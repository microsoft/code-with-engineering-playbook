# Disclaimers

The following disclaimers provide more details about how to consider the impact of particular actions recommended by the [Sustainable Engineering Checklist](./README.md#sustainabile-engineering-checklist).

## ACTION: Resize physical or virtual machines to improve utilization

Recommendations from cost-savings tools are usually aligned with carbon-reduction, but as sustainability is not the purpose of such tools, carbon-savings are not guaranteed. How a cloud provider or data center manages unused capacity is also a factor in determining how impactful this action may be. For example:

The sustainable impact of using smaller VMs in the same family are typically beneficial or neutral. When cores are no longer reserved they can be used by others instead of bringing new servers online.

The sustainable impact of changing VM families can be harder to reason about because the underlying hardware and reserved cores may be changing with them.

## ACTION: Migrate to a hyperscale cloud provider

Carbon savings from hyperscale cloud providers are generally attributable to four key features: IT operational efficiency, IT equipment efficiency, datacenter infrastructure efficiency, and renewable electricity. Microsoft Cloud, for example, is between 22 and 93 percent more energy efficient than traditional enterprise datacenters, depending on the specific comparison being made. When taking into account renewable energy purchases, the Microsoft Cloud is between 72 and 98 percent more carbon efficient. [Source [PDF]](https://download.microsoft.com/download/7/3/9/739BC4AD-A855-436E-961D-9C95EB51DAF9/Microsoft_Cloud_Carbon_Study_2018.pdf)

## ACTION: Consider running an edge device

Running an edge device negates many of the benefits of hyperscale compute facilities, so considering the local energy grid mix and the typical timing of the workloads is important to determine if this is beneficial overall.  The larger volume of data that needs to be transmitted, the more this solution becomes appealing. For example, sending large amounts of audio and video content for processing.

## ACTION: Consider physically shipping data to the provider

Shipping physical items has its own carbon impact, depending on the mode of transportation, which needs to be understood before making this decision.  The larger the volume of data that needs to be transmitted the more this options may be beneficial.

## ACTION: Consider the energy efficiency of languages

When selecting a programming language, the _most_ energy efficient progamming language may not always be the best choice for development speed, maintenance, integration with dependent systems, and other project factors. But when deciding between languages that all meet the project needs, energy efficiency can be a helpful consideration.
