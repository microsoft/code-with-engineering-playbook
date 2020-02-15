# Python Code Reviews

## Style Guide

[CSE](../CSE.md) developers follow the [PEP8 style guide](https://pep8.org/) with [type hints](https://www.python.org/dev/peps/pep-0484/). The use of type hints throughout paired with linting and type hint checking avoids common errors that are tricky to debug.

[CSE](../CSE.md) projects should check Python code with automated tools.

Linting should be added to build validation, and both linting and code formatting can be added to your pre-commit hooks and VS Code.

## Linters

The 2 most popular python linters are [Pylint](https://www.pylint.org/) and [Flake8](https://pypi.org/project/flake8/).  Both check adherance to **PEP8** but vary a bit in what other rules they check.  In general **Pylint** tends to be a bit more stringent and give a few more false positives but both are good options for linting python code.

Both **Pylint** and **Flake8** can be configured in VS Code using the  VS Code **python extension**

### Flake8

Flake8 is a simple and fast wrapper around [Pyflakes](https://github.com/PyCQA/pyflakes) (for logig errors), [pycodestyle](https://github.com/PyCQA/pycodestyle) (for pep8) and [pydocstyle](https://github.com/PyCQA/pydocstyle) (for [doc strings](https://www.python.org/dev/peps/pep-0257/)).

Install Flake8

```bash
pip install flake8
```

Run Flake8

```bash
flake8 .    # lint the whole project
```

### Pylint

Install Pylint

```bash
pip install pylint
```

Run Pylint

```bash
pylint src  # lint the source directory
```

## Automatically format python code

### Black

[Black](https://github.com/psf/black) is an unappologetic code formatting tool. It removes all need from `pycodestyle` nagging about formatting so the team can focus on content vs style. It is however not possible to configure black for your own style needs.

```bash
pip install black
```

Format python code

```bash
black [file/folder]
```

### Autopep8

[Autopep8](https://github.com/hhatto/autopep8) is more lenient and allows more configuration if you want less stringent formatting.

```bash
pip install autopep8
```

Format python code

```bash
autopep8 [file/folder] --in-place
```

### yapf

[yapf](https://github.com/google/yapf) Yet Another Python Formatter is a python formatter from Google based on ideas from gofmt.  This is also more configurable and a good option for automatic code formatting.

```bash
pip install yapf
```

Format python code

```bash
yapf [file/folder] --in-place
```

## VS Code Extensions

### Python

The [Python language extension](https://marketplace.visualstudio.com/items?itemName=ms-python.python) is the base extension you should have installed for python development with VS Code. It enables among other things, intellisense, debugging, linting (with the above linters), testing with pytest or unittest, and code formatting with the formatters mentioned above.

### Pyright

The [Pyright extension](https://marketplace.visualstudio.com/items?itemName=ms-pyright.pyright) augments VS Code with static type checking when you use type hints

```python
def add(first_value: int, second_value: int) -> int:
    return first_value + second_value
```

## Build validation

Linting and testing should be validated as part of the Pull Request. This is an example of a [build validation YAML configuration](\build-validation\build-python.yml) with **Flake8** and **PyTest** that can be used in an AzDO pipeline to protect your develop and master branches.

## Pre-commit hooks

Pre-commit hooks allow you to format and lint code locally before the pull request is issued.

Adding pre-commit hooks for your python repository is easy using the pre-commit package

1. Install pre-commit and add to the requirements.txt

    ```bash
    pip install pre-commit
    ```

2. Add a **.pre-commit-config.yaml** file in the root of the repository, with the desired pre-commit actions

    ```yaml
    repos:
    -   repo: https://github.com/ambv/black
        rev: stable
        hooks:
        - id: black
        language_version: python3.6
    -   repo: https://github.com/pre-commit/pre-commit-hooks
        rev: v1.2.3
        hooks:
        - id: flake8
    ```

3. Each individual developer that wants to set up pre-commit hooks can then run

    ```bash
    pre-commit install
    ```

At the next attempted commit any lint failures will block the commit.

> Note: Installing pre-commit hooks is volontary and done by each developer individually. Thus it is not a replacement for build validation on the server

## Code Review Checklist

In addition to the [Code Review Checklist](../readme.md) you should also look for these python specific code review items

* [ ] Are all new packages used included in requirements.txt
* [ ] Do funcitons use type hints, and are there any type hint errors?
* [ ] Is the code readable and using pythonic constructs wherever possible.
