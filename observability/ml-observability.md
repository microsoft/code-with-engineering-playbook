# Observability in Machine Learning  

Development process of software system with machine learning component is more complex
than traditional software as such systems change in three directions: the code, the model and the data.
We can distinguish 2 stages of such system lifespan: experimentation and production.
Both stages require specific approach to observability that we will discuss below:

## Model experimentation and tuning

Experimentation is a process of finding suitable machine learning model and its parameters via training and evaluating such models with one or more data sets.
When developing and tuning machine learning models data scientist or team of data scientists experiment
with various parameters and models. Team is interested to observe and compare chosen performance metrics and be able to reproduce machine learning model, i.e. re-run training process with given dataset and parameters and produce the same model.

The following tools are available to monitor model development process:

[MLFlow for Databricks](https://docs.microsoft.com/en-us/azure/databricks/applications/mlflow/)
MLFlow is open source framework that can be hosted on Azure Databricks. You can use MLFlow SDK to log your evaluation metrics or any parameter you would like and track it at experimentation board in Azure Databricks.
Source code and dataset version are also saved with log snapshot to provide reproducibility.

[Azure Machine Learning Service](https://ml.azure.com/)
Azure Machine Learning service provides SDK for Python, R and C#  to log your evaluation metrics to AML Experiment. Experiments are viewed in AML dashboard. Reproducibility is achived by storing code or notebook
snapshot together with viewed metric. You can create versioned Datasets within Azure Machine Learning service.

## Model in production

Trained model can be deployed to production as container. Azure Machine Learning service provides SDK to deploy model as Azure Container Instance and publishes REST endpoint. You can monitor it using microservice observability methods.
MLFLow is alternative way to deploy ML model as a service.

## Training and re-training

To automatically retrain the model you can use AML Pipelines or Azure Databricks.
When re-training with AML Pipelines you can monitor full information of each run including
output,log and metric in the Azure portal experiment dashboard or manually extract it using SDK.

## Model performance over time: data drift  

We re-train machine learning models to improve its performance and make models better aligned with data changing over time. However, in some cases model performance may degrade. This may happen in case data change dramatically and do not expose pattern we observed during model development any more. This effect is called data drift.
AML has preview feature to observe and report data drift.
This [article](https://docs.microsoft.com/en-us/azure/machine-learning/how-to-monitor-datasets) describes it in detail.

## Data versioning  

It is recommended practice to add version to all datasets. Create Azure Ml Dataset with version for AML environment for this purpose.
Use manual versioning in other systems.
