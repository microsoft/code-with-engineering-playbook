# Author Guidance

## Properly describe your PR

- Give the PR a descriptive title, so that other members can easily (in one short sentence) understand what a PR is about.
- Every PR should have a proper description, that shows the reviewer what has been changed and why.

## Add relevant reviewers

- Add one or more reviewers (depending on your project's guidelines) to the PR. Ideally, you would add at least someone who has expertise and is familiar with the project, or the language used
- Adding someone less familiar with the project or the language can aid in verifying the changes are understandable, easy to read, and increases the expertise within the team
- In CSE code-with projects with a customer team, it is important to include reviewers from both organizations for knowledge transfer - [Customize Reviewers Policy](./customize-ado.md#reviewer-policies)

## Be open to receive feedback

Discuss design/code logic and address all comments as follows:

- Resolve a comment, if the requested change has been made.
- Mark the comment as "won't fix", if you are not going to make the requested changes and provide a clear reasoning
  - If the requested change is within the scope of the task, "I'll do it later" is not an acceptable reason!
  - If the requested change is out of scope, create a new work item (task or bug) for it
- If you don't understand a comment, ask questions in the review itself as opposed to a private chat
- If a thread gets bloated without a conclusion, have a meeting with the reviewer (call them or knock on door)

## Use checklists

At the moment of creating a pull request it is a good idea to put in the description of it a checklist of expected objectives to achieve in the PR. This way reviewers can be able to focus on specific areas and also consider some other tasks as secondary according to this list.

### Get a process for fixing found issues

Before getting started with any commit, your team should define how you will measure the effectiveness of peer review and get some goals. Using a [SMART criteria](https://en.wikipedia.org/wiki/SMART_criteria) the team can get this objectives in the most accurate way and not something very general like **fix more bugs**, the more precise a goal can be the easier it will be to hit the target.

Metrics can play a significant role in this part, you can include an **Inspection rate** (the speed with which review is performed), **Defect rate** (the number of bugs found within an hour of review) and **Defect density** (the number of bugs found per piece of code) as the most common ones to be considered.

### Code should have annotations before the review

If you can't avoid large PRs, include explanations of the changes in order to make it easier for the reviewer to review the code, with clear comments the reviewer can identify the goal of every code block.

### Make comments clear

- Explain why the code needs to change.
- Prefix a “point of polish” with “Nit:”.
- Suggest changes to a PR by using the suggestion feature (available in [GitHub](https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/commenting-on-a-pull-request#adding-line-comments-to-a-pull-request) and Azure DevOps) or by creating a PR to the author branch.
- If one or two comments don’t resolve a disagreement, talk in person or create group discussion.

### Foster a positive code review culture

Code reviews play a critical role in product quality and it should not represent an arena for long discussions or even worse a battle of egos. What matters is a bug caught not who made it, not who found it, not who solved it. The only thing that matters is having the best possible product.
