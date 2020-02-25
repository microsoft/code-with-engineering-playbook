# Milestone / Epic Design Review Recipe

## Things to keep in mind

* As with all other aspects of the project, design reviews must provide a friendly and safe environment so that any team member feels comfortable proposing a design for review and can use the opportunity to grow and learn from the constructive / non-judgemental feedback from peers and subject matter experts (see [Team Agreements](../../team-agreements)).
* Design reviews should be lightweight and should not feel like an additional process overhead.
* Tech Lead can usually provide guidance on whether a given epic/milestone needs a design review and can help other team members in preparation.
* This is *not* a strict template that must be followed and teams should not be bogged down with polished "design presentations".
* Think of the recipe below as a "menu of options" for potential questions to think through in designing this epic. Not all sections are required for every epic. Focus on sections and questions that are most relevant for making the decision and rationalizing the trade offs.
* Milestone/epic design is considered high-level design but is usually more detailed than the design included in the Game Plan, but will likely re-use some of the technologies, non-functional requirements, and constraints mentioned in the Game Plane.
* As the team learned more about the project and further refined the scope of the epic, they may specifically call out notable changes to the overall approach and, in particular, highlight any unique deployment, security, private, scalability, etc. characteristics of this milestone.

***

# [Design Title]

* Milestone / Epic: [Name](http://link-to-work-item)
* Project / Engagement: [Project Engagement]
* Authors: [Authors]

## Overview / Problem Statement

> Describe the milestone/epic with a high-level summary and a problem statement. Consider including or linking to any additional background (e.g. Game Plan or Checkpoint docs) if it is useful for historical context.

## Goals / In-Scope

> List bullet points of goals that the milestone/epic will help achieve. Include acceptable criteria required to meet the [Definition of Done](../../team-agreements/definition-of-done/).

## Non-goals / Out-of-Scope

> List bullet points of non-goals for this milestone/epic to clarify the work that is beyond the scope of this milestone/epic.

## Proposed Design / Suggested Approach

* Describe the proposed design / suggested approach for this milestone/epic.
* List some of the alternative approaches that were considered.
* Include relevant diagrams (e.g. architecture, sequence, component, deployment, etc.) and code/pseudo-code snippets to make it easier to talk through the approaches.
* Whenever possible, for each of the approaches, include the brief key **Pros and Cons** used to help rationalize the decision. For example:

| Pros                             | Cons                                  |
| -------------------------------- | ------------------------------------- |
| Simple to implement              | Creates secondary identity system     |
| Repeatable pattern/code artifact | Deployment requires admin credentials |
|                                  |                                       |

## Technology

> Describe the languages(s) and platform(s) that comprise the stack. This may include anything that is needed to understand the overall solution: OS, web server, presentation layer, persistence layer, caching, eventing, etc.

## Operationalization

* How is CI/CD setup for the milestone epic?
* How is the application/service/feature deployed to various environments in a consistent and predictable way?
* Is there a process (manual or automated) to promote builds from lower environments to higher ones?
* Is it possible to add "blue-green" deployment or otherwise achieve near zero-downtime?
* Are there mechanisms in place to rollback a deployment?

## Security & Privacy

* What security and privacy concerns does this milestone/epic have?
* Is all sensitive information and secrets treated in a safe and secure manner?

## Performance, Scalability, and Costs

* What are the primary performance and scalability concerns for this milestone/epic?
* Are there specific bottlenecks or potential problem areas?
* Are operations CPU or I/O (network, disk) bound?
* How large are the data sets and how fast do they grow?
* Are operations expected to be long-running (e.g. copying large mount of files)?
* What is the expected usage pattern of the service?
* Will there be peaks and valleys of intense concurrent usage?

## Open Questions

> Include any open questions and concerns.

## Additional References

> Include any additional references including links to work items or other documents.
