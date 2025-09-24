# Branching & CI/CD Guidance

Purpose: Provide a concise, practical policy and examples teams can adopt for integration, branching and CI gating. This page is intentionally short — teams should adapt the policy to their project and toolchain.

## Recommended approach

- Prefer trunk-based development where possible for new projects. Use short-lived feature branches when necessary and merge frequently into the default integration branch (commonly `main` or `trunk`).
- Use branch protection rules on the integration branch to enforce quality gates (required passing CI, required code reviews, status checks).
- Keep releases simple: use tags/releases from the integration branch and keep release process documented separately.

## Example branch protection rules

- Require at least one approving reviewer for pull requests.
- Require successful CI pipeline status checks before merge.
- Require up-to-date branch before merge if your policy prefers.

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

## Merge policy checklist (suggested)

- [ ] Code compiles and automated tests pass in CI
- [ ] At least one approving reviewer has reviewed the change
- [ ] The change has an associated work item or issue
- [ ] Documentation updated where applicable

## Tips

- Keep feature branches short-lived; frequent merges reduce integration risk.
- Automate as much of the gate (linting, unit tests, basic security scans) as possible to keep manual review focused on design and architecture.
- Adapt branch protection to match team size and delivery cadence.

## CI/CD guidance

This page complements the central [CI/CD guidance](../CI-CD/README.md). Key expectations teams should follow:

- The integration (main) branch should be continuously shippable and stable — at any point we should be able to deploy a build from `main` to production if needed.
- Run a quality pipeline (linting, unit tests, basic integration tests) on each PR and on merges to the integration branch.
- Provision cloud resources and environment configuration via infrastructure-as-code (for example Terraform, Bicep, Pulumi) and exercise them in non-production environments.
- Deploy release candidates automatically to a non-production environment to validate integration and operational concerns.
- Automate release and rollback procedures so releases are repeatable and auditable.