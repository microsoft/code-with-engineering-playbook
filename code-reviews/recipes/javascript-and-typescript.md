# JavaScript/TypeScript Code Reviews

## Style Guide

[CSE](../../CSE.md) developers use [prettier](https://prettier.io/) to do code formatting for JavaScript.

Using an automated code formatting tool like Prettier enforces a well accepted style guide that was collaboratively built by a wide range of companies including Microsoft, Facebook, and AirBnB.

For higher level style guidance not covered by prettier, we follow the [AirBnB Style Guide](https://github.com/airbnb/javascript).

## Code Analysis / Linting

### eslint

Per guidance outlined in [Palantir's 2019 TSLint roadmap](https://medium.com/palantir/tslint-in-2019-1a144c2317a9),
TypeScript code should be linted with [ESLint](https://github.com/eslint/eslint). Resources for
linting TypeScript code with ESLint can be found in the [typescript-eslint](https://github.com/typescript-eslint/typescript-eslint)
repository.

To [install and configure linting with ESLint](https://github.com/typescript-eslint/typescript-eslint/tree/master/docs/getting-started/linting),
install the following packages as dev-dependencies:

```bash
npm install -D eslint @typescript-eslint/parser @typescript-eslint/eslint-plugin
```

Add a `.eslintrc.js` to the root of your project:

```javascript
module.exports = {
  root: true,
  parser: '@typescript-eslint/parser',
  plugins: [
    '@typescript-eslint',
  ],
  extends: [
    'eslint:recommended',
    'plugin:@typescript-eslint/eslint-recommended',
    'plugin:@typescript-eslint/recommended',
  ],
};
```

Add the following to the `scripts` of your `package.json`:

```json
"scripts": {
    "lint": "eslint . --ext .js,.jsx,.ts,.tsx --ignore-path .gitignore"
}
```

This will lint all `.js`, `.jsx`, `.ts`, `.tsx` files in your project and omit any files or
directories specified in your `.gitignore`.

You can run linting with:

```bash
npm run lint
```

## Setting up Prettier

[Prettier](https://prettier.io/docs/en/) is an opinionated code formatter.

[Getting started guide](https://prettier.io/docs/en/integrating-with-linters.html).

Install with `npm` as a dev-dependency:

```bash
npm install -D prettier eslint-config-prettier eslint-plugin-prettier
```

Add `prettier` to your `.eslintrc.js`:

```javascript
module.exports = {
  root: true,
  parser: '@typescript-eslint/parser',
  plugins: [
    '@typescript-eslint',
  ],
  extends: [
    'eslint:recommended',
    'plugin:@typescript-eslint/eslint-recommended',
    'plugin:@typescript-eslint/recommended',
    'prettier/@typescript-eslint',
    'plugin:prettier/recommended',
  ],
};
```

This will apply the `prettier` ruleset when linting with ESLint.

## Auto formatting with VS Code

VS Code can be configured to automatically perform `eslint --fix` on save.

Create a `.vscode` folder in the root of your project and add the following to your
`.vscode/settings.json`:

```json
{
  "editor.codeActionsOnSave": {
    "source.fixAll.eslint": true
  },
}
```

By default, we use the following overrides should be added to the VS Code configuration to standardize on single quotes, a four space drop, and to do ESLinting:

```json
{
    "prettier.singleQuote": true,
    "prettier.eslintIntegration": true,
    "prettier.tabWidth": 4
}
```

## Build Validation

To automate this process in Azure Devops you can add the following snippet to your pipeline definition yaml file. This will lint any scripts in the `./scripts/` folder.

```yaml
- task: Npm@1
  displayName: 'Lint'
  inputs:
    command: 'custom'
    customCommand: 'run lint'
    workingDir: './scripts/'
```

## Pre-commit hooks

All developers should run `eslint` in a pre-commit hook to ensure standard formatting. We highly recommend using an editor integration like [vscode-eslint](https://github.com/Microsoft/vscode-eslint) to provide realtime feedback.

1. Under `.git/hooks` rename `pre-commit.sample` to `pre-commit`
1. Remove the existing sample code in that file
1. There are many examples of scripts for this on gist, like [pre-commit-eslint](https://gist.github.com/linhmtran168/2286aeafe747e78f53bf)
1. Modify accordingly to include TypeScript files (include ts extension and make sure typescript-eslint is set up)
1. Make the file executable: `chmod +x .git/hooks/pre-commit`

As an alternative [husky](https://github.com/typicode/husky) can be considered to simplify pre-commit hooks.

## Code Review Checklist

In addition to the [Code Review Checklist](../process-guidance/reviewer-guidance.md) you should also look for these JavaScript and TypeScript specific code review items.

### Javascript

* [ ] Does the code stick to our formatting and code standards? Does running prettier and ESLint over the code should yield no warnings or errors respectively?
* [ ] Does the change re-implement code that would be better served by pulling in a well known module from the ecosystem?
* [ ] Is `"use strict";` used to reduce errors with non declared variables?
* [ ] Are unit tests used where possible, also for APIs? [Ponicode](https://www.ponicode.com/) can help with test generation. Ponicode creates test files using Jest syntax.
* [ ] Are tests arranged correctly with the Arrange/Act/Assert pattern and properly documented in this way?
* [ ] Are best practices for error handling followed, as well as `try catch finally` statements?
* [ ] Are the `doWork().then(doSomething).then(checkSomething)` properly followed for async calls, including `expect`, `done`?
* [ ] Instead of using raw strings, are constants used in the main class? Or if these strings are used across files/classes, is there a static class for the constants?
* [ ] Are magic numbers explained? There should be no number in the code without at least a comment of why it is there. If the number is repetitive, is there a constant/enum or equivalent?
* [ ] If there is an asynchronous method, does the name of the method end with the `Async` suffix?
* [ ] Is a minimum level of logging in place? Are the logging levels used sensible?
* [ ] Is document fragment manipulation limited to when you need to manipulate multiple sub elements?

### TypeScript

* [ ] Does the code stick to our formatting and code standards? Does running prettier and ESLint over the code should yield no warnings or errors respectively?
* [ ] Does the change re-implement code that would be better served by pulling in a well known module from the ecosystem?
* [ ] Does TypeScript code compile without raising linting errors?
* [ ] Instead of using raw strings, are constants used in the main class? Or if these strings are used across files/classes, is there a static class for the constants?
* [ ] Are magic numbers explained? There should be no number in the code without at least a comment of why it is there. If the number is repetitive, is there a constant/enum or equivalent?
* [ ] Is there a proper `/* */` in the various classes and methods?
* [ ] Are unit tests used where possible? In most cases, tests should be present for APIs, interfaces with data access, transformation, backend elements and models. [Ponicode](https://www.ponicode.com/) can help with test generation. Ponicode creates test files using Jest syntax.
* [ ] Are tests arranged correctly with the Arrange/Act/Assert pattern and properly documented in this way?
* [ ] If there is an asynchronous method, does the name of the method end with the `Async` suffix?
* [ ] Is a minimum level of logging in place? Is the logging level is the right one?
* [ ] Is document fragment manipulation limited to when you need to manipulate multiple sub elements?
* [ ] Is not to much code used in the controller and are heavy operations done in the backend?
* [ ] Is event handling on the html efficiently done?
