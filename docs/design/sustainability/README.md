# Sustainable Software Engineering

The choices made throughout the engineering process regarding cloud services, software architecture
design and automation can have a big impact on the carbon footprint of a solution. We can opt for the use of a shared service, which has less Carbon footprint compared to deployed and dedicated VMs in the same region which - depending on the projected load - could potentially could run well below capacity for longer periods of time.  

## Sustainability in the Engineering process

### Business Strategy

Several companies have a strategy and goals to reduce their carbon footprint. During the Envisioning phase of a Software
Engineering project, aligning with the sustainability strategy of the company and gathering information on the guidelines and implications could prove beneficial for the environment and useful for the project.

### Architecture Design

During the [design](../) phase, choices on the type of infrastructure and services can have a big impact on the
carbon footprint of the solution.

#### Platform  vs. Infratructure services

Opting for platform or shared services does not only reduce the overall and maintenance cost, it also pushes capacity
planning to the responsibilities of the provider and has benefits regarding optimal use of resources.

#### Use of Virtual Machines

If VMs within a protected network is a requirement, consider the ability to automate scaling up or down with the current
or anticipated load.

In some scenarios, Spot VMs could augment regular VMs to process production workloads. They utilize unused capacity in
existing data center infrastructure and usually cost just a fraction of on-demand virtual machines. By taking advantage of existing infrastructure, leveraging Spot VMs reduces the the need for more hardware to run in data centers and ultimately reduces future energy consumption.

#### Data Storage

Consider what performance for data access is required, i.e. having different storage layers for fast and slower access.

Avoid duplication of data if possible and feasible.

#### Payload

Compression of payload data can reduce the load on network layers.

### Observability

[Observability](../../observability) can surface information on load and capacity of the system. If not already supported by
the chosen services, consider to automate scaling down when resources are idle.

### CI/CD Pipelines

[CI/CD pipelines](../../continuous-integration) offer the capability to re-create an environment from scratch, and to
deprovision the whole infrastructure if it is not in-use. Load test or staging environments are often not in use during
the development cycle and could be deprovisioned after testing.

### Developer environment

Turn off idle developer VMs and consider leveraging Spot VMs for non-production workloads.

## Guidelines

- [Principles of Green Software Engineering](https://principles.green/)
- [Microsoft Cloud for Sustainability](https://www.microsoft.com/en-us/sustainability)
- [Learning Module: Sustainable Software
Engineering](https://docs.microsoft.com/en-us/learn/modules/sustainable-software-engineering-overview/)

## Tools

- [Emissions Impact](https://appsource.microsoft.com/en-us/product/power-bi/coi-sustainability.emissions_impact_dashboard)
- [Azure GreenAI Carbon-Intensity API](http://azure-uw-cli-2021.azurewebsites.net/home)

## Projects

- [Green Energy Hub (Energinet)](https://github.com/Energinet-DataHub/green-energy-hub)
- [Sustainability through SpotVMs](https://github.com/hybridflux/SparkOnSpot)

## Other resources

- [Green Software](https://github.com/Green-Software-Foundation/awesome-green-software)
