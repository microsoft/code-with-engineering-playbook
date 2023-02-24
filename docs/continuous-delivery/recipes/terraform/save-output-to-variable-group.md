# Save terraform output to a variable group (Azure DevOps)

This recipe applies only to terraform usage with Azure DevOps. It assumes your familiar with terraform commands and Azure Pipelines.

## Context

When terraform is used to automate the provisioning of the infrastructure, an [Azure Pipeline](https://learn.microsoft.com/en-us/azure/devops/pipelines/?view=azure-devops) is generally dedicated to apply terraform configuration files. It will create, update, delete Azure resources to provision your infrastructure changes.

Once files are applied, some [Output Values](https://developer.hashicorp.com/terraform/language/values/outputs) (for instance resource group name, app service name) can be referenced and outputted by terraform. These values must be generally retrieved afterwards, used as input variables for the deployment of services happening in separate pipelines.

How to make terraform output values available across multiple pipelines ?

## Solution

One suggested solution is to store outputted values in a [variable group](https://learn.microsoft.com/en-us/azure/devops/pipelines/library/variable-groups?view=azure-devops&tabs=yaml). Variable groups is a convenient way store values you might want to be passed into a YAML pipeline.

For this purpose, we are using the following commands:

- [terraform output](https://developer.hashicorp.com/terraform/cli/commands/output) to extract the value of an output variable from the state file (provided by [Terraform CLI](https://developer.hashicorp.com/terraform/cli))
- [az pipelines variable-group](https://learn.microsoft.com/en-us/cli/azure/pipelines/variable-group?view=azure-cli-latest) to manage variable groups (provided by [Azure DevOps CLI](https://learn.microsoft.com/en-us/azure/devops/cli/?view=azure-devops))

### Script (update-variablegroup.sh)

#### Parameters

| Name | Description |
|---|---|
| DEVOPS_ORGANIZATION | The URI of the Azure DevOps organization. |
| DEVOPS_PROJECT | The name or id of the Azure DevOps project. |
| GROUP_NAME| The name of the variable group targeted. |

If a variable group exists, a valid option could be to delete it and rebuild it from scratch. However, as authorization could have been updated at the group level, we prefered to avoid this option. The script remove instead existing variables and add them back with latest values.

```bash
#!/bin/bash

set -e

export DEVOPS_ORGANIZATION=$1
export DEVOPS_PROJECT=$2
export GROUP_NAME=$3

# configure the azure devops cli
az devops configure --defaults organization=${DEVOPS_ORGANIZATION} project=${DEVOPS_PROJECT} --use-git-aliases true

# get the variable group id (if already exists)
group_id=$(az pipelines variable-group list --group-name ${GROUP_NAME} --query '[0].id' -o json)

if [ -z "${group_id}" ]; then
    # create a new variable group
    tf_output=$(terraform output -json | jq -r 'to_entries[] | "\(.key)=\(.value.value)"')
    az pipelines variable-group create --name ${GROUP_NAME} --variables ${tf_output} --authorize true
else
    # get existing variables
    var_list=$(az pipelines variable-group variable list --group-id ${group_id})

    # add temporary uuid variable (a variable group cannot be empty) 
    uuid=$(cat /proc/sys/kernel/random/uuid)
    az pipelines variable-group variable create --group-id ${group_id} --name ${uuid}

    # delete existing variables 
    for row in $(echo ${var_list} | jq -r 'to_entries[] | "\(.key)"'); do
        az pipelines variable-group variable delete --group-id ${group_id} --name ${row} --yes
    done

    # create variables with latest values (from terraform)
    for row in $(terraform output -json | jq -c 'to_entries[]'); do
        _jq()
        {
            echo ${row} | jq -r ${1}
        }

        az pipelines variable-group variable create --group-id ${group_id} --name $(_jq '.key') --value $(_jq '.value.value') --secret $(_jq '.value.sensitive') 
    done

    # delete temporary uuid variable
    az pipelines variable-group variable delete --group-id ${group_id} --name ${uuid} --yes
fi
```


[az devops configure](https://learn.microsoft.com/en-us/cli/azure/devops?view=azure-cli-latest#az-devops-configure)
`
## Authenticate with Azure DevOps

Some Azure DevOps CLI commands that don't call into Azure DevOps, like `az devops configure` and `az devops -h`, do not require any authentication, but most commands interact with Azure DevOps and do require authentication. You can authenticate using the System.AccessToken security token used by the running pipeline, by assigning it to an environment variable named `AZURE_DEVOPS_EXT_PAT`, as shown in the following example (see [Azure DevOps CLI in Azure Pipeline YAML](https://learn.microsoft.com/en-us/azure/devops/cli/azure-devops-cli-in-yaml?view=azure-devops#authenticate-with-azure-devops)).

```yaml
  - task: Bash@3
    displayName: 'Update variable group using terraform outputs'
    inputs:
      targetType: filePath
      arguments: $(System.TeamFoundationCollectionUri) $(System.TeamProjectId) "Platform-VG"
      workingDirectory: $(terraformDirectory)
      filePath: $(scriptsDirectory)/update-variablegroup.sh
    env:
      AZURE_DEVOPS_EXT_PAT: $(System.AccessToken)
```

| System variables | Description |
|---|---|
| [System.AccessToken](https://learn.microsoft.com/en-us/azure/devops/pipelines/build/variables?view=azure-devops&tabs=yaml#systemaccesstoken)| System.AccessToken is a special variable that carries the security token used by the running build. |
| [System.TeamFoundationCollectionUri](https://learn.microsoft.com/en-us/azure/devops/pipelines/build/variables?view=azure-devops&tabs=yaml#system-variables-devops-services) | The URI of the Azure DevOps organization. For example: https://dev.azure.com/fabrikamfiber/. |
| [System.TeamProjectId](https://learn.microsoft.com/en-us/azure/devops/pipelines/build/variables?view=azure-devops&tabs=yaml#system-variables-devops-services) | The ID of the project that this build belongs to. |