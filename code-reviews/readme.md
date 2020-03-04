# Code Reviews

Developers working on [CSE](../CSE.md) projects should conduct peer code reviews on every pull request (or check-in to a shared branch).

## Goals

Code reviews is a way to have a conversation about code where reviewers who haven't written the code will

1. Improve code quality by catching bugs before shipping it.
2. Grow by learning about unfamiliar design patterns or languages and even break some bad habits.
3. Develop a shared understanding of the project's code.

## Healthy Code Review process

To ensure that the code review process is healthy and meets the goals stated above, consider following these guidelines:

### General Guidance

1. Although modern DevOps environments incorporate tools for managing PRs, it can be useful to label tasks pending for review or to have a dedicated place for them on the task board.
    * AzDO: [Customize cards](https://docs.microsoft.com/en-us/azure/devops/boards/boards/customize-cards?view=azure-devops)
    * AzDO: [Add columns on task board](https://docs.microsoft.com/en-us/azure/devops/boards/sprints/customize-taskboard?view=azure-devops#add-columns)
2. In the daily standup meeting check tasks pending for review and make sure they have reviewers assigned.
3. Junior teams and teams new to the process can consider creating separate tasks for reviews together with the tasks themselves.

### Size guidance

We should always aim to have Pull Requests be as small as possible, without losing context and technical feasibility. Small pull requests have multiple advantages:

1. It's easier to review; a clear benefit for the reviewers.
2. It's easier to deploy, at least in terms of a bigger Pull Request. This is aligned with the strategy of release fast and release often.
3. Minimizes possible conflicts and stale Pull Requests, which are difficult to merge and keep in sync with master either because they're very dynamic or contain refactoring.

However, we should be aware to avoid having Pull Requests that include code without context or very loose coupled.

There are times where seem a big Pull Request is unavoidable, however, there are some strategies to keep Pull Requests small depending on the "cause" of the ineluctability:

#### Minimum Working Components

#### Layers

#### Feature Flag

### Reviewee's guidance

1. When starting to work on a task, break your code into the smallest logically separable units. [TODO: More on size here]
2. Before submitting a pull request (PR) :
   * Write tests that cover your changes.
   * Update the documentation related to your change.
   * All new and existing tests pass.
   * The code your wrote follows the style of the project.
   * Run linting checks.
   * Do manual testing (run the code) and make sure to not introduce a breaking change.

3. Once done with a unit of code submit a pull request (PR) that follows [pull-request-template.md](pull-request-template.md)
4. Add one or two reviewers (depending on your project's guidelines). Ideally, you would add at least someone who has expertise and is familiar with the project or the language used and someone who is less familiar with the project or language.
5. Be open to receive feedback, discuss design/code logic and address all comments as follows:
   * Resolve the comment if you will make the requested change
   * Mark the comment as won't fix if you are not going to make the requested changes and explain clearly the reasoning
   * Ask clarification questions on the review itself (not in a private chat) if you don't understand a reviewer's comment
   * If a comments thread went beyong 5 or 6 replies and there has been no conclusion, then make direct communication with you reviewer (call them or knock on door)
   * Mark the comment as pending and clearly state that you are going to address it in a future PR.
6. If the reviewer's haven't looked at your code in 24-48 hours, ping them to ensure a timely review process.
7. Once all comments have been addressed and your reviewers have approved you changes, you can submit your code.

## Reviewer's guidance

The goal of code reviews is to identify and remove defects before they can be introduced into shared code branches. To the extent that parts of reviews can be automated via linters, human reviewers can focus on architectural and functional correctness. Human reviewers should focus on:

* The correctness of the business logic embodied in the code.
* The correctness of any new or changed tests.
* The "readability" and maintainability of the overall design decisions reflected in the code.
* The checklist of common errors that the team maintains for each programming language.

Code reviews should use the below guidance and checklists to ensure positive and effective code reviews.

1. Understand the code you are reviewing  
    * Read every line changed.  
    * If we have a stakeholder review, it’s not necessary to run the PR unless it aids your understanding of the code.  
    * AzDO orders the files for you, but you should read the code in some logical sequence to aid understanding.  
    * If you don’t fully understand a change in a file because you don’t have context, click to view the whole file and read through surrounding code.
    * Ask the author to clarify.
2. Be considerate
    * Be positive – encouraging, appreciation for good practices.  
    * Avoid language that points fingers like “you” but rather use “we” or “this line” -- code reviews aren’t personal and language matters.
3. Make comments clear
    * Explain why the code needs to change.
    * Prefix a “point of polish” with “Nit:”.
    * If one or two comments don’t resolve a disagreement, talk in person or on the phone.
4. Decide on a common standard for each language  
    * Automate as much as possible (styling, etc.) to avoid the need for "Nit's" and allow the reviewer to focus more on functional aspects of the PR.

## First Design Pass

1. Pull Request Overview
    * Does the PR description make sense?
    * Do all the changes logically fit in this PR, or are there unrelated changes?
    * If necessary, are the changes made reflected in updates to the README or other docs? If the changes affect how the user builds code especially.

2. User Facing Changes
    * If the code involves a user-facing change, is there a GIF/photo that explains the functionality? If not, it might be key to validate the PR to ensure the change does what is expected.
    * Ensure UI changes look good without unexpected behavior.  

3. Design  
    * Do the interactions of the various pieces of code in the PR make sense?
    * Does the code recognize and incorporate architectures and coding patterns?

## Code Quality Pass

1. Complexity
    * Are functions too complex?  
    * Should a function be broken into multiple functions?
    * If a method has greater than 3 arguments, potentially overly complex.
    * Single responsibility principle – function or class should do one ‘thing’  
    * Can the code be understood easily by code readers?  
    * Does the code add functionality that isn’t needed? Is it overly complex?  

2. Naming/readability
    * Did the developer pick good names for functions, variables, etc?

3. Error Handling
    * Are errors handled gracefully and explicitly where necessary?  

4. Functionality  
    * Is there parallel programming in this PR that could cause race conditions? Carefully read through this logic.
    * Could the code be optimized? For example: are there more calls to the database than need be?  
    * If you may not fully understand how the code could affect the system, ask for help.
    * Are there security flaws?  
    * Does a variable name reveal any customer specific information?  
    * Is PII and EUII treated correctly? And not logging any PII information.

5. Style  
    * Are there extraneous comments? If the code isn’t clear enough to explain itself, then the code should be made simpler. Comments may be there to explain why some code exists.  
    * Does the code adhere to the style guide/conventions that we have agreed upon? We use automated styling like black and prettier.  

6. Tests
    * Tests should always be committed in the same PR as the code itself (‘I’ll add tests next’ is not acceptable)
    * Make sure tests are sensible and valid assumptions are made.

## Language Specific Guidance

* [Bash](recipes/Bash.md)
* [C#](recipes/CSharp.md)
* [Go](recipes/Go.md)
* [JavaScript and TypeScript](recipes/javascript-and-typescript.md)
* [Markdown](recipes/Markdown.md)
* [Python](recipes/Python.md)
* [Terraform](recipes/Terraform.md)

## Evidence and Measures

Many of these items can be automated or enforced by policy in modern version control and work item tracking systems. Verification of the policies on the master branch in [Azure DevOps](https://azure.microsoft.com/en-us/services/devops/) (AzDO) or [GitHub](https://github.com/), for example, may be sufficient evidence that a project team is conducting code reviews.

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

## Resources

* [Best Kept Secrets of Peer Code Review](https://static1.smartbear.co/smartbear/media/pdfs/best-kept-secrets-of-peer-code-review_redirected.pdf)

## Q&A

### Q: We pair or mob. Why do we need code reviews

A: Our peer code reviews are structured around best practices to find specific kinds of errors. Much like you would still run a linter over mobbed code, you would still ask someone to make the last pass to make sure the code conforms to expected standards and avoids common pitfalls.

### Q: What if we do pair programming

A: Someone outside of the pair should perform the code review. One of the other major benefits of code reviews is spreading knowledge about the code base to other members of the team that don't usually work in the part of the codebase under review.

### Q: What if we do mob programming

A: A member of the mob who spent less (or no) time at the keyboard should perform the code review.
