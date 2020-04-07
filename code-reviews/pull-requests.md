# Pull Requests

Changes to any main codebase - master branch in Git repository, for example - must be done using pull requests (PR).

Pull requests enable:

* Code inspection - see [Code Reviews](./README.md)
* Running automated qualification of the code
  * Linters
  * Compilation
  * Unit tests
  * Integration tests etc.

The requirements of pull requests can and should be enforced by policies, which can be set in the most modern version control and work item tracking systems. See [Evidence and Measures section](./evidence-and-measures/README.md) for more information.

## General Process

1. Implement changes based on the well-defined description and acceptance criteria of the task at hand
1. Then, before creating a new pull request:
    * Make sure the code conforms with the agreed coding conventions
        * This can be partially automated using linters
    * Ensure the code compiles and runs without errors or warnings
    * Write and/or update tests to cover the changes and make sure all new and existing tests pass
    * Write and/or update the documentation to match the changes
1. Once convinced the criteria above are met, create and submit a new pull request adhering to the [pull request template](./pull-request-template.md)
1. Follow the [code review](./process-guidance/README.md) process to merge the changes to the main codebase

## Size Guidance

We should always aim to have pull requests be as small as possible, without losing context and technical feasibility. Small PRs have multiple advantages:

1. They are easier to review; a clear benefit for the reviewers.
1. They are easier to deploy; this is aligned with the strategy of release fast and release often.
1. Minimizes possible conflicts and stale PRs, which are difficult to merge and keep in sync with master either because they're very dynamic or contain refactoring.

However, we should avoid having PRs that include code that is without context or loosely coupled.

<!-- TODO: Expand the topics below

There are times where seem a big PR is unavoidable; however, there are some strategies to keep PRs small depending on the "cause" of the ineluctability:

### Minimum Working Components
### Layers
### Feature Flag

-->

## Resources

* [Review code with pull requests (Azure DevOps)](https://docs.microsoft.com/en-us/azure/devops/repos/git/pull-requests?view=azure-devops)
* [Collaborating with issues and pull requests (GitHub)](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests)
