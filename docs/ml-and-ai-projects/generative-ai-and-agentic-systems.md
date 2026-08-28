# Generative AI and Agentic Systems

Generative AI systems introduce engineering concerns that are less common in classical ML systems. The same user request can produce different outputs over time, retrieved content can change the answer, prompts become part of the product behavior, and tool-using agents can take actions outside the model runtime. Treat prompts, models, grounding data, tool permissions, evaluations, and telemetry as production artifacts.

Use this guide when a solution uses large language models, retrieval-augmented generation (RAG), tool calling, autonomous or semi-autonomous agents, model routing, generated content, or AI-assisted workflows that affect users or production systems.

## Choose the Right Architecture

Prefer the simplest design that can satisfy the user need, quality bar, and risk profile.

- Use direct model calls when the task is low risk, does not require private or fast-changing facts, and can be validated with clear output checks.
- Use RAG when answers must be grounded in approved sources, citations are expected, or the knowledge changes more often than the model can be updated.
- Use deterministic orchestration when the process needs predictable steps, explicit branching, repeatable validation, or integration with existing business rules.
- Use tool-calling agents when the system must inspect state, call APIs, modify records, or coordinate work, and when each tool can be scoped, validated, audited, and rolled back.
- Use multi-agent systems only when distinct roles, state boundaries, or review loops reduce complexity enough to justify the extra coordination and observability cost.
- Use model routers when different models serve clearly different latency, cost, quality, privacy, or availability needs, and routing decisions can be tested and monitored.
- Use fine-tuning when examples show that prompt design, RAG, or orchestration cannot meet the quality target, and when the team can own training data quality, evaluation, safety review, and model lifecycle operations.

Do not use an agent to hide unclear requirements. If a workflow is not understood well enough to describe its tools, permissions, failure states, and acceptance criteria, start with a deterministic workflow or a human-assisted prototype.

## Workload Readiness Checklist

Before the team commits to building or operating an AI workload, confirm that the following are explicit and reviewable:

- [ ] The intended use and measurable user outcome are documented.
- [ ] Prohibited uses, excluded user groups, and unsafe operating conditions are documented.
- [ ] Impacted users, operators, and downstream stakeholders are identified.
- [ ] Input data, grounding data, prompts, responses, logs, and memory stores have data classifications.
- [ ] The architecture choice explains why direct calls, RAG, orchestration, agents, routing, or fine-tuning fit the problem.
- [ ] The evaluation plan covers quality, safety, groundedness, refusal behavior, latency, cost, and regression cases.
- [ ] The observability plan captures enough telemetry to debug behavior while protecting sensitive data.
- [ ] The cost budget covers model calls, embeddings, retrieval, evaluations, tracing, red-team runs, and expected growth.
- [ ] The support model identifies owners for prompts, grounding data, tools, model configuration, evals, and incidents.
- [ ] The incident response plan covers disabling model features, blocking unsafe tools, rolling back prompts or indexes, and communicating user impact.

Use the [Responsible AI](./responsible-ai.md), [model experimentation](./model-experimentation.md), and [test planning](../automated-testing/test-planning.md) guidance to turn these readiness items into project artifacts.

## RAG and Grounding Checklist

RAG systems move part of the product quality bar into the data and retrieval layer. Review grounding content with the same care as application code.

- [ ] Source systems are authoritative for the questions the product will answer.
- [ ] Retrieval respects user authorization and does not expose documents the user cannot access directly.
- [ ] Chunking, metadata, embedding, and ranking choices are evaluated against realistic user questions.
- [ ] Citations identify the source, section, or record used to generate the answer.
- [ ] The system handles stale, missing, conflicting, or low-quality retrieved content safely.
- [ ] Deletion, retention, and right-to-be-forgotten requirements apply to indexes, caches, prompts, logs, and generated summaries.
- [ ] Index updates, emergency rollback, and source freshness checks are part of release and operations plans.

## Agentic Systems Checklist

Agents need stronger controls because they can combine model output, user context, memory, and tools into actions.

- [ ] Each agent has a clear identity, purpose, owner, and operating boundary.
- [ ] User context is passed only when needed and is validated before use in prompts, tools, and retrieval.
- [ ] The tool inventory lists each tool, data scope, side effects, rate limits, and failure behavior.
- [ ] Tool permissions follow least privilege and are separated by environment, tenant, and user role.
- [ ] Tool schemas are narrow, versioned, validated, and resilient to malformed model output.
- [ ] High-impact actions require approval, confirmation, or human review before execution.
- [ ] Memory and state retention rules cover what is stored, where it is stored, who can read it, and how it is deleted.
- [ ] Audit logs connect user request, prompt or instruction version, retrieval results, tool calls, approvals, and final outcome.
- [ ] Circuit breakers can stop repeated failures, unsafe outputs, runaway cost, excessive retries, and risky tool sequences.
- [ ] Rollback procedures cover prompts, tools, model configuration, grounding indexes, memory, and external side effects.

## Review the System Across Disciplines

Generative AI and agentic systems should be reviewed through the same engineering fundamentals as the rest of the system, with extra attention to non-determinism, data boundaries, and tool authority.

- Lean on [Responsible AI](./responsible-ai.md) to review user impact, harms, transparency, accountability, human oversight, and post-deployment review cadence.
- Turn to [model experimentation](./model-experimentation.md) to version prompts, datasets, model settings, retrieval configuration, and evaluation results.
- Let [test planning](../automated-testing/test-planning.md) define golden datasets, adversarial cases, prompt regressions, groundedness checks, and tool-call contract tests.
- Run [threat modeling](../security/threat-modelling.md) to analyze prompt injection, indirect prompt injection, tool-output injection, data exfiltration, sensitive disclosure, model/provider trust, and excessive agency.
- Plan with [ML observability](../observability/ml-observability.md) for traces of prompts, model versions, retrieval source IDs, citations, safety filters, tool calls, latency, tokens, cost, and user feedback.
- Treat the [CI/CD](../CI-CD/README.md) pipeline as where prompts, eval datasets, grounding indexes, model configuration, safety settings, and tool permission manifests become versioned release artifacts.
- Reach for [Copilots](../developer-experience/copilots.md) when AI assistants or coding agents help author code, tests, documentation, or pull requests.
- Check [privacy fundamentals](../non-functional-requirements/privacy/README.md) for prompt data, logs, memory, telemetry, retention, consent, and deletion handling.
- Revisit [accessibility](../non-functional-requirements/accessibility.md) for generated content, chat experiences, citations, multimodal input and output, fallback paths, and user control.
- Bring [code reviews](../code-reviews/README.md) in to inspect AI-generated code, prompt changes, tool contracts, eval evidence, dependencies, and operational controls.

## Definition of Done

A generative AI or agentic feature is not ready because it responds convincingly in a demo. It is ready when the team can show evidence that the feature is useful, bounded, testable, observable, secure, and supportable.

- [ ] The feature has acceptance criteria for correct, incorrect, uncertain, unsafe, and out-of-scope requests.
- [ ] Evaluation results are reviewed before release and compared with a previous baseline.
- [ ] Human review paths are defined for high-impact decisions or actions.
- [ ] Users understand when they are interacting with AI and how to challenge, correct, or report an output.
- [ ] Operations teams can identify the prompt, model, retrieval data, tool calls, and safety controls involved in an incident.
- [ ] The team has a rollback path that does not require retraining a model under incident pressure.
