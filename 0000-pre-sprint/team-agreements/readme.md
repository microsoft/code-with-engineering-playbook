# Tech Lead's Engineering Fundamentals Checklist

This checklist helps to ensure that our projects meet our Engineering Fundamentals. 

## Source Control
- [ ] The master branch is locked.
- [ ] Merges are done through PRs.
- [ ] PRs reference related work items. 
- [ ] Commit history is consistent and commit messages are informative (what, why).
- [ ] Secrets are not part of the commit history or made public. 
- [ ] Public repositories follow the [OSS guidelines](../../0000-pre-sprint/source-control-repositories/recipes/git.md#Required files in default branch for public repositories).

More details on [Source Control](../source-control-repositories/readme.md)

## Work Item Tracking
- [ ] All items are tracked in AzDevOps (or similar).
- [ ] The board is organized (swim lanes, feature tags, technology tags).

## Testing
- [ ] Unit tests cover the majority of all components (>90% if possible). 
- [ ] Integration tests run to test the solution e2e. 

More details on [Unit Testing](../../0010-day-one/test-first-development/unit-testing/readme.md)

## CI/CD
- [ ] Project runs CI with automated build and test on each PR. 
- [ ] Project uses CD to manage deployments to a replica environment before PRs are merged to master.
- [ ] Master is always shippable. 

## Security - TO DO! 
- [ ] Robust treatment of secrets. 
- [ ]  
- [ ] 

## Observability - TO DO! 
- [ ] Solution faults and errors are logged. 
- [ ] Additional information and metrics collected depending on use case. 
- [ ] Metrics collected to identify health of the services. 
- [ ] Logging configuration can be modified without code changes (eg: debug mode).
- [ ] GDPR compliance is ensured regarding PII (personal identifiable information). 

## Agile/Scrum
- [ ] Scrum Master (fixed/rotating) to run standup daily.
- [ ] Agile process clearly defined within team.
- [ ] Tech Lead (+ PO/Others) have responsability for backlog management and grooming.
- [ ] Working agreement between members of team and customer.

## Design Reviews
- [ ] Process for conducting design reviews.
- [ ] Design reviews for each major component of the solution.
- [ ] Document major design decisions and alternatives. 
- [ ] Stories and/or PRs link to the design document

## Code Reviews
- [ ] Clear agreement in the team as to function of code reviews. 
- [ ] Code review checklist or established process.
- [ ] A minimum number of reviewers for a PR merge is enforced (2 usually).
- [ ] Linters, unit tests and successful builds for PR merges. 
- [ ] Bug fixes suggest how to catch the bug in a code review within associated work item. And if possible link to original PR that introduced bug. 

More details on [Code Reviews](../../0030-day-three/pull-requests/code-reviews/readme.md)

## Retrospectives
- [ ] Set time for retrospectives each week/at the end of each sprint. 
- [ ] 1-3 proposed experiments to be tried each week/sprint to improve the process. 
- [ ] Experiments have owners and are added to project backlog. 
- [ ] Longer retrospective for Milestones and project completion. 

More details on [Retrospectives](../../0050-day-five/retrospectives/readme.md)