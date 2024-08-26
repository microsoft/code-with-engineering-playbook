# How to Sync a Wiki Between Repositories

This is a quick guide to mirroring a Project Wiki to another repository.

```bash
# Clone the wiki
git clone <source wiki repo url>

# Add mirror repository as a remote
cd <source wiki repo working folder>
git remote add mirror <mirror repo that must already exist>
```

Now each time you wish to sync run the following to get latest from the source wiki repo:

```bash
# Get everything
git pull -v
```

> **Warning**: Check that the output of the pull shows "From source repo URL". If this shows the mirror repo url then you've forgotten to reset the tracking. Run `git branch -u origin/wikiMaster` then continue.

Then run this to push it to the mirror repo and reset the branch to track the source repo again:

```bash
# Push all branches up to mirror remote
git push -u mirror

# Reset local to track source remote
git branch -u origin/wikiMaster

```

Your output should look like this when run:

```ps
PS C:\Git\MyProject.wiki> git pull -v
POST git-upload-pack (909 bytes)
remote: Azure Repos
remote: Found 5 objects to send. (0 ms)
Unpacking objects: 100% (5/5), done.
From https://.....  wikiMaster -> origin/wikiMaster
Updating 7412b94..a0f543b
Fast-forward
 .../dffffds.md | 4 ++++
 1 file changed, 4 insertions(+)


PS C:\Git\MyProject.wiki> git push -u mirror
Enumerating objects: 9, done.
Counting objects: 100% (9/9), done.
Delta compression using up to 8 threads
Compressing objects: 100% (5/5), done.
Writing objects: 100% (5/5), 2.08 KiB | 2.08 MiB/s, done.
Total 5 (delta 4), reused 0 (delta 0)
remote: Analyzing objects... (5/5) (6 ms)
remote: Storing packfile... done (48 ms)
remote: Storing index... done (59 ms)
To https://......
   7412b94..a0f543b  wikiMaster -> wikiMaster
Branch 'wikiMaster' set up to track remote branch 'wikiMaster' from 'mirror'.


PS C:\Git\MyProject.wiki> git branch -u origin/wikiMaster
Branch 'wikiMaster' set up to track remote branch 'wikiMaster' from 'origin'.
```
