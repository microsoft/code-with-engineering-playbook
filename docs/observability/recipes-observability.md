# Recipes

## Application Insights/ASP.NET

[GitHub Repo](https://github.com/Azure-Samples/application-insights-aspnet-sample-opentelemetry), [Article](https://devblogs.microsoft.com/aspnet/observability-asp-net-core-apps/).

## Application Insights/ASP.NET Core with Distributed Trace Context Propagation to Kafka

[GitHub Repo](https://github.com/MagdaPaj/application-insights-aspnet-sample-trace-context-propagation).

## Example: OpenTelemetry Over a Message Oriented Architecture in Java with Jaeger, Prometheus and Azure Monitor

[GitHub Repo](https://github.com/iamnicoj/OpenTelemetry-Async-Java-with-Jaeger-Prometheus-AzMonitor)

## Example: Setup Azure Monitor Dashboards and Alerts with Terraform

[GitHub Repo](https://github.com/buzzfrog/azure-alert-dashboard-terraform)

## On-premises Application Insights

[On-premise Application Insights](https://github.com/c-w/appinsights-on-premises) is a service that is compatible with Azure App Insights, but stores the data in an in-house database like PostgreSQL or object storage like [Azurite](https://github.com/Azure/Azurite).

On-premises Application Insights is useful as a drop-in replacement for Azure Application Insights in scenarios where a solution must be cloud deployable but must also support on-premises disconnected deployment scenarios.

On-premises Application Insights is also useful for testing telemetry integration. Issues related to telemetry can be hard to catch since often these integrations are excluded from unit-test or integration test flows due to it being non-trivial to use a live Azure Application Insights resource for testing, e.g. managing the lifetime of the resource, having to ignore old telemetry for assertions, if a new resource is used it can take a while for the telemetry to show up, etc. The On-premise Application Insights service can be used to make it easier to integrate with an Azure Application Insights compatible API endpoint during local development or continuous integration without having to spin up a resource in Azure. Additionally, the service simplifies integration testing of asynchronous workflows such as web workers since integration tests can now be written to assert against telemetry logged to the service, e.g. assert that no exceptions were logged, assert that some number of events of a specific type were logged within a certain time-frame, etc.

## Azure DevOps Pipelines Reporting with Power BI

The [Azure DevOps Pipelines Report](https://github.com/Azure-Samples/powerbi-pipeline-report) contains a [Power BI](https://learn.microsoft.com/en-us/power-bi/fundamentals/power-bi-overview) template for monitoring project, pipeline, and pipeline run data from an Azure DevOps (AzDO) organization.

This dashboard recipe provides observability for AzDO pipelines by displaying various metrics (i.e. average runtime, run outcome statistics, etc.) in a table. Additionally, the second page of the template visualizes pipeline success and failure trends using Power BI charts. Documentation and setup information can be found in the project README.

## Python Logger Class for Application Insights using OpenCensus

The Azure SDK for Python contains an [Azure Monitor Opentelemetry Distro client library for Python ](https://github.com/Azure/azure-sdk-for-python/tree/main/sdk/monitor/azure-monitor-opentelemetry). You can view samples of how to use the library in this [GitHub Repo](https://github.com/Azure/azure-sdk-for-python/tree/main/sdk/monitor/azure-monitor-opentelemetry/samples). With this library you can easily collect traces, metrics, and logs.

## Java OpenTelemetry Examples

This [GitHub Repo](https://github.com/open-telemetry/opentelemetry-java-docs) contains a set of fully-functional, working examples of using the OpenTelemetry Java APIs and SDK.
