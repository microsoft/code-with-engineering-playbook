# Git Guidance

## Installation

[Install Git](https://git-scm.com/downloads) and follow the [First-Time Git Setup](https://git-scm.com/book/en/v2/Getting-Started-First-Time-Git-Setup)

## Tools

Use a shell/terminal to work with Git commands instead of relying on [GUI clients](https://git-scm.com/downloads/guis/).

If you're working on Windows, [posh-git](https://github.com/dahlbyk/posh-git) is a great PowerShell environment for Git. Another option is to use [Git bash for Windows](http://www.techoism.com/how-to-install-git-bash-on-windows/). On Linux/Mac, install git and use your favorite shell/terminal.

## Working with repositories

### Contributing to an existing repository

When working on an existing project, `git clone` the repository and ensure you understand the team's branch, merge and release strategy (e.g. through the projects [CONTRIBUTING.md file](https://blog.github.com/2012-09-17-contributing-guidelines/)).

### Creating a new repository

If you create a new repository, agree on your branch, merge and release strategies upfront and document them in your [CONTRIBUTING.md](https://blog.github.com/2012-09-17-contributing-guidelines/). Also lock the default branches and define who can approve and merge Pull Requests into your default branches.

#### Required files in default branch for public repositories

A public repository needs to have the following files in the root directory of the default branch:

* a [LICENSE](Templates/LICENSE) file
* a [README.md](Templates/README.md) file
* a [CONTRIBUTING.md](Templates/CONTRIBUTING.md) file
* reference the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/)

To start to contribute by creating your own branch, or fork the repository, and commit often - make your commit comments useful to others by including the *WHAT* and *WHY* (instead of the *HOW*).

## Commit history

Agree if you want a linear or non-linear commit history. There are pros and cons to both approaches:

* Pro linear: [A tidy, linear Git history](https://www.bitsnbites.eu/a-tidy-linear-git-history/)
* Con linear: [Why you should stop using Git rebase](https://medium.com/@fredrikmorken/why-you-should-stop-using-git-rebase-5552bee4fed1)

### Approach for non-linear commit history

Merging `topic` into `master`

```md
  A---B---C topic
 /         \
D---E---F---G---H master

git fetch origin
git checkout master
git merge topic
```

### Two approaches to achieve a linear commit history

#### Rebase topic branch before merging into master

Before merging `topic` into `master`, we rebase `topic` with the   :

```bash
          A---B---C topic
         /         \
D---E---F-----------G---H master

git fetch origin
git rebase master topic
git checkout master
git merge topic
```

#### Rebase topic branch before squash merge into master

[Squash merging](https://docs.microsoft.com/en-us/azure/devops/repos/git/merging-with-squash?view=azure-devops) is a merge option that allows you to condense the Git history of topic branches when you complete a pull request. Instead of adding each commit on `topic` to the history of `master`, a squash merge takes all the file changes and adds them to a single new commit on `master`.

```bash
          A---B---C topic
         /
D---E---F-----------G---H master

Create a PR topic --> master in Azure DevOps and approve using the squash merge option
```

### Naming branches

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

The example above is just that - an example. The team can choose to omit or add parts. Choosing a branch convention can depend on the development model (e.g. [trunk-based development](https://trunkbaseddevelopment.com/)), [versioning](versioning/readme.md) model, tools used in managing source control, matter of taste etc. Focus on simplicity and unambiguity; a good branch naming strategy allows the team to understand the purpose and ownership of each branch in the repository.

### Release Strategy/Versioning

Please see [versioning](versioning/readme.md).

### Working with secrets (such as storage keys)

The best way to avoid leaking secrets is to store them in local/private files and exclude these from  git tracking with a [.gitignore](https://git-scm.com/docs/gitignore) file.
E.g. the following pattern will exclude all files with the extension `.private.config`:

```bash
# remove private configuration
*.private.config
```

For more details on proper management of credentials and secrets in source control, and handling an accidental commit of secrets to source control, please refer to the [Secrets Management](../continuous-deployment/secrets-management/readme.md) document which has further information, split by language as well.

As an extra security measure, apply [credential scanning](../continuous-integration/credential-scanning/recipes/detect-secrets.md) in your CI/CD pipeline

### Reverting and deleting commits

To "undo" a commit, run the following two commands: `git revert` and `git reset`. `git revert` creates a new commit that undoes commits while `git reset` allows to delete commits entirely from the commit history.

> If you have committed secrets/keys, `git reset` will remove them from the commit history!

To **delete** the latest commit use `HEAD~`:

```bash
git reset --hard HEAD~1
```

To delete commits back to a specific commit, use the respective commit id:

```bash
git reset --hard <sha1-commit-id>
```

after you deleted the unwanted commits, push using `force`:

```bash
git push origin HEAD --force
```

### Multi service development and deployments

Submodules can be useful in more complex deployment and/or development scenarios

Adding a submodule to your repo

```bash
git submodule add -b master <your_submodule>
```

Initialize and pull a repo with submodules:

```bash
git submodule init
git submodule update --init --remote
git submodule foreach git checkout master
git submodule foreach git pull origin
```

### Stashing

`git stash` is super handy if you have un-committed changes in your working directory but you want to work on a different branch. You can run `git stash` and save the un-committed work and reverts back to the HEAD commit. You can retrieve the saved changes by running `git stash pop`:

```bash
git stash
…
git stash pop
```

Or you can move the current state into a new branch:

```bash
git stash branch <new_branch_to_save_changes>
```

### Working with images, video and other binary content

Avoid committing frequently changed binary files, such as large images, video or compiled code to your git repository. Binary content is not diffed like text content, so cloning or pulling from the repository may pull each revision of the binary file.

One solution to this problem is `Git LFS (Git Large File Storage)` - an open source Git extension for versioning large files. `Git LFS` replaces the binary files with text pointers inside Git, while storing the file contents on a remote server like GitHub.com or Azure DevOps.

#### Benefits of Git LFS

* Uses the end to end Git workflow for all files
* Git LFS supports file locking to avoid conflicts for undiffable assets
* Git LFS is fully supported in Azure DevOps Services

#### Limitations of Git LFS

* Everyone contributing to the repository needs to install Git LFS
* If not set up properly:
  * Binary files committed through Git LFS are not visible as Git will only download the data describing the large file
  * Committing large binaries will push the full binary to the repository
* Git cannot merge the changes from two different versions of a binary file; file locking mitigates this
* Azure Repos do not support using SSH for repositories with Git LFS tracked files - for more information see the Git LFS [authentication documentation](https://github.com/git-lfs/git-lfs/blob/master/docs/api/authentication.md)

#### Common commands

Install git lfs

```bash
git lfs install       # windows
sudo apt-get git-lfs  # linux
```

See the [Git LFS installation instructions](https://github.com/git-lfs/git-lfs/wiki/Installation) for installation on other systems

Track .mp4 files with Git LFS

```bash
git lfs track '*.mp4'
```

Update the `.gitattributes` file listing the files and patterns to track

```bash
*.mp4 filter=lfs diff=lfs merge=lfs -text
docs/images/* filter=lfs diff=lfs merge=lfs -text
```

List all patterns tracked

```bash
git lfs track
```

List all files tracked

```bash
git lfs ls-files
```

Download files to your working directory

```bash
git lfs pull
git lfs pull --include="path/to/file"
```

#### References

* [Git LFS getting started](https://git-lfs.github.com/)
* [Git LFS manual](https://github.com/git-lfs/git-lfs/tree/master/docs)
* [Git LFS on Azure Repos](https://docs.microsoft.com/en-us/azure/devops/repos/git/manage-large-files?view=azure-devops)
