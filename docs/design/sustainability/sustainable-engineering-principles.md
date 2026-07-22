# Sustainable Principles

The following principle overviews provide the foundations supporting specific actions in the [Sustainable Engineering Checklist](./README.md#sustainable-engineering-checklist). More details about each principle can be found by following the links in the headings or visiting the [Principles of Green Software Engineering website](https://learn.greensoftware.foundation/).

## [Electricity Consumption](https://learn.greensoftware.foundation/energy-efficiency)

Most electricity is still produced through the burning of fossil fuels and is responsible for 49% of the carbon emitted into the atmosphere.

Software consumes electricity in its execution. Running hardware consumes electricity even at zero percent utilization.  Some of the best ways we can reduce electricity consumption and the subsequent emissions of carbon pollution is to make our applications more energy efficient when they are running and limit idle hardware.

## [Energy Proportionality](https://learn.greensoftware.foundation/energy-efficiency#energy-proportionality)

![Illustrative graph showing a computer at 0% utilization draws 100 Watts, at 50% utilization it draws 180 Watts and at 100% utilization it draws 200 Watts. The relationship between power consumption and utilization is not linear and it does not cross the origin.](https://learn.greensoftware.foundation/assets/images/06_energy_proportionality_updated-a6941b6c0d261511e74dc2217062373c.png)

The relationship between power and utilization is not proportional.

The more you utilize a computer, the more efficient it becomes at converting electricity to useful computing operations. Running your work on as few servers as possible with the highest utilization rate maximizes their energy efficiency.

An idle computer, even running at zero percent utilization, still draws electricity.

## [Embodied Carbon](https://learn.greensoftware.foundation/hardware-efficiency#embodied-carbon)

Embodied carbon (otherwise referred to as "Embedded Carbon") is the amount of carbon pollution emitted during the creation and disposal of a device. When calculating the total carbon pollution for the computers running your software, account for both the carbon pollution to run the computer and the embodied carbon of the computer. Therefore a great way to reduce embodied carbon is to prevent the need for new devices to be manufactured by extending the usefulness of existing ones.

## [Demand Shaping](https://learn.greensoftware.foundation/carbon-awareness#demand-shaping)

Demand shaping is a strategy of shaping our demand for resources so it matches the existing supply.

If supply is high, increase the demand by doing more in your applications. If the supply is low, decrease demand.  This means doing less in your applications or delaying work until supply is higher.

## [Networking](https://learn.greensoftware.foundation/)

A network is a series of switches, routers, and servers. All the computers and network equipment in a network consume electricity and have [embedded carbon](#embodied-carbon). The internet is a global network of devices typically run off the standard local grid energy mix.

When you send data across the internet, you are sending that data through many devices in the network, each one of those devices consuming electricity. As a result, any data you send or receive over the internet emits carbon.

The amount of carbon emitted to send data depends on many factors including:

- Distance the data travels
- Number of hops between network devices
- Energy efficiency of the network devices
- Carbon intensity of energy used by each device at the time the data is transmitted.
- Network protocol used to coordinate data transmission - e.g. multiplex, header compression, TLS/Quic

[Recent networking studies - Cloud Carbon Footprint](https://www.cloudcarbonfootprint.org/docs/methodology/#appendix-iv-recent-networking-studies)
