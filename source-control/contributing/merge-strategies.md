# Merge strategies

Agree if you want a linear or non-linear commit history. There are pros and cons to both approaches:

* Pro linear: [A tidy, linear Git history](https://www.bitsnbites.eu/a-tidy-linear-git-history/)
* Con linear: [Why you should stop using Git rebase](https://medium.com/@fredrikmorken/why-you-should-stop-using-git-rebase-5552bee4fed1)

## Approach for non-linear commit history

Merging `topic` into `main`

```md
  A---B---C topic
 /         \
D---E---F---G---H main

git fetch origin
git checkout main
git merge topic
```

## Two approaches to achieve a linear commit history

### Rebase topic branch before merging into main

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

### Rebase topic branch before squash merge into main

[Squash merging](https://docs.microsoft.com/en-us/azure/devops/repos/git/merging-with-squash?view=azure-devops) is a merge option that allows you to condense the Git history of topic branches when you complete a pull request. Instead of adding each commit on `topic` to the history of `main`, a squash merge takes all the file changes and adds them to a single new commit on `main`.

```bash
          A---B---C topic
         /
D---E---F-----------G---H main
```

Create a PR topic --> main in Azure DevOps and approve using the squash merge option
