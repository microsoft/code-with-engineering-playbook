# Machine Learning fundamentals at CSE

This guideline documents the Machine Learning (ML) practices in CSE. CSE works with customers on developing ML models and putting them in production, with an emphasis on engineering and research best practices throughout the project's life cycle.

## Goals

* Provide a set of ML practices to follow in an ML project.
* Provide clarity on ML process and how it fits within an software engineering project.
* Provide best practices for the different stages of an ML project.

## How to use these fundamentals

* If you are starting a new ML project, consider reading through the [general guidance documents](#general-guidance).
* For specific aspects of an ML project, refer to the guidelines for different [project phases](#ml-project-phases).

## ML Project phases

The diagram below shows different phases in an ideal ML project. Due to practical constraints and requirements, it might not always be possible to have a project structured in such a manner, however best practices should be followed for each individual phase.

![Project flow](flow.png)

* **[Envisioning](ml-problem-formulation-envisioning.md)**: Initial problem understanding, customer goals and objectives.
* **[Feasibility Study](ml-feasibility-study.md)**: Assess whether the problem in question is feasible to solve satisfactorily using ML with the available data.
* **Model Milestone**: There is a basic model that is achieving the minimum required performance, both in terms of ML performance and system performance. Using the knowledge gathered up to this milestone, define the scope, objectives, high-level architecture, definition of done and plan for the entire project.
* **[Model(s) experimentation](ml-experimentation.md)**: Tools and best practices for conducting successful model experimentation.
* **Model(s) Operationalization**: [Model readiness for production](ml-model-checklist.md) checklist.

## General guidance

* [ML Process Guidance](ml-proposed-process.md)
* [ML Fundamentals checklist](ml-fundamentals-checklist.md)
* [Agile ML development](ml-project-management.md)
* [Testing Data Science and ML Ops code](ml-testing.md)

## References

* [Responsible AI](https://www.microsoft.com/en-us/ai/responsible-ai-resources)
* [Model Operationalization](https://github.com/Microsoft/MLOps)
