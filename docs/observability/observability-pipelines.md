# Observability of CI/CD Pipelines

With increasing complexity to delivery pipelines, it is very important
to consider Observability in the context of build and release of
applications.

## Benefits

- Having proper instrumentation during build time helps gain insights into the various stages of the build and release process.
- Helps developers understand where the pipeline performance bottlenecks are, based on the data collected. This
helps in having data-driven conversations around identifying latency between jobs, performance issues,
artifact upload/download times providing valuable insights into agents availability and capacity.
- Helps to identify trends in failures, thus allowing developers to quickly do root cause analysis.
- Helps to provide an organization-wide view of pipeline health to easily identify trends.

## Points to Consider

- It is important to identify the Key Performance Indicators (KPIs) for evaluating a successful CI/CD pipeline. Where needed, additional tracing can be added to better record KPI metrics. For example, adding pipeline build tags to identify a 'Release Candidate' vs. 'Non-Release Candidate' helps in evaluating the end-to-end release process timeline.
- Depending on the tooling used (Azure DevOps, Jenkins etc.,), basic reporting on the pipelines is
available out-of-the-box. It is important to evaluate these reports against the KPIs to understand if
a custom reporting solution for their pipelines is needed. If required, custom dashboards can be built using
third-party tools like Grafana or Power BI Dashboards.
