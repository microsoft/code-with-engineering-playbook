# Continuous Deployment

Continuous Deployment can be thought of as a deployment pipeline where a piece of software needs to be validated before getting released anytime into production. It is a software engineering process where each functionality is pushed into production through automated deployments.

Continuous deployments can be achieved by creating different environments in [Azure DevOps](https://docs.microsoft.com/en-us/aspnet/core/azure/devops/cicd) or by using multiple [GitHub workflows](https://docs.github.com/en/actions/configuring-and-managing-workflows/configuring-a-workflow). These environments can be used for different reasons like some environments are used for development and testing while others are used for production.

More details on environments and the steps for setting up different environments using GitHub workflows can be found [here](../continuous-deployment/pipelines/recipes/github-workflows/workflow-per-environment.md).

For additional information and details on CI/CD please refer to this [link](../continuous-integration/CICD.md).

## Sections within Continuous Deployment

* [Secrets Management](secrets-management/readme.md)
* [Pipelines](pipelines/readme.md)
