# Contributing Source Code

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

## Contributing to an existing repository

When working on an existing project, `git clone` the repository and ensure you understand the team's branch, merge and release strategy (e.g. through the projects [CONTRIBUTING.md file](https://blog.github.com/2012-09-17-contributing-guidelines/)).

## Creating a new repository

If you create a new repository, agree on your branch, merge and release strategies upfront and document them in your [CONTRIBUTING.md](https://blog.github.com/2012-09-17-contributing-guidelines/). Also lock the default branches and define who can approve and merge Pull Requests into your default branches.

### Required files in default branch for public repositories

A public repository needs to have the following files in the root directory of the default branch:

* a [LICENSE](../../resources/templates/LICENSE) file
* a [README.md](../../resources/templates/README.md) file
* a [CONTRIBUTING.md](../../resources/templates/CONTRIBUTING.md) file
* reference the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/)

To start to contribute by creating your own branch, or fork the repository, and commit often - make your commit comments useful to others by including the *WHAT* and *WHY* (instead of the *HOW*).

## Merge strategies

Agree if you want a linear or non-linear commit history. There are pros and cons to both approaches:

* Pro linear: [A tidy, linear Git history](https://www.bitsnbites.eu/a-tidy-linear-git-history/)
* Con linear: [Why you should stop using Git rebase](https://medium.com/@fredrikmorken/why-you-should-stop-using-git-rebase-5552bee4fed1)

### Approach for non-linear commit history

Merging `topic` into `main`

```md
  A---B---C topic
 /         \
D---E---F---G---H main

git fetch origin
git checkout main
git merge topic
```

### Two approaches to achieve a linear commit history

#### Rebase topic branch before merging into main

Before merging `topic` into `main`, we rebase `topic` with the   :

```bash
          A---B---C topic
         /         \
D---E---F-----------G---H main

git fetch origin
git rebase main topic
git checkout main
git merge topic
```

#### Rebase topic branch before squash merge into main

[Squash merging](https://docs.microsoft.com/en-us/azure/devops/repos/git/merging-with-squash?view=azure-devops) is a merge option that allows you to condense the Git history of topic branches when you complete a pull request. Instead of adding each commit on `topic` to the history of `main`, a squash merge takes all the file changes and adds them to a single new commit on `main`.

```bash
          A---B---C topic
         /
D---E---F-----------G---H main

Create a PR topic --> main in Azure DevOps and approve using the squash merge option
```

## Naming branches

When contributing to existing projects, look for and stick with the agreed branch naming convention. In open source projects this information is typically found in the contributing instructions, often in a file named `CONTRIBUTING.md`.

In the beginning of a new project the team agrees on the project conventions including the branch naming strategy.

Here's an example of a branch naming convention:

```plaintext
<user alias>/[feature/bug/hotfix]/<work item ID>_<title>
```

Which could translate to something as follows:

```plaintext
dickinson/feature/271_add_more_cowbell
```

The example above is just that - an example. The team can choose to omit or add parts. Choosing a branch convention can depend on the development model (e.g. [trunk-based development](https://trunkbaseddevelopment.com/)), [versioning](../versioning/readme.md) model, tools used in managing source control, matter of taste etc. Focus on simplicity and unambiguity; a good branch naming strategy allows the team to understand the purpose and ownership of each branch in the repository.
