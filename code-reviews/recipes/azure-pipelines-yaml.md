# YAML(Azure Pipelines) Code Reviews

## Syle Guide

[CSE](../../CSE.md) developers follow the [YAML schema reference](https://docs.microsoft.com/en-us/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema).

## Code Analysis / Linting

The most popular YAML linter is [YAML](https://marketplace.visualstudio.com/items?itemName=redhat.vscode-yaml) extension. This extension provides YAML validation, document outlining, Auto completion, Hover support and Formatter features.

## VS Code Extensions

There is an [Azure Pipelines for VS Code](https://marketplace.visualstudio.com/items?itemName=ms-azure-devops.azure-pipelines) extension to add syntax highlighting and autocompletion for Azure Pipelines YAML to VS Code. It also helps you set up continuous build and deployment for Azure WebApps without leaving VS Code.

## YAML in Azure Pipelines Overview

When the pipeline is triggered, before running the pipeline, there are some different phases such as `Queue Time`, `Compile Time` and `Runtime`, in these phases variables are interpretted by their [runtime expression syntax](https://docs.microsoft.com/en-us/azure/devops/pipelines/process/variables?view=azure-devops&tabs=yaml%2Cbatch#runtime-expression-syntax).

When pipeline is triggered all nested YAML files are expanded to run in Azure Pipelines. This check list visits some tips and tricks for reviewing all nested YAML files.

Before starting review please see the following documents:

- Make sure to check [Azure Pipelines YAML documentation](https://docs.microsoft.com/en-us/azure/devops/pipelines/yaml-schema).

- Understand how pipelines work [Pipeline run sequence](https://docs.microsoft.com/en-us/azure/devops/pipelines/process/runs?view=azure-devops)

- Get familiar with [Key concepts for new Azure Pipelines](https://docs.microsoft.com/en-us/azure/devops/pipelines/get-started/key-pipelines-concepts?view=azure-devops)

  **Key concepts overview**
![Azure Pipelines key concepts](images/key-concepts-overview.png)

  - A trigger tells a Pipeline to run.
  - A pipeline is made up of one or more stages. A pipeline can deploy to one or more environments.
  - A stage is a way of organizing jobs in a pipeline and each stage can have one or more jobs.
  - Each job runs on one agent. A job can also be agentless.
  - Each agent runs a job that contains one or more steps.
  - A step can be a task or script and is the smallest building block of a pipeline.
  - A task is a pre-packaged script that performs an action, such as invoking a REST API or publishing a build artifact.
  - An artifact is a collection of files or packages published by a run.

## Code Review Checklist

In addition to the [Code Review Checklist](../process-guidance/reviewer-guidance.md) you should also look for these Azure Pipelines YAML specific code review items.

### Pipeline Structure

- [ ] First understand [Pipeline structure](https://docs.microsoft.com/en-us/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema#pipeline-structure) and identify components
- [ ] Check the pipeline in Azure Pipelines
- [ ] Edit the pipeline in Azure Pipelines and find root file
- [ ] Find templates called in the pipeline
- [ ] Check all the template file references to ensure it does not cause breaking changes, changing one file may effect multiple pipelines
- [ ] Avoid long inline scipts in YAML file, consider to separate into a script file

### YAML Structure

- [ ] Avoid big templates, check and identify re-usable components
- [ ] Separate environment specific variables
  - [ ] Consider using variable templates per environment
  - [ ] Or consider using variable group per environment in Azure Pipelines Library
- [ ] Consider changes of values during `Queue Time`, `Compile Time` and `Runtime`
- [ ] Check variable syntax values used with `Macro Syntax`, `Template Expression Syntax` and `Runtime Expression Syntax`
- [ ] Is there any unused variable or parameter? Make sure those are removed in pipeline.
- [ ] Does the pipeline meet with stage/job `Conditions` criterias?
- [ ] Consider value changes: Variables can change during the pipeline, Parameters cannot

### Permission Check & Security

- [ ] Make sure pipeline is not printing any secret value in script
- [ ] Use `issecret` for printing secrets for debugging
- [ ] If pipeline is using variable groups in Library, ensure pipeline has access to the variable groups created.
- [ ] If pipeline has a remote task in other repo/organization, does it have an access?
- [ ] If pipeline is trying to access a secure file, does it have the permission?
- [ ] If pipeline requires approval for environment deployments, Who is the approver?
- [ ] Does it need to keep secrets and manage them, did you consider using Azure KeyVault?

### Troubleshooting Tips

- Consider Variable Syntax with [Runtime Expressions](https://docs.microsoft.com/en-us/azure/devops/pipelines/process/variables?view=azure-devops&tabs=yaml%2Cbatch#runtime-expression-syntax) in the pipeline. Here is a nice sample to understand [Expansion of variables](https://docs.microsoft.com/en-us/azure/devops/pipelines/process/variables?view=azure-devops&tabs=yaml%2Cbatch#expansion-of-variables).

- When we assign variable like below it won't set during the initialize time, it'll assign during runtime, then we can retrieve some errors based on when template runs.

  ```yaml
  - task: AzureWebApp@1
    displayName: 'Deploy Azure Web App : $(webAppName)'
    inputs:
      azureSubscription: '$(azureServiceConnectionId)'
      appName: '$(webAppName)'
      package: $(Pipeline.Workspace)/drop/Application$(Build.BuildId).zip
      startUpCommand: 'gunicorn --bind=0.0.0.0 --workers=4 app:app'
  ```

  Error:

  ![authorization issue due to initialize time](images/authorization_issue_due_to_initialize_time.png)

  After passing these variables as parameter, it loads values properly.

  ```yaml
    - template: steps-deployment.yaml
      parameters:
        azureServiceConnectionId: ${{ variables.azureServiceConnectionId  }}
        webAppName: ${{ variables.webAppName  }}
  ```

  ```yaml
  - task: AzureWebApp@1
    displayName: 'Deploy Azure Web App :${{ parameters.webAppName }}'
    inputs:
      azureSubscription: '${{ parameters.azureServiceConnectionId }}'
      appName: '${{ parameters.webAppName }}'
      package: $(Pipeline.Workspace)/drop/Application$(Build.BuildId).zip
      startUpCommand: 'gunicorn --bind=0.0.0.0 --workers=4 app:app'
  ```

- Use `issecret` for printing secrets for debugging

  ```bash
  echo "##vso[task.setvariable variable=token;issecret=true]${token}"
  ```
