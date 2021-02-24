# Documentation

Every software development project requires documentation. [Agile Software Development](https://agilemanifesto.org/) values *working software over comprehensive documentation*. Still, projects should include the key information needed to understand the development and the use of the generated software.

Documentation shouldn't be an afterthought. Different written documents and materials should be created during the whole life cycle of the project, as per the project needs.

## Table of Contents

- [Goals](#goals)
- [Challenges](#challenges)
- [What documentation should exist?](#what-documentation-should-exist)
- [Best practices](#best-practices)
- [Tools](#tools)
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

## What documentation should exist

- [Project and Repositories](./guidance/project-and-repositories.md)
- [Work items](./guidance/work-items.md)
- [Code](./guidance/code.md)
- [Pull Requests](./guidance/pull-requests.md)
- [Security](./guidance/security.md)
- [Engineering Feedback](./guidance/engineering-feedback.md)

## Best practices

- [Establishing and managing documentation](./best-practices/establish-and-manage.md)
- [Where does documentation fit within story work?](./best-practices/fit-within-story-work.md)
- [Making documentation discoverable](./best-practices/discoverability.md)
- [Creating good documentation](./best-practices/good-documentation.md)
- [Keeping documentation updated](./best-practices/keep-updated.md)
- [Communication and documentation](./best-practices/communication.md)
- [Replacing documentation with automation](./best-practices/automation.md)

## Tools

- [Wikis](./tools/wikis.md)
- [Languages](./tools/languages.md)
  - [markdown](./tools/languages.md#markdown)
  - [mermaid](./tools/languages.md#mermaid)
- [How to automate simple checks](./tools/automation.md)
- [Integration with Teams/Slack](./tools/integrations.md)

## Resources

- [Software Documentation Types and Best Practices](https://blog.prototypr.io/software-documentation-types-and-best-practices-1726ca595c7f)
- [Why is project documentation important?](https://www.greycampus.com/blog/project-management/why-is-project-documentation-important)
