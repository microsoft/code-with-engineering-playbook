# Python Code Reviews

## Style Guide

[CSE](../CSE.md) developers follow the [PEP8 style guide](https://pep8.org/) with [type hints](https://www.python.org/dev/peps/pep-0484/). The use of type hints throughout paired with type hint checking avoids common errors that are tricky to debug.

## Linters and related tools

[CSE](../CSE.md) projects should check Python code with automated tools.

### Pylint

[Pylint](https://www.pylint.org/) is the most common linter used for python.  It verifies adherance to the PEP8 style guide but also performs a few more checks.

```bash
pip install pylint
```

### Black

[Black](https://black.readthedocs.io/en/stable/) is an unappologetic code formatting tool. It removes all need from `pycodestyle` nagging about formatting so the team can focus on content vs style. It is however not possible to configure black for your own style needs.

```bash
pip install black
```

### Pyflakes

[Pyflakes](https://github.com/PyCQA/pyflakes) is a fast static linter that verifies logicstic errors like the syntax tree of each file.

```bash
pip install pyflakes
```

### Pycodestyle

[pycodestyle](https://github.com/PyCQA/pycodestyle) is the PEP8 official linter.

```bash
pip install pycodestyle
```

### Pydocstyle

[pydocstyle](https://github.com/PyCQA/pydocstyle) verifies the use of docstring conventions per [PEP 257](https://www.python.org/dev/peps/pep-0257/).

```bash
pip install pydocstyle
```

### Flake8

[Flake8](https://pypi.org/project/flake8/) is an option for teams who want a single wrapper for running Pyflakes and pycodestyle.

```bash
pip install flake8
```

## VS Code Extensions

### Python

The [Python language extension](https://marketplace.visualstudio.com/items?itemName=ms-python.python) is the base extension you should have installed for python development with VS Code. It enables among other things, intellisense, debugging, linting (with the above linters), testing with pytest, code formatting with black or autopep8 etc.

### Pyright

The [Pyright extension](https://marketplace.visualstudio.com/items?itemName=ms-pyright.pyright) augments VS Code with static type checking when you use type hints

```python
def add(first_value: int, second_value: int) -> int:
    return first_value + second_value
```

## Unit Testing

### Unittest

[Unittest](https://docs.python.org/3/library/unittest.html) is pythons built in unit testing framework that provides the basics for unit testing: asserts, fixtures, mocks, etc. Tests can be run using:

```bash
python -m unittest
```

### Pytest

[Pytest](https://docs.pytest.org/en/latest/) is a unit testing framework on top of unittest that provides a simpler way to create unit tests in python without the need for unittest classes.  It is usually the preferred unittest framework for python.

```bash
pip install pytest
```

You can optionally parameterizise test functions

### Pytest-mock

[Pytest-mock](https://github.com/pytest-dev/pytest-mock/) is a mocking/stubbing framework that works with Pytest. Use this to mock out OS calls, off-box calls, and other calls that would unnecessarily broaden the scope of unit tests.

```bash
pip install pytest-mock
```

## Code Review Checklist

In addition to the [Code Review Checklist](../readme.md) you should also look for these python specific code review items

1. [ ] Are all new packages used included in requirements.txt
2. [ ] Do funcitons use type hints, and are there any type hint errors?
3. [ ] Is the code readable and using pythonic constructs wherever possible.
