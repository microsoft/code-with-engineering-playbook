# Pillars of observability

## Logging

Logs are discrete events with the goal of helping engineers identify problem area(s) during failures.

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

## Tracing

Produces the information required to observe series of correlated operations in a distributed system. Once collected they show the path, measurements and faults in a end to end transaction.

- Ensure that at least key business transactions are traced.
- Include in each trace necessary information to identify software releases (i.e. service name, version). This is important to correlate deployments and system degradation.
- Ensure dependencies are included in trace (databases, I/O).
- If costs are a concern use sampling, avoiding throwing away errors, unexpected behaviour and critical information.
- Don't reinvent the wheel, use existing tools to collect and analyse the data.
- Ensure personal identifiable information policies and restrictions are followed.

## Metrics

Metrics provide a near real-time indication of how the system is running. As opposed to logs and traces, the amount of data collected using metrics remains constant as the system load increases.

- Measurements that need to be alerted upon are good candidates for metrics: queue length, retries, latency, requests/sec, cpu, memory. These metrics can be use to automatically scale components.
- Use metrics to collect business success measurements. For instance visits, sold items, session time, games played, jobs done. Ask stakeholders what they need.
- Whenever applicable add release/version dimensions to metrics, allowing the comparison between versions (did the change provide improvements?).