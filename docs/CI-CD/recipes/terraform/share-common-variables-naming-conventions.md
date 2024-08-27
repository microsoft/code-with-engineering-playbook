# Sharing Common Variables / Naming Conventions Between Terraform Modules

## What are we Trying to Solve?

When deploying infrastructure using code, it's common practice to split the code into different modules that are responsible for the deployment of a part or a component of the infrastructure. In Terraform, this can be done by using [modules](https://www.terraform.io/language/modules/develop).

In this case, it is useful to be able to share some common variables as well as centralize naming conventions of the different resources, to ensure it will be easy to refactor when it has to change, despite the dependencies that exist between modules.

For example, let's consider 2 modules:

- Network module, responsible for deploying Virtual Network, Subnets, NSGs and Private DNS Zones
- Azure Kubernetes Service module responsible for deploying AKS cluster

There are dependencies between these modules, like the Kubernetes cluster that will be deployed into the virtual network from the Network module. To do that, it must reference the name of the virtual network, as well as the resource group it is deployed in. And ideally, we would like these dependencies to be loosely coupled, as much as possible, to keep agility in how the modules are deployed and keep independent lifecycle.

This page explains a way to solve this with Terraform.

## How to Do It?

### Context

Let's consider the following structure for our modules:

```sh
modules
├── kubernetes
│   ├── main.tf
│   ├── provider.tf
│   └── variables.tf
├── network
│   ├── main.tf
│   ├── provider.tf
│   └── variables.tf
```

Now, assume that you deploy a virtual network for the development environment, with the following properties:

- name: vnet-dev
- resource group: rg-dev-network

Then at some point, you need to inject these values into the Kubernetes module, to get a reference to it through a data source, for example:

```tf
data "azurem_virtual_network" "vnet" {
    name                = var.vnet_name
    resource_group_name = var.vnet_rg_name
}
```

In the snippet above, the virtual network name and resource group are defined through variable. This is great, but if this changes in the future, then the values of these variables must change too. In every module they are used.

Being able to manage naming in a central place will make sure the code can easily be refactored in the future, without updating all modules.

### About Terraform Variables

In Terraform, every [input variable](https://www.terraform.io/language/values/variables) must be defined at the configuration (or module) level, using the `variable` block. By convention, this is often done in a `variables.tf` file, in the module. This file contains variable declaration and default values. Values can be set using variables configuration files (.tfvars), environment variables or CLI arg when using the terraform `plan` or `apply` commands.

One of the limitation of the variables declaration is that it's not possible to compose variables, [locals](https://www.terraform.io/language/values/locals) or Terraform [built-in functions](https://www.terraform.io/language/functions) are used for that.

### Common Terraform Module

One way to bypass this limitations is to introduce a "common" module, that will not deploy any resources, but just compute / calculate and output the resource names and shared variables, and be used by all other modules, as a dependency.

```sh
modules
├── common
│   ├── output.tf
│   └── variables.tf
├── kubernetes
│   ├── main.tf
│   ├── provider.tf
│   └── variables.tf
├── network
│   ├── main.tf
│   ├── provider.tf
│   └── variables.tf
```

*variables.tf:*

```tf
variable "environment_name" {
  type = string
  description = "The name of the environment."
}

variable "location" {
  type = string
  description = "The Azure region where the resources will be created. Default is westeurope."
  default = "westeurope"
}
```

*output.tf:*

```tf
# Shared variables
output "location" {
  value = var.location
}

output "subscription" {
  value = var.subscription
}

# Virtual Network Naming

output "vnet_rg_name" {
  value = "rg-network-${var.environment_name}"
}

output "vnet_name" {
  value = "vnet-${var.environment_name}"
}

# AKS Naming

output "aks_rg_name" {
  value = "rg-aks-${var.environment_name}"
}

output "aks_name" {
  value = "aks-${var.environment_name}"
}
```

Now, if you execute the Terraform apply for the common module, you get all the shared/common variables in outputs:

```sh
$ terraform plan -var environment_name="dev" -var subscription="$(az account show --query id -o tsv)"

Changes to Outputs:
  + aks_name     = "aks-dev"
  + aks_rg_name  = "rg-aks-dev"
  + location     = "westeurope"
  + subscription = "01010101-1010-0101-1010-010101010101"
  + vnet_name    = "vnet-dev"
  + vnet_rg_name = "rg-network-dev"

You can apply this plan to save these new output values to the Terraform state, without changing any real infrastructure.
```

### Use the Common Terraform Module

Using the common Terraform module in any other module is super easy. For example, this is what you can do in the Azure Kubernetes module `main.tf` file:

```tf
module "common" {
  source           = "../common"
  environment_name = var.environment_name
  subscription     = var.subscription
}

data "azurerm_subnet" "aks_subnet" {
  name                 = "AksSubnet"
  virtual_network_name = module.common.vnet_name
  resource_group_name  = module.common.vnet_rg_name
}

resource "azurerm_kubernetes_cluster" "aks" {
  name                = module.common.aks_name
  resource_group_name = module.common.aks_rg_name
  location            = module.common.location
  dns_prefix          = module.common.aks_name

  identity {
    type = "SystemAssigned"
  }

  default_node_pool {
    name           = "default"
    vm_size        = "Standard_DS2_v2"
    vnet_subnet_id = data.azurerm_subnet.aks_subnet.id
  }
}
```

Then, you can execute the `terraform plan` and `terraform apply` commands to deploy!

```sh
terraform plan -var environment_name="dev" -var subscription="$(az account show --query id -o tsv)"
data.azurerm_subnet.aks_subnet: Reading...
data.azurerm_subnet.aks_subnet: Read complete after 1s [id=/subscriptions/01010101-1010-0101-1010-010101010101/resourceGroups/rg-network-dev/providers/Microsoft.Network/virtualNetworks/vnet-dev/subnets/AksSubnet]

Terraform used the selected providers to generate the following execution plan. Resource actions are indicated with the following symbols:
  + create

Terraform will perform the following actions:

  # azurerm_kubernetes_cluster.aks will be created
  + resource "azurerm_kubernetes_cluster" "aks" {
      + dns_prefix                          = "aks-dev"
      + fqdn                                = (known after apply)
      + id                                  = (known after apply)
      + kube_admin_config                   = (known after apply)
      + kube_admin_config_raw               = (sensitive value)
      + kube_config                         = (known after apply)
      + kube_config_raw                     = (sensitive value)
      + kubernetes_version                  = (known after apply)
      + location                            = "westeurope"
      + name                                = "aks-dev"
      + node_resource_group                 = (known after apply)
      + portal_fqdn                         = (known after apply)
      + private_cluster_enabled             = (known after apply)
      + private_cluster_public_fqdn_enabled = false
      + private_dns_zone_id                 = (known after apply)
      + private_fqdn                        = (known after apply)
      + private_link_enabled                = (known after apply)
      + public_network_access_enabled       = true
      + resource_group_name                 = "rg-aks-dev"
      + sku_tier                            = "Free"

      [...] truncated

      + default_node_pool {
          + kubelet_disk_type    = (known after apply)
          + max_pods             = (known after apply)
          + name                 = "default"
          + node_count           = (known after apply)
          + node_labels          = (known after apply)
          + orchestrator_version = (known after apply)
          + os_disk_size_gb      = (known after apply)
          + os_disk_type         = "Managed"
          + os_sku               = (known after apply)
          + type                 = "VirtualMachineScaleSets"
          + ultra_ssd_enabled    = false
          + vm_size              = "Standard_DS2_v2"
          + vnet_subnet_id       = "/subscriptions/01010101-1010-0101-1010-010101010101/resourceGroups/rg-network-dev/providers/Microsoft.Network/virtualNetworks/vnet-dev/subnets/AksSubnet"
        }

      + identity {
          + principal_id = (known after apply)
          + tenant_id    = (known after apply)
          + type         = "SystemAssigned"
        }

      [...] truncated
    }

Plan: 1 to add, 0 to change, 0 to destroy.
```

> **Note:** the usage of a common module is also valid if you decide to deploy all your modules in the same operation from a main Terraform configuration file, like:

```tf
module "common" {
  source           = "./common"
  environment_name = var.environment_name
  subscription     = var.subscription
}

module "network" {
  source           = "./network"
  vnet_name        = module.common.vnet_name
  vnet_rg_name     = module.common.vnet_rg_name
}

module "kubernetes" {
  source           = "./kubernetes"
  aks_name         = module.common.aks_name
  aks_rg           = module.common.aks_rg_name
}
```

### Centralize Input Variables Definitions

In case you chose to define variables values directly in the source control (e.g. gitops scenario) using [variables definitions files](https://www.terraform.io/language/values/variables#variable-definitions-tfvars-files) (`.tfvars`), having a common module will also help to not have to duplicate the common variables definitions in all modules. Indeed, it is possible to have a global file that is defined once, at the common module level, and merge it with a module-specific variables definitions files at Terraform `plan` or `apply` time.

Let's consider the following structure:

```sh
modules
├── common
│   ├── dev.tfvars
│   ├── prod.tfvars
│   ├── output.tf
│   └── variables.tf
├── kubernetes
│   ├── dev.tfvars
│   ├── prod.tfvars
│   ├── main.tf
│   ├── provider.tf
│   └── variables.tf
├── network
│   ├── dev.tfvars
│   ├── prod.tfvars
│   ├── main.tf
│   ├── provider.tf
│   └── variables.tf
```

The common module as well as all other modules contain variables files for `dev` and `prod` environment. `tfvars` files from the common module will define all the global variables that will be shared with other modules (like subscription, environment name, etc.) and `.tfvars` files of each module will define only the module-specific values.

Then, it's possible to merge these files when running the `terraform apply` or `terraform plan` command, using the following syntax:

```bash
terraform plan -var-file=<(cat ../common/dev.tfvars ./dev.tfvars)
```

> **Note:** using this, it is really important to ensure that you have not the same variable names in both files, otherwise that will generate an error.

## Conclusion

By having a common module that owns shared variables as well as naming convention, it is now easier to refactor your Terraform configuration code base. Imagine that for some reason you need change the pattern that is used for the virtual network name: you change it in the common module output files, and just have to re-apply all modules!
