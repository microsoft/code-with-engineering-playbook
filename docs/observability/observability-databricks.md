# Observability for Azure Databricks

## Overview

Azure Databricks is an Apache Spark–based analytics service that makes it easy to rapidly develop and deploy big data analytics. Monitoring and troubleshooting performance issues is critical when
operating production Azure Databricks workloads. It is important to log adequate information from Azure Databricks so that it is helpful to monitor and troubleshoot performance issues.

Spark is designed to run on a cluster - a cluster is a set of Virtual Machines (VMs). Spark can horizontally scale with bigger workloads needed more VMs. Azure Databricks can scale in and out as
needed.

## Approaches to Observability

### Azure Diagnostic Logs

[Azure Diagnostic Logging](https://learn.microsoft.com/en-us/azure/databricks/administration-guide/account-settings/azure-diagnostic-logs) is provided out-of-the-box by Azure Databricks, providing
visibility into actions performed against DBFS, Clusters, Accounts, Jobs, Notebooks, SSH, Workspace, Secrets, SQL Permissions, and Instance Pools.

These logs are enabled using Azure Portal or CLI and can be configured to be delivered to one of these Azure resources.

- Log Analytics Workspace
- Blob Storage
- Event Hub

### Cluster Event Logs

[Cluster Event logs](https://learn.microsoft.com/en-us/azure/databricks/clusters/configure#cluster-log-delivery) provide a quick overview into important Cluster lifecycle events. The
log are structured - Timestamp, Event Type and Details. Unfortunately, there is no native way to export logs to Log Analytics. Logs will have to be delivered to Log Analytics either using [REST API](https://learn.microsoft.com/en-us/azure/databricks/dev-tools/api/latest/examples#cluster-log-example) or polled in the dbfs using Azure Functions.

### VM Performance Metrics (OMS)

[Log Analytics Agent](https://learn.microsoft.com/en-us/azure/virtual-machines/extensions/oms-linux) provides insights into the performance counters from the Cluster VMs and helps to understand the
Cluster Utilization patters. Leveraging Linux OMX Agent to onboard VMs into Log Analytics, helps provide insights into the VM metrics, performance, inventory and syslog metrics. It is important to
note that Linux OMS Agent is not specific to Azure Databricks.

### Application Logging

Of all the logs collected, this is perhaps the most important one. [Spark Monitoring library](https://github.com/mspnp/spark-monitoring) collects metrics about the driver, executors, JVM, HDFS, cache
shuffling, DAGs, and much more. This library provides helpful insights to fine-tune Spark jobs. It allows monitoring and tracing each layer within Spark workloads, including performance and resource
usage on the host and JVM, as well as Spark metrics and application-level logging. The library also includes ready-made Grafana dashboards that is a great starting point for building Azure Databricks
dashboard.

### Logs via REST API

Azure Databricks also provides [REST API](https://learn.microsoft.com/en-us/azure/databricks/dev-tools/api/latest/) support. If there's any specific log data that is required, this data can be collected using the REST API calls.

### NSG Flow Logs

[Network security group (NSG) flow logs](https://learn.microsoft.com/en-us/azure/network-watcher/network-watcher-nsg-flow-logging-overview) is a feature of Azure Network Watcher that allows you to log
information about IP traffic flowing through an NSG. Flow data is sent to Azure Storage accounts from where you can access it as well as export it to any visualization tool, SIEM, or IDS of your choice.
This log information is not specific to NSG Flow logs. This data can be used to identify unknown or undesired traffic and monitor traffic levels and/or bandwidth consumption. This is possible only with
VNET-injected workspaces.

### Platform Logs

Platform logs can be used to review provisioning/de-provisioning operations. This can be used to review activity in Databricks managed resource group. It helps discover operations performed at
subscription level (like provisioning of VM, Disk etc.)

These logs can be enabled via Azure Monitor > Activity Logs and shipped to Log Analytics.

### Ganglia Metrics

Ganglia metrics is a Cluster Utilization UI and is available on the Azure Databricks. It is great for viewing live metrics of interactive clusters. Ganglia metrics is available by default and takes
snapshot of usage every 15 minutes. Historical metrics are stored as .png files, making it impossible to analyze data.
