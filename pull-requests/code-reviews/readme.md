# Code Reviews

Developers working on [CSE](../CSE.md) projects should conduct peer code reviews on every pull request (or check-in to a shared branch).

## Goals

1.  Improve code quality by catching defects before code is checked in.
1.  Software engineers grow by learning from each other.
1.  Participants working on a project develop a shared understanding of the project's code.

## Evidence and Measures

Many of these items can be automated or enforced by policy in modern version control and work item tracking systems. Verification of the policies on the master branch in AzDO, for example, may be sufficient evidence that a project team is conducting code reviews.

-   [ ] The master branches in all repositories have branch policies.
-   [ ] All builds produced out of project repositories include appropriate linters, run unit tests.
-   [ ] Every bug work item should include a link to the pull request that introduced it, once the error has been diagnosed. This helps with learning.
-   [ ] Each bug work item should include a note on how the bug might (or might not have) been caught in a code review.
-   [ ] The project team regularly updates their code review checklists to reflect common issues they have encountered.
-   [ ] Software engineering managers should review a sample of pull requests and/or be co-reviewers with other developers to help everyone improve their skills as code reviewers.


## General Guidance

The goal of code reviews is to identify and remove defects before they can be introduced into shared code branches. To the extent that parts of reviews can be automated via linters, human reviewers can focus on architectural and functional correctness. Human reviewers should focus on:

-   The correctness of the business logic embodied in the code.
-   The correctness of any new or changed tests.
-   The "readability" and maintainability of the overall design decisions reflected in the code.
-   The checklist of common errors that the team maintains for each programming language.

Code reviews should use the below guidance and checklists to ensure positive and effective code reviews. 

## Approach in Code Reviews
1. Understand the code you are reviewing  
    * Read every line changed.  
    * If we have a stakeholder review, it’s not necessary to run the PR unless it aids your understanding of the code.  
    * AzDO orders the files for you, but you should read the code in some logical sequence to aid understanding.  
    * If you don’t fully understand a change in a file because you don’t have context, click to view the whole file and read through surrounding code.  
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
    1.  [ ] Does the PR description make sense? 
    1.  [ ] Do all the changes logically fit in this PR, or are there unrelated changes? 
    1.  [ ] If necessary, are the changes made reflected in updates to the README or other docs? If the changes affect how the user builds code especially. 

1. User Facing Changes 
    1.  [ ] If the code involves a user-facing change, is there a GIF/photo that explains the functionality? If not, it might be key to validate the PR to ensure the change does what is expected. 
    1.  [ ] Ensure UI changes look good without unexpected behavior.  

1. Design  
    1.  [ ] Do the interactions of the various pieces of code in the PR make sense? 
    1.  [ ] Does the code recognize and incorporate architectures and coding patterns? 

## Code Quality Pass
1. Complexity 
    1.  [ ] Are functions too complex?  
    1.  [ ] Should a function be broken into multiple functions? 
    1.  [ ] If a method has greater than 3 arguments, potentially overly complex. 
    1.  [ ] Single responsibility principle – function or class should do one ‘thing’  
    1.  [ ] Can the code be understood easily by code readers?  
    1.  [ ] Does the code add functionality that isn’t needed? Is it overly complex?  

1. Naming/readability 
    1.  [ ] Did the developer pick good names for functions, variables, etc? 

1. Error Handling 
    1.  [ ] Are errors handled gracefully and explicitly where necessary?  

1. Functionality  
    1.  [ ] Is there parallel programming in this PR that could cause race conditions? Carefully read through this logic. 
    1.  [ ] Could the code be optimized? For example: are there more calls to the database than need be?  
    1.  [ ] If you may not fully understand how the code could affect the system, ask for help. 
    1.  [ ] Are there security flaws?  
    1.  [ ] Does a variable name reveal any customer specific information?  
    1.  [ ] Is PII and EUII treated correctly? And not logging any PII information. 

1. Style  
    1.  [ ] Are there extraneous comments? If the code isn’t clear enough to explain itself, then the code should be made simpler. Comments may be there to explain why some code exists.  
    1.  [ ] Does the code adhere to the style guide/conventions that we have agreed upon? We use automated styling like black and prettier.  

1. Tests 
    1.  [ ] Tests should always be committed in the same PR as the code itself (‘I’ll add tests next’ is not acceptable) 
    1.  [ ] Make sure tests are sensible and valid assumptions are made. 

## Language Specific Guidance

-   [Bash](recipes/Bash.md)
-   [C#](recipes/CSharp.md)
-   [Go](recipes/Go.md)
-   [Java](recipes/Java.md)
-   [JavaScript](recipes/JavaScript.md)
-   [TypeScript](recipes/TypeScript.md)
-   [Python](recipes/Python.md)

## Resources

-   [Best Kept Secrets of Peer Code Review](https://smartbear.com/SmartBear/media/pdfs/best-kept-secrets-of-peer-code-review.pdf)

## Q&A

### Q: We pair or mob. Why do we need code reviews?

A: Our peer code reviews are structured around best practices to find specific kinds of errors. Much like you would still run a linter over mobbed code, you would still ask someone to make the last pass to make sure the code conforms to expected standards and avoids common pitfalls.

### Q: What if we do pair programming?

A: Someone outside of the pair should perform the code review. One of the other major benefits of code reviews is spreading knowledge about the code base to other members of the team that don't usually work in the part of the codebase under review.

### Q: What if we do mob programming?

A: A member of the mob who spent less (or no) time at the keyboard should perform the code review.
