# Hybrid Resource Design Guidance


As companies usage scales from on-prem to cloud or multi-cloud, considerations for routing, dns

> **NOTE:** Always work with the relevant stakeholders to ensure that introducing new patterns provides the intended value.
>
> When working in an existing hybrid environment, it is important to understand any current patterns and how they are used before making a change to them.


## Networking, Routing, Firewall and DNS

Creating a hybrid cloud setup with on-premises services and an ExpressRoute connection to expand your private network in Azure involves various components like networking, security, and resource allocation. Here's a list of best practices to consider:
### ExpressRoute

Choose the right ExpressRoute circuit: Select an appropriate SKU (Standard or Premium) and bandwidth based on your organization's requirements.
Redundancy: Ensure redundancy by provisioning two ExpressRoute circuits in different peering locations.
Monitoring: Use Azure Monitor and Network Performance Monitor (NPM) to monitor the health and performance of your ExpressRoute circuits.
### Networking

Address space planning: Plan your address space for Azure virtual networks (VNets) and on-premises networks to avoid overlaps.
VNet peering: Use VNet peering for communication between VNets in Azure to avoid traffic traversing the on-premises network.
Network segmentation: Divide your network into smaller subnets based on the application, environment, or security requirements.
Network Security Groups (NSGs): Use NSGs to control inbound and outbound traffic to your virtual networks and subnets.



#### Vnet Hub/Spoke topology

A Hub-and-Spoke network topology is a common architecture pattern used in Azure for organizing and managing network resources. It is based on the concept of a central hub that connects to various spoke networks. This model is particularly useful for organizing resources, maintaining security, and simplifying network management.

In Azure, the Hub-and-Spoke model is typically implemented using Azure Virtual Networks (VNet) and VNet peering.

The Hub: The central VNet acts as a hub, providing shared services such as network security, monitoring, and connectivity to on-premises or other cloud environments. Common components in the hub include Network Virtual Appliances (NVAs), Azure Firewall, VPN Gateway, and ExpressRoute Gateway.

The Spokes: The spoke VNets represent separate units or applications within an organization, each with its own set of resources and services. They connect to the hub through VNet peering, which allows for communication between the hub and spoke VNets.

Implementing a Hub-and-Spoke model in Azure offers several benefits:

Isolation and Segmentation: By dividing resources into separate spoke VNets, you can isolate and segment workloads, preventing any potential issues or security risks from affecting other parts of the network.

Centralized Management: The hub VNet acts as a single point of management for shared services, making it easier to maintain, monitor, and enforce policies across the network.

Simplified Connectivity: VNet peering enables seamless communication between the hub and spoke VNets without the need for complex routing or additional gateways, reducing latency and management overhead.

Scalability: The Hub-and-Spoke model can easily scale to accommodate additional spokes as the organization grows or as new applications and services are introduced.

Cost Savings: By centralizing shared services in the hub, organizations can reduce the costs associated with deploying and managing multiple instances of the same services across different VNets.

In conclusion, implementing a Hub-and-Spoke network topology in Azure enables organizations to create a secure, scalable, and manageable network infrastructure. It allows for better segmentation, centralized management of shared services, and simplified connectivity between resources, making it a recommended best practice for Azure network design.

### DNS

DNS forwarding: Set up DNS forwarding between your on-premises DNS servers and Azure DNS servers for name resolution across environments.
Use Azure Private DNS zones for Azure resources: Configure Azure Private DNS zones for your Azure resources to ensure name resolution is kept within the virtual network.
Consistent naming conventions: Use consistent naming conventions for resources across on-premises and Azure environments.


https://learn.microsoft.com/en-us/azure/architecture/hybrid/hybrid-dns-inf


### Firewall and security

Azure Firewall: Use Azure Firewall for central management of network traffic and threat protection.
Network Virtual Appliances (NVAs): Use NVAs for advanced network security and traffic management.
Encryption: Enable encryption for data in transit and at rest.
Security Center: Use Azure Security Center to monitor and manage the security posture of your hybrid environment.
### IP allocation

Reserve IP addresses: Reserve IP addresses in your address space for critical resources or services.
Public IP allocation: Minimize the use of public IP addresses and use Azure Private Link when possible to access services over a private connection.
IP address management (IPAM): Use IPAM solutions to manage and track IP address allocation across your hybrid environment.

When allocating IP address spaces to Azure Virtual Networks (VNets), it's essential to follow best practices for proper management, scalability, and to avoid potential issues. Here are some recommendations for IP allocation to VNets:

Plan your address space: Choose an appropriate private address space (from RFC 1918) for your VNets that is large enough to accommodate future growth. Avoid overlapping with on-premises or other cloud networks.

Use CIDR notation: Use Classless Inter-Domain Routing (CIDR) notation to define the VNet address space, which allows more efficient allocation and prevents wasting IP addresses.

Allocate non-overlapping address spaces: Assign non-overlapping address spaces to different VNets to prevent routing issues and to simplify peering configurations.

Use subnets: Divide your VNets into smaller subnets based on security, application, or environment requirements. This allows for better network management and security.

Consider leaving a buffer between VNets: While it's not strictly necessary, leaving a buffer between VNets can be beneficial in some cases, especially when you anticipate future growth or when you might need to merge VNets. This can help avoid re-addressing conflicts when expanding or merging networks.

Reserve IP addresses: Reserve a range of IP addresses within your VNet address space for critical resources or services. This ensures that they have a static IP address, which is essential for specific services or applications.

Allocate IP addresses for VNet peering: When you plan to use VNet peering, allocate a separate IP address space for the peered VNets. This will prevent IP conflicts and ensure seamless communication between VNets.

Plan for hybrid scenarios: If you're working in a hybrid environment with on-premises or multi-cloud networks, ensure that you plan for IP address allocation across all environments. This includes avoiding overlapping address spaces and reserving IP addresses for specific resources like VPN gateways or ExpressRoute circuits.

Following these best practices for IP allocation in Azure VNets helps prevent potential issues like overlapping IP address spaces, routing conflicts, or difficulties when expanding, merging, or peering VNets.
### Resource allocation

For resource allocation the best practices from [Cloud Resource Design Guidance](cloud-resource-design-guidance/README.md) should be followed.

## References

The following references can be used to understand the lastest best practices in working in a hybrid or cross cloud environment:

* [Private dns resolver](https://learn.microsoft.com/en-us/azure/dns/dns-private-resolver-overview)

## Tooling

* [Azure Resource Naming Tool](https://github.com/microsoft/CloudAdoptionFramework/tree/master/ready/AzNamingTool)
