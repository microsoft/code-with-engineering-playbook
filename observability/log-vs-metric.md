# Logs vs Metrics

## Overview

### Metrics

The purpose of metrics is to inform observers about the health & operations regarding a component or system. A metric represents a point in time measure of a particular source, and data-wise tends to be very small. The compact size allows for efficient collection even at scale in large systems. Metrics also lend themselves very well to preaggregation within the component before collection, reducing computation cost for processing & storing large numbers of metric time series in a central system. Due to how efficiently metrics are processed & stored, it lends itself very well for use in automated alerting, as metrics are an excellent source for the health data for all components in the system.

### Logs

Log data inform observers about the discreet events that occurred within a component or a set of components. Just about every software component log information about its activities over time. This rich data tends to be much larger than metric data and can cause processing issues, especially if components are logging too verbosely. Therefore using log data to understand the health of an extensive system tends to be avoided and depends on metrics for that data. Once metric telemetry highlights potential problem sources, filtered log data for those sources can be used to understand what occurred.

## Formats & Collection Methods

### Log Collection

When it comes to log collection methods, two of the standard techniques are a direct-write or an agent-based approach.

Directly written log events are handled in-process of the particular component, usually utilizing a provided library. This approach has some advantages:

- There is no external process to configure or monitor
- No log file management (rolling, expiring) to prevent out of disk space issues.

The potential trade-offs of this approach:

- Potentially higher memory usage if the particular library is using a memory backed buffer.
- In the event of an extended service outage, log data may get dropped or truncated due to buffer constraints.
- Multiple component process logging will manage & emit logs individually, which can be more complex to manage for the outbound load.

Agent-based log collection relies on an external process running on the host machine, with the particular component emitting log data stdout or file. Writing log data to stdout is the preferred practice when running applications within a container environment like Kubernetes. The container runtime redirects the output to files, which can then be processed by an agent. [Azure Monitor](https://azure.microsoft.com/en-us/services/monitor), [Grafana Loki](https://github.com/grafana/loki) [Elastic's Logstash](https://www.elastic.co/logstash) and [Fluent Bit](https://fluentbit.io/) are examples of log shipping agents.

There are several advantages when using an agent to collect & ship log files:

- Centralized configuration.
- Collecting multiple sources of data with a single process.
- Local pre-processing & filtering of log data before sending it to a central service.
- Utilizing disk space as a data buffer during a service disruption.

This approach isn't without trade-offs:

- Required exclusive CPU & memory resources for the processing of log data.
- Persistent disk space for buffering.

### Metric Collection

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

## Usage Guidance

When to use metric or log data to track a particular piece of telemetry can be summarized with the following points:

- Use metrics to track the occurrence of an event, counting of items, the time taken to perform an action or to report the current value of a resource (CPU, memory, etc.)
- Use logs to track detailed information about an event also monitored by a metric, particularly errors, warnings or other exceptional situations.
