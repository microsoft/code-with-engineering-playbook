# Observability in Machine Learning

Development process of software system with machine learning component is more complex
than traditional software. We need to monitor changes and variations in three dimensions:
the code, the model and the data.
We can distinguish two stages of such system lifespan: experimentation and production
that require  different approaches to observability as discussed below:

## Model experimentation and tuning

Experimentation is a process of finding suitable machine learning model and its parameters via training and evaluating such models with one or more datasets.

When developing and tuning machine learning models, the data scientists are interested in observing and comparing selected performance metrics for various model parameters.
They also need a reliable way to reproduce a training process, such that a given dataset and given parameters produces the same models.

There are many model metric evaluation solutions available, both open source (like MLFlow) and proprietary (like Azure Machine Learning Service), and of which some serve different purposes. To capture model metrics, there are a.o. the following options available:

[Azure Machine Learning Service SDK](https://ml.azure.com/)
Azure Machine Learning service provides an SDK for Python, R and C# to capture your evaluation metrics to a Azure Machine Learning service (AML) Experiment. Experiments are viewed in the AML dashboard. Reproducibility is achieved by storing code or notebook snapshot together with viewed metric. You can create versioned Datasets within Azure Machine Learning service.

[MLFlow (for Databricks)](https://docs.microsoft.com/en-us/azure/databricks/applications/mlflow/)
MLFlow is open source framework, and can be hosted on Azure Databricks as its remote tracking server (it currently is the only solution that offers first-party integration with Databricks). You can use the MLFlow SDK tracking component to capture your evaluation metrics or any parameter you would like and track it at experimentation board in Azure Databricks. Source code and dataset version are also saved with log snapshot to provide reproducibility.

[TensorBoard](https://www.tensorflow.org/tensorboard/)
TensorBoard is a popular tool amongst data scientist to visualize specific metrics of Deep Learning runs, especially of TensorFlow runs. TensorBoard is not an MLOps tool like AML/MLFlow, and therefore does not offer extensive logging capabilities. It is meant to be transient; and can therefore be used as an addition to an end-to-end MLOps tool like AML, but not as a complete MLOps tool.

[Application Insights](https://docs.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview)
Application Insights can be used as an alternative sink to capture model metrics, and can therefore offer more extensive options as metrics can be transferred to e.g. a PowerBI dashboard. It also enables log querying. However, this solution means that a custom application needs to be written to send logs to AppInsights (using for example the OpenCensus Python SDK), which would mean extra effort of creating/maintaining custom code.

An extensive comparison of the four tools can be found as follows:

|                           | Azure ML      | MLFlow      | TensorBoard   | Application Insights |
| -----------               | ----------- | ----------- | -----------   | -----------          |
| **Metrics support**       | Values, images, matrices, logs | Values, images, matrices and plots as files | Metrics relevant to DL research phase | Values, images, matrices, logs
| **Customizability**       | Basic | Basic | Very basic | High
| **Metrics accessible**    | AML portal, AML SDK | MLFlow UI, Tracking service API | Tensorboard UI, history object | Application Insights
| **Logs accessible**       | Rolling logs written to .txt files in blob storage, accessible via blob or AML portal. Not query-able | Rolling logs are not stored | Rolling logs are not stored | Application Insights in Azure Portal. Query-able with KQL
| **Ease of use and set up** | Very straightforward, only one portal | More moving parts due to remote tracking server | A bit over process overhead. Also depending on ML framework | More moving parts as a custom app needs to be maintained
| **Shareability** | Across people with access to AML workspace | Across people with access to remote tracking server | Across people with access to same directory | Across people with access to AppInsights

## Model in production

The trained model can be deployed to production as container. Azure Machine Learning service provides SDK to deploy model as Azure Container Instance and publishes REST endpoint. You can monitor it using micro service observability methods( for more details -refer to [Recipes](readme.md) section). MLFLow is an alternative way to deploy ML model as a service.

## Training and re-training

To automatically retrain the model you can use AML Pipelines or Azure Databricks.
When re-training with AML Pipelines you can monitor information of each run, including the output, logs, and various metrics in the Azure portal experiment dashboard, or manually extract it using the AML SDK

## Model performance over time: data drift

We re-train machine learning models to improve their performance and make models better aligned with data changing over time. However, in some cases model performance may degrade. This may happen in case data change dramatically and do not exhibit the patterns we observed during model development any more. This effect is called data drift. Azure Machine Learning Service has preview feature to observe and report data drift.
This [article](https://docs.microsoft.com/en-us/azure/machine-learning/how-to-monitor-datasets) describes it in detail.

## Data versioning

It is recommended practice to add version to all datasets. You can create a versioned Azure ML Dataset for this purpose, or manually version it if using other systems.
