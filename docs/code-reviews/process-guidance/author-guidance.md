# Author Guidance

## Properly Describe Your Pull Request (PR)

- Give the PR a descriptive title, so that other members can easily (in one short sentence) understand what a PR is about.
- Every PR should have a proper description, that shows the reviewer what has been changed and why.

## Add Relevant Reviewers

- Add one or more reviewers (depending on your project's guidelines) to the PR. Ideally, you would add at least someone who has expertise and is familiar with the project, or the language used
- Adding someone less familiar with the project or the language can aid in verifying the changes are understandable, easy to read, and increases the expertise within the team
- In ISE code-with projects with a customer team, it is important to include reviewers from both organizations for knowledge transfer - [Customize Reviewers Policy](../tools.md#reviewer-policies)

## Be Open to Receive Feedback

Discuss design/code logic and address all comments as follows:

- Resolve a comment, if the requested change has been made.
- Mark the comment as "won't fix", if you are not going to make the requested changes and provide a clear reasoning
  - If the requested change is within the scope of the task, "I'll do it later" is not an acceptable reason!
  - If the requested change is out of scope, create a new work item (task or bug) for it
- If you don't understand a comment, ask questions in the review itself as opposed to a private chat
- If a thread gets bloated without a conclusion, have a meeting with the reviewer (call them or knock on door)

## Use Checklists

When creating a PR, it is a good idea to add a checklist of objectives of the PR in the description. This helps the reviewers to focus on the key areas of the code changes.

## Link a Task to Your PR

Link the corresponding work items/tasks to the PR. There is no need to duplicate information between the work item and the PR, but if some details are missing in either one, together they provide more context to the reviewer.

## Code Should Have Annotations Before the Review

If you can't avoid large PRs, include explanations of the changes in order to make it easier for the reviewer to review the code, with clear comments the reviewer can identify the goal of every code block.
