# Structure of a Sprint

### Goals

This index structure is intended to accomplish the following goals

1. Organize for quick reference and discoverability.
2. Provide content in a logical structure which reflects the engineering process.
3. Extensible hierarchy to allow teams to share deep subject matter expertise.

### A Week In The Life Of....

This layout structures the playbook content to make it easy day to day to find relevant resources during an Agile sprint. 

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
    - Commit best practices
    - [Git guide](source-control/git.md)
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
  - [Pull Requests](pull-requests/readme.md) (separate from code reviews)
    - Conceptual requirements for pull request (it should build, have 1 reviewer, linked work item, build changes)
      - Add emphasis on importance of protecting master, effect this has on crew efficiency
    - Recipe for Setup in
      - Azure DevOps
      - GitHub
    - [Code Reviews](pull-requests/code-reviews/readme.md)
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

### Assumptions

This workflow makes the following assumptions about the development environment

* Team is using git for version control.
