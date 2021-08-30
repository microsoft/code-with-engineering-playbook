# Set the terraform required version
terraform {
  required_version = ">= 0.12.6"

  # Register common providers
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "2.51.0"
    }
  }

# NOTE: COMMENT THE TWO LINES BELOW FOR LOCAL RUN OF TERRAFORM COMMANDS
#       MAKE SURE IT"S UNCOMMENTED WHEN RUN IN AN AZURE DEVOPS PIPELINE
#       AND CONFIGURE THE STORAGE OF THE TERRAFORM STATE.
#  backend "azurerm" {
#  }
}

# Configure the Azure Provider
provider "azurerm" {
  skip_provider_registration = true
  features {}
}

# Data

# Provides client_id, tenant_id, subscription_id and object_id variables
data "azurerm_client_config" "current" {}
