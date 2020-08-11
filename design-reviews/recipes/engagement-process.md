# Incorporating Design Reviews into an Engagement

## Introduction

Design reviews should not feel like a burden.  Design reviews can be easily incorporated into your dev crew process with minimal overhead.  

- Only create design reviews when needed.  Not every story or task requires a full blown design review
- Leverage this guidance and make changes to fit in best with your team.  Every team works a bit differently and has different tweaks that work best for them.
- Leverage subject matter experts (SME) as needed during design reviews. Not every story needs SME or leadership sign-off.  Most design reviews can be fully executed within your own dev crew.

The following is are some guidelines on how you and your team can start incorporating design reviews into your normal day to day agile process.

## Table of Contents

- [Envisioning / Architecture Design Session (ADS)](#envisioning--architecture-design-session-ads)
- [Game Plan](#game-plan)
- [Checkpoint Reviews](#checkpoint-reviews)
- [Sprint Planning](#sprint-planning)
- [Sprint Backlog Grooming](#sprint-backlog-grooming)
- [Sprint Retrospectives](#sprint-retrospectives)
- [Wrap-up Sprints](#wrap-up-sprints)

## Envisioning / Architecture Design Session (ADS)

Early on within an engagement process we are working with customers to understand their unique goals and objectives.  We are defining requirements to understand definition of done.  We are diving deep into their existing infrastructure and architecture to understand constraints.

During this time we are uncovering as many unknowns as possible to help us jointly generate a design to meet the customers goals.  We are leveraging all the new found information and incorporating it into our game plan design for the customer engagement.

> **Tip**: We have not uncovered all the unknowns at this point. You will continue to learn and discover more during the lifetime of your engagement

## Game Plan

The [game plan document](https://aka.ms/GamePlanTemplate) is our guiding star throughout the engagement.  The game plan document should include the following sections and answer the following questions.

### Deliverable

1. What are we delivering?
1. What does success look like?
1. What is the definition of done?
1. What security, privacy and/or performance requirements are required?

### Design

1. What does the high level architecture look like?
1. What does the technology stack look like?
1. How does this solution fit into the customers overall product / service?

### Process

1. How will engineering fundamentals be leveraged during the project?
1. What is the proposed sprint schedule?  How many sprints?
1. Who is the team? CSE engineers? Customer Engineers?
1. What is the sharing plan after the engagement is complete?

### Ready to start

1. Has the customer signed off on the plan?
1. Are there any blocking issues to starting the engagement?
1. What are the known risks?

> **Tip**: Keep your game plan up to date as your design changes over time

## Checkpoint Reviews

Our monthly checkpoints are a great way for the team to check-in with leadership and other CSE SME's and provide a status update to the larger team.

Some key items to discuss:

### Design Reviews

1. Present any key design reviews created since the last checkpoint or game plan
1. Present any new design artifacts including API contracts, architecture diagrams, workflows, deployment pipelines, etc.
1. Describe if there are any high level architecture or design changes since last review
1. How have your design changes impacted the initial game plan

## Sprint Planning

In many of our engagements we will be working with our customers using a SCRUM agile development process.  [Sprint planning](../../agile-development/sprint-planning/readme.md) is a great opportunity to dive deep into the next set of high priority work.  Some key points to address are the following:

1. Identify stories that require design reviews
1. Breakout design from implementation for complex stories
1. Assign owners to each design story

Stories that will benefit from design reviews have one or more of the following in common:

1. Are there many unknowns or unclear requirements
1. There is wide distribution in story point costing amongst your dev crew
1. You cannot clearly illustrate all the tasks required for a story

> **Tip:** After your sprint planning is complete your team should consider hosting an initial design review discussion to dive deep on the design requirement of the stories that were identified.  After you have more clarity the team should continue forward with either a sync or async design review to complete the tasks.

## Sprint Backlog Grooming

If you team is not already hosting a [Sprint Backlog Grooming](../../agile-development/backlog-management/grooming/readme.md) session at least once per week you should consider it.  It is a great opportunity to:

1. Keep your backlog clean
1. Re-prioritize work bash on shifting business priorities
1. Fill in missing descriptions / acceptance criteria
1. Identify stories that require design reviews

The team can follow the same steps from [sprint planning](#sprint-planning) to help identify which stories require design reviews.  This can often save much time during your actual sprint planning meetings to focus on the task at hand.

## Sprint Retrospectives

[Sprint retrospectives](../../agile-development/retrospectives/readme.md) are a great time to check-in with your dev team to identify what is working or not working within your group and propose changes to keep improving.

It is also a great time to check-in on your design reviews

- Did any of your designs change from last sprint?
- How have your design changes impacted your engagement?
- Have previous design artifacts been updated to reflect new changes?

All design artifacts including the game plan should be treated as a living document.  As requirements change or you uncover more unknowns the dev crew should be going back and updating all your design artifacts to reflect reality.  If this step is missed you are making a critical mistake which could lead to the customer incurring more technical debt in the future. Artifacts that are not up to date are basically `bugs` in your design.

> **Tip:** Keep your artifacts up to date by adding it to your teams [Definition of Done](../../agile-development/team-agreements/definition-of-done/readme.md) for all user stories.

## Wrap-up Sprints

Wrap-up sprints are a great time to tie up loose ends with your customer, hand-off your solution and execute your sharing requirements from the game plan.  Customer hand-off becomes a lot easier when you have design artifacts to reference and deliver along side your completed solution.  

During your wrap-up sprints your dev crew should consider the following:

1. Are your design artifacts up to date?
1. Are your design artifacts stored in an accessible location?
1. How can other CSE dev crews leverage the work from your engagement?
1. Submit new engineering patterns and practices back to the [CSE playbook](https://aka.ms/cseplaybook)

It is critical that your design artifacts are in an accessible location that can be shared by other CSE dev crews.  [CSE artifact hub](https://aka.ms/cseartifacthub) is a great place to store and share your artifacts so that other teams can quickly find them.

> **Tip:** Now is also a great time to schedule a brown bag meeting to review your engagement and showcase your key designs that were created by the team.
