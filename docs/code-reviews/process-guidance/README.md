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

### Get a process for fixing found issues

Before getting started with any commit, your team should define how you will measure the effectiveness of peer review and get some goals. Using a [SMART criteria](https://en.wikipedia.org/wiki/SMART_criteria) the team can get this objectives in the most accurate way and not something very general like **fix more bugs**, the more precise a goal can be the easier it will be to hit the target.

Metrics can play a significant role in this part, you can include an **Inspection rate**(the speed with which review is performed), **Defect rate**(the number of bugs found within an hour of review) and **Defect density**(the number of bugs found per piece of code) as the most common ones to be considered.

### Code reviews shouldn't include many lines of code

It's easy to say a developer can review 400 or more lines but when code surpasses certain amount of lines of code effectiveness of defects discovery can decrease and there is a chance of not having a good review or just letting bugs pass to main branch or another stage. Setting a line of code limit is as important as a time limit.

### Take your time to review but don't go beyond of the specific task

There is a small, very small gap when reviewing code talking about time, you shouldn't review code too quickly but neither take too long in one sitting. If you have many pull requests that could lead to many code reviews or complexity of code is demanding the recommendation is to not invest much time, take a break, spend some minutes between reviews to recover and focus in the ones you are most experienced.

Always remember, the goal in a code review is to verify the specified task has been achieved, there is a common practice of analyzing tasks beyond the scope of a PR by suggesting improvements that are are not being considered for this you can raise a bug, an improvement or a technical debt but not postpone a review because of a different task.

### Automate whenever possible

Before doing any code review it's important to set automated builds, tests and checks (something achievable in the [CI process](../../continuous-integration/README.md)), this can save human reviewers some time and focus in areas like design and functionality for proper evaluation. Reviewing code with some questions in mind can help team focus on the right things. One of the possible questions to ask when reviewing is **Do I understand what the code does?** and it's important to start from there in order to get the best qualified team reviewing the code.

This way of critical evaluation will ensure the team is checking the right things and it will reduce time when it comes to deal with human reviewing.

## Role specific guidance

- [Author Guidance](author-guidance.md)
- [Reviewer Guidance](reviewer-guidance.md)
