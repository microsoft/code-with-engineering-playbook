# Network Architecture Guidance for Hybrid

The following are best practices around how to design and configure resources, used for Hybrid and Multi-Cloud environments.

> **NOTE:** When working in an existing hybrid environment, it is important to understand any current patterns, and how they are used before making any changes.

## Hub-and-spoke Topology

The hub-and-spoke topology doesn't change much when using cloud/hybrid if configured correctly, The main different is that the hub VNet is peering to the on-prem network via a ExpressRoute and that all traffic from Azure might exit via the ExpressRoute and the on-prem internet connection.

The generalized best practices are in  [Network Architecture Guidance for Azure#Hub and Spoke topology](network-architecture-guidance-for-azure.md#hub-and-spoke-topology)

### IP Allocation

When working with Hybrid deployment, take extra care when planning IP allocation as there is a much greater risk of overlapping network ranges.

The general best practices are available in the [Network Architecture Guidance for Azure#ip-allocation](network-architecture-guidance-for-azure.md#ip-allocation)

Read more about this in [Azure Best Practices Plan for IP Addressing](https://learn.microsoft.com/azure/cloud-adoption-framework/ready/azure-best-practices/plan-for-ip-addressing)

### ExpressRoute

Environments using Express often tunnel all traffic from Azure via a private link (ExpressRoute) to an on-prem location. This imposes a few problems when working with PAAS offerings as not all of them connect via their respective private endpoint and instead use an external IP for outgoing connections, or some PAAS to PASS traffic occur internally in azure and won't function with disabled public networks.

Two notable services here are data planes copies of storage accounts and a lot of the services not supporting private endpoints.

Choose the right ExpressRoute circuit: Select an appropriate SKU (Standard or Premium) and bandwidth based on your organization's requirements.
Redundancy: Ensure redundancy by provisioning two ExpressRoute circuits in different peering locations.
Monitoring: Use Azure Monitor and Network Performance Monitor (NPM) to monitor the health and performance of your ExpressRoute circuits.

### DNS

General best practices are available in [Network Architecture Guidance for Azure#dns](network-architecture-guidance-for-azure.md#dns)

When using Azure DNS in a hybrid or multi-cloud environment it is important to ensure a consistent DNS and forwarding configuration which ensures that records are automatically updated and that all DNS servers are aware of each other and know which server is the authoritative for the different records.

Read more about [Hybrid/Multi-Cloud DNS infrastructure](https://learn.microsoft.com/azure/architecture/hybrid/hybrid-dns-infra)

### Resource Allocation

For resource allocation the best practices from [Cloud Resource Design Guidance](cloud-resource-design-guidance.md) should be followed.
