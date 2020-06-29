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

Writing unit tests help encourage testable design

- TDD
- Dependency Injection 
- Best practices
  - Arrange/Act/Assert
  - Test naming FunctionName_StateUnderTest_Result

What not to do
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
