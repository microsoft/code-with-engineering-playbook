# Design Reviews

## Table of Contents

- [Goals](#goals)
- [Measures](#measures)
- [Impact](#impact)
- [Participation](#participation)
- [Facilitation Guidance](#facilitation-guidance)
- [Design Review Recipes](#design-review-recipes)
- [Technical Spike](#technical-spike)

## Goals

- Reduce technical debt for our customers
- Continue to iterate on design after Game Plan review
- Generate useful technical artifacts that can be referenced by Microsoft and customers

## Measures

### Cost of Change

When incorporating design reviews as part of the engineering process, decisions are front-loaded before implementation begins. Making a decision of using Azure Kubernetes Service instead of App Services at the design phase likely only requires updating documentation. However, making this pivot after implementation has started or after a solution is in use is much more costly.

Are these changes occurring before or after implementation? How large of effort are they typically?

### Reviewer Participation

How many different individuals participate across the designs created? Cumulatively if this is a larger number this would indicate a wider contribution of ideas and perspectives. A lower number (i.e. same 2 individuals only on every review) might indicate a limited set of perspectives. Is there anyone participating from outside the core development team?

### Time To Potential Solutions

How long does it typically take to go from requirements to solution options (multiple)?

There is a healthy balancing act between spending too much or too little time evaluating different potential solutions. Too little time puts higher risk of costly changes required after implementation. Too much time delays target value from being delivered; as well as subsequent features in queue. However, the faster the team can *identify the most critical information necessary to make an informed decision*, the faster value can be provided with lower risk of costly changes down the road.

### Time to Decisions

How long does it take to make a decision on which solution to implement?

There is also a healthy balancing act in supporting a healthy debate while not hindering the team's delivery. The ideal case is for a team to quickly digest the solution options presented, ask questions, and debate before finally reaching quorum on a particular approach. In cases where no quorum can be reached, the person with the most context on the problem (typically story owner) should make the final decision. Prioritize delivering value and learning. Disagree and commit!

## Impact

- Solutions can be quickly operationalized into customer's production environment
- Easier for other dev crews to leverage your teams work
- Easier for engineers to ramp up on projects
- Increase team velocity by front-loading changes and decisions when they cost the least
- Increased team engagement and transparency by soliciting wide reviewer participation

## Participation

### Dev Crew

The dev crew should always participate in all design review sessions

- [CSE](../CSE.md) Engineering
- Customer Engineering

### Domain Experts

Domain experts should participate in design review sessions as needed

- CSE Tech Domain
- Customer Subject Matter Experts (SME)
- Senior Leadership

## Facilitation Guidance

### Sync Design Reviews via in-person / virtual meetings

Joint meetings with dev crew, subject matter experts (SMEs) and customer engineers

### Async Design Reviews via Pull-Requests

See the [async design review recipe](./recipes/async-design-reviews.md) for guidance on facilitating async design reviews. This can be useful for teams that are geographically distributed across different time-zones.

## Design Review Recipes

Design reviews come in all shapes and sizes. There are also different items to consider when creating a design at different stages during an engagement

### Design Review Process

- [Incorporate design reviews throughout the lifetime of an engagement](./recipes/engagement-process.md)

### Design Review Templates

#### [Game Plan](./recipes/high-level-design-recipe.md)

- The same template already in use today
- High level architecture and design
- Includes technologies, languages & products to complete engagement objective

#### [Milestone / Epic Design Review](./recipes/milestone-epic-design-review-recipe.md)

- Should be considered when an engagement contains multiple milestones or epics
- Design should be more detailed than game plan
- May require unique deployment, security and/or privacy characteristics from other milestones

#### [Feature/story design review](./recipes/feature-story-design-review-template.md)

- Design for complex features or stories
- Will reuse deployment, security and other characteristics defined within game plan or milestone
- May require new libraries, OSS or patterns to accomplish goals

#### [Task design review](./recipes/task-design-review-template.md)

- Highly detailed design for a complex tasks with many unknowns
- Will integrate into higher level feature/component designs

## Technical Spike

A technical spike is most often used for evaluating the impact new technology has on the current implementation. Please read more [here](./recipes/technical-spike.md).

## Design Documentation

- Document and update the architecture design in the project design documentation
- Track and document design decisions in a [decision log](./decision-log/readme.md)
- Document decision process in [trade studies](./trade-studies/readme.md) when multiple solutions exist for the given problem
