# Python Code Reviews

## Python Style Guide

[CSE](../CSE.md) developers follow [Google's Python Style Guide](https://google.github.io/styleguide/pyguide.html).

## Linters

[CSE](../CSE.md) projects should check Python code with automated tools. ```pylint``` is the minimum, but we prefer to run three different tools:

### [```Pyflakes```](https://github.com/PyCQA/pyflakes)

Pyflakes is a fast static analysis tool that identifies common errors in Python code.

### [```pycodestyle```](https://github.com/PyCQA/pycodestyle)

We follow the [PEP 8](https://www.python.org/dev/peps/pep-0008/) style guide.

### [```pydocstyle```](https://github.com/PyCQA/pydocstyle)

We follow the [PEP 257](https://www.python.org/dev/peps/pep-0257/) Docstring conventions.

### [```Flake8```](https://pypi.org/project/flake8/)

Flake8 is an option for teams who want a single wrapper for running Pyflakes and pycodestyle.

## Secure Coding

[CSE](../CSE.md) projects should follow secure coding practices adhering to the ethos of "Secure by Design". Security vulnerabilities can be addressed during the development phase by utilizing tools like:

### [```Bandit```](https://github.com/PyCQA/bandit)

Bandit is a tool designed to find common security issues in Python code.

## Starter Code Review Checklist

