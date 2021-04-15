# Using Git LFS and VFS for Git introduction

**Git LFS** and **VFS for Git** are solutions for using Git with (large) binary files and large source trees.

## Git LFS

Git is very good and keeping track of changes in text-based files like code. But it is not that good in tracking binary files. For instance, if you store a Photoshop image file (PSD) in a repository, with every change, the complete file is stored again in the history. This can make the history of the Git repo very large, which makes a clone of the repository more and more time consuming.

A solution to work with these kind of files is using Git LFS (or Git Large File System). This is an extension to Git and must be installed separately. And it can only be used with a repository platform that supports LFS. GitHub.com and Azure DevOps for instance are platforms that have support for LFS.

The way it works in short, is that a placeholder file is stored in the repo with information for the LFS system. It looks something like this:

```shell
version https://git-lfs.github.com/spec/v1
oid a747cfbbef63fc0a3f5ffca332ae486ee7bf77c1d1b9b2de02e261ef97d085fe
size 4923023
```

The actual file is stored in a separate storage. This way Git will track changes in this placeholder file, not the large file. The combination of using Git and Git LFS will hide this from the developer though. You will just work with the repository and files as before.

When working with these large files yourself, you'll still see the git history grown on your own machine, as git will still start tracking these large files locally. But when you clone the repo, the history is actually pretty small. So it's beneficial for others not working directly on the large files.

### Pros of Git LFS

* Uses the end to end Git workflow for all files
* Git LFS supports file locking to avoid conflicts for undiffable assets
* Git LFS is fully supported in Azure DevOps Services

### Cons of Git LFS

* Everyone contributing to the repository needs to install Git LFS
* If not set up properly:
  * Binary files committed through Git LFS are not visible as Git will only download the data describing the large file
  * Committing large binaries will push the full binary to the repository
* Git cannot merge the changes from two different versions of a binary file; file locking mitigates this
* Azure Repos do not support using SSH for repositories with Git LFS tracked files - for more information see the Git LFS [authentication documentation](https://github.com/git-lfs/git-lfs/blob/master/docs/api/authentication.md)

### Installation and use of Git LFS

Go to [https://git-lfs.github.com](https://git-lfs.github.com) and download and install the setup from there.

For every repository you want to use LFS, you have to go through these steps:

* Setup LFS for the repo:

```shell
git lfs install
```

* Indicate which files have to be considered as large files (or binary files). As an example, to consider all Photoshop files to be large:

```shell
git lfs track "*.psd"
```

There are more fine grained ways to indicate files in a folder and more. See the [Git LFS Documentation](https://github.com/git-lfs/git-lfs/tree/master/docs?utm_source=gitlfs_site&utm_medium=docs_link&utm_campaign=gitlfs).

With these commands a `.gitattribute` file is created which contains these settings and must be part of the repository.

From here on you just use the standard git commands to work in the repository. The rest will be handled by Git and Git LFS.

### Common LFS commands

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

## VFS for Git

Imagine a large repository containing multiple projects, ex. one per feature. As a developer you may only be working on some of the features, and thus you don't want to download all the projects in the repo. By default with Git however, cloning the repository means you will download *all* files/projects.

VFS for Git (or Virtual File System for Git) solves this problem, as it will only download what you need to your local machine. But if you look in the file system, e.g. with Windows Explorer, it will show all the folders and files including the correct file sizes.

The Git platform must support GVFS to make this work. GitHub.com and Azure DevOps both support this out of the box.

### Installation and use of VFS for Git

Microsoft create VFS for Git and made it open source. It can be found at [https://github.com/microsoft/VFSForGit](https://github.com/microsoft/VFSForGit). It's only available for Windows.

The necessary installers can be found at [https://github.com/Microsoft/VFSForGit/releases](https://github.com/Microsoft/VFSForGit/releases)

On the releases page you'll find two important downloads:

* Git 2.28.0.0 installer, which is a requirement for running VFS for Git. This is not the same as the standard Git for Windows install!
* SetupGVFS installer.

Download those files and install them on your machine.

To be able to use VFS for Git for a repository, a `.gitattributes` file needs to be added to the repo with this line in it:

```shell
* -text
```

To clone a repository to your machine using VFS for Git you use `gvfs` instead of `git` like so:

```shell
gvfs clone [URL] [dir]
```

Once this is done, you have a folder which contains a `src` folder which contains the contents of the repository. This is done because of a practice to put all outputs of build systems outside of this tree. This makes it easier to manage `.gitignore` files and to keep Git performant with lots of files.

For working with the repository you just use Git commands as before.

To remove a VFS for Git repository from your machine, make sure the VFS process is stopped and execute this command from the main folder:

```shell
gvfs unmount
```

This will stop the process and unregister it. After that you can safely remove the folder.

### References

* [Git LFS getting started](https://git-lfs.github.com/)
* [Git LFS manual](https://github.com/git-lfs/git-lfs/tree/master/docs)
* [Git LFS on Azure Repos](https://docs.microsoft.com/en-us/azure/devops/repos/git/manage-large-files?view=azure-devops)
