# Open Telemetry

Building observable systems enable one to measure how well the application is behaving. Adopting open-source standards related to implementing telemetry and tracing features built on top of the OpenTelemetry framework helps decouple vendor-specific implementations while maintaining an extensible, standard and portable open-source solution.

collectingOpenTelemetry is an observability open-source standard that defines the way to generate, collect and describe telemetry in distributed systems. OpenTelemetry also provides a single-point distribution of a set of APIs, SDKs and instrumentation libraries that implements the open-source standard which can be used for collecting, processing and orchestrating telemetry data (signals) like traces, metrics and logs. It supports multiple languages (Java, .NET, Python, JavaScript, Golang, Erlang etc.). Open telemetry follows a vendor agnostic and standards based approach for collection and management of telemetry data. Important point to note is that OpenTelemetry does not have its own backend, all telemetry collected by OpenTelemetry Collector must be sent to a backend like Prometheus, Jaeger, Zipkin, Azure Monitor, etc. Open telemetry is also the 2nd most active CNCF project after Kubernetes.

The main two Problems OpenTelemetry solves are: Vendor neutrality for tracing, monitoring and logging APIs and Cross platform Context propagation implementation.


## Open Telemetry Core Concepts
### Open Telemetry Implementation Patterns 

A detailed explanation of OpenTelemetry concepts is out of the scope of this repo. There is plenty of available information about how the SDK and the Agent are configured and how the Exporters, Tracers, Context, and Span's hierarchy works. See the Reference section for useful OpenTelemetry resources.

However, understanding the core implementation patterns will help you understand what approach better fits the scenario you are trying to solve. These are three main patterns as follows:

* Automatic telemetry: Support for automatic instrumentation is available for some languages. For those that is available, OpenTelemetry automated instrumentation (100% codeless) is implementing by running the OpenTelemetry Agent. The agent would be deployed with your service and run as a separate process or in a sidecar. The agent reads a set of predefined environment variables used to configure its behavior and various exporter/collector settings. The agent will intercept all interactions and dependencies and automatically sending the telemetry to the configured exporters. 

* Manual tracing: This must be done by actually coding using the OpenTelemetry SDK, managing the `tracer` objects to obtain Spans, and forming instrumented OpenTelemetry Scopes to identify the code segments to be traced manually.  Also, by using the @WithSpan annotations. 

* Hybrid approach: Most Production-ready scenarios will require a mix of both techniques, using the OpenTelemetry Java Agent to collect automatic telemetry and the OpenTelemetry SDK to identify code segments that are important to instrument manually. When considering production-ready scenarios, the hybrid approach is the way to go as it allows for a throughout cover over the whole solution. It means the OpenTelemetry Java Agent is implemented for automatic tracing, combined with the OpenTelemetry SDK for manual instrumentation. Automatic context propagation and events correlation is provided out of the box. 

### Collector

The Collector is a separate process that is designed to be a ‘sink’ for telemetry data emitted by many processes, which can then export that data to backend systems. The Collector has two different deployment strategies – either running as an agent alongside a service, or as a remote application. In general, using both is recommended: the agent would be deployed with your service and run as a separate process or in a sidecar; meanwhile, the collector would be deployed separately, as its own application running in a container or virtual machine. Each agent would forward telemetry data to the collector, which could then export it to a variety of backend systems such as Lightstep, Jaeger, or Prometheus.

Regardless of how you choose to instrument or deploy OpenTelemetry, exporters provide powerful options for reporting telemetry data. You can directly export from your service, you can proxy through the collector, or you can aggregate into standalone collectors – or even a mix of these.

### Instrumentation Libraries

A library that enables observability for another library is called an instrumentation library. OpenTelemetry libraries are language specific, currently there is good support for Java, Python, Javascript, dotnet and golang. Support for automatic instrumentation is available for some libraries which make using OpenTelemetry easy and trivial. In case automatic instrumentation is not available, manual instrumentation can be configured by using the OpenTelemetry SDK.

## Integration of OpenTelemetry

OpenTelemetry can be used to collect, process and export data into multiple backends, some popular integrations supported with OpenTelemetry are:

1. Zipkin
2. Prometheus
3. Jaeger
4. New Relic
5. Azure Monitor
6. AWS X-Ray
7. Datadog
8. Kafka
9. Lightstep
10. Splunk
11. GCP Monitor

## Why use OpenTelemetry

The main reason to use OpenTelemetry is that it offers an open-source standard for implementing distributed telemetry (context propagation) over heterogeneous systems. There is no need to reinvent the wheel to implement end-to-end business flow transactions monitoring when using OpenTelemetry.
It enables tracing, metrics and logging telemetry through a set of single-distribution multi-language libraries, and a set of tools that allows for a plug and play telemetry architecture that includes the concept of agents and collectors.

Moreover, avoiding any type of propetary lockdown and achiving vendor neutrality for tracing, monitoring and logging APIs AND backends allows for a maximum portability and extensibility patterns.

Another good reason to use OpenTelemetry would include if the stack is using OpenCensus or OpenTracing. As OpenCensus and OpenTracing have carved way for OpenTelemetry, it makes sense to introduce OpenTelemetry where OpenCensus or OpenTracing is getting used as it still has backward compatibility.

Apart from features like adding custom attributes, sampling, collecting data for metrics and traces, OpenTelemetry is governed by specifications and backed up big players in Observability landscape like Microsoft, Splunk, AppDynamics etc. It is likely that OpenTelemetry will become a de-facto open source standard for enabling metrics and tracing when all features become GA.

## Current Status of OpenTelemetry Project

OpenTelemetry is a project which emerged from merging of OpenCensus and OpenTracing in 2019. Although OpenCensus and OpenTracing are frozen and no new features are being developed for them, OpenTelemetry has backward compatibility with OpenCensus and OpenTracing. Some features of OpenTelemetry are still in beta, feature support for different languages is being tracked here: [Feature Status of OpenTelemetry](https://github.com/open-telemetry/opentelemetry-specification/blob/main/spec-compliance-matrix.md). Status of OpenTelemetry project can be tracked [here](https://opentelemetry.io/status/).

From the website: 

> Our goal is to provide a generally available, production quality release for the tracing data source across most OpenTelemetry components in the first half of 2021. Several components have already reached this milestone! We expect metrics to reach the same status in the second half of 2021 and are targeting logs in 2022.

## What to watch out for

As OpenTelemetry is a very recent project (first GA version of some features released in 2020), many features are still in beta hence due diligence needs to be done before using such features in production. Also, OpenTelemetry supports many popular languages but features in all languages are not at par. Some languages offer more features as compared to other languages. It also needs to be called out as some features are not in GA, there may be some incompatibility issues with the tooling. That being said, OpenTelemetry is one of the most active projects of CNCF, so it is expected that many more features would reach GA soon.



### Hybrid Instrumentation




## Integration Options with Azure Monitor

There are two possible approaches when integrating OpenTelemetry with Azure Monitor as an OpenTemetry exporter.
### Using the Azure Monitor OpenTelemetry Exporter  Library
  
  This scenario uses the OpenTelemetry Java SDK as the core telemetry library. The Azure Monitor OpenTelemetry Exporter is instantiated manually in an imperative way and then added as an additional exporter with the OpenTelemetry SDK. The `OtelConfiguration` class, within the workers-core library, configures and registers the `AzureMonitorTraceExporter` when the solution is running under the OpenTelemetry mode:

> There is no need to use any Open Telemetry specific configuration when running under the Application Insights agent mode.


### Using the Application Insights Java Agent Jar file

When configuring this option, the Applications Insights Java Agent Jar file is added with the `-javaagent` option when executing the application. The `applicationinsights.json` configuration file must be also be added as part of the applications artifacts. Pay close attention to the preview section, where the `"openTelemetryApiSupport": true,` property is set to true, enabling the agent to intercept OpenTelemetry telemetry created in the application code pushing it to Azure Monitor.

The main difference between running the OpenTelemetry agent vs. the Application Insights agent is demonstrated in the amount of traces getting logged in Azure Monitor. When running in the OpenTelemetry mode, **only the manual traces are getting pushed to Azure Monitor**. No other automatic traces are sent from the java application or the Application Insights agent. On the other hand, when running the solution using the Application Insights agent mode, it is essential to highlight that nothing gets logged on Jaeger (or any other OpenTelemetry exporter). All traces will be pushed exclusively to Azure Monitor. However, both manual instrumentation done via the OpenTelemetry  SDK and all automatic traces, dependencies, performance counters, and metrics being instrumented by the Application Insights Java agent are sent to Azure Monitor. Although there is a rich amount of additional data automatically instrumented by the Application Insights agent, it can be deduced that it is not necessarily OpenTelemetry compliant. Only the traces logged by the manual instrumentation using the OpenTelemetry SDK are.

## OtelTelemetry vs Application Insights agents compared

|Highlight | OtelTelemetry Agent | App Insights Agent |
|------|-------------|------|
| Automatic Telemetry| Y | Y |
| Manual OpenTelemetry| Y | Y |
| Plug and Play Exportes| Y | N |
| Multiple Exportes| Y | N |
| Full Open Telemetry layout (decoupling agents, collectors and exporters)| Y | N |
| Enriched out of the box telemetry | N | Y |
| Unified telemetry backend | N | Y |

# Summary

As you may have guessed, there is no "one size fits all" approach when implementing OpenTelemetry with Azure Monitor as a backend. At the time of this writing, if you want to have the flexibility of having different OpenTelemetry backends, you should definitively go with the OpenTelemetry Agent, even though you'd sacrifice all automating tracing flowing to Azure Monitor.
On the other hand, if you want to get the best of Azure Monitor and still want to instrument your code with the OpenTelemetry SDK, you should use the Application Insights  Agent and manually instrument your code with the OpenTelemetry SDK to get the best of both worlds. 
Either way, instrumenting your code with OpenTelemetry seems the right approach as the ecosystem will only get bigger, better, and more robust.

# Advanced topics
Use the [Azure OpenTelemetry Tracing plugin library for Java](https://github.com/Azure/azure-sdk-for-java/tree/main/sdk/core/azure-core-tracing-opentelemetry) to enable distributed tracing across Azure components through OpenTelemetry. 
# References
- [OpenTelemetry Official Site](https://opentelemetry.io/)
- [Getting Started with dotnet and OpenTelemetry](https://opentelemetry.io/docs/net/getting-started/)
- [Using OpenTelemetry Collector](https://opentelemetry.io/docs/collector/getting-started/)

* [OpenTelemetry Java SDK](https://github.com/open-telemetry/opentelemetry-java)

* [Manual Instrumentation](https://github.com/open-telemetry/opentelemetry-java-instrumentation/blob/main/docs/manual-instrumentation.md)

* [OpenTelemetry Instrumentation Agent for Java](https://github.com/open-telemetry/opentelemetry-java-instrumentation)

* [Application Insights Java Agent](https://docs.microsoft.com/en-us/azure/azure-monitor/app/java-in-process-agent)

* [Azure Monitor OpenTelemetry Exporter client library for Java](https://github.com/Azure/azure-sdk-for-java/tree/3f31d68eed6fbe11516ca3afe3955c8840a6e974/sdk/monitor/azure-monitor-opentelemetry-exporter)

* [Azure OpenTelemetry Tracing plugin library for Java](https://github.com/Azure/azure-sdk-for-java/tree/main/sdk/core/azure-core-tracing-opentelemetry)

* [Application Insights Agent's OpenTelemetry configuration](https://github.com/microsoft/ApplicationInsights-Java/wiki/OpenTelemetry-API-support-(3.0))
