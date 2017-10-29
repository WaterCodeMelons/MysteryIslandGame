# MysteryIslandGame
A 3D Unity Engine based game. University project.

---

### Git download
> https://git-scm.com/

### To clone the repository use
> **git clone** https://github.com/WaterCodeMelons/MysteryIslandGame.git

### To get the latest updates on the repo before working on the project. Inside the folder of the project
> **git pull**

### To list branches
> **git branch**

### To switch branch
> **git checkout <branch_name>**

### To stage changes
> * **git add -A** - stage add/update/remove changes
> * **git add .** - stage add/update changes
> * **git add -u** - stage update/remove changes

### To commit use
> * **git commit** - This let's you write the heading and body of a commit.
> * **git commit -m "Text"** - Commit with just the heading.

---

### To clean Your directory from unwanted files such as untracked or ignored by .gitignore You can run 
> `git clean -fxd`

##### Explanation
`git clean` accepts parameters such as:
* `-f` - If the Git configuration variable clean.requireForce is not set to false, git clean will refuse to delete files or directories unless given -f, -n or -i. Git will refuse to delete directories with .git sub directory or file unless a second -f is given.
* `-x` - git will not use the standard ignore rules read from .gitignore
* `-d` - remove untracked directories in addition to untracked files
* `-n` - dry run. don’t actually remove anything, just show what would be done.

##### Dry example

<img src="https://i.imgur.com/sRkGhLh.png?1" width="100%" alt="Cmd" />

---

> ##### The `.gitignore` file in our project is configured so our repository takes as little space as possible to allow faster syncs. When You clone the repo and open with Unity Editor. Unity will have to build Your project cache and solutions stored within `library, obj, .csproj`. You can remove the files anytime with `git clean -fxd` but Unity will have to rebuild them when neccessary. The .gitignore allows us to commit changes without uploading directories and files which are not neccessary to build the project.

---

Use this chart as Your workflow model.

<img src="https://i.stack.imgur.com/F00b8.png" width="100%" alt="Gitflow chart" />

---

# Git flow

When You want to add a new feature on an existing repository using gitflow, first pull all branches:
> **git pull origin --all**

Switch to develop
> **git checkout develop**

Create a feature
> **git flow feature start <feature-name>**

Create a feature
> **git flow feature start <feature-name>**

When you create a new feature, git-flow should automatically switch You to the feature/<feature-name> branch and You can check that with `git branch`. If not then:
> **git checkout feature/<feature-name>**

You can now stage changes with `git add -A` and commit them using `git commit` and the VIM editor or `git commit -m "title"`
> **git add -A**
> **git commit / git commit -m "title"**

When You're done with changes You can publish Your feature:
> **git flow feature publish <feature-name>**

To pull a feature use:
> **git flow feature pull origin <feature-name>**

Cheatsheet
> https://danielkummer.github.io/git-flow-cheatsheet/index.pl_PL.html
---