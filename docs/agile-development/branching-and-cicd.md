# Branching & CI/CD Guidance

Purpose: Provide a concise, practical policy and examples teams can adopt for integration, branching and CI gating. This page is intentionally short — teams should adapt the policy to their project and toolchain.

## Recommended approach

- Prefer trunk-based development where possible for new projects. Use short-lived feature branches when necessary and merge frequently into the default integration branch (commonly `main` or `trunk`). The [source control git guidance](../source-control/git-guidance/README.md#branching) owns the canonical feature-branch workflow.
- Use branch protection rules on the integration branch to enforce quality gates (required passing CI, required code reviews, status checks). The [pull request guidance](../code-reviews/pull-requests.md) owns the canonical pull request and merge policy.
- Keep releases simple: use tags/releases from the integration branch and keep release process documented separately.

## Branch protection and merge policy

Enforce the merge gate through branch protection rules rather than restating it here. The [pull request guidance](../code-reviews/pull-requests.md) and [code review evidence and measures](../code-reviews/evidence-and-measures/README.md) own the canonical policy: changes to the integration branch flow through a pull request that requires at least one approving reviewer, passing CI status checks, a linked work item, and updated documentation.

## Sample minimal GitHub Actions CI gate (example)

```yaml
name: ci
on: [pull_request]
jobs:
  build-and-test:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      - name: Set up Node.js
        uses: actions/setup-node@v3
        with:
          node-version: '18'
      - name: Install
        run: npm ci
      - name: Run tests
        run: npm test
```

## Tips

- Keep feature branches short-lived; frequent merges reduce integration risk.
- Automate as much of the gate (linting, unit tests, basic security scans) as possible to keep manual review focused on design and architecture.
- Adapt branch protection to match team size and delivery cadence.

## CI/CD guidance

This page complements the central [CI/CD guidance](../CI-CD/README.md). For the shared expectations — quality pipeline on every PR, infrastructure-as-code provisioning, automated deployment to non-production, and repeatable release and rollback — follow the [CI/CD fundamentals](../CI-CD/README.md#the-fundamentals).

One branching-specific expectation reinforces those fundamentals: the integration (main) branch should stay continuously shippable and stable, so a build from `main` can be deployed to production at any point if needed.