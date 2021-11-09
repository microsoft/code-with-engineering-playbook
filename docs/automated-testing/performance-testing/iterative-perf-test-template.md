# Test Name

- [Iteration 3](#iteration-3)
- [Iteration 2](#iteration-2)
- [Iteration 1](#iteration-1)

## Iteration 3

### Goal

> Mention in bullet points the goal for this iteration of test. The goal should be small and measurable within this iteration.

### Test Details

- **Date**: *Date and time when this iteration started and ended*
- **Duration**: *Time it took to complete this iteration.*
- **Application Code**: *Commit id and link to the commit for the code(s) which are being tested in this iteration*
- **Benchmarking Configuration:**
  - **Application Configuration:** *In bullet points mention the configuration for application that should be recorded*
  - **System Configuration:** *In bullet points mention the configuration of the infrastructure*

> Record different types of configurations. Usually application specific configuation changes between iterations where as system or infrastructure configurations rarely change

### Work Items

> List of links to relevant work items (task, user story, bug) being tested in this iteration.

### Results

```md
In bullet points document the results from the test.  
- Attach any documents supporting the test results.
- Add links to the dashboard for metrics and logs such as Application Insights.
- Capture screenshots for metrics and include it in the results. Good candidate for this is CPU/Memory/Disk usage.
```

### Observations

> Observations are insights derived from test results. Keep the observations brief and as bullet points. Mention outcomes supporting the goal of the iteration. If any of the observation results in a work item (task, story, bug) then add the link to the work item together with the observation.  

---

## Iteration 2

### Goal

- Determine the time it takes to bulk insert 20mn records using 5 concurrent threads.

### Test Details

- **Date**: 01.01.1970 10:00AM IST - 01.01.1970 10:11AM IST
- **Duration**: 672 seconds
- **Application Code**: 5af2391fa9224124
- **Benchmarking Configuration:**
  - **Application Configuration:**
    - Threads: 5
    - Number of records: 20mn
    - ASB SDK
      - Prefetch: 1
      - ASB Lock Duration - 2 min
  - **System Configuration:** 
    - DB SKU: xxx
    - VM SKU: xxx

### Work Items

- Bug: Fix deadlock issue during bulk insert from concurrent threads (link to the issue)

### Results

1. VM Usage (screenshot)
2. SQL Usage (screenshot)
3. Link to Azure Monitor for this specific time window
4. Link to logs in Application Insight for this specific iteration.

### Observations

1. No deadlock detected
2. Locks getting escalted to table lock. Investigate locking issue (link to work item)
3. No sudden spike detected in VM CPU usage.

---

## Iteration 1

### Goal

- Sanity test

*Trimmed for brevity*
