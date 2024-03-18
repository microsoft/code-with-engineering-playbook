# Readable Code

> "Any fool can write code that a computer can understand. Good programmers write code that humans can understand." - Martin Fowler

TODO

## Practices

### Meaningful Names

> Liam's brain dump: Use meaningful, descriptive, and consistent names for variables, functions, classes, and modules. Avoid names that are too long, too short, or ambiguous. Use nouns for classes, verbs for functions, and camelCase for variables. Avoid using prefixes or suffixes that are redundant or misleading. Use domain-specific terminology and avoid abbreviations or acronyms that are not widely known or understood.

Highlight intention-revealing names.

For example, use `name` instead of `strName`, `theName`, or `n`.
```c#
string n = "John"; // Bad
string strName = "John"; // Bad
string theName = "John"; // Bad
string name = "John"; // Okay
string employeeName = "John"; // Good
```

> Switch to to List of products. Good name "catalogue" or "inventory".

### Comments

> Liam's brain dump: Write comments that explain why the code does something, not what it does or how it does it. Use comments to clarify complex or obscure code, to provide additional context or information, or to warn about potential pitfalls or limitations. Avoid writing comments that are redundant, outdated, or misleading. Prefer writing self-documenting code that expresses its intent through meaningful names and clear structure. For example, write a comment that explains why you need to check for a null value, instead of a comment that repeats the code logic or the function name.

### Formatting

> Liam's brain dump: Format your code in a consistent and readable way that follows the established coding standards and conventions of your language, framework, or project. Use indentation, spacing, and line breaks to separate and group code blocks. Use comments and blank lines to create visual sections and headings. Align and order your code elements logically and intuitively. Use tools or plugins to automate or enforce code formatting. For example, format your code using Prettier, ESLint, or Black, depending on your language and preferences.