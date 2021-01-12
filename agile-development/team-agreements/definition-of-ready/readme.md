# Definition of Ready

When the development team picks a user story from the top of the backlog, the user story needs to have enough detail to estimate the work needed to complete the story within the sprint. If it has enough detail to estimate, it is Ready to be developed.

> If a user story is not Ready in the beginning of the Sprint it increases the chance that the story will not be done at the end of this sprint.

## What it is

*Definition of Ready* is the agreement made by the scrum team around how complete a user story should be in order to be selected as candidate for estimation in the sprint planning. These can be codified as a checklist in user stories using [Github Issue Templates](https://help.github.com/en/github/building-a-strong-community/configuring-issue-templates-for-your-repository) or [Azure DevOps Work Item Templates](https://docs.microsoft.com/en-us/azure/devops/boards/backlogs/work-item-template?view=azure-devops&tabs=browser).

It can be understood as a checklist that helps the Product Owner to ensure that the user story they wrote contains all the necessary details for the scrum team to understand the work to be done.

### Examples of ready checklist items:

* [ ] Does the description have the details including any input values required to implement the user story?
* [ ] Does the user story have clear and complete acceptance criteria?
* [ ] Does the user story address the business need?
* [ ] Can we measure the acceptance criteria?
* [ ] Is the user story small enough to be implemented in a short amount of time, but large enough to provide value to the customer?
* [ ] Is the user story blocked? For example, does it depend on any of the following:
  * The completion of unfinished work
  * A deliverable provided by another team (code artifact, data, etc...)

## Who writes it

The ready checklist can be written by a Product Owner in agreement with the development team and the Process Lead.

## When should a Definition of Ready be updated

Update or change the definition of ready anytime the scrum team observes that there are missing information in the user stories that recurrently impacts the planning.

## What should be avoided

The ready checklist should contain items that apply broadly. Don't include items or details that only apply to one or two user stories. This may become an overhead when writing the user stories.

## How to get stories ready

In the case that the highest priority work is not yet ready, it still may be possible to make forward progress. Here are some strategies that may help:

* [Backlog Refinement](../../backlog-management/refinement/readme.md) sessions are a good time to validate that high priority user stories are verified to have a clear description, acceptance criteria and demonstrable business value. It is also a good time to breakdown large stories will likely not be completable in a single sprint.
* Prioritization sessions are a good time to prioritize user stories that unblock other blocked high priority work.
* Blocked user stories can often be broken down in a way that unblocks a portion of the original stories scope. This is a good way to make forward progress even when some work is blocked.
