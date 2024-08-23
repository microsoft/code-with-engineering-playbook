# Observability as Code

As much as possible, configuration and management of observability assets such as cloud resource provisioning, monitoring alerts and dashboards must be managed as code. Observability as Code is achieved using any one of Terraform / Ansible / ARM Templates

## Examples of Observability as Code

1. Dashboards as Code - Monitoring Dashboards can be created as JSON or XML templates. This template is source control maintained and any changes to the dashboards can be reviewed. Automation can be built for enabling the dashboard. [More about how to do this in Azure](https://learn.microsoft.com/en-us/azure/azure-portal/azure-portal-dashboards-create-programmatically). Grafana dashboard can also be [configured as code](https://grafana.com/blog/2020/02/26/how-to-configure-grafana-as-code/) which eventually can be source-controlled to be used in automation and pipelines.
2. Alerts as Code - Alerts can be created within Azure by using Terraform or ARM templates. Such alerts can be source-controlled and be deployed as part of pipelines (Azure DevOps pipelines, Jenkins, GitHub Actions etc.). Few references of how to do this are: [Terraform Monitor Metric Alert](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/monitor_metric_alert). Alerts can also be created based on log analytics query and can be defined as code using [Terraform Monitor Scheduled Query Rules Alert](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/monitor_scheduled_query_rules_alert#example-usage).
3. Automating Log Analytics Queries - There are several use cases where automation of log analytics queries may be needed. Example, Automatic Report Generation, Running custom queries programmatically for analysis, debugging etc. For these use cases to work, log queries should be source-controlled and automation can be built using [log analytics REST](https://learn.microsoft.com/en-us/rest/api/loganalytics/) or [azure cli](https://learn.microsoft.com/en-us/cli/azure/ext/log-analytics/monitor/log-analytics?view=azure-cli-latest).

## Why

- It makes configuration repeatable and automatable. It also avoids manual configuration of monitoring alerts and dashboards from scratch across environments.
- Configured dashboards help troubleshoot errors during integration and deployment (CI/CD)
- We can audit changes and roll them back if there are any issues.
- Identify actionable insights from the generated metrics data across all environments, not just production.
- Configuration and management of observability assets like alert threshold, duration, configuration
values using IAC help us in avoiding configuration mistakes, errors or overlooks during deployment.
- When practicing observability as code, the changes can be reviewed by the team similar to other code
contributions.
