# Model Experimentation

## Overview

Machine learning model experimentation involves uncertainty around the expected model results and future operationalization.
To handle this uncertainty as much as possible, we propose a semi-structured process, balancing between engineering/research best practices and rapid model/data exploration.

## Model experimentation goals

- **Performance**: Find the best performing solution
- **Operationalization**: Keep an eye towards production, making sure that operationalization is feasible
- **Code quality** Maintain code and artifacts quality
- **Reproducibility**: Keep research active by allowing experiment tracking and reproducibility
- **Collaboration**: Foster the collaboration and joint work of multiple people on the team

## Model experimentation challenges

- **Trial and error process**: Difficult to plan and estimate durations and capacity.
- **Quick and dirty**: We want to fail fast and get a sense of what’s working efficiently.
- **Collaboration**: How do we form a team-wide trial and error process and effective brainstorming.
- **Code quality**: How do we maintain the quality of non-production code during research.
- **Operationalization**: Switching between approaches might have a significant impact on operationalization (e.g. GPU/CPU, batch/online, parallel/sequential, runtime environments).

Creating an experimentation framework which facilitates rapid **experimentation**, **collaboration**,
experiment and model **reproducibility**, **evaluation**  and **defined APIs**,
and lets each team member focus on the model development and improvement,
while trusting the framework to do the rest.

The following tools and guidelines are aimed at achieving experimentation goals as well as addressing the aforementioned challenges.

## Tools and guidelines for successful model experimentation

- [Virtual environments](#virtual-environments)
- [Source control and folder/package structure](#source-control-and-folder-package-structure)
- [Experiment tracking](#experiment-tracking)
- [Datasets and models abstractions](#datasets-and-models-abstractions)
- [Model evaluation](#model-evaluation)

### Virtual environments

In languages like Python and R, it is always advised to employ virtual environments. Virtual environments facilitate reproducibility, collaboration and productization.
Virtual environments allow us to be consistent across our local dev envs as well as with compute resources. These environments' configuration files can be used to build the code from source in an consistent way.
For more details on why we need virtual environments visit [this blog post](https://realpython.com/python-virtual-environments-a-primer/#why-the-need-for-virtual-environments).

#### Which virtual environment framework should I choose

All virtual environments frameworks create isolation, some also propose dependency management and additional features. Decision on which framework to use depends on the complexity of the development environment (dependencies and other required resources) and on the ease of use of the framework.

#### Types of virtual environments

In CSE we often choose from either `venv`, `Conda` or `Poetry`, depending on the project requirements and complexity.

- [venv](https://docs.python.org/3/library/venv.html) is included in Python, is the easiest to use, but lacks more advanced features like dependency management.
- [Conda](https://docs.conda.io/en/latest/) is a popular package, dependency and environment management framework. It supports multiple stacks (Python, R) and multiple versions of the same environment (e.g. multiple Python versions). `Conda` maintains its own package repository, therefore some packages might not be downloaded and managed directly through `Conda`.
- [Poetry](https://python-poetry.org/) is a Python dependency management system which manages dependencies in a standard way using `pyproject.toml` files and `lock` files. Similar to `Conda`, `Poetry`'s dependency resolution process is sometimes slow (see [FAQ](https://python-poetry.org/docs/faq/#why-is-the-dependency-resolution-process-slow)), but in cases where dependency issues are common or tricky, it provides a robust way to create reproducible and stable environments.

#### Expected outcomes for virtual environments setup

1. Documentation describing how to create the selected virtual environment and how to install dependencies.
2. Environment configuration files if applicable (e.g. `requirements.txt` for `venv`, [environment.yml](https://docs.conda.io/projects/conda/en/latest/user-guide/tasks/manage-environments.html#creating-an-environment-from-an-environment-yml-file) for `Conda` or [pyrpoject.toml](https://python-poetry.org/docs/pyproject/) for `Poetry`).

#### Virtual environments benefits

- Productization
- Collaboration
- Reproducibility

### Source control and folder/package structure

Applied ML projects often contain source code, notebooks, devops scripts, documentation, scientific resources, datasets and more. We recommend to come up with an agreed folder structure to keep resources tidy. Consider deciding upon a generic folder structure for projects (e.g. which contains the folders `data`, `src`, `docs` and `notebooks`), or adopt popular structures like the [CookieCutter Data Science](https://drivendata.github.io/cookiecutter-data-science/) folder structure.

[Source control](https://github.com/microsoft/code-with-engineering-playbook/tree/master/source-control) should be applied to allow collaboration, versioning, code reviews, traceability and backup. In data science projects, source control should be used for code, and the storing and versioning of other  artifacts (e.g. data, scientific literature) should be decided upon depending on the scenario.

#### Folder structure and source control expected outcomes

- Defined folder structure for all users to use, pushed to the repo.
- [.gitignore](https://git-scm.com/docs/gitignore) file determining which folders should be synced with `git` and which should be kept locally. For example, [this one](https://github.com/drivendata/cookiecutter-data-science/blob/master/%7B%7B%20cookiecutter.repo_name%20%7D%7D/.gitignore).
- Determine how notebooks are stored and versioned (e.g. [strip output from Jupyter notebooks](https://github.com/kynan/nbstripout))

#### Source control and folder structure benefits

- Collaboration
- Reproducibility
- Code quality

### Experiment tracking

Experiment tracking tools allow data scientists and researchers to keep track of previous experiments for better understanding of the experimentation process and for the reproducibility of experiments or models.

#### Types of experiment tracking frameworks

Experiment tracking frameworks differ by the set of features they provide for collecting experiment metadata, and comparing and analysing experiments. In CSE, we mainly use [MLFlow](https://mlflow.org/) on [Databricks](https://databricks.com/product/managed-mlflow) or [Azure ML Experimentation](https://docs.microsoft.com/en-us/azure/machine-learning/how-to-track-experiments). Note that some experiment tracking frameworks require a deployment, while others are SaaS.

#### Experiment tracking outcomes

1. Decide on an experiment tracking framework
2. Ensure it is accessible to all users
3. Document set-up on local environments
4. Define datasets and evaluation in a way which will allow the comparison of all experiments. **Consistency across datasets and evaluation is paramount for experiment comparison**.
5. Ensure full reproducibility by assuring that all required details are tracked (i.e. dataset names and versions, parameters, code, environment)

#### Experiment tracking benefits

- Model performance
- Reproducibility
- Collaboration
- Code quality

### Datasets and models abstractions

By creating abstractions to building blocks (e.g., datasets, models, evaluators),
we allow the easy introduction of new logic into the experimentation pipeline while keeping the agreed upon experimentation flow intact.

These abstractions can be created using different mechanisms.
For example, we can use Object Oriented Programming (OOP) solutions like abstract classes:

- [An example from scikit-learn describing the creation of new estimators compatible with the API](https://scikit-learn.org/stable/developers/develop.html).
- [An example from PyTorch on extending the abstract `Dataset` class](https://pytorch.org/tutorials/beginner/data_loading_tutorial.html#dataset-class).

#### Abstraction outcomes

1. Different building blocks have defined APIs allowing them to be replaced or extended.
2. Replacing building blocks does not break the original experimentation flow.
3. Mock building blocks are used for unit tests
4. APIs/mocks are shared with the engineering teams for integration with other modules.

#### Abstraction benefits

- Collaboration
- Code quality
- Reproducibility
- Operationalization
- Model performance

### Model evaluation

When deciding on the evaluation of the ML model/process, consider the following checklist:

- [ ] Evaluation logic is approved by all stakeholders.
- [ ] Relationship between evaluation logic and business KPIs is analysed and decided.
- [ ] Evaluation flow is applicable for all present and future models (i.e. does not assume some prediction structure or method-specific process).
- [ ] Evaluation code is unit-tested and reviewed by all team members.
- [ ] Evaluation flow facilitates further results and error analysis.

## Evaluation development process outcomes

1. Evaluation strategy is agreed upon all stakeholders
2. Research and discussion on various evaluation methods and metrics is documented.
3. The code holding the logic and data structures for evaluation is reviewed and tested.
4. Documentation on how to apply evaluation is reviewed.
5. Performance metrics are automatically tracked into the experiment tracker.

## Evaluation development process benefits

- Model performance
- Code quality
- Collaboration
- Reproducibility
