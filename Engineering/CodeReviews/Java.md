# Java Code Reviews

Please refer to the general [CSE](../../CSE.md) [code review guidance](../CodeReviews.md) as well. Provided here is a check list of Java specific items to help you with your code reviews.

## Code Style

Choose a code style (or coding standard) for your project, stick to it and enforce it. There are several accepted ones to choose from. Good places to start are:

* [Google Java Style Guide](https://checkstyle.org/styleguides/google-java-style-20170228.html)
* [Oracle's Code Conventions for the Java Programming Language](https://www.oracle.com/technetwork/java/javase/documentation/codeconvtoc-136057.html)

To enforce a coding standard, you can lean on a number of tools for this purpose:

* [checkstyle](http://checkstyle.sourceforge.net/) - "_a development tool to help programmers write Java code that adheres to a coding standard. It automates the process of checking Java code to spare humans of this boring (but important) task._"
* [PMD](https://pmd.github.io/) - "_a source code analyzer. It finds common programming flaws like unused variables, empty catch blocks, unnecessary object creation, and so forth._"

## Code Quality

Code quality goes hand in hand with code style. Tools like PMD not only uncover style issues, they also point to code quality issues.

You can also use other tools to watch code quality:

* [FindBugs](http://findbugs.sourceforge.net/) - "_a program which uses static analysis to look for bugs in Java code._"

### Code Quality Literature and Guide Lines

There are plenty of good sources to help you with advice and guidance around code quality in Java.

Must read books as a reference for your code reviews include:

* [*Clean Code* by Robert C. Martin](https://www.safaribooksonline.com/library/view/clean-code/9780136083238/)
* [*Effective Java* by Joshua Bloch](https://www.safaribooksonline.com/library/view/effective-java-3rd/9780134686097/)

DZone has compiled a [*Java Code Review Checklist*](https://dzone.com/articles/java-code-review-checklist) from items of the above books.

Please also consider using [Oracle's *Secure Coding Guidelines for Java SE*](https://www.oracle.com/technetwork/java/seccodeguide-139067.html) in your code reviews.