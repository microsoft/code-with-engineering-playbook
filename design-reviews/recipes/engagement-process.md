# Incorporating Design Reviews into an Engagement

## Introduction

Design reviews should not feel like a burden.  Design reviews can be easily incorporated into your dev crew process with minimal overhead.  

- Only create design reviews when needed.  Not every story or task requires a full blown design review
- Leverage this guidance and make changes to fit in best with your team.  Every team works a bit differently and has different tweaks that work best for them.
- Leverage Microsoft subject matter experts (SME) as needed during design reviews. Not every story needs SME or leadership sign-off. Most design reviews can be fully executed within a dev crew.

The following are guidelines on how Microsoft and the customer togethere can start incorporating design reviews into day-to-day agile processes.

## Table of Contents

- [Envisioning / Architecture Design Session (ADS)](#envisioning--architecture-design-session-ads)
- [Sprint Planning](#sprint-planning)
- [Sprint Backlog Grooming](#sprint-backlog-grooming)
- [Sprint Retrospectives](#sprint-retrospectives)
- [Wrap-up Sprints](#wrap-up-sprints)

## Envisioning / Architecture Design Session (ADS)

Early in an engagement Microsoft works with customers to understand their unique goals and objective and establish a definition of done. Microosft dives deep into existing customer infrastructure and architecture to understand potential constraints.

During this time the team uncovers many unknowns, leveraging all new found information, in order to help generate a design to meet customer goals.

> **Tip**: Not all unknowns have been addressed at this point.

## Sprint Planning

In many of our engagements we work with customers using a SCRUM agile development process which begins with sprint planning. [Sprint planning](../../agile-development/sprint-planning/readme.md) is a great opportunity to dive deep into the next set of high priority work.  Some key points to address are the following:

1. Identify stories that require design reviews
1. Breakout design from implementation for complex stories
1. Assign owners to each design story

Stories that will benefit from design reviews have one or more of the following in common:

1. There are many unknown or unclear requirements
1. There is wide distribution of anticipated workload, or story pointing, across the dev crew
1. The developer cannot clearly illustrate all tasks required for the story

> **Tip:** After sprint planning is complete the team should consider hosting an initial design review discussion to dive deep on the design requirement of the stories that were identified. This will provide more clarity so that the team  can move forward with a design review, syncronously or asynchronously, and complete tasks.

## Sprint Backlog Grooming

The team should consider hosting a [Sprint Backlog Grooming](../../agile-development/backlog-management/grooming/readme.md) at least once per week. It is a great opportunity to:

1. Keep the backlog clean
1. Re-prioritize work based on shifting business priorities
1. Fill in missing descriptions and acceptance criteria
1. Identify stories that require design reviews

The team can follow the same steps from [sprint planning](#sprint-planning) to help identify which stories require design reviews. This can often save much time during the actual sprint planning meetings to focus on the task at hand.

## Sprint Retrospectives

[Sprint retrospectives](../../agile-development/retrospectives/readme.md) are a great time to check-in with the dev team, identify what is working or not working, and propose changes to keep improving.

It is also a great time to check-in on design reviews

- Did any of the designs change from last sprint?
- How have  design changes impacted the engagement?
- Have previous design artifacts been updated to reflect new changes?

All design artifacts should be treated as a living document.  As requirements change or uncover more unknowns the dev crew should be retractively updating all design artifacts. Missing this critical step may cause the customer to incur future technical debt. Artifacts that are not up to date are basically `bugs` in the design.

> **Tip:** Keep your artifacts up to date by adding it to your teams [Definition of Done](../../agile-development/team-agreements/definition-of-done/readme.md) for all user stories.

## Wrap-up Sprints

Wrap-up sprints are a great time to tie up loose ends with the customer and hand-off solution.  Customer hand-off becomes a lot easier when there are design artifacts to reference and deliver along side the completed solution.  

During your wrap-up sprints thee dev crew should consider the following:

1. Are the design artifacts up to date?
1. Are the design artifacts stored in an accessible location?