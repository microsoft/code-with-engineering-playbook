# Observability

Building observable systems enables development teams at CSE to measure how well the application is behaving.

## Goals

1. Provide holistic view on the health of the application.
2. Help measure business performance for the customer.
3. Measure operational performance of the system.
4. Identify and diagnose failures to get to the problem fast.

## Pillars of Observability

1. [Logging](/observability/pillars.md#Logging)
2. [Tracing](/observability/pillars.md#Tracing)
3. [Metrics](/observability/pillars.md#Metrics)

## Recommended Practices

1. **Correlation Id**: Include unique identifier at the start of the interaction to tie down aggregated data from various system components and provide a holistic view. Read more guidelines about using [correlation id](correlation-id.md).
1. Ensure health of the services are **monitored** and provide insights into system's performance and behavior.
2. **Faults, crashes, and failures** are logged as discrete events. This helps engineers identify problem area(s) during failures.
3. Ensure logging configuration (eg: setting logging to "verbose") can be controlled without code changes.
4. Ensure that **metrics** around latency and duration are collected and can be aggregated.
5. Don't attempt to monitor everything. If the data is not actionable, it is useless and becomes a noise.
6. As a general rule, do not log any customer sensitive and Personal Identifiable Information (PII). Ensure any pertinent privacy regulations are followed regarding PII (Ex: GDPR etc.,)
7. Start small and add where there is customer impact.

## What is collected

1. **Latency**: Time taken to service a request.
2. **Traffic**: Measurement of how much demand is placed on the system, typically number of requests per second.
3. **Errors**: Errors, application faults and traces with adequate information on error messages.
4. Identify a unique value (correlation identifier) that will be consistently tagged with data.

In addition to above, engineers are encouraged to have conversations to understand other logs, metrics, data that adds value to the customer.

## Recommended Tools and Approaches

1. [Application Insights](https://docs.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview)

## Recipes

Links to GitHub posts - Coming soon
