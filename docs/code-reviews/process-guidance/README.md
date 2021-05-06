# Process Guidance

## General Guidance

Code reviews should be part of the software engineering team process regardless of the development model. Furthermore, the team should learn to execute reviews in a timely manner. [Pull requests (PRs)](../pull-requests.md) left hanging can cause additional merge problems and go stale resulting in lost work. Qualified PRs are expected to reflect well-defined, concise tasks, and thus be compact in content. Reviewing a single task should then take relatively little time to complete.

To ensure that the code review process is healthy and meets the goals stated above, consider following these guidelines:

- Establish a [service-level agreement (SLA)](https://en.wikipedia.org/wiki/Service-level_agreement) for code reviews and add it to your teams working agreement.
- Although modern DevOps environments incorporate tools for managing PRs, it can be useful to label tasks pending for review or to have a dedicated place for them on the task board - [Customize AzDO task boards](./customize-ado.md#task-boards)
- In the daily standup meeting check tasks pending for review and make sure they have reviewers assigned.
- Junior teams and teams new to the process can consider creating separate tasks for reviews together with the tasks themselves.
- Utilize tools to streamline the review process - [Code review tools](../tools.md)

## Measuring code review process

If the team is finding that code reviews are taking a significant time to merge and it is becoming a blocker, consider the following additional recommendations:

1. Measure the average time it takes to merge a PR per sprint cycle.
1. Review during retrospective how the time to merge can be improved and prioritized.
1. Assess the time to merge across sprints to see if the process is improving.
1. Ping required approvers directly as a reminder.

## Role specific guidance

- [Author Guidance](./author-guidance.md)
- [Reviewer Guidance](./reviewer-guidance.md)

## Resources

Further resources can be found in the [resource section](../README.md#resources) on the main page.
