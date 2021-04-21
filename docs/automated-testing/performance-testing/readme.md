# Performance Testing

Performance Testing is an overloaded term that is used to refer to several sub categories of performance related testing, each of which has different purpose. A good description of overall performance testing is as follows:

"*Performance testing is a type of testing intended to determine the responsiveness, throughput, reliability, and/or scalability of a system under a given workload.* " -  [Performance Testing Guidance for Web Applications](https://docs.microsoft.com/en-us/archive/blogs/dajung/ebook-pnp-performance-testing-guidance-for-web-applications).

Before getting into the different subcategories of performance tests let us understand why is performance testing typically done.

## Why Performance Testing

Performance testing is commonly conducted to accomplish one or more the following:

* To help in assessing whether a **system is ready for Release**:
  * Estimating / Predicting the performance characteristics (such as response time, throughput) which an application is likely to have when it is released in to production. The results can help in predicting the satisfaction level of the users when interacting with the system. The predicted values can also be compared with agreed values (success criteria) for the performance characteristics when available.
  * To help in accessing the adequacy of the infrastructure / managed service SKUs to meet the desired performance characteristics of a system
  * Identifying bottlenecks and issues with the application at different load levels
* To compare the **performance impact of application changes**
  * Comparing the performance characteristics of an application after a change to the values of performance characteristics during previous runs (or baseline values), can provide an indication of performance issues or enhancements introduced due to a change
* To **support system tuning**
  * Comparing performance characteristics of a system for different system configurations

## Key Performance Testing categories

<!-- markdownlint-disable no-duplicate-heading -->
### Performance Testing
<!-- markdownlint-enable no-duplicate-heading -->

  This category is the super set of all sub categories of performance related testing. It validates/determines the speed, scalability or reliability characteristics of the system under test. Performance testing focuses on achieving the response times, throughput, and resource utilization levels which meet the performance objectives of a system

### **[Load Testing](./load-testing.md)**
  
  This is the subcategory of performance testing which focuses on validating the performance characteristics of a system, when the system faces load volumes which are expected during production operation. **Endurance Test** or **Soak Test** is a load test carried over a long duration ranging from several hours to days.

### Stress Testing

  This is the subcategory of performance testing which focuses on validating the performance characteristics of a system when the system faces extreme load. The goal is to evaluate how does the system handles being pressured to its limits, does it recover (i.e. scale-out) or does it just break and fail?

## Key Performance testing activities

  Performance testing activities vary depending on sub category of performance test, the engagement requirements and constraints. For specific guidance you can follow the link to the sub category of performance tests listed above. Following are some activities which will generally be involved:

### Identify and Define the Acceptance criteria for the tests

  This will generally include identifying and defining the goals and constrains for the performance characteristics of the system
  
### Plan and design the tests
  
  In general we need to consider the following points:

* Defining the load the application would be tested with
* Establishing the metrics to be collected
* Establish which tools will be used for the tests
* Establish the performance test frequency : whether the performance tests be done as a part of the feature development sprints, or only prior to release to a major environment?
  
### Test implementation

### Test Execution

### Result analysis and re-testing

* The test are executed, the results are collected and the environments are monitored
* The results are analysed
* Depending on the scenario, modification of application or configuration are done and testing cycle is repeated again.

## Resources

* [Patters and Practices: Performance Testing Guidance for Web Applications](https://docs.microsoft.com/en-us/archive/blogs/dajung/ebook-pnp-performance-testing-guidance-for-web-applications)
