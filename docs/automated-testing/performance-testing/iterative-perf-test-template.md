# Performance Test Iteration Template

> This document provides template for capturing results of performance tests. Performance tests are done in iterations and each iteration should have a clear goal. The results of any iteration is immutable regardless whether the goal was achieved or not. If the iteration failed or the goal is not achieved then a new iteration of testing is carried out with appropriate fixes. It is recommended to keep track of the recorded iterations to maintain a timeline of how system evolved and which changes affected the performance in what way. Feel free to modify this template as needed.

## Iteration Template

### Goal

> Mention in bullet points the goal for this iteration of test. The goal should be small and measurable within this iteration.

### Test Details

- **Date**: *Date and time when this iteration started and ended*
- **Duration**: *Time it took to complete this iteration.*
- **Application Code**: *Commit id and link to the commit for the code(s) which are being tested in this iteration*
- **Benchmarking Configuration:**
  - **Application Configuration:** *In bullet points mention the configuration for application that should be recorded*
  - **System Configuration:** *In bullet points mention the configuration of the infrastructure*

> Record different types of configurations. Usually application specific configuration changes between iterations whereas system or infrastructure configurations rarely change

### Work Items

> List of links to relevant work items (task, story, bug) being tested in this iteration.

### Results

```md
In bullet points document the results from the test.
- Attach any documents supporting the test results.
- Add links to the dashboard for metrics and logs such as Application Insights.
- Capture screenshots for metrics and include it in the results. Good candidate for this is CPU/Memory/Disk usage.
```

### Observations

> Observations are insights derived from test results. Keep the observations brief and as bullet points. Mention outcomes supporting the goal of the iteration. If any of the observation results in a work item (task, story, bug) then add the link to the work item together with the observation.
