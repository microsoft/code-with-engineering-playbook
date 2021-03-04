# Dashboard

## Overview

Dashboard is a form of data visualization that provides "at a glance" view of Key Performance Indicators(KPIs) of observable system. Dashboard connects multiple data sources allowing creation of visual representation of data insights which otherwise are difficult to understand. Dashboard can be used to:

- show trends
- identify patterns(user, usage, search etc)
- measure efficiency easily
- identify data outliers and correlations
- view health state or performance of the system
- give an outlook of the KPI that is important to a business/proces

## Best Practices

Common questions to ask youself when building dashboard would be:

- Where did my user spend most of their time at?
- What is my user searching?
- How do I better help my team with alerts and troubleshooting?
- Is my system healthy for the past one day/week/month/quarter?

Here are principles to consider to build a better dashboards:

1. Separate a dashboard in multiple sections for simplicity. Adding page jump or anchor(#section) is also a plus if applicable.
2. Add multiple and simple charts. Build simple chart, have more of them rather than a complicated all in one chart.
3. Identify goals or KPI measurement. Identifying goals or KPI helps in defining what needs to be achieved. Here are some examples - server downtime, mean time to address error, service level agreement.
4. Ask questions that can help reach the defined goal or KPI. This may sound counter intuitive, the more questions asked while constructing dashboard the better the outcome will be. Questions like location, internet service provider, time of day the users make requests to server would be a good start.
5. Validate the questions. This is often done with stakeholders, sponsors, leads or project managers.
6. Observe the dashboard that is built. Is the data reflecting what the stakeholders set out to answer?
7. Always remember this process takes time. Building dashboard is easy, building an observable dashboard to show pattern is hard.

## Recommended Tools

- [Azure Monitor Workbooks](https://docs.microsoft.com/en-us/azure/azure-monitor/platform/workbooks-overview) - Supporting markdown, Azure Workbooks is tightly integrated with Azure services making this highly customizable without extra tool.
- [Create dashboard using log query](https://docs.microsoft.com/en-us/azure/azure-monitor/learn/tutorial-logs-dashboards) - Dashboard can be created using log query on Log Analytics data.
- [Building dashboards using Application Insights](https://docs.microsoft.com/en-us/azure/azure-monitor/learn/tutorial-app-dashboards) - Dashboards can be created using Application Insights as well.
- [Power Bi](https://docs.microsoft.com/en-us/power-bi/create-reports/service-dashboard-create) - Power Bi is one of the easier tools to create dashboards from data sources and reports.
- [Grafana](https://grafana.com/tutorials/) - Getting started with Grafana. Grafana is a popular open source tool for dashboarding and visualization.
- [Azure Monitor as Grafana data source](https://grafana.com/grafana/plugins/grafana-azure-monitor-datasource) - This provides a step by step integration of Azure Monitor to Grafana.
- [Brief comparison of various tools](https://docs.microsoft.com/en-us/azure/azure-monitor/visualizations)

## Dashboard Samples and Recipes

### Azure Workbooks:

- Performance analysis - A measurement on how the system performs. Workbook template available in gallery.
- Failure analysis - A report about system failure with details. Workbook template available in gallery.
- Application Performance Index([Appdex](https://en.wikipedia.org/wiki/Apdex)) - This is a way to measure user satisfaction. It classifies performance into three zones based on a baseline performance threshold T. The template for Appdex is available in Azure Workbooks gallery as well.

### Application Insights:

- [User retention analysis](https://docs.microsoft.com/en-us/azure/azure-monitor/app/usage-retention)
- [User navigation patterns analysis](https://docs.microsoft.com/en-us/azure/azure-monitor/app/usage-flows)
- [User session analysis](https://docs.microsoft.com/en-us/azure/azure-monitor/learn/tutorial-users)

For other tools, these can be used as a reference to recreate if a template is not readily available.

## Summary

In order to build an observable dashboard, the goal is to make use of collected metrics, logs, traces to give an insight on how the system performs, user behaves and identify patterns. There are a lot of tools and templates out there. Whichever the choice is, a good dashboard is always a dashboad that can help you answer questions about the system and user, keep track of the KPI and goal while also allowing informed business decisions to be made.
