#*********************************************************************************
# This module creates a website for hosting documentation. It uses its own app-plan.
# OPTIONS:
# - authentication can be enabled on the app service. See comments.
# - SSL certificate can be added to a keyvault and used. See comments.
#*********************************************************************************

# Create the app service plan for the website
resource "azurerm_app_service_plan" "service-plan" {
  name                = var.plan_name
  location            = var.rg_location
  resource_group_name = var.rg_name
  kind                = "Windows"
  reserved            = false

  sku {
    tier = "Standard"
    size = "S1"
  }

  lifecycle {
    ignore_changes = [
      tags,
    ]
  }
}

# Create the app service (website)
resource "azurerm_app_service" "app-service" {
  name                = var.app_name
  location            = var.rg_location
  resource_group_name = var.rg_name
  app_service_plan_id = azurerm_app_service_plan.service-plan.id
  https_only          = true

  site_config {
    dotnet_framework_version = "v4.0"
    default_documents        = ["readme.html", "index.html"]
    always_on                = true
  }

  app_settings = {
    "WEBSITE_RUN_FROM_PACKAGE" = "1"
  }

#*********************************************************************************
# NOTE: UNCOMMENT THE AUTH SETTINGS TO ADD AUTHENTICATION
#       MAKE SURE THE CLIENT_ID VARIABLE IS SET.
#*********************************************************************************
#  auth_settings {
#    enabled = true
#    active_directory {
#      client_id = var.client_id
#    }
#    default_provider = "AzureActiveDirectory"
#  }

  lifecycle {
    ignore_changes = [
      tags,
    ]
  }
}

#*********************************************************************************
# NOTE: UNCOMMENT ALL DATA AND RESOURCE ENTRIES BELOW TO ADD SSL TO YOUR WEBSITE
#       MAKE SURE THE APPROPRIATE VARIABLES ARE SET.
# The key vault must be created manually in the the resource group
# and the certificate must be added manually with the defined name.
#*********************************************************************************
# Reference to the existing common keyvault
#data "azurerm_key_vault" "key-vault" {
#  name                = var.kv_name
#  resource_group_name = var.rg_name
#}

# Reference the existing SSL certificate in the common keyvault
#data "azurerm_key_vault_certificate" "ssl_certificate" {
#  name         = var.ssl_certificate_name
#  key_vault_id = data.azurerm_key_vault.key-vault.id
#}

# Create an app service certificate from the certificate in the key vault
#resource "azurerm_app_service_certificate" "app_service_certificate" {
#  name                = var.app_ssl_certificate_name
#  location            = var.rg_location
#  resource_group_name = var.rg_name
#  key_vault_secret_id = data.azurerm_key_vault_certificate.ssl_certificate.secret_id
#
#  lifecycle {
#    ignore_changes = [
#      tags,
#    ]
#  }
#}

# Custom hostname binding and SSL certificate assignment
#resource "azurerm_app_service_custom_hostname_binding" "custom_hostname_binding" {
#  hostname            = var.app_hostname
#  app_service_name    = azurerm_app_service.app-service.name
#  resource_group_name = var.rg_name
#  ssl_state           = "SniEnabled"
#  thumbprint          = azurerm_app_service_certificate.app_service_certificate.thumbprint
#}
