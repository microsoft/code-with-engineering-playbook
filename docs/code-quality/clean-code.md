# Clean Code

Clean Code is a book by Robert C. Martin, also known as Uncle Bob, that presents a set of principles and best practices for writing high-quality and maintainable code. The book covers topics such as naming, functions, comments, formatting, error handling, testing, and refactoring. The goal of clean code is to create software that is not only functional but also readable, understandable, and efficient throughout its lifecycle.

Whilst we recommend reading the book to hear Robert's thoughts in full, we've summarised some patterns and practices that are critical to writing clean code.

## The Total Cost of Owning a Mess

TODO

## Practices

### Meaningful Names

> Liam's brain dump: Use meaningful, descriptive, and consistent names for variables, functions, classes, and modules. Avoid names that are too long, too short, or ambiguous. Use nouns for classes, verbs for functions, and camelCase for variables. Avoid using prefixes or suffixes that are redundant or misleading. Use domain-specific terminology and avoid abbreviations or acronyms that are not widely known or understood.

For example, use `name` instead of `strName`, `theName`, or `n`.
```c#
string name = "John"; // Good
string strName = "John"; // Bad
string theName = "John"; // Bad
string n = "John"; // Bad
```

### Functions

> Liam's brain dump: Write short, simple, and focused functions that do one thing well. Each function should have a clear and expressive name that describes its purpose. Use as few parameters as possible, and avoid output parameters or side effects. Prefer returning values over modifying global variables or state. Use exceptions to handle errors, and wrap external APIs or libraries in your own functions.

For example, write a function called `CalculateInterest` that takes `principal`, `rate`, and `time` as parameters and returns the interest amount, instead of a function called `Calc` that takes an array of numbers and modifies a global variable called `result`.
```c#
public int CalculateInterest(int principal, double rate, int time)
{
    return principal * rate * time;
} // Good

public void Calc(int[] numbers)
{
    result = numbers[0] * numbers[1] * numbers[2];
} // Bad
```

### Comments

> Liam's brain dump: Write comments that explain why the code does something, not what it does or how it does it. Use comments to clarify complex or obscure code, to provide additional context or information, or to warn about potential pitfalls or limitations. Avoid writing comments that are redundant, outdated, or misleading. Prefer writing self-documenting code that expresses its intent through meaningful names and clear structure. For example, write a comment that explains why you need to check for a null value, instead of a comment that repeats the code logic or the function name.

### Formatting

> Liam's brain dump: Format your code in a consistent and readable way that follows the established coding standards and conventions of your language, framework, or project. Use indentation, spacing, and line breaks to separate and group code blocks. Use comments and blank lines to create visual sections and headings. Align and order your code elements logically and intuitively. Use tools or plugins to automate or enforce code formatting. For example, format your code using Prettier, ESLint, or Black, depending on your language and preferences.

### Error Handling

> Liam's brain dump: Use exceptions to handle errors, and throw them as soon as possible. Use descriptive and specific error messages that provide useful information for debugging and recovery. Use the built-in exception types of your language, or create your own custom exceptions if needed. Avoid using return codes or flags to indicate errors, as they can be easily ignored or misinterpreted. Use the `try-catch-finally` or `try-with-resources` blocks to ensure proper cleanup and release of resources. For example, use a `FileNotFoundException` to indicate that a file could not be found, and wrap your file operations in a `try-with-resources` block to ensure that the file is closed regardless of the outcome.

### Testing

> Liam's brain dump: Write tests that verify the functionality, quality, and performance of your code. Use a testing framework or tool that supports automated, repeatable, and isolated testing. Write unit tests that test each function or module in isolation, and integration tests that test the interactions and dependencies between different parts of your system. Write test cases that cover both the normal and the edge cases, and use descriptive and meaningful names for your tests. Use code coverage tools to measure how much of your code is tested, and aim for a high percentage of coverage. For example, use JUnit, PyTest, or Mocha, depending on your language and preferences, and write tests that follow the AAA pattern: Arrange, Act, Assert.

You can find out more information about Automated Testing [here](../automated-testing/).