# Work Items

While many teams can work with a flat list of items, sometimes it helps to group related items into a hierarchical structure. You can use portfolio backlogs to bring more order to your backlog.

**Agile** process backlog work item hierarchy:

![agile-artifacts](./images/scrum-artifacts.png)

**Scrum** process backlog work item hierarchy:

![scrum-artifacts](./images/scrum-artifacts.png)

Bugs can be set at the same level as User Stories / Product Backlog Items or Tasks.

## Epics and Features

User stories / Product Backlog Items roll up into **Features**, which typically represent a shippable deliverable that addresses a customer need e.g., "Add shopping cart". And Features roll up into **Epics**, which represent a business initiative to be accomplished e.g., "Increase customer engagement". Take that into account when naming them.

Each Feature or Epic should include as much detail as the team needs to:

- Understand the scope.
- Estimate the work required.
- Develop tests.
- Ensure the end product meets acceptance criteria.

Details that should be added:

- *Value Area*: Business (directly deliver customer value) vs. Architectural (technical services to implement business features).
- *Effort / Story Points / Size*: Relative estimate of the amount of work required to complete the item.
- *Business Value*: Priority of an item compared to other items of the same type.
- *Time Criticality*: Higher values indicate an item is more time critical than items with lower values.
- *Target Date* by which the feature should be implemented.

You may use work item tags to support queries and filtering.

## User Stories / Product Backlog Items

Each User Story / Product Backlog Item should be sized so that they can be completed within a sprint.

You should add the following details to the items:

- Title. ```// TODO```
- Description.
  - Design Reviews.
- Acceptance Criteria.
- Activity: Deployment, Design, Development, Documentation, Requirements, Testing.
- Original Estimate: The amount of estimated work required to complete a task.

Remember to use the Discussion section of the items to keep track of related comments, and mention individuals, groups, work items or pull requests when required.

```// TODO https://docs.microsoft.com/en-us/azure/devops/boards/backlogs/create-your-backlog?view=azure-devops&tabs=agile-process```

## Tasks

Each Task should be sized so that they can be completed within a day.

You should at least add the following details to the items:

- Title.
- Description.
- Reference to the working branch in related code repository.

Remember to use the Discussion section of the tasks to keep track of related comments.

```// TODO https://docs.microsoft.com/en-us/azure/devops/boards/sprints/add-tasks?view=azure-devops```

### Actions from Retrospectives

```// TODO https://docs.microsoft.com/en-us/azure/devops/boards/sprints/add-tasks?view=azure-devops```

## Bugs

```// TODO https://docs.microsoft.com/en-us/azure/devops/boards/backlogs/manage-bugs?view=azure-devops```

## Issues / Impediments

```// TODO https://docs.microsoft.com/en-us/azure/devops/boards/backlogs/manage-issues-impediments?view=azure-devops```

## Related information

- [Best practices for Agile project management - Azure Boards | Microsoft Docs](https://docs.microsoft.com/en-us/azure/devops/boards/best-practices-agile-project-management?view=azure-devops&tabs=agile-process).
- [Define features and epics, organize backlog items - Azure Boards | Microsoft Docs](https://docs.microsoft.com/en-us/azure/devops/boards/backlogs/define-features-epics?view=azure-devops&tabs=scrum-process).
- [Create your product backlog - Azure Boards | Microsoft Docs](https://docs.microsoft.com/en-us/azure/devops/boards/backlogs/create-your-backlog?view=azure-devops&tabs=agile-process).
- [Add tasks to support sprint planning - Azure Boards | Microsoft Docs](https://docs.microsoft.com/en-us/azure/devops/boards/sprints/add-tasks?view=azure-devops).
- [Define, capture, triage, and manage bugs or code defects - Azure Boards | Microsoft Docs](https://docs.microsoft.com/en-us/azure/devops/boards/backlogs/manage-bugs?view=azure-devops).
- [Add and manage issues or impediments - Azure Boards | Microsoft Docs](https://docs.microsoft.com/en-us/azure/devops/boards/backlogs/manage-issues-impediments?view=azure-devops).
