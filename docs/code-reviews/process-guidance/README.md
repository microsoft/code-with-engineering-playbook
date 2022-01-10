# Process Guidance

## General Guidance

Code reviews should be part of the software engineering team process regardless of the development model. Furthermore, the team should learn to execute reviews in a timely manner. [Pull requests (PRs)](../pull-requests.md) left hanging can cause additional merge problems and go stale resulting in lost work. Qualified PRs are expected to reflect well-defined, concise tasks, and thus be compact in content. Reviewing a single task should then take relatively little time to complete.

To ensure that the code review process is healthy, inclusive and meets the goals stated above, consider following these guidelines:

- Establish a [service-level agreement (SLA)](https://en.wikipedia.org/wiki/Service-level_agreement) for code reviews and add it to your teams working agreement.
- Although modern DevOps environments incorporate tools for managing PRs, it can be useful to label tasks pending for review or to have a dedicated place for them on the task board - [Customize AzDO task boards](./customize-ado.md#task-boards)
- In the daily standup meeting check tasks pending for review and make sure they have reviewers assigned.
- Junior teams and teams new to the process can consider creating separate tasks for reviews together with the tasks themselves.
- Utilize tools to streamline the review process - [Code review tools](../tools.md)
- Foster inclusive code reviews - [Inclusion in Code Review](../inclusion-in-code-review.md)

## Measuring code review process

If the team is finding that code reviews are taking a significant time to merge, and it is becoming a blocker, consider the following additional recommendations:

1. Measure the average time it takes to merge a PR per sprint cycle.
1. Review during retrospective how the time to merge can be improved and prioritized.
1. Assess the time to merge across sprints to see if the process is improving.
1. Ping required approvers directly as a reminder.

## Recommendations for a better code review

### Take your time to review but don't go beyond of the specific task

You shouldn't review code too quickly but neither take too long in one sitting. If you have many pull requests or if the complexity of code is demanding the recommendation is to take a break between reviews to recover, and focus on the ones you are most experienced with.

Always remember, the goal of a code review is to verify that the specified task has been achieved. If your suggestions are on code related to, but not included in the PR, raise those suggestions as separate tasks (bugs, technical debt etc.). Don't block the current PR on suggestions outside the scope of the PR.

### Decide on a common standard for each language

Automate as much as possible (styling, etc.) to avoid the need for "Nit's" and allow the reviewer to focus more on functional aspects of the PR.

### Automate whenever possible

Before doing any code review it's important to set automated builds, tests and checks (something achievable in the [CI process](../../continuous-integration/README.md)), this can save human reviewers some time and focus in areas like design and functionality for proper evaluation.

This will ensure the team is focusing on the right things and it will reduce review time.

## Role specific guidance

- [Author Guidance](author-guidance.md)
- [Reviewer Guidance](reviewer-guidance.md)
