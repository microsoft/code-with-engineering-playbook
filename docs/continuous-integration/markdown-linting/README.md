# CI Pipeline for better documentation

## Introduction

Most projects start with spikes, where developers and analysts produce lots of documentation.

But sometimes, these documents don't have a standard and each one write them accordingly with their preference. Add to that
the time a reviewer will spend confirming grammar, searching for typos or non-inclusive language.

This pipeline addresses that!

## The Pipeline

The pipeline uses the following `npm` modules:

- [markdownlint](https://github.com/DavidAnson/markdownlint): add standardization using [rules](https://github.com/DavidAnson/markdownlint#rules--aliases)
- [markdown-link-check](https://github.com/tcort/markdown-link-check): check the links in the documentation and report broken
ones
- [write-good](https://github.com/btford/write-good): linter for English prose

We have been use this pipeline for more than one year in different engagements and always received great feedback from the
customers!

## How does it work

To start using this pipeline:

1. Download the files from [this repository](https://github.com/squassina/doc-pipeline/tree/main/repo-root)
1. Unzip the folders and files to your repository root if the repository is empty
    - if it's not brand new, copy the files and make the required adjustments:
        - check `.azdo` so it matches your repository standard
        - check `package.json` so you don't overwrite one you already have in the process. Also update the file if you changed
          the name of the `.azdo` folder.
1. Create the pipeline in Azure DevOps or GitHub

## References

[Markdown Code Reviews in the Code With Engineering Playbook](https://microsoft.github.io/code-with-engineering-playbook/code-reviews/recipes/markdown/#code-review-checklist)
