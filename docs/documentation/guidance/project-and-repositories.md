# Projects and Repositories

Every source code repository should include documentation that is specific to it (e.g., in a Wiki within the repository), while the project itself should include general documentation that is common to all its associated repositories (e.g., in a Wiki within the backlog management tool).

## Documentation Specific to a Repository

- Introduction
- Getting started
  - Onboarding
  - Setup: programming language, frameworks, platforms, tools, etc.
  - Sandbox environment
  - Working agreement
  - Contributing guide
- Structure: folders, projects, etc.
- How to compile, test, build, deploy the solution/each project
  - Different OS versions
  - Command line + editors/IDEs
- [Design Decision Logs](../../design/design-reviews/decision-log/README.md)
  - [Architecture Decision Record (ADRs)](../../design/design-reviews/decision-log/README.md#architecture-decision-record-(ADR))
  - [Trade Studies](../../design/design-reviews/trade-studies/README.md)

Some sections in the documentation of the repository might point to the project’s documentation (e.g., Onboarding, Working Agreement, Contributing Guide).

## Common Documentation to all Repositories

- Introduction
  - Project
  - Stakeholders
  - Definitions
  - Requirements
- [Onboarding](../../developer-experience/onboarding-guide-template.md)
- Repository guide
  - Production, Spikes
- [Team agreements](../../agile-development/team-agreements/)
  - [Team Manifesto](../../agile-development/team-agreements/team-manifesto.md)
    - Short summary of expectations around the technical way of working and supported mindset in the team.
    - E.g., ownership, respect, collaboration, transparency.
  - [Working Agreement](../../agile-development/team-agreements/working-agreement.md)
    - How we work together as a team and what our expectations and principles are.
    - E.g., communication, work-life balance, scrum rhythm, backlog management, code management.
  - [Definition of Done](../../agile-development/team-agreements/definition-of-done.md)
    - List of tasks that must be completed to close a user story, a sprint, or a milestone.
  - [Definition of Ready](../../agile-development/team-agreements/definition-of-ready.md)
    - How complete a user story should be in order to be selected as candidate for estimation in the sprint planning.
- Contributing Guide
  - Repo structure
  - Design documents
  - [Branching and branch name strategy](../../source-control/naming-branches.md)
  - [Merge and commit history strategy](../../source-control/merge-strategies.md)
  - [Pull Requests](./pull-requests.md)
  - [Code Review Process](../../code-reviews/README.md)
  - [Code Review Checklist](../../code-reviews/process-guidance/reviewer-guidance.md)
    - [Language Specific Checklists](../../code-reviews/recipes/)
- [Project Design](../../design/design-reviews/README.md)
  - [High Level / Game Plan](../../design/design-reviews/recipes/high-level-design-recipe.md)
  - [Milestone / Epic Design Review](../../design/design-reviews/recipes/milestone-epic-design-review-recipe.md)
- [Design Review Recipes](../../design/design-reviews/README.md#Recipes)
  - [Milestone / Epic Design Review Template](../../design/design-reviews/recipes/templates/milestone-epic-design-review.md)
  - [Feature / Story Design Review Template](../../design/design-reviews/recipes/templates/feature-story-design-review.md)
  - [Task Design Review Template](../../design/design-reviews/recipes/templates/template-task-design-review.md)
  - [Decision Log Template](../../design/design-reviews/decision-log/doc/decision-log.md)
  - [Architecture Decision Record (ADR) Template](../../design/design-reviews/decision-log/README.md#architecture-decision-record-(ADR)) ([Example 1](../../design/design-reviews/decision-log/doc/adr/0001-record-architecture-decisions.md),
    [Example 2](../../design/design-reviews/decision-log/doc/adr/0002-app-level-logging.md))
  - [Trade Study Template](../../design/design-reviews/trade-studies/template.md)
