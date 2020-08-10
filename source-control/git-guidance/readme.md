# Git Guidance

## The basics

### Installation

[Install Git](https://git-scm.com/downloads) and follow the [First-Time Git Setup](https://git-scm.com/book/en/v2/Getting-Started-First-Time-Git-Setup).

### Typical workflow

The following is a typical workflow for making a change in an existing repo using git

1. Clone the repository to your local machine 

    ```cmd
    git clone https://github.com/username/repo-name
    ```

2. Create and checkout a new branch for your changes

    ```cmd
    git checkout -b feature/123-add-instructions
    ```

3. Make a change to README.md

4. (Optional) Check what files were changed

    ```cmd
    git status
    ```

5. Track the changed files and commit the changes to the local branch

    ```cmd
    git add README.md
    git commit -m "add instructions for how to use the repo"
    ```

6. When you are done committing changes - push the local branch to the remote repository

    ```cmd
    git push
    ```

7. Open a Pull Request (PR) to merge to main/develop in github, Azure DevOps or equivalent
8. When the PR is approved merge the Pull Request in the tool where you created the PR or using

    ```cmd
    git merge develop
    ```

What you name your branches, whether you merge into main or develop, what merge strategy you use etc. is something you should agree on with your team before starting development.

([git flow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow), [release flow](https://docs.microsoft.com/en-us/azure/devops/learn/devops-at-microsoft/release-flow) etc.)

### Cloning

Cloning a repository pulls down a full copy of all the repository data, so that you can work on it locally.
This copy includes all versions of every file and folder for the project.

```cmd
git clone https://github.com/username/repo-name
```

### Branching

Often, the main or develop branch of a repository will be locked so that you can't make changes without a Pull Request.
In this case it is useful to create a separate branch for your local work.

1. Make sure you are positioned on the develop (or main) branch, and pull to get the latest changes

    ```cmd
    git checkout develop
    git pull
    ```

2. Create a new local branch for your work

    ```cmd
    git checkout -b feature/feature-name
    ``` 

At any point, you can move between the branches with `git checkout <branch>` as long as you have committed or stashed your work.

If you forget the name of your branch use `git branch --all` to list all branches

To publish your branch 

git branch --all if you forgot the name

### Committing

```cmd
git add README.md
git commit -m "add instructions on how to use the repo"
...
git push
```

### Merging

1. Open a pull request
2. Merge the PR

Resolving conflicts - via merge

git checkout master
git pull
git checkout <your branch>
(git branch --all if you forgot the name)
git merge master (resolve conflicts)
git merge --continue
git log
git push

Resolving conflicts - via rebase

git checkout master
git pull
git checkout <your branch>
(git branch --all if you forgot the name)
git rebase master (resolve conflicts)
git rebase --continue
git log
git push

### Managing remotes


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
