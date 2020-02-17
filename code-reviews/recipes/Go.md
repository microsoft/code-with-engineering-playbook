# Go Code Reviews

## Go Style Guide

```gofmt``` is the automated code format style guide for Go.

[Effective Go](https://golang.org/doc/effective_go.html) describes other standard elements of Go style we follow.

## Linters

### ```gofmt```

All developers should run ```gofmt``` in a pre-commit hook to ensure standard formatting.

```gofmt``` should be run as a part of every build to enforce the common standard.

### ```go vet```

```go vet``` is a static analysis tool that checks for common go errors, such as incorrect use of range loop variables or misaligned printf arguments. [CSE](../CSE.md) Go code should be able to build with no ```go vet``` errors.


### What about ```golint```?

[```golint```](https://github.com/golang/lint) can be an effetive tool for finding many issues, but it errors on the side of false positives. It is best used by developers when working on code, not as part of an automated build process.


### Automation

#### `golangci-lint`

[`golangci-lint`](https://github.com/golangci/golangci-lint/) is the replacement for the now depricated `gometalinter`. It is 2-7x faster than `gometalinter` [along with a host of other benefits](https://github.com/golangci/golangci-lint/#comparison).

One awesome feature of `golangci-lint` is that is can be easily introduced to an existing large codebase using the `--new-from-rev COMMITID`. With this setting only newly introduced issues are flagged, allowing a team to improve new code without having to fix all historic issues in a large codebase. This provides a great path to improving code-reviews on existing solutions. 

## Starter Code Review Checklist

The Go language team maintains a list of common [Code Review Comments](https://github.com/golang/go/wiki/CodeReviewComments) for go that form the basis for a solid checklist for a team working in Go.

1. [ ] Does this code [handle errors](https://golang.org/doc/effective_go.html#errors) correctly? This includes not throwing away errors with ```_``` assignments and returning errors, instead of [in-band error values](https://github.com/golang/go/wiki/CodeReviewComments#in-band-errors)?
2. [ ] Does this code follow Go standards for method [receiver types](https://github.com/golang/go/wiki/CodeReviewComments#receiver-type)?
3. [ ] Does this code [pass values](https://github.com/golang/go/wiki/CodeReviewComments#pass-values) when it should?
4. [ ] Are interfaces in this code defined in the [correct packages](https://github.com/golang/go/wiki/CodeReviewComments#interfaces)?
5. [ ] Do goroutines in this code have [clear lifetimes](https://github.com/golang/go/wiki/CodeReviewComments#goroutine-lifetimes)?
6. [ ] Is parallelism in this code handled via goroutines and channels with [synchronous methods](https://github.com/golang/go/wiki/CodeReviewComments#synchronous-functions)?
7. [ ] Does this code have meaningful [Doc Comments](https://github.com/golang/go/wiki/CodeReviewComments#doc-comments)?
8. [ ] Does this code have meaningful [Package Comments](https://github.com/golang/go/wiki/CodeReviewComments#package-comments)?
9. [ ] Does this code use [Contexts](https://github.com/golang/go/wiki/CodeReviewComments#contexts) correctly?
10. [ ] Do unit tests fail with [meaningful messages](https://github.com/golang/go/wiki/CodeReviewComments#useful-test-failures)?
