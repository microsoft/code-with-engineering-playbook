# Engineering Fundamentals Outline

The following outline will use the implementation of a given story as a means to root each of the applied engineering fundamentals in the delivery of a given story.

## Proposed Outline

The proposed outline is intended to accomplish the following goals

1. Author as idea-to-delivery value stream narrative from an engineering perspective.
2. Organize for quick reference and discoverability.
3. Extensible heirarchy to allow teams to share deep subject matter expertise.

### Proposed Structure/Pattern

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

#### Example Directory Heirarchy

The following illustrates how the directory structure could be organized.

```
- /continuous-integration
    - README.md (Conceptual)
    - /double-click
        - deploying-ci-builds-for-e2e-testing.md
        - incorporating-code-static-analysis.md
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

### Working Playbook Outline

The following outlines each section and what content would be included within each section.

- Team Baselines
  - Working Agreements
  - Definition of Ready
  - Definition of Done
  - Estimation Baselines
    - Pick stories to use as markers for relative sizing
    - Pick sizing scale (fibonacci, currency denominations, etc)
    - Pick coversion ratio for points:days/hours:engineers (i.e. 1point = 1 day for 1 engineer)
- Aglie Ceremonies
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
      - Provide guidance on what scale to use (fibonacci, currency denominations, etc)
      - How to establish baseline estimates (if using relative sizing)
      - How is that scale converted to time (if using time-based sizing)
      - Resolving estimation conflicts (two people are sizing differently)
    - Recipes
      - Using "Magic Estimation" strategy
  - Planning
    - Conceptual
      - Inputs (Requirements to have ready before meeting)
      - Participants required
      - Outputs (Decsions, actions to conclude meeting)
    - Determining team capacity
    - Tasking stories in sprint backlog
      - Size of tasks
      - Hour estimates
      - Updating todo hours
    - Dividing work into WIP (work-in-progress) or Workstreams
  - Daily Standups
    - Conceptual
      - Inputs (Requirements to have ready before meeting)
      - Participants required
      - Outputs (Decsions, actions to conclude meeting)
    - What should be in my standup update
    - Recipes
      - How to run efficient standups for remote teams
  - Scrum of Scrums
    - Conceptual
      - Inputs (Requirements to have ready before meeting)
      - Participants required
      - Outputs (Decsions, actions to conclude meeting)
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
- Backlog Management
  - Product Backlog
  - Sprint Backlog
  - Defect Triage
    - Define criteria for defect
    - Severity definition (what constitutes Sev1, Sev2, etc)
    - Iteration Defects vs Regression
  - Software Inventory Guidance (how far ahead should I plan)
  - User Story States
  - Defect States
  - Recipes
    - Managing product backlog in ADO
    - Configuring ADO states for Stories and Defects
    - Queries for Defect Triage
    - Queries for Grooming & Planning
- Testing (NEW)
  - Designing test cases
  - Automation Testing (aka End-to-End or Integration)
  - Load Testing
- Feature/Story Implementation Design (NEW)
  - What should be considered durign design?
    - Sequences (how does each part of the system participate in the story)
    - System Interfaces/Contracts
    - Database schema changes
    - Backwards Compatibility
    - Security & Threat Modeling
    - Authorization (Roles/Permissioning)
  - Conducting design reviews
- Source Control (extend/refactor, would make some of the existing content more opinionated)
  - Repository organization strategies (How many repositories? How should I decide?)
  - Setting up a new repository (readme, license, ignores, etc)
    - Recipe for ADO
    - Recipe for GitHub
  - Branching for a new feature or story (move some existing content here and make more opinionated)
  - Commit best practices (move some existing content here)
    - Link work items
    - How often to commit
    - When to push
  - Merge (move existing content here and make more opinionated)
    - squash (/w rebase?)
- Versioning (extend)
  - Recipe for implementing Semantic Versioning
    - ADO Pipelines
    - Jenkins
- Continuous Integration (extend)
  - Conceptual ()
  - Deploying from CI builds for e2e testing
  - Static code analysis
    - Recipies for ADO using
      - Sonarqube
  - Recipes for ADO & Jenkins
    - Recipes for setting up CI pipelines for specific frameworks & languages
      - .NET Core
      - Node
      - Python
      - C++
      - GO
- Pull Requests (separate from code reviews)
  - Conceptual requirements for pull request (it should build, have 1 reviewer, linked work item, build changes)
    - Add emphasis on importance of protecting master, effect this has on crew efficiency
  - Testing before merging (deploy and test end to end)
    - Assert designed tests
    - Verify automated end-to-end tests against deployed changes
  - Recipe for Setup in
    - Azure DevOps
    - GitHub
  - Code Reviews (extend)
    - Conceptual (extend)
      - Add to checklist (breaking changes & backward compatibility, security, fault tolerance, etc)
- Continuous Deployment (extend, much more explanation needed)
  - Conceptual
    - Which environments (ci, test, stage)? For each environment...
      - Conceptually whats is the purpose for each env
      - When should deployment trigger
      - Pre-deployment approvers
      - Sign off for promotion
  - Recipies for Setting up CD Pipelines
    - ADO
    - Jenkins
- Production Readiness
  - Threat Model
  - Operational Playbooks/Runbooks
  - Monitoring & Alerting
  - Firewall and Networking requirements (Data Flow Diagram)
