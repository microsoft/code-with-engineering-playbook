# Code Reviews

Developers working on [CSE](../CSE.md) projects will conduct peer code reviews on every pull request (or check-in to a shared branch).

## Goals

1.  Improve code quality by catching defects before code is checked in.
1.  Software engineers grow by learning from each other.
1.  Participants working on a project develop a shared understanding of the project's code.

## Evidence and Measures

Many of these items can be automated or enforced by policy in modern version control and work item tracking systems. Verification of the policies on the master branch in VSTS, for example, may be sufficient evidence that a project team is conducting code reviews.

*   [ ] The master branches in all repositories have branch policies defined in line with the general guidance below.
*   [ ] All builds produced out of project repositories include appropriate linters, run unit tests, and complete with neither errors nor warnings.
*   [ ] Every bug work item should include a link to the pull request that introduced it, once the error has been diagnosed. This is meant to support learning, not assigning blame.
*   [ ] Each bug work item should include a note on how the bug might (or might not have) been caught in a code review.
*   [ ] The project team regularly updates their code review checklists to reflect common issues they have encountered.
*   [ ] Software engineering managers should review a sample of pull requests and/or be co-reviewers with other developers to help everyone improve their skills as code reviewers.

In the future, we may introduce specific measures to help teams track their own performance, like how many code reviews each developer performed on a specific project or how many round trips code reviews take. These measures can take the focus off of improving code quality through peer reviews. Through our [Retrospective](../Engineering/Retrospectives.md) process, we will work with teams to adapt our approach to measurement and evaluating evidence.

## General Guidance

The goal of code reviews is to identify and remove defects before they can be introduced into shared code branches. To the extent that parts of reviews can be automated via linters, human reviewers can focus on architectural and functional correctness. Human reviewers should focus on:

*   The correctness of the business logic embodied in the code.
*   The correctness of any new or changed tests.
*   The "readability" and maintainability of the overall design decisions reflected in the code.
*   The checklist of common errors that the team maintains for each programming language.

The following guidelines are framed prescriptively in terms of VSTS git, but apply equally to other version control and code review environments. Pull request is used as the generic term for a request to commit code to a shared branch.

*   Code review policies should be enforced on the master branch.
    *   Git should be configured to deny commits directly to master, enforcing that all changes are made through topic branch PRs.
        * For github the following branch protection settings should be enabled for master:
             * Protect this branch
             * Require pull request reviews before merging
             * Require status checks to pass before merging
             * Require branches to be up to date before merging
             * Include Administrators
    *   Our minimum number of reviewers is 1.
        *   Developers may not approve their own changes.
        *   Do not allow pull request completion if some reviewers have voted "Waiting" or "Reject".
        *   Each team may choose to _maintain or reset_ votes when code changes as part of a review.
    *   Every pull request _must_ be linked to a work item.
    *   All code review comments must be resolved before completing the pull request.
    *   Enforce the standard merge strategy described in [CSE](../CSE.md)'s [Source Control](../Engineering/SourceControl.md) guidance.
    *   Per [CSE](../CSE.md)'s [CI/CD](../Engineering/CICD.md) guidance, execute a build on every pull request and update to a pull request to verify that:
        *   The project builds without warnings.
        *   All unit tests pass.
        *   The code passes all configured lint rules.
*   In general, any other developer on the team may comment on a pull request.
    *   When creating a pull request, developers should ask for specific reviewers or additional reviewers when dealing with stacks that require specific expertise or when introducing a more complex change.
    *   Developers should vary from whom they request reviews and which developer's pull requests they are reviewing.
    *   Engineering managers and more senior developers should plan to devote more time to code reviews than other developers.

The team should understand what linters catch, and run them locally, before submitting PRs, so they don't expend time and energy looking for those issues when conducting reviews. The reviewer has a clear picture of the business logic required in the change before beginning the review. Reviewers should work from a team checklist to identify and address common issues. A short checklist of common issues to look for is a powerful tool in code reviews. It reminds reviewers to look for mistakes that have been issues for the team or the language in general. A checklist also provides a reviewer with a structured way to engage with code changes, beyond an in-order reading. This can prevent reviewers from seeing what they expect to see. The language specific guidelines include suggested starting checklists, but project teams and durable engineering crews should maintain their own updated checklists based on their experience. A reasonable checklist size is 10-20 items. Old items must be removed when new ones are added. Old items should be removed, or at least reevaluated,when reviewers stop seeing the issues in pull requests. As developers get better, through reviews, at avoiding the issues in the lists, the lists should adapt to continue improving the code.

Every code review should include the following general code review checklist items, in addition to language specific items:

1.  [ ] Are there unit tests that cover internally testing the newly added code and do they pass in the CI/CD system being used by the project?
1.  [ ] Does this code correctly implement the business logic?
1.  [ ] Do the tests for this code correctly test the code?
1.  [ ] Is this code designed to be testable?
1.  [ ] Is the code documented well?
1.  [ ] Does each method or function "do one thing well"? Reviewers should recommend when methods could be split up for maintainability and testability.
1.  [ ] Is PII and EUII treated correctly? In particular, make sure the code is not logging objects or strings that might contain PII (e.g. request headers).
1.  [ ] Have secrets been stripped before committing?
1.  [ ] Do unit tests mock dependencies so only the method under test is being executed?
1.  [ ] Is the deployment of the code scripted such that it is repeatable and ideally declarative?
1.  [ ] Is the PR a relatively small change? Optimal PR sizes for code reviews are typically described in terms like embodying less than three days of work or having [200 or fewer changed lines of code](https://smallbusinessprogramming.com/optimal-pull-request-size/). If not, suggest smaller user stories or more frequent PRs in the future to reduce the amount of code being reviewed in one PR.

## Language Specific Guidance

*   [C#](../Engineering/CodeReviews/CSharp.md)
*   [Go](../Engineering/CodeReviews/Go.md)
*   [Java](../Engineering/CodeReviews/Java.md)
*   [JavaScript](../Engineering/CodeReviews/JavaScript.md)
*   [Python](../Engineering/CodeReviews/Python.md)

## Resources

*   [Best Kept Secrets of Peer Code Review](https://smartbear.com/SmartBear/media/pdfs/best-kept-secrets-of-peer-code-review.pdf)

## Q&A

### Q: We pair or mob. Why do we need code reviews?

A: Our peer code reviews are structured around best practices to find specific kinds of errors. Much like you would still run a linter over mobbed code, you would still ask someone to make the last pass to make sure the code conforms to expected standards and avoids common pitfalls.

### Q: What if we do pair programming?

A: Someone outside of the pair should perform the code review. One of the other major benefits of code reviews is spreading knowledge about the code base to other members of the team that don't usually work in the part of the codebase under review.

### Q: What if we do mob programming?

A: A member of the mob who spent less (or no) time at the keyboard should perform the code review.
