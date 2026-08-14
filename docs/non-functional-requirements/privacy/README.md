# Privacy fundamentals

Private data handling and protection requires both the proper design of software,
systems and databases, as well as the implementation of organizational processes and procedures.

In general, developers working on [ISE](../../ISE.md) projects should adhere to Microsoft's recommended standard practices and regulations on Privacy and Data Handling.

## AI Privacy Review Prompts

Generative AI and agentic systems can move private data through many surfaces — user-facing inputs like prompts and retrieved content, the systems that process them such as model providers and tool calls, and what the system retains afterward in telemetry, memory, and generated summaries. Use these prompts with the [Responsible AI](../../ml-and-ai-projects/responsible-ai.md) and [generative AI and agentic systems](../../ml-and-ai-projects/generative-ai-and-agentic-systems.md) guidance before release and after material model, prompt, retrieval, tool, or telemetry changes.

- What personal, confidential, regulated, or customer-owned data can appear in user prompts, system prompts, uploaded files, retrieved documents, tool responses, generated outputs, logs, traces, embeddings, caches, or memory stores?
- Are users told what data they should not enter or upload, and does the product block or warn on risky upload types, excessive data scope, or unsupported sensitive data?
- Which model providers, hosting regions, retrieval stores, tool APIs, and telemetry systems process the data, and what contractual, residency, retention, and access controls apply?
- Is telemetry minimized, redacted, aggregated, or sampled so operators can debug quality, safety, cost, and reliability without storing unnecessary sensitive content?
- What conversation memory, generated summaries, personalization state, or agent state is stored, who can read it, how long is it retained, and how can a user or operator delete it?
- Do retrieval indexes enforce the same authorization as the source systems, and do deletion or right-to-be-forgotten workflows cover indexes, embeddings, caches, summaries, and citations?
- Are prompts, prompt templates, system instructions, tool schemas, and safety policies reviewed for accidental disclosure of secrets, internal-only details, or private data handling assumptions?
- Can the team disable memory, tracing, retrieval, or model calls during an incident without losing the ability to communicate user impact and recover safely?
