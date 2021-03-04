# Data and DataOps fundamentals

Most projects involve some type of data storage, data processing and data ops. For these projects, as with all projects, we follow the general guidelines laid out in other sections around security, testing, observability, CI/CD etc.

## Goal

The goal of this section is to briefly describe how to apply the fundamentals to data heavy projects or portions of the project.

## Contents

- [Data Tiering (Data Quality)](#data-tiering-data-quality)
- [Data Validation](#data-validation)
- [Idempotent Data Pipelines](#idempotent-data-pipelines)
- [Testing](#testing)
- [CI/CD, Source Control and Code Reviews](#cicd-source-control-and-code-reviews)
- [Security and Configuration](#security-and-configuration)
- [Observability](#observability)
- [End to End and Azure Technology Samples](#end-to-end-and-azure-technology-samples)

## Data Tiering (Data Quality)

Develop a common understanding of the quality of your datasets so that everyone understands the quality of the data, and expected use cases and limitations.

A common data quality model is `Bronze`, `Silver`, `Gold`

- **Bronze:** This is a landing area for your raw datasets with no to minimal data transformations applied, and therefore are optimized for writes / ingestion. Treat these datasets as an immutable, append only store.
- **Silver:** These are cleansed, semi-processed datasets. These conform to a known schema and predefined data invariants and might have further data augmentation applied. These are typically used by data scientists.
- **Gold:** These are highly processed, highly read-optimized datasets primarily for consumption of business users. Typically, these are structured in your standard fact and dimension tables.

Divide your data lake into three major areas containing your Bronze, Silver and Gold datasets.

> Note: Additional storage areas for malformed data, intermediate (sandbox) data, and libraries/packages/binaries are also useful when designing your storage organization.

## Data Validation

Validate data early in your pipeline

- Add data validation between the Bronze and Silver datasets. By validating early in your pipeline, you can ensure all datasets conform to a specific schema and known data invariants. This can also potentially prevent data pipeline failures in case of unexpected changes to the input data.
- Data that does not pass this validation stage can be rerouted to a record store dedicated for malformed data for diagnostic purposes.
- It may be tempting to add validation prior to landing in the Bronze area of your data lake. This is generally not recommended. Bronze datasets are there to ensure you have as close of a copy of the source system data. This can be used to replay the data pipeline for both testing (i.e. testing data validation logic) and data recovery purposes (i.e. data corruption is introduced due to a bug in the data transformation code and thus the pipeline needs to be replayed).

## Idempotent Data Pipelines

Make your data pipelines re-playable and idempotent

- Silver and Gold datasets can get corrupted due to a number of reasons such as unintended bugs, unexpected input data changes, and more. By making data pipelines re-playable and idempotent, you can recover from this state through deployment of code fixes, and re-playing the data pipelines.
- Idempotency also ensures data-duplication is mitigated when replaying your data pipelines.

## Testing

Ensure data transformation code is testable

- Abstracting away data transformation code from data access code is key to ensuring unit tests can be written against data transformation logic. An example of this is moving transformation code from notebooks into packages.
- While it is possible to run tests against notebooks, by extracting the code into packages, you increase the developer productivity by increasing the speed of the feedback cycle.

## CI/CD, Source Control and Code Reviews

- All artifacts needed to build the data pipeline from scratch should be in source control. This included infrastructure-as-code artifacts, database objects (schema definitions, functions, stored procedures etc.), reference/application data, data pipeline definitions and data validation and transformation logic.
- Any new artifacts (code) introduced to the repository should be code reviewed, both automatically (linting, credential scanning etc.) and peer reviewed.
- There should be a safe, repeatable process (CI/CD) to move the changes through dev, test and finally production.

## Security and Configuration

- Maintain a central, secure location for sensitive configuration such as database connection strings that can be accessed by the appropriate services within the specific environment.
- On Azure this is typically solved through securing secrets in a Key Vault per environment, then having the relevant services query KeyVault for the configuration

## Observability

Monitor infrastructure, pipelines and data

- A proper monitoring solution should be in-place to ensure failures are identified, diagnosed and addressed in a timely manner. Aside from the base infrastructure and pipeline runs, data should also be monitored. A common area that should have data monitoring is the malformed record store.

## End to End and Azure Technology Samples

The [DataOps for the Modern Data Warehouse repo](https://github.com/Azure-Samples/modern-data-warehouse-dataops) contains both end-to-end and technology specific samples on how to implement DataOps on Azure.

![CI/CD](CI_CD_process.png?raw=true "CI/CD")
Image: CI/CD for Data pipelines on Azure - from DataOps for the Modern Data Warehouse repo
