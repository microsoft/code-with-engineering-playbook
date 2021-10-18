# Inclusive Linting

As software professionals we should strive to promote an inclusive work environment, which naturally extends to the code we write. It's important to keep the use of inclusive language consistent across an entire project or repository.

To achieve this, we recommend using a text file analysis tool such as an inclusive linter and including this as a step in your CI pipelines.

## What to Lint for

The primary goal of an inclusive linter is to flag any occurrences of non-inclusive language within source code (and optionally suggest some alternatives). Non-inclusive words or phrases in a project can be found anywhere from comments and documentation to variable names.

An inclusive linter may include its own dictionary of "default" non-inclusive words and phrases to run against as a good starting point. These tools can also be customizable, oftentimes offering the ability to omit some terms and/or add your own.

The ability to add additional terms to your linter has the added benefit of enabling linting of sensitive language on top of inclusive linting. This can prevent things such as customer names or other non-public information from making it into your git history, for instance.

## Getting Started with an Inclusive Linter

### [`woke`]

One inclusive linter we recommend is `woke`. It is a language-agnostic CLI tool that detects non-inclusive language in your source code and recommends alternatives. While it has a default ruleset, you can customize it and/or define your own ruleset yaml file to be run against.

Running the tool locally is relatively straightforward:

```sh
$ woke test.txt

test.txt:2:2-11: `Blacklist` may be insensitive, use `denylist`, `blocklist` instead (warning)
* Blacklist
  ^
```

`woke` can be run locally on your machine or CI/CD system and is also available as a [GitHub Action]. For more information about configuration and usage, see the official [docs].

[`woke`]: https://github.com/get-woke/woke
[GitHub Action]: https://github.com/marketplace/actions/run-woke
[docs]: https://docs.getwoke.tech/
