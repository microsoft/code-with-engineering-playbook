# Observability

Building observable systems enables development teams at CSE to measure how well the application is behaving.

## Goals

1. Provide holistic view on the health of the application.
2. Help measure business performance for the customer.
3. Measure operational performance of the system.
4. Identify and diagnose failures to get to the problem fast.

## Sections

- [Pillars of Observability](#pillars-of-observability)
- [Recommended Practices](#recommended-practices)
- [Pitfalls to Avoid](#pitfalls-to-avoid)
- [Recommended Tools and Approaches](#recommended-tools-and-approaches)
- [Tools](#tools)
- [Recipes](#recipes)

## Pillars of Observability

1. [Logging](pillars/logging.md)
2. [Tracing](pillars/tracing.md)
3. [Metrics](pillars/metrics.md)
4. [Dashboard](pillars/dashboard.md)

## Recommended Practices

1. **Correlation Id**: Include unique identifier at the start of the interaction to tie down aggregated data from various system components and provide a holistic view. Read more guidelines about using [correlation id](correlation-id.md).
2. Ensure health of the services are **monitored** and provide insights into system's performance and behavior.
3. **Faults, crashes, and failures** are logged as discrete events. This helps engineers identify problem area(s) during failures.
4. Ensure logging configuration (eg: setting logging to "verbose") can be controlled without code changes.
5. Ensure that **metrics** around latency and duration are collected and can be aggregated.
6. Start small and add where there is customer impact.

## Pitfalls to avoid

Read more [here](pitfalls.md) to understand what to watch out for while designing and building an observable system.

## Recipes

### Application Insights/ASP.NET

[Github Repo](https://github.com/Azure-Samples/application-insights-aspnet-sample-opentelemetry), [Article](https://devblogs.microsoft.com/aspnet/observability-asp-net-core-apps/).

### On-premises Application Insights

[On-premise Application Insights](https://github.com/c-w/appinsights-on-premises) is a service that is compatible with Azure App Insights, but stores the data in an in-house database like PostgreSQL or object storage like [Azurite](https://github.com/Azure/Azurite).

On-premises Application Insights is useful as a drop-in replacement for Azure Application Insights in scenarios where a solution must be cloud deployable but must also support on-premises disconnected deployment scenarios.

On-premises Application Insights is also useful for testing telemetry integration. Issues related to telemetry can be hard to catch since often these integrations are excluded from unit-test or integration test flows due to it being non-trivial to use a live Azure Application Insights resource for testing, e.g. managing the lifetime of the resource, having to ignore old telemetry for assertions, if a new resource is used it can take a while for the telemetry to show up, etc. The On-premise Application Insights service can be used to make it easier to integrate with an Azure Application Insights compatible API endpoint during local development or continuous integration without having to spin up a resource in Azure. Additionally, the service simplifies integration testing of asynchronous workflows such as web workers since integration tests can now be written to assert against telemetry logged to the service, e.g. assert that no exceptions were logged, assert that some number of events of a specific type were logged within a certain time-frame, etc.
