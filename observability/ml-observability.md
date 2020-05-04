# Observability in Machine Learning  

Development process of software system with machine learning component is more complex.
as such systems change in three directions, the model, the code and the data.
As ml model is implemented in some computer language, for example Python, for code standard unit test approach is applicable to test that code works correctly given sample data set in certain format.
There is more to monitor for ml models and data.

We can distinguish 2 stages of such system lifespan: experimentation stage and production stage.
Both stages require monitoring and logging, but in slightly differently.
Let us consider those stage observability.

## Model experimentation and tuning : logging and dashboard  

Experimentation stage is stage of fingins tuning ml model. tying out different models etc. This

here is about metrics logging, comparison various models, dashboards.

When developing and tuning machine learning models data scientist experiments with various parameters
and model performance metrics.
Tools that facilitate team of data scientists to observe and share modelling results are.

[MLFlow for Databricks](https://docs.microsoft.com/en-us/azure/databricks/applications/mlflow/)
Here is best practice to observe model behaiviour using MLFlow

[Azure Machine learning Service](https://ml.azure.com/)
Here is best practice to observe model behaiviour using AML  

## Model experimentation and tuning: reproducibility  

Here is about reproducible experimenation>  

## Model in production

## Model performance over time: data drift  

In re-tranining scenario model behaviour may degrade due to changes in data.
Here is how to observe and report model performance in production.

    Model deployment:
    Deployed as dependency (pickle file)  
    Deployed as service

## Data versioning  
