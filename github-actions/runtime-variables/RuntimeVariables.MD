# Runtime Variables in Github Actions

## Objective
While Github Actions is a popular choice for writing and running CI/CD pipelines, especially for open source projects hosted on Github, it lacks specific quality of life features found in other CI/CD environments. One key feature that Github Actions has not yet implemented is the ability to **mock and inject runtime variables** into a workflow, in order to test the pipeline itself.

## Target Audience
This guide assumes that you are familiar with CI/CD, and understand the security implications of CI/CD pipelines. We assume that you, as a CI/CD engineer, want to inject environment variables or environment flags into your pipelines and workflows in order to test them, and are using Github Actions to accomplish this.

## Usage Scenario
Many integration or end-to-end workflows require specific environment variables that are only available at rutime. For example, a workflow might be doing the following:

![Workflow Diagram](images/workflow-diagram.png)

In this situation, testing the pipeline is extremely difficult without having to make external calls to the resource. In many cases, making external calls to the resource can be expensive or time consuming, significantly slowing down inner loop development.

Azure Dev Ops, as an example, offers a way to define pipeline variables on a manual trigger:

![AzDo Example](images/AzDoExample.PNG)

Github Actions does not do so yet.

## Solution
To workaround this, the easiest solution is to add runtime variables to either commit messages or the PR Body, and `grep` for the variable. **This is NOT for injecting secrets** as the commit messages and PR body can be retrieved by a third party, are stored in `git log`, and can otherwise be read by a malicious individual using a variety of tools. Rather, this is for testing a workflow that needs simple variables to be injected into it, as above.

**If you need to retrieve secrets or sensitive information**, use the ![Github Action for Azure Key Vault](https://github.com/marketplace/actions/azure-key-vault-get-secrets) or some other similar secret storage and retrieval service.

### Commit Message Variables

