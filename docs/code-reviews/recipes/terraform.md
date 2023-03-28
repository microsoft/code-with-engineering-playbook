# Terraform Code Reviews

## Style Guide

Developers should follow the [terraform style guide](https://github.com/jonbrouse/terraform-style-guide/blob/master/README.md).

Projects should check Terraform scripts with automated tools.

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

Ensure you enforce the style guides during build. The following example script can be used to install terraform, and a linter that
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

### Providers

* [ ] Are all providers used in the terraform scripts [versioned](https://www.terraform.io/language/providers/requirements#best-practices-for-provider-versions) to prevent breaking changes in the future?

### Repository Organization

* [ ] The code split into reusable modules?
* [ ] Modules are split into separate `.tf` files where appropriate?
* [ ] The repository contains a `README.md` describing the architecture provisioned?
* [ ] If Terraform code is mixed with application source code, the Terraform code isolated into a dedicated folder?

### Terraform state

* [ ] The Terraform project configured using Azure Storage as remote state backend?
* [ ] The remote state backend storage account key stored a secure location (e.g. Azure Key Vault)?
* [ ] The project is configured to use state files based on the environment, and the deployment pipeline is configured to supply the state file name dynamically?

### Variables

* [ ] If the infrastructure will be different depending on the environment (e.g. Dev, UAT, Production), the environment specific parameters are supplied via a `.tfvars` file?
* [ ] All variables have `type` information. E.g. a `list(string)` or `string`.
* [ ] All variables have a `description` stating the purpose of the variable and its usage.
* [ ] `default` values are not supplied for variables which must be supplied by a user.

### Testing

* [ ] Unit and integration tests covering the Terraform code exist (e.g. [`Terratest`](https://terratest.gruntwork.io/), [`terratest-abstraction`](https://github.com/microsoft/terratest-abstraction))?

### Naming and code structure

* [ ] Resource definitions and data sources are used correctly in the Terraform scripts?
  * **resource:** Indicates to Terraform that the current configuration is in charge of managing the life cycle of the object
  * **data:** Indicates to Terraform that you only want to get a reference to the existing object, but don’t want to manage it as part of this configuration
* [ ] The resource names start with their containing provider's name followed by an underscore? e.g. resource from the provider `postgresql` might be named as `postgresql_database`?
* [ ] The `try` function is only used with simple attribute references and type conversion functions? Overuse of the `try` function to suppress errors will lead to a configuration that is hard to understand and maintain.
* [ ] Explicit type conversion functions used to normalize types are only returned in module outputs? Explicit type conversions are rarely necessary in Terraform because it will convert types automatically where required.
* [ ] The `Sensitive` property on schema set to `true` for the fields that contains sensitive information? This will prevent the field's values from showing up in CLI output.

### General recommendations

* Try avoiding nesting sub configuration within resources. Create a separate resource section for resources even though they can be declared as sub-element of a resource. For example, declaring subnets within virtual network vs declaring subnets as a separate resources compared to virtual network on Azure.
* Never hard-code any value in configuration. Declare them in `locals` section if a variable is needed multiple times as a static value and are internal to the configuration.
* The `name`s of the resources created on Azure should not be hard-coded or static. These names should be dynamic and user-provided using `variable` block. This is helpful especially in unit testing when multiple tests are running in parallel trying to create resources on Azure but need different names (few resources in Azure need to be named uniquely e.g. storage accounts).
* It is a good practice to `output` the ID of resources created on Azure from configuration. This is especially helpful when adding dynamic blocks for sub-elements/child elements to the parent resource.
* Use the `required_providers` block for establishing the dependency for providers along with pre-determined version.
* Use the `terraform` block to declare the provider dependency with exact version and also the terraform CLI version needed for the configuration.
* Validate the variable values supplied based on usage and type of variable. The validation can be done to variables by adding `validation` block.
* Validate that the component SKUs are the right ones, e.g. standard vs premium.
