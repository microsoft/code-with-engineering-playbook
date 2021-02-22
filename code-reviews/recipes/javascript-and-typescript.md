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

In addition to the [Code Review Checklist](../process-guidance/reviewer-guidance.md) you should also look for these JavaScript specific code review items

* [ ] Does the code stick to our formatting and code standards? Does running prettier and ESLint over the code should yield no warnings or errors respectively?
* [ ] Does the change re-implement code that would be better served by pulling in a well known module from the ecosystem?
* [ ] Does TypeScript code compile without raising linting errors
