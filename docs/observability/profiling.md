# Profiling

## Overview

Profiling is a form of runtime analysis that measures various components of the runtime such as, memory allocation, garbage collection, threads and locks, call stacks, or frequency and duration of specific functions. It can be used to see which functions are the most costly in your binary, allowing you to focus your effort on removing the largest inefficiencies as quickly as possible. It can help you find deadlocks, memory leaks, or inefficient memory allocation, and help inform decisions around resource allocation (ie: CPU or RAM).

## How to Profile your Applications

Profiling is somewhat language dependent, so start off by searching for "profile $language" (some common tools are listed below). Additionally, Linux Perf is a good fallback, since a lot of languages have bindings in C/C++.

Profiling does incur some cost, as it requires inspecting the call stack, and sometimes pausing the application all together (ie: to trigger a full GC in Java). It is recommended to continuously profile your services, say for 10s every 10 minutes. Consider the cost when deciding on tuning these parameters.

Different tools visualize profiles differently. Common CPU profiles might use a directed graph ![graph](./images/pprof-dot.png) or a flame graph. ![flame](./images/flame.png)

Unfortunately, each profiler tool typically uses its own format for storing profiles, and comes with its own visualization.

## Tools

- (Java, Go, Python, Ruby, eBPF) [Pyroscope](https://github.com/pyroscope-io/pyroscope) continuous profiling out of the box.
- (Java and Go) [Flame](https://github.com/VerizonMedia/kubectl-flame) - profiling containers in Kubernetes
- (Java, Python, Go) [Datadog Continuous profiler](https://www.datadoghq.com/product/code-profiling/)
- (Go) [profefe](https://github.com/profefe/profefe), which builds `pprof` to provide continuous profiling
- (Java) [Eclipse Memory Analyzer](https://eclipse.dev/mat/)
