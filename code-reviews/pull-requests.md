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

However, we should avoid having PRs that include code that is without context or loosely coupled. There is no right size, but keep in mind that a code review is a collaborative process, a big PR could be faster to write but slower to review. We should always strive to have as small PRs as possible that still add value. Besides the size, remember that every PR should:

* Be consistent,
* not break the build, and
* include related tests as part of the PR.

Be consistent means that all the changes included on the PR should aim to solve one goal (ex. one user story) and be intrinsically related. Think of this as the Single-responsibility principle in terms of the whole project, the PR should have only one *reason to change* the project.

Start small, it is easier to create a small PR from the start than to break up a bigger one.

These are some strategies to keep PRs small depending on the "cause" of the inevitability:

### Minimum Working Components

If the design of your changes allow breaking the implementation into self-contained changes that do not break the build, it is better to create one PR per component. The components should be fully functional pieces that can be released as soon as possible. Think about this as breaking the implementation vertically, where components sometimes involve changes on the full-stack.

### Layers

Sometimes we cannot release components without breaking the build, this is very often the case on refactors. For example, if you need to modify several classes on the backend. In this case, is better to break the code on layers or incremental changes.

Think about this as breaking the implementation horizontally, where layers involve changes on one part of the stack.

### Feature Flag

Sometimes we don't want to release the changes immediately to be visible to the final users until the whole implementation is complete, but we want to merge small pieces into code working in production, in this cases we could work to integrate the code into the production branch (making sure it does not break the build) but disabling the code. There are multiple ways to do this depending on the language or framework, the most basic one is by creating an application or config setting that can enable/disable that part of the code. Design patterns like Observer-Subject or Canary releases (with traffic redirection) are useful to implement this.

Think about this as releasing hidden features that could be enabled later. You can find more information about different feature flag techniques by searching for "Feature Toggling" patterns.

## Resources

* [Review code with pull requests (Azure DevOps)](https://docs.microsoft.com/en-us/azure/devops/repos/git/pull-requests?view=azure-devops)
* [Collaborating with issues and pull requests (GitHub)](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests)
