# Why Unit Tests

It is no secret that writing unit tests is hard, and even harder to write well. Writing unit tests also increases the
development time for every feature. So why should we bother writing them?

## Reduce costs

There is no question that the later a bug is found, the more expensive it is to fix; especially so if the bug makes it
into production. A [2008 research study by IBM](ftp://ftp.software.ibm.com/software/rational/info/do-more/RAW14109USEN.pdf)
estimates that a bug caught in production could cost 6 times as much as if it was caught during implementation.

## Increase Developer Confidence

Many changes that developers make are not big features or something that requires an entire testing suite. A strong unit
test suite helps increase the confidence of the developer that their change is not going to cause any downstream bugs.
Having unit tests also helps with making safe, mechanical refactors that are provably safe; using things like
refactoring tools to do mechanical refactoring and running unit tests that cover the refactored code should be enough to
increase confidence in the commit.

## Speed up development

Unit tests take time to write but they also speed up development? While this may seem like a oxymoron, it is one of
the strengths of a unit testing suite - over time it continues to grow and evolve until the tests become an essential
part of the developer workflow.

If the only testing available to a developer is a long running system test, integration tests that require a deployment,
or manual testing, it will increase the amount of time taken to write a feature. These types of tests should be a part of
the "Outer loop"; tests that may take some time to run and validate more than just the code you are writing. Usually
these types of outer loop tests get run at the PR stage or even later during merges into branches.

The Developer Inner Loop is the process that developers go through as they are authoring code. This varies from
developer to developer and language to language but typically is something like code -> build -> run -> repeat. When
unit tests are inserted into the inner loop, developers can get early feedback and results from the code they are
writing. Since unit tests execute really quickly, running tests shouldn't be seen as a barrier to entry for this loop.
Tooling such as [Visual Studio Live Unit Testing](https://docs.microsoft.com/en-us/visualstudio/test/live-unit-testing-start?view=vs-2019)
also help to shorten the inner loop even more.

## Documentation as code

Writing unit tests is a great way to show how the units of code you are writing are supposed to be used. In some ways,
unit tests are better than any documentation or samples because they are (or at least should be) executed with every
build so there is confidence that they are not out of date. Unit tests also should be simple so they are easy to follow.
