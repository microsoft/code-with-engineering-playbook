# Tracing

## Overview

Produces the information required to observe series of correlated operations in a distributed system. Once collected they show the path, measurements and faults in a end to end transaction.

## Best Practices

- Ensure that at least key business transactions are traced.
- Include in each trace necessary information to identify software releases (i.e. service name, version). This is important to correlate deployments and system degradation.
- Ensure dependencies are included in trace (databases, I/O).
- If costs are a concern use sampling, avoiding throwing away errors, unexpected behaviour and critical information.
- Don't reinvent the wheel, use existing tools to collect and analyse the data.
- Ensure personal identifiable information policies and restrictions are followed.
