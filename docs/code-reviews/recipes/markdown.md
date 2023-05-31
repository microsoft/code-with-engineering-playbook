# Markdown Code Reviews

## Style Guide

Developers should treat documentation like other source code and follow the same rules and checklists when reviewing documentation as code.

Documentation should both use good Markdown syntax to ensure it's properly parsed, and follow good [writing style guidelines](#writing-style-guidelines) to ensure the document is easy to read and understand.

## Markdown

Markdown is a lightweight markup language that you can use to add formatting elements to plaintext text documents. Created by John Gruber in 2004, Markdown is now one of the world’s most popular markup languages.

Using Markdown is different from using a WYSIWYG editor. In an application like Microsoft Word, you click buttons to format words and phrases, and the changes are visible immediately. Markdown isn’t like that. When you create a Markdown-formatted file, you add Markdown syntax to the text to indicate which words and phrases should look different.

You can find more information and full documentation [here](https://www.markdownguide.org/).

## Linters

Markdown has specific way of being formatted. It is important to respect this formatting, otherwise some interpreters which are strict won't properly display the document. Linters are often used to help developers properly create documents by both verifying proper Markdown syntax, grammar and proper English language.

A good setup includes a markdown linter used during editing and PR build verification, and a grammar linter used while editing the document. The following are a list of linters that could be used in this setup.

### markdownlint

[`markdownlint`](https://github.com/markdownlint/markdownlint) is a linter for markdown that verifies Markdown syntax, and also enforces rules that make the text more readable. [Markdownlint-cli](https://github.com/igorshubovych/markdownlint-cli) is an easy-to-use CLI based on Markdownlint.

It's available as a [ruby gem](https://github.com/markdownlint/markdownlint), an [npm package](https://github.com/DavidAnson/markdownlint), a [Node.js CLI](https://github.com/igorshubovych/markdownlint-cli) and a [VS Code extension](https://github.com/DavidAnson/vscode-markdownlint). The VS Code extension [Prettier](https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode) also catches all markdownlint errors.

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

A comprehensive list of markdownlint rules is available [here](https://github.com/DavidAnson/markdownlint/blob/main/doc/Rules.md).

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

The [`markdownlint extension`](https://marketplace.visualstudio.com/items?itemName=DavidAnson.vscode-markdownlint) examines the Markdown documents, showing warnings for rule violations while editing.

## Build Validation

### Linting

To automate linting with `markdownlint` for PR validation in GitHub actions,
you can either use linters aggregator as we do with [MegaLinter in this repository](https://github.com/microsoft/code-with-engineering-playbook/blob/main/.github/workflows/mega-linter.yml) or use the following YAML.

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
        markdownlint "**/*.md" --ignore node_modules
```

### Checking Links

To automate link check in your markdown files add `markdown-link-check` action to your validation pipeline:

```yaml
  markdown-link-check:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@master
    - uses: gaurav-nelson/github-action-markdown-link-check@v1
```

More information about `markdown-link-check` action options can be found at [`markdown-link-check` home page](https://github.com/gaurav-nelson/github-action-markdown-link-check)

## Code Review Checklist

In addition to the [Code Review Checklist](../process-guidance/reviewer-guidance.md) you should also look for these documentation specific code review items

- [ ] Is the document easy to read and understand and does it follow [good writing guidelines](#writing-style-guidelines)?
- [ ] Is there a single source of truth or is content repeated in more than one document?
- [ ] Is the documentation up to date with the code?
- [ ] Is the documentation technically, and ethically correct?

## Writing Style Guidelines

The following are some examples of writing style guidelines.

Agree in your team which guidelines you should apply to your project documentation.
Save your guidelines together with your documentation, so they are easy to refer back to.

### Wording

- Use inclusive language, and avoid jargon and uncommon words. The docs should be easy to understand
- Be clear and concise, stick to the goal of the document
- Use active voice
- Spell check and grammar check the text
- Always follow chronological order
- Visit [Plain English](https://plainenglish.co.uk/how-to-write-in-plain-english.html) for tips on how to write documentation that is easy to understand.

### Document Organization

- Organize documents by topic rather than type, this makes it easier to find the documentation
- Each folder should have a top-level README.md and any other documents within that folder should link directly or indirectly from that README.md
- Document names with more than one word should use underscores instead of spaces, for example `machine_learning_pipeline_design.md`. The same applies to images

### Headings

- Start with a H1 (single # in markdown) and respect the order H1 > H2 > H3 etc
- Follow each heading with text before proceeding with the next heading
- Avoid putting numbers in headings. Numbers shift, and can create outdated titles
- Avoid using symbols and special characters in headers, this causes problems with anchor links
- Avoid links in headers

### Links

- Avoid duplication of content, instead link to the `single source of truth`
- Link but don't summarize. Summarizing content on another page leads to the content living in two places
- Use meaningful anchor texts, e.g. instead of writing `Follow the instructions [here](../recipes/markdown.md)` write `Follow the [Markdown guidelines](../recipes/markdown.md)`
- Make sure links to Microsoft docs (like `https://learn.microsoft.com/something/somethingelse`) do not contain the language marker `/en-us/` or `/fr-fr/`, as this is automatically determined by the site itself.

### Lists

- List items should start with capital letters if possible
- Use ordered lists when the items describe a sequence to follow, otherwise use unordered lists
- For ordered lists, prefix each item with `1.` When rendered, the list items will appear with sequential numbering. This avoids number-gaps in list
- Do not add commas `,` or semicolons `;` to the end of list items, and avoid periods `.` unless the list item represents a complete sentence

### Images

- Place images in a separate directory named `img`
- Name images appropriately, avoiding generic names like `screenshot.png`
- Avoid adding large images or videos to source control, link to an external location instead

### Emphasis and special sections

- Use **bold** or _italic_ to emphasize
  > For sections that everyone reading this document needs to be aware of, use blocks
- Use `backticks` for code, a single backtick for inline code like `pip install flake8` and 3 backticks for code blocks followed by the language for syntax highlighting

  ```python
  def add(num1: int, num2: int):
    return num1 + num2
  ```

- Use check boxes for task lists
  - [ ] Item 1
  - [ ] Item 2
  - [x] Item 3
- Add a References section to the end of the document with links to external references
- Prefer tables to lists for comparisons and reports to make research and results more readable

  | Option   | Pros      | Cons      |
  |----------|-----------|-----------|
  | Option 1 | Some pros | Some cons |
  | Option 2 | Some pros | Some cons |

### General

- Always use Markdown syntax, don't mix with HTML
- Make sure the extension of the files is `.md` - if the extension is missing, a linter might ignore the files
