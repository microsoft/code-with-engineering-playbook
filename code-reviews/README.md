# Code Reviews

Developers working on [CSE](../CSE.md) projects should conduct peer code reviews on every pull request (or check-in to a shared branch).

## Goals

Code reviews is a way to have a conversation about the code where participants will:

- Improve code quality by identifying and removing defects before they can be introduced into shared code branches.
- Grow by learning from each other about unfamiliar design patterns or languages among other topics, and even break some bad habits.
- Develop a shared understanding of the project's code.

## Table of contents

- [Process Guidance: General](./process-guidance/README.md#general-guidance)
  - [Pull Requests](./pull-requests.md)
    - [General Process](./pull-requests.md#general-process)
    - [Size Guidance](./pull-requests.md#size-guidance)
    - [Commit Message Standardization](./pull-requests.md#commit-message-standardization)
    - [Pull Request Template](./pull-request-template.md)
  - Qualified PRs
    - Reflect well-defined, concise tasks
    - Compact in content
  - Guidelines
    - SLAs for code reviews
    - Manage tasks pending for review
      - [Customize AzDO task boards](./process-guidance/customize-ado.md#task-boards)
    - Leverage [code review tools](./tools.md)
  - [Measuring code review process](./process-guidance/README.md#measuring-code-review-process)
- [Process Guidance: Authors](./process-guidance/author-guidance.md)
  - [Add relevant reviewers](./process-guidance/author-guidance.md#add-relevant-reviewers)
    - [Customize Reviewers Policy](./process-guidance/customize-ado.md#reviewer-policies)
  - [Address comments](./process-guidance/author-guidance.md#be-open-to-receive-feedback)
    - Resolve if change has been made
    - Provide reason for "won't fix"
    - Discuss comments in the review
  - [Track progress](./process-guidance/author-guidance.md#track-progress)
- [Process Guidance: Reviewer](./process-guidance/reviewer-guidance.md)
  - [Focus](./process-guidance/reviewer-guidance.md)
    - Correctness of business logic
    - Correctness of tests
    - Readability and maintainability
    - Checklist of common errors
  - [General guidance](./process-guidance/reviewer-guidance.md#general-guidance)
    - [Understand the code](./process-guidance/reviewer-guidance.md#understand-the-code-you-are-reviewing)
    - [Be considerate](./process-guidance/reviewer-guidance.md#be-considerate)
    - [Make comments clear](./process-guidance/reviewer-guidance.md#make-comments-clear)
    - [Decide on a common standard and automate with e.g. linters](./process-guidance/reviewer-guidance.md#decide-on-a-common-standard-for-each-language)
  - [First design pass](./process-guidance/reviewer-guidance.md#first-design-pass)
    - [PR overview](./process-guidance/reviewer-guidance.md#pull-request-overview)
    - [User facing, UI changes](./process-guidance/reviewer-guidance.md#user-facing-changes)
    - [Design](./process-guidance/reviewer-guidance.md#design)
  - [Code quality pass](./process-guidance/reviewer-guidance.md#code-quality-pass)
    - [Complexity](./process-guidance/reviewer-guidance.md#complexity)
    - [Naming/readability](./process-guidance/reviewer-guidance.md#naming_readability)
    - [Error handling](./process-guidance/reviewer-guidance.md#error-handling)
    - [Functionality](./process-guidance/reviewer-guidance.md#functionality)
    - [Style](./process-guidance/reviewer-guidance.md#style)
    - [Tests](./process-guidance/reviewer-guidance.md#tests)
- [Evidence and Measures](./evidence-and-measures/README.md)
  - [Evidence](./evidence-and-measures/README.md#evidence)
    - [Branch policies](./evidence-and-measures/branch-policy.md)
    - Builds include linters and run unit tests
    - Bug work items
    - Update code review checklist
    - Improve skills as code reviewers
  - [Measures](./evidence-and-measures/README.md#measures)
    - Collect metrics e.g. Defect Removal Efficiency, Time metrics, Lines of Code
    - Manual tracking vs. AzDO dasboards
- [Language Specific Guidance](./recipes/README.md)
  - [Bash](./recipes/Bash.md)
  - [C#](./recipes/CSharp.md)
  - [Go](./recipes/Go.md)
  - [Java](./recipes/Java.md)
  - [JavaScript and TypeScript](./recipes/javascript-and-typescript.md)
  - [Markdown](./recipes/Markdown.md)
  - [Python](./recipes/Python.md)
  - [Terraform](./recipes/Terraform.md)
- [FAQ](./faq.md)
  - [Large PRs?](./faq.md#we-experience-very-large-prs-how-can-we-fix-this)
  - [Slow code reviews?](./faq.md#we-experience-slow-code-reviews-causing-delays-in-delivering-features)
  - [Complex PRs?](./faq.md#reviewing-a-complex-pr-on-github-can-be-hard-is-there-a-more-integrated-way)
  - [Enforcing code reviews](./faq.md#how-can-we-enforce-code-reviews)
  - [Code Reviews and pair/mob programming](./faq.md#we-pair-or-mob-why-do-we-need-code-reviews)
- Resources
  - [Code review tools](tools.md)
  - [Google's Engineering Practices documentation: How to do a code review](https://google.github.io/eng-practices/review/reviewer/)
  - [Best Kept Secrets of Peer Code Review](https://static1.smartbear.co/smartbear/media/pdfs/best-kept-secrets-of-peer-code-review_redirected.pdf)
