# Code Reviews

Developers working on [CSE](../CSE.md) projects should conduct peer code reviews on every pull request (or check-in to a shared branch).

## Goals

Code reviews is a way to have a conversation about the code where participants will:

- Improve code quality by identifying and removing defects before they can be introduced into shared code branches.
- Grow by learning from each other about unfamiliar design patterns or languages among other topics, and even break some bad habits.
- Develop a shared understanding of the project's code.

## Sections

- [Process Guidance](./process-guidance/README.md)
- [Evidence and Measures](./evidence-and-measures/README.md)
- [Language Specific Guidance](./recipes/README.md)
- [Resources](#resources)
- [Q&A](#qa)

## Resources

- [Code review tools](tools.md)
- [Google's Engineering Practices documentation: How to do a code review](https://google.github.io/eng-practices/review/reviewer/)
- [Best Kept Secrets of Peer Code Review](https://static1.smartbear.co/smartbear/media/pdfs/best-kept-secrets-of-peer-code-review_redirected.pdf)

## Q&A

### Q: We pair or mob. Why do we need code reviews

Our peer code reviews are structured around best practices to find specific kinds of errors. Much like you would still run a linter over mobbed code, you would still ask someone to make the last pass to make sure the code conforms to expected standards and avoids common pitfalls.

### Q: What if we do pair programming

Someone outside of the pair should perform the code review. One of the other major benefits of code reviews is spreading knowledge about the code base to other members of the team that don't usually work in the part of the codebase under review.

### Q: What if we do mob programming

A member of the mob who spent less (or no) time at the keyboard should perform the code review.