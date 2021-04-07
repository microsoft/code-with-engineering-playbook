# FAQ

This is a list of questions / frequently occurring issues when working with code reviews and answers how you can possibly tackle them.

## We experience very large PRs, how can we fix this?

Make sure you size the work items smaller. They should be able to be completed on their own. The team is instructed to commit early, before the full product backlog item / user story is complete, but rather when an individual item is done. If the work would result in an incomplete feature, make sure it can be turned off, until the full feature is delivered.
More information can be found in [Pull Requests - Size Guidance](./pull-requests.md#size-guidance).

## We experience slow code reviews, causing delays in delivering features

### Possible actions you can take:

- Add a rule for PR turnaround time to your work agreement.
- Setup a slot after the standup to go through pending PRs and assign the ones that are inactive.
- Dedicate a PR review manager who will be responsible to keep things flowing by assigning or notifying people when PR got stale.
- Use tools to better indicate stale reviews - [Customize ADO - Task Boards](./process-guidance/customize-ado.md#task-boards).

## Reviewing a complex PR on GitHub can be hard, is there a more integrated way?

Checkout the [Tools](./tools.md) for help on how to perform reviews out of Visual Studio or Visual Studio Code.

## How can we enforce code reviews?

Checkout the [Branch Policy](./evidence-and-measures/branch-policy.md) for instructions on how to configure branch policies that enforce code review requirements.

## We pair or mob. Why do we need code reviews

Our peer code reviews are structured around best practices to find specific kinds of errors. Much like you would still run a linter over mobbed code, you would still ask someone to make the last pass to make sure the code conforms to expected standards and avoids common pitfalls.

## What if we do pair programming

Someone outside of the pair should perform the code review. One of the other major benefits of code reviews is spreading knowledge about the code base to other members of the team that don't usually work in the part of the codebase under review.

## What if we do mob programming

A member of the mob who spent less (or no) time at the keyboard should perform the code review.
