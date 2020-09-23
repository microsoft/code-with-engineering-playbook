# Your Milestone/Epic Design Title Here (prefix with DRAFT/WIP to indicate level of completeness)

> Please refer to <https://github.com/microsoft/code-with-engineering-playbook/blob/master/design-reviews/recipes/milestone-epic-design-review-recipe.md> for things to keep in mind when using this template.

* Milestone / Epic: [Name](http://link-to-work-item)
* Project / Engagement: [Project Engagement]
* Authors: [Author1, Author2, etc.]

## Overview / Problem Statement

> Describe the milestone/epic with a high-level summary and a problem statement. Consider including or linking to any additional background (e.g. Game Plan or Checkpoint docs) if it is useful for historical context.

## Goals / In-Scope

> List a few bullet points of goals that this milestone/epic will achieve and that are most relevant for the design review discussion. You may include acceptable criteria required to meet the [Definition of Done](../../agile-development/team-agreements/definition-of-done/).

## Non-goals / Out-of-Scope

> List a few bullet points of non-goals to clarify the work that is beyond the scope of the design review for this milestone/epic.

## Proposed Design / Suggested Approach

> To optimize the time investment, this should be brief since it is likely that details will change as the epic/milestone is further decomposed into features and stories. The goal being to convey the vision and complexity in something that can be understood in a few minutes and can help guide a discussion (either asynchronously via comments or in a meeting).

* A paragraph to describe the proposed design / suggested approach for this milestone/epic.
* A diagram (e.g. architecture, sequence, component, deployment, etc.) or pseudo-code snippet to make it easier to talk through the approach.
* List a few of the alternative approaches that were considered and include the brief key **Pros and Cons** used to help rationalize the decision. For example:

| Pros                             | Cons                                  |
| -------------------------------- | ------------------------------------- |
| Simple to implement              | Creates secondary identity system     |
| Repeatable pattern/code artifact | Deployment requires admin credentials |
|                                  |                                       |

## Technology

> Briefly list the languages(s) and platform(s) that comprise the stack. This may include anything that is needed to understand the overall solution: OS, web server, presentation layer, persistence layer, caching, eventing, etc.

## Non-Functional Requirements

* What are the primary performance and scalability concerns for this milestone/epic?
* Are there specific latency, availability, and RTO/RPO objectives that must be met?
* Are there specific bottlenecks or potential problem areas? For example, are operations CPU or I/O (network, disk) bound?
* How large are the data sets and how fast do they grow?
* What is the expected usage pattern of the service? For example, will there be peaks and valleys of intense concurrent usage?
* Are there specific cost constraints? (e.g. $ per transaction/device/user)

## Operationalization

* Are there any specific considerations for the CI/CD setup of milestone/epic?
* Is there a process (manual or automated) to promote builds from lower environments to higher ones?
* Does this milestone/epic require zero-downtime deployments, and if so, how are they achieved?
* Are there mechanisms in place to rollback a deployment?
* What is the process for monitoring the functionality provided by this milestone/epic?

## Dependencies

* Does this milestone/epic need to be sequenced after another epic assigned to the same team and why?
* Is the milestone/epic dependent on another team completing other work?
* Will the team need to wait for that work to be completed or could the work proceed in parallel?

## Risks & Mitigations

* Does the team need assistance from subject matter experts?
* What security and privacy concerns does this milestone/epic have?
* Is all sensitive information and secrets treated in a safe and secure manner?

## Open Questions

> Include any open questions and concerns.

## Additional References

> Include any additional references including links to work items or other documents.
