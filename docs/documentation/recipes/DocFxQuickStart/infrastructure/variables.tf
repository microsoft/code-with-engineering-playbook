variable "rg_name" {
  type        = string
  description = "Name of the resource group"
  default     = "<INSERT THE NAME OF THE TARGET RESOURCE GROUP>"
}

variable "rg_location" {
  type        = string
  description = "Location of the resource group"
  default     = "<INSERT THE NAME OF THE LOCATION OF THE RESOURCE GROUP>"
}

variable "app_name" {
  type        = string
  description = "Application name. Use only lowercase letters and numbers. This makes up a unique url with the addition of azurewebsites.net"
  default     = "<INSERT THE NAME OF THE APP SERVICE>"
}

variable "plan_name" {
  type        = string
  description = "Application plan name. Use only lowercase letters and numbers"
  default     = "<INSER THE NAME OF THE APP SERVICE PLAN>"
}

# NOTE: UNCOMMENT THESE SETTINGS AND SET THE CLIENT ID FOR ADDING AUTHENTICATION
#variable "client_id" {
#  type        = string
#  description = "Client id for authentication"
#}

# NOTE: UNCOMMENT THESE VARIABLES AND SET VALUES FOR SSL CERTIFICATE USAGE IN KEY VAULT
#variable "kv_name" {
#  type        = string
#  description = "Name of key vault. SSL certificate for the docs is fetched from there."
#}
#variable "ssl_certificate_name" {
#  type        = string
#  description = "Name of SSL certificate in the key vault"
#  default     = "ssl-certificate"
#}
#variable "app_ssl_certificate_name" {
#  type        = string
#  description = "Name of App Service SSL certificate"
#  default     = "cert-documentation"
#}
#variable "app_hostname" {
#  type        = string
#  description = "Hostname for the documentation website"
#  default     = "<INSERT YOUR URL, e.g. documentation.somewhere.com>"
#}