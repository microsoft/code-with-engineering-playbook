# Code Review for Azure Pipelines YAML Files

## Overview

In this document you'll find a code review guidance for Azure Pipelines YAML files and nested YAML files. When our pipeline is triggered, before running the pipeline, there are some different phases such as `Queue Time`, `Compile Time` and `Runtime`, in these phases your variables are interpretted by their [runtime expression syntax](https://docs.microsoft.com/en-us/azure/devops/pipelines/process/variables?view=azure-devops&tabs=yaml%2Cbatch#runtime-expression-syntax).

When pipeline is triggered all nested YAML files are expanded to run in Azure Pipelines. This document visits some tips and tricks for reviewing all nested YAML files.

Before starting review, make sure you check [Azure Pipelines YAML documentation](https://docs.microsoft.com/en-us/azure/devops/pipelines/yaml-schema).

Also you need to check [Key concepts for new Azure Pipelines](https://docs.microsoft.com/en-us/azure/devops/pipelines/get-started/key-pipelines-concepts?view=azure-devops)

To understand how pipelines work check [Pipeline run sequence](https://docs.microsoft.com/en-us/azure/devops/pipelines/process/runs?view=azure-devops)

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

## Pipeline Structure

- [ ] First understand [Pipeline structure](https://docs.microsoft.com/en-us/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema#pipeline-structure) and identify components
- [ ] Check the pipeline in Azure Pipelines
- [ ] Edit the pipeline in Azure Pipelines and find root file
- [ ] Find templates called in the pipeline
- [ ] Make sure that where template file is referenced, changing one file may effect multiple pipelines
- [ ] Avoid long scipts inline in YAML file, consider to separate into a script file

## YAML Structure

- [ ] Avoid big templates, check and identify re-usable components
- [ ] Separate environment specific variables
  - [ ] Consider using variable templates per environment
  - [ ] Or consider using variable group per environment in Azure Pipelines Library
- [ ] Consider changes of your values during `Queue Time`, `Compile Time` and `Runtime`
- [ ] Check variable syntax values used with `Macro Syntax`, `Template Expression Syntax` and `Runtime Expression Syntax`
- [ ] Is there any unused variable or parameter?
- [ ] Does your pipeline meet with stage/job `Conditions` criterias?
- [ ] Consider value changes: Variables can change during the pipeline, Parameters cannot

## Permission Check & Security

- [ ] Make sure pipeline is not printing any secret value in script
- [ ] Use `issecret` for printing secrets for debugging
- [ ] If pipeline is using variable groups in Library, Does it have an access?
- [ ] If pipeline has a remote task in other repo/organization, Does it have an access?
- [ ] If pipeline is trying to access a secure file, do you have the permission?
- [ ] If pipeline requires approval for environment deployments, Who is the approver?
- [ ] Do you need to keep secrets and manage them, Did you consider to use Azure KeyVault?

## Scenarios

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

## References

- [Azure Pipelines documentation](https://docs.microsoft.com/en-us/azure/devops/pipelines/)
- [Understanding Azure DevOps Variables](https://adamtheautomator.com/azure-devops-variables)
- [Configuring CI/CD Pipelines as Code with YAML in Azure DevOps](https://azuredevopslabs.com/labs/azuredevops/yaml/)
- [Using secrets from Azure Key Vault in a pipeline](https://azuredevopslabs.com/labs/vstsextend/azurekeyvault)
