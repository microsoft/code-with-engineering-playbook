# Documentation

Every software development project requires documentation. [Agile Software Development](https://agilemanifesto.org/) values *working software over comprehensive documentation*. Still, projects should include the key information needed to understand the development and the use of the generated software.

Documentation shouldn't be an afterthought. Different written documents and materials should be created during the whole life cycle of the project, as per the project needs.

## Table of Contents

- [Goals](#goals)
- [Challenges](#challenges)
- [Areas of Focus](#areas-of-focus)
- [Communication and Documentation](#communication-and-documentation)
- [Utilities](#utilities)
- [Resources](#resources)

## Goals

- Facilitate onboarding of new team members.
- Improve communication and collaboration between teams (especially when distributed across time zones).
- Improve the transition of the project to another team.

## Challenges

When working in an engineering project, we typically encounter one or more of these challenges related to documentation (including some examples):

- **Non-existent**.
  - No onboarding documentation, so it takes a long time to setup the environment when you join the project.
  - No document in the wiki explaining existing repositories so you cannot tell which of the 10 available repositories you should clone.
  - No main README, so you don't know where to start when you clone a repository.
  - No "how to contribute" section, so you don't know which is the branch policy, where to add new documents, etc.
  - No code guidelines, so everyone follows different naming conventions, etc.
- **Hidden**.
  - Impossible to find useful documentation as it’s scattered all over the place. E.g., no idea how to compile, run and test the code as the README is hidden in a folder within a folder within a folder.
  - Useful processes (e.g., grooming process) explained outside of the backlog management tool and not linked anywhere.
  - Decisions taken in different channels other than the backlog management tool and not recorded anywhere else.
- **Incomplete**.
  - No clear branch policy, so everyone names their branches differently.
  - Missing settings in the "how to run this" document that are required to run the application.
- **Inaccurate**.
  - Documents not updated along with the code, so they don't mention the right folders, settings, etc.
- **Obsolete**.
  - Design documents that don't apply anymore sitting next to valid documents. Which one shows the latest decisions?
- **Out of order (subject / date)**.
  - Documents not organized per subject/workstream so not easy to find relevant information when you change to a new workstream.
  - Design decision logs out of order and without a date that helps to determine which is the final decision on something.
- **Duplicate**.
  - No settings file available in a centralized place as a single source of truth, so developers must keep sharing their own versions and we end up with many different files that might or might not work.
- **Afterthought**.
  - Key documents created when we've been several weeks into the project: onboarding, how to run the app, etc.
  - Documents that we create in the last minute just before the end of a project, forgetting that they also help the team while working on the project.

## Areas of Focus

- [Project and Repositories](#project-and-repositories)
- [Work items](#work-items)
- [Code](#code)
- [Pull Requests](#pull-requests)
- [Security](#security)
- [Engineering Feedback](#engineering-feedback)

### Project and Repositories

Every source code repository should include documentation that is specific to it (e.g., in a Wiki within the repository), while the project itself should include general documentation that is common to all its associated repositories (e.g., in a Wiki within the backlog management tool).

**Documentation specific to a repository:**

- Introduction.
- Getting started.
  - Onboarding.
  - Setup: programming language, frameworks, platforms, tools, etc.
  - Sandbox environment.
  - Working Agreement.
  - Contributing Guide.
- Structure: folders, projects, etc.
- How to compile, test, build, deploy the solution/each project.
  - Different OS versions.
  - Command line + editors/IDEs.
- Design decision records.

Some sections in the documentation of the repository might point to the project’s documentation (e.g., Onboarding, Working Agreement, Contributing Guide).

**Common documentation to all repositories:**

- Introduction.
  - Project.
  - Customer.
  - Definitions.
  - Requirements.
- Onboarding.
- Repository guide.
  - Production, Spikes.
- Working Agreement.
  - Working beliefs.
  - Definition of Ready.
  - Definition of Done.
  - Scrum rhythm.
- Contributing Guide.
  - Repo structure.
  - Design documents.
  - Branching and branch name strategy.
  - Merge and commit history strategy.
  - Pull Requests.
  - Code Review Process.
  - Code Review Checklist.
- Design decision records.
  - Template.

### Work items

- Epics/Features/User Stories/Tasks/Bugs.
  - Title.
  - Description.
  - Acceptance Criteria.
  - Estimation.
  - Discussion.
- Stories/tasks include:
  - Design reviews.
  - Observability design components.
- Actions from Retrospectives.

### Code

- Comments.
  - Placeholders/TODOs.
- Doc comments.
- CLI help, API docs (Swagger), etc.

### Pull Requests

- Title.
- Description.
- Linked worked items.
- Comments.

### Security

- Artifacts.
  - Threat models.
  - Security requirements.
  - Reports.
  - Lessons learned.

### Engineering Feedback

- Actionable.
- Specific.
- Detailed.
  - Assets.
  - Customer scenario.

## Communication and Documentation

- Communication channels.
  - In-person vs. phone vs. email vs. Teams/Slack vs. Discussion section in Wiki/tasks vs. …
- Recording decisions/changes.
- Communicating decisions/changes.
  - E.g., Channels in Teams: General, Breaking Changes, Meetings, PRs, Workstreams

## Utilities

- Wikis vs. note apps (e.g., OneNote).
- Languages: markdown (.md), mermaid (.mmd + .png).
- Tools and extensions.
- Automation e.g., Linters, Precommit.
- Integration with Teams/Slack.
  - Pull Requests.

## Resources

- [Software Documentation Types and Best Practices](https://blog.prototypr.io/software-documentation-types-and-best-practices-1726ca595c7f)
- [Why is project documentation important?](https://www.greycampus.com/blog/project-management/why-is-project-documentation-important)
