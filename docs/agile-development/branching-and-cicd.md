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

---

## Alignment with CI/CD guidance
This page complements the central CI/CD guidance in `docs/CI-CD/README.md`. Key expectations teams should follow:

- The integration (main) branch should be continuously shippable and stable — at any point we should be able to deploy a build from `main` to production if needed.
- Run a quality pipeline (linting, unit tests, basic integration tests) on each PR and on merges to the integration branch.
- Provision cloud resources and environment configuration via infrastructure-as-code (for example Terraform, Bicep, Pulumi) and exercise them in non-production environments.
- Deploy release candidates automatically to a non-production environment to validate integration and operational concerns.
- Automate release and rollback procedures so releases are repeatable and auditable.

## Tools (reference)
Refer to `docs/CI-CD/README.md` for more detail on recommended tools. Common options include:
- Azure Pipelines — recommended/used across many Microsoft engagements for CI/CD.
- GitHub Actions, Jenkins, CircleCI, TravisCI — viable alternatives depending on project constraints.

## AI-assisted CI/CD authoring
AI tools can accelerate writing CI/CD pipeline YAML, jobs, and scripting snippets, but they must be used with explicit guardrails.

Suggested workflow:
- Use AI to draft CI/CD pipeline templates or job steps as a starting point (for example, generating a minimal GitHub Actions workflow).
- Run the draft pipeline in a safe non-production environment or CI sandbox to validate syntax and basic behaviour.
- Require a human reviewer to validate generated steps for correctness, idempotence, and security implications (especially around secrets, permissions, and external actions).
- Add tests or smoke checks to the pipeline so changes can be validated automatically when the pipeline runs.
- Promote approved templates into a central location (for example, `.github/workflows/` or a shared pipeline template repository) so teams reuse vetted, audited pipelines.

Guardrails and checklist (before merging AI-generated pipeline changes):
- [ ] Human review completed and documented in PR
- [ ] No secrets or credentials are hard-coded
- [ ] Required linting and syntax checks pass locally and in CI
- [ ] Security and license scans run and report no critical issues
- [ ] Pipeline steps are idempotent and have clear rollback strategies where applicable
- [ ] Generated content is annotated in the PR description (e.g., "AI-assisted draft") so reviewers know to apply extra scrutiny

Notes:
- AI-generated pipelines are excellent for reducing boilerplate and accelerating iteration, but they do not replace domain knowledge and security review.
- Maintain a small set of vetted pipeline templates to reduce risk and improve reproducibility.