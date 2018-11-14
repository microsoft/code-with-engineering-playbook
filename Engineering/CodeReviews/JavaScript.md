# JavaScript/TypeScript Code Reviews

## Style Guide

We use [`prettier`](https://prettier.io/) to do code formatting for both JavaScript and TypeScript. Using an automated code formatting tool like Prettier enforces a well accepted style guide that was collaboratively built by a wide range of companies including Microsoft, Facebook, and AirBnB. It is highly recommended that you use one of the native editor integrations and enable format on save. In addition, by default, we use the following overrides (shown here in the config format for VSCode) to standardize on single quotes, a four space drop, and to do ESLinting:

```
{
    "prettier.singleQuote": true,
    "prettier.eslintIntegration": true,
    "prettier.tabWidth": 4
}
```

For higher level style guidance not covered by prettier, we follow the [AirBnB Style Guide](https://github.com/airbnb/javascript).

## Linter

All developers should run `eslint` in a pre-commit hook to ensure standard formatting. We highly recommend using an editor integration like [vscode-eslint](https://github.com/Microsoft/vscode-eslint) to provide realtime feedback.

## Code Review Checklist

In addition to the [general Code Review checklist](../CodeReviews.md), you should also look for these additional JavaScript related code review items:

1.  [ ] Does the code stick to our formatting and code standards? Does running prettier and ESLint over the code should yield no warnings or errors respectively?
1.  [ ] Does the change reimplement code that would be better served by pulling in a well known module from the ecosystem?

If you have great suggestions for things folks should be thinking about during a JavaScript code review, please feel free to submit a pull request.  
