# Git Guidance

## The basics

### Installation

[Install Git](https://git-scm.com/downloads) and follow the [First-Time Git Setup](https://git-scm.com/book/en/v2/Getting-Started-First-Time-Git-Setup).

## Rolling back changes

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

## Using submodules

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

## Stashing changes

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

## Working with images, video and other binary content

Avoid committing frequently changed binary files, such as large images, video or compiled code to your git repository. Binary content is not diffed like text content, so cloning or pulling from the repository may pull each revision of the binary file.

One solution to this problem is `Git LFS (Git Large File Storage)` - an open source Git extension for versioning large files. `Git LFS` replaces the binary files with text pointers inside Git, while storing the file contents on a remote server like GitHub.com or Azure DevOps.

### Benefits of Git LFS

* Uses the end to end Git workflow for all files
* Git LFS supports file locking to avoid conflicts for undiffable assets
* Git LFS is fully supported in Azure DevOps Services

### Limitations of Git LFS

* Everyone contributing to the repository needs to install Git LFS
* If not set up properly:
  * Binary files committed through Git LFS are not visible as Git will only download the data describing the large file
  * Committing large binaries will push the full binary to the repository
* Git cannot merge the changes from two different versions of a binary file; file locking mitigates this
* Azure Repos do not support using SSH for repositories with Git LFS tracked files - for more information see the Git LFS [authentication documentation](https://github.com/git-lfs/git-lfs/blob/master/docs/api/authentication.md)

### Common commands

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

### References

* [Git LFS getting started](https://git-lfs.github.com/)
* [Git LFS manual](https://github.com/git-lfs/git-lfs/tree/master/docs)
* [Git LFS on Azure Repos](https://docs.microsoft.com/en-us/azure/devops/repos/git/manage-large-files?view=azure-devops)

## Tools

* Visual Studio Code is a cross-platform powerful source code editor with built in git commands. Within Visual Studio Code editor you can review diffs, stage changes, make commits, pull and push to your git repositories.
You can refer to [Visual Studio Code Git Support](https://code.visualstudio.com/docs/editor/versioncontrol#_git-support) for documentation.

* Use a shell/terminal to work with Git commands instead of relying on [GUI clients](https://git-scm.com/downloads/guis/).

* If you're working on Windows, [posh-git](https://github.com/dahlbyk/posh-git) is a great PowerShell environment for Git. Another option is to use [Git bash for Windows](http://www.techoism.com/how-to-install-git-bash-on-windows/). On Linux/Mac, install git and use your favorite shell/terminal.
