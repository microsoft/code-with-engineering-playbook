# Open Telemetry

Open Telemetry is a set of APIs, SDKs and instrumentation which can be used for collection, processing and orchestration of telemetry data like traces metrics and logs. It supports multiple languages(Java, dotnet, python, javascript, golang, erlang etc.). Open telemetry follows a vendor agnostic and standards based approach for collection and management of telemetry data. Important point to note is that OpenTelemetry does not have its own backend, all telemetry collected by OpenTelemetry Collector must be sent to a backend like Prometheus etc. Open telemetry is also the 2nd most active CNCF project after Kubernetes.

## Collector

OpenTelemetry Collector performs telemetry collection, processing and export. It is mostly run as an agent or a sidecar with the application or as a daemon if installed directly on host. As the collector is standards based and supports many integrations, there is a possibility that many tool specific agents for metric, traces and logs can be replaced by a single OpenTelemetry collector.
The collector can also be installed as standalone service to receive telemetry data from multiple applications.

## Instrumentation Libraries

A library that enables observability for another library is called an instrumentation library. OpenTelemetry libraries are language specific, currently there is good support for Java, Python, Javascript, dotnet and golang. Support for automatic instrumentation is available for some libraries which make using OpenTelemetry easy and trivial. In case automatic instrumentation is not available, manual instrumentation can be configured by using the OpenTelemetry SDK.

## Integration of OpenTelemetry

OpenTelemetry can be used to collect, process and export data into multiple backends, some popular integrations supported with OpenTelemetry are:

1. Zipkin
2. Prometheus.
3. Jaeger
4. New Relic.
5. Azure Monitor

## Why use OpenTelemetry

The main reason to use OpenTelemetry is that it offers tracing, metrics and logging telemetry through a single agent which supports multiple integrations. Seperate agents for tracing, logging and metrics will not be needed to be setup if OpenTelemetry is used.

## References

- [OpenTelemetry Official Site](https://opentelemetry.io/)
- [Getting Started with dotnet and OpenTelemetry](https://opentelemetry.io/docs/net/getting-started/)
- [Using OpenTelemetry Collector](https://opentelemetry.io/docs/collector/getting-started/)
