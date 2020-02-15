# C# Code Reviews

## Style Guide

[CSE](../../CSE.md) developers follow Microsoft's [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) and, where applicable, Microsoft's [Secure Coding Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/security/secure-coding-guidelines).

## Linters

[CSE](../../CSE.md) projects should check code style with the [StyleCop Analyzers for the .NET Compiler Platform](https://github.com/DotNetAnalyzers/StyleCopAnalyzers). The minimum rules set teams should adopt is the [Managed Recommended Rules](https://msdn.microsoft.com/en-us/library/dd264893.aspx) rule set.

Reference: [Setting up code analysis for a project](https://docs.microsoft.com/en-us/visualstudio/code-quality/code-analysis-for-managed-code-overview).

## Code Review Checklist

* [ ] Is framework version of code compatible with the target system
* [ ] Does this code make correct use of [asynchronous programming constructs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/#BKMK_AsyncandAwait), including proper use of ```await``` and ```Task.WhenAll```?
* [ ] Are the [middlewares](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/index?view=aspnetcore-2.1&tabs=aspnetcore2x) included in this project configured correctly?
* [ ] Does the code [handle exceptions correctly](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions)?
* [ ] Is package management being used (NuGet) instead of committing DLLs?
* [ ] Does this code us LINQ appropriately? Pulling LINQ into a project to replace a single short loop or in ways that do not perform well are usually not appropriate.
