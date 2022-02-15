# Technical Debt

Even when following the engineering fundamentals in this playbook, you are likely to accrue some technical debt as your codebase evolves and matures over time. Technical debt can include any changes you would make to your code if you had the opportunity to do so. Technical debt can take many forms from the intentional protoyping of a new feature for a proof of concept to the unintentional unnecessary using directives you forgot to delete in your C# code. Addressing technical debt early in a project can minimize rework and help improve code quality for additional features developed in future sprints. However, it's never too late to address technical debt. Even large codebases running in production can be improved to be more performant, secure, and maintainable if you identify, prioritize and resolve technical debt in your code.

## Sections within Technical Debt

* Intentional vs. Unintentional Technical Debt
* Invasive vs. Non-invasive Changes
* Adding Technical Debt to Your Backlog
* Working with Another Team's Codebase
* Identifying Common Patterns to Resolve

## Intentional vs. Unintentional Technical Debt

Technical debt can be intentional or unintentional. If you are working on a proof of concept, you are likely to deprioritize tasks related to scalability and in some cases even reliability and security. It is important that you capture these intentional decisions at the time they are made so it is easier for you or others to resolve these issues later if the project continues past the proof of concept stage. It is best to track intentional technical debt in your backlog. However, if you know in advance that the codebase will survive beyond the backlog, you may want to include comments in your code identifying the technical debt and any guidance on how you believe it could be resovled in the future.
  
Unintentional technical debt can be mitigated with thorough code reviews for each PR. If you identify an issue in a PR and it cannot be resovled at that time, add the issue to the backlog to ensure the issue is not lost in the PR comments. By doing this, you can transform the technical debt from unintentional to intentional and increase the chances the issue is resolved before the code makes its way into a production environment.

## Invasive vs. Non-invasive Changes

When dealing with legacy code it's helpful to identify 2 types of expected mitigation impact: Invasive and Non-Invasive.

**Invasive**: Deep changes that require integration and unit tests to prevent breaks

*Example*: Consider a large codebase that's already in production and that has multiple areas where the Single-responsibility principle isn’t applied. Chances are, that methods that aren’t following that principle are probably referenced in multiple areas of the code. They might also be part of a dynamic library that's re-used in external projects. Since refactoring the method could have a significant impact on the behavior of the method we would consider it invasive. Keep in mind that none of these are hard rules and are merely guidance. In practice what is an invasive change in one case might not be in another.

**Non-invasive**: Changes that are unlikely to break the overall solution and are safer to make without integration and unit tests.
  
*Example*: Adding unit tests to an existing codebase would be a good  illustration of a non-invasive change.  Additionally, it will help guard the functionality of the code before making a more invasive change.

For some suggestions of how you might classify rules, here's an example of some rule classifications that can be tailored for use in a C# & .NET solution: [Rules Classification C Sharp Example](./RulesClassification-CSharpExample.md).

## Adding Technical Debt to Your Backlog

Technical debt should be added to your backlog alongside the other important user stories you need to accomplish. If your choose to incur some technical debt during your project, you should add the backlog item immediately after you make the decision while the details are fresh in your mind. For example, if you decide to write some prototype code that isn't as scalable as you would expect for a production deployment, create a quick backlog item outlining what steps you would take to refactor the code to be more scalable in the future. Your new backlog story doesn't need to be perfect, as long as it indicates what the issue is and where in the codebase someone can look to work on that issue in the future.  
  
The next most likely time to identify technical debt and add it to your backlog is during code reviews for PRs. When you are finalizing a PR, look for any comments that were resolved with suggestions for improvements. If you don't have time to incorporate the improvement now, add it to the backlog so another team member can make the change in the future when time permits.  
  
Finally, if you are beginning work on a codebase the you inherited from another team, you may need to assess the code for exiting technical debt. This work can take time and should be included in the sprint plan or in a sprint zero phase prior to the project kickoff. Remember to add this work to the backlog to ensure that the assessment itself is a high priority work item that gets proper attention from the team.

## Improving Another Team's Codebase

* Please follow the recommendations listed inside [inclusion in code reviews](../../code-reviews/inclusion-in-code-review.md) when working with another team's codebase.
* Code should be considered in it's current state as-of today, which means it can change using an iterative approach.
* Don't assume the original developer didn't know how to write high quality code, instead consider that they didn't have the time to do it or other factors came into play.
* Any issue that's listed as technical debt should be considered as a compromise vs. time or a milestone instead of whether one team is "better" or "faster" than another at writing code.
* Take into consideration "onus" of the codebase. That is to say, who will be the person taking the pager call at 3 am when the code doesn't work. If they don't like a change find out why and see if there's an opportunity to make it better.

## Identifying Common Patterns to Resolve

* For the language that you are using, find the most adopted form of style and code static analysis tools and enable them see also [code review](/code-reviews/README.md).
* Style guidelines represent aspects of the code that involve naming, organization and basic maintenance of code.
* Code static analysis guidelines represent aspects of the code that involve performance, security and general rules to follow.
* Ensure that the rules are reporting issues as errors and not warnings.
* Address all issues that come up during the static analysis tool evaluation.
* In the beginning of switching over to the new rules, evaluate each issue together as a team to ensure everyone agrees with the rules - and most importantly modify the rule if necessary.
* Ensure that you and your team are following [code review](/code-reviews/README.md) practices as closely as you can to catch any code issues that aren't caught by automated tools.

## Organizing and classifying code quality rules to make them actionable

To be efficient in your effort to reduce technical debt, we highly recommend following a structured approach. For each language or technology in your code, identify the code quality rules you want to apply and sort them into categories and types of potential changes (i.e. Invasive/Non-Invasive).

You can find an example of rules classification in [this playbook](./RulesClassification-CSharpExample.md).

Here are a few steps to follow for each language:

### Step 1: Gather state of the art code quality guidelines and rules for the language you are including

Most of the programming languages have an official definition of quality when it comes to writing software with them. These can be found on the programming language (or platform) official website, on articles and blog posts from advanced users of the language or from experts in your team, organization, and company. In the playbook, you can find [recipes for some languages](/code-review/README.md). Additionally, research whether any tool exists to automate the detection of broken rules in the existing code. [Linters](https://en.wikipedia.org/wiki/Lint_(software)) and other [code analyzers](https://en.wikipedia.org/wiki/List_of_tools_for_static_code_analysis) exist for most of the popular programming languages.

### Step 2: Group the list of rules you selected in step 1 into each code quality category

Group all the rules into categories. This will help structure and plan your code review exercise.

Our proposed list of categories is: **Static Code Analysis**, **Test Coverage**, **Observability**, **Style and Readability**, **Code Clarity and Commenting**, **Performance**, and **Security**.

### Step 3: Determine the types of expected mitigation impact for each rule

As mentioned earlier in this document, we identify 2 types of expected mitigation impact: **Invasive** and **Non-Invasive**.

For each rule, think about examples of instances where it can be broken. Go through a mental exercise of fixing these and decide if the change would likely be breaking and impact existing behavior (Invasive) or if it would likely be non-impactful (Non-invasive).
