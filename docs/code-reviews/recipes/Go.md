# Go Code Reviews

## Style Guide

[CSE](../../CSE.md) developers follow the [Effective Go](https://golang.org/doc/effective_go.html) Style Guide.

## Code Analysis / Linting

### Project Setup

Below is the project setup that you would like to have in your VS Code.

#### vscode-go extension

Using the Go extension for Visual Studio Code, you get language features like IntelliSense, code navigation, symbol search, bracket matching, snippets, etc. This extension includes rich language support for go in VS Code.

#### go vet

`go vet` is a static analysis tool that checks for common go errors, such as incorrect use of range loop variables or misaligned printf arguments. [CSE](../../CSE.md) Go code should be able to build with no `go vet` errors. This will be part of vscode-go extension.

#### golint

[golint](https://github.com/golang/lint) can be an effective tool for finding many issues, but it errors on the side of false positives. It is best used by developers when working on code, not as part of an automated build process. This is the default linter which is setup as part of the vscode-go extension.

## Automatic Code Formatting

### gofmt

`gofmt` is the automated code format style guide for Go. This is part of the vs-code extension and it is enabled by default to run on save of every file.

### golangci-lint

[golangci-lint](https://github.com/golangci/golangci-lint/) is the replacement for the now deprecated `gometalinter`. It is 2-7x faster than `gometalinter` [along with a host of other benefits](https://github.com/golangci/golangci-lint/#comparison).

One awesome feature of `golangci-lint` is that is can be easily introduced to an existing large codebase using the `--new-from-rev COMMITID`. With this setting only newly introduced issues are flagged, allowing a team to improve new code without having to fix all historic issues in a large codebase. This provides a great path to improving code-reviews on existing solutions. golangci-lint can also be setup as the default linter in VS Code.

Installation options for golangci-lint are present at [golangci-lint](https://github.com/golangci/golangci-lint#binary).

To use golangci-lint with VS Code, use the below recommended settings:

```json
"go.lintTool":"golangci-lint",
   "go.lintFlags": [
     "--fast"
   ]
   ```

## Build Validation

`gofmt` should be run as a part of every build to enforce the common standard.

To automate this process in Azure Devops you can add the following snippet to your `azure-pipelines.yaml` file. This will format any scripts in the `./scripts/` folder.

```yaml
- script: go fmt
  workingDirectory: $(System.DefaultWorkingDirectory)/scripts
  displayName: "Run code formatting"
  ```

  `govet` should be run as a part of every build to check code linting.

To automate this process in Azure Devops you can add the following snippet to your `azure-pipelines.yaml` file. This will check linting of any scripts in the `./scripts/` folder.

```yaml
- script: go vet
  workingDirectory: $(System.DefaultWorkingDirectory)/scripts
  displayName: "Run code linting"
  ```

Alternatively you can use golangci-lint as a step in the pipeline to do multiple enabled validations(including go vet and go fmt) of golangci-lint.

```yaml
- script: golangci-lint run --enable gofmt --fix
  workingDirectory: $(System.DefaultWorkingDirectory)/scripts
  displayName: "Run code linting"
  ```

## Pre-Commit Hooks

All developers should run `gofmt` in a pre-commit hook to ensure standard formatting.

### Step 1- Install pre-commit

Run `pip install pre-commit` to install pre-commit.
Alternatively you can run `brew install pre-commit` if you are using homebrew.

### Step 2- Add go-fmt in pre-commit

Add .pre-commit-config.yaml file to root of the go project. Run go-fmt on pre-commit by adding it to .pre-commit-config.yaml file like below.

```yaml
- repo: git://github.com/dnephin/pre-commit-golang
  rev: master
  hooks:
    - id: go-fmt
 ```

### Step 3

Run `$ pre-commit install` to setup the git hook scripts

## Sample Build Validation Pipeline in Azure DevOps

```yaml
trigger: master

pool:
   vmImage: 'ubuntu-latest'

steps:

- task: GoTool@0
  inputs:
    version: '1.13.5'

- task: Go@0
  inputs:
    command: 'get'
    arguments: '-d'
    workingDirectory: '$(System.DefaultWorkingDirectory)/scripts'


- script: go fmt
  workingDirectory: $(System.DefaultWorkingDirectory)/scripts
  displayName: "Run code formatting"

- script: go vet
  workingDirectory: $(System.DefaultWorkingDirectory)/scripts
  displayName: 'Run go vet'

- task: Go@0
  inputs:
    command: 'build'
    workingDirectory: '$(System.DefaultWorkingDirectory)'

- task: CopyFiles@2
  inputs:
    TargetFolder: '$(Build.ArtifactStagingDirectory)'
- task: PublishBuildArtifacts@1
  inputs:
     artifactName: drop
   ```

## Code Review Checklist

The Go language team maintains a list of common [Code Review Comments](https://github.com/golang/go/wiki/CodeReviewComments) for go that form the basis for a solid checklist for a team working in Go that should be followed in addition to the [CSE Code Review Checklist](../process-guidance/reviewer-guidance.md)

* [ ] Does this code [handle errors](https://golang.org/doc/effective_go.html#errors) correctly? This includes not throwing away errors with `_` assignments and returning errors, instead of [in-band error values](https://github.com/golang/go/wiki/CodeReviewComments#in-band-errors)?
* [ ] Does this code follow Go standards for method [receiver types](https://github.com/golang/go/wiki/CodeReviewComments#receiver-type)?
* [ ] Does this code [pass values](https://github.com/golang/go/wiki/CodeReviewComments#pass-values) when it should?
* [ ] Are interfaces in this code defined in the [correct packages](https://github.com/golang/go/wiki/CodeReviewComments#interfaces)?
* [ ] Do go-routines in this code have [clear lifetimes](https://github.com/golang/go/wiki/CodeReviewComments#goroutine-lifetimes)?
* [ ] Is parallelism in this code handled via go-routines and channels with [synchronous methods](https://github.com/golang/go/wiki/CodeReviewComments#synchronous-functions)?
* [ ] Does this code have meaningful [Doc Comments](https://github.com/golang/go/wiki/CodeReviewComments#doc-comments)?
* [ ] Does this code have meaningful [Package Comments](https://github.com/golang/go/wiki/CodeReviewComments#package-comments)?
* [ ] Does this code use [Contexts](https://github.com/golang/go/wiki/CodeReviewComments#contexts) correctly?
* [ ] Do unit tests fail with [meaningful messages](https://github.com/golang/go/wiki/CodeReviewComments#useful-test-failures)?
