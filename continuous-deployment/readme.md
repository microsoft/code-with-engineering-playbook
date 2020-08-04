# Continuous Deployment

Continuous Deployment can be thought of as a deployment pipeline where a piece of software needs to be validated before getting released anytime into production. It is a software engineering process where each functionality is pushed into production through automated deployments.

Continuous deployments can be achieved by creating different environments in [Azure DevOps](https://docs.microsoft.com/en-us/aspnet/core/azure/devops/cicd) using pipelines or by using multiple [GitHub workflows](https://docs.github.com/en/actions/configuring-and-managing-workflows/configuring-a-workflow). These environments can be used for different reasons like some environments are used for development and testing while others are used for production.

More details on environments can be seen [below](#Environments) and the steps for setting up different environments using GitHub workflows can be found [here](../continuous-deployment/pipelines/recipes/github-workflows/workflow-per-environment.md).

Azure DevOps Pipelines or Github Workflows is a way to automatically build and test your code project and make it available to other users. It works with just about any language or project type.

It combines continuous integration (CI) and continuous Deployment (CD) to constantly and consistently test and build your code and ship it to any target. Using the above tools, you can achieve Continuous Delivery or Continuous Deployment, depending on the your development and release cycle and the customer environment. To understand more about Continuous Delivery and Continuous Deployment, and their differences, please refer to the link in the [references](#References) section below.

There are a few suggestions listed below to keep in mind when creating Azure DevOps pipelines/ Github workflows for continuous deployment:

1. Keep your pipelines as fast as feasible
1. Isolate and secure your CI/CD environment
1. Make the CI/CD pipeline the only way to deploy to production
1. Maintain parity with production wherever possible
1. Build only once and promote the result through the pipeline
1. Run your fastest tests early to make sure you fail out fast to help unblock resources
1. Minimize branching in your version control system
1. Run tests locally before committing to the CI/CD pipeline
1. Run tests in temporary environments when possible

For additional information and details on CI/CD please refer to this [link](../continuous-integration/CICD.md).

## Environments

Environments can be used for different reasons, like some environments are used for development and testing while others are used for production.

Specific environments are protected to prevent unauthorized users from affecting them, since deployments can be executed by different users with different roles. Thus protected environment ensures safety by only letting users with the required privileges, deploy to an environment.

Continuous deployment pipelines help promote changes through automated testing and deployment cycles, out to staging environments and finally to production. The more detailed and comprehensive a testing pipeline is, there is more confidence that the changes wont introduce issues in your production deployment. Since the change must go through the entire process of being tested and deployed, keeping pipelines and deployment environments fast and dependable is of utmost importance.

To understand more about deployment environments, and their differences, please refer to the link in the [references](#References) section below.

## Sections within Continuous Deployment

* [Secrets Management](secrets-management/readme.md)

## References

* [Deployment Environment](https://en.wikipedia.org/wiki/Deployment_environment)
* [Continuous integration vs. continuous delivery vs. continuous deployment](https://www.atlassian.com/continuous-delivery/principles/continuous-integration-vs-delivery-vs-deployment)
