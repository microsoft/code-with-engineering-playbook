# Watchdog Tests

Watchdog Tests are a set of functional and non-functional tests that run alongside the main product to verify its health and resilience, at runtime.

## Why Watchdog tests [The Why]

Traditionally, software providers rely on testing through CI/CD stages in the well known [testing pyramid](https://martinfowler.com/bliki/TestPyramid.html) (unit, integration, e2e) to validate that the product is healthy and without regressions. Such tests will run on the build agent or in the test/stage environment before being deployed to production and released to live user traffic. During the services' lifetime in the production environment, they are safeguarded by monitoring and alerting tools that rely on Real User Metrics/Monitoring (RUM).

However, as more organizations today provide highly-available (99.9+ SLA) products, they find that the nature of distributed applications (hardware or software) over time is to fail. Moreover, the frequency of releases to parts the system becomes more frequent generating more instability to the system.
For such systems, the ambition of service engineering teams is to reduce to a minimum the time it takes to fix errors in the system, or the [MTTR - Mean Time To Repair](https://en.wikipedia.org/wiki/Mean_time_to_repair). It is a continuous effort, performed on the live/production system.

A general name for tests which run in proudction is Shift-Right, which comes to compliment and add on top of the Shift-Left paradigms, allowing for testing on live systems. Watchdog tests are a subset of the methods used to Shift-Right testing.

## Watchdog tests Design Blocks [The What]

Applications of testing in production inject synthetic user behaviors to the system and validate their effect, usually by passively relying on existing monitoring and alerting capabilities.
There are two components to Testing in production: **Probes**, which are test code running generating data, and the **Monitoring** tools placed to validate both the system's behavior under test and the health of the test themselves.

[TODO: ADD IMAGE]

### Watchdog tests tests

A Watchdog test is, in fact, very related to black-box tests. It is not uncommon for the same code used for e2e or integration tests to be used to implement the probe.

### Watchdog tests monitoring

Given that Watchdog tests are continuously running (at intervals) in a production environment, the assertion of system behavior through test relies on existing monitoring fundamentals used for the live system (Loggin, Metrics, Distributed Tracing).

In this section, describe the test type, its components, and how they interact to solve the problem described above.

## Applying Tests in Production [the how]

Tests are required to run in production, facing live systems as a test user account. This usually reflects on implementing AuthN/AuthZ for these tests.

### Risks

* Corrupted or invalid data
* Protected data
* Overloaded systems
* Unintended side effects or impacts on other production systems
* Skewed analytics (traffic funnels, A/B test results, etc.)

In this section, describe what good testing looks like for this test type, discuss some of the best practices, discuss pitfalls to avoid, and finally discuss some of the common tools used to apply the test type, if any.

## Watchdog tests Frameworks and Tools

???

In this section, describe various test frameworks and tools, their pros and cons, and provide with the links to where to get more information.

## Conclusion

???

In conclusion, provide the final thoughts on why and how this type of test can help with your next customer engagement, what best practices and recommendations that can be withdrawn from the case studies and research.

## Resources

[Google SRE book - Testing Reliability](https://landing.google.com/sre/sre-book/chapters/testing-reliability/)

[Microsoft DevOps Architectures - Shift Right to Test in Production](https://docs.microsoft.com/en-us/azure/devops/learn/devops-at-microsoft/shift-right-test-production)

[Martin Fowler - Synthetic Monitoring](https://martinfowler.com/bliki/SyntheticMonitoring.html)
