# Recommended Practices

1. **Correlation Id**: Include unique identifier at the start of the interaction to tie down aggregated data from various system components and provide a holistic view. Read more guidelines about using [correlation id](./correlation-id.md).
1. Ensure health of the services are **monitored** and provide insights into system's performance and behavior.
1. Ensure **dependent services** are monitored properly. Errors and exceptions in dependent services like Redis cache, Service bus, etc. should be logged and alerted. Also, metrics related to dependent services should be captured and logged.

    - Additionally, failures in **dependent services** should be propagated up each level of the stack by the health check.

1. **Faults, crashes, and failures** are logged as discrete events. This helps engineers identify problem area(s) during failures.
1. Ensure logging configuration (eg: setting logging to "verbose") can be controlled without code changes.
1. Ensure that **metrics** around latency and duration are collected and can be aggregated.
1. For AI workloads, correlate the user request, prompt or template version, model deployment, retrieval configuration, tool-call spans, safety checks, token usage, cost, and user feedback under the same trace or correlation id. This helps teams explain why an answer or action occurred without depending on raw prompt or response logs.
1. Version prompts, model settings, grounding indexes, and tool schemas as observable production artifacts. Include those versions in logs, traces, dashboards, and incident records so teams can compare behavior before and after a release.
1. Capture tool-call traces for agentic systems with the requested tool, authorization context, approval state, side-effect status, retry count, and failure category. Avoid logging tool inputs or outputs verbatim unless they have been classified and redacted.
1. Start small and add where there is customer impact. [Avoiding metric fatigue](./pitfalls.md#metric-fatigue) is very crucial to collecting actionable data.
1. It is important that every data that is collected contains relevant and rich context.
1. Personally Identifiable Information or any other customer sensitive information should never be logged. Special attention should be paid to any local privacy data regulations and collected data must adhere to those. (ex: GDPR)
1. **Health checks** : Appropriate health checks should added to determine if service is healthy and ready to serve traffic. On a kubernetes platform different types of probes e.g. Liveness, Readiness, Startup etc. can be used to determine health and readiness of the deployed service.

Read more [here](./pitfalls.md) to understand what to watch out for while designing and building an observable system.
