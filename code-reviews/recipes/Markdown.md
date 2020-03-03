# Markdown Code Reviews

## Style Guide

[CSE](../../CSE.md) developers treat documentation like other source code and follow the same rules and checklists when reviewing documentation as code.

Documentation should both use good markdown syntax to ensure it's properly parsed, and follow good [writing style guidelines](#writing-style) to ensure the document is easy to read and understand.

## Linting

Linting tools exist both for verifying proper markdown syntax as well as grammar and proper English language.

A good setup includes a markdown linter used during editing and PR build verification, and a grammar linter used while editing the document.

### markdownlint

[`markdownlint`](https://github.com/markdownlint/markdownlint) is a linter for markdown that verifies markdown syntax, and also enforces rules that make the text more readable.

It's available as a [ruby gem](https://github.com/markdownlint/markdownlint), an [nmp package](https://github.com/DavidAnson/markdownlint), a [Node.js CLI](https://github.com/igorshubovych/markdownlint-cli) and a [VS Code extension](https://github.com/DavidAnson/vscode-markdownlint).

Installing the Node.js CLI

```bash
npm install -g markdownlint-cli
```

Running markdownlint on a Node.js project

```bash
markdownlint **/*.md --ignore node_modules
```

Fixing errors automatically

```bash
markdownlint **/*.md --ignore node_modules --fix
```

### proselint

[`proselint`](http://proselint.com/) is a command line utility that lints the text contents of the document.  It checks for jargon, spelling errors, redundancy, corporate speak and other language related issues.

It's available both as a [python package](https://github.com/amperser/proselint/#checks) and a [node package](https://www.npmjs.com/package/proselint).

```bash
pip install proselint
npm install -g proselint
```

Run proselint

```bash
proselint document.md
```

### write-good

[`write-good`](https://github.com/btford/write-good) is a linter for English text that helps writing better documentation.

```bash
npm install -g write-good
```

Run write-good

```bash
write-good *.md
```

Run write-good without installing it

```bash
npx write-good *.md
```

Write Good is also available as an [extension for VS Code](https://marketplace.visualstudio.com/items?itemName=travisthetechie.write-good-linter)

## VS Code Extensions

### Write Good Linter

The [`Write Good Linter Extension`](https://marketplace.visualstudio.com/items?itemName=travisthetechie.write-good-linter) integrates with VS Code to give grammar and language advice while editing the document.

### markdownlint extension

The [`markdownlint extension`](https://marketplace.visualstudio.com/items?itemName=DavidAnson.vscode-markdownlint) examines the markdown documents, showing warnings for rule violations while editing.

## Build validation

To automate linting with `markdownlint` for PR validation in GitHub actions, use the following YAML.

```yaml
name: Markdownlint

on:
  push:
    paths:
      - "**/*.md"
  pull_request:
    paths:
      - "**/*.md"

jobs:
  lint:

    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v2
    - name: Use Node.js
      uses: actions/setup-node@v1
      with:
        node-version: 12.x
    - name: Run Markdownlint
      run: |
        npm i -g markdownlint-cli
        markdownlint "**/*.md"
```

## Code Review Checklist

Apart from the items on the [Code Review Checklist](../readme.md) you should also look for these markdown specific code review items

- [ ] Is the document easy to read and understand and does it follow [good writing guidelines](#writing-style-guidelines)?
- [ ] Is there a single source of truth or is content repeated in more than one document?
- [ ] Is the documentation up to date with the code?

## Writing Style Guidelines

The following are some examples of writing style guidelines.

Agree in your team which guidelines you should apply to your project documentation.
Save your guidelines together with your documentation so they are easy to refer back to.

### Wording

- Use inclusive language, and avoid jargon and uncommon words. The docs should be easy to understand.
- Be clear and consise, stick to the goal of the document.

### Document Organization

- Organize documents by topic rather than type, this makes it easier to find the documentation
- Each folder should have a top-level readme.md and any other documents within that folder should link directly or indirectly from that readme.md
- Document names with more than one word should use underscores instead of spaces, for example `machine_learning_pipeline_desgin.md`. The same applies to images.

### Headings

- Start with a H1 and respect the order H1 > H2 > H3 etc.
- Avoid putting numbers in headings. Numbers shift, and can create outdated titles
- Avoid using symbols and special characters in headers, this causes problems with anchor links
- Avoid links in headers

### Links

- Avoid duplication of content, instead link to the `single source of truth`
- Link but don't summarize. Summarizing content on another page leads to the content living in two places.
- Use meaningful anchor texts, e.g. instead of writing `Follow the instructions [here](../recipes/Markdown.md)` write `Follow the [Markdown guidelines](../recipes/Markdown.md)`

### Lists

- List items should start with capital letters
- Use ordered lists when the items describe a sequence to follow, otherwise use unordered lists
- For ordered lists, prefix each item with `1.` When rendered, the list items will appear with sequential numbering. This avoids number-gaps in list
- Do not add commas (,) or semicolons (;) to the end of list items, and avoid periods (.) unless the list item represents a complete sentence

### Images

- Place images in a separate directory named `img`
- Name images appropriately, avoiding generic names like `screenshot.png`
- Avoid adding large images or videos to source control, link to an external location instead.

### Emphasis

- Use **bold** or _italic_ or `tics` to emphasise.
  > For sections that everyone reading this document needs to be aware of, use blocks
