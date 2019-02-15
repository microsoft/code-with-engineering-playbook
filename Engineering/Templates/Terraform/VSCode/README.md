# Terraform VS Code Boostrap Project

The following project provides a template for developing terraform templates within vs code. It contains the following features

1. Execute terraform commands from the task runner (`CTRL+SHIFT+P > Run Tasks`)
2. Store terraform variable values in workspace and/or settings so that they are not committed to source control.

## Setup/Configuration

The following steps must be completed before vs code will be able to execute terraform commands.

### Install Terraform

Terraform executable should be downloaded [here](https://www.terraform.io/downloads.html) for the appropriate OS. The terraform executable should be added to the PATH variable.

### Create a Service Principal

Terraform currently only supports running as service principal. While you can run as a user, the templates will not be able to obtain any context about the user executing the templates. This can create issues when templates need to grant permissions to resources such as Key Vault. Therefore, it is reccomended to create a service principal with at minimum Contributor role. User Access Administrator role will be needed if the SPN is granting privileges to resources such as Key Vault.

### Create a Remote Backend (Opt)

The vs code tasks will expect that a remote backend is being used to track the terraform state. Prior to running the tasks, a backend must be created. The credentials for the backend will be provided to the settings in the subsequent steps for backend initialization.

### Configure Environment Settings

1. Open up the .vscode\settings.json file.
2. Paste the following json into the settings.json and update the values accordingly

```js
    "terraform" : {
        // the following configures the service principal and subscription to use when executing terraform commands
        "azurerm" : {
            "tenant_id" : "Tenant to use when executing terraform commands",
            "subscription_id" : "Subscription to use when executing terraform commands",
            "client_id" : "Service principal app id to use when executing terraform commands",
            "client_secret" : "Service principal password to use when executing terraform commands",
            "backend" : {
                "storage_account_name" : "name of the storage account",
                "access_key" : "primary/secondary access key to the storage account",
                "resource_group_name" : "resource group to which the storage account is assigned",
                "container_name" : "storage account blob container name to store the state",
                "key" : "the name of the blob file to store the state"
            }
        },
        // the values to provide to the terraform template when running commands
        "tfvars" : {
            // these are variables required for the provided sample template.
            // they should be updated to reflect the variables for the real template.
            "env" : "dev",
            "org" : "czp",
            "location" : "eastus"
        }
    }
```

## Run Terraform Commands

Once the environment settings are configured, and the backend has been created, you can begin executing terraform commands. VS Code tasks have been configured to run each of the commonly used terraform commands. These can be accessed via `CTRL+SHIFT+P` > `Tasks: Run Tasks`. Each of these tasks will take its input from what has been configured in `.vscode/settings.json`

- `terraform init`: installs plugins and connects terraform to the remote backend configured in `.vscode/settings.json`
- `terraform validate`: checks templates for syntax errors
- `terraform plan`: reports what would be done with apply without actually deploying any resources
- `terraform apply`: deploys the terraform templates
- `terraform destroy`: remove anything deployed with the templates. Uses `.vscode/settings.json` to determine what should be destroyed