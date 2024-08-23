# Merge Strategies

Agree if you want a linear or non-linear commit history. There are pros and cons to both approaches:

* Pro linear: [Avoid messy git history, use linear history](https://dev.to/bladesensei/avoid-messy-git-history-3g26)
* Con linear: [Why you should stop using Git rebase](https://medium.com/@fredrikmorken/why-you-should-stop-using-git-rebase-5552bee4fed1)

## Approach for Non-Linear Commit History

Merging `topic` into `main`

```sh
  A---B---C topic
 /         \
D---E---F---G---H main

git fetch origin
git checkout main
git merge topic
```

## Two Approaches to Achieve a Linear Commit History

### Rebase Topic Branch Before Merging into Main

Before merging `topic` into `main`, we rebase `topic` with the `main` branch:

```bash
          A---B---C topic
         /         \
D---E---F-----------G---H main

git checkout main
git pull
git checkout topic
git rebase origin/main
```

Create a PR topic --> main in Azure DevOps and approve using the squash merge option

### Rebase Topic Branch Before Squash Merge into Main

[Squash merging](https://learn.microsoft.com/en-us/azure/devops/repos/git/merging-with-squash?view=azure-devops) is a merge option that allows you to condense the Git history of topic branches when you complete a pull request. Instead of adding each commit on `topic` to the history of `main`, a squash merge takes all the file changes and adds them to a single new commit on `main`.

```bash
          A---B---C topic
         /
D---E---F-----------G---H main
```

Create a PR topic --> main in Azure DevOps and approve using the squash merge option
