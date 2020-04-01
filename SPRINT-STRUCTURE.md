# Structure of a Sprint

The purpose of this document is to:

- Organize content in the playbook for quick reference and discoverability
- Provide content in a logical structure which reflects the engineering process
- Extensible hierarchy to allow teams to share deep subject matter expertise

## The first week of a CSE Project

### Before starting the project

- [ ] [Discuss and start writing the Team Agreements](team-agreements/readme.md). Update these documents with any process decisions made throughout the project
  - [Working Agreement](team-agreements/working-agreements/readme.md)
  - [Definition of Ready](team-agreements/definition-of-ready/readme.md)
  - [Definition of Done](team-agreements/definition-of-done/readme.md)
  - [Estimation](sprint-planning/estimation/readme.md)
- [ ] [Set up the repository/repositories](source-control/readme.md)
  - Decide on repository structure/s
  - Add [README.md](resources/templates/README.md), [LICENSE](resources/templates/LICENSE), [CONTRIBUTING.md](resources/templates/CONTRIBUTING.md), .gitignore, etc
- [ ] [Build a Product Backlog](backlog-management/readme.md)
  - Set up a project in your chosen project management tool (ex. Azure DevOps)
  - [INVEST](https://en.wikipedia.org/wiki/INVEST_(mnemonic)) in good User Stories and Acceptance Criteria

- Project Start
  - [Team Agreements](team-agreements/readme.md)
    - [Working Agreements](team-agreements/working-agreements/readme.md)
    - [Definition of Ready](team-agreements/definition-of-ready/readme.md)
    - [Definition of Done](team-agreements/definition-of-done/readme.md)
    - [Estimation](sprint-planning/estimation/readme.md)
  - [Repository organization strategies (How many repositories? How should I decide?)](source-control/readme.md)
    - Setting up a new repository (readme, license, ignores, etc)
  - [Versioning (extend)](source-control/versioning/readme.md)
    - Recipe for implementing Semantic Versioning
      - ADO Pipelines
      - Jenkins
  - [Building a Product Backlog](backlog-management/readme.md)
    - Guide to creating stories
      - INVEST
      - User story and acceptance criteria examples
      - Defining stories for ML
    - Recipes
      - Managing product backlog in ADO
- Day 1
  - [Sprint Planning](sprint-planning/readme.md)
    - Purpose, Goals, Participants, Facilitation Guidance, Impact, and Measures
    - Capacity Planning
    - Tasking
    - Dividing work WIP Limits
  - [Test-First Development](test-first-development/readme.md)
    - Conceptual (Purpose, Goals, Impact, and Measures)
    - Developing Test Cases
    - [Unit Testing](test-first-development/unit-testing/readme.md)
      - Conceptual (Purpose, Goals, Impact, and Measures)
    - Load Testing
  - [Feature Branching (creating branch for new story)](source-control/feature-branching/readme.md)
- Day 2
  - [Source Control](source-control/readme.md)
    - [Commit best practices](source-control/contributing/readme.md#commit-best-practices)
    - [Git guidance](source-control/git-guidance/readme.md)
  - [Continuous Integration](continuous-integration/readme.md)
    - Conceptual (Purpose, Goals, Impact, and Measures)
      - Recipes for ADO
  - Scrum of Scrums
    - Purpose, Goals, Participants, Facilitation Guidance, Impact, and Measures
  - [Daily Standups](stand-ups/readme.md)
    - Purpose, Goals, Participants, Facilitation Guidance, Impact, and Measures
      - What should be in my standup update
    - Recipes
      - How to run efficient standups for remote teams
- Day 3
  - [Pull Requests](code-reviews/pull-requests.md) (separate from code reviews)
    - Conceptual requirements for pull request (it should build, have 1 reviewer, linked work item, build changes)
      - Add emphasis on importance of protecting master, effect this has on crew efficiency
    - Recipe for Setup in
      - Azure DevOps
      - GitHub
    - [Code Reviews](code-reviews/README.md)
      - Conceptual
        - Add to checklist (breaking changes & backward compatibility, security, fault tolerance, etc)
  - Code Merging
    - prescribe strategy (i.e. squash /w or w/o rebase)
- Day 4
  - [Continuous Deployment](continuous-deployment/readme.md) (extend, much more explanation needed)
    - Conceptual, Purpose, Goals, Impact and Measures
      - Which environments (ci, test, stage)? For each environment...
        - Conceptually whats is the purpose for each env
        - When should deployment trigger
        - Pre-deployment approvers
        - Sign off for promotion
    - Recipes for Setting up CD Pipelines
      - Azure DevOps
  - Asserting Test Cases and Automation
- Day 5
  - Sprint Demo
  - [Retrospectives](retrospectives/readme.md)
    - Conceptual
      - Inputs (Requirements to have ready before meeting)
      - Participants required
      - Outputs (Decisions, actions to conclude meeting)
    - Guide for retrospective facilitator
      - Timeline for 1 hour retro
      - Tips for sticking to time
      - Voting for action items
    - Recipes
      - Remote retros using ADO Retrospectives
      - Remote retros using Retrium
  - [Grooming](backlog-management/grooming/readme.md)
    - Conceptual
      - Inputs (Requirements to have ready before meeting)
      - Participants required
      - Outputs (Decisions, actions to conclude meeting)
    - Definition of ready for stories
      - Examples of well defined acceptance criteria
      - Can the story be tested as written
      - Can it be completed within a sprint
      - Is it dependent on other stories
    - [Estimation](sprint-planning/estimation/readme.md)
      - Resolving estimation conflicts (two people are sizing differently))

- [ ] [Plan the first sprint](sprint-planning/readme.md)
  - Agree on a sprint goal, and how to measure the sprint progress
  - Determine team capacity
  - Assign user stories to the sprint and split user stories into tasks
  - Set up Work in Progress (WIP) limits
- [ ] [Decide on test frameworks and discuss test strategies](test-first-development/readme.md)
  - Discuss the purpose and goals of tests and how to measure test coverage
  - Agree on how to separate unit tests from integration, load and smoke tests
  - Design the first test cases
- [ ] [Decide on branch naming](source-control/feature-branching/readme.md)
- [ ] [Discuss security needs and verify that secrets are kept out of source control](continuous-deployment/secrets-management/recipes/azure-devops/secrets-per-branch.md)

### Day 2

- [ ] [Set up Source Control](source-control/readme.md)
  - Agree on [best practices for commits](source-control/readme.md#commit-best-practices)
- [ ] [Set up basic Continuous Integration with linters and automated tests](continuous-integration/readme.md)
- [ ] [Set up meetings for Daily Standups and decide on a scrum master](stand-ups/readme.md)
  - Discuss purpose, goals, participants and facilitation guidance
  - Discuss timing, and how to run an efficient stand-up
- [ ] [If the project has sub-teams, set up a Scrum of Scrums](scrum-of-scrums/readme.md)

### Day 3

- [ ] [Agree on code style](code-reviews/README.md) and on [how to assign Pull Requests](code-reviews/pull-requests.md)
- [ ] [Set up Build Validation for Pull Requests (2 reviewers, linters, automated tests)](code-reviews/README.md) and agree on [Definition of Done](team-agreements/definition-of-done/readme.md)
- [ ] [Agree on a Code Merging strategy](source-control/git.md) and update the [CONTRIBUTING.md](resources/templates/CONTRIBUTING.md)
- [ ] [Agree on logging and observability frameworks and strategies](observability/readme.md)

### Day 4

- [ ] [Set up Continuous Deployment](continuous-deployment/readme.md)
  - Determine what environments are appropriate for this solution
  - For each environment discuss purpose, when deployment should trigger, pre-deployment approvers, sing-off for promotion.
- [ ] [Decide on a versioning strategy](source-control/versioning/readme.md)
- [ ] Agree on how to [Desing a feature and conduct a Design Review](design-reviews/readme.md)

### Day 5

- [ ] Conduct a Sprint Demo
- [ ] [Conduct a Retrospective](retrospectives/readme.md)
  - Determine required participants, how to capture input (tools) and outcome
  - Set a timeline, and discuss facilitation, meeting structure etc.
- [ ] [Groom the Backlog](backlog-management/grooming/readme.md)
  - Determine required participants
  - Update the [Definition of Ready](team-agreements/definition-of-ready/readme.md)
  - Update estimates, and the [Estimation](sprint-planning/estimation/readme.md) document
- [ ] [Submit Engineering Feedback for issues encountered](engineering-feedback/readme.md)
