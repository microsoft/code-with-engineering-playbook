# Observability

Building observable systems enables development teams at CSE to measure how well the application is behaving.

## Goals

1. Provide holistic view on the health of the application.
2. Help measure business performance for the customer.
3. Measure operational performance of the system.
4. Identify and diagnose failures to get to the problem fast.

## Sections

- [Pillars of Observability](#pillars-of-observability)
- [Observability in Machine Learning](#ml-observability.md)
- [Observability As Code](#observability-as-code)
- [Recommended Practices](#recommended-practices)
- [Logs vs Metrics](log-vs-metric.md)
- [Recipes](#recipes)

## Pillars of Observability

1. [Logging](pillars/logging.md)
2. [Tracing](pillars/tracing.md)
3. [Metrics](pillars/metrics.md)

## Observability in Machine Learning

Read on how Observability can be implemented in [Machine Learning](ml-observability.md) engagements effectively during Model tuning, experimentation and deployment.

## Observability As Code

As much as possible, configuration and management of observability assets such as cloud resource provisioning, monitoring alerts and dashboards must be managed as code. Observability as Code is achieved using any one of Terraform / Ansible / ARM Templates

### Examples of Observability As Code

1. Dashboards as Code- You can create Monitoring Dashboards as Json or XML templates, such templates can be checked into the code repository for source control, any change in the dashboards can be reviewed and automation can be built for enabling the dashboard. [More about how to do this in Azure A](https://docs.microsoft.com/en-us/azure/azure-portal/azure-portal-dashboards-create-programmatically).

2. Alerts as Code- Alerts can be created within azure by using Terraform or ARM templates. Such alerts can be source controlled and be deployed as part of pipelines(Azure Devops pipelines, Jenkins, Github Actions etc.). Some reference of how to do this are: [Terraform Monitor Metric Alert](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/monitor_metric_alert). Alerts can also be created based on log analytics query and can be defined as code using [Terraform Monitor Scheduled Query Rules Alert](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/monitor_scheduled_query_rules_alert#example-usage).

3. Automating Log Analytics Queries- There are several use cases where automation of log analytics queries may be needed. Example, Automatic Report Generation, Running custom queries programmatically for analysis, debugging etc. For these use cases to work, log queries should be source controlled and automation can be built using [log analytics REST](https://dev.loganalytics.io/documentation/Using-the-API) or [azure cli](https://docs.microsoft.com/en-us/cli/azure/ext/log-analytics/monitor/log-analytics?view=azure-cli-latest).

### Why

- It makes configuration repeatable and automatable. It also avoids manual configuration of monitoring alerts and dashboards from scratch across environments.

- Configured dashboards help troubleshoot errors during integration and deployment (CI/CD)

- We can audit changes and roll them back if there are any issues.

- Identify actionable insights from the generated metrics data across all environments, not just production.

- Configuration and management of observability assets like alert threshold, duration, configuration
values using IAC help us in avoiding configuration mistakes, errors or overlooks during deployment.

- When practicing observability as code, the changes can be reviewed by the team similar to other code
contributions.

## Recommended Practices

1. **Correlation Id**: Include unique identifier at the start of the interaction to tie down aggregated data from various system components and provide a holistic view. Read more guidelines about using [correlation id](correlation-id.md).
2. Ensure health of the services are **monitored** and provide insights into system's performance and behavior.
3. Ensure **dependent services** are monitored properly. Errors and exceptions in dependent services like Redis cache, Service bus, etc. should be logged and alerted. Also metrics related to dependent services should be captured and logged.
4. **Faults, crashes, and failures** are logged as discrete events. This helps engineers identify problem area(s) during failures.
5. Ensure logging configuration (eg: setting logging to "verbose") can be controlled without code changes.
6. Ensure that **metrics** around latency and duration are collected and can be aggregated.
7. Start small and add where there is customer impact. [Avoiding metric fatigue](pitfalls.md#metric-fatigue) is very crucial to collecting actionable data.
8. It is important that every data that is collected contains relevant and rich context.
9. Personally Identifiable Information or any other customer sensitive information should never be logged. Special attention should be paid to any local privacy data regulations and collected data must adhere to those. (ex: GPDR)

Read more [here](pitfalls.md) to understand what to watch out for while designing and building an observable system.

## Recipes

### Application Insights/ASP.NET

[Github Repo](https://github.com/Azure-Samples/application-insights-aspnet-sample-opentelemetry), [Article](https://devblogs.microsoft.com/aspnet/observability-asp-net-core-apps/).

### On-premises Application Insights

[On-premise Application Insights](https://github.com/c-w/appinsights-on-premises) is a service that is compatible with Azure App Insights, but stores the data in an in-house database like PostgreSQL or object storage like [Azurite](https://github.com/Azure/Azurite).

On-premises Application Insights is useful as a drop-in replacement for Azure Application Insights in scenarios where a solution must be cloud deployable but must also support on-premises disconnected deployment scenarios.

On-premises Application Insights is also useful for testing telemetry integration. Issues related to telemetry can be hard to catch since often these integrations are excluded from unit-test or integration test flows due to it being non-trivial to use a live Azure Application Insights resource for testing, e.g. managing the lifetime of the resource, having to ignore old telemetry for assertions, if a new resource is used it can take a while for the telemetry to show up, etc. The On-premise Application Insights service can be used to make it easier to integrate with an Azure Application Insights compatible API endpoint during local development or continuous integration without having to spin up a resource in Azure. Additionally, the service simplifies integration testing of asynchronous workflows such as web workers since integration tests can now be written to assert against telemetry logged to the service, e.g. assert that no exceptions were logged, assert that some number of events of a specific type were logged within a certain time-frame, etc.
