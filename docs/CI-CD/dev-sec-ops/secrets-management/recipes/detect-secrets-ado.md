# Running `detect-secrets` in Azure DevOps Pipelines

## Overview

In this article, you can find information on how to integrate YELP detect-secrets into your Azure DevOps Pipeline. The proposed code can be part of the classic CI process or (preferred way) build validation for PRs before merging to the `main` branch.

## Azure DevOps Pipeline

Proposed Azure DevOps Pipeline contains multiple steps described below:

1. Set Python 3 as default
1. Install detect-secrets using pip
1. Run detect-secrets tool
1. Publish results in the Pipeline Artifact
   > **Note:** It's an optional step, but for future investigation .json file with results may be helpful.
1. Analyzing detect-secrets results
   > **Note:** This step does a simple analysis of the .json file. If any secret has been detected, then break the build with exit code 1.

> **Note:** The below example has 2 jobs: for Linux and Windows agents. You do not have to use both jobs - just adjust the pipeline to your needs.
>
> **Note:** Windows example does not use the latest version of detect-secrets. It is related to the bug in the detect-secret tool (see more in [Issue#452](https://github.com/Yelp/detect-secrets/issues/452)). It is highly recommended to monitor the fix for the issue and use the latest version if possible by removing version tag `==1.0.3` in the pip install command.

```yaml
trigger:
  - none

jobs:
  - job: ubuntu
    displayName: "detect-secrets on Ubuntu Linux agent"
    pool:
      vmImage: ubuntu-latest
    steps:
      - task: UsePythonVersion@0
        displayName: "Set Python 3 as default"
        inputs:
          versionSpec: "3"
          addToPath: true
          architecture: "x64"

      - bash: pip install detect-secrets
        displayName: "Install detect-secrets using pip"

      - bash: |
          detect-secrets --version
          detect-secrets scan --all-files --force-use-all-plugins --exclude-files FETCH_HEAD > $(Pipeline.Workspace)/detect-secrets.json
        displayName: "Run detect-secrets tool"

      - task: PublishPipelineArtifact@1
        displayName: "Publish results in the Pipeline Artifact"
        inputs:
          targetPath: "$(Pipeline.Workspace)/detect-secrets.json"
          artifact: "detect-secrets-ubuntu"
          publishLocation: "pipeline"

      - bash: |
          dsjson=$(cat $(Pipeline.Workspace)/detect-secrets.json)
          echo "${dsjson}"

          count=$(echo "${dsjson}" | jq -c -r '.results | length')

          if [ $count -gt 0 ]; then
            msg="Secrets were detected in code. ${count} file(s) affected."
            echo "##vso[task.logissue type=error]${msg}"
            echo "##vso[task.complete result=Failed;]${msg}."
          else
            echo "##vso[task.complete result=Succeeded;]No secrets detected."
          fi
        displayName: "Analyzing detect-secrets results"

  - job: windows
    displayName: "detect-secrets on Windows agent"
    pool:
      vmImage: windows-latest
    steps:
      - task: UsePythonVersion@0
        displayName: "Set Python 3 as default"
        inputs:
          versionSpec: "3"
          addToPath: true
          architecture: "x64"

      - script: pip install detect-secrets==1.0.3
        displayName: "Install detect-secrets using pip"

      - script: |
          detect-secrets --version
          detect-secrets scan --all-files --force-use-all-plugins > $(Pipeline.Workspace)/detect-secrets.json
        displayName: "Run detect-secrets tool"

      - task: PublishPipelineArtifact@1
        displayName: "Publish results in the Pipeline Artifact"
        inputs:
          targetPath: "$(Pipeline.Workspace)/detect-secrets.json"
          artifact: "detect-secrets-windows"
          publishLocation: "pipeline"

      - pwsh: |
          $dsjson = Get-Content $(Pipeline.Workspace)/detect-secrets.json
          Write-Output $dsjson

          $dsObj = $dsjson | ConvertFrom-Json
          $count = ($dsObj.results | Get-Member -MemberType NoteProperty).Count

          if ($count -gt 0) {
            $msg = "Secrets were detected in code. $count file(s) affected. "
            Write-Host "##vso[task.logissue type=error]$msg"
            Write-Host "##vso[task.complete result=Failed;]$msg"
          }
          else {
            Write-Host "##vso[task.complete result=Succeeded;]No secrets detected."
          }
        displayName: "Analyzing detect-secrets results"
```
