# Testing

## Map of Outcomes to Testing Techniques

The table below maps outcomes -- the results that you may want to achieve in your validation efforts -- to one or more techniques that can be used to accomplish that outcome.

To use the table, either eyeball-browse or search for keywords.

| When I am working on... | I want to get this outcome... | ...so I should consider |
|--|--|--|
| Development | Prove backward compatibility with existing callers and clients | Shadow testing |
| Development; [Integration testing](integration-testing/readme.md) | Ensure telemetry is sufficiently detailed and complete to trace and diagnose malfunction in [End-to-End testing](e2e-testing/readme.md) flows | Distributed Debug challenges ;  Orphaned call chain analysis |
| Development | Ensure program logic is correct for a variety of expected, mainline, edge and unexpected inputs | [Unit testing](unit-testing/readme.md); Functional tests; [Integration testing](integration-testing/readme.md) |
| Development | Prevent regressions in logical correctness; earlier is better | [Unit testing](unit-testing/readme.md); Functional tests; [Integration testing](integration-testing/readme.md); Rings (each of these are expanding scopes of coverage) |
| Development | Quickly validate mainline correctness of a point of functionality (e.g. single API), manually | Manual smoke testing Tools: postman, powershell, curl |
| Development; [Integration testing](integration-testing/readme.md) | Validate that multiple components function together across multiple interfaces in a call chain, incl network hops | [Integration testing](integration-testing/readme.md); End-to-end ([End-to-End testing](e2e-testing/readme.md)) tests; Segmented end-to-end ([End-to-End testing](e2e-testing/readme.md)) |
| Development | Prove disaster recoverability – recover from corruption of data | DR drills |
| Development | Find vulnerabilities in service Authentication or Authorization | Scenario (security) |
| Development | Prove correct RBAC and claims interpretation of Authorization code | Scenario (security) |
| Development | Document and/or enforce valid API usage | [Unit testing](unit-testing/readme.md); Functional tests|
| Development | Prove implementation correctness in advance of a dependency or absent a dependency | [Unit testing](unit-testing/readme.md) (with mocks); [Unit testing](unit-testing/readme.md) (with emulators) |
| Development | Ensure that the user interface is accessible | Accessibility |
| Development | Ensure that users can operate the interface | [UI testing (automated)](ui-testing/readme.md) (human usability observation) |
| Development | Prevent regression in user experience | UI automation; [End-to-End testing](e2e-testing/readme.md) |
| Development | Detect and prevent &#39;noisy neighbor&#39; phenomena | [Load testing](performance-testing/load-testing.md) |
| Development | Detect availability drops | [Synthetic Transaction testing](synthetic-monitoring-tests/readme.md); Outside-in probes |
| Development | Prevent regression in &#39;composite&#39; scenario use cases / workflows (e.g. an ecommerce system might have many APIs that used together in a sequence perform a &quot;shop-and-buy&quot; scenario) | [End-to-End testing](e2e-testing/readme.md); Scenario |
| Development; Operations | Prevent regressions in runtime performance metrics e.g. latency / cost / resource consumption; earlier is better | Rings; [Synthetic Transaction testing](synthetic-monitoring-tests/readme.md) / Transaction; Rollback Watchdogs |
| Development; Optimization | Compare any given metric between 2 candidate implementations or variations in functionality | Flighting; A/B testing|
| Development; Staging | Prove production system of provisioned capacity meets goals for reliability, availability, resource consumption, performance | [Load testing (stress)](performance-testing/load-testing.md); Spike; Soak; [Performance testing](performance-testing/readme.md) |
| Development; Staging | Understand key user experience performance characteristics – latency, chattiness, resiliency to network errors | Load; [Performance testing](performance-testing/readme.md); Scenario (network partitioning) |
| Development; Staging; Operation | Discover melt points (the loads at which failure or maximum tolerable resource consumption occurs) for each individual component in the stack | Squeeze; [Load testing (stress)](performance-testing/load-testing.md) |
| Development; Staging; Operation | Discover overall system melt point (the loads at which the end-to-end system fails) and which component is the weakest link in the whole stack | Squeeze; [Load testing (stress)](performance-testing/load-testing.md) |
| Development; Staging; Operation | Measure capacity limits for given provisioning to predict or satisfy future provisioning needs | Squeeze; [Load testing (stress)](performance-testing/load-testing.md) |
| Development; Staging; Operation | Create / exercise failover runbook | Failover drills |
| Development; Staging; Operation | Prove disaster recoverability – loss of data center (the meteor scenario); measure MTTR | DR drills |
| Development; Staging; Operation | Understand whether observability dashboards are correct, and telemetry is complete; flowing | Trace Validation; [Load testing (stress)](performance-testing/load-testing.md); Scenario; [End-to-End testing](e2e-testing/readme.md) |
| Development; Staging; Operation | Measure impact of seasonality of traffic | [Load testing](performance-testing/load-testing.md) |
| Development; Staging; Operation | Prove Transaction and alerts correctly notify / take action | [Synthetic Transaction testing](synthetic-monitoring-tests/readme.md) (negative cases); [Load testing](performance-testing/load-testing.md) |
| Development; Staging; Operation; Optimizing | Understand scalability curve, i.e. how the system consumes resources with load | [Load testing (stress)](performance-testing/load-testing.md); [Performance testing](performance-testing/readme.md) |
| Operation; Optimizing | Discover system behavior over long-haul time | Soak |
| Optimizing | Find cost savings opportunities | Squeeze |
| Staging; Operation | Measure impact of failover / scale-out (repartitioning, increasing provisioning) / scale-down | Failover drills; Scale drills |
| Staging; Operation | Create/Exercise runbook for increasing/reducing provisioning | Scale drills |
| Staging; Operation | Measure behavior under rapid changes in traffic | Spike |
| Staging; Optimizing | Discover cost metrics per unit load volume (what factors influence cost at what load points, e.g. cost per million concurrent users) | Load (stress) |
| Development; Operation | Discover points where a system is not resilient to unpredictable yet inevitable failures (network outage, hardware failure, VM host servicing, rack/switch failures, random acts of the Malevolent Divine, solar flares, sharks that eat undersea cable relays, cosmic radiation, power outages, renegade backhoe operators, wolves chewing on junction boxes, …) | Chaos |

## Sections within Testing

- [End-to-End testing](e2e-testing/readme.md)
- [Fault Injection testing](fault-injection-testing/readme.md)
- [Integration testing](integration-testing/readme.md)
- [Performance testing](performance-testing/readme.md)
- [Smoke testing](smoke-testing/readme.md)
- [Synthetic Transaction testing](synthetic-monitoring-tests/readme.md)
- [UI testing](ui-testing/readme.md)
- [Unit testing](unit-testing/readme.md)
