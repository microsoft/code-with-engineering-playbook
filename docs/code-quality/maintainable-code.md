# Maintainable Code

TODO

## Practices

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

### Error Handling

> Liam's brain dump: Use exceptions to handle errors, and throw them as soon as possible. Use descriptive and specific error messages that provide useful information for debugging and recovery. Use the built-in exception types of your language, or create your own custom exceptions if needed. Avoid using return codes or flags to indicate errors, as they can be easily ignored or misinterpreted. Use the `try-catch-finally` or `try-with-resources` blocks to ensure proper cleanup and release of resources. For example, use a `FileNotFoundException` to indicate that a file could not be found, and wrap your file operations in a `try-with-resources` block to ensure that the file is closed regardless of the outcome.