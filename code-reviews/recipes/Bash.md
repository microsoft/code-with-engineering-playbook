# Bash Code Reviews

## Style Guide

[CSE](../../CSE.md) developers follow [Google's Bash Style Guide](https://google.github.io/styleguide/shell.xml).

## Code Analysis / Linting

[CSE](../../CSE.md) projects must check Bash code with [shellcheck](https://github.com/koalaman/shellcheck) as part of the [CI process](../../continuous-integration/readme.md).

## Useful extensions for VS Code 

### vscode-shellcheck
Shellcheck extension should be used in VS Code, it provides static code analysis capabilities and auto fixing linting issues. To use vscode-shellcheck in vscode do the following:


### shell-format
shell-format extension does automatic formatting of your bash scripts, dockerfiles and several configuration files. It is dependent on shfmt which can enforce google style guide checks for bash.
To use shell-format in vscode do the following:

## Build Validation

To automate this process in Azure Devops you can add the following snippet to you `azure-pipelines.yaml` file. This will lint any scripts in the `./scripts/` folder.

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

In addition to the [Code Review Checklist](../README.md) you should also look for these bash specific code review items

> TODO: Add checklist
