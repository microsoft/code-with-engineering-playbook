# Your Feature or Story Design Title Here

> Does the feature re-use or extend existing patterns / interfaces that have already been established for the project?
> Does the feature expose new patterns or interfaces that will establish a new standard for new future development?

* [Feature/Story Name](http://link-to-feature-or-story-work-item)
* Engagement: [Engagement]
* Customer: [Customer]
* Authors: [Author1, Author2, etc.]

## Overview/Problem Statement

* Describe the feature/story with a high-level summary.
* Consider additional background and justification, for posterity and historical context.

## Goals/In-Scope

* List the goals that the feature/story will help us achieve.  
* This should include acceptance criteria required to meet [definition of done](../../team-agreements/definition-of-done/).

## Non-goals / Out-of-Scope

* List the non-goals for the feature/story.
* This contains work that is beyond the scope of what the feature/component/service is intended for.

## Proposed Design

* Briefly describe the high-level architecture for the feature/story.
* Relevant diagrams (e.g. sequence, component, context, deployment) should be included here.

## Technology Choices

* Describe the relevant OS, Web server, presentation layer, persistence layer, caching, eventing/messaging/jobs, etc. – whatever is applicable to the overall technology solution.
* Describe the usage of any libraries of OSS components.

## Security & Privacy

* What security and privacy concerns does this feature/story have?
* Privacy and security are paramount to our customers.
* To this end, we need to do our utmost to ensure that any PII/HBI, sensitive information and secrets are treated in a safe and secure manner.

## Performance & Scalability

* Identify any performance or scalability concerns for your feature/story and provide possible mitigation.
* When considering performance/scale, start by answering the following questions:
  * What are the bottlenecks or potential problem areas of the service?
  * Fundamentally, this is identifying the unit(s) of work that the service performs.
    * Are these operation(s) CPU bound?  I/O bound?
    * Are these operation(s) expected to be long-running (i.e. copying large amounts of files)?
  * Along with identifying areas that may have scale concerns, it's important to understand the expected usage pattern) of the service.
  * Will there be peaks and valleys of intense, concurrent usage?  
* This information is typically derived from product and customer scenarios/requirements.

## Open Questions

> List any open questions/concerns here.

## Additional References

> List any additional references here including links to backlog items, work items or other documents.
