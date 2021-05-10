# Trade Study: Automated Deployment

Conducted by: Jeff jeding@microsoft.com, Tess tedistef@microsoft.com

Backlog Work Item: #21651

Decision: ARM Templates

Decision Makers: Team

## Overview

In order to make the deployment more effectively, we would like to make the analysis on different automated deployment tools for Azure cloud infrastructure.

### Summary

Both ARM templates and Terraform are widely supported by Azure.
Pulumi has way smaller adoption than Terraform, so we might not consider at this moment.

With ARM templates, it is only supported by Azure platform.
If considering letting other team to maintain in the future, then ARM templates option might be better due to less upskilling and better monitoring supported by Azure portal.

Terraform can support multiple cloud providers, including Azure, AWS, GCP, and more, and it also stated as one of two widely used option in Azure doc.

### Evaluation Criteria

1. File Type: Which file types are supported? (YAML, JSON, or customized)
1. Platforms: Which platforms are supported? (Azure, AWS, GCP)
1. Upskilling: Is this a new technology which will help us prepare for future projects?
1. Azure Portal Monitoring: Can it be monitored in the Azure Portal?
1. Incremental updates support for CI/CD?

The results section contains a table evaluating each solution against the evaluation criteria.

## Solutions

### {Solution 1} ARM Templates

- [ARM Templates](https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/overview) is a way to declare the objects you want.
  The types, names, and properties in a JSON file which can be checked into source control and managed like any other code file.
- ARM Templates can deploy several resources together in a single unit and the deployments are idempotent.
- ARM uses JSON, you can put variables in a separate file and refer to the variables in the main configuration file (supporting conditionals, nested templates).
- Able to import nested templates from files, URLs, but the file needs to be accessible by ARM during deployment (not locally).
- Az CLI can validate the ARM templates without deploying
- It's capable to rollback to previous successful deployment.

#### ARM Templates Evaluation Criteria

1. File Type: Which file types are supported? (YAML, JSON, or customized)
   - JSON
1. Platforms: Which platforms are supported? (Azure, AWS, GCP)
   - Azure
1. Upskilling: Is this a new technology which will help us prepare for future projects?
   - Yes, this can be a useful experience for future projects, and it will be new upskilling.
1. Azure Portal Monitoring: Can it be monitored in the Azure Portal?
   - Yes, Azure Portal supports monitoring the progress of the deployment, deployment events, check various errors.
1. Incremental updates support for CI/CD?
   - Yes.

![Architecture1](https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/media/overview/3-tier-template.png)
![Architecture2](https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/media/overview/nested-tiers-template.png)
![Architecture3](https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/media/overview/tier-templates.png)

### {Solution 2} Terraform

- It's OSS.
- [Terraform](https://docs.microsoft.com/en-us/azure/developer/terraform/overview) support multi-cloud services and can deploy the same setup to Azure, AWS, GCP, on-premises servers and other location by design.
- No matter which provider, all HashiCorp Terraform configuration files use HCL (HashiCorp Configuration Language).
- HashiCorp Terraform has a resource called `azurerm_resource_group_template_deployment` for the AzureRM provider.
  This resource allows you to deploy an ARM Template through HashiCorp Terraform without changing anything.
- Terraform's modularity and comments helps Readability.
- No Azure Portal support for monitoring.
- Most error messages Terraform spit are pretty obvious, but if some error messages can be difficult to interpret.
- Terraform provides a backend state mechanism for state management.
- Terraform produces a state file that contains deployment data as plain text, including variables, resource information, accounts, etc.
  Might cause issue if checking these confidential info into source control.
- No formal rollback support in Terraform.
  You will need to update and re-apply for the updates.
- The `terraform init` download numerous copies of the terraform-modules Repo.
  If two or more Resource Group folder pin to the same Module Tag, it will download the code from git Repo multiple times.

#### Terraform Evaluation Criteria

1. File Type: Which file types are supported? (YAML, JSON, or customized)
   - Terraform configuration file (.tf)
1. Platforms: Which platforms are supported? (Azure, AWS, GCP)
   - Azure, AWS, GCP, on-premises
1. Upskilling: Is this a new technology which will help us prepare for future projects?
   - Yes, this can be a useful experience for future projects, and it will be new upskilling.
1. Azure Portal Monitoring: Can it be monitored in the Azure Portal?
   - No
1. Incremental updates support for CI/CD?
   - No, Terraform will only destroy resources if it cannot edit them.
     If Terraform thinks an edit would work, it will just update the service, but many things are immutable after you've created the resource, like name.
     If you change an immutable property, Terraform will destroy and then create new resource.

#### Terraform Resources

- [Terraform](https://www.terraform.io)
- [Terraform Github repo](https://github.com/hashicorp/terraform)
- [Terraform Azure tutorial](https://learn.hashicorp.com/collections/terraform/azure-get-started)
- [Terraform Azure CI/CD setup tutorial](https://azuredevopslabs.com/labs/vstsextend/terraform/)

#### Terraform Community

- Stars: 25,300
- Forks: 6,400
- Last Commit: 1/27/2021

### {Solution 3} Pulumi

- Pulumi supports many languages, and the ones focused on in their docs are Go, JavaScript/TypeScript, Java, C#
- Pulumi can be used with the Azure CLI after some configuration
- Changes are deployed (to Azure or elsewhere) using the Pulumi console command `pulumi up`
- There are [tutorials](https://www.pulumi.com/docs/get-started/azure/next-steps/) on the website for integrations with Azure Function Apps, App Services with SQL and App Insights, AKS clusters, CosmosDB, etc.

#### Pulumi Evaluation Criteria

1. File Type: Which file types are supported? (YAML, JSON, or customized)
   - Pulumi manages projects via YAML however their docs explain how to import from terraform, arm, helm, and cloudformation.
   - Multiple environments are supported through separate environment-specific YAML files
1. Platforms: Which platforms are supported? (Azure, AWS, GCP)
   - Azure, AWS, GCP
1. Upskilling: Is this a new technology which will help us prepare for future projects?
   - We think that yes, this can be a useful experience for future projects.
     And it will be new upskilling.
1. Azure Portal Monitoring: Can it be monitored in the Azure Portal?
   - No
1. Incremental updates support for CI/CD?
   - No finding.

#### Pulumi Resources

[Pulumi](https://www.pulumi.com/)

#### Pulumi Community

- Stars: 7602
- Forks: 394
- Last Commit: 2/1/2021

### {Solution 4} Azure CLI (AzCLI)

AzCLI is a simple, lightweight solution that makes single deployments very straightforward.
It can be used to manually deploy, or it can be automated through any scripting language that can execute CLI commands.

#### AzCLI Evaluation Criteria

1. File Type: Which file types are supported? (YAML, JSON, or customized)
   - AzCLI is a command line tool set.
     However, it is possible to set up a CD pipeline to run an executable such as a bash or batch script.
1. Platforms: Which platforms are supported? (Azure, AWS, GCP)
   - Azure only
1. Upskilling: Is this a new technology which will help us prepare for future projects?
   - We think that yes, this can be a useful experience for future projects.
     And it will be new upskilling.
1. Azure Portal Monitoring: Can it be monitored in the Azure Portal?
   - No

#### AzCLI Resources

[AzCLI docs](https://docs.microsoft.com/en-us/cli/azure/)

[AzCLI startup](https://docs.microsoft.com/en-us/cli/azure/get-started-with-azure-cli)

#### AzCLI Community

AzCLI is widely used but it is not OSS.

## Results

This section should contain a table that has each solution rated against each of the evaluation criteria:

| Solution      | File Type                                | Platforms                    | Upskilling | Azure Portal Monitoring |
| ------------- | ---------------------------------------- | ---------------------------- | ---------- | ----------------------- |
| ARM Templates | JSON                                     | Azure only                   | Yes        | Yes                     |
| Terraform     | HCL structure (.tf)                      | Azure, AWS, GCP, on-premises | Yes        | No                      |
| Pulumi        | YAML                                     | Azure, AWS, GCP, k8s         | Yes        | No                      |
| AzCLI         | executable that can execute CLI commands | Azure only                   | Yes        | No                      |

## Decision

We have decided to go with ARM because:

- ARM is Azure Native with monitoring support in the portal
- Because we will be deploying Azure resources, we are not concerned about being cloud agnostic
- ARM supports incremental updates and rollbacks
- Because ARM is in house by Azure, it will support new features before they are adopted by Terraform
- ARM can be integrated into a CI/CD pipeline naturally without much overhead
