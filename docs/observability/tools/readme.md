# Tools & Patterns

There are a number of modern tools to make systems observable. While identifying and/or creating tools that work for your system, here are a few things to consider to help guide the choices.

- Must be simple to integrate and easy to use.
- It must be possible to aggregate and visualize data.
- Tools must provide real-time data.
- Must be able to guide users to the problem area with suitable, adequate end-to-end context.

## Choices

- [Loki](./loki.md)
- [OpenTelemetry](./OpenTelemetry.md)
- [Kubernetes Dashboards](./KubernetesDashboards.md)
- [Prometheus](./Prometheus.md)

## Service Mesh

Leveraging a Service Mesh that follows the [Sidecar Pattern](https://www.oreilly.com/library/view/designing-distributed-systems/9781491983638/ch02.html#:~:text=The%20sidecar%20pattern%20is%20a,first%20is%20the%20application%20container.&text=In%20addition%20to%20the%20application,without%20the%20application%20container's%20knowledge.) quickly sets up a go-to set of metrics, and traces (although traces need to be propagated from incoming requests to outgoing requests manually).

A sidecar works by intercepting all incoming and outgoing traffic to your image. It then adds trace headers to each request and emits a standard set of logs and metrics. These metrics are extremely powerful for observability, allowing every service, whether client-side or server-side, to leverage a unified set of metrics, including:

- Latency
- Bytes
- Request Rate
- Error Rate

In a microservice architecture, pinpointing the root cause of a spike in 500's can be non-trivial, but with a the added observability from a sidecar you can quickly determine which service in your service mesh resulted in the spike in errors.

Service Mesh's have a large surface area for configurability, and can seem like a daunting undertaking to deploy. However, most services (including Linkerd) offer a sane set of defaults, and can be deployed via the happy path to quickly land these observability wins.
