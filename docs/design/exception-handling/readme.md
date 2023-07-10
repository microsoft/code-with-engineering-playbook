## Exception constructs

Almost all language platforms offer a construct of exception or equivalent to handle error scenarios. The underlying platform, used libraries or the authored code can "throw" exceptions to initiate an error flow. Some of the advantages of using exceptions are - 

1. Abstract different kind of errors
2. Breaks the control flow from different code structures
3. Navigate the call stack till the right catch block is identified
4. Automatic collection of call stack
5. Define different error handling flows thru multiple catch blocks
6. Define finally block to cleanup resouces 

Here is some guidance on exception handling in .Net

[C# Exception fundamentals](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/)

[Handling exceptions in .Net](https://learn.microsoft.com/en-us/dotnet/standard/exceptions/#exceptions-vs-traditional-error-handling-methods)

## Custom exceptions

Although the platform offers numerous types of exceptions, often we need custom defined exceptions to arrive at an optimal low level design for error handling. The advantages of using custom exceptions are - 

1. Define exceptions specific to business domain of the requirement. E.g. InvalidCustomerException
2. Wrap system/platform exceptions to define more generic system exception so that overall code base is more tech stack agnostic. E.g DatabaseWriteException which wraps MongoWriteException. 
3. Enrich the exception with more information about the code flow of the error. 
4. Enrich the exception with more information about the data context of the error. E.g. RecordId in property in DatabaseWriteException which carries the Id of the record failed to update.
5. Define custom error message which is more business user friendly or support team friendly. 
