# AI-Assisted Engineering

AI tools help us explore ideas, draft code, write tests, summarize context, and improve documentation. They work best when they are part of normal engineering practice: a responsible person still owns the work, the team still validates the output, and our decisions still follow the customer and team context.

Use this guide as the shared baseline for AI-assisted engineering. Domain guides such as [Developer Experience](../developer-experience/README.md), [Automated Testing](../automated-testing/README.md), [Security](../security/README.md), [Observability](../observability/README.md), [Source Control](../source-control/README.md), [Code Reviews](../code-reviews/README.md), and [Documentation](../documentation/README.md) provide more specific guidance.

## When to Use AI Assistance

AI assistance pays off most when an early draft or explanation gives us something concrete to react to, so we reach for it on work where a candidate implementation accelerates learning and delivery:

- Drafting boilerplate, examples, tests, and documentation, along with supporting artifacts like diagrams and review notes
- Explaining unfamiliar code, logs, errors, and dependencies, including infrastructure templates
- Generating implementation options, refactoring ideas, threat-model prompts, and test scenarios
- Summarizing requirements, backlog items, architecture notes, and design tradeoffs
- Exploring alternatives before the team makes a decision

We avoid leaning on AI alone where the work demands accountability, project-specific judgment, or policy interpretation:

- Architecture decisions, security-sensitive logic, privacy decisions, and release approvals
- Consequential decisions that affect people, access, eligibility, or legal status — and anything touching finance, health, or safety
- Customer data handling, regulated data handling, retention decisions, and disclosure obligations
- Production incident response, destructive operations, and changes to cloud or production resources
- Claims about compliance, licensing, or vulnerability status — and any claim about performance or model behavior — made without evidence

## Human Oversight

AI can produce confident-looking work that is subtly wrong, so we treat its output as draft material until a responsible person has reviewed, tested, and accepted it.

- Keep a named human owner for every AI-assisted pull request, design decision, deployment, and customer-facing artifact.
- Review AI-generated code and text with the same or higher care as hand-written work.
- Check generated claims against source material, product documentation, requirements, and customer context.
- Reject generated output that is unrelated, unexplainable, or unverifiable — or that is over-broad or inconsistent with the team architecture.
- Preserve our normal engineering controls — peer review, branch protection, and CI checks — along with security review, accessibility review, and rollback planning.

## Data and Context Hygiene

Every prompt is a place data can leak, so we give AI tools only the minimum context they need to complete the task.

- Confirm which AI tools are approved for the project, customer, data classification, and engagement model before work starts.
- Do not paste secrets, credentials, or private customer data into AI tools — and keep regulated data and unnecessary proprietary context out as well.
- Prefer synthetic, representative, anonymized, or redacted examples when exploring prompts or reproducing issues.
- Strip access tokens, connection strings, and personal data — along with customer identifiers and confidential business details — from any prompts, screenshots, logs, or attachments.
- Understand how a tool handles retention, logging, and telemetry — and its training and data-residency behavior — before feeding it project or customer context.
- Keep prompts and retrieved context scoped to the task. Extra context can increase leakage risk and produce less accurate output.

## Prompt and Repository Hygiene

AI tools are only as good as the context they can find, so keeping our repositories well-documented directly improves the results we get.

- Keep the common build, test, and lint commands easy to find in repository documentation, along with setup and run instructions.
- Document project conventions, architectural boundaries, dependency choices, and coding standards where tools and people can discover them.
- Use repository instruction files, prompt files, or agent configuration only when the team has agreed on their purpose and maintenance owner.
- Avoid instructions that ask AI tools to bypass tests, ignore security review, hide generated changes, or make broad edits outside the task.
- Keep reusable prompts factual and current. Remove outdated assumptions when architecture, tooling, or customer constraints change.

## Security

A model has no stake in our security, so we treat its output as untrusted input and review it accordingly.

- Review generated code for the usual high-risk flaws — injection, authorization, and authentication — and for cryptography, dependency, logging, and error-handling issues.
- Do not execute generated commands or scripts until a responsible person understands their effect.
- Scope AI agent tools, credentials, and file access to the least privilege needed for the task — and do the same for cloud permissions and network access.
- Add threat-model coverage for AI-specific risks using the canonical [AI systems threat-modeling considerations](../security/threat-modelling.md#ai-systems-threat-modeling-considerations).
- Validate generated dependency, container, infrastructure, and CI/CD changes against the normal security review path.

## Testing and Evaluation

AI assistance changes how we produce code, but not our need for evidence that it works.

- Review generated tests for meaningful assertions, realistic setup, negative cases, and failure modes.
- Add deterministic automated tests for ordinary software behavior.
- Add AI-specific evaluations whenever product behavior depends on prompts, retrieval, models, or agents — or on generated content, ranking, summarization, or recommendations.
- Where relevant, evaluate quality, groundedness, safety, and bias, along with robustness, tool-call correctness, regression behavior, and fallback behavior.
- Keep evaluation datasets, rubrics, expected outcomes, and known limitations versioned with the system or linked from the project documentation.

## Observability

AI-enabled systems can drift in ways traditional ones do not, so we capture enough telemetry to debug behavior and detect that drift while respecting privacy and policy constraints.

- Track the signals that let us explain a response after the fact:
  - Versions in play: model, configuration, and prompt template versions
  - What the system did: retrieval sources, tool calls, and fallback paths
  - Cost and performance: latency and token or cost signals
  - Outcomes: errors, safety outcomes, evaluation scores, and human escalation
- Avoid logging raw prompts or completions, and keep secrets, personal data, customer data, and sensitive retrieval content out of logs unless the project has an explicit, approved logging design.
- Connect production signals to incident response, rollback, model or prompt change review, and customer support workflows.
- Review observability data for quality regression, unexpected tool use, abuse patterns, and changes in model behavior over time.

## Authorship and Traceability

When a decision is questioned later, we want to know where AI materially shaped the work, so we keep that influence visible.

- Follow the team's convention for documenting material AI assistance in pull requests, commit metadata, work items, or decision records.
- Keep generated changes small enough to review and explain.
- Back AI-assisted decisions with the same evidence we expect for any other decision — requirements, tests, and evaluations, plus design notes, customer constraints, and review comments.
- Do not use AI-generated summaries as the only record of customer decisions or stakeholder approval.
- Make sure generated comments, release notes, and documentation do not claim behavior that has not been implemented and validated.

## Accessibility and Inclusion

AI can help us spot accessibility and inclusion issues, but it does not replace user research, accessibility testing, or assistive-technology review.

- Review AI-generated UI, content, flows, and images for accessibility and inclusive language, as well as cognitive load, localization, and cultural context.
- Validate generated UI with the same accessibility requirements used for the rest of the product.
- Test important experiences manually with keyboard navigation, screen readers, color contrast checks, and other assistive technology where appropriate.
- Include affected users, domain experts, and accessibility reviewers when AI-enabled behavior changes the user experience.

## Governance

No single policy fits every engagement, so we adapt this guidance to each project's risk, customer policy, and system impact.

- Decide early which tools are approved, which data they can access, who owns review, and how exceptions are handled.
- Add AI policy and setup questions to project onboarding, first-week planning, team working agreements, and definitions of done where relevant — the [Project Kickoff Checklist](../start-here/project-kickoff-checklist.md) is where a team decides its AI usage model.
- Route higher-risk AI work through the reviews that fit the risk — Responsible AI assessment, privacy review, and security review, plus design, accessibility, and legal or compliance review — before seeking stakeholder approval.
- Document material limitations, known failure modes, monitoring expectations, and human escalation paths for AI-enabled features.
- Revisit the guidance when tools, customer constraints, model capabilities, or production usage change.

## Related Playbook Areas

- [Developer Experience](../developer-experience/README.md) and [Copilots](../developer-experience/copilots.md) for AI tool setup and attribution patterns
- [Automated Testing](../automated-testing/README.md) for test strategy and evaluation practices
- [Security](../security/README.md) for secure engineering practices and threat modeling
- [Observability](../observability/README.md) for telemetry and operational readiness
- [Source Control](../source-control/README.md) and [Code Reviews](../code-reviews/README.md) for review, traceability, and change control
- [Data Handling](../non-functional-requirements/privacy/data-handling.md) for privacy and data protection practices
- [Accessibility](../non-functional-requirements/accessibility.md) for inclusive and accessible delivery
- [Responsible AI](../ml-and-ai-projects/responsible-ai.md) for AI system impact assessment

## External References

These external resources expand on the practices above. Review them against your project's customer, data, and policy constraints before adopting them.

- [microsoft/hve-core](https://github.com/microsoft/hve-core) — open-source Hypervelocity Engineering (HVE) accelerator: reusable Copilot agents, prompts, instructions, and skills built around a Research → Plan → Implement (RPI) workflow.
- [HVE Core documentation](https://microsoft.github.io/hve-core/) — guidance for AI-assisted development across the lifecycle.
- [HVE Guide — project lifecycle](https://microsoft.github.io/hve-core/docs/hve-guide/) and [RPI workflow](https://microsoft.github.io/hve-core/docs/rpi/) — explore and specify before coding, with fast iteration loops.
- [HVE project-planning templates](https://microsoft.github.io/hve-core/docs/templates/) — reusable requirements and ADR templates.
- [Responsible AI in Azure Workloads](https://learn.microsoft.com/en-us/azure/well-architected/ai/responsible-ai) — Well-Architected Responsible AI guardrails and governance per lifecycle stage.
- [Best practices for using GitHub Copilot](https://docs.github.com/en/copilot/get-started/best-practices) — prompt hygiene, iteration, and human oversight.
- [GitHub Copilot Fundamentals](https://learn.microsoft.com/en-us/training/paths/copilot/) — adoption and SDLC use cases.
