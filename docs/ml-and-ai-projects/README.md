# Machine Learning Fundamentals at ISE

This guideline documents the Machine Learning (ML) practices in ISE. ISE works with customers on ML/AI projects and putting them in production, with an emphasis on engineering and research best practices throughout the project's life cycle.

Modern ML/AI projects may also include generative AI, retrieval-augmented generation, tool-calling agents, or AI-assisted workflows. These systems still need the ML lifecycle guidance in this section, but they also require explicit controls for prompts, grounding data, evaluations, tool permissions, telemetry, and Responsible AI review.

## Goals

* Provide a set of ML practices to follow in an ML project.
* Provide clarity on ML process and how it fits within a software engineering project.
* Provide best practices for the different stages of an ML project.

## How to use these Fundamentals

* If you are starting a new ML project, consider reading through the [general guidance documents](#general-guidance).
* For specific aspects of an ML project, refer to the guidelines for different [project phases](#ml-project-phases).

## AI-enabled project entry points

Generative AI, LLM, and agent projects need the same ML fundamentals plus additional engineering controls for prompts, retrieval, tool use, autonomy, safety, and monitoring.

* Start with the [AI-Assisted Engineering](../ai-assisted-engineering/README.md) guide for shared expectations around tool use, review, data handling, testing, security, observability, and traceability.
* Use [Responsible AI](./responsible-ai.md) early for impact assessment, stakeholder analysis, fallback paths, and ongoing review.
* Plan evaluation datasets, rubrics, safety checks, and regression gates with the [Testing](../automated-testing/README.md#testing-ai-assisted-and-ai-enabled-changes) guidance.
* Include AI-specific threat modeling and operational telemetry from the [Security](../security/README.md#ai-and-agent-security) and [Observability](../observability/README.md#ai-observability) guides.

## ML Project Phases

The diagram below shows different phases in an ideal ML project. Due to practical constraints and requirements, it might not always be possible to have a project structured in such a manner, however best practices should be followed for each individual phase.

![Project flow](./images/flow.png)

* **[Envisioning](./envisioning-and-problem-formulation.md)**: Initial problem understanding, customer goals and objectives.
* **[Feasibility Study](./feasibility-studies.md)**: Assess whether the problem in question is feasible to solve satisfactorily using ML with the available data.
* **Model Milestone**: There is a basic model that is achieving the minimum required performance, both in terms of ML performance and system performance. Using the knowledge gathered to this milestone, define the scope, objectives, high-level architecture, definition of done and plan for the entire project.
* **[Model(s) experimentation](./model-experimentation.md)**: Tools and best practices for conducting successful model experimentation.
* **Model(s) Operationalization**: [Model readiness for production](ml-model-checklist.md) checklist.

## General Guidance

* [ML Process Guidance](./proposed-ml-process.md)
* [ML Fundamentals checklist](./ml-fundamentals-checklist.md)
* [Data Exploration](./data-exploration.md)
* [Agile ML development](./agile-development-considerations-for-ml-projects.md)
* [Testing Data Science and ML Ops code](./testing-data-science-and-mlops-code.md)
* [Profiling Machine Learning and ML Ops code](./profiling-ml-and-mlops-code.md)
* [Responsible AI](./responsible-ai.md)
* [Generative AI and agentic systems](./generative-ai-and-agentic-systems.md)
* [Program Management for ML projects](./tpm-considerations-for-ml-projects.md)

## Resources

* [Model Operationalization](https://github.com/Microsoft/MLOps)
