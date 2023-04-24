# Hybrid Resource Design Guidance


In the below documet best practices about how resources and artitechture should be configured and used for Hybrid and Multi-Cloud enviorments.

> **NOTE:** Always work with the relevant stakeholders to ensure that introducing new patterns provides the intended value.
>
> When working in an existing hybrid environment, it is important to understand any current patterns and how they are used before making a change to them.


## Hub and Spoke topology

The Hub-and-Spoke topology doesn't change much when using cloud/hybrid if configured correctly, The main different is that the hub vnet is peering to the on-prem network via a Expressruote and that all traffic from Azure might exit via the expressroute and the on-prem internet connection.

The generalized best practices are in  [cloud-artitechture-design-guidance#Hub and Spoke topology](..\cloud-artitechture-design-guidance\readme.md#hub-and-spoke-topology)

### IP allocation

When working with Hybrid deployment extra care should be taken when planning IP allocation as there is a much greater risk of overlapping network ranges.

The generalized best practices are in [cloud-artitechture-design-guidance#ip-allocation](..\cloud-artitechture-design-guidance\readme.md#ip-allocation)

Read more about this at [azure-best-practices/plan-for-ip-addressing](https://learn.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/plan-for-ip-addressing)

### ExpressRoute

Enviorments using Express often tunnel all traffic from Azure via a private link(ExpressRoute) to an on-prem location, This imposes a few problems when working with PAAS offereigns as not all of them connect via their respective private endpoint and instead use an external IP for outgoing connections, or some PAAS to PASS traffic occur internally in azure and won't function with disabled public networks.

Two notable services here are dataplanes copies of Storage accounts and a lot of the services not supporting private-endpoints.

Choose the right ExpressRoute circuit: Select an appropriate SKU (Standard or Premium) and bandwidth based on your organization's requirements.
Redundancy: Ensure redundancy by provisioning two ExpressRoute circuits in different peering locations.
Monitoring: Use Azure Monitor and Network Performance Monitor (NPM) to monitor the health and performance of your ExpressRoute circuits.

### DNS

The generalized best practices are in [cloud-artitechture-design-guidance#dns](../cloud-artitechture-design-guidance/readme.md#dns)

When using Azure DNS in a hybrid or multi-cloud enviorment it is important to ensure a consistent dns and forwarding configuration which ensures that records are automatically updated and that all DNS servers are aware of each other and know which server is the authoritative for the different records.

Read more about [Hybrid/Multi-Cloud DNS infrasurecture](https://learn.microsoft.com/en-us/azure/architecture/hybrid/hybrid-dns-infra)

### Resource allocation

For resource allocation the best practices from [Cloud Resource Design Guidance](../cloud-resource-design-guidance/README.md) should be followed.

## Tooling

* [Azure Resource Naming Tool](https://github.com/microsoft/CloudAdoptionFramework/tree/master/ready/AzNamingTool)
