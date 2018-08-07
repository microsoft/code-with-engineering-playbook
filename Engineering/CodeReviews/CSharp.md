# C# Code Reviews

## C# Style Guide

[CSE](../CSE.md) developers follow Microsoft's [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) and, where applicable, Microsoft's [Secure Coding Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/security/secure-coding-guidelines).

## Linters

[CSE](../CSE.md) projects should check code style with the [StyleCop Analyzers for the .NET Compiler Platform](https://github.com/DotNetAnalyzers/StyleCopAnalyzers). The minimum rules set teams should adopt is the [Managed Recommended Rules](https://msdn.microsoft.com/en-us/library/dd264893.aspx) rule set.

Documentation on setting up code analysis for a project is provided [here](https://docs.microsoft.com/en-us/visualstudio/code-quality/code-analysis-for-managed-code-overview).

## Starter Code Review Checklist

1. [ ] Does this code make correct use of [asynchronous programming constructs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/#BKMK_AsyncandAwait), including proper use of ```await``` and ```Task.WhenAll```?
1. [ ] Are the [middlewares](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/index?view=aspnetcore-2.1&tabs=aspnetcore2x) included in this project configured correctly?
1. [ ] Does the code [handle exceptions correctly](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions)?
1. [ ] Do new unit tests or changes to unit tests in this code actually test the business logic they purport to test?
1. [ ] Is package management being used (NuGet) instead of committing DLLs?
1. [ ] Does the code in this project use log levels consistently?
1. [ ] Does this code us LINQ appropriately? Pulling LINQ into a project to replace a single short loop or in ways that do not perform well are usually not appropriate.
