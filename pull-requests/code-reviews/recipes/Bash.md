# Bash Code Reviews

## Style Guide

[CSE](../../../CSE.md) developers follow [Google's Bash Style Guide](https://google.github.io/styleguide/shell.xml).

## Linter

[CSE](../../../CSE.md) projects must check Bash code with [shellcheck](https://github.com/koalaman/shellcheck) as part of the [CI process](../../../continuous-integration/readme.md).

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
