# Terraform Code Reviews

## Style Guide

[CSE](../../CSE.md) developers follow the [hashicorp style guide](https://www.terraform.io/docs/configuration/style.html).

[CSE](../../CSE.md) projects should check Terraform scripts with automated tools.

## Code Analysis / Linting

### TFLint

[`TFLint`](https://github.com/terraform-linters/tflint) is a Terraform linter focused on possible errors, best practices, etc. Once TFLint installed in the environment, it can be invoked using the VS Code [`terraform extension`](https://marketplace.visualstudio.com/items?itemName=mauve.terraform).

## VS Code Extensions

The following VS Code extensions are widely used.

### [`Terraform extension`](https://marketplace.visualstudio.com/items?itemName=mauve.terraform)

This extension provides syntax highlighting, linting, formatting and validation capabilities.

### [`Azure Terraform extension`](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azureterraform)

This extension provides Terraform command support, resource graph visualization and CloudShell integration inside VS Code.

## Build Validation

Ensure you enforce the style guides during build. The following example script can be used to install terraform and a linter that
then checks for formatting and common errors.

```shell
#! /bin/bash
set -e

SCRIPT_DIR=$(dirname "$BASH_SOURCE")
cd "$SCRIPT_DIR"

TF_VERSION=0.12.4
TF_LINT_VERSION=0.9.1

echo -e "\n\n>>> Installing Terraform 0.12"
# Install terraform tooling for linting terraform
wget -q https://releases.hashicorp.com/terraform/${TF_VERSION}/terraform_${TF_VERSION}_linux_amd64.zip -O /tmp/terraform.zip
sudo unzip -q -o -d /usr/local/bin/ /tmp/terraform.zip

echo ""
echo -e "\n\n>>> Install tflint (3rd party)"
wget -q https://github.com/wata727/tflint/releases/download/v${TF_LINT_VERSION}/tflint_linux_amd64.zip -O /tmp/tflint.zip
sudo unzip -q -o -d /usr/local/bin/ /tmp/tflint.zip

echo -e "\n\n>>> Terraform version"
terraform -version

echo -e "\n\n>>> Terraform Format (if this fails use 'terraform fmt -recursive' command to resolve"
terraform fmt -recursive -diff -check

echo -e "\n\n>>> tflint"
tflint

echo -e "\n\n>>> Terraform init"
terraform init

echo -e "\n\n>>> Terraform validate"
terraform validate
```

## Code Review Checklist

In addition to the [Code Review Checklist](../process-guidance/reviewer-guidance.md) you should also look for these Terraform specific code review items

* [ ] Are all providers used in the terraform scripts [versioned](https://www.terraform.io/docs/configuration/providers.html#provider-versions) to prevent breaking changes in the future?
* [ ] Are modules split into separate `.tf` files where appropriate?
* [ ] Does the repository contain a `README.md` describing the architecture provisioned?
* [ ] Is the Terraform project configured using Azure Storage as remote state backend?
* [ ] Is the remote state backend storage account key is stored a secure location (e.g. Azure Key Vault)?
* [ ] If Terraform code is mixed with application source code, is the Terraform code isolated into a dedicated folder?
* [ ] If the infrastructure is going to different depending on the environment (e.g. Dev, UAT, Production), are the environment specific parameters supplied via `.tfvars` file?
* [ ] Is the project configured to use state file based on the environment and the deployment pipeline configured to supply the state file name dynamically?
* [ ] Are the resource definitions and data sources handled correctly in the Terraform scripts?
    resource : Indicates to Terraform that the current configuration is in charge of managing the life cycle of the object
    data: Indicates to Terraform that you only want to get a reference to the existing object, but don’t want to manage it as part of this configuration
* [ ] Is the code split into multiple reusable modules?
* [ ] Are unit and integration tests used for Terraform code (e.g. [`Terratest`](https://terratest.gruntwork.io/), [`terratest-abstraction`](https://github.com/microsoft/terratest-abstraction))?
* [ ] Are the resource names starting with their containing provider's name followed by an underscore? e.g. resource from the provider `postgresql` might be named as `postgresql_database`?
* [ ] Is `try` function used only with simple attribute references and type conversion functions?, as overuse of `try` function to suppress errors will lead to a configuration that is hard to understand and maintain.
* [ ] Are the explicit type conversion functions used to normalize types returned only in module outputs?, as the explicit type conversions are rarely necessary in Terraform because it will convert types automatically where required.
* [ ] Is `Sensitive` property on schema set to `true` for the fields that contains sensitive information?. This will prevent the field's values from showing up in CLI output.
* [ ] Each defined variables should explicitly have `type` information. E.g. a `list(string)` or `string`.
* [ ] Each defined variables should explicitly have `description` about the purpose of variable and usage.
* [ ] Don’t provide a `default` value for a variable which must be supplied by a user.
* [ ] Try avoiding nesting sub configuration within resources. Create a sepearate resource section for resources even though they can be decalred as sub-element of a resource. For example, declaring subnets within virtual network vis-a-vis declaring subnets as a separate resources compared to virtual network on Azure.
* [ ] Never hard-code any value in configuration. Declare them in `locals` section if a variable is needed multiple times as a static value and are internal to the configuration.
* [ ] The `name`s of the resources created on Azure should not be hard-coded or static. These names should be dynamic and user-provided using `variable` block. This is helpful especially in unit testing when multiple tests are running in parallel trying to create resources on Azure but need different names (few resources in Azure need to be named uniquely e.g. storage accounts).
* [ ] It is a good practice to `output` the ID of resources created on Azure from configuration. This is especially helpful when adding dynamic blocks for sub-elements/child elements to the parent resource.
* [ ] Use `required_providers` block for establishing the dependency for providers along with pre-determined version.
* [ ] Use `terraform` block to declare the provider dependency with exact version and also the terraform CLI version needed for the configuration.
* [ ] Validate the variable values supplied based on usage and type of variable. The validation can be done to variables by adding `validation` block.
