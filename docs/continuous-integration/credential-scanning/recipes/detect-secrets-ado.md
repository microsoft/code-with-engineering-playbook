# Detecting secrets in your Azure DevOps Pipeline with YELP detect-secrets

## Overview

In this article, you can find information on how to integrate YELP detect-secrets into your Azure DevOps Pipeline. The proposed code can be part of the classic CI process or (preferred way) build validation for PRs before merging to the main branch.

## Azure DevOps Pipeline

Proposed Azure DevOps Pipeline contains multiple steps described below:

1. Set Python 3 as default
1. Install detect-secrets using pip
1. Run detect-secrets tool
   > NOTE: In this example, the tool gets additional parameters. The most important is `--custom-plugins`, which points to the custom plugin for Azure Storage Account Key detection.
   > This plugin is not part of the official YELP detect-secrets yet, so you have to provide it in your codebase. Reference code you can find under the [Custom plugin example](#custom-plugin-example) section.
1. Publish results in the Pipeline Artifact
   > NOTE: It's an optional step, but for future investigation .json file with results may be helpful.
1. Analyzing detect-secrets results
   > NOTE: This step does a simple analysis of the .json file. If any secret has been detected, then break the build.

```yaml
trigger:
  - none

pool:
  vmImage: "windows-latest"

steps:
  - task: UsePythonVersion@0
    displayName: "Set Python 3 as default"
    inputs:
      versionSpec: 3

  - task: CmdLine@2
    displayName: "Install detect-secrets using pip"
    inputs:
      script: |
        pip install detect-secrets

  - task: CmdLine@2
    displayName: "Run detect-secrets tool"
    inputs:
      script: |
        detect-secrets scan --exclude-files "src\\Web\\wwwroot\\lib\\*" --use-all-plugins --custom-plugins yelp\azure_storage_key.py > detect-secrets.json

  - task: PublishPipelineArtifact@1
    displayName: "Publish results in the Pipeline Artifact"
    inputs:
      targetPath: "$(Pipeline.Workspace)/detect-secrets.json"
      artifact: "detect-secrets"
      publishLocation: "pipeline"

  - task: PowerShell@2
    displayName: "Analyzing detect-secrets results"
    inputs:
      targetType: "inline"
      script: |
        $ds = Get-Content detect-secrets.json
        Write-Output $ds

        $dsObj = $ds | ConvertFrom-Json
        $num = ($dsObj.results | Get-Member -MemberType NoteProperty).Count

        if ($num -gt 0) {
          Write-Host "##vso[task.logissue type=error]Secrets were detected in code."
          exit 1
        }
        else {
          Write-Host "No secrets detected."
        }
      pwsh: true
```

## Custom plugin example

The below example contains a custom plugin for YELP detect-secrets. This plugin is a Detector for Azure Storage Account access keys.

```python
"""
This plugin searches for Azure Storage Account access keys.
"""
import re


from detect_secrets.plugins.base import RegexBasedDetector


class AzureStorageKeyDetector(RegexBasedDetector):
    """Scans for Azure Storage Account access keys."""
    secret_type = 'Azure Storage Account access key'

    denylist = [
        re.compile(r'AccountKey=[a-zA-Z0-9+\/=]{88}'),
    ]
```
