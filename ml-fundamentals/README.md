# Machine Learning fundamentals at CSE

This guideline documents the Machine Learning (ML) practices in CSE. CSE works with customers on developing ML models and putting them in production, while emphasizing engineering and research best practices throughout the project's life cycle.

## Goals

* Provide a set of ML practices to follow in an ML project.
* Provide clarity on ML process and how it fits within an software engineering project.
* Provide best practices for the different stages of an ML project.

## How to use these fundamentals

* If you are starting a new ML project, consider reading through the [general guidance documents](#general-guidance).
* For specific aspects of an ML project, refer to the guidelines for different [project phases](#ml-project-phases-in-cse).

## ML Project phases in CSE

![Project flow](flow.png)

* [Envisioning](../design-reviews/recipes/engagement-process.md#envisioning--architecture-design-session-ads): Initial problem understanding, customer goals and objectives. *(Link to engineering playbook)*
* Feasibility study: Assess whether the problem in question is feasible to solve satisfactorily using ML with the available data.
* [Game plan](../design-reviews/recipes/engagement-process.md#game-plan): Defining the problem, scope, objectives, definition of done and high level plan for the entire project. *(Link to engineering playbook)*
* [Model(s) experimentation](ml-experimentation.md): Tools and best practices for conducting successful model experimentation.
* [Model readiness for production](ml-model-checklist.md) checklist.
  
## General guidance

* [ML Fundamentals checklist](ml-fundamentals-checklist.md)
* [Agile ML development](ml-project-management.md)
* [Testing Data Science and ML Ops code](ml-testing.md)

### ML project phases

* [Model Readiness for Production](ml-model-checklist.md)

## References

* [Responsible AI](https://www.microsoft.com/en-us/ai/responsible-ai-resources)
* [Model Operationalization](https://github.com/Microsoft/MLOps)
