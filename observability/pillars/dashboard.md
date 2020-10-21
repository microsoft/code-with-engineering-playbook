# Dashboard and Visualization

## Overview

Dashboard provides "at glance" view of Key Performance Index(KPI) in accrodance with goals and objectives of business processes. Typically this includes metrices and key data points to monitor the health of a business, department or specific process. Dashboard usually connects to one or multiple data sources allowing the creation of visual representation of data. This is important in observability as a good dashboard will be able to 

- show trends
- identify patterns(user, usage, search etc)
- measure efficiency easily
- identify data outliers and correlations
- view health state or performance of the system
- give an outlook of the KPIs that is important to a business/process

which otherwise is difficult to understand and consume relating back to business goal or KPI measure. Common questions to ask while building dashboard would be:
- Where did my user spend most of their time at?
- What is my user searching?
- How do I better help my team with alerts and troubleshooting?
- Is my system healthy for the past one day/week/month/quarter?

## Best Practices

1. Identify goals or KPI measurement. Identifying goals or KPI helps in defining what needs to be achieved.
2. Ask questions that can help reach the defined goal or KPI. This may sound counter intuitive, the more questions asked while constructing dashboard the better the outcome will be.
3. Validate the questions. This is often done with stakeholders, sponsors, leads or even project managers.
4. Build simple chart, have more of them. Rather than having a complicated all in one dashboard, seperate the dashboard into sections. Azure Workbooks is highly recommended with markdown support.
5. Observe the dashboard that is built. Is the data reflecting what the stakeholders set out to answer? If not, make small adjustments.

Always remember this process takes time. Building dashboard is easy, building an observable dashboard to show pattern is hard.

## Recommended Tools

- [Azure Monitor Workbooks](https://docs.microsoft.com/en-us/azure/azure-monitor/platform/workbooks-overview) - With Azure workbook, creating a unified interactive experience is easier. This has tight integration with Azure services making this higly customizable without extra tool.
- [Create dashboard using log query](https://docs.microsoft.com/en-us/azure/azure-monitor/learn/tutorial-logs-dashboards) - Dashboard can be created using log query on Log Analytics data.
- [Building dashboards using Application Insights](https://docs.microsoft.com/en-us/azure/azure-monitor/learn/tutorial-app-dashboards) - Dashboards can be created using Application Insights as well.
- [Power Bi](https://docs.microsoft.com/en-us/power-bi/create-reports/service-dashboard-create) - Power Bi is one of the easier tools to create dashboards from data sources and reports.
- [Grafana](https://grafana.com/tutorials/) - Getting started with Grafana. Grafana is a popular open source tool for dashboarding and visualization.
- [Azure Monitor as Grafana data source](https://grafana.com/grafana/plugins/grafana-azure-monitor-datasource) - This provides a step by step integration of Azure Monitor to Grafana. 

There are many options available for visualization and dashboarding. Depending on the needs, requirements and implementation, visualization tool used might vary but the overall concept on observability would be more or less the same.

[Brief comparison of various tools](https://docs.microsoft.com/en-us/azure/azure-monitor/visualizations) 

Notes:
1. Some useful observability features available on Azure Workbooks to leverage on:
- Performance analysis - A measurement on how the system performs. Workbook template available in gallery.
- Failure analysis - A report about system failure with details. Workbook template available in gallery.
- Application Performance Index([Appdex](https://en.wikipedia.org/wiki/Apdex)) - This is a way to measure user satisfaction. It classifies performance into three zones based on a baseline performance threshold T. The template for Appdex is available in Azure Workbooks gallery as well. 

2. Application Insights has various ready to go analysis on observability on a system as well.
- [User retention analysis](https://docs.microsoft.com/en-us/azure/azure-monitor/app/usage-retention)
- [User navigation patterns analysis](https://docs.microsoft.com/en-us/azure/azure-monitor/app/usage-flows)
- [User session analysis](https://docs.microsoft.com/en-us/azure/azure-monitor/learn/tutorial-users)

For other tools, these can be used as a reference to recreate if a template is not readily available.

## Summary

In order to build an observable dashboard, the goal is to make use of collected metrics, logs, traces to give an insight on how the system performs, user behaves and identify patterns. There are a lot of tools and templates out there. Whichever the choice is, a good dashboard is always a dashboad that can help you answer questions about the system and user, keep track of the KPI and goal while also allowing informed business decisions to be made.