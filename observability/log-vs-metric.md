# Logs vs Metrics

## Overview

### Metrics

The purpose of metrics is to inform observers about the health & operations regarding a component and/or system. A metric represents a point in time measure of a particular source and data wise tends to be very small. This allows for efficient collection even at scale in large systems. Metrics also lend them selves very well to preaggregation within the component prior to collection, reducing computation cost for processing & storing large numbers of metric time series in a central system. Due to the efficient nature of how metrics processed & stored, it lends itself very well for use in automated alerting; as metrics are an excellent source for the health data for all components in the system.

### Logs

Log data informs observers about the discreet events that occured within a component or a set of components. Just about every software components logs information about its activities over time. This rich data tends to be much larger than metric data and can cause processing issues, especially if componently are logging too verbosely. Therefore using log data to understand the health of a large system tends to be avoided, instead leaning on metrics for that data. Once metric telemetry highlights potential problem sources, filtered log data for those sources can be used to understand what occured.

## Formats & Collection Methods


### Logs

When it comes to log collection methods, two of the common methods are a direct write or an agent based, approach.

Directly written log events are handled in-process of the particular component, usually utilizing a provided library. This has some some advantages:

- There is no external process to configure or monitor
- No log file management (rolling, expiring) to prevent out of disk space issues.

The potential trade-offs of this approach:

- Potentially higher memory usage if the particular library is using a memory backed buffer.
- In the event of an extended service outage, log data may be dropped/truncated due to buffer constraints.
- Multiple componet process logging will manage & emit logs individually, which can be more complex to manage for outbound load.

Agent based log collection relies on an external process running on the host machine, with the perticular component emitting log data stdout or file. Writting log data to stdout is the preferred practice when running applications within a container environment like Kubernetes. The container runtime redirects the output to files, which can then be processed by an agent.

There are a number of advantages when using an agent to collect & ship log files:

- Centralized configuration.
- Collecting multiple sources of data with a single process.
- Local pre-processing & filtering of log data before sending to a central service.
- Utilizing disk space as a data buffer during service disruption.

This approach isn't without trade-offs:
- Required exclusive cpu & memeory resources for processing
- Persistent disk space for buffering. 
- Log file management tools, such as `logrotate`, may be needed to roll off old log data to prevent eventual disk space exhaustion. 

Commonly used formats for log data, which are generally only utilized when using the agent based logging, fall into 2 categories: Unstructured and structured. Unstructured logs are lines of text separated with spaces and other punctuation. They may be humanly readable but are generally poor for a machine to parse in any reliable way. Structured logs have a more apparent structure to them to assist with machine processing. This includles having a field name and a value, using a consistent format.

An example of unstructured log data might look something like this:
`14/June/2019 20:10 An unexpected error occured. ERROR foo.bar`

A structured version of the same information may look like:
`ts=2019-06-14T20:10Z msg="An unexpected error occured." level=ERROR host=foo.bar`
or as JSON
`{"ts":"2019-06-14T20:10Z","msg":"An unexpected error occured.","level":"ERROR","host":"foo.bar"}`

By using structuring of log data to decorate various fields with names, greatly assists in their processing by an agent or central service.

### Metrics

Metric collection approaches fall into two broad categories: push metrics & pull metrics. Push metrics means that the originating component sends the data to a remote service or agent. Microsoft Application Insights and Etsy's statsd are examples of push metrics. Some of the strengths with push metrics include:

- Only require network egress to the remote target.
- Originating component controls frequency of measurement.
- Simplified configuration as the component only needs to know where to send data to.

Some of the trade-offs with this approach:

- At scale it is much more difficult to control data intake rates, which can cause service throttling or dropping of values.
- Determining if every component, particularly in a dynamic scale environment, is healthy and sending data is difficult.

In the case of pull metrics, each originating component publishes an endpoint for the metric agent to connect to and gather measurements. Prometheus and its ecosystem of tools are an example of pull style metrics. Benefits experienced using a pull metrics setup may involve:

- Singular configuration for determining what is measured and the frequency of measurement for the local environment.
- Every measurement target has its own metric related to if the measurement is successful or not, which can be used as a general health check.
- Support for routing, filtering and processing of metrics before sending them onto a globally central metrics store.

Items of concern to some may include:

- Configuring & managing data sources can lead to a complex configuration. Prometheus has tooling to auto-discover and configure data sources in some environments, such as Kubernetes, but there are always exceptions to this which lead to configuration complexity.
- Network configuration may add further complexity if firewalls and other ACLs need to be managed to allow connectivity.

## Usage Guidance 

When to use metric or log data to track a particular piece of telemetry can be summarized with the following points:

- Use metrics to track the occurance of an event, the time taken to perform an action or to report the current value of a resource (CPU, memory, etc)
- Use logs to track detailed information about an event also tracked by a metric, particularly errors, warnings or other exceptional situations. 
