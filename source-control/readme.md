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

Consistency is important, so agree to the approach as a team before starting to code. Treat this as a design decision, so include a design proposal and review, in the same way as you would document all design decisions (see [Working Agreements](../team-agreements/working-agreements/readme.md)).

The team should at least be doing the following:

* Agree on the **branch**, **release** and **merge strategy**
* Define the commit history approach ([linear or non-linear](./git.md#Commit-history))
* Lock the default branch and merge using [pull requests (PRs)](../code-reviews/pull-requests#Pull-Requests)
* Agree on [branch naming](./git.md#Naming-branches) (e.g. `user/your_alias/feature_name`)
* Establish [branch/PR policies](../code-reviews/pull-requests#Pull-Requests)
* For public repositories the default branch should contain the following files:
  * [LICENSE](../resources/templates/LICENSE)
  * [README.md](../resources/templates/README.md)
  * [CONTRIBUTING.md](../resources/templates/CONTRIBUTING.md)

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
