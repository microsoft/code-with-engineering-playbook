# Observability

Building observable systems enables development teams at CSE to measure how well the application is behaving. Observability serves the following goals:

- Provide holistic view of the _application health_.
- Help measure _business performance_ for the customer.
- Measure _operational performance_ of the system.
- Identify and _diagnose failures_ to get to the problem fast.

## Pillars of Observability

- [Logs](pillars/logging.md)
- [Metrics](pillars/metrics.md)
- [Tracing](pillars/tracing.md)
- [Logs vs Metrics](log-vs-metric.md)
- [Profiling](pillars/profiling.md)

By following the sidecar pattern, made popular by service meshes, you can quickly and easily deploy a microservice architecture with the following pillars of observability built into your system for free. Check out the [Service Mesh](tools/readme.md#service-mesh) section for more info.

> Note: You do not need to deploy a service mesh, or even leverage Kubernetes to follow the sidecar pattern, although it does make the setup much easier.

Lastly, although not considered a pillar of observability, we recommend checking out [profiling](profiling.md) for gaining deeper insight into what your code is doing, and identifying potential leaks (memory, thread, etc), or performance bottlenecks.

## Observability in Machine Learning

Read on how Observability can be implemented in [Machine Learning](ml-observability.md) engagements effectively during Model tuning, experimentation and deployment.

## Observability As Code

As much as possible, configuration and management of observability assets such as cloud resource provisioning, monitoring alerts and dashboards must be managed as code. Observability as Code is achieved using any one of Terraform / Ansible / ARM Templates

### Examples of Observability as Code

1. Dashboards as Code - Monitoring Dashboards can be created as JSON or XML templates. This template is source control maintained and any changes to the dashboards can be reviewed. Automation can be built for enabling the dashboard. [More about how to do this in Azure](https://docs.microsoft.com/en-us/azure/azure-portal/azure-portal-dashboards-create-programmatically). Grafana dashboard can also be [configured as code](https://grafana.com/blog/2020/02/26/how-to-configure-grafana-as-code/) which eventually can be source controlled to be used in automation and pipelines.

2. Alerts as Code - Alerts can be created within Azure by using Terraform or ARM templates. Such alerts can be source controlled and be deployed as part of pipelines (Azure DevOps pipelines, Jenkins, Github Actions etc.). Few references of how to do this are: [Terraform Monitor Metric Alert](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/monitor_metric_alert). Alerts can also be created based on log analytics query and can be defined as code using [Terraform Monitor Scheduled Query Rules Alert](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/monitor_scheduled_query_rules_alert#example-usage).

3. Automating Log Analytics Queries - There are several use cases where automation of log analytics queries may be needed. Example, Automatic Report Generation, Running custom queries programmatically for analysis, debugging etc. For these use cases to work, log queries should be source controlled and automation can be built using [log analytics REST](https://dev.loganalytics.io/documentation/Using-the-API) or [azure cli](https://docs.microsoft.com/en-us/cli/azure/ext/log-analytics/monitor/log-analytics?view=azure-cli-latest).

### Why

- It makes configuration repeatable and automatable. It also avoids manual configuration of monitoring alerts and dashboards from scratch across environments.

- Configured dashboards help troubleshoot errors during integration and deployment (CI/CD)

- We can audit changes and roll them back if there are any issues.

- Identify actionable insights from the generated metrics data across all environments, not just production.

- Configuration and management of observability assets like alert threshold, duration, configuration
values using IAC help us in avoiding configuration mistakes, errors or overlooks during deployment.

- When practicing observability as code, the changes can be reviewed by the team similar to other code
contributions.

## Observability of CI/CD Pipelines

With increasing complexity to delivery pipelines, it is very important
to consider Observability in the context of build and release of
applications.

### Benefits

- Having proper instrumentation during build time helps gain insights into the various stages of the build and release process.

- Helps developers understand where the pipeline performance bottlenecks are, based on the data collected. This
helps in having data-driven conversations around identifying latency between jobs, performance issues,
artifact upload/download times providing valuable insights into agents availability and capacity.

- Helps to identify trends in failures, thus allowing developers to quickly do root cause analysis.

- Helps to provide a organization-wide view of pipeline health to easily identify trends.

### Points to Consider

- It is important to identify the Key Performance Indicators (KPIs) for evaluating a successful CI/CD pipeline. Where needed, additional tracing can be added to better record KPI metrics. For example, adding pipeline build tags to identify a 'Release Candidate' vs. 'Non-Release Candidate' helps in evaluating the end-to-end release process timeline.

- Depending on the tooling used (Azure DevOps, Jenkins etc.,), basic reporting on the pipelines is
available out-of-the-box. It is important to evaluate these reports againt the KPIs to understand if
a custom reporting solution for their pipelines is needed. If required, custom dashboards can be built using
third-party tools like Grafana or Power BI Dashboards.

## Recommended Practices

1. **Correlation Id**: Include unique identifier at the start of the interaction to tie down aggregated data from various system components and provide a holistic view. Read more guidelines about using [correlation id](correlation-id.md).
1. Ensure health of the services are **monitored** and provide insights into system's performance and behavior.
1. Ensure **dependent services** are monitored properly. Errors and exceptions in dependent services like Redis cache, Service bus, etc. should be logged and alerted. Also metrics related to dependent services should be captured and logged.

    - Additionally, failures in **dependent services** should be propoagated up each level of the stack by the healthcheck.

1. **Faults, crashes, and failures** are logged as discrete events. This helps engineers identify problem area(s) during failures.
1. Ensure logging configuration (eg: setting logging to "verbose") can be controlled without code changes.
1. Ensure that **metrics** around latency and duration are collected and can be aggregated.
1. Start small and add where there is customer impact. [Avoiding metric fatigue](pitfalls.md#metric-fatigue) is very crucial to collecting actionable data.
1. It is important that every data that is collected contains relevant and rich context.
1. Personally Identifiable Information or any other customer sensitive information should never be logged. Special attention should be paid to any local privacy data regulations and collected data must adhere to those. (ex: GPDR)

Read more [here](pitfalls.md) to understand what to watch out for while designing and building an observable system.

## Recipes

### Application Insights/ASP.NET

[Github Repo](https://github.com/Azure-Samples/application-insights-aspnet-sample-opentelemetry), [Article](https://devblogs.microsoft.com/aspnet/observability-asp-net-core-apps/).

### Example: Setup Azure Monitor dashboards and alerts with Terraform

[Github Repo](https://github.com/buzzfrog/azure-alert-dashboard-terraform)

### On-premises Application Insights
>>>>>>> 9508d5f... add section on profiling

## Insights

- [Dashboards and Reporting](pillars/dashboard.md)

## Tools, Patterns and Recommended Practices

- [Tooling and Patterns](tools/readme.md)
- [Observability As Code](observability-as-code.md)
- [Recommended Practices](best-practices.md)

## Facets of Observability

- [Observability in Machine Learning](ml-observability.md)
- [Observability of CI/CD Pipelines](observability-pipelines.md)
- [Recipes](recipes-observability.md)
