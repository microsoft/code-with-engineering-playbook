# CSE Code-With Customer/Partner Engineering Playbook

An engineer working for a [CSE](./CSE.md) project...

* Has responsibilities to their team – mentor, coach, and lead.
* Knows their **playbook**. Follows their playbook. Fixes their playbook if it is broken. If they find a better playbook, they copy it. If somebody could use your playbook, give them yours.
* Leads by example. Models the behaviors we desire both interpersonally and technically.
* Strives to understand how their work fits into a broader context and ensures the outcome.

This our playbook. All contributions welcome! Please feel free to submit a pull request to get involved.

## Outline

The following outlines each section and its contents.

### Goals

The proposed outline is intended to accomplish the following goals

1. Organize for quick reference and discoverability.
2. Define content with a logical structure which reflects the engineering process (our Agile Lifecycle below).
3. Extensible hierarchy to allow teams to share deep subject matter expertise.

### Agile Lifecycle

Our Agile Lifecycle is rooted in CSE's one week sprint cycle, though the ordering and general guidance should still easily apply to sprint cycles of any reasonable length. Each section within then allows for deep dive information, recipes, and use cases.

- [Project Start](0000-pre-sprint)
  - [Team Agreements](0000-pre-sprint/team-agreements)
    - [Working Agreements](0000-pre-sprint/team-agreements/working-agreements)
    - [Definition of Ready](0000-pre-sprint/team-agreements/definition-of-ready)
    - [Definition of Done](0000-pre-sprint/team-agreements/definition-of-done)
    - [Estimation ](0000-pre-sprint/team-agreements/estimation)
  - [Repository organization strategies (How many repositories? How should I decide?)](0000-pre-sprint/source-control-repositories)
    - Setting up a new repository (readme, license, ignores, etc)
  - [Versioning (extend)](0000-pre-sprint/versioning)
    - Recipe for implementing Semantic Versioning
      - ADO Pipelines
      - Jenkins
  - [Building a Product Backlog](0000-pre-sprint/product-backlog)
    - Guide to creating stories
      - INVEST
      - User story and acceptance criteria examples
      - Defining stories for ML
    - Recipes
      - Managing product backlog in ADO
- [Day 1](0010-day-one)
  - [Sprint Planning](0010-day-one/sprint-planning)
    - Purpose, Goals, Participants, Facilitation Guidance, Impact, and Measures
    - Capacity Planning
    - Tasking
    - Dividing work WIP Limits
  - [Test-First Development](0010-day-one/test-first-development)
    - Conceptual (Purpose, Goals, Impact, and Measures)
    - Developing Test Cases
    - Unit Testing
      - Conceptual (Purpose, Goals, Impact, and Measures)
    - Load Testing
  - [Feature Branching (creating branch for new story)](0010-day-one/feature-branching)
- Day 2
  - Commit best practices (move some existing content here)
    - Link work items
    - How often to commit
    - When to push
  - Continuous Integration (extend)
    - Conceptual (Purpose, Goals, Impact, and Measures)
      - Recipes for ADO
  - Scrum of Scrums
    - Purpose, Goals, Participants, Facilitation Guidance, Impact, and Measures
  - [Daily Standups](0020-day-two/standups)
    - Purpose, Goals, Participants, Facilitation Guidance, Impact, and Measures
      - What should be in my standup update
    - Recipes
      - How to run efficient standups for remote teams
- Day 3
  - Pull Requests (separate from code reviews)
    - Conceptual requirements for pull request (it should build, have 1 reviewer, linked work item, build changes)
      - Add emphasis on importance of protecting master, effect this has on crew efficiency
    - Recipe for Setup in
      - Azure DevOps
      - GitHub
    - Code Reviews
      - Conceptual
        - Add to checklist (breaking changes & backward compatibility, security, fault tolerance, etc)
  - Code Merging
    - prescribe strategy (i.e. squash /w or w/o rebase)
- Day 4
  - Continuous Deployment (extend, much more explanation needed)
    - Conceptual, Purpose, Goals, Impact and Measures
      - Which environments (ci, test, stage)? For each environment...
        - Conceptually whats is the purpose for each env
        - When should deployment trigger
        - Pre-deployment approvers
        - Sign off for promotion
    - Recipies for Setting up CD Pipelines
      - ADO
  - Asserting Test Cases and Automation
- Day 5
  - Sprint Demo
  - Retrospectives
    - Conceptual
      - Inputs (Requirements to have ready before meeting)
      - Participants required
      - Outputs (Decsions, actions to conclude meeting)
    - Guide for retrospective facilitator
      - Timeline for 1 hour retro
      - Tips for sticking to time
      - Voting for action items
    - Recipes
      - Remote retros using ADO Retrospectives
      - Remote retros using Retrium
  - Grooming
    - Conceptual
      - Inputs (Requirements to have ready before meeting)
      - Participants required
      - Outputs (Decsions, actions to conclude meeting)
    - Definition of ready for stories
      - Examples of well defined acceptance criteria
      - Can the story be tested as written
      - Can it be completed within a sprint
      - Is it dependent on other stories
    - Estimation
      - Resolving estimation conflicts (two people are sizing differently))

### Assumptions

This workflow makes the following assumptions about the development environment

* Team is using git for version control.
