# Metrics

## Overview

Metrics provide a near real-time stream of data, informing operators and stakeholders about the functions the system is performing as well as its health. Unlike logging and tracing, metric data tends to be more efficient to transmit and store.

## Best Practices

### What should be tracked?

System critical measurements that relate to the application/machine health, which are usually excellent alert candidates. Work with your engineering and devops peers to identify the metrics, but they may include:

- CPU and memory utilisation.
- Request rate.
- Queue length.
- Unexpected exception count.

Important business-related measurements, which drive reporting to stakeholders. Consult with the various stakeholders of the component, but some examples may include:

- Jobs performed.
- User Session length.
- Games played.
- Site visits.

### Dimension Labels

Modern metric systems today usually define a single time series metric as the combination of the name of the metric and its dictionary of dimension labels. Labels are an excellent way to distinguish one instance of a metric, from another while still allowing for aggregation and other operations to be performed on the set for analysis. Some common labels used in metrics may include:

- Container Name
- Host name
- Code Version
- Kubernetes cluster name
- Azure Region

_Note_: Since dimension labels are used for aggregations and grouping operations, do not use unique strings or those with high cardinality as the value of a label. The value of the label is significantly diminished for reporting and in many cases has a negative performance hit on the metric system used to track it.
