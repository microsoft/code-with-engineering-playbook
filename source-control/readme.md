# Source Control

There are many different options when working with Source Control. In [CSE](../CSE.md) we use [AzureDevOps](https://csesd.visualstudio.com/_projects) for private repositories and [GitHub](https://github.com/) for public repositories.

## Sections within Source Control

* [Git](git.md)
* [Feature Branching](feature-branching/readme.md)
* [Versioning](versioning/readme.md)

## Goal

* Following industry best practice to work in geo-distributed teams which encourage contributions from all across [CSE](../CSE.md) as well as the broader OSS community
* Improve code quality by enforcing reviews before merging into master branches
* Improve traceability of features and fixes through a clean commit history

## General Guidance

Consistency is important, so agree to the approach as a team before starting to code. Consider this as a design decision
which means that there should be a design proposal and review, and the outcome will be captured in the same way
that all design decisions are documented (see [Working Agreements](../team-agreements/working-agreements/readme.md)).

The team should at least be doing the following:

* agree on their **branch**, **release** and **merge strategy**
* define approach to commit history (linear or non-linear)
* lock the default branch and merge using PRs
* agree branch naming (e.g. `user/your_alias/feature_name`)
* for public repositories:
  * default branch contains the [LICENSE](../resources/templates/LICENSE), [README.md](../resources/templates/README.md) and [CONTRIBUTING.md](../resources/templates/CONTRIBUTING.md) file

## Commit Best Practices

TODO: Add more content and details here!

* Link work items
* How often to commit
* When to push

## Resources

* [Git](https://git-scm.com/) `--local-branching-on-the-cheap`
* [AzureDevOps](https://azure.microsoft.com/en-us/services/devops/)
* [The GitHub Hello World](https://guides.github.com/activities/hello-world/)
* [CSE Git details](git.md) details on how to use Git as part of a [CSE](../CSE.md) project.
* [GitHub - Removing sensitive data from a repository](https://help.github.com/articles/removing-sensitive-data-from-a-repository/)