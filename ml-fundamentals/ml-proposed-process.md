# Proposed ML process

## Introduction

The objective of this document is to provide guidance to produce machine learning (ML) applications that are based on code, data and models that can be reproduced and reliably released to production environments.
When developing ML applications, we consider the following approaches:

* Best practices in ML engineering:

  * The ML application development should use engineering fundamentals to ensure high quality software deliverables.
  * The ML application should be reliabily released into production, leveraging automation as much as possible.
  * The ML application can be deployed into production at any time. This makes the decision about when to release it a business decision rather than a technical one.

* Best practices in ML research:

  * All artifacts, specifically data, code and ML models, should be versioned and managed using standard tools and workflows, in order to facilitate continuous research and development.
  * While the model outputs can be non-deterministic and hard to reproduce, the process of releasing ML software into production should be reproducible.
  * Responsible AI aspects are carefully analysed and addressed.

* Cross-functional team:

  * A cross-functional team comprising of different skill sets in data science, data engineering, development, operations, and industry domain specialists is required.

## ML process

The proposed ML development process is comprised of:

1. Data and problem understanding
2. Responsible AI assessment
3. Feasibility study
4. Baseline model experimentation
5. Model evaluation and experimentation
6. Model operationalization
    * Unit and Integration testing
    * Deployment
    * Monitoring and Observability

### Version control

* During all stages of the process, it is suggested that artifacts should be version controlled. Typically, the process is iterative and versioned artifacts can assist in tracebility and reviewing. See more [here](ml-experimentation.md#source-control-and-folder-package-structure).

### Understanding the problem

* Define the business problem for the ML project:
  * Agree on the success criteria with the customer.
  * Identify potential data sources and determine the availability of these sources.
  * Define performance evaluation metrics on ground truth data
* Conduct a Responsible AI assessment to ensure development and deployment of the ML solution in a responsible manner. See more [here](https://www.microsoft.com/en-us/ai/responsible-ai-resources?activetab=pivot1%3aprimaryr4).
* Conduct a feasibility study to assess whether the business problem is feasible to solve satisfactorily using ML with the available data. The objective of the feasibility study is to mitigate potential over-investment by ensuring sufficient evidence that ML is possible and would be the best solution. The study also provides initial indications of what the ML solution should look like. This ensures quality solutions supported by thorough consideration and evidence. Refer to [feasibility study](ml-feasibility-study.md).
* Exploratory data analysis is performed and discussed with the team

* **Typical output**:

  * Data exploration source code (Jupyter notebooks/scripts) and slides/docs
  * Initial ML model code (Jupyter notebook or scripts)
  * Initial solution architecture with initial data engineering requirements
  * Data dictionary (if not yet available)
  * List of assumptions

### Baseline Model Experimentation

* Data preparation: creating data source connectors, determining storage services to be used and potential versioning of raw datasets.
* Feature engineering: create new features from raw source data to increase the predictive power of the learning algorithm. The features should capture additional information that is not apparent in the original feature set.
* Split data into training, validation and test sets: creating training, validation, and test datasets with ground truth to develop ML models. This would entail joining or merging various feature engineered datasets. The training dataset is used to train the model to find the patterns between its features and labels (ground truth). The validation dataset is used to assess the model architecture and the test data is used to confirm the prediction quality of the model.
* Initial code to create access data sources, transform raw data into features and model training as well as scoring.
* During this phase, experiment code (Jupyter notebooks or scripts) and accompanying utility code should be version controlled using tools such as ADO (Azure DevOps).

* **Typical output**: Rough Jupyter notebooks or scripts in Python or R, initial results from baseline model.

For more information on experimentation, refer to the [experimentation](ml-experimentation.md) section.

### Model Evaluation

* Compare the effectiveness of different algorithms on the given problem.

* **Typical output**:
  * Evaluation flow is [fully set up](ml-experimentation.md#model-evaluation).
  * Reproducible experiments for the different approaches experimented with.

### Model Productionization

* Taking "experimental" code and preparing it so it can be deployed. This includes data pre-processing, featurization code, training model code (if required to be trained using CI/CD) and model inference code.

* **Typical output**:
  * Production-grade code (Preferrably in the form of a package) for:
    * Data preprocessing / post processing
    * Serving a model
    * Training a model
  * CI/CD scripts.
  * Reproducibility steps for the model in production.
  * See more [here](ml-model-checklist.md).

#### Unit and Integration Testing

* Ensuring that production code behaves in the way we expect it to, and that its results match those we saw during the Model Evaluation and Experimentation phases.
* Refer to [this](ml-testing.md) post for further details.
* **Typical output**: Test suite with unit and end-to-end tests is created and completes successfuly.

#### Deployment

* Responsible AI considerations such as bias and fairness analysis. Additionally, explainability/interpretability of the model should also be considered.
* It is recommended for a human-in-the-loop to verify the model and manually approve deployment to production.
* Getting the model into production where it can start adding value by serving predictions. Typical artifacts are APIs for accessing the model and integrating the model to the solution architecture.
* Additionally, certain scenarios may require training the model periodically in production.
* Reproducibility steps of the production model are available.
* **Typical output**: [model readiness checklist](ml-model-checklist.md) is completed.

#### Monitoring and Observability

* The final phase, where we ensure our model is doing what we expect it to in production.
* Refer to [this](https://github.com/microsoft/code-with-engineering-playbook/blob/master/observability/ml-observability.md) post for further details on observability.
* Refer to [this document](https://docs.microsoft.com/en-us/azure/machine-learning/how-to-enable-data-collection) on Azure ML's offerings around ML models production monitoring.
* It is recommended to consider incorporating data drift monitoring process in the production solution. This will assist in detecting potential changes in new datasets presented for inference that may significantly impact model performance. Refer to [this document](https://docs.microsoft.com/en-us/azure/machine-learning/how-to-monitor-datasets) on Azure ML detect data drift on datasets.
* **Typical output**: Logging and monitoring scripts and tools set up, permissions for users to access monitoring tools.
