# Bash Code Reviews

## Style Guide

[CSE](../../CSE.md) developers follow [Google's Bash Style Guide](https://google.github.io/styleguide/shell.xml).

## Code Analysis / Linting

[CSE](../../CSE.md) projects must check Bash code with [shellcheck](https://github.com/koalaman/shellcheck) as part of the [CI process](../../continuous-integration/readme.md).
Apart from linting, [shfmt](https://github.com/mvdan/sh) can be used to automatically format shell scripts. There are few vscode code extensions which are based on shfmt like shell-format which can be used to automatically format shell scripts.

## Project Setup

### vscode-shellcheck

Shellcheck extension should be used in VS Code, it provides static code analysis capabilities and auto fixing linting issues. To use vscode-shellcheck in vscode do the following:

#### Install shellcheck on your machine:

For MacOS

```bash
brew install shellcheck
```

For Ubuntu:

```bash
apt-get install shellcheck
```

#### Install shellcheck on vscode:

Find the vscode-shellcheck extension in vscode and install it.

## Automatic Code Formatting

### shell-format

shell-format extension does automatic formatting of your bash scripts, docker files and several configuration files. It is dependent on shfmt which can enforce google style guide checks for bash.
To use shell-format in vscode do the following:

#### Install shfmt(Requires Go 1.13 or later) on your machine:

```bash
GO111MODULE=on go get mvdan.cc/sh/v3/cmd/shfmt
```

#### Install shell-format on vscode:

Find the shell-format extension in vscode and install it.

## Build Validation

To automate this process in Azure DevOps you can add the following snippet to you `azure-pipelines.yaml` file. This will lint any scripts in the `./scripts/` folder.

```yaml
- bash: |
    echo "This checks for formatting and common bash errors. See wiki for error details and ignore options: https://github.com/koalaman/shellcheck/wiki/SC1000"
    export scversion="stable"
    wget -qO- "https://storage.googleapis.com/shellcheck/shellcheck-${scversion?}.linux.x86_64.tar.xz" | tar -xJv
    sudo mv "shellcheck-${scversion}/shellcheck" /usr/bin/
    rm -r "shellcheck-${scversion}"
    shellcheck ./scripts/*.sh
  displayName: "Validate Scripts: Shellcheck"
  ```
  
  Also, your shell scripts can be formatted in your build pipeline by using shfmt. To integrate shfmt in your build pipeline do the following:

```yaml
- bash: |
    echo "This step does auto formatting of shell scripts"
    shfmt -l -w ./scripts/*.sh
  displayName: "Format Scripts: shfmt"
  ```
  
  Unit testing using [shunit2](https://github.com/kward/shunit2) can also be added to the build pipeline, using the following block:
  
  ```yaml
- bash: |
    echo "This step unit tests shell scripts by using shunit2"
    ./shunit2
  displayName: "Format Scripts: shfmt"
  ```
  
## Pre-Commit Hooks

All developers should run shellcheck and shfmt as pre-commit hooks.

### Step 1- Install pre-commit

Run `pip install pre-commit` to install pre-commit.
Alternatively you can run `brew install pre-commit` if you are using homebrew.

### Step 2- Add shellcheck and shfmt

Add .pre-commit-config.yaml file to root of the go project. Run shfmt on pre-commit by adding it to .pre-commit-config.yaml file like below.

```yaml
-   repo: git://github.com/pecigonzalo/pre-commit-fmt
    sha: master
    hooks:
      -   id: shell-fmt
          args:
            - --indent=4
 ```

 ```yaml
-   repo: https://github.com/shellcheck-py/shellcheck-py
    rev: v0.7.1.1
    hooks:
    -   id: shellcheck
 ```

### Step 3

Run `$ pre-commit install` to setup the git hook scripts

## Dependencies

Bash scripts are often used to 'glue together' other systems and tools. As such, Bash scripts can often have numerous and/or complicated dependencies. Consider using Docker containers to ensure that scripts are executed in a portable and reproducible environment that is guaranteed to contain all the correct dependencies. To ensure that dockerized scripts are nevertheless easy to execute, consider making the use of Docker transparent to the script's caller by wrapping the script in a 'bootstrap' which checks whether the script is running in Docker and re-executes itself in Docker if it's not the case. This provides the best of both worlds: easy script execution and consistent environments.

```bash
if [[ "${DOCKER}" != "true" ]]; then
  docker build -t my_script -f my_script.Dockerfile . > /dev/null
  docker run -e DOCKER=true my_script "$@"
  exit $?
fi

# ... implementation of my_script here can assume that all of its dependencies exist since it's always running in Docker ...
```

## Code Review Checklist

In addition to the [Code Review Checklist](../process-guidance/reviewer-guidance.md) you should also look for these bash specific code review items

* [ ] Does this code use [Built-in Shell](https://www.gnu.org/software/bash/manual/html_node/The-Set-Builtin.html) Options like set -o, set -e, set -u for execution control of shell scripts ?
* [ ] Is the code modularized? Shell scripts can be modularized like python modules. Portions of bash scripts should be sourced in complex bash projects.
* [ ] Are all exceptions handled correctly? Exceptions should be handled correctly using exit codes or trapping signals.
* [ ] Does the code pass all linting checks as per shellcheck and unit tests as per shunit2 ?
* [ ] Does the code uses relative paths or absolute paths? Relative paths should be avoided as they are prone to environment attacks. If relative path is needed, check that the ```PATH``` variable is set.
* [ ] Does the code take credentials as user input? Are the credentials masked or encrypted in the script?
