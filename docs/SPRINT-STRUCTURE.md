# Structure of a Sprint

The purpose of this document is to:

- Organize content in the playbook for quick reference and discoverability
- Provide content in a logical structure which reflects the engineering process
- Extensible hierarchy to allow teams to share deep subject-matter expertise

## The first week of an ISE Project

### Before starting the project

- [ ] [Discuss and start writing the Team Agreements](agile-development/advanced-topics/team-agreements/README.md). Update these documents with any process decisions made throughout the project
  - [Working Agreement](agile-development/advanced-topics/team-agreements/working-agreements.md)
  - [Definition of Ready](agile-development/advanced-topics/team-agreements/definition-of-ready.md)
  - [Definition of Done](agile-development/advanced-topics/team-agreements/definition-of-done.md)
  - [Estimation](agile-development/core-expectations/README.md)
- [ ] [Set up the repository/repositories](source-control/README.md#creating-a-new-repository)
  - Decide on repository structure/s
  - Add [README.md](resources/templates/README.md), [LICENSE](resources/templates/LICENSE), [CONTRIBUTING.md](resources/templates/CONTRIBUTING.md), .gitignore, etc
- [ ] [Build a Product Backlog](agile-development/advanced-topics/backlog-management/README.md)
  - Set up a project in your chosen project management tool (ex. Azure DevOps)
  - [INVEST](https://en.wikipedia.org/wiki/INVEST_(mnemonic)) in good User Stories and Acceptance Criteria
  - [Non-Functional Requirements Guidance](design/design-patterns/non-functional-requirements-capture-guide.md)

### Day 1

- [ ] [Plan the first sprint](agile-development/core-expectations/README.md)
  - Agree on a sprint goal, and how to measure the sprint progress
  - Determine team capacity
  - Assign user stories to the sprint and split user stories into tasks
  - Set up Work in Progress (WIP) limits
- [ ] [Decide on test frameworks and discuss test strategies](automated-testing/README.md)
  - Discuss the purpose and goals of tests and how to measure test coverage
  - Agree on how to separate unit tests from integration, load and smoke tests
  - Design the first test cases
- [ ] [Decide on branch naming](source-control/naming-branches.md)
- [ ] [Discuss security needs and verify that secrets are kept out of source control](continuous-delivery/azure-devops/secret-management-per-branch.md)

### Day 2

- [ ] [Set up Source Control](source-control/README.md)
  - Agree on [best practices for commits](source-control/git-guidance/README.md#commit-best-practices)
- [ ] [Set up basic Continuous Integration with linters and automated tests](continuous-integration/README.md)
- [ ] [Set up meetings for Daily Stand-ups and decide on a Process Lead](agile-development/core-expectations/README.md)
  - Discuss purpose, goals, participants and facilitation guidance
  - Discuss timing, and how to run an efficient stand-up
- [ ] [If the project has sub-teams, set up a Scrum of Scrums](agile-development/advanced-topics/effective-organization/scrum-of-scrums.md)

### Day 3

- [ ] [Agree on code style](code-reviews/README.md) and on [how to assign Pull Requests](code-reviews/pull-requests.md)
- [ ] [Set up Build Validation for Pull Requests (2 reviewers, linters, automated tests)](code-reviews/README.md) and agree on [Definition of Done](agile-development/advanced-topics/team-agreements/definition-of-done.md)
- [ ] [Agree on a Code Merging strategy](source-control/merge-strategies.md) and update the [CONTRIBUTING.md](resources/templates/CONTRIBUTING.md)
- [ ] [Agree on logging and observability frameworks and strategies](observability/README.md)

### Day 4

- [ ] [Set up Continuous Deployment](continuous-delivery/README.md)
  - Determine what environments are appropriate for this solution
  - For each environment discuss purpose, when deployment should trigger, pre-deployment approvers, sing-off for promotion.
- [ ] [Decide on a versioning strategy](source-control/component-versioning.md)
- [ ] Agree on how to [Design a feature and conduct a Design Review](design/design-reviews/README.md)

### Day 5

- [ ] Conduct a Sprint Demo
- [ ] [Conduct a Retrospective](agile-development/core-expectations/README.md)
  - Determine required participants, how to capture input (tools) and outcome
  - Set a timeline, and discuss facilitation, meeting structure etc.
- [ ] [Refine the Backlog](agile-development/advanced-topics/backlog-management/README.md)
  - Determine required participants
  - Update the [Definition of Ready](agile-development/advanced-topics/team-agreements/definition-of-ready.md)
  - Update estimates, and the [Estimation](agile-development/core-expectations/README.md) document
- [ ] [Submit Engineering Feedback for issues encountered](engineering-feedback/README.md)
