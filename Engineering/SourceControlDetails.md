# Git - The basics
[Install Git](https://git-scm.com/downloads) and follow the [First-Time Git Setup](https://git-scm.com/book/en/v2/Getting-Started-First-Time-Git-Setup)

## Tools
It's recommended to use a shell/terminal to work with Git commands and not just to rely on [GUI clients](https://git-scm.com/downloads/guis/). If you're working on Windows, [posh-git](https://github.com/dahlbyk/posh-git) is a great PowerShell environment for Git. Another option is to use [Git bash for Windows](http://www.techoism.com/how-to-install-git-bash-on-windows/). On Linux/Mac, install git and simply use your favorite shell/terminal. 

# Working with repositories
## Contributing to an existing repository
When working on an existing project, `git clone` the repository and ensure you understand the team's branch, merge and release strategy (e.g. through the projects [CONTRIBUTING.md file](https://blog.github.com/2012-09-17-contributing-guidelines/)).

## Creating a new repository
If you create a new repository, agree on your branch, merge and release strategies upfront and document them in your [CONTRIBUTING.md](https://blog.github.com/2012-09-17-contributing-guidelines/). Also lock the default branches and define who can approve and merge Pull Requests into your default branches.

### Required files in default branch for public repositories
A public repository needs to have the following files in the root directory of the default branch:
* a [LICENSE](Templates/LICENSE) file 
* a [README.md](Templates/README.md) file
* a [CONTRIBUTING.md](Templates/CONTRIBUTING.md) file 

It's also important to reference the Microsoft Open Source Code of Conduct in the [README.md](Templates/README.md) and/or [CONTRIBUTING.md](Templates/CONTRIBUTING.md) files.

Links to [CSE](../CSE.md) template files: [LICENSE](Templates/LICENSE), [README.md](Templates/README.md) and [CONTRIBUTING.md](Templates/CONTRIBUTING.md) 

To start to contribute by creating your own branch (e.g. `user/your_alias/feature_name`) and committing early and often - just ensure your commit comments are useful to others and describe the *WHAT* and *WHY* (instead of the *HOW*). 

# Commit history
Agree if you want a linear or non-linear commit history. There are pros and cons to both approaches as highlighted in the following two blog posts:
*  Pro linear: [A tidy, linear Git history](www.bitsnbites.eu/a-tidy-linear-git-history/)
*  Con linear: [Why you should stop using Git rebase](https://medium.com/@fredrikmorken/why-you-should-stop-using-git-rebase-5552bee4fed1)

## Approach for non-linear commit history
Merging `topic` into `master`
```
  A---B---C topic
 /         \
D---E---F---G---H master

git fetch origin
git checkout master
git merge topic
```
## Two approaches to achieve a linear commit history
### Rebase topic branch before merging into master 
Before merging `topic` into `master`, we rebase `topic` with the   :
```
          A---B---C topic
         /         \
D---E---F-----------G---H master

git fetch origin
git rebase master topic
git checkout master
git merge topic
```
### Rebase topic branch before squash merge into master
[Squash merging](https://docs.microsoft.com/en-us/vsts/git/merging-with-squash?view=vsts) is a merge option that allows you to condense the Git history of topic branches when you complete a pull request. Instead of each commit on `topic` being added to the history of `master`, a squash merge takes all the file changes and adds them to a single new commit on `master`. 
```
          A---B---C topic
         /        
D---E---F-----------G---H master

Create a PR topic --> master in VSTS and approve using the squash merge option
```

# Write good commit comments
In a nutshell, if you use `git commit -m` then you're most likely not write the best commit messages ;-)

See [How to Write a Git Commit Message](https://chris.beams.io/posts/git-commit/) for the reasoning and [A Note About Git Commit Messages](https://tbaggery.com/2008/04/19/a-note-about-git-commit-messages.html) for more context. 
This section is merely a tl;dr summary. 
1. Separate subject from body with a blank line
2. Limit the subject line to 50 characters
3. Capitalize the subject line
4. Do not end the subject line with a period
5. Use the imperative mood in the subject line
6. Wrap the body at 72 characters
7. Use the body to explain what and why vs. how

Here an example:
```
Summarize changes in around 50 characters or less

More detailed explanatory text, if necessary. Wrap it to about 72
characters or so. In some contexts, the first line is treated as the
subject of the commit and the rest of the text as the body. The
blank line separating the summary from the body is critical (unless
you omit the body entirely); various tools like `log`, `shortlog`
and `rebase` can get confused if you run the two together.

Explain the problem that this commit is solving. Focus on why you
are making this change as opposed to how (the code explains that).
Are there side effects or other unintuitive consequences of this
change? Here's the place to explain them.

VSTS understands Markdown, so you can use that sparingly throughout.

Further paragraphs come after blank lines.

 - Bullet points are okay, too
 - Typically a hyphen or asterisk is used for the bullet, preceded
   by a single space (no blank lines between them on VSTS)

Put issue references to them at the bottom,
like this:

Resolves: #123
See also: #456, #789
```

You can specify the default git editor, which allows you to write your commit messages using your favorite editor. The following command makes vscode your default git editor:

```
git config --global core.editor "code --wait"
```

# Branch strategies
## Naming branches
Let's use the following naming conventions for branches:
 * personal branches: `user/your_alias/feature_name` 
 * feature branches for staging (testing, integration,...): `staging/feature_name` 
 * release branches: `release/release_name`

## Restrict access to default branches
* In VSTS it's recommended to specify the **minimum number of required reviewers** as well as the **commit strategy** if you want to enforce [squash merging](https://docs.microsoft.com/en-us/vsts/git/merging-with-squash?view=vsts). Here some details on [VSTS branch policies](https://docs.microsoft.com/en-us/vsts/git/branch-policies?view=vsts)
* In GitHub it's recommended to protect these branches by limiting the push access to reviewers only. Here some details how to [enable branch restrictions in GitHub](https://help.github.com/articles/enabling-branch-restrictions/)

# Release strategy
It is important that the team agrees on the project's release strategy upfront. The two most common approaches are the use of `tags` and/or `branches`. While using `tags` is lightweight and straightforward, `branches` provide extra flexibility in multi customer deployment that might require individual bug fixes in-between major releases.
## Using tags for releases
To create a git tag you simply use the `git tag` command. By default, the `git push` command doesn’t transfer tags to remote servers. You will have to explicitly push tags to a shared server after you have created them. This process is just like sharing remote branches — you can run `git push origin <tagname>`:

```
git tag -a v1.1 -m "version 1.1"
git push origin v1.1
```

To checkout a specific version, you simply run `git push origin <tagname>`. Note that this will put you into a 'detached HEAD' state:
```
git checkout v1.1
```
Refer to the CI/CD section to see how to integrate specific version into your CI/CD pipeline

## Using branches for releases
TBD - lock branch


# More Git greatness

## Working with secrets (such as storage keys)
The best way to avoid leaking secrets is to store them in local/private files which will be excluded from being tracked in git. This is done by configuring the [.gitignore](https://git-scm.com/docs/gitignore) file.
E.g. the following pattern will exclude all files with the extension `.private.config`:
```
# remove private configuration
*.private.config
```

For more details on proper management of credentials and secrets in source control, and handling an accidental commit of secrets to source control, please refer to the the [Secrets Management](./SecretsManagement.md) document which has further information, split by language as well. 

## Reverting and deleting commits
There are two options to "undo" a commit: `git revert` and `git reset`. `git revert` creates a new commit that undoes commits while `git reset` allows to delete commits entirely from the commit history. 
>If you accidentally committed secrets/keys only `git reset` will remove them from the commit history!
   
To **delete** the latest commit use `HEAD~`:
```
git reset --hard HEAD~1
```
To delete commits back to a specific commit, use the respective commit id:
```
git reset --hard <sha1-commit-id>
```
after you deleted the unwanted commits, just push using `force`:
```
git push origin HEAD --force
```

## Multi service development and deployments
Submodules can be very useful in more complex deployment and/or development scenarios

Adding a submodule to your repo
```
git submodule add -b master <your_submodule>
```
Initialize and pull a repo with submodules:
```
git submodule init 
git submodule update --init --remote
git submodule foreach git checkout master
git submodule foreach git pull origin
```

## Stashing
`git stash` is super handy if you have un-committed changes in your working directory but you want to work on a different branch. You can simply run `git stash` and save the un-committed work and reverts back to the HEAD commit. You can retrieve the saved changes by running `git stash pop`:
```
git stash
...
git stash pop
```
Or you can simply move the current state into a new branch:
```
git stash branch <new_branch_to_save_changes>
```

