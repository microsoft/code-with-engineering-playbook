# Prometheus

## Overview

Originally built at SoundCloud, [Prometheus](https://prometheus.io/docs/introduction/overview/) is an open-source monitoring and alerting toolkit based on time series metrics data. It has become a de facto standard metrics solution in the cloud Native world and widely used with Kubernetes. 

The core of Prometheus is a server that scrapes and stores metrics. There are other numerous optional features and components like an Alert-manager and [client libraries](https://prometheus.io/docs/instrumenting/clientlibs/) for programming languages to extend the functionalities of Prometheus beyond the basics. 
The client libraries offer four [metric types](https://prometheus.io/docs/concepts/metric_types/): `Counter`, `Gauge`, `Histogram`, and `Summary`.

## Why Prometheus?

- Prometheus is a time series database and allow for events or measurements to be tracked, monitored, and aggregated over time. 
- Prometheus is a pull based tool. One of the biggest advantages of Prometheus vs other monitoring tools is that Prometheus actively scrapes targets in order to retrieve metrics from them.
- Prometheus allows for control over who to scrape, and how often to scrape them. Through the Prometheus server, there can be multiple scrape configurations, allowing for multiple rates for different targets.
- Similar to Grafana, visualization fo the time series can be directly done through the Prometheus Web UI. The Web UI provides the ability to easily filter and have an overview of what is taking place with your different targets.
- Prometheus provides a powerful functional query language called PromQL (Prometheus Query Language) that lets the user aggregate time series data in real time.

## Integration with Other Tools
The Prometheus client libraries allows you to add instrumentation to your code and expose internal metrics via an HTTP endpoint. The official [Prometheus client libraries](https://prometheus.io/docs/instrumenting/clientlibs/) currently are `Go`, `Java or Scala`, `Python` and `Ruby`. Unofficial third-party libraries include: `.NET/C#`, `Node.js`, and `C++`.

Prometheus metrics format is supported by a wide array of metric tools and services including: 
- [Azure Monitor](https://docs.microsoft.com/en-us/azure/azure-monitor/containers/container-insights-prometheus-integration)
- [Stackdriver](https://cloud.google.com/stackdriver/docs/solutions/gke/prometheus) 
- [Datadog](https://docs.datadoghq.com/integrations/prometheus/) 
- [CloudWatch](https://aws.amazon.com/blogs/containers/using-prometheus-metrics-in-amazon-cloudwatch/)
- [New Relic](https://docs.newrelic.com/docs/integrations/prometheus-integrations/get-started/send-prometheus-metric-data-new-relic/)

There are numerous [exporters](https://prometheus.io/docs/instrumenting/exporters/) which are used in exporting existing metrics from third-party databases, hardware, CI/CD tools, messaging systems, APIs and other monitoring systems. In addition to client libraries and exporters, there is a significant number of [integration points](https://prometheus.io/docs/operating/integrations/) for service discovery, remote storage, alerts and management. 
## References

- [Prometheus Docs](https://prometheus.io/docs)
- [Prometheus Best Practices](https://prometheus.io/docs/practices)
- [Grafana with Prometheus](https://prometheus.io/docs/visualization/grafana/)