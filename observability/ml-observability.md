# Observability in Machine Learning  

Development process of software system with machine learning component is more complex
than traditional software. We need to monitor changes and variations in three dimentions:
the code, the model and the data.
We can distinguish two stages of such system lifespan: experimentation and production
that require  different approaches to observability as discussed below:

## Model experimentation and tuning

Experimentation is a process of finding suitable machine learning model and its parameters via training and evaluating such models with one or more datasets.

When developing and tuning machine learning models, the data scientists are interested in observing and comparing selected performance metrics for various model parameters.
They also need a reliable way to reproduce a training process, such that a given dataset and given parameters produces the same models.

The following tools are available to monitor model development process:

[MLFlow for Databricks](https://docs.microsoft.com/en-us/azure/databricks/applications/mlflow/)
MLFlow is open source framework that can be hosted on Azure Databricks. You can use MLFlow SDK to log your evaluation metrics or any parameter you would like and track it at experimentation board in Azure Databricks.
Source code and dataset version are also saved with log snapshot to provide reproducibility.

[Azure Machine Learning Service](https://ml.azure.com/)
Azure Machine Learning service provides SDK for Python, R and C#  to log your evaluation metrics to Azure Machine Learning service(AML) Experiment. Experiments are viewed in AML dashboard. Reproducibility is achived by storing code or notebook snapshot together with viewed metric. You can create versioned Datasets within Azure Machine Learning service.

## Model in production

The trained model can be deployed to production as container. Azure Machine Learning service provides SDK to deploy model as Azure Container Instance and publishes REST endpoint. You can monitor it using microservice observability methods( for more detailes -refer to [Recipes](readme.md) section). MLFLow is an alternative way to deploy ML model as a service.

## Training and re-training

To automatically retrain the model you can use AML Pipelines or Azure Databricks.
When re-training with AML Pipelines you can monitor information of each run, including the output, logs, and various metrics in the Azure portal experiment dashboard, or manually extract it using the AML SDK

## Model performance over time: data drift  

We re-train machine learning models to improve their performance and make models better aligned with data changing over time. However, in some cases model performance may degrade. This may happen in case data change dramatically and do not exhibit the patterns we observed during model development any more. This effect is called data drift. Azure Machine Learning Service has preview feature to observe and report data drift.
This [article](https://docs.microsoft.com/en-us/azure/machine-learning/how-to-monitor-datasets) describes it in detail.

## Data versioning  

It is recommended practice to add version to all datasets. You can create a versioned Azure ML Dataset for this purpose, or manually version it if using other systems.
