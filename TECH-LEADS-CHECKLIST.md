# Tech Lead's Engineering Fundamentals Checklist

This checklist helps to ensure that our projects meet our Engineering Fundamentals.

## Source Control

- [ ] The master branch is locked.
- [ ] Merges are done through PRs.
- [ ] PRs reference related work items.
- [ ] Commit history is consistent and commit messages are informative (what, why).
- [ ] Secrets are not part of the commit history or made public. (see [Credential scanning](./continuous-integration/credential-scanning/README.md))
- [ ] Public repositories follow the [OSS guidelines](source-control/git.md), see `Required files for public repositories`.

More details on [Source Control](source-control/readme.md)

## Work Item Tracking

- [ ] All items are tracked in AzDevOps (or similar).
- [ ] The board is organized (swim lanes, feature tags, technology tags).

## Testing

- [ ] Unit tests cover the majority of all components (>90% if possible).
- [ ] Integration tests run to test the solution e2e.

More details on [Unit Testing](test-first-development/unit-testing/readme.md)

## CI/CD

- [ ] Project runs CI with automated build and test on each PR.
- [ ] Project uses CD to manage deployments to a replica environment before PRs are merged to master.
- [ ] Master is always shippable.

## Security - TO DO

- [ ] Access control.
- [ ] Separation of concerns.
- [ ] Robust treatment of secrets.
- [ ] Encryption for data in transit (and if necessary at rest) and password hashing.

## Observability

- [ ] Application faults and errors are logged.
- [ ] Metrics collected to identify health of the services.
- [ ] Latency for servicing a request is logged, as appropriate for the solution.
- [ ] Significant business and functional events that are important are tracked and related metrics collected.
- [ ] Logging configuration can be modified without code changes (eg: debug mode).
- [ ] GDPR compliance is ensured regarding PII (personal identifiable information).

## Agile/Scrum

- [ ] Scrum Master (fixed/rotating) to run standup daily.
- [ ] Agile process clearly defined within team.
- [ ] Tech Lead (+ PO/Others) have responsibility for backlog management and grooming.
- [ ] Working agreement between members of team and customer.

## Design Reviews

- [ ] Process for conducting design reviews.
- [ ] Including design review process in the [Working Agreement](/team-agreements/working-agreements/readme.md)
- [ ] Design reviews for each major component of the solution.
- [ ] Document major design decisions and alternatives.
- [ ] Stories and/or PRs link to the design document.
- [ ] Each user story includes a task for design review by default, which is assigned or removed during sprint planning.
- [ ] Project advisors are invited to design reviews or asked to give feedback to the design decisions captured in documentation.
- [ ] Discover all the reviews that the customer's processes require and plan for them.

## Code Reviews

- [ ] Clear agreement in the team as to function of code reviews.
- [ ] Code review checklist or established process.
- [ ] A minimum number of reviewers for a PR merge is enforced (2 usually).
- [ ] Linters, unit tests and successful builds for PR merges.
- [ ] Bug fixes suggest how to catch the bug in a code review within associated work item. And if possible link to original PR that introduced bug.

More details on [Code Reviews](pull-requests/code-reviews/readme.md)

## Retrospectives

- [ ] Set time for retrospectives each week/at the end of each sprint.
- [ ] 1-3 proposed experiments to be tried each week/sprint to improve the process.
- [ ] Experiments have owners and are added to project backlog.
- [ ] Longer retrospective for Milestones and project completion.

More details on [Retrospectives](retrospectives/readme.md)
