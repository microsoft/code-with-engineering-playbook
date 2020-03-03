# Pull Requests

Changes to any main codebase - master branch in Git repository, for example - must be done using pull requests (PR).

Pull requests enable:
* Code inspection - see [Code Reviews](./README.md)
* Running automated qualification of the code
    * Linters
    * Compilation
    * Unit tests
    * Integration tests etc.

The requirements of pull requests can and should be enforced by policies, which can be set in the most modern version control and work item tracking systems. See [Evidence and Measures section](./README.md#evidence-and-measures) on Code Reviews page for more information.

## General Process

1. Implement changes based on the well-defined description and acceptance criteria of the task at hand
1. Then, before creating a new pull request:
    * Make sure the code conforms with the agreed coding conventions
        * This can be partially automated using linters
    * Ensure the code compiles and runs without errors or warnings
    * Write and/or update tests to cover the changes and make sure all new and existing tests pass
    * Write and/or update the documentation to match the changes
1. Once convinced the criteria above are met, create and submit a new pull request adhering to the [pull request template](./pull-request-template.md)
1. Follow the [code review](./README.md) process to merge the changes to the main codebase

## Resources

* [Review code with pull requests (Azure DevOps)](https://docs.microsoft.com/en-us/azure/devops/repos/git/pull-requests?view=azure-devops)
* [Collaborating with issues and pull requests (GitHub)](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests)

