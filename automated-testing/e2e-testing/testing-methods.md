# E2E Testing Methods

## Horizontal Test

This method is used very commonly. It occurs horizontally across the context of multiple applications. Take an example of a data ingest management system.

![Horizontal Test](./images/horizontal-e2e-testing.png)

The inbound data may be  injected from various sources, but it then "flatten" into a horizontal processing pipeline that may include various components, such as a gateway API, data transformation, data validation, storage, etc... Throughout the entire Extract-Transform-Load (ETL) processing, the data flow can be tracked and monitored under the horizontal spectrum with little sprinkles of optional, and thus not important for the overall E2E test case, services, like logging, auditing, authentication.

## Vertical Test

In this method, all most critical transactions of any application are verified and evaluated right from the start to finish. Each individual layer of the application is tested starting from top to bottom. Take an example of a web-based application that uses middleware services for reaching back-end resources.

![Vertical Test](./images/vertical-e2e-testing.png)

 In such case, each layer (tier) is required to be fully tested in conjunction with the "connected" layers above and beneath, in which services "talk" to each other during the end to end data flow. All these complex testing scenarios will require proper validation and dedicated automated testing. Thus this method is much more difficult.

## E2E Test Cases Design Guidelines

Below enlisted are few **guidelines** that should be kept in mind while designing the test cases for performing E2E testing:

- Test cases should be designed from the end user’s perspective.
- Should focus on testing some existing features of the system.
- Multiple scenarios should be considered for creating multiple test cases.
- Different sets of test cases should be created to focus on multiple scenarios of the system.
