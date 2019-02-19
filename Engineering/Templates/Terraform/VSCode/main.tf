provider "azurerm" {
  version = "~>1.5"
}

terraform {
  backend "azurerm" {}
}

locals {
  location_suffixes = {
    centralus = "cus"
    eastus = "eus"
    eastus2 = "eus2"
    westus = "wus"
    northcentralus = "ncus"
    southcentralus = "scus"
    westcentralus = "wcus"
    westus2 = "wus2"
  }

  location_suffix = "${local.location_suffixes[var.location]}"
  suffix = "-core-${var.env}-${local.location_suffix}-${var.org}"
}

resource "azurerm_resource_group" "rg_core" {
  name = "rg${local.suffix}"
  location = "${var.location}"
}
