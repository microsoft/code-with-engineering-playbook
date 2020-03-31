# Go Code Reviews

## Go Style Guide

[CSE](../../CSE.md) developers follow the [Effective Go](https://golang.org/doc/effective_go.html) Style Guide.

## Code Analysis / Linting

### go vet

`go vet` is a static analysis tool that checks for common go errors, such as incorrect use of range loop variables or misaligned printf arguments. [CSE](../../CSE.md) Go code should be able to build with no `go vet` errors.

### golint

[golint](https://github.com/golang/lint) can be an effetive tool for finding many issues, but it errors on the side of false positives. It is best used by developers when working on code, not as part of an automated build process.

## Useful extensions for VS Code and Visual Studio

### vscode-go

Using the Go extension for Visual Studio Code, you get language features like IntelliSense, code navigation, symbol search, bracket matching, snippets etc.

## Automatic Code Formatting

### gofmt

`gofmt` is the automated code format style guide for Go.

### golangci-lint

[golangci-lint](https://github.com/golangci/golangci-lint/) is the replacement for the now depricated `gometalinter`. It is 2-7x faster than `gometalinter` [along with a host of other benefits](https://github.com/golangci/golangci-lint/#comparison).

One awesome feature of `golangci-lint` is that is can be easily introduced to an existing large codebase using the `--new-from-rev COMMITID`. With this setting only newly introduced issues are flagged, allowing a team to improve new code without having to fix all historic issues in a large codebase. This provides a great path to improving code-reviews on existing solutions.

## Build Validation

`gofmt` should be run as a part of every build to enforce the common standard.

To automate this process in Azure Devops you can add the following snippet to you `azure-pipelines.yaml` file. This will format any scripts in the `./scripts/` folder.
 
`- script: go fmt`\
  `workingDirectory: $(System.DefaultWorkingDirectory)/scripts`\
  `displayName: "Run code formatting"`
  
  `govet` should be run as a part of every build to check code linting.

To automate this process in Azure Devops you can add the following snippet to you `azure-pipelines.yaml` file. This will check linting of any scripts in the `./scripts/` folder.
 
`- script: go vet`\
  `workingDirectory: $(System.DefaultWorkingDirectory)/scripts`\
  `displayName: "Run code linting"`

## Pre-Commit Hooks

All developers should run `gofmt` in a pre-commit hook to ensure standard formatting.

### Step 1- Install pre-commit
pip install pre-commit or brew install pre-commit if you are using homebrew

### Step 2- Add go-fmt in pre-commit
Add .pre-commit-config.yaml to root of the project. Run go-fmt and go-vet on pre-commit by adding them to .pre-commit-config.yaml

```
- repo: git://github.com/dnephin/pre-commit-golang
  rev: master
  hooks:
    - id: go-fmt
    - id: go-vet
 ```
    
### Step 3
Run `pre-commit install` to setup the git hook scripts \

`$ pre-commit install`


## Code Review Checklist

The Go language team maintains a list of common [Code Review Comments](https://github.com/golang/go/wiki/CodeReviewComments) for go that form the basis for a solid checklist for a team working in Go that should be followed in addition to the [CSE Code Review Checklist](../README.md)

* [ ] Does this code [handle errors](https://golang.org/doc/effective_go.html#errors) correctly? This includes not throwing away errors with `_` assignments and returning errors, instead of [in-band error values](https://github.com/golang/go/wiki/CodeReviewComments#in-band-errors)?
* [ ] Does this code follow Go standards for method [receiver types](https://github.com/golang/go/wiki/CodeReviewComments#receiver-type)?
* [ ] Does this code [pass values](https://github.com/golang/go/wiki/CodeReviewComments#pass-values) when it should?
* [ ] Are interfaces in this code defined in the [correct packages](https://github.com/golang/go/wiki/CodeReviewComments#interfaces)?
* [ ] Do goroutines in this code have [clear lifetimes](https://github.com/golang/go/wiki/CodeReviewComments#goroutine-lifetimes)?
* [ ] Is parallelism in this code handled via goroutines and channels with [synchronous methods](https://github.com/golang/go/wiki/CodeReviewComments#synchronous-functions)?
* [ ] Does this code have meaningful [Doc Comments](https://github.com/golang/go/wiki/CodeReviewComments#doc-comments)?
* [ ] Does this code have meaningful [Package Comments](https://github.com/golang/go/wiki/CodeReviewComments#package-comments)?
* [ ] Does this code use [Contexts](https://github.com/golang/go/wiki/CodeReviewComments#contexts) correctly?
* [ ] Do unit tests fail with [meaningful messages](https://github.com/golang/go/wiki/CodeReviewComments#useful-test-failures)?
