# C\# Example Rules Classification

This is an example of rules classifications for reviewing and reducing technical debt. This example is for C# and was used on a real life case, to improve the quality of an existing code base.
For more information, please read [this document](README.md) about technical debt.

## Rules, organized per category:

## Notes:

- C#: In creating this list of rules: Code Analysis (FxCop) and Style Analysis (StyleCop) were our starting point

We used the documentation listed in the derived from section to specify some rules or add some that are not part of FxCop and StyleCop.

- Tools to automate detection of quality improvements opportunities:
  - NETAnalyzers - Fxcop (.NET Analyzers): [.NET Analyzers Quality Rules](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/)
  - NETAnalyzers - StyleCop: [StyleCop Style Rules](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/)

## Testing:

| Rule name                                                                               | Invasive | Core | Desc                                                                                                                                                                                                                                       | Enhanced Guidance                                                                                                                |
| :-------------------------------------------------------------------------------------- | :------- | :--- | :----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | :------------------------------------------------------------------------------------------------------------------------------- |
| Are functional integration tests automated                                              | N        | Y    | The code should have automated functional integration tests                                                                                                                                                                                |                                                                                                                                  |
| Make sure tests are sensible and valid assumptions are made.                            | N        | Y    | Tests should have a clear goal                                                                                                                                                                                                             |                                                                                                                                  |
| Make sure edge cases are handled                                                        | N        | Y    | When writing a test, you can cover 100% of the code without test all cases. The test should cover edge cases                                                                                                                               |                                                                                                                                  |
| Aim for 80% unit test coverage.                                                         | N        | Y    | We should keep this as informational until we reach the number                                                                                                                                                                             |                                                                                                                                  |
| Are there appropriate negative tests written?                                           | N        | Y    | Negative tests validate wrong inputs and check if they are handled correctly                                                                                                                                                               | [Wikipedia - Negative Testing](https://en.wikipedia.org/wiki/Negative_testing)                                                                                   |
| Tests should be named [MethodName]\_[Scenario]\_[ExpectedBehavior]                      | N        | Y    | Following a pattern for test names helps with understanding what the test does                                                                                                                                                             |                                                                                                                                  |
| Do tests follow Arrange, Act, Assert?                                                   | N        | Y    | Following this pattern helps with understanding what the test does                                                                                                                                                                         | [Best practices for writing unit tests - .NET](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices) |
| Is there logic in the test?                                                             | N        | Y    | The test should limit itself to testing one use cases. Most of the time when there is logic, it means the test is testing multiple cases. Having logic in a test also increases the chance for it to give false positive or false negative | [Best practices for writing unit tests - .NET](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices) |
| Are there Thread Sleeps in the test?                                                    | N        | Y    | A test should not use thread.sleep                                                                                                                                                                                                         | [Playbook: Unit Testing](../automated-testing/unit-testing) |
| Unit tests: Does it call third party APIs or read off of disk? Are dependencies mocked? | N        | Y    | A unit test should only test the logic of the function it is testing. If the function is calling dependencies, they should be mocked.                                                                                                      | [Playbook: Unit Testing](../automated-testing/unit-testing) |
| The code should not be tightly coupled                                                  | Y        | N    | The code should not be tightly coupled to make it easier to test                                                                                                                                                                           |                                                                                                                                  |
| Are component integration tests automated?                                              | N        | N    |                                                                                                                                                                                                                                            |                                                                                                                                  |

## Observability

| Rule name                                                                                  | Invasive | Core | Desc                                                                                                                                        | Enhanced Guidance                                                                                                                                                                                                             |
| :----------------------------------------------------------------------------------------- | :------- | :--- | :------------------------------------------------------------------------------------------------------------------------------------------ | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Does this code include telemetry (metrics, tracing and logging) instrumentation?           | N        | Y    | Observability is key to understand and debug an issue in production. As a dev, do I have enough information to debug a system failure?      | [code-with-engineering-playbook/log-vs-metric.md at master · microsoft/code-with-engineering-playbook (github.com](../observability/log-vs-metric.md))   |
| Does the code include usage metrics?                                                       | N        | N    | Usage metrics are also called functional metrics. They help understand the real usage of a specific platform (what feature is used?)        |                                                                                                                                                                                                                               |
| Is the observability implementation using correlation ids?                                 | Y        | Y    | Correlation ids helps with grouping observability traces that relates to on query together. This increases the chances of debugging success | [code-with-engineering-playbook/correlation-id.md at master · microsoft/code-with-engineering-playbook (github.com)](../observability/correlation-id.md) |
| Are the dashboards for observability created using IaC principles? (Observability As Code) | N        | N    | This improves the ability to redeploy the observability dashboards at a later point, if needed.                                             | [code-with-engineering-playbook/observability at master · microsoft/code-with-engineering-playbook (github.com)](../observability#observability-as-code) |

## Code quality

## Code Analysis (fxcop) for C\#

Following the recommendations of using and FxCop (now Microsoft.CodeAnalysis.NetAnalyzers) per: [playbook](../code-reviews/recipes/CSharp.md).

This model allows for suppressions and their justification in the code, providing reviewers the ability to reason about suppressions and whether they are appropriate.

## Error handling

| Rule name                                               | Invasive | Core | Desc                                                                                                                                                                                                                                                            | Enhanced Guidance                                                                                                                                                                  |
| :------------------------------------------------------ | :------- | :--- | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Are exceptions used for normal logic flow?              | Y        | N    | Exception should not be used for normal logic flow. As an example, code should not try to access a file, expecting a FileNotFoundException if the file does not exist. The code logic should check for the file availability prior to trying to access the file | [Best Practices for Exceptions](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions)                                                                                          |
| Are classes designed so that exceptions can be avoided? | Y        | N    | A class can provide methods or properties that enable you to avoid making a call that would trigger an exception                                                                                                                                                | [Best Practices for exceptions - .NET](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions#design-classes-so-that-exceptions-can-be-avoided) |

## C# code guidelines (outside of fxcop and stylecop)

| Rule name                                                                                                                                                         | Invasive | Core | Desc                                                                                                                             | Enhanced Guidance |
| :---------------------------------------------------------------------------------------------------------------------------------------------------------------- | :------- | :--- | :------------------------------------------------------------------------------------------------------------------------------- | :---------------- |
| Does the code use LINQ appropriately? Pulling LINQ into a project to replace a single short loop or in ways that do not perform well are usually not appropriate. | N        | Y    | Linq should be used when solving one or more complex problems                                                                    |                   |
| Does this code properly validate arguments sanity (i.e. CA1062)? Consider leveraging extensions such as Ensure.That                                               | N        | Y    | The arguments in a function should be checked to ensure that it will not break the code or enable a bad usage of the application |                   |

## Functionality

| Rule name                                                       | Invasive | Core | Desc                                                                                                                                                                                                                                   | Enhanced Guidance                                                                                                                                                                                                                  |
| :-------------------------------------------------------------- | :------- | :--- | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Is there parallel programming that could cause race conditions? | Y        | N    | Does this code make correct use of asynchronous programming constructs, including proper use of await and Task.WhenAll including CancellationTokens? Is the code subject to concurrency issues? Are shared objects properly protected? | [Async Overview](https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/potential-pitfalls-in-data-and-task-parallelism) and [C# Async Antipatterns (markheath.net)](https://markheath.net/post/async-antipatterns) |
| Are out of process calls optimized?                             | Y        | N    | Is data cached from Databases / Services? Are calls to APIs optimized?                                                                                                                                                                 |                                                                                                                                                                                                                                    |

## Style & Readability

## Static Analysis (StyleCop), for C\#

  Following the recommendations of using StyleCop per: playbook. This model allows for suppressions and their justification in the code, providing reviewers the ability to reason about suppressions and whether they are appropriate.

## Complexity

| Rule name                                        | Invasive | Core | Desc                                                                              | Enhanced Guidance |
| :----------------------------------------------- | :------- | :--- | :-------------------------------------------------------------------------------- | :---------------- |
| Is the single responsibility principle followed? | Y        | N    | Single-responsibility principle - Wikipedia                                       |                   |
| Is the function too complex?                     | Y        | N    |                                                                                   |                   |
| Is the functionality used?                       | N        | Y    | Should not be invasive, but removing the functionality needs to be done carefully |                   |

## Style and Readability

| Rule name                                                                                           | Invasive                                                            | Core | Desc | Enhanced Guidance                                                                                                                                                       |
| :-------------------------------------------------------------------------------------------------- | :------------------------------------------------------------------ | :--- | :--- | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Do the names for functions, variables, etc. make sense? Are they self-documenting understandably?   | N                                                                   | Y    |      | [C# Coding Conventions - C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions#naming-conventions) |
| Can the code be understood easily by code readers? Does the code has the right amount of commenting | Depend on the size of the scope. Large = Y and Small (function) = N | N    |      |                                                                                                                                                                         |
| Is there a readme for another developer to understand each module?                                  | N                                                                   | N    |      | One readme per module                                                                                                                                                   |

## Re-usability

| Rule name                                           | Invasive | Core | Enhanced Guidance                                                                                |
| :-------------------------------------------------- | :------- | :--- | :----------------------------------------------------------------------------------------------- |
| Are patterns and components reused when applicable? | Y        | N    | Accessing the database the same way? Are rest calls done in a consistent way across the codebase |
| Is it modular enough?                               | Y        | N    | Is this class reusable?                                                                          |

## Security

| Rule name                  | Keep? | Invasive | Core | Desc | Enhanced Guidance |
| :------------------------- | :---- | :------- | :--- | :--- | :---------------- |
| All issues raised by FxCop |       |          | Y    |      |                   |
| Secrets in the code        |       |          | Y    |      |                   |
