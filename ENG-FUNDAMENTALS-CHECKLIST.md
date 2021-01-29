# Engineering Fundamentals Checklist

This checklist helps to ensure that our projects meet our Engineering Fundamentals.

## Source Control

- [ ] The main branch is locked.
- [ ] Merges are done through PRs.
- [ ] PRs reference related work items.
- [ ] Commit history is consistent and commit messages are informative (what, why).
- [ ] Secrets are not part of the commit history or made public. (see [Credential scanning](continuous-integration/credential-scanning/readme.md))
- [ ] Public repositories follow the [OSS guidelines](source-control/readme.md#creating-a-new-repository), see `Required files in default branch for public repositories`.

More details on [Source Control](source-control/readme.md)

## Work Item Tracking

- [ ] All items are tracked in AzDevOps (or similar).
- [ ] The board is organized (swim lanes, feature tags, technology tags).

## Testing

- [ ] Unit tests cover the majority of all components (>90% if possible).
- [ ] Integration tests run to test the solution e2e.

More details on [Unit Testing](automated-testing/unit-testing/readme.md)
More details on [Integration Testing](automated-testing/integration-testing/readme.md)

## CI/CD

- [ ] Project runs CI with automated build and test on each PR.
- [ ] Project uses CD to manage deployments to a replica environment before PRs are merged.
- [ ] Main branch is always shippable.

## Security - TO DO

- [ ] Access control.
- [ ] Separation of concerns.
- [ ] Robust treatment of secrets.
- [ ] Encryption for data in transit (and if necessary at rest) and password hashing.

## Observability

- [ ] Significant business and functional events are tracked and related metrics collected.
- [ ] Application faults and errors are logged.
- [ ] Health of the system is monitored.
- [ ] The client and server side observability data can be differentiated.
- [ ] Logging configuration can be modified without code changes (eg: verbose mode).
- [ ] [Incoming tracing context](observability/correlation-id.md) is propagated to allow for production issue debugging purposes.
- [ ] GDPR compliance is ensured regarding PII (Personally Identifiable Information).

## Agile/Scrum

- [ ] Process Lead (fixed/rotating) to run standup daily.
- [ ] Agile process clearly defined within team.
- [ ] Dev Lead (+ PO/Others) have responsibility for backlog management and refinement.
- [ ] Working agreement between members of team and customer.

## Design Reviews

- [ ] Process for conducting design reviews is included in the [Working Agreement](agile-development/team-agreements/working-agreements/readme.md).
- [ ] Design reviews for each major component of the solution are carried out and documented, including alternatives.
- [ ] Stories and/or PRs link to the design document.
- [ ] Each user story includes a task for design review by default, which is assigned or removed during sprint planning.
- [ ] Project advisors are invited to design reviews or asked to give feedback to the design decisions captured in documentation.
- [ ] Discover all the reviews that the customer's processes require and plan for them.

More details on [Design Reviews](design-reviews/readme.md)

## Code Reviews

- [ ] Clear agreement in the team as to function of code reviews.
- [ ] Code review checklist or established process.
- [ ] A minimum number of reviewers (usually 2) for a PR merge is enforced by policy.
- [ ] Linters/Code Analyzers, unit tests and successful builds for PR merges are set up.
- [ ] Process to enforce a quick review turnaround.

More details on [Code Reviews](code-reviews/README.md)

## Retrospectives

- [ ] Set time for retrospectives each week/at the end of each sprint.
- [ ] 1-3 proposed experiments to be tried each week/sprint to improve the process.
- [ ] Experiments have owners and are added to project backlog.
- [ ] Longer retrospective for Milestones and project completion.

More details on [Retrospectives](agile-development/retrospectives/readme.md)

## Engineering Feedback

- [ ] Submit business and technical blockers that prevent project success
- [ ] Add suggestions for improvements to leveraged services and components
- [ ] Ensure feedback is detailed and repeatable

More details on [Engineering Feedback](engineering-feedback/readme.md)
