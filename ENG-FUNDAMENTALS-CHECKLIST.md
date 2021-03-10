# Engineering Fundamentals Checklist

This checklist helps to ensure that our projects meet our Engineering Fundamentals.

## Source Control

- [ ] The default target branch is locked.
- [ ] Merges are done through PRs.
- [ ] PRs reference related work items.
- [ ] Commit history is consistent and commit messages are informative (what, why).
- [ ] Consistent branch naming conventions.
- [ ] Clear documentation of repository structure.
- [ ] Secrets are not part of the commit history or made public. (see [Credential scanning](continuous-integration/credential-scanning/readme.md))
- [ ] Public repositories follow the [OSS guidelines](source-control/readme.md#creating-a-new-repository), see `Required files in default branch for public repositories`.

More details on [source control](source-control/readme.md)

## Work Item Tracking

- [ ] All items are tracked in AzDevOps (or similar).
- [ ] The board is organized (swim lanes, feature tags, technology tags).

More details on [backlog management](agile-development/backlog-management/readme.md)

## Testing

- [ ] Unit tests cover the majority of all components (>90% if possible).
- [ ] Integration tests run to test the solution e2e.

More details on [automated testing](automated-testing/readme.md)

## CI/CD

- [ ] Project runs CI with automated build and test on each PR.
- [ ] Project uses CD to manage deployments to a replica environment before PRs are merged.
- [ ] Main branch is always shippable.

More details on [continuous integration](continuous-integration/readme.md) and [continuous delivery](continuous-delivery/readme.md)

## Security

- [ ] Access is only granted on an as needed bases
- [ ] Secrets are stored in secured locations and not checked in to code
- [ ] Data is encrypted in transit (and if necessary at rest) and passwords are hashed
- [ ] Is the system split into logical segments with separation of concerns? This helps limiting security vulnerabilities.

More details on [security](security/README.md)

## Observability

- [ ] Significant business and functional events are tracked and related metrics collected.
- [ ] Application faults and errors are logged.
- [ ] Health of the system is monitored.
- [ ] The client and server side observability data can be differentiated.
- [ ] Logging configuration can be modified without code changes (eg: verbose mode).
- [ ] [Incoming tracing context](observability/correlation-id.md) is propagated to allow for production issue debugging purposes.
- [ ] GDPR compliance is ensured regarding PII (Personally Identifiable Information).

More details on [observability](observability/readme.md)

## Agile/Scrum

- [ ] Process Lead (fixed/rotating) runs the daily standup
- [ ] The agile process is clearly defined within team.
- [ ] The Dev Lead (+ PO/Others) are responsible for backlog management and refinement.
- [ ] A working agreement is established between team members and customer.

More details on [agile development](agile-development/README.md)

## Design Reviews

- [ ] Process for conducting design reviews is included in the [Working Agreement](agile-development/team-agreements/working-agreements/readme.md).
- [ ] Design reviews for each major component of the solution are carried out and documented, including alternatives.
- [ ] Stories and/or PRs link to the design document.
- [ ] Each user story includes a task for design review by default, which is assigned or removed during sprint planning.
- [ ] Project advisors are invited to design reviews or asked to give feedback to the design decisions captured in documentation.
- [ ] Discover all the reviews that the customer's processes require and plan for them.

More details on [design reviews](design-reviews/readme.md)

## Code Reviews

- [ ] There is a clear agreement in the team as to function of code reviews.
- [ ] The team has a code review checklist or established process.
- [ ] A minimum number of reviewers (usually 2) for a PR merge is enforced by policy.
- [ ] Linters/Code Analyzers, unit tests and successful builds for PR merges are set up.
- [ ] There is a process to enforce a quick review turnaround.

More details on [code reviews](code-reviews/README.md)

## Retrospectives

- [ ] Retrospectives are conducted each week/at the end of each sprint.
- [ ] The team identifies 1-3 proposed experiments to try each week/sprint to improve the process.
- [ ] Experiments have owners and are added to project backlog.
- [ ] The team conducts longer retrospective for Milestones and project completion.

More details on [retrospectives](agile-development/retrospectives/readme.md)

## Engineering Feedback

- [ ] The team submits feedback on business and technical blockers that prevent project success
- [ ] Suggestions for improvements are incorporated in the solution
- [ ] Feedback is detailed and repeatable

More details on [engineering feedback](engineering-feedback/readme.md)

## Developer Experience (DevEx)

Developers on the team can:

- [ ] Build/Compile source to verify it is free of syntax errors and compiles.
- [ ] Execute all automated tests (unit, e2e, etc).
- [ ] Start/Launch end-to-end to simulate execution in a deployed environment.
- [ ] Attach a debugger to started solution or running automated tests, set breakpoints, step through code, and inspect variables.
- [ ] Automatically install dependencies by pressing F5 (or equivalent) in their IDE.
- [ ] Use local dev configuration values (i.e. .env, appsettings.development.json).

More details on [developer experience](developer-experience/readme.md)
