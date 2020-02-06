# TypeScript Code Reviews

TypeScript projects should have linting configured, and should refuse PR's that do not comply with
the project's linting standard.

## Setting up [ESLint](https://eslint.org/docs/about/)

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

Add a `.eslintignore` with files & folders to omit:

```ignore
# don't ever lint node_modules
node_modules
# don't lint build output
dist
# don't lint nyc coverage
coverage
```

Add the following to the `scripts` of your `package.json`:

```json
"scripts": {
    "lint": "eslint . --ext .js,.jsx,.ts,.tsx"
}
```

You can run linting with: 

```bash
npm run lint
```

## Setting up [Prettier](https://prettier.io/docs/en/)

Prettier is an opinionated code formatter. You can find a getting started guide [here](https://prettier.io/docs/en/integrating-with-linters.html).

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

## Autoformatting with VS Code

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

## Code Review Checklist

In addition to the [Code Review checklist](../readme.md), TypeScript code should compile without
error and should not raise linting errors.
