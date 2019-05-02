# Python Code Reviews

## Python Style Guide

[CSE](../CSE.md) developers follow [Google's Python Style Guide](https://google.github.io/styleguide/pyguide.html). Note the use of strong typing throughout. Older versions of python allow you to get away without this but type checking avoids common errors that are tricky to debug. 

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

## Unit Testing

### [```Pytest```](https://docs.pytest.org/en/latest/)
Pytest is a simple unit testing framework that provides the basics for unit testing: asserts, fixtures, etc... 

```bash
pip3 install pytest
```

### [```Pytest-mock```](https://github.com/pytest-dev/pytest-mock/)
Mocking/stubbing framework that works with Pytest. Use this to mock out OS calls, off-box calls, and other calls that would unnecessarily broaden the scope of unit tests.

```bash
pip3 install pytest-mock
```

## Starter Code Review Checklist

