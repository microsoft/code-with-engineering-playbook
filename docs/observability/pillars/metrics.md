# Metrics

## Overview

Metrics provide a near real-time stream of data, informing operators and stakeholders about the functions the system is performing as well as its health. Unlike logging and tracing, metric data tends to be more efficient to transmit and store.

## Collection Methods

Metric collection approaches fall into two broad categories: push metrics & pull metrics. Push metrics means that the originating component sends the data to a remote service or agent. [Azure Monitor](https://azure.microsoft.com/en-us/services/monitor) and [Etsy's statsd](https://github.com/statsd/statsd) are examples of push metrics. Some of the strengths with push metrics include:

- Only require network egress to the remote target.
- Originating component controls the frequency of measurement.
- Simplified configuration as the component only needs to know the destination of where to send data.

Some of the trade-offs with this approach:

- At scale, it is much more difficult to control data transmission rates, which can cause service throttling or dropping of values.
- Determining if every component, particularly in a dynamic scale environment, is healthy and sending data is difficult.

In the case of pull metrics, each originating component publishes an endpoint for the metric agent to connect to and gather measurements. [Prometheus](https://prometheus.io/) and its ecosystem of tools are an example of pull style metrics. Benefits experienced using a pull metrics setup may involve:

- Singular configuration for determining what is measured and the frequency of measurement for the local environment.
- Every measurement target has a meta metric related to if the collection is successful or not, which can be used as a general health check.
- Support for routing, filtering and processing of metrics before sending them onto a globally central metrics store.

Items of concern to some may include:

- Configuring & managing data sources can lead to a complex configuration. Prometheus has tooling to auto-discover and configure data sources in some environments, such as Kubernetes, but there are always exceptions to this, which lead to configuration complexity.
- Network configuration may add further complexity if firewalls and other ACLs need to be managed to allow connectivity.

## Best Practices

### When should I use metrics instead of logs?

[Logs vs Metrics](../log-vs-metric.md) covers some high level guidance on when to utilize metric data and when to use log data. Both have a valuable part to play in creating observable systems.

### What should be tracked?

System critical measurements that relate to the application/machine health, which are usually excellent alert candidates. Work with your engineering and devops peers to identify the metrics, but they may include:

- CPU and memory utilization.
- Request rate.
- Queue length.
- Unexpected exception count.
- Dependent service metrics like response time for Redis cache, Sql server or Service bus.

Important business-related measurements, which drive reporting to stakeholders. Consult with the various stakeholders of the component, but some examples may include:

- Jobs performed.
- User Session length.
- Games played.
- Site visits.

### Dimension Labels

Modern metric systems today usually define a single time series metric as the combination of the name of the metric and its dictionary of dimension labels. Labels are an excellent way to distinguish one instance of a metric, from another while still allowing for aggregation and other operations to be performed on the set for analysis. Some common labels used in metrics may include:

- Container Name
- Host name
- Code Version
- Kubernetes cluster name
- Azure Region

_Note_: Since dimension labels are used for aggregations and grouping operations, do not use unique strings or those with high cardinality as the value of a label. The value of the label is significantly diminished for reporting and in many cases has a negative performance hit on the metric system used to track it.

## Recommended Tools

- [Azure Monitor](https://docs.microsoft.com/en-us/azure/azure-monitor/overview) - Umbrella of services including system metrics, log analytics and more.
- [Prometheus](https://docs.microsoft.com/en-us/azure/azure-monitor/overview) - A real-time monitoring & alerting application. It's exposition format for exposing time-series is the basis for OpenMetrics's standard format.
- [Thanos](https://thanos.io) - Open source, highly available Prometheus setup with long term storage capabilities.
- [Cortex](https://cortexmetrics.io) - Horizontally scalable, highly available, multi-tenant, long term Prometheus.
- [Grafana](https://grafana.com) - Open source dashboard & visualization tool. Supports Log, Metrics and Distributed tracing data sources.
