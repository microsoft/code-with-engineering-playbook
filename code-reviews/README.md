# Code Reviews

Developers working on [CSE](../CSE.md) projects should conduct peer code reviews on every pull request (or check-in to a shared branch).

<!-- markdownlint-disable MD036 -->
**Table of contents**
<!-- markdownlint-enable MD036 -->

1. [Goals](#goals)
1. [General Guidance](#general-guidance)
1. [First Design Pass](#first-design-pass)
1. [Code Quality Pass](#code-quality-pass)
1. [Evidence and Measures](#evidence-and-measures)
1. [Language Specific Guidance](#language-specific-guidance)
1. [Resources](#resources)
1. [Q&A](#q&a)

## Goals

Code reviews is a way to have a conversation about the code where participants will:

1. Improve code quality by identifying and removing defects before they can be introduced into shared code branches.
2. Grow by learning from each other about unfamiliar design patterns or languages among other topics, and even break some bad habits.
3. Develop a shared understanding of the project's code.

## General Guidance

Code reviews should be part of the software engineering team process regardless of the development model. Furthermore, the team should learn to execute reviews in a timely manner. [Pull requests (PRs)](./pull-requests.md) left hanging can cause additional merge problems and go stale resulting in lost work. Qualified PRs are expected to reflect well-defined, concise tasks, and thus be compact in content. Reviewing a single task should then take relatively little time to complete.

To ensure that the code review process is healthy and meets the goals stated above, consider following these guidelines:

1. Although modern DevOps environments incorporate tools for managing PRs, it can be useful to label tasks pending for review or to have a dedicated place for them on the task board.
    * AzDO: [Customize cards](https://docs.microsoft.com/en-us/azure/devops/boards/boards/customize-cards?view=azure-devops)
    * AzDO: [Add columns on task board](https://docs.microsoft.com/en-us/azure/devops/boards/sprints/customize-taskboard?view=azure-devops#add-columns)
2. In the daily standup meeting check tasks pending for review and make sure they have reviewers assigned.
3. Junior teams and teams new to the process can consider creating separate tasks for reviews together with the tasks themselves.

As an author of a PR, you should:

1. Add relevant reviewers:
    * Add one or more reviewers (depending on your project's guidelines) to the PR. Ideally, you would add at least someone who has expertise and is familiar with the project or the language used
    * Adding someone less familiar with the project or the language can aid in verifying the changes are understandable, easy to read, and increases the expertise within the team
    * In CSE code-with projects with a customer team, it is important to include reviewers from both organizations for knowledge transfer
      * In AzDO this can be enforced by setting groups as required reviewers, see [Automatically include code reviewers](https://docs.microsoft.com/en-us/azure/devops/repos/git/branch-policies?view=azure-devops#automatically-include-code-reviewers)
1. Be open to receive feedback, discuss design/code logic and address all comments as follows:
   * Resolve a comment, if the requested change has been made.
   * Mark the comment as "won't fix", if you are not going to make the requested changes and provide a clear reasoning
     * If the requested change is within the scope of the task, "I'll do it later" is not an acceptible reason!
     * If the requested change is out of scope, create a new work item (task or bug) for it
   * If you don't understand a comment, ask questions in the review itself as opposed to a private chat
   * If a thread gets bloated without a conclusion, have a meeting with the reviewer (call them or knock on door)
1. If the reviewers have not responded in a reasonable time (generally a day or two), ping them or raise the issue in a daily meeting.

Since parts of reviews can be automated via linters and such, human reviewers can focus on architectural and functional correctness. Human reviewers should focus on:

* The correctness of the business logic embodied in the code.
* The correctness of any new or changed tests.
* The "readability" and maintainability of the overall design decisions reflected in the code.
* The checklist of common errors that the team maintains for each programming language.

Code reviews should use the below guidance and checklists to ensure positive and effective code reviews.

1. Understand the code you are reviewing
    * Read every line changed.
    * If we have a stakeholder review, it’s not necessary to run the PR unless it aids your understanding of the code.
    * AzDO orders the files for you, but you should read the code in some logical sequence to aid understanding.
    * If you don’t fully understand a change in a file because you don’t have context, click to view the whole file and read through the surrounding code or checkout the changes and view them in IDE.
    * Ask the author to clarify.
1. Be considerate
    * Be positive – encouraging, appreciation for good practices.
    * Avoid language that points fingers like “you” but rather use “we” or “this line” -- code reviews aren’t personal and language matters.
1. Make comments clear
    * Explain why the code needs to change.
    * Prefix a “point of polish” with “Nit:”.
    * If one or two comments don’t resolve a disagreement, talk in person or on the phone.
1. Decide on a common standard for each language
    * Automate as much as possible (styling, etc.) to avoid the need for "Nit's" and allow the reviewer to focus more on functional aspects of the PR.

## First Design Pass

1. Pull Request Overview
    * Does the PR description make sense?
    * Do all the changes logically fit in this PR, or are there unrelated changes?
    * If necessary, are the changes made reflected in updates to the README or other docs? If the changes affect how the user builds code especially.
1. User Facing Changes
    * If the code involves a user-facing change, is there a GIF/photo that explains the functionality? If not, it might be key to validate the PR to ensure the change does what is expected.
    * Ensure UI changes look good without unexpected behavior.
1. Design
    * Do the interactions of the various pieces of code in the PR make sense?
    * Does the code recognize and incorporate architectures and coding patterns?

## Code Quality Pass

1. Complexity
    * Are functions too complex?
    * Is the single responsibility principle followed? Function or class should do one ‘thing’.
    * Should a function be broken into multiple functions?
    * If a method has greater than 3 arguments, it is potentially overly complex.
    * Does the code add functionality that isn’t needed?
    * Can the code be understood easily by code readers?
1. Naming/readability
    * Did the developer pick good names for functions, variables, etc?
1. Error Handling
    * Are errors handled gracefully and explicitly where necessary?
1. Functionality
    * Is there parallel programming in this PR that could cause race conditions? Carefully read through this logic.
    * Could the code be optimized? For example: are there more calls to the database than need be?
    * How does the functionality fit in the bigger picture? Can it have negative effects to the overall system?
    * Are there security flaws?
    * Does a variable name reveal any customer specific information?
    * Is PII and EUII treated correctly? And not logging any PII information.
1. Style
    * Are there extraneous comments? If the code isn’t clear enough to explain itself, then the code should be made simpler. Comments may be there to explain why some code exists.
    * Does the code adhere to the style guide/conventions that we have agreed upon? We use automated styling like black and prettier.
1. Tests
    * Tests should always be committed in the same PR as the code itself (‘I’ll add tests next’ is not acceptable)
    * Make sure tests are sensible and valid assumptions are made.

## Evidence and Measures

Many of the code quality assurance items can be automated or enforced by policies in modern version control and work item tracking systems. Verification of the policies on the master branch in [Azure DevOps](https://azure.microsoft.com/en-us/services/devops/) (AzDO) or [GitHub](https://github.com/), for example, may be sufficient evidence that a project team is conducting code reviews.

* The master branches in all repositories have branch policies.
  * AzDO: [Configure branch policies](https://docs.microsoft.com/en-us/azure/devops/repos/git/branch-policies?view=azure-devops#configure-branch-policies)
  * AzDO: Configuring branch policies with the CLI tool:
    * [Create a policy configuration file](https://docs.microsoft.com/en-us/azure/devops/cli/policy-configuration-file?view=azure-devops#create-a-policy-configuration-file)
    * [Approval count policy](https://docs.microsoft.com/en-us/rest/api/azure/devops/policy/configurations/create?view=azure-devops-rest-5.1#approval-count-policy)
  * GitHub: [Configuring protected branches](https://help.github.com/en/github/administering-a-repository/configuring-protected-branches)
* All builds produced out of project repositories include appropriate linters, run unit tests.
* Every bug work item should include a link to the pull request that introduced it, once the error has been diagnosed. This helps with learning.
* Each bug work item should include a note on how the bug might (or might not have) been caught in a code review.
* The project team regularly updates their code review checklists to reflect common issues they have encountered.
* Software engineering managers should review a sample of pull requests and/or be co-reviewers with other developers to help everyone improve their skills as code reviewers.

The team can collect metrics of code reviews to measure their efficiency. Some useful metrics include:

* Defect Removal Efficiency (DRE) - a measure of the development team's ability to remove defects prior to release
* Time metrics:
  * Time used preparing for code inspection sessions
  * Time used in review sessions
* Lines of code (LOC) inspected per time unit/meeting

It is a perfectly reasonable solution to track these metrics manually e.g. in an Excel sheet. It is also possible to utilize the features of project management platforms - for example, AzDO enables dashboards for metrics including [tracking bugs](https://docs.microsoft.com/en-us/azure/devops/boards/backlogs/manage-bugs?view=azure-devops&tabs=new-web-form). You may find ready-made plugins for various platforms - see [GitHub Marketplace](https://github.com/marketplace) for instance - or you can choose to implement these features yourself.

Remember that since defects removed thanks to reviews is far less costly compared to finding them in production, the cost of doing code reviews is actually negative!

For more information, see links under [resources](#resources).

## Language Specific Guidance

* [Bash](./recipes/Bash.md)
* [C#](./recipes/CSharp.md)
* [Go](./recipes/Go.md)
* [JavaScript and TypeScript](./recipes/javascript-and-typescript.md)
* [Python](./recipes/Python.md)
* [Terraform](./recipes/Terraform.md)

## Resources

* [Google's Engineering Practices documentation: How to do a code review](https://google.github.io/eng-practices/review/reviewer/)
* [Best Kept Secrets of Peer Code Review](https://static1.smartbear.co/smartbear/media/pdfs/best-kept-secrets-of-peer-code-review_redirected.pdf)
* [A Guide to Code Inspections](http://www.ganssle.com/inspections.pdf)
* [Defect Removal Effectiveness](https://www.westfallteam.com/sites/default/files/papers/defect_removal_effectiveness.pdf)
* [Tools](tools.md)

## Q&A

### Q: We pair or mob. Why do we need code reviews

A: Our peer code reviews are structured around best practices to find specific kinds of errors. Much like you would still run a linter over mobbed code, you would still ask someone to make the last pass to make sure the code conforms to expected standards and avoids common pitfalls.

### Q: What if we do pair programming

A: Someone outside of the pair should perform the code review. One of the other major benefits of code reviews is spreading knowledge about the code base to other members of the team that don't usually work in the part of the codebase under review.

### Q: What if we do mob programming

A: A member of the mob who spent less (or no) time at the keyboard should perform the code review.
