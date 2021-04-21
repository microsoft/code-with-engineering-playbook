# Kubernetes UI Dashboards

This document covers the options and benefits of various Kubernetes UI Dashboards which are useful tools for monitoring and debugging your application on Kubernetes Clusters. It allows the management of applications running in the cluster, debug them and manage the cluster all through these dashboards.

## Overview and Background

There are times when not all solutions can be run locally. This limitation could be due to a cloud service which does not offer a robust or efficient way to locally debug the environment. In these cases, it is necessary to use other tools which provide the capabilities to monitor your application with Kubernetes.

## Advantages and Use Cases

- Allows the ability to view, manage and monitor the operational aspects of the Kubernetes Cluster.

- Benefits of using a UI dashboard includes the following:
  - see an overview of the cluster
  - deploy applications onto the cluster
  - troubleshoot applications running on the cluster
  - view, create, modify, and delete Kubernetes resources
  - view basic resource metrics including resource usage for Kubernetes objects
  - view and access logs
  - live view of the pods state (e.g. started, terminating, etc)

- Different dashboards may provide different functionalities and the use case to choose a particular dashboard will depend on the requirements. For example, many dashboards provide a way to only monitor your applications on Kubernetes but do not provide a way to manage them.

## Open Source Dashboards

There are currently several UI dashboards available to monitor your applications or manage them with Kubernetes. For example:

- [Octant](https://github.com/vmware-tanzu/octant)
- [Prometheus and Grafana](https://prometheus.io/docs/visualization/grafana/)
  - [Kube Prometheus Stack Chart](https://github.com/prometheus-community/helm-charts/tree/main/charts/kube-prometheus-stack): provides an easy way to operate end-to-end Kubernetes cluster monitoring with Prometheus using the Prometheus Operator.
- [K8Dash](https://github.com/indeedeng/k8dash)
- [kube-ops-view](https://github.com/hjacobs/kube-ops-view): a tool to visualize node occupancy & utilization
- [Lens](https://k8slens.dev/): Client side desktop tool
- [Thanos](https://github.com/thanos-io/thanos) and [Cortex](https://cortexmetrics.io/docs/): Multi-cluster implementations

## References

- [Alternatives to Kubernetes Dashboard](https://octopus.com/blog/alternative-kubernetes-dashboards)
- [Prometheus and Grafana with Kubernetes](https://tanzu.vmware.com/developer/guides/kubernetes/observability-prometheus-grafana-p1/)
