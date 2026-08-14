# Responsible AI in ISE

## Microsoft's Responsible AI principles

Every ML project in ISE goes through a Responsible AI (RAI) assessment to ensure that it upholds Microsoft's [6 Responsible AI principles](https://www.microsoft.com/en-us/ai/responsible-ai):

- Fairness
- Reliability & Safety
- Privacy & Security
- Inclusiveness
- Transparency
- Accountability

Every project goes through the RAI process, whether we are building a new ML model from scratch, or putting an existing model in production.

## ISE's Responsible AI process

The process begins as soon as we start a prospective project. We start to complete a Responsible AI review document, and an impact assessment, which provides a structured way to explore topics such as:

- Can the problem be addressed with a non-technical (e.g. social) solution?
- Can the problem be solved without AI? Would simpler technology suffice?
- Will the team have access to domain experts (e.g. doctors, refugees) in the field where the AI is applicable?
- Who are the stakeholders in this project? Who does the AI impact? Are there any vulnerable groups affected?
- What are the possible benefits and harms to each stakeholder?
- How can the technology be misused, and what can go wrong?
- Has the team analyzed the input data properly to make sure that the training data is suitable for machine learning?
- Is the training data an accurate representation of data that will be used as input in production?
- Is there a good representation of all users?
- Is there a fall-back mechanism (a human in the loop, or a way to revert decisions based on the model)?
- Does data used by the model for training or scoring contain PII? What measures have been taken to remove sensitive data?
- Does the model impact consequential decisions, like blocking people from getting jobs, loans, health care etc. or in the cases where it may, have appropriate ethical considerations been discussed?
- Have measures for re-training been considered?
- How can we address any concerns that arise, and how can we mitigate risk?

At this point we research available [tools and resources](https://www.microsoft.com/en-us/ai/responsible-ai-resources), such as [InterpretML](https://interpret.ml/) or [Fairlearn](https://github.com/fairlearn/fairlearn), that we may use on the project. We may change the project scope or re-define the [ML problem definition](./envisioning-and-problem-formulation.md) if necessary.

## Generative AI and agent review prompts

Generative AI and agentic systems need additional Responsible AI review because they can produce open-ended content, use grounding data, remember context, call tools, and take actions on behalf of users. Use these prompts with the [generative AI and agentic systems](./generative-ai-and-agentic-systems.md) guide when reviewing feasibility, development, production readiness, deployment, and monitoring. For shared engineering controls across these areas, see the [AI-Assisted Engineering](../ai-assisted-engineering/README.md) guide.

### Grounding and generated content

We ask these questions early, while we are still deciding how the system should source and present its answers:

- What sources ground the answer, and are they authoritative for the intended use?
- How does the system handle stale, missing, contradictory, or low-quality retrieved content?
- Are citations or source references available when users need to verify generated answers?
- What harms could occur if the system hallucinates, overstates confidence, or produces misinformation?
- What content safety controls, refusal behaviors, and fallback paths are tested before release?

### Prompt, retrieval, and tool abuse

Whenever the system accepts untrusted input or calls tools, we walk through these abuse scenarios:

- How could a user, retrieved document, web page, file, or tool response inject instructions that override the intended behavior?
- Are system instructions, developer prompts, and tool schemas reviewed and versioned as product artifacts?
- What validation prevents tool-output injection, unsafe command construction, or untrusted content from being treated as instructions?
- Which misuse and abuse cases were red-teamed, and what evidence shows the mitigations were retested?

Use [threat modeling](../security/threat-modelling.md) to turn these questions into threats, mitigations, and validation evidence.

### Agent actions and human oversight

Before we let an agent act on a user's behalf, we get clear on what it can do and who signs off:

- What actions can the agent take, and which users, roles, tenants, and environments can authorize them?
- Which actions require explicit user approval, human review, or a second system check before execution?
- Can privileged actions be paused, blocked, rate limited, or rolled back during an incident?
- How are failures, retries, partial completion, and external side effects communicated to users and operators?

### Memory, logs, and retention

As we decide what to store and for how long, we check these data-handling questions:

- What conversation history, prompts, retrieved content, generated outputs, tool calls, and user feedback are stored?
- Does stored memory contain personal, confidential, regulated, or customer-owned data?
- How are consent, retention, deletion, and right-to-be-forgotten requirements handled across prompts, logs, indexes, caches, and memories?
- Can telemetry support debugging and audit needs without exposing sensitive content unnecessarily?

Use [privacy fundamentals](../non-functional-requirements/privacy/README.md) and [ML observability](../observability/ml-observability.md) when designing these controls.

### Production monitoring and review cadence

Once the system is live, we keep asking these questions so the review does not stop at launch:

- What evaluation suite tracks groundedness, harmful content, jailbreak resistance, tool-call accuracy, and regression from previous releases?
- What user feedback, safety filter outcomes, incident signals, and cost or latency metrics are reviewed after deployment?
- Who owns prompt updates, model configuration, grounding data, eval datasets, safety thresholds, and tool permissions?
- How often will the team re-run Responsible AI review after model, prompt, retrieval, data, policy, or user population changes?

Use [model experimentation](./model-experimentation.md) and [test planning](../automated-testing/test-planning.md) to define measurable evaluation evidence.

The Responsible AI review documents remain living documents that we re-visit and update throughout project development, through the [feasibility study](./feasibility-studies.md), as the model is developed and prepared for production, and new information unfolds. The documents can be used and expanded once the model is deployed, and monitored in production.
