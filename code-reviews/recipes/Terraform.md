# Terraform Code Reviews

## Style guide

[CSE](../../CSE.md) developers adhere to the [hashicorp style guide](https://www.terraform.io/docs/configuration/style.html).

We also ensure all used providers are versioned to prevent breaking changes in future. [docs on versioning providers](https://www.terraform.io/docs/configuration/providers.html#provider-versions).

## Linting

### tflint

> TODO: add information and an example of installation and usage of tflint

## Build Validation

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

> TODO: Add example of how to use this in an AzDO build validation pipeline

## Code Review Checklist

In addition to the [Code Review Checklist](../readme.md) you should also look for these terraform specific code review items

> TODO: Add checklist
