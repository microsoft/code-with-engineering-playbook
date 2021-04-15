# Git Guidance

## What is Git?

Git is a distributed version control system. This means that - unlike SVN or CVS - it doesn't use a central server to synchronize. Instead, every participant has a local copy of the source code and the attached history that is kept in sync by comparing commit hashes (SHA hashes of changes between each git commit command) making up the latest version (called `HEAD`).

For example:

```plain
repo 1: A -> B -> C -> D -> HEAD
repo 2: A -> B -> HEAD
repo 3: X -> Y -> Z -> HEAD
repo 4: A -> J -> HEAD
```

Since they share a common history, repo 1 and repo 2 can be synchronized fairly easily, repo 4 _may_ be able to synchronize as well but it's going to have to add a commit (J, and maybe a merge commit) to repo 1. Repo 3 cannot be easily synchronized with the others. Everything related to these commits is stored in a local .git directory in the root of the repository.

In other words, by using Git you are simply creating immutable file histories that uniquely identify the current state and therefore allow to share whatever comes after. It's a [Merkle tree](https://en.wikipedia.org/wiki/Merkle_tree).

Be sure to run `git help` after Git installation to find really in-depth explanations of everything.

## Installation

Git is a toolset that must be installed. [Install Git](https://git-scm.com/downloads) and follow the [First-Time Git Setup](https://git-scm.com/book/en/v2/Getting-Started-First-Time-Git-Setup).

A recommended installation is the [Git Lens extension for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=eamodio.gitlens). Visualize code authorship at a glance via Git blame annotations and code lens, seamlessly navigate and explore Git repositories, gain valuable insights via powerful comparison commands, and so much more.

You can use these commands as well to configure your Git for Visual Studio Code as an editor for merge conflicts and diff tool.

```cmd
git config --global user.name [YOUR FIRST AND LAST NAME]
git config --global user.email [YOUR E-MAIL ADDRESS]

git config --global merge.tool vscode
git config --global mergetool.vscode.cmd "code --wait $MERGED"

git config --global diff.tool vscode
git config --global difftool.vscode.cmd "code --wait --diff $LOCAL $REMOTE"
```

## Basic workflow

A basic Git workflow is as follows; you can find more information on the specific steps below.

```cmd
# pull the latest changes
git pull

# start a new feature branch based on the develop branch
git checkout -b feature/123-add-git-instructions develop

# edit some files

# add and commit the files
git add <file>
git commit -m "add basic instructions"

# edit some files

# add and commit the files
git add <file>
git commit -m "add more advanced instructions"

# check your changes
git status

# push the branch to the remote repository
git push --set-upstream origin feature/123-add-git-instructions
```

### Cloning

Whenever you want to make a change to a repository you need to first clone it. Cloning a repository pulls down a full copy of all the repository data, so that you can work on it locally. This copy includes all versions of every file and folder for the project.

```cmd
git clone https://github.com/username/repo-name
```

You only need to clone the repository the first time. Before any subsequent branches you can sync any changes from the remote repository using `git pull`.

### Branching

To avoid adding code that has not been peer reviewed to the main branch (ex. `develop`) we typically work in feature branches, and merge these back to the main trunk with a Pull Request. It's even the case that often the `main` or `develop` branch of a repository are locked so that you can't make changes without a Pull Request. Therefore, it is useful to create a separate branch for your local/feature work, so that you can work and track your changes in this branch.

Pull the latest changes and create a new branch for your work based on the trunk (in this case `develop`).

```cmd
git pull
git checkout -b feature/feature-name develop
```

At any point, you can move between the branches with `git checkout <branch>` as long as you have committed or stashed your work. If you forget the name of your branch use `git branch --all` to list all branches.

### Committing

To avoid losing work, it is good to commit often in small chunks. This allows you to revert only the last changes if you discover a problem and also neatly explains exactly what changes were made and why.

1. Make changes to your branch

2. Check what files were changed

    ```cmd
    > git status
    On branch feature/271-basic-commit-info
    Changes not staged for commit:
      (use "git add <file>..." to update what will be committed)
      (use "git restore <file>..." to discard changes in working directory)
            modified:   source-control/git-guidance/readme.md
    ```

3. Track the files you wish to include in the commit. To track all modified files:

    ```cmd
    git add --all
    ```

   Or to track only specific files:

    ```cmd
    git add source-control/git-guidance/readme.md
    ```

4. Commit the changes to your local branch with a descriptive [commit message](../readme.md#commit-best-practices)

    ```cmd
    git commit -m "add basic git instructions"
    ```

### Pushing

When you are done working, push your changes to a branch in the remote repository using:

```cmd
git push
```

The first time you push, you first need to set an upstream branch as follows. After the first push, the --set-upstream parameter and branch name are not needed anymore.

```cmd
git push --set-upstream origin feature/feature-name
```

Once the feature branch is pushed to the remote repository it is visible to anyone with access to the code.

### Merging

In [CSE](../../CSE.md) we encourage the use of Pull Request to merge code to the main repository to make sure that all code in the final product is [code reviewed](../../code-reviews/README.md)

The Pull Request (PR) process in [Azure DevOps](https://docs.microsoft.com/en-us/azure/devops/repos/git/pull-requests?view=azure-devops), [GitHub](https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request) and other similar tools make it easy both to start a PR, review a PR and merge a PR.

#### Merge Conflicts

If multiple people make changes to the same files, you may need to resolve any conflicts that have occurred before you can merge.

```cmd
# check out the develop branch and get the latest changes
git checkout develop
git pull

# check out your branch
git checkout <your branch>

# merge the develop branch into your branch
git merge develop

# if merge conflicts occur, above command will fail with a message telling you that there are conflicts to be solved

# find which files need to be resolved
git status
```

You can start an interactive process that will show which files have conflicts. Sometimes you removed a file, where it was changed in dev. Or you made changes to some lines in a file where another developer made changes as well. If you went through the installation steps mentioned before, Visual Studio Code is setup as merge tool. You can also use a merge tool like [kdiff3](https://github.com/KDE/kdiff3). When editing conflicts occur, the process will automatically open Visual Studio Code where the conflicting parts are highlighted in green and blue and you have make a selection:

* Accept your changes (current)
* Accept the changes from dev branch (incoming)
* Accept them both and fix the code (probably needed)

```text
Here are lines that are either unchanged from the common
ancestor, or cleanly resolved because only one side changed.
<<<<<<< yours:sample.txt
Conflict resolution is hard;
let's go shopping.
=======
Git makes conflict resolution easy.
>>>>>>> theirs:sample.txt
And here is another line that is cleanly resolved or unmodified
```

When this process is completed, make sure you test the result by executing build, checks, test to validate this merged result.

```cmd
# conclude the merge
git merge --continue

# verify that everything went ok
git log

# push the changes to the remote branch
git push
```

If no other conflicts appear, the PR can now be merged and your branch deleted. Use `squash` to reduce your changes into a single commit, so the commit history can be within an acceptable size.

### Stashing changes

`git stash` is super handy if you have un-committed changes in your working directory but you want to work on a different branch. You can run `git stash` and save the un-committed work and reverts back to the HEAD commit. You can retrieve the saved changes by running `git stash pop`:

```cmd
git stash
…
git stash pop
```

Or you can move the current state into a new branch:

```cmd
git stash branch <new_branch_to_save_changes>
```

### Recovering lost commits

If you "lost" a commit that you want to return to, for example to revert back a `git rebase` where your commits got squashed, you can use `git reflog` to find the commit:

```cmd
git reflog
```

Then you can use the reflog reference (`HEAD@{}`) to reset to a specific commit before the rebase:

```cmd
git reset HEAD@{2}
```

## Managing remotes

A local git repository can have one or more backing remote repositories. You can list the remote repositories using `git remote` - by default, the remote repository you cloned from will be called origin

```cmd
> git remote -v
origin  https://github.com/microsoft/code-with-engineering-playbook.git (fetch)
origin  https://github.com/microsoft/code-with-engineering-playbook.git (push)
```

### Working with forks

You can set multiple remotes. This is useful for example if you want to work with a forked version of the repository.
For more info on how to set upstream remotes and syncing repositories when working with forks see GitHub's [Working with forks documentation](https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/working-with-forks).

### Updating the remote if a repository changes names

If the repository is changed in some way, for example a name change, or if you want to switch between HTTPS and SSH you need to update the remote

```cmd
# list the existing remotes
> git remote -v
origin  https://hostname/username/repository-name.git (fetch)
origin  https://hostname/username/repository-name.git (push)

# change the remote url
git remote set-url origin https://hostname/username/new-repository-name.git

# verify that the remote URL has changed
> git remote -v
origin  https://hostname/username/new-repository-name.git (fetch)
origin  https://hostname/username/new-repository-name.git (push)
```

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

Interactive rebase for undoing commits:

```bash
git rebase -i HEAD~N
```

The above command will open an interactive session in an editor (for example vim) with the last N commits sorted from oldest to newest. To undo a commit, delete the corresponding line of the commit and save the file. Git will rewrite the commits in the order listed in the file and because one (or many) commits were deleted, the commit will no longer be part of the history.

Running rebase will locally modify the history, after this one can use `force` to push the changes to remote without the deleted commit.

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

## Working with images, video and other binary content

Avoid committing frequently changed binary files, such as large images, video or compiled code to your git repository. Binary content is not diffed like text content, so cloning or pulling from the repository may pull each revision of the binary file.

One solution to this problem is `Git LFS (Git Large File Storage)` - an open source Git extension for versioning large files. You can find more information on Git LFS in the [Git LFS and VFS document](./git-lfs-and-vfs.md).

## Working with large repositories

When working with a very large repository of which you don't require all the files, you can use `VFS for Git` - an open source Git extension that virtualizes the file system beneath your Git repository, so that you seem to work in a regular working directory but while VFS for Git only downloads objects as they are needed. You can find more information on VFS for Git in the [Git LFS and VFS document](./git-lfs-and-vfs.md).

## Tools

* Visual Studio Code is a cross-platform powerful source code editor with built in git commands. Within Visual Studio Code editor you can review diffs, stage changes, make commits, pull and push to your git repositories.
You can refer to [Visual Studio Code Git Support](https://code.visualstudio.com/docs/editor/versioncontrol#_git-support) for documentation.

* Use a shell/terminal to work with Git commands instead of relying on [GUI clients](https://git-scm.com/downloads/guis/).

* If you're working on Windows, [posh-git](https://github.com/dahlbyk/posh-git) is a great PowerShell environment for Git. Another option is to use [Git bash for Windows](http://www.techoism.com/how-to-install-git-bash-on-windows/). On Linux/Mac, install git and use your favorite shell/terminal.
