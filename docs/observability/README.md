# Observability

Building observable systems enables development teams at ISE to measure how well the application is behaving. Observability serves the following goals:

- Provide holistic view of the _application health_.
- Help measure _business performance_ for the customer.
- Measure _operational performance_ of the system.
- Identify and _diagnose failures_ to get to the problem fast.

## Pillars of Observability

- [Logs](./pillars/logging.md)
- [Metrics](./pillars/metrics.md)
- [Tracing](./pillars/tracing.md)
- [Logs vs Metrics vs Traces](./log-vs-metric-vs-trace.md)

## Insights

- [Dashboards and Reporting](./pillars/dashboard.md)

## Tools, Patterns and Recommended Practices

- [Tooling and Patterns](./tools/README.md)
- [Observability As Code](./observability-as-code.md)
- [Recommended Practices](./best-practices.md)
- [Diagnostics tools](./diagnostic-tools.md)
- [OpenTelemetry](./tools/OpenTelemetry.md)

## Facets of Observability

- [Observability for Microservices](./microservices.md)
- [Observability in Machine Learning](./ml-observability.md)
- [Observability of CI/CD Pipelines](./observability-pipelines.md)
- [Observability in Azure Databricks](./observability-databricks.md)
- [Recipes](./recipes-observability.md)

## AI observability

AI-enabled systems need telemetry that helps teams debug behavior, detect drift, and control cost while respecting project privacy and retention rules.

- Capture request context: model, provider, and version; prompt template version; retrieval source IDs; and tool calls.
- Capture operational signals: latency, token or cost signals, error rates, and fallback paths.
- Capture safety signals: refusal rates, safety outcomes, and escalation rates.
- Use traces to follow multi-step agent decisions and tool invocations.
- Apply project data classification and retention rules before logging prompts, completions, documents, embeddings, or user conversations.
- Run scheduled quality and safety evaluations to detect behavior drift.
- Alert when safety, quality, latency, cost, or fallback metrics cross agreed thresholds.

Use the [AI-Assisted Engineering](../ai-assisted-engineering/README.md) guide for shared observability and privacy considerations.

## Resources

- [Non-Functional Requirements Guidance](../design/design-patterns/non-functional-requirements-capture-guide.md)
