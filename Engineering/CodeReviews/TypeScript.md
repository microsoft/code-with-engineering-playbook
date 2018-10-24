# TypeScript Code Reviews

## Style Guide

We use [`Prettier`](https://prettier.io/) to do code formatting for TypeScript. Using an automated code formatting tool like Prettier enforces a well accepted style guide that was collaboratively built by a wide range of companies including Microsoft, Facebook, and AirBnB. It is highly recommended that you use one of the native editor integrations and enable format on save. In addition, by default, we use the following overrides (shown here in the config format for VSCode) to standardize on single quotes and a 4-space indent:

```json
{
    ...
    "prettier.singleQuote": true,
    "prettier.tabWidth": 4
}
```

For higher level style guidance not covered by prettier, we follow the [AirBnB Style Guide](https://github.com/airbnb/javascript).

## Linter

All developers should run `TSLint` in a pre-commit hook to ensure standard formatting. We highly recommend using an editor integration like [vscode-tslint](https://github.com/Microsoft/vscode-tslint) to provide realtime feedback.

Since `Prettier` does not support integration with `TSLint`, we need to add a tslint.json file to the root of our project:

```json
{
    "defaultSeverity": "error",
    "extends": ["tslint:recommended"],
    "jsRules": {},
    "rules": {
        "quotemark": {
            "options": "single"
        },
        "arrow-parens": {
            "options": "ban-single-arg-parens"
        },
        "no-console": false,
        "trailing-comma": {
            "options": [
                {
                    "esSpecCompliant": true
                }
            ]
        },
        "jsdoc-format": false,
        "curly": {
            "options": ["ignore-same-line"]
        }
    },
    "rulesDirectory": []
}
```

## YAML

A 4-space indent makes YAML difficult to read, so you might consider adding the following to the `VSCode` User or Workspace Settings.

```json
{
    ...
    "[yaml]": {
        "editor.insertSpaces": true,
        "editor.tabSize": 2,
        "editor.autoIndent": false
    }
}
```

You will then need to exclude YAML files from `Prettier` by adding a .prettierignore file to the root of our project:

```
**/*.yaml
```

## Code Review Checklist

In addition to the [general Code Review checklist](../CodeReviews.md), you should also look for these additional TypeScript related code review items:

1.  [ ] Does the code stick to our formating and code standards? Does running prettier and TSLint over the code should yield no warnings or errors respectively?
1.  [ ] Does the change reimplement code that would be better served by pulling in a well known module from the ecosystem?

If you have great suggestions for things folks should be thinking about during a TypeScript code review, please feel free to submit a pull request.
