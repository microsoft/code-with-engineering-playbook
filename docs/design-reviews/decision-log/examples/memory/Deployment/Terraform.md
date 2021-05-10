# Overview

[Terraform](https://www.terraform.io/) is an open-source infrastructure as code software tool that provides a consistent CLI workflow to manage hundreds of cloud services.
Terraform codifies cloud APIs into declarative configuration files.

Terraform source files are located in the `~/terraform` folder.

## Projects

- **state** - Terraform templates to deploy the Terraform azure remote state provider
- **infrastructure** - Templates to deploy the run time components for the Memory application

## Remote State

[Remote State](https://www.terraform.io/docs/language/state/remote.html) is leveraged to share the Terraform state files in a central location used by AzDO during continuous deployment.

Since we are already leverage Azure as our deployment target we are also using the [Azure remote backend provider](https://www.terraform.io/docs/language/settings/backends/azurerm.html) that stores the state within a separate blob storage account.

## Pipeline

The following workflow illustrates the Terraform deployment process kicked off through the `Infrastructure CD` AzDO pipeline.

The Terraform templates also contain resources to configure the k8s cluster leveraging [ArgoCD](Argo-CD.md) for our GitOps deployment model.

![Terraform Deployment](../.attachments/terraform-deployment.png)
