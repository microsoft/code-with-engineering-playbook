# How to automate simple checks

- [Code Analysis / Linting](../../code-reviews/recipes/Markdown.md#code-analysis-linting)
  - [markdownlint](../../code-reviews/recipes/Markdown.md#markdownlint)
  - [markdown-link-check](https://github.com/tcort/markdown-link-check)
  - [Docker image for node-markdown-spellcheck](https://github.com/tmaier/docker-markdown-spellcheck)
  - [proselint](../../code-reviews/recipes/Markdown.md#proselint)
  - [write-good](../../code-reviews/recipes/Markdown.md#write-good)

- [VS Code Extensions](../../code-reviews/recipes/Markdown.md#vs-code-extensions)
  - [Write Good Linter](../../code-reviews/recipes/Markdown.md#write-good-linter)
  - [markdownlint](../../code-reviews/recipes/Markdown.md#markdownlint-extension)

![docs-checks](./images/docs-checks.png)

With [pre-commit](https://pre-commit.com/) we can use Git hook scripts to identify simple issues before submitting our code or documentation for review.

Linting can also be automated via [Build validation](../../code-reviews/recipes/Markdown.md#build-validation) for PRs.
