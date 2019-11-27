# Observability

Building observable systems enables development teams at CSE to measure how well the application is behaving.

## Goals

1. Provide holistic view on the health of the application.
2. Help measure business performance for the customer.
3. Measure operational performance of the system.
4. Identify and diagnose failures to get to the problem fast.

## Recommended Practices

1. Ensure health of the services are **monitored** and provide insights into system's performance and behavior. 
2. <b>Faults, crashes and failures</b> are logged as discrete events. This helps engineers identify problem area(s) during failures.
3. Logging configuration (eg: verbose) can be controlled without code changes.
4. Ensure that <b>metrics</b> around latency, duration are collected and are aggregatable.
5. Include unique identifier for all logs to tie down aggregated data from various systems and provide a holistic view.
6. Don't attempt to monitor everything. If the data is not actionable, it is useless and becomes noise.
7. As a general rule, do not log any customer sensitive and Personal Identifiable Information (PII). Ensure GDPR compliance is followed regarding PII.
8. Start small and add where there is customer impact.

## What is collected

1. Latency: Time taken to service a request.
2. Traffic: Measurement of how much demand is placed on the system, typically number of requests per second.
3. Errors: Errors, application faults and traces with adequete information on error messages.
4. Identify a unique value (correlation identifier) that will be consistently tagged with data.

In addition to above, engineers are encouraged to have conversations to understand other logs, metrics, data that adds value to the customer.
