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

At the moment of creating a pull request it is a very good idea to put in the description of it a checklist of expected objectives to achieve in the PR. This way reviewers can be able to focus on specific areas and also consider some other tasks as secondary according to this list.

## Code should have annotations before the review

If big files are something that can not be avoided then you need to include comments in order to make it easier to the teams to review, with clear comments developers can go faster in the process and also can identify goals for every code block.

## Track progress

- If the reviewers have not responded in a reasonable time (generally a day or two), ping them or raise the issue in a daily meeting.

## Foster a positive code review culture

This is the easiest recommendation to follow and yet the most absent form code reviews. Code reviews play a critical role in product quality and it should not represent an arena for long discussions or even worse a battle of egos. What matters is a bug caught not who made it, not who found it, not who solved it. The only thing that matters is having the best possible product.
