# Logging

## Overview

Logs are discrete events with the goal of helping engineers identify problem area(s) during failures.

## Collection Methods

When it comes to log collection methods, two of the standard techniques are a direct-write or an agent-based approach.

Directly written log events are handled in-process of the particular component, usually utilizing a provided library. [Azure Monitor](https://azure.microsoft.com/en-us/services/monitor) has direct send capabilities, but it's not recommended for serious/production use. This approach has some advantages:

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

## Best Practices

- Pay attention to logging levels. Logging too much will increase costs and decrease application throughput.
- Ensure logging configuration can be modified without code changes. Ideally, make it changeable without application restarts.
- If available, take advantage of logging levels per category allowing granular logging configuration.
- Check for log levels before logging, thus avoiding allocations and string manipulation costs.
- Ensure service versions are included in logs to be able to identify problematic releases.
- Log a raised exception only once. In your handlers, only catch expected exceptions that you can handle gracefully (even with a specific return code). If you want to log and rethrow, leave it to the top level exception handler. Do the minimal amount of cleanup work needed then throw to maintain the original stack trace. Don’t log a warning or stack trace for expected exceptions (eg: properly expected 404, 403 HTTP statuses).
- Fine tune logging levels in production (>= warning for instance). During a new release the verbosity can be increased to facilitate bug identification.
- If using sampling, implement this at the service level rather than defining it in the logging system. This way we have control over what gets logged. An additional benefit is reduced number of roundtrips.
- Only include failures from health checks and non-business driven requests.
- Ensure a downstream system malfunction won't cause repetitive logs being stored.
- Don't reinvent the wheel, use existing tools to collect and analyse the data.
- Ensure personal identifiable information policies and restrictions are followed.
- Ensure errors and exceptions in dependent services are captured and logged. For example, if an application uses Redis cache, Service Bus or any other service, any errors/exceptions raised while accessing these services should be captured and logged.

### If there's sufficient log data, is there a need for instrumenting metrics?

[Logs vs Metrics](../log-vs-metric.md) covers some high level guidance on when to utilize metric data and when to use log data. Both have a valuable part to play in creating observable systems.

### Having problems identifying what to log?

**At application startup**:

- Unrecoverable errors from startup.
- Warnings if application still runnable, but not as expected (i.e. not providing blob connection string, thus resorting to local files. Another example is if there's a need to fail back to a secondary service or a known good state, because it didn’t get an answer from a primary dependency.
- Information about the service’s state at startup (build #, configs loaded, etc.)

**Per incoming request**:

- Basic information for each incoming request: the url (scrubbed of any personally identifying data, a.k.a. PII), any user/tenant/request dimensions, response code returned, request-to-response latency, payload size, record counts, etc. (whatever you need to learn something from the aggregate data)
- Warning for any unexpected exceptions, caught only at the top controller/interceptor and logged with or alongside the request info, with stack trace. Return a 500. This code doesn’t know what happened.

**Per outgoing request**:

- Basic information for each outgoing request: the url (scrubbed of any personally identifying data, a.k.a. PII), any user/tenant/request dimensions, response code returned, request-to-response latency, payload sizes, record counts returned, etc. Report perceived availability and latency of dependencies and including slicing/clustering data that could help with later analysis.

## Recommended Tools

- [Azure Monitor](https://docs.microsoft.com/en-us/azure/azure-monitor/overview) - Umbrella of services including system metrics, log analytics and more.
- [Grafana Loki](../tools/loki.md) - An open source log aggregation platform, built on the learnings from the Prometheus Community for highly efficient collection & storage of log data at scale.
- [The Elastic Stack](https://www.elastic.co/what-is/elk-stack) - An open source log analytics tech stack utilizing Logstash, Beats, Elastic search and Kibana.
- [Grafana](https://grafana.com) - Open source dashboard & visualization tool. Supports Log, Metrics and Distributed tracing data sources.
