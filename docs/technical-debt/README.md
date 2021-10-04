# Technical Debt (DRAFT - WORK IN PROGRESS)

Even when following the engineering fundamentals in this playbook, you are likely to accrue some technical debt as your code base evolves and matures over time. Technical debt can include any changes you would make to your code if you had the opportunity to do so. Technical debt can take many forms from the intentional protoyping of a new feature for a proof of concept to the unintentional unnessecary using directives you forgot to delete in your C# code. Addressing technical debt early in a project can minimize rework and help improve code quality for additional features developed in future sprints. However, it's never too late to address technical debt. Even large code bases running in production can be improved to be more performant, secure, and maintainable if you identify, priortize and resolve technical debt in your code.

## Sections within Technical Debt

* Intentional vs. Unintentional Technical Debt
* Invasive vs. Non-invasive Changes
* Adding Technical Debt to Your Backlog
* Working with Another Team's Codebase
* Identifying Common Patterns to Resolve

## Intentional vs. Unintentional Technical Debt

Ideas to help draft this section (delete after creating first draft)

* When you intentionally create technical debt, add it to the backlog.
* Look for technical debt during PR reviews
* Should intentional technical debt be included in comments in code?

## Invasive vs. Non-invasive Changes

Ideas to help draft this section (delete after creating first draft)
* 

## Adding Technical Debt to Your Backlog
Technical debt should be added to your backlog alongside the other important user stories you need to accomplish. If your choose to incur some technical debt during your project, you should add the backlog item immediately after you make the decision while the details are fresh in your mind. For example, if you decide to write some prototype code that isn't as scalable as you would expect for a production deployment, create a quick backlog item outlining what steps you would take to refactor the code to be more scalable in the future. Your new backlog story doesn't need to be perfect, as long as it indicates what the issue is and where in the codebase someone can look to work on that issue in the future.  
  
The next most likely time to identify technical debt and add it to your backlog is during code reviews for PRs. When you are finalizing a PR, look for any comments that were resolved with suggestions for improvements. If you don't have time to incorporate the improvement now, add it to the backlog so another team member can make the change in the future when time permits.  
  
Finally, if you are beginning work on a codebase the you inheritted from another team, you may need to assess the code for exiting technical debt. This work can take time and should be included in the sprint plan or in a sprint zero phase prior to the project kickoff. Remember to add this work to the backlog to ensure that the assessment itself is a high priority work item that gets proper attention from the team.


## Improving Another Team's Codebase

Ideas to help draft this section (delete after creating first draft)

* Inheriting a code base from another team; what process should you use?
* Don't assume the original developer didn't know how to write high quality code? Assume they didn't have the time to do it.
* Seperate code quality issues for developer quality issues

## Identifying Common Patterns to Resolve
- For the language that you are using, find the most adopted form of style and code static analysis tools and enable them.
- Style guidelines represent aspects of the code that involve naming, organization and basic maintenance of code.
- Code static analysis guidelines represent aspects of the code that involve performance, security and general rules to follow.
- Ensure that the rules are reporting issues as errors and not warnings.
- Address all issues that come up during the static analysis tool evaluation.
- In the beginning of switching over to the new rules, evaluate each issue together as a team to ensure everyone agrees with the rules - and most importantly modify the rule if necessary. 
- Ensure that you and your team are following [code review](./code-reviews/README.md) practices as closely as you can to catch any code issues that aren't caught by automated tools.

## Organizing and classifying code quality rules to make them actionable

To be efficient in your effort to reduce technical debt, we highly recommend following a structured approach. For each language or technology in your code, identify the code quality rules you want to apply and sort them into categories and types of potential changes (ie. Invasive/Non-Invasive).

You can find an example of rules classification in [this playbook](./RulesClassification-CSharpExample.md). 

Here are a few steps to follow for each language:

### Step 1: Gather state of the art code quality guidelines and rules for the language you are including

Most of the programming languages have an official definition of quality when it comes to writing software with them. These can be found on the programming language (or platform) official website, on articles and blog posts from advanced users of the language or from experts in your team, organization, and company. In the playbook, you can find [recipes for some languages](../code-review/recipes/README.md). Additionally, research whether any tool exists to automate the detection of broken rules in the existing code. [Linters](https://en.wikipedia.org/wiki/Lint_(software)) and other [code analyzers](https://en.wikipedia.org/wiki/List_of_tools_for_static_code_analysis) exist for most of the popular programming languages.

### Step 2: Group the list of rules you selected in step 1 into each code quality category

Group all the rules into categories. This will help structure and plan your code review exercise.

Our proposed list of categories is: **Static Code Analysis**, **Test Coverage**, **Observability**, **Style and Readability**, **Code Clarity and Commenting**, **Performance**, and **Security**.

### Step 3: Define the types of expected mitigation impact for each rule

As mentioned earlier in this document, we identify 2 types of expected mitigation impact: **Invasive** and **Non-Invasive**.

For each rule, think about examples of instances where it can be broken. Go through a mental exercise of fixing these and decide if the change would likely be breaking and impact existing behavior (Invasive) or if it would likely be non-impactful (Non-invasive). As an example, consider a large code base that is already in production and that has multiple areas where the Single-responsibility principle isn’t applied. Chances are, that methods that aren’t following that principle are probably referenced in multiple areas of the code. They might also be part of a DLL that is re-used in external projects. Since refactoring the method could have a significant impact on the behavior of the method we would consider it **invasive**. Keep in mind that none of these are hard rules and are merely guidance. In practice what is an invasive change in one case might not be in another.

## ADDITIONAL NOTES TO DELETE AFTER FIRST DRAFT

* Acknowledge technical debt as early as possible. Make conscious decisions to take short cuts and add it to the backlog at the time.
* Identify issues and add them to your backlog
* Tag issues as invasive or non-invasive changes

* When is it a good idea to have a sprint just focused on clean up?
* Why do they do it
* What do we have to add
* When things go wrong
* Emotional impact
