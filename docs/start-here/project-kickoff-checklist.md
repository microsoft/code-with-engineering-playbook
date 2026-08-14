# Project Kickoff Checklist

This checklist sequences playbook guidance for the first week of an ISE project. Use it after choosing the role-based reading path that best fits your work.

> **Note:** A good kickoff leaves you with a ready environment, an aligned team, and an immediate start on building — not a long planning-only phase. Lean on the playbook's [AI tooling considerations](../agile-development/README.md#ai-tooling-considerations) and [Continuous Integration](../CI-CD/continuous-integration.md) guidance to iterate quickly from the first day.

## Before Day 1: Readiness

Get these in place so the team can build from Day 1 instead of waiting on setup.

- [ ] Provision [developer tooling](../developer-experience/README.md) and licenses for everyone who needs them
- [ ] Provide reproducible developer environments (for example, [dev containers](../developer-experience/devcontainers-getting-started.md)) and an [onboarding guide](../developer-experience/onboarding-guide-template.md)
- [ ] Confirm access to the data, APIs, and connectors the solution depends on
- [ ] Assign the [team and roles](../agile-development/roles.md) and grant the access each role needs
- [ ] Discuss and start writing the Team Agreements. Update these documents with any process decisions made throughout the project
  - [Working Agreement](../agile-development/team-agreements/working-agreement.md)
  - [Definition of Ready](../agile-development/team-agreements/definition-of-ready.md)
  - [Definition of Done](../agile-development/team-agreements/definition-of-done.md)
  - [Estimation](../agile-development/ceremonies.md#estimation)
- [ ] Agree on the [AI-assisted engineering](../ai-assisted-engineering/README.md) approach for the project
  - Confirm which AI tools are approved for this project and data type
  - Define allowed data, prompt/context boundaries, retention expectations, and approved use cases
  - Decide how material AI assistance is recorded in PRs, work items, or commit metadata
- [ ] [Set up the repository/repositories](../source-control/README.md#creating-a-new-repository)
  - Decide on repository structure/s
  - Add README.md, LICENSE, CONTRIBUTING.md, .gitignore, etc
- [ ] [Build a Product Backlog](../agile-development/backlog-management.md)
  - Set up a project in your chosen project management tool (ex. Azure DevOps)
  - [INVEST](https://en.wikipedia.org/wiki/INVEST_(mnemonic)) in good User Stories and Acceptance Criteria
  - [Non-Functional Requirements Guidance](../design/design-patterns/non-functional-requirements-capture-guide.md)

## Kickoff session

Run a focused session to align the team before the first sprint. The day-by-day list below covers the detail; use this agenda for the cross-cutting decisions.

- [ ] Align on the problem and the use case the project solves
- [ ] Define success criteria for the POC/MVP
- [ ] Confirm roles and [working agreements](../agile-development/team-agreements/working-agreement.md)
- [ ] Start from a proven baseline or starter instead of greenfield. As one public example, the [Hypervelocity Engineering (HVE) Core](https://github.com/microsoft/hve-core) project ships reusable [templates](https://microsoft.github.io/hve-core/docs/templates/)
- [ ] Stand up the repository and a [CI/CD](../agile-development/branching-and-cicd.md) starter with [Continuous Integration](../CI-CD/continuous-integration.md)

## Immediately after kickoff

- [ ] Turn the agreed requirements into a lightweight spec and a [product backlog](../agile-development/backlog-management.md) right away
- [ ] Start prototyping in short iterations using [minimal slices](../agile-development/advanced-topics/backlog-management/minimal-slices.md), capturing [non-functional requirements](../design/design-patterns/non-functional-requirements-capture-guide.md) as they surface

## Decisions to make at kickoff

- [ ] AI usage model — see [AI-assisted engineering](../ai-assisted-engineering/README.md)
- [ ] Security and Responsible AI guardrails — see [Security](../security/README.md), [AI systems threat modeling](../security/threat-modelling.md#ai-systems-threat-modeling-considerations), and [Responsible AI](../ml-and-ai-projects/responsible-ai.md)
- [ ] Feedback-loop cadence — see [ceremonies](../agile-development/ceremonies.md) and [engineering feedback](../engineering-feedback/README.md)

## Day 1

- [ ] [Plan the first sprint](../agile-development/ceremonies.md#sprint-planning)
  - Agree on a sprint goal, and how to measure the sprint progress
  - Determine team capacity
  - Assign user stories to the sprint and split user stories into tasks
  - Set up Work in Progress (WIP) limits
- [ ] [Decide on test frameworks and discuss test strategies](../automated-testing/README.md)
  - Discuss the purpose and goals of tests and how to measure test coverage
  - Agree on how to separate unit tests from integration, load and smoke tests
  - Design the first test cases
  - Define evaluation strategy for AI-enabled stories, including quality, safety, fallback, and regression checks
- [ ] [Decide on branch naming](../source-control/naming-branches.md)
- [ ] [Discuss security needs and verify that secrets are kept out of source control](../CI-CD/dev-sec-ops/secrets-management/README.md)

## Day 2

- [ ] [Set up Source Control](../source-control/README.md)
  - Agree on [best practices for commits](../source-control/git-guidance/README.md#commit-best-practices)
  - Confirm branch protection, CI validation, and agent permissions for AI-assisted work
  - [ ] [Set up basic Continuous Integration with linters and automated tests](../CI-CD/continuous-integration.md)
  - [ ] [Set up meetings for Daily Stand-ups and decide on a Process Lead](../agile-development/ceremonies.md#stand-up)
  - Discuss purpose, goals, participants and facilitation guidance
  - Discuss timing, and how to run an efficient stand-up
- [ ] [If the project has sub-teams, set up a Scrum of Scrums](../agile-development/advanced-topics/effective-organization/scrum-of-scrums.md)

## Day 3

- [ ] [Agree on code style](../code-reviews/README.md) and on [how to assign Pull Requests](../code-reviews/pull-requests.md)
- [ ] [Set up Build Validation for Pull Requests (2 reviewers, linters, automated tests)](../code-reviews/README.md) and agree on [Definition of Done](../agile-development/team-agreements/definition-of-done.md)
- [ ] Agree how reviewers identify, test, and document AI-assisted changes
- [ ] [Agree on a Code Merging strategy](../source-control/merge-strategies.md) and update the CONTRIBUTING.md
- [ ] [Agree on logging and observability frameworks and strategies](../observability/README.md)

## Day 4

- [ ] [Set up Continuous Deployment](../CI-CD/continuous-delivery.md)
  - Determine what environments are appropriate for this solution
  - For each environment discuss purpose, when deployment should trigger, pre-deployment approvers, sign-off for promotion.
- [ ] [Decide on a versioning strategy](../source-control/component-versioning.md)
- [ ] Agree on how to [Design a feature and conduct a Design Review](../design/design-reviews/README.md)
  - Include AI risks, human approval points, security, observability, and rollback behavior when the design uses AI features or agents

## Day 5

- [ ] Conduct a [Sprint Demo](../agile-development/ceremonies.md#sprint-demo)
- [ ] Conduct a [Retrospective](../agile-development/ceremonies.md#retrospectives)
  - Determine required participants, how to capture input (tools) and outcome
  - Set a timeline, and discuss facilitation, meeting structure etc.
- [ ] [Refine the Backlog](../agile-development/backlog-management.md)
  - Determine required participants
  - Update the [Definition of Ready](../agile-development/team-agreements/definition-of-ready.md)
  - Update estimates, and the [Estimation](../agile-development/ceremonies.md#estimation) document
- [ ] [Submit Engineering Feedback for issues encountered](../engineering-feedback/README.md)
