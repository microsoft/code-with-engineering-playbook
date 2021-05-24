# Code

You might have heard more than once that **you should write self-documenting code**. This doesn't mean that you should never comment your code.

There are two types of code comments, implementation comments and documentation comments.

## Implementation comments

They are used for internal documentation, and are intended for anyone who may need to maintain the code in the future, including your future self.

There can be single line and multi-line comments (e.g., [C# Comments](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/lexical-structure#comments)). Comments are human-readable and not executed, thus ignored by the compiler. So you could potentially add as many as you want.

Now, the use of these comments is often considered a code smell. If you need to clarify your code, that may mean the code is too complex. So you should work towards the removal of the clarification by making the code simpler, easier to read, and understand. Still, these comments can be useful to give overviews of the code, or provide additional context information that is not available in the code itself.

## Documentation comments

Doc comments are a special kind of comment, added above the definition of any user-defined type or member, and are intended for anyone who may need to use those types or members in their own code.

If, for example, you are building a library or framework, doc comments can be used to generate their documentation. This documentation should serve as API specification, and/or programming guide.

Doc comments won't be included by the compiler in the final executable, as with single and multi-line comments.

In **C#**, doc comments can be processed by the compiler to generate XML documentation files. These files can be distributed alongside your libraries so that Visual Studio and other IDEs can use IntelliSense to show quick information about types or members. Additionally, these files can be run through tools like [DocFx](https://dotnet.github.io/docfx/) to generate API reference websites.

More information:

- [C# guide / C# Concepts / Documenting your code: Document your C# code with XML comments](https://docs.microsoft.com/en-us/dotnet/csharp/codedoc).
- [C# guide / C# Lenguage reference / C# specification: Documentation comments](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments).
- [C# guide / C# Programming Guide / XML documentation comments: Overview](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/).

In other languages, you may require external tools. For example, **Java** doc comments can be processed by Javadoc tool to generate HTML documentation files.

More information:

- [How to Write Doc Comments for the Javadoc Tool](https://www.oracle.com/technical-resources/articles/java/javadoc-tool.html)
- [Javadoc Tool](https://www.oracle.com/java/technologies/javase/javadoc-tool.html#javadocdocuments)
