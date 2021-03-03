# Loki

Loki is a horizontally-scalable, highly-available, multi-tenant log aggregation system, created by Grafana
Labs inspired by the learnings from Prometheus. Loki is commonly referred as 'Prometheus, but for logs', which
makes total sense. Both tools follow the same architecture, which is an agent collecting metrics in each
of the components of the software system, a server which stores the logs and also the Grafana dashboard, which
access the loki server to build its visualizations and queries. That being said, Loki has three main
components:

## Promtail

It is the agent portion of Loki. It can be used to grab logs from several different places, like var/log/ for
example. The configuration of the Promtail is a yaml file called ```config-promtail.yml```. In this file, its described all the paths and log sources that will be
aggregated on Loki Server.

## Loki Server

Loki Server is responsible for receiving and storing all the logs received from all the different systems. The Loki Server is also
responsible for the queries done on Grafana, for example.

## Grafana Dashboards

Grafana Dashboards are responsible for creating the visualizations and performing queries. After all, it will
be a web page that people with the right access can log into to see, query and create alerts for the aggregated
logs.

## Why use Loki

The main reason to use Loki instead of other log aggregation tools, is that Loki optimizes the necessary
storage. It does that by following the same pattern as prometheus, which index the labels and make chunks
of the log itself, using less space than just storing the raw logs.

## References

- [Loki Official Site](https://grafana.com/oss/loki/)
- [Inserting logs into Loki](https://grafana.com/docs/loki/latest/getting-started/get-logs-into-loki/)
- [Adding Loki Source to Grafana](https://grafana.com/docs/grafana/latest/datasources/loki/#adding-the-data-source)
- [Comparing Loki to other log systems](https://grafana.com/docs/loki/latest/overview/comparisons/)
