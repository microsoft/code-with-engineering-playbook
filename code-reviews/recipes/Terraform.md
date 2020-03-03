## Code Reviews
### Style Guide
- Adhere to the [hashicorp style guide](https://www.terraform.io/docs/configuration/style.html)
- Ensure all used providers are versioned to prevent breaking changes in future. [docs on versioning providers](https://www.terraform.io/docs/configuration/providers.html#provider-versions)
- main.tf: This file usually contains provider configuration, backend configuration, imports to the modules to use and eventually some common resources that was not isolated into a specific file. It is absolutely possible to have the whole infrastructure defined in this file itself, suggest to split it into other *.tf files
- README.md - Always useful to document what the Terraform project does

### Linters
1. [tflint](https://github.com/terraform-linters/tflint) - As of now tflint doesn't have Azure specific rules, it can be used to inspect  general Terraform specific issues.  

### Useful extensions for VS Code and Visual Studio

The following VC Code extensions are widely used

1. [Terraform extension](https://marketplace.visualstudio.com/items?itemName=mauve.terraform)
2. [Azure Terraform extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azureterraform)

The Terraform extension also supports [tflint](https://github.com/terraform-linters/tflint/), tflint can be used independently and also within VS Code

### Build Validation

Ensure you enforce the style guides during build. The following example script can be used to install terraform and a linter
then check for formatting and common errors.

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

echo -e "\n\n>>> Terraform verion"
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

### Code Review Checklist
In addition to the [Code Review Checklist](../readme.md) you should also look for these terraform specific code review items

- Verify Terraform project is configured to use Azure Storage as remote state backend
- Verify remote state backend storage account key is stored in the key vault and not hard coded
- If Terraform code is mixed with application source code, verify that the Terraform code is isolated into a dedicated folder
- If the infrastructure going to different depending on the environment (Example: Dev, UAT, Production), verify sub-directory per environment is created
- Verify resource definition and data sources are handled correctly in the Terraform
    - resource : Indicates to Terraform that the current configuration is in charge of managing the life cycle of the object
    - data: Indicates to Terraform that you only want to get a reference of the existing object, but don’t want to manage it part of this configuration
- Ensure code is split into to multiple reusable modules
- Verify for unit test implementation for Terraform code. [Terratest](https://terratest.gruntwork.io/) is widely used. While running the unit tests from DevOps pipelines, check for managed identities or service principal is used with the Terratest

