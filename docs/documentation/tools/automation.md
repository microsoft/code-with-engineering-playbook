# How to Automate Simple Checks

If you want to automate some checks on your Markdown documents, there are several tools that you could leverage. For example:

- Code Analysis / Linting
  - [markdownlint](../../code-reviews/recipes/markdown.md#markdownlint) to verify Markdown syntax and enforce rules that make the text more readable.
  - [lychee](https://github.com/lycheeverse/lychee) to extract links from markdown texts and check whether each link is alive (200 OK) or dead.
  - [write-good](../../code-reviews/recipes/markdown.md#write-good) to check English prose.
  - [Docker image for node-markdown-spellcheck](https://github.com/tmaier/docker-markdown-spellcheck), a lightweight docker image to spellcheck markdown files.
  - [static code analysis](../../CI-CD/dev-sec-ops/secrets-management/static-code-analysis.md)

- [VS Code Extensions](../../code-reviews/recipes/markdown.md#vs-code-extensions)
  - [Write Good Linter](../../code-reviews/recipes/markdown.md#write-good-linter) to get grammar and language advice while editing a document.
  - [markdownlint](../../code-reviews/recipes/markdown.md#markdownlint-extension) to examine Markdown documents and get warnings for rule violations while editing.

- Automation
  - [pre-commit](https://pre-commit.com/) to use Git hook scripts to identify simple issues before submitting our code or documentation for review.
  - Check [Build validation](../../code-reviews/recipes/markdown.md#build-validation) to automate linting for PRs.
  - Check [CI Pipeline for better documentation](../../CI-CD/recipes/ci-pipeline-for-better-documentation.md) for a sample pipeline with `markdownlint`, `lychee` and `write-good`.

Sample output:

![docs-checks](./images/docs-checks.png)

## On Linting Rules

The team needs to be clear what linting rules are required and shouldn't be overridden with tooling or comments. The team should have consensus on when to override tooling rules.
