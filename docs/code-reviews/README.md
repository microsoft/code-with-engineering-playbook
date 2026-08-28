# Code Reviews

Developers working on projects should conduct peer code reviews on every pull request (or check-in to a shared branch).

## Goals

Code review is a way to have a conversation about the code where participants will:

- **Improve code quality** by identifying and removing defects before they can be introduced into shared code branches.
- **Learn and grow** by having others review the code, we get exposed to unfamiliar design patterns or languages among other topics, and even break some bad habits.
- **Shared understanding** between the developers over the project's code.

## Reviewing AI-assisted changes

We review AI-generated code as untrusted code, confirming the change satisfies the work item, avoids unrelated generated code, and meets the same expectations as any other pull request.

- Inspect logic, edge cases, error handling, security, performance, accessibility, and maintainability.
- Require meaningful tests or evaluations for generated behavior.
- Check generated comments, documentation, and PR text for unsupported claims.

The [AI-Assisted Engineering](../ai-assisted-engineering/README.md) guide owns the shared baseline for human ownership, data and context hygiene, and authorship traceability.

## Resources

- [Code review tools](./tools.md)
- [Google's Engineering Practices documentation: How to do a code review](https://google.github.io/eng-practices/review/reviewer/)
- [Best Kept Secrets of Peer Code Review](https://static1.smartbear.co/smartbear/media/pdfs/best-kept-secrets-of-peer-code-review_redirected.pdf)
