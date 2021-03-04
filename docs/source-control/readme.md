# Source Control

There are many different options when working with Source Control. In [CSE](../CSE.md) we use [AzureDevOps](https://azure.microsoft.com/en-us/services/devops/) for private repositories and [GitHub](https://github.com/) for public repositories.

## Sections within Source Control

* [Merge Strategies](contributing/merge-strategies.md)
* [Branch Naming](contributing/naming-branches.md)
* [Versioning](versioning/readme.md)
* [Working with Secrets](secrets-management/readme.md)
* [Git Guidance](git-guidance/readme.md)
* [Pull Request Templates](pull-request-templates/README.md)

## Goal

* Following industry best practice to work in geo-distributed teams which encourage contributions from all across [CSE](../CSE.md) as well as the broader OSS community
* Improve code quality by enforcing reviews before merging into main branches
* Improve traceability of features and fixes through a clean commit history

## General Guidance

Consistency is important, so agree to the approach as a team before starting to code. Treat this as a design decision, so include a design proposal and review, in the same way as you would document all design decisions (see [Working Agreements](../agile-development/team-agreements/working-agreements/readme.md) and [Design Reviews](../design-reviews/readme.md)).

## Creating a new repository

When creating a new repository, the team should at least do the following

* Agree on the **branch**, **release** and **merge strategy**
* Define the merge strategy ([linear or non-linear](./contributing/merge-strategies.md))
* Lock the default branch and merge using [pull requests (PRs)](../code-reviews/pull-requests.md)
* Agree on [branch naming](./contributing/naming-branches.md) (e.g. `user/your_alias/feature_name`)
* Establish [branch/PR policies](../code-reviews/pull-requests.md)
* For public repositories the default branch should contain the following files:
  * [LICENSE](../resources/templates/LICENSE)
  * [README.md](../resources/templates/README.md)
  * [CONTRIBUTING.md](../resources/templates/CONTRIBUTING.md)

## Contributing to an existing repository

When working on an existing project, `git clone` the repository and ensure you understand the team's branch, merge and release strategy (e.g. through the projects [CONTRIBUTING.md file](https://blog.github.com/2012-09-17-contributing-guidelines/)).

## Mixed DevOps Environments

For most engagements having a single hosted DevOps environment (i.e AzureDevOps) is the preferred path but there are times when a mixed DevOps environment (i.e. AzureDevOps for Agile/Work item tracking & GitHub for Source Control) is needed due to customer requirements. When working in a mixed environment:

* Manually tag PR's in work items
* Ensure that the scope of work items / tasks align with PR's

## Commit Best Practices

* Make small commits. This makes changes easier to review, and if we need to revert a commit, we lose less work.
* Commit complete and well tested code. Never commit incomplete code, get in the habit of testing your code before committing.
* Don't mix whitespace changes with functional code changes. It is hard to determine if the line has a functional change or only removes a whitespace, so functional changes may go unnoticed.
* Write good commit messages.

A good commit message should answer these questions:

* Why is it necessary? It may fix a bug, add a feature, improve performance, or just be a change for the sake of correctness
* How does it address the issue? For short, obvious changes, this can be omitted
* What effects does this change have? In addition to the obvious ones, this may include benchmarks, side effects etc.
* What limitations does the current code have?

Consider this when writing your commit message:

* Don't assume that the code is self-evident/self-documenting
* If it seems difficult to summarize your commit, it may be because it includes more than one logical change or bug fix. If so, it is better to split it into separate commits with `git add -p`
* Don't assume the reviewer understands the original problem. It should be possible to review a change request without reading the contents of the original bug/task.

Good message structure:

* Separate subject from body with a blank line
* Limit the subject line to 50 characters
* Capitalize the subject line
* Do not end the subject line with a period
* Use the imperative mood in the subject line (*Fix typo in log* vs. *Fixed typo in log* or *Misc fixes in log code*)
* Wrap the body at 72 characters
* Use the body to explain what and why vs. how
* Reference fixed issues with [closing keywords](https://help.github.com/en/enterprise/2.16/user/github/managing-your-work-on-github/closing-issues-using-keywords)

Example of a well structured git commit message:

```md
Add code review recipe for Go

- Helps teams automate linting and build verification for go projects.
- Also gives a list of items to verify for go code reviews.

The PR does not add info about VS Code extensions for go, this will
be added in issue #124

Closes: #123
```

You can specify the default git editor, which allows you to write your commit messages using your favorite editor. The following command makes Visual Studio Code your default git editor:

```bash
git config --global core.editor "code --wait"
```

References:

* [How to Write a Git Commit Message](https://chris.beams.io/posts/git-commit/)
* [A Note About Git Commit Messages](https://tbaggery.com/2008/04/19/a-note-about-git-commit-messages.html)
* [On commit messages](http://who-t.blogspot.com/2009/12/on-commit-messages.html)
* [Information in commit messages](https://wiki.openstack.org/wiki/GitCommitMessages#Information_in_commit_messages)
* [Git commit best practices](https://medium.com/@nawarpianist/git-commit-best-practices-dab8d722de99)

## Resources

* [Git](https://git-scm.com/) `--local-branching-on-the-cheap`
* [AzureDevOps](https://azure.microsoft.com/en-us/services/devops/)
* [The GitHub Hello World](https://guides.github.com/activities/hello-world/)
* [CSE Git details](./git-guidance/readme.md) details on how to use Git as part of a [CSE](../CSE.md) project.
* [GitHub - Removing sensitive data from a repository](https://help.github.com/articles/removing-sensitive-data-from-a-repository/)
