# Mocking in Unit Tests

One of the key components of writing unit tests is to remove the dependencies your system has and replacing it with an
implementation you control. The most common method people use as the replacement for the dependency is a mock, and
mocking frameworks exist to help make this process easier.

Many frameworks and articles use different meanings for the differences between test doubles. A test double is a generic
term for any "pretend" object used in place of a real one. This term, as well as others used in this page are the
[definitions provided by Martin Fowler](https://martinfowler.com/articles/mocksArentStubs.html#TheDifferenceBetweenMocksAndStubs).
The most commonly used form of test double is Mocks, but there are many cases where Mocks perhaps are not the best
choice and Fakes should be considered instead.

## Stubs

Most of the time when "mocks" are being used, what is actually being used is a **stub**; a stub simply returns what the
test expects and has no other logic to it. Stubs typically ignore inputs they do not expect or will always return the
same thing. These are usually simple one lined methods that set up the state that the test expects.

Stubs can be useful especially during early development of a system, but since nearly every test requires its own stubs
(to test the different states), this quickly becomes repetitive and involves a lot of boilerplate code. Rarely will you
find a codebase that uses only stubs for mocking, they are usually paired with other test doubles.

Stubs do not require any sort of framework to run, but are usually supported by mocking frameworks to quickly build the
stubs.

### Upsides

- Do not require any framework, easy to set up.

### Downsides

- Can involve rewriting the same code many times, lots of boilerplate.

## Mocks

Fowler describes **mocks** as pre-programmed objects with expectations which form a specification of the calls they are
expected to receive. In other words, mocks are a replacement object for the dependency that has certain expectations
that are placed on it; those expectations might be things like validating a sub-method has been called a certain number
of times or that arguments are passed down in a certain way.

Mocking frameworks are abundant for every language, with some languages having mocks built into the unit test packages.
They make writing unit tests easy and still encourage good unit testing practices.

The main difference between a mock and most of the other test doubles is that mocks do **behavioral verification**,
whereas other test doubles do **state verification**. With behavioral verification, you end up testing that the
implementation of the system under test is as you expect, whereas with state verification the implementation is not
tested, rather the inputs and the outputs to the system are validated.

The major downside to behavioral verification is that it is tied to the implementation. One of the biggest advantages of
writing unit tests is that when you make code changes you have confidence that if your unit tests continue to pass, that
you are making a relatively safe change. If tests need to be updated every time because the behavior of the method has
changed, then you lose that confidence because bugs could also be introduced into the test code. This also increases the
development time and can be a source of frustration.

For example, let's assume you have a method that you are testing that makes 5 web service calls. With mocks, one of your
tests could be to check that those 5 web service calls were made. Sometime later the API is updated and only a single
web service call needs to be made. Once the system code is changed, the unit test will fail because it expects 5 calls
and not 1. The test needs to be updated, which results in lowered confidence in the change, as well as potentially
introduces more areas for bugs to sneak in.

Some would argue that in the example above, the unit test is not a good test anyway because it depends on the
implementation, and that may be true; but one of the biggest problems with using mocks (and specifically mocking
frameworks that allow these verifications), is that it encourages these types of tests to be written. By not using a
mock framework that allows this, you never run the risk of writing tests that are validating the implementation.

### Upsides

- Easy to write.
- Encourages testable design.

### Downsides to Mocking

- Behavioral testing can present problems with maintainability in unit test code.
- Usually requires a framework to be installed (or if no framework, lots of boilerplate code)

## Fakes

**Fake** objects actually have working implementations, but usually take some shortcut which may make them not suitable
for production. One of the common examples of using a Fake is an in-memory database - typically you want your database
to be save data somewhere between application runs, but when writing unit tests if you have a fake implementation of
your database APIs that are store all data in memory, you can use these for unit tests and not break abstraction as well
as still keep your tests fast.

Writing a fake does take more time than other test doubles, because they are full implementations, and can have
their own suite of unit tests. In this sense though, they increase confidence in your code even more because your test
double has been thoroughly tested for bugs before you even use it as a downstream dependency.

Similarly to mocks, fakes also promote testable design, but unlike mocks they do not require any frameworks to write.
Writing a fake is as easy as writing any other implementation class. Fakes can been included in the test code only, but
many times they end up being "promoted" to the product code, and in some cases can even start off in the product code
since it is held to the same standard with full unit tests. Especially if writing a library or an API that other
developers can use, providing a fake in the product code means those developers no longer need to write their own mock
implementations, further increasing reusability of code.

### Upsides

- No framework needed, is just like any other implementation.
- Encourages testable design.
- Code can be "promoted" to product code, so it is not wasted effort.

### Downsides

- Takes more time to implement.

## Conclusion

Using test doubles in unit tests is an essential part of having a healthy test suite. When looking at mocking frameworks
and using test doubles, it is important to consider the future implications of integrating with a mocking framework from
the start. Sometimes certain features of mocking frameworks seem essential, but usually that is a sign that the code
itself is not abstracted enough if it requires a framework.

If possible, starting without a mocking framework and attempting to create fake implementations will lead to a more
healthy code base, but when that is not possible the onus is on the technical leaders of the team to find cases where
mocks may be overused, rely too much on implementation details, or end up not testing the right things.
