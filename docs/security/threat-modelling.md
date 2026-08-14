# Threat Modeling

Threat modeling is an effective way to help secure your systems, applications, networks, and services. It's a systematic approach that identifies potential threats and recommendations to help reduce risk and meet security objectives earlier in the development lifecycle.

## Threat Modeling Phases

1. *Diagram*
    Capture all requirements for your system and create a data-flow diagram
2. *Identify*
    Apply a threat-modeling framework to the data-flow diagram and find potential security issues. Here we can use [STRIDE framework](https://learn.microsoft.com/en-us/training/modules/tm-use-a-framework-to-identify-threats-and-find-ways-to-reduce-or-eliminate-risk/1b-threat-modeling-framework) to identify the threats.
3. *Mitigate*
    Decide how to approach each issue with the appropriate combination of security controls.
4. *Validate*
    Verify requirements are met, issues are found, and security controls are implemented.

Example of these phases is covered in the [threat modelling example.](./threat-modelling-example.md)
More details about these phases can be found at [Threat Modeling Security Fundamentals.](https://learn.microsoft.com/en-us/training/paths/tm-threat-modeling-fundamentals/)

## AI Systems Threat Modeling Considerations

Generative AI, retrieval-augmented generation (RAG), and agentic systems should go through the same threat modeling phases as other systems, with extra attention to untrusted instructions, grounding data, model dependencies, and tool authority. Include AI assets and trust boundaries in the data-flow diagram instead of treating the model as a black box.

As we model AI systems, we give extra attention to the risk categories that classical systems rarely face:

- Prompt injection
- Insecure output handling
- Sensitive information disclosure
- Excessive agency
- Unsafe tool calls
- Model or data poisoning
- Model theft
- AI supply chain risk

We also make sure the data-flow diagram names the AI assets and trust boundaries that an attacker would target:

- User prompts, uploaded files, system and developer instructions, prompt templates, and prompt stores
- Retrieval corpora, embeddings, vector indexes, source documents, citation metadata, and stale or poisoned content
- Model providers, hosted model deployments, model configuration, content filters, and fallback models
- Tool APIs, function schemas, queues, file systems, shells, external services, and write paths
- Agent memory, state stores, conversation history, secrets, delegated user permissions, telemetry, evaluation datasets, and feedback data
- Human approval, escalation, incident response, rollback, and red-team retesting points

As we walk each boundary, we ask questions like these to turn it into concrete threats:

- How could a prompt, retrieved document, uploaded file, web page, or tool response inject instructions that override the intended behavior?
- Can the system distinguish untrusted content from instructions, tool arguments, or policy decisions?
- Could the model or agent disclose sensitive data from prompts, retrieval results, memory, telemetry, evaluation data, or tool outputs?
- Are retrieval results security trimmed, fresh, attributable to approved sources, and resilient to poisoned or misleading content?
- Does the agent have more authority than the user, task, tenant, or environment requires?
- Can tool calls exfiltrate data, mutate records, execute commands, trigger external side effects, or bypass normal authorization checks?
- What happens if a model provider, hosted model deployment, embedding model, dependency, or safety service changes behavior or becomes unavailable?
- How are excessive token use, runaway retries, unbounded tool loops, cost spikes, and denial-of-wallet scenarios detected and stopped?
- Could model inversion, model stealing, training data leakage, or improper output handling expose protected information?

Mitigations should be specific, testable, and tied to owners. We group the controls we reach for most often by theme:

- Input and output handling: prompt and tool schema review, strict input and output validation, security-trimmed retrieval, and sensitive data redaction.
- Least privilege: least-privilege tools, user-context authorization, and human approval for privileged or irreversible actions.
- Operational safety: rate limits, circuit breakers, dry-run modes for write paths, and audit logs.
- Recovery and follow-up: rollback paths for prompts and indexes, and retesting after red-team findings are fixed.

## Threat Modeling Example

   [Here is an example](./threat-modelling-example.md) of a threat modeling document which talks about the architecture and different phases involved in the threat modeling. This document can be used as reference template for creating threat modeling documents.

## Resources

* [Threat Modeling](https://www.microsoft.com/en-us/securityengineering/sdl/threatmodeling)
* [Microsoft Threat Modeling Tool](https://learn.microsoft.com/en-us/azure/security/develop/threat-modeling-tool)
* [STRIDE (Threat modeling framework)](https://learn.microsoft.com/en-us/training/modules/tm-use-a-framework-to-identify-threats-and-find-ways-to-reduce-or-eliminate-risk/1b-threat-modeling-framework)
