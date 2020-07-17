# Unit Testing

Unit testing is a fundamental tool in every developer's toolbox. Unit tests not only help us test our code, they
encourage good design practices, reduce the chances of bugs reaching production, and can even serve as examples or
documentation on how code functions. Properly written unit tests can also improve developer efficiency.

Unit testing also is one of the most commonly misunderstood forms of testing. Unit testing refers to a very specific
type of testing; a unit test should be:

- **Provably reliable** - should be 100% reliable so failures indicate a bug in the code
- **Fast** - should run in milliseconds, a whole unit testing suite shouldn't take longer than a couple seconds
- **Isolated** - removing all external dependencies ensures reliability and speed

<!-- The document should start with a brief overview about the test type and what is covered in this document, the goal here is to provide a high-level description to help the reader understand what is covered to decide whether to continue reading or not. -->

## Why Unit Testing

It is no secret that writing unit tests is hard, and even harder to write well. Writing unit tests also increases the
development time for every feature. So why should we bother writing them?

- Reduces costs by catching bugs earlier
- Increases developer confidence in changes
- Speeds up developer inner loop
- Documentation as code

Still not sold? See all the [detailed descriptions of the points above](./why-unit-tests.md)

## Unit Testing Design Blocks [The What]
<!-- In this section, describe the test type, its components, and how they interact to solve the problem described above. -->

Unit testing is the lowest level of testing and as such generally has few components and dependencies.

The **system under test** is the "unit" we are testing. Generally these are methods or functions, but depending
on the language these could be different. In general you want the unit to be as small as possible though.

Most languages also have a wide suite of **unit testing frameworks** and test runners. These test frameworks have
a wide range of functionality, but the base functionality should be a way to organize your tests and run them quickly.

Finally there is your **unit test code**; unit test code is generally short and simple, preferring repetition to adding
layers and complexity to the code.

## Applying the Unit Testing [the how]

TODO: intro

### Techniques

To illustrate some of the unit testing techniques, let's start with an example.

#### Abstraction

#### Dependency Injection

Dependency injection is a technique which allows us to extract dependencies from our code. In a normal use-case of a
dependant class, the dependency is constructed and used within the system under test. This creates a hard dependency
between the two classes, which can make it particularly hard to test in isolation. Dependencies could be things like
classes wrapping a REST API, or even something as simple as file access. By injecting the dependencies into our system
rather than constructing them, we have "inverted control" of the dependency. You may see "Inversion of Control" and
"Dependency Injection" used as separate terms, but it is very hard to have one and not the other, with some arguing
that [Dependency Injection is a more specific way of saying inversion of control](https://martinfowler.com/articles/injection.html#InversionOfControl).

#### Test-Driven Development

Test-Driven Development (TDD) is less a technique in how your code is designed, but a technique that will lead you to a
testable design from the start. There are many forms of test-driven development, but the underlying point is that you
write your test code first and then write the system under test to match the APIs defined in the test. This way all the
test design is done up front and by the time you finish writing your system code, you are already at 100% test pass rate
and test coverage.

One common method of writing a class in a TDD fashion is called Red-Green-Refactor. For more information on
Red-Green-Refactor and an example into using TDD, see the page on [Test-Driven Development](./tdd.md)

### Best Practices

- Arrange/Act/Assert
- Test naming FunctionName_StateUnderTest_Result

### Things to Avoid

- sleeps
- reading from disk
- calling APIs

<!-- In this section, describe what good testing looks like for this test type, discuss some of the best practices, discuss pitfalls to avoid, and finally discuss some of the common tools used to apply the test type, if any. -->

## Unit Testing Frameworks and Tools

<!-- In this section, describe various test frameworks and tools, their pros and cons, and provide with the links to where to get more information. -->

### Test Frameworks

TODO: Disclaimer. Should this just be removed?

| Name                                         | Languages                  | Comments                  |
| -------------------------------------------- | -------------------------- | ------------------------- |
| [xUnit.net](https://xunit.net/)              | .NET Framework / .NET Core |                           |
| [NUnit](https://nunit.org/)                  | .NET Framework / .NET Core |                           |
| [Jest](https://jestjs.io/)                   | Javascript/Typescript      | Usually paired with React |
| [Mocha](https://mochajs.org/)                | Javascript/Typescript      |                           |
| [pytest](https://docs.pytest.org/en/latest/) | Python                     |                           |
| [JUnit](https://junit.org/junit5/)           | Java                       |                           |
| [Pester](https://pester.dev/)                | Powershell                 |                           |

### Mock Frameworks

Many projects start with both a unit test framework, and also add a mock framework. While mocking frameworks have their
uses and sometimes can be a requirement, it should not be something that is added without considering the broader
implications and risks associated with heavy usage of mocks.

To see if mocking is right for your project, or if a mock-free approach is more appropriate, see the page on [mocking](mocking.md).

## Conclusion

Unit testing is extremely important, but it is also not the silver bullet; having proper unit tests is just a part of a
well-tested system. 

<!-- In conclusion, provide the final thoughts on why and how this type of test can help with your next customer engagement, what best practices and recommendations that can be withdrawn from the case studies and research. -->

## Resources

<!-- List additional readings about this test type for those that would like to dive deeper. -->
