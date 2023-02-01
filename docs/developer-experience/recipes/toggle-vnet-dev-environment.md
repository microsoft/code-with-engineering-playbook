# Toggle VNet on and off for production and development environment

## Problem Statement

When deploying resources on Azure in a secure environment, resources are usually created behind a Private Network (VNet). This is of course the best approach for pre-production or production environments.

Accessing resources from a local machine implies one of the following option:

- Use bastion #TODO: dig up
- Use a VPN
- Use a **jumpbox** (less secure)

However, a developer may want to deploy a test infrastructure for their tests without worrying on how to access this environment.

## Option

The idea is to offer an option in your deployment, via a variable, to deploy resources behind a VNet or not.

The deployment pipeline will obviously set these resources behind a VNet. Developers will be able to run the same deployment script, specifying that resources will not be behind a VNet nor have public accesses disabled.

Let's consider the following use case for production: we want to deploy a VNet, a subnet, a storage account with no public access and a private endpoint for the table (the code below will not contain everything, the purpose is to show the pattern). Our variable deciding whether the VNet, and all its consequences, will be activated is called `behind_vnet`.

Let's implement this use case using `Terraform`.

There is no `if` *per sé* in Terraform. However, we can use the [`count`](https://developer.hashicorp.com/terraform/language/meta-arguments/count) meta-argument. If, we deploy without VNet, we set count to 0, therefore nothing will be deployed.

- variables.tf

    ```terraform
    variable "behind_vnet" {
    type    = bool
    }
    ```

- main.tf

    ```terraform
    resource "azurerm_virtual_network" "vnet" {
    count = var.behind_vnet ? 1 : 0
    
    name                = "MyVnet"
    address_space       = [x.x.x.x/16]
    resource_group_name = "MyResourceGroup"
    location            = "WestEurope"

    ...

    subnet {
        name              = "subnet_1"
        address_prefix    = "x.x.x.x/24"
    }
    }

    resource "azurerm_storage_account" "storage_account" {
    name                = "mystorage"
    resource_group_name = "MyResourceGroup"
    location            = "WestEurope"
    tags                = var.tags

    ...

    public_network_access_enabled = var.behind_vnet ? false : true
    }

    resource "azurerm_private_endpoint" "storage_account_table_private_endpoint" {
    count = var.behind_vnet ? 1 : 0
    
    name                = "pe-storage"
    subnet_id           = azurerm_virtual_network.vnet[0].subnet[0].id
    
    ...

    private_service_connection {
        name                           = "psc-storage"
        private_connection_resource_id = azurerm_storage_account.storage_account.id
        subresource_names              = [ "table" ]
        ...
    }

    private_dns_zone_group {
        name = "privateDnsZoneGroup"
        ...
    }
    }
    ```

If we run

```bash
terraform apply -var behind_vnet=true
```

then all the resources above will be deployed, and it is what we want on a pre-production or production environment.

However, if we run

```bash
terraform apply -var behind_vnet=false
```

the `azurerm_virtual_network` and `azurerm_private_endpoint` resources will be skipped. The resource `azurerm_storage_account` will be created, with minor differences in some properties. For instance, here, `public_network_access_enabled` will be set to `true`.

The same pattern can be applied over and over.

There are a couple of trade off with this approach:

- if a resource has the `count` argument, it will need to be treated as a list, and not a single item. In the example above, if there is a need to reference the resource `azurerm_virtual_network`, the code

    ```terraform
    azurerm_virtual_network.vnet.id
    ```

    will not work. The following must be used

    ```terraform
    azurerm_virtual_network.vnet[0].id
    ```

- The meta-argument `count` cannot be used with `for_each`. That means that the use of loops to deploy multiple endpoints for instance will not work. Each private endpoints will need to be deployed individually.
