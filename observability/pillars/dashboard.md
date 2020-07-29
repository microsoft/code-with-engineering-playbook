# Dashboard and Visualization

## Overview

TLDR - Dashboard to show patterns. What you want to achieve here is to derive a pattern - user, usage, search or anything that you have defined as your KPI.

## Best Practices

1. Identify your goal or KPI.
2. Ask yourself questions that can help you reach your goal or KPI. This may sound counter intuitive, the more questions you ask the better the outcome will be.
3. Validate your questions. Are these necessary in finding a common pattern?
4. Build simple chart, have more of them. Rather than having a complicated all in one dashboard, seperate your dashboard into sections. Azure Workbooks is highly recommended as it supports markdown.
5. Observe the dashboard that you built. Is the data reflecting what you are set out to answer? If not make small adjustment.

Always remember this process takes time. Building dashboard is easy, building an obserable dashboard to show pattern is hard.

## Recommended Tools

- [Azure Monitor](https://docs.microsoft.com/en-us/azure/azure-monitor/overview) - Umbrella of services including system metrics, log analytics and more.
- [Application Insights](https://docs.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview) - An extensible Application Performance Management (APM) service used to monitor live applications, and a feature of inside Azure Monitor.
- [Azure Log Analytics](https://docs.microsoft.com/en-us/azure/azure-monitor/log-query/log-query-overview) - Run advanced queries against the data collected via Azure Monitor Logs.
- [Azure Monitor Workbooks](https://docs.microsoft.com/en-us/azure/azure-monitor/platform/workbooks-overview) - Visualizations for your logged data, tightly interated with Azure services and higly customizable.

### Azure Monitor Workbooks

[Azure Monitor Workbooks](https://docs.microsoft.com/en-us/azure/azure-monitor/platform/workbooks-overview) provide a flexible canvas for data analysis and the creation of rich visual reports within the Azure portal. Workbooks allow you to tap into multiple data sources from across Azure, and combine them into a unified interactive experiences.

There are many options available for visualization and dashboarding and workbooks is one of them. Other tools include PowerBi, Azure Dashboard, Graphana[(brief comparison)](https://docs.microsoft.com/en-us/azure/azure-monitor/visualizations). Depending on your need and implementation, your visualization will vary but the concept on observability would be more or less the same.

Here are some useful observability feature available that you may want to leverage on:

Performance analysis - A measurement on how the system performs. Workbook template available in gallery.

Failure analysis - A report about system failure with details. Workbook template available in gallery.

Application Performance Index([Appdex](https://en.wikipedia.org/wiki/Apdex)) - a way to measure user satisfaction. It classifies performance into three zones based on a baseline performance threshold T. Workbook template available in gallery.

You may mix and match by extracting checking how the template on workbooks query log analytics and replicate in your own custom dashboard.

### Application Insights Visualization

Application Insights has various ready to go analysis on observability of the system. These includes but not limited to:-

User retention analysis
<https://docs.microsoft.com/en-us/azure/azure-monitor/app/usage-retention>

User navigation patterns analysis
<https://docs.microsoft.com/en-us/azure/azure-monitor/app/usage-flows>

User session analysis
<https://docs.microsoft.com/en-us/azure/azure-monitor/learn/tutorial-users>

Generally to build an observable dashboard, your goal is to make use of collected metrics, logs, traces to give an insight on how the system performs, user behaves and identify patterns. While the provided Azure Workbooks answer some of the questions, you may also want to consider additional things like:

1. Where did my user spend most of thier time at?
2. What is my user searching?
3. How do I better help my team with alerts and troubleshooting?
4. Is my system healthy for the past one day/week/month/quarter?
