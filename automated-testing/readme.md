# Testing

## Map of Outcomes to Testing Techniques

The table below maps outcomes -- the results that you may want to achieve in your validation efforts -- to one or more techniques that can be used to accomplish that outcome.

To use the table, either eyeball-browse or search for keywords.  The  

| When I am working on... | I want to get this outcome... | ...so I should consider |
|--|--|--|
| Development | Prove backward compatibility with existing callers and clients | Shadow testing |
| Development<br/>[Integration testing](integration-testing/readme.md) | Ensure telemetry is sufficiently detailed and complete to trace and diagnose malfunction in [End-to-End testing](e2e-testing/readme.md) flows | Distributed Debug challenges <br/> Orphaned call chain analysis |
| Development | Ensure program logic is correct for a variety of expected, mainline, edge and unexpected inputs | [Unit testing](unit-testing/readme.md)<br/>Functional tests<br/>[Integration testing](integration-testing/readme.md) |
| Development | Prevent regressions in logical correctness; earlier is better | [Unit testing](unit-testing/readme.md)<br/>Functional tests<br/>[Integration testing](integration-testing/readme.md)<br/>Rings (each of these are expanding scopes of coverage) |
| Development | Quickly validate mainline correctness of a point of functionality (e.g. single API), manually | Manual smoke testing Tools: postman, powershell, curl |
| Development<br/>[Integration testing](integration-testing/readme.md) | Validate that multiple components function together across multiple interfaces in a call chain, incl network hops | [Integration testing](integration-testing/readme.md)<br/>End-to-end ([End-to-End testing](e2e-testing/readme.md)) tests<br/>Segmented end-to-end ([End-to-End testing](e2e-testing/readme.md)) |
| Development | Prove disaster recoverability – recover from corruption of data | DR drills |
| Development | Find vulnerabilities in service Authentication or Authorization | Scenario (security) |
| Development | Prove correct RBAC and claims interpretation of Authorization code | Scenario (security) |
| Development | Document and/or enforce valid API usage | [Unit testing](unit-testing/readme.md)<br/>Functional tests|
| Development | Prove implementation correctness in advance of a dependency or absent a dependency | [Unit testing](unit-testing/readme.md) (with mocks)<br/>[Unit testing](unit-testing/readme.md) (with emulators) |
| Development | Ensure that the user interface is accessible | Accessibility |
| Development | Ensure that users can operate the interface | [UI testing (automated)](ui-testing/readme.md) (human usability observation) |
| Development | Prevent regression in user experience | UI automation<br/>[End-to-End testing](e2e-testing/readme.md) |
| Development | Detect and prevent &#39;noisy neighbor&#39; phenomena | [Load testing](performance-testing/load-testing.md) |
| Development | Detect availability drops | [Synthetic Transaction testing](synthetic-monitoring-tests/readme.md)<br/>Outside-in probes |
| Development | Prevent regression in &#39;composite&#39; scenario use cases / workflows (e.g. an ecommerce system might have many APIs that used together in a sequence perform a &quot;shop-and-buy&quot<br/>scenario) | [End-to-End testing](e2e-testing/readme.md)<br/>Scenario |
| Development<br/>Operations | Prevent regressions in runtime performance metrics e.g. latency / cost / resource consumption<br/>earlier is better | Rings<br/>[Synthetic Transaction testing](synthetic-monitoring-tests/readme.md) / Transaction<br/>Rollback Watchdogs |
| Development<br/>Optimization | Compare any given metric between 2 candidate implementations or variations in functionality | Flighting<br/>A/B testing|
| Development<br/>Staging | Prove production system of provisioned capacity meets goals for reliability, availability, resource consumption, performance | [Load testing (stress)](performance-testing/load-testing.md)<br/>Spike<br/>Soak<br/>[Performance testing](performance-testing/readme.md) |
| Development<br/>Staging | Understand key user experience performance characteristics – latency, chattiness, resiliency to network errors | Load<br/>[Performance testing](performance-testing/readme.md)<br/>Scenario (network partitioning) |
| Development<br/>Staging<br/>Operation | Discover melt points (the loads at which failure or maximum tolerable resource consumption occurs) for each individual component in the stack | Squeeze<br/>[Load testing (stress)](performance-testing/load-testing.md) |
| Development<br/>Staging<br/>Operation | Discover overall system melt point (the loads at which the end-to-end system fails) and which component is the weakest link in the whole stack | Squeeze<br/>[Load testing (stress)](performance-testing/load-testing.md) |
| Development<br/>Staging<br/>Operation | Measure capacity limits for given provisioning to predict or satisfy future provisioning needs | Squeeze<br/>[Load testing (stress)](performance-testing/load-testing.md) |
| Development<br/>Staging<br/>Operation | Create / exercise failover runbook | Failover drills |
| Development<br/>Staging<br/>Operation | Prove disaster recoverability – loss of data center (the meteor scenario)<br/>measure MTTR | DR drills |
| Development<br/>Staging<br/>Operation | Understand whether observability dashboards are correct, and telemetry is complete<br/>flowing | Trace Validation<br/>[Load testing (stress)](performance-testing/load-testing.md)<br/>Scenario<br/>[End-to-End testing](e2e-testing/readme.md) |
| Development<br/>Staging<br/>Operation | Measure impact of seasonality of traffic | [Load testing](performance-testing/load-testing.md) |
| Development<br/>Staging<br/>Operation | Prove Transaction and alerts correctly notify / take action | [Synthetic Transaction testing](synthetic-monitoring-tests/readme.md) (negative cases)<br/>[Load testing](performance-testing/load-testing.md) |
| Development<br/>Staging<br/>Operation<br/>Optimizing | Understand scalability curve, i.e. how the system consumes resources with load | [Load testing (stress)](performance-testing/load-testing.md)<br/>[Performance testing](performance-testing/readme.md) |
| Operation<br/>Optimizing | Discover system behavior over long-haul time | Soak |
| Optimizing | Find cost savings opportunities | Squeeze |
| Staging<br/>Operation | Measure impact of failover / scale-out (repartitioning, increasing provisioning) / scale-down | Failover drills<br/>Scale drills |
| Staging<br/>Operation | Create/Exercise runbook for increasing/reducing provisioning | Scale drills |
| Staging<br/>Operation | Measure behavior under rapid changes in traffic | Spike |
| Staging<br/>Optimizing | Discover cost metrics per unit load volume (what factors influence cost at what load points, e.g. cost per million concurrent users) | Load (stress) |
| Development<br/>Operation | Discover points where a system is not resilient to unpredictable yet inevitable failures (network outage, hardware failure, VM host servicing, rack/switch failures, random acts of the Malevolent Divine, solar flares, sharks that eat undersea cable relays, cosmic radiation, power outages, renegade backhoe operators, wolves chewing on junction boxes, …) | Chaos |

## Sections within Testing

- [End-to-End testing](e2e-testing/readme.md)
- [Integration testing](integration-testing/readme.md)
- [Performance testing](performance-testing/readme.md)
- [Synthetic Transaction testing](synthetic-Monitoring-tests/readme.md)
- [UI testing](ui-testing/readme.md)
- [Unit testing](unit-testing/readme.md)
