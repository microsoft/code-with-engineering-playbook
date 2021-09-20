# Create Documentation Website

This folder contains the Terraform scripts for creating the documentation website. The terraform command to deploy this website is executed in the **.pipelines/documentation.yml**.

More explanation of the use of these files can be found int the article Deploy the DocFx Documentation website to an Azure Website automatically **TODO: fix url**  ://github.com/microsoft/code-with-engineering-playbook/tree/main/docs/documentation/recipes/deploy-docfx-azure-website.html).

## Running Terraform locally

To run these scripts, first make sure you set the proper values of the variables.

> IMPORTANT: Make sure you modify the value of the **app_name** variable. This value is appended by **azurewebsites.net** and must be unique. Otherwise the script will fail that it cannot create the website.

To install Terraform, you can use [Chocolatey](https://chocolatey.org/install):

```shell
choco install terraform
```

To run the terraform scripts from your local developer machine, make sure to modify the **providers.tf**. Comment the **backend** definition as instructed.

Next make the connection with the Azure environment by running the [Azure Cli](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-windows?tabs=azure-cli) command:

```shell
az login
```

Next you can initialize Terraform:

```shell
terraform init
```

The you can plan the terraform actions:

```shell
terraform plan
```

And apply the terraform script with:

```shell
terraform apply
```

When asked for approval, type "yes" followed by ENTER. You can also add the *-auto-approve* flag to the terraform apply command.
