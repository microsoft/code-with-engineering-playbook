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


### Automation - ```gometalinter```

```gometalinter``` is a tool that concurrently runs numerous linters and normalises their output to a standard format.
In order to automate the linting process, you can include a `gometalinter.json` settings file in your project and run the tool with
```sh 
gometalinter --config ./gometalinter.json ./...
```

`gometalinter.json`:
```json
{
    "Vendor": true,
    "Deadline": "5m",
    "Sort": ["linter", "severity", "path", "line"],
    "EnableGC": true,
    "WarnUnmatchedDirective": true,
    "DisableAll": true,
    "Linters": {
        "goimports": {
            "Command": "goimports -l --local github.com/{your-org}/{your-repo}"
        }
    },
    "Enable": [
        "deadcode",
        "gofmt",
        "gocyclo",
        "goimports",
        "golint",
        "gosimple",
        "ineffassign",
        "misspell",
        "unused",
        "vet"
    ]
}
```

**Note:** You can see that `golint` is included in the `gometalinter.json` file. Make sure you include [`//nolint: golint`](https://github.com/alecthomas/gometalinter#comment-directives) in your code if you encounter false positive results.

For more details visit [gometalinter](https://github.com/alecthomas/gometalinter)

## Starter Code Review Checklist

The Go language team maintains a list of common [Code Review Comments](https://github.com/golang/go/wiki/CodeReviewComments) for go that form the basis for a solid checklist for a team working in Go.

1. [ ] Does this code [handle errors](https://golang.org/doc/effective_go.html#errors) correctly? This includes not throwing away errors with ```_``` assignments and returning errors, instead of [in-band error values](https://github.com/golang/go/wiki/CodeReviewComments#in-band-errors)?
1. [ ] Does this code follow Go standards for method [receiver types](https://github.com/golang/go/wiki/CodeReviewComments#receiver-type)?
1. [ ] Does this code [pass values](https://github.com/golang/go/wiki/CodeReviewComments#pass-values) when it should?
1. [ ] Are interfaces in this code defined in the [correct packages](https://github.com/golang/go/wiki/CodeReviewComments#interfaces)?
1. [ ] Do goroutines in this code have [clear lifetimes](https://github.com/golang/go/wiki/CodeReviewComments#goroutine-lifetimes)?
1. [ ] Is parallelism in this code handled via goroutines and channels with [synchronous methods](https://github.com/golang/go/wiki/CodeReviewComments#synchronous-functions)?
1. [ ] Does this code have meaningful [Doc Comments](https://github.com/golang/go/wiki/CodeReviewComments#doc-comments)?
1. [ ] Does this code have meaningful [Package Comments](https://github.com/golang/go/wiki/CodeReviewComments#package-comments)?
1. [ ] Does this code use [Contexts](https://github.com/golang/go/wiki/CodeReviewComments#contexts) correctly?
1. [ ] Do unit tests fail with [meaningful messages](https://github.com/golang/go/wiki/CodeReviewComments#useful-test-failures)?
