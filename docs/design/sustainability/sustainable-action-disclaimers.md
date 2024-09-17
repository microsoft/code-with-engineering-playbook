# Disclaimers

The following disclaimers provide more details about how to consider the impact of particular actions recommended by the [Sustainable Engineering Checklist](./README.md#sustainable-engineering-checklist).

## ACTION: Resize Physical or Virtual Machines to Improve Utilization

Recommendations from cost-savings tools are usually aligned with carbon-reduction, but as sustainability is not the purpose of such tools, carbon-savings are not guaranteed. How a cloud provider or data center manages unused capacity is also a factor in determining how impactful this action may be. For example:

The sustainable impact of using smaller VMs in the same family are typically beneficial or neutral. When cores are no longer reserved they can be used by others instead of bringing new servers online.

The sustainable impact of changing VM families can be harder to reason about because the underlying hardware and reserved cores may be changing with them.

## ACTION: Migrate to a Hyperscale Cloud Provider

Carbon savings from hyperscale cloud providers are generally attributable to four key features: IT operational efficiency, IT equipment efficiency, data center infrastructure efficiency, and renewable electricity. Microsoft Cloud, for example, is between 22 and 93 percent more energy efficient than traditional enterprise data centers, depending on the specific comparison being made. When taking into account renewable energy purchases, the Microsoft Cloud is between 72 and 98 percent more carbon efficient. [Source (PDF)](https://download.microsoft.com/download/7/3/9/739BC4AD-A855-436E-961D-9C95EB51DAF9/Microsoft_Cloud_Carbon_Study_2018.pdf)

## ACTION: Consider Running an Edge Device

Running an edge device negates many of the benefits of hyperscale compute facilities, so considering the local energy grid mix and the typical timing of the workloads is important to determine if this is beneficial overall.  The larger volume of data that needs to be transmitted, the more this solution becomes appealing. For example, sending large amounts of audio and video content for processing.

## ACTION: Consider Physically Shipping Data to the Provider

Shipping physical items has its own carbon impact, depending on the mode of transportation, which needs to be understood before making this decision.  The larger the volume of data that needs to be transmitted the more this options may be beneficial.

## ACTION: Consider the Energy Efficiency of Languages

When selecting a programming language, the _most_ energy efficient programming language may not always be the best choice for development speed, maintenance, integration with dependent systems, and other project factors. But when deciding between languages that all meet the project needs, energy efficiency can be a helpful consideration.

## ACTION: Use Caching Policies

A cache provides temporary storage of resources that have been requested by an application. Caching can improve application performance by reducing the time required to get a requested resource. Caching can also improve sustainability by decreasing the amount of network traffic.

While caching provides these benefits, it also increases the risk that the resource returned to the application is stale, meaning that it is not identical to the resource that would have been sent by the server if caching were not in use. This can create poor user experiences when data accuracy is critical.

Additionally, caching may allow unauthorized users or processes to read sensitive data. An authenticated response that is cached may be retrieved from the cache without an additional authorization. Due to security concerns like this, caching is **not recommended** for middle tier scenarios.

## ACTION: Consider Caching Data Close to End Users with a CDN

Including CDNs in your network architecture adds many additional servers to your software footprint, each with their own  local energy grid mix.  The details of CDN hardware and the impact of the power that runs it is important to determine if the carbon emissions from running them is lower than the emissions from sending the data over the wire from a more distant source.  The larger the volume of data, distance it needs to travel, and frequency of requests, the more this solution becomes appealing.
