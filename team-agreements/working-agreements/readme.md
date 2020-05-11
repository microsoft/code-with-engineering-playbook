# Sections of a working agreement

A working agreement is a document or a set of documents that describe how we work together as a team and what our expectations and principles are.

The working agreement created by the team at the beginning of the project, and is stored in the repository so that it is readily available for everyone working on the project.

The following are examples of sections and points that can be part of a working agreement but each team should compose their own, and adjust times, communication channels etc. to fit their team needs.

## General

- We work as one team towards a common goal and clear scope
- We make sure everyones voice is heard, listened to
- We show all team members equal respect
- We pair-program as often as possible
- We make sure to spread our expertise and skills in the team, so no single person is relied on for one skill
- All times below are listed in CET

## Communication

- We communicate all information relevant to the team through the Project Teams channel
- We add all research results, design documents and other technical documentation to the project repository through PRs

## Work life balance

- Our office hour, when we can expect to collaborate via Microsoft Teams, phone or face-to-face are Monday to Friday 10AM-5PM
- We are not expected to answer emails past 6PM, on weekends on when we are on holidays or vacation.
- We work in different time zones and respsect this, especially when setting up recurring meetings.
- We record meetings when possible, so that team members who could not attend live can listen later.

## Quality and not quantity

- We, together on a [Definition of Done](../definition-of-done/readme.md) for our user story's and sprints and live by it.
- We follow engineering best practices like the [Code With Engineering Playbook](https://github.com/microsoft/code-with-engineering-playbook)

## Scrum rhythm

| Activity | When | Duration | Who | Accountable | Goal |
|-|-|-|-|-|-|
| [Project Standup](./sprint-planning/../../../stand-ups/readme.md) | Tue-Fri 9AM | 15 min | Dev Team, PM | Scrum Master | What has been accomplished, next steps, blockers |
| Sprint Demo | Monday 9AM | 1 hour | Dev Team, PM, PO | PM and Dev Lead | Present work done and sign off on user story completion |
| [Sprint Retro](./../../retrospectives/readme.md) | Monday 10PM | 1 hour | Dev Team, PM | Scrum Master | Dev Teams shares learnings and what can be improved |
| [Sprint Planning](./../../sprint-planning/readme.md) | Monday 11PM | 1 hour | Dev Team, PM, Customer PO | PM | Size and plan user stories for the sprint |
| Task Creation | After Sprint Planning | - | Dev Team, PM | Dev Lead | Create tasks to clarify and determine velocity |
| [Backlog grooming](../../backlog-management/grooming/readme.md) | Wednesday 2PM | 1 hour | PM, PO, Dev Lead, Scrum Master, Dev Team | PM | Prepare for next sprint and ensure that stories are ready for next sprint. |

## Backlog management

- We work together on a [Definition of Ready](../definition-of-ready/readme.md) and all user stories assigned to a sprint need to follow this
- We communicate what we are working on through the board
- We assign ourselves a task when we are ready to work on it (not before) and move it to active
- We capture any work we do related to the project in a user story/task
- We close our tasks/user stories only when they are done (as described in the [Definition of Done](../definition-of-done/readme.md))
- We work with the PM if we want to add a new user story to the sprint
- If we add new tasks to the board, we make sure it matches the acceptance criteria of the user story (to avoid scope creep). If it doesn't match the acceptance criteria we should discuss with the PM to see if we need a new user story for the task or if we should adjust the acceptance criteria.

## Code management

- We follow the git flow branch naming convention for branches and identify the task number eg. `feature/123-add-working-agreement`
- We merge all code into Develop and Master through PRs
- All PRs are reviewed by one person from Contoso and one from Microsoft (for knowledge transfer and to ensure code and security standards are met)
- We always review existing PRs before starting work on a new task
- We look through open PRs at the end of stand-up to make sure all PRs have reviewers.
- We treat documentation as code and apply the same [standards to Markdown](../../code-reviews/recipes/Markdown.md) as code
