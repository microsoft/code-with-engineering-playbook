# Unit Testing

## Goals
Unit tests play an integral role in building quality software and enabling agile methodologies. [CSE](../CSE.md) recommends all efforts follow [Test Driven Development](http://deviq.com/test-driven-development/) where ever possible, i.e. code should have unit tests unless it's developed for an environment with unit testing capabilities, e.g. Azure Stream Analytics. 

With TDD, an engineer follows the pattern of RED/GREEN/REFACTOR to build only the code required and nothing more.
- RED: Start with a test to exercise a function. Initially, this test will fail because the function is not yet implemented (or is incomplete).
- GREEN: Implements just enough code to get all of the currently written tests to pass.
- REFACTOR: Modify the code as necessary to reflect for naming standards, remove code duplication and implement clean coding practices.

Development continues in this cycle (RED/GREEN/REFACTOR) writing additional tests until all functional requirements are complete.

### Unit tests have several goals:
- Ensure code fulfills functional requirements. 
- Ensure focus is delivering required functionality not unnecessary requirements.
- Support fast code evolution and refactoring while reducing the risk of regressions.
- Provide confidence to potential contributors.
- Developer Documentation of API usage

>Note: Non-functional requiements should be validated with integration tests (i.e. Server response time in less than 2 seconds.)

## Evidence and Measures
The [CICD already requires badges in place](../CICD) for every repo to quickly assess code coverage and test pass/fail.

Unit tests should be run before every commit. The team should decide on the importance of runnning integration and end-to-end testing as part of the merge process. 
>Note: Ignoring tests is never a valid method for getting tests to not be RED. The team should decide when ignored tests are allowed or when they should be refactored out of the code base.

## General Guidance
The scope of a unit test is small and generally a single unit of work. Engineers should use good judgement to provide a reasonable amount of unit test based on complexity of the unit to be tested, aligning with the overall goal of 70-80% code coverage. Unit tests should exercise more than the ideal conditions and should reflect appropriate error handling and expected exceptions.

Bug fixes should start with a test that reliably reproduces the bug. This will help ensure that the code correctly fixes the issue and that it is not reintroduced in future changes. Existing tests will reduce risk of regressions introduced by the fix.

Developers should be careful to focus their unit testing efforts on the code that they are currently working on. Writing tests to validate that the functionality of a 3rd party framework should be considered out of scope. An integration test to ensure handling 3rd party failures is acceptable, but should be focused on how internal code handles the failure, not on how the external failure triggered. It is easy to bogged down in writing unit tests that test functionality that is not in the scope of responsibility of the developer. For example, writing a test to validate the implementation of an framework's function for parsing a number from a string value.

In order to keep execution of unit tests fast and executable as part of a CI/CD pipeline, tests should provide mock implementations of dependencies including other parts of the application or 3rd party services. 

Unit testing represents only the foundational testing in the system development. It does not remove the need for integration tests and end-to-end tests for larger pieces of functionality and system dependencies. For integration or end-to-end testing, mocks should be replaced with API calls to the system they are simulating.

### Writing Tests
Good unit tests follow a few general principles:
- Run incredibly fast
- Test only the current system under test
- Test one thing generally with a single assertion
- Have only one reason to fail

Consider an integration test:
- Ensure transactions commit or roll back as designed
- Ensure CRUD operations work as designed
- All data created for or during a test is localized to the test to allow for parallel test execution
- All data created during or for a test gets cleaned up after tests completed

For more complex applications, integration load tests can also ensure:
- that multi-threading works as intended
- the unit can deals appropriately with transient outages of external dependencies (retry, fail-fast, …)
- Stateful applications restore state when re-started

## Specific Guidance
Languages and Platforms provide their own unit test tools and frameworks. In [CSE](../CSE.md), we prefer:
- .NET / Visual Studio: https://docs.microsoft.com/en-us/visualstudio/test/unit-test-your-code
- .NET / NUnit: http://nunit.org/ 
- .NET Core: https://docs.microsoft.com/en-us/dotnet/core/testing/
- Java: https://junit.org/junit5/
- Go: https://golang.org/pkg/testing/
- JavaScript / Node: https://mochajs.org/
		
## Resources
- .NET Tutorial: https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code
- Java Tutorial: http://tutorials.jenkov.com/java-unit-testing/index.html
- Unit Testing Spark: http://www.jesse-anderson.com/2016/04/unit-testing-spark-with-java/