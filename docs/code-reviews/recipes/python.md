# Python Code Reviews

## Style Guide

[CSE](../../CSE.md) developers follow the [PEP8 style guide](https://pep8.org/) with [type hints](https://www.python.org/dev/peps/pep-0484/). The use of type hints throughout paired with linting and type hint checking avoids common errors that are tricky to debug.

[CSE](../../CSE.md) projects should check Python code with automated tools.

Linting should be added to build validation, and both linting and code formatting can be added to your pre-commit hooks and VS Code.

## Code Analysis / Linting

The 2 most popular python linters are [Pylint](https://pypi.org/project/pylint/) and [Flake8](https://pypi.org/project/flake8/). Both check adherence to `PEP8` but vary a bit in what other rules they check. In general `Pylint` tends to be a bit more stringent and give more false positives but both are good options for linting python code.

Both `Pylint` and `Flake8` can be configured in VS Code using the VS Code `python extension`.

### Flake8

Flake8 is a simple and fast wrapper around [`Pyflakes`](https://github.com/PyCQA/pyflakes) (for detecting coding errors) and [`pycodestyle`](https://github.com/PyCQA/pycodestyle) (for pep8).

Install `Flake8`

{% raw %}

```bash
pip install flake8
```

{% endraw %}

Add an extension for the [`pydocstyle`](https://github.com/PyCQA/pydocstyle) (for [doc strings](https://www.python.org/dev/peps/pep-0257/)) tool to flake8.

{% raw %}

```bash
pip install flake8-docstrings
```

{% endraw %}

Add an extension for [`pep8-naming`](https://github.com/PyCQA/pep8-naming) (for [naming conventions](https://www.python.org/dev/peps/pep-0008/#naming-conventions) in pep8) tool to flake8.

{% raw %}

```bash
pip install pep8-naming
```

{% endraw %}

Run `Flake8`

{% raw %}

```bash
flake8 .    # lint the whole project
```

{% endraw %}

### Pylint

Install `Pylint`

{% raw %}

```bash
pip install pylint
```

{% endraw %}

Run `Pylint`

{% raw %}

```bash
pylint src  # lint the source directory
```

{% endraw %}

## Automatic Code Formatting

### Black

[`Black`](https://github.com/psf/black) is an unapologetic code formatting tool. It removes all need from `pycodestyle` nagging about formatting, so the team can focus on content vs style. It's not possible to configure black for your own style needs.

{% raw %}

```bash
pip install black
```

{% endraw %}

Format python code

{% raw %}

```bash
black [file/folder]
```

{% endraw %}

### Autopep8

[`Autopep8`](https://github.com/hhatto/autopep8) is more lenient and allows more configuration if you want less stringent formatting.

{% raw %}

```bash
pip install autopep8
```

{% endraw %}

Format python code

{% raw %}

```bash
autopep8 [file/folder] --in-place
```

{% endraw %}

### yapf

[yapf](https://github.com/google/yapf) Yet Another Python Formatter is a python formatter from Google based on ideas from gofmt.  This is also more configurable, and a good option for automatic code formatting.

{% raw %}

```bash
pip install yapf
```

{% endraw %}

Format python code

{% raw %}

```bash
yapf [file/folder] --in-place
```

{% endraw %}

## VS Code Extensions

### Python

The [`Python language extension`](https://marketplace.visualstudio.com/items?itemName=ms-python.python) is the base extension you should have installed for python development with VS Code. It enables intellisense, debugging, linting (with the above linters), testing with pytest or unittest, and code formatting with the formatters mentioned above.

### Pyright

The [`Pyright extension`](https://marketplace.visualstudio.com/items?itemName=ms-pyright.pyright) augments VS Code with static type checking when you use type hints

{% raw %}

```python
def add(first_value: int, second_value: int) -> int:
    return first_value + second_value
```

{% endraw %}

## Build validation

To automate linting with `flake8` and testing with `pytest` in Azure Devops you can add the following snippet to you `azure-pipelines.yaml` file.

{% raw %}

```yaml
trigger:
  branches:
    include:
    - develop
    - master
  paths:
    include:
    - src/*

pool:
  vmImage: 'ubuntu-latest'

jobs:
- job: LintAndTest
  displayName: Lint and Test

  steps:

  - checkout: self
    lfs: true

  - task: UsePythonVersion@0
    displayName: 'Set Python version to 3.6'
    inputs:
      versionSpec: '3.6'

  - script: pip3 install --user -r requirements.txt
    displayName: 'Install dependencies'

  - script: |
      # Install Flake8
      pip3 install --user flake8
      # Install PyTest
      pip3 install --user pytest
    displayName: 'Install Flake8 and PyTest'

  - script: |
      python3 -m flake8
    displayName: 'Run Flake8 linter'

  - script: |
      # Run PyTest tester
      python3 -m pytest --junitxml=./test-results.xml
    displayName: 'Run PyTest Tester'

  - task: PublishTestResults@2
    displayName: 'Publish PyTest results'
    condition: succeededOrFailed()
    inputs:
      testResultsFiles: '**/test-*.xml'
      testRunTitle: 'Publish test results for Python $(python.version)'
```

{% endraw %}

To perform a PR validation on GitHub you can use a similar YAML configuration with [GitHub Actions](https://help.github.com/en/actions/language-and-framework-guides/using-python-with-github-actions)

## Pre-commit hooks

Pre-commit hooks allow you to format and lint code locally before submitting the pull request.

Adding pre-commit hooks for your python repository is easy using the pre-commit package

1. Install pre-commit and add to the requirements.txt

    {% raw %}

```bash
    pip install pre-commit
    ```

{% endraw %}

2. Add a `.pre-commit-config.yaml` file in the root of the repository, with the desired pre-commit actions

    {% raw %}

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

{% endraw %}

3. Each individual developer that wants to set up pre-commit hooks can then run

    {% raw %}

```bash
    pre-commit install
    ```

{% endraw %}

At the next attempted commit any lint failures will block the commit.

> Note: Installing pre-commit hooks is voluntary and done by each developer individually. Thus, it's not a replacement for build validation on the server

## Code Review Checklist

In addition to the [Code Review Checklist](../process-guidance/reviewer-guidance.md) you should also look for these python specific code review items

* [ ] Are all new packages used included in requirements.txt
* [ ] Does the code pass all lint checks?
* [ ] Do functions use type hints, and are there any type hint errors?
* [ ] Is the code readable and using pythonic constructs wherever possible.
