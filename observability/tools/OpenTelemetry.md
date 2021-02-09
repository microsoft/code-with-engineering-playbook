# Open Telemetry

OpenTelemetry is a set of APIs, SDKs and instrumentation which can be used for collection, processing and orchestrating telemetry data like traces metrics and logs. It supports multiple languages(Java, .NET, Python, JavaScript, Golang, Erlang etc.). Open telemetry follows a vendor agnostic and standards based approach for collection and management of telemetry data. Important point to note is that OpenTelemetry does not have its own backend, all telemetry collected by OpenTelemetry Collector must be sent to a backend like Prometheus etc. Open telemetry is also the 2nd most active CNCF project after Kubernetes.

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
Good causes to use OpenTelemetry would include if the stack is using OpenCensus or OpenTracing. As OpenCensus and OpenTracing have carved way for OpenTelemetry, it makes sense to introduce OpenTelemetry where OpenCensus or OpenTracing is getting used as it still has backward compatibility.
Apart from features like adding custom attributes, sampling, collecting data for metrics and traces, OpenTelemetry is governed by specifications and backed up big players in Observability landscape like Microsoft, Splunk, AppDynamics etc. It is likely that OpenTelemetry will become a de-facto open source standard for enabling metrics and tracing when all fatures become GA.

## Current Status of OpenTelemetry Project

OpenTelemetry is a project which emerged from merging of OpenCensus and OpenTracing in 2019. Although OpenCensus and OpenTracing are frozen and no new features are being developed for them, OpenTelemetry has backward compatibility with OpenCensus and OpenTracing. Some features of OpenTelemetry are still in beta, feature support for different languages is being tracked here: [Feature Status of OpenTelemetry](https://github.com/open-telemetry/opentelemetry-specification/blob/main/spec-compliance-matrix.md). Status of OpenTelemetry project can be tracked [here](https://opentelemetry.io/project-status/).

## What to watch out for

As OpenTelemetry is a very recent project (first GA version of some features released in 2020), many features are still in beta hence due deligence needs to be done before using such features in production. Also, OpenTelemetry supports many popular languages but features in all languages are not at par. Some languages offer more features as compared to other languages. It also needs to be called out as some of the features are not in GA, there may be some incompatibility issues with the tooling. That being said, OpenTelemetry is one of the most active projects of CNCF so it is expected that many more features would reach GA soon.

## References

- [OpenTelemetry Official Site](https://opentelemetry.io/)
- [Getting Started with dotnet and OpenTelemetry](https://opentelemetry.io/docs/net/getting-started/)
- [Using OpenTelemetry Collector](https://opentelemetry.io/docs/collector/getting-started/)
