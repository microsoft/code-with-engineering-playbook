# Planning

## Goals

During the [sprint planning](https://www.agilealliance.org/glossary/sprint-planning), the team discusses and agrees on the scope for the upcoming sprint.

Goals:

- Select the **stories** that will be implemented in the sprint.
- Estimate the **effort** required for the stories in the sprint.
- Split the stories into **tasks**.

General guidance:

- The sprint planning should happen at the beginning of the new sprint (or at the end of the previous one). It usually lasts between 1 and 4 hours depending on the size of the team and duration of the sprint.
- Each story should be able to be completed within the duration of the sprint. Otherwise, the story should be broken up into multiple stories.
- Each task duration should be somewhere between 2 to 8 hours.

## Participation

**Everyone** in the team should participate in the sprint planning, including the Product Owner.

Specific roles:

- [Process Lead]:
  - Facilitate the conversation.
  - Ensure everyone is heard.
  - Remind scrums/agile/other principles and sprint planning goals if necessary, updating the working agreement where needed to ensure a mapping between principals and what is working/not working for the team.
- [Product owner](https://www.agilealliance.org/glossary/product-owner/):
  - Prior to the sprint planning: performs some [backlog refinement](../backlog-management/refinement/readme.md) to ensure that each story that they want to propose for the new sprint (*) :
  
    - Is in the correct position in the backlog, by right priority order.
    - Is attending the [definition of ready](../team-agreements/definition-of-ready/readme.md).
  - Do NOT pre assign stories to the future sprint. This is the purpose of the sprint planning.
  - During the meeting:

    - Clarify team's questions and improve the story accordingly, if necessary.
    - Describe to the team the stories that they propose for the sprint.

- All team members:

  - Listen to the product owner story description.
  - Ask questions to make sure everyone understands each story properly.
  - [Estimate](estimation/readme.md) the effort for each backlog item, as a team.
  - Split each story into tasks.
  - (Optional) self assign first task to team members.

*(\*) some teams find useful to define a **[Definition of ready](../team-agreements/definition-of-ready/readme.md)** that describes the list of things that needs to be done in each story before the **product owner** can propose it for a **sprint**. The list proposed here is the classic minimal definition of ready.*

## Impact

Sprint planning key benefits:

- Everyone participates, the entire team is aware of the scope of the sprint.
- The team has an agreement on the goal of the sprint.
- Each team member takes responsibility in the sprint scope by participating in the stories discovery, prioritization and estimation.
- Creates a channel to communicate, discover and discuss dependencies.

## Measures

- How many stories needed more work before being presented (and were rejected because they were not clear enough)?
- How realistic was the estimation of effort?
- Team satisfaction (can be assessed during the retrospective): does everyone in the team feel included in sprint planning?

## Facilitation Guidance

Prior to the meeting:

- Set sprint goal.
- Make sure the backlog is prioritized.
- Make sure each story that is a candidate for next sprint is [ready](../team-agreements/definition-of-ready/readme.md).

During the meeting:

- Confirm team capacity. This should be done using the average velocity (number of points achieved per sprint) and removing the project vacations/holidays/off days. If it helps, you can get the daily average velocity, divide by the number of team members and multiply by number of off days.
- Timebox (for instance: half of the meeting for story selection, half of the meeting for task splitting).
- Agree on how much capacity needs to be "saved" for bug fixing (might depend on the sprint).
- Ensure everyone understands each story that is selected for the sprint.
- Ensure everyone participates in story effort estimation.

Other considerations:

- Take into account off days (vacations, national holidays, unavailability).
- When the backlog reaches a size that makes it difficult to manage by one team, you might want to split into different work streams. This might require thinking about [scrum of scrums](../scrum-of-scrums/readme.md) and all related ceremonies.
- For Azure DevOps, leverage the [Sprint Goal](https://marketplace.visualstudio.com/items?itemName=keesschollaart.sprint-goal&targetId=e254bbbe-45a2-4344-9bbd-c4ba47e66719&utm_source=vstsproduct&utm_medium=ExtHubManageList) extension to display the goal in the tab-label on every page within the sprint.
