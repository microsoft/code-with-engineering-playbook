variable "location" {
    type          = "string"
    description   = "The name of the target location"
}
variable "env" {
    type        = "string",
    description = "The short name of the target env (i.e. dev, staging, or prod)"
}
variable "org" {
    type        = "string",
    description = "The short name of the organization"
}