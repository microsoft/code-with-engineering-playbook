# Unit Testing

## Goals
Unit tests play an integral role in building quality software and enabling agile methodologies. [CSE](../CSE.md) recommends all efforts follow [Test Driven Development](http://deviq.com/test-driven-development/) where ever possible, i.e. code should have unit tests unless it's developed for an environment without unit testing capabilities, e.g. Azure Stream Analytics. With TDD, engineers start with coding the test(s), which will initially fail. The implementation of the unit is finished when the unit satisfies the tests.

### Unit tests have several goals:
- Ensure code fulfills functional and non-functional requirements
- Ensure focus on functionality to deliver
- Support fast code evolution and refactoring while reducing the risk of regressions
- Provide confidence to potential contributors 
- Developer Documentation of API usage

## Evidence and Measures
The [CICD already requires badges in place](../Engineering/CICD.md) for every repo to quickly assess code coverage and test pass/fail.

The team should also keep in an eye on tests that may not be running as part of every merge, i.e. integration and e2e test.

## General Guidance
The scope of a unit test is small. Engineers should use good judgement to provide a reasonable amount of unit test based on complexity of the unit to be tested, aligning with the overall goal of 70-80% code coverage. Unit tests should exercise more than the "happy path" paying specific attention to returned error values or exceptions thrown. 

Bug fixes should start with a test that reliably reproduces the bug to ensure that a particular commit will fix the bug as intended. Existing tests will reduce risk of regressions introduced by the fix.

Unit testing works in conjunction with integration tests and end-to-end tests for larger pieces of functionality.

In order to keep execution of unit tests fast and executable as part of a CI/CD pipeline, tests can provide mock implementations of other parts of the application or 3rd party services. 

For integration or end-to-end testing, mocks should be replaced with API calls to the system they are simulating.

### Writing Tests
Good unit tests follow a few general principles:
- Pass / Fail tests ensure intended succeeds and fails as designed.
- Transactional tests ensure transactions commit or roll back as designed
- CRUD operations work as designed
- All data created for or during a test is localized to the test to allow for parallel test execution
- All data created during or for a test gets cleaned up after tests completed

For more complex applications, unit tests also ensure:
- that multi-threading works as intended,
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
- Book The Art of Unit Testing: With Examples in .NET - by Roy Osherove: https://www.goodreads.com/book/show/6487349-the-art-of-unit-testing
