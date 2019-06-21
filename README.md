# CSE Code-With Customer/Partner Engineering Playbook

An engineer working for a [CSE](./CSE.md) project...

* Has responsibilities to their team – mentor, coach, and lead.
* Knows their **playbook**. Follows their playbook. Fixes their playbook if it is broken. If they find a better playbook, they copy it. If somebody could use your playbook, give them yours.
* Leads by example. Models the behaviors we desire both interpersonally and technically (this is what most people think of as a "developer").
* Strives to understand how their work fits into a broader context and ensures the outcome.

This is the playbook. You are invited to contribute via standard git pull requests to GitHub.

## Outline

The following outlines each section and what content would be included within each section.

### Goals

The proposed outline is intended to accomplish the following goals

1. Author as idea-to-delivery value stream narrative from an engineering perspective.
2. Organize for quick reference and discoverability.
3. Extensible heirarchy to allow teams to share deep subject matter expertise.

### Working Heirarchy

The working heirarchy is rooted in CSE's one week sprint cycle. Each section within then allows for deep dive information, recipes, and use cases.

Project Start
  - Team Agreements
    - Working Agreements
    - Definition of Ready
    - Definition of Done
    - Estimation Baselines
  - Source Control - Repository organization strategies (How many repositories? How should I decide?)
    - Setting up a new repository (readme, license, ignores, etc)
      - Recipe for ADO
      - Recipe for GitHub
  - Versioning (extend)
    - Recipe for implementing Semantic Versioning
      - ADO Pipelines
      - Jenkins
  - Building a Product Backlog
    - Guide to creating stories
      - INVEST
      - User story and acceptance criteria examples
      - Defining stories for ML
    - Recipes
      - Managing product backlog in ADO
Day 1
  - Sprint Planning
    - Purpose, Goals, Participants, Facilitation Guidance, Impact, and Measures
    - Capacity Planning
    - Tasking
    - Dividing work WIP Limits
  - Test-First Development
    - Conceptual (Purpose, Goals, Impact, and Measures)
    - Developing Test Cases
    - Unit Testing
      - Conceptual (Purpose, Goals, Impact, and Measures)
    - Load Testing
  - Feature Branching (creating branch for new story)
Day 2
  - Commit best practices (move some existing content here)
    - Link work items
    - How often to commit
    - When to push
  - Continuous Integration (extend)
    - Conceptual (Purpose, Goals, Impact, and Measures)
      - Recipes for ADO
  - Scrum of Scrums
    - Purpose, Goals, Participants, Facilitation Guidance, Impact, and Measures
  - Daily Standups
    - Purpose, Goals, Participants, Facilitation Guidance, Impact, and Measures
      - What should be in my standup update
    - Recipes
      - How to run efficient standups for remote teams
Day 3
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
Day 4
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
Day 5
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

### Structure/Pattern

At a conceptual level each section consist of the following parts

1. Conceptual Overview
   1. Explain why this will positively impact the project
   2. What are potential consequences of not using this in my project?
   3. Describe how the concept works
2. Double-Click
   1. Dive into specific areas of whats described in the conceptual overview (i.e Grooming > Estimation > establish baseline estimates)
3. Recipes
   1. Tool specific implementations of the concept
   2. Named patterns or games that implement the concept (usually applies to agile cermonies)
4. Case Studies
   1. Specific project examples how teams implemented the concept
   2. What problem was the team try to solve with their implementation?
   3. What worked well?
   4. Opportunities for improvement
   5. External Reference Material (???)

### Example Directory Heirarchy

The following illustrates how the directory structure could be organized.

```
- /continuous-integration
    - README.md (Conceptual)
    - /e2e-testing-in-ci
        - README.md
    - /static-code-analysis
        - README.md
    - /recipes
        - /azure-devops
            - versioning-ci-builds-in-azure-devops.md
            - sonar-qube-integration.md
            - ci-pipeline-for-dotnet-core.md
            - ci-pipeline-for-python.md
        - /jenkins
    - /case-studies
        - contoso-ci-pipeline-for-terraform.md
```