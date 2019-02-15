# Naming Conventions for Azure Resources

The naming convention followed consists of 5 segments. Where permitted, the segments will be seperated by hyphens. Otherwise, they are concatenated as a single string.

Most resources have a 24 character name limit within azure. To keep the name within the limit, each segment uses abbreviated versions of their full name. Abbreviations will work well when the name consists of multiple words. However, when a name consists of a single long word it can be shortened by removing vowels and superfluous consonants. Shortened single words as follows

- graph         = gph
- secrets       = scrt

## Examples

- rg-gph-dev-eus-msft         - Development environment resource group for graph module deployed to East US location.
- kv-core-stage-wus-msft      - Staging environment Key Vault for secrets module deployed to West US location.

## Segment Definitions

### Resource Type

A 2-4 character short name for the type of resource.

- rg    = Resource Group
- st    = Storage Account
- acr   = Azure Container Registry
- aks   = Azure Kubernetes Service

### Module

A short name for the module that is responsible for deploying the resource. For example the graph module will include `gph' in this segment.

### Environment

A short name for the environment to which the resource is associated. For example, development environment resources would include 'dev' in this segment

### Location

The location short name to which the resource is assigned. Resources deployed in East US would have eastus in this segment.

- East US = eus
- South Central US = scus
- West US = wus

#### Global Resources

For resources not assigned to a location, the location will be omitted. Service Principals & Application Insights are examples of location agnostic resources in Azure.

### Organization

The org short name to which the resource is assigned. This is primarily used to make the resource name globally unique across all of Azure. Resources such as app services, storage accounts, and key vault expose a public dns (i.e. mywebsite.azurewebsites.net) which require them to be unique across all of Azure.

## Resource Short Names Table

| Resource Type             | Short Name |
| ------------------------- | ---------- |
| Resource Group            | rg         |
| Storage Account           | st         |
| Container Registry        | acr        |
| Kubernetes Service        | aks        |
| Key Vault                 | kv         |
| Media Services            | mds        |
| Media Services            | mds        |
| Application Insights      | ai         |
| API Management Gateway    | apim       |
| Service Fabric            | asf        |
| Container Instances       | aci        |
| SQL Server                | sql        |
| SQL Database              | sqldb      |
| Cosmos                    | cos        |
| Virtual Network           | vnet       |
| Subnet                    | snet       |
| Virtual Machine           | vm         |
| Virtual Machine Scale Set | vmss       |
| Application Service       | app        |
| Web Site                  | web        |
| Log Analytics Workspace   | log        |

## Location Short Names Table

| Location       | Short Name |
| -------------- | ---------- |
| centralus      | cus        |
| eastus         | eus        |
| eastus2        | eus2       |
| westus         | wus        |
| northcentralus | ncus       |
| southcentralus | scus       |
| westcentralus  | wcus       |
| westus2        | wus2       |