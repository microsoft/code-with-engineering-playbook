# Peformance Testing

Performance Testing is an overloaded term that is used to refer to several sub categories of performance related testing, each of which has different purpose. A good description of overall performance testing is as follows: 

"*Performance testing is a type of testing intended to determine the responsiveness, throughput, reliability, and/or scalability of a system under a given workload.* " -  [Performance Testing Guidance for Web Applications](https://docs.microsoft.com/en-us/archive/blogs/dajung/ebook-pnp-performance-testing-guidance-for-web-applications).

Before getting into the different subcategories of performance tests let us understand why is performance testing typically done.


## Why Performance Testing

Performance testing is commonly conducted to accomplish one or more the following:

* To help in accessing whether a **system is ready for Release**:
  * Estimating / Predicting the performance characteristics (such as response time, failure rate, throughput) which an application is likely to have when it is released in to production. The results can help in predicting the satisfaction level of the users when interacting with the system. The predicted values can also be compared with agreed values (success criteria) for the performance characteristics when available. 
  * To help in accessing the adequacy of the infrastrucutre / managed service sku's to meet the desired performance charecteristics of a system
  * Identifying bottlenecks and issues with the application at different load levels
* To compare the **performance impact of application changes**
  * Comparing the the performance characteristics of an application after a change to the values of performance characteristics during previous runs (or baseline values), can provide an indication of performance issues or enhancements introduced due to a change
* To **support system tuning**
  * Comparing performance characteristics of a system for different system configurations



## Key Performance Testing categories
* **Performance Testing** : This category is the super set of all sub categories of performance related testing. It validates/determines the speed, scalability or reliability charateristics of the system under test. Performance testing focusses on achieving the response times, throughput, and resource utilization levels which meet the performance objectives of a system
* **Load Testing** : This is the subcategory of performance testing which focusses on validating the performance characteristics of a system, when the system faces load volumes which are expected during production operation.
* **Stress Testing** : This is the subcategory of performance testing which focusses on validating the performance characteristics of a system, when the system faces load volumes or conditions beyond those expected during production operations. This could include tests which limit the memory, disk available to the system.

**TODO: Need to add from this point onwards**

In this section, describe the test type, its components, and how they interact to solve the problem described above.

## Applying the ~test type~ [the how]

In this section, describe what good testing looks like for this test type, discuss some of the best practices, discuss pitfalls to avoid, and finally discuss some of the common tools used to apply the test type, if any.

## ~Test type~ Frameworks and Tools

In this section, describe various test frameworks and tools, their pros and cons, and provide with the links to where to get more information.

## Examples/Case studies

If available, list some good examples or case studies for this test type and elaborate on what is good about them.

## Conclusion

In conclusion, provide the final thoughts on why and how this type of test can help with your next customer engagement, what best practices and recommendations that can be withdrawn from the case studies and research.

## Resources

* Most of the guidance on this page is based on the awesome performance testing book [Patters and Practices: Performance Testing Guidance for Web Applications](https://docs.microsoft.com/en-us/archive/blogs/dajung/ebook-pnp-performance-testing-guidance-for-web-applications)

List additional readings about this test type for those that would like to dive deeper.
