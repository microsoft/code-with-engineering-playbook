# Design Reviews

## Table of Contents

- [Goals](#goals)
- [Impact](#impact)
- [Participation](#participation)
- [Facilitation Guidance](#facilitation-guidance)
- [Design Review Recipes](#design-review-recipes)

## Goals

- Reduce technical debt for our customers
- Continue to iterate on design after Game Plan review
- Generate useful technical artifacts that can be referenced by Microsoft and customers

## Impact

- Solutions can be quickly operationalized into customer's production environment
- Easier for other dev crews to leverage your teams work
- Easier for engineers to ramp up on projects

## Participation

### Dev Crew

The dev crew should always participate in all design review sessions

- CSE Engineering
- Customer Engineering

### Domain Experts

Domain experts should participate in design review sessions as needed

- CSE Tech Domain
- Customer Subject Matter Experts (SME's)
- Senior Leadership

## Facilitation Guidance

### Sync Design Reviews via in-person / virtual meetings

Joint meetings with dev crew, subject matter experts (SME's) and customer engineers

### Async Design Reviews via Pull-Requests

See the [async design review recipe](./recipes/async-design-reviews.md) for guidance on facilitating async design reviews. This can be useful for teams that are geographically distributed across different time-zones.

## Design Review Recipes

Design reviews come in all shapes and sizes. There are also different items to consider when creating a design at different stages during an engagement

### Design Review Process

- [Incorporate design reviews throughout the lifetime of an engagement](./recipes/engagement-process.md)

### Design Review Templates

#### Game Plan

- The same template already in use today
- High level architecture and design
- Includes technologies, languages & products to complete engagement objective

#### [Milestone / Epic Design Review](./recipes/milestone-epic-design-review-recipe.md)

- Should be considered when an engagement contains multiple milestones or epics
- Design should be more detailed than game plan
- May require unique deployment, security and/or privacy characteristics from other milestones

#### Feature/story design review

- Design design for complex features or stories
- Will reuse deployment, security and other characteristics defined within game plan or milestone
- May require new libraries, OSS or patterns to accomplish goals

#### [Task design review](./recipes/task-design-review-template.md)

- Highly detailed design for a complex tasks with many unknowns
- Will integrate into higher level feature/component designs
