# Privacy related frameworks

The following tools/frameworks could be leveraged when data analysis or model development needs to take place on private data.
Note that the use of such frameworks still requires the solution to adhere to privacy regulations and others, and additional safeguards should be applied.

## Typical scenarios for leveraging a Privacy framework

- Sharing data or results while preserving data subjects' privacy
- Performing analysis or statistical modeling on private data
- Developing privacy preserving ML models and data pipelines

## Privacy frameworks

Protecting private data involves the entire data lifecycle, from acquisition, through storage, processing, analysis, modeling and usage in reports or machine learning models. Proper safeguards and restrictions should be applied in each of these phases.

In this section we provide a **non-exhaustive list** of privacy frameworks which can be leveraged for protecting and preserving privacy.

We focus on four main use cases in the data lifecycle:

1. [Obtaining non-sensitive data](#obtaining-non-sensitive-data)
2. [Establishing trusted research and modeling environments](#trusted-research-and-modeling-environments)
3. [Creating privacy preserving data and ML pipelines](#privacy-preserving-data-pipelines-and-ml)
4. [Data loss prevention](#data-loss-prevention)

### Obtaining non-sensitive data

In many scenarios, analysts, researchers and data scientists require access to a non-sensitive version or sample of the private data.
In this section we focus on two approaches for obtaining non-sensitive data.

**Note:** These two approaches do not guarantee that the outcome would not include private data, and additional measures should be applied.

#### Data de-identification

De-identification is the process of applying a set of transformations to a dataset,
in order to lower the risk of unintended disclosure of personal data.
De-identification involves the removal or substitution of both direct identifiers (such as name, or social security number) or quasi-identifiers,
which can be used for re-identification using additional external information.

De-identification can be applied to different types of data, such as structured data, images and text.
However, de-identification of non-structured data often involves statistical approaches which might result in undetected PII (Personal Identifiable Information) or non-private information being redacted or replaced.

Here we outline several de-identification solutions available as open source:

| Solution                                                                                  | Notes                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
|-------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [Presidio](https://microsoft.github.io/presidio)                                          | Presidio helps to ensure sensitive data is properly managed and governed. It provides fast identification and anonymization modules for private entities in text such as credit card numbers, names, locations, social security numbers, bitcoin wallets, US phone numbers, financial data and more in unstructured text and images. It's useful when high customization is required, for example to detect custom PII entities or languages. [Link to repo](https://aka.ms/presidio), [link to docs](https://microsoft.github.io/presidio), [link to demo](https://aka.ms/presidio-demo). |
| [FHIR tools for anonymization](https://github.com/microsoft/FHIR-Tools-for-Anonymization) | FHIR Tools for Anonymization is an open-source project that helps anonymize healthcare FHIR data (FHIR=Fast Healthcare Interoperability Resources, a standard for exchanging Electric Health Records), on-premises or in the cloud, for secondary usage such as research, public health, and more. [Link](https://github.com/microsoft/FHIR-Tools-for-Anonymization). Works with FHIR format (Stu3 and R4), allows different strategies for anonymization (date shift, crypto-hash, encrypt, substitute, perturb, generalize)                                                              |
| [ARX](https://arx.deidentifier.org/)                                                      | Anonymization using statistical models, specifically k-anonymity, ℓ-diversity, t-closeness and δ-presence. Useful for validating the anonymization of aggregated data. Links: [Repo](https://github.com/arx-deidentifier/arx), [Website](https://arx.deidentifier.org/). Written in Java.                                                                                                                                                                                                                                                                                                  |
| [k-Anonymity](https://github.com/Nuclearstar/K-Anonymity)                                 | GitHub repo with examples on how to produce k-anonymous datasets. k-anonymity protects the privacy of individual persons by pooling their attributes into groups of at least *k* people. [repo](https://github.com/Nuclearstar/K-Anonymity/blob/master/k-Anonymity.ipynb)                                                                                                                                                                                                                                                                                                                  |

#### Synthetic data generation

A synthetic dataset is a repository of data generated from actual data and has the same statistical properties as the real data.
The degree to which a synthetic dataset is an accurate proxy for real data is a measure of utility.
The potential benefit of such synthetic datasets is for sensitive applications – medical classifications or financial modelling, where getting hands on a high-quality labelled dataset is often prohibitive.

When determining the best method for creating synthetic data, it is essential first to consider what type of synthetic data you aim to have. There are two broad categories to choose from, each with different benefits and drawbacks:

- Fully synthetic: This data does not contain any original data, which means that re-identification of any single unit is almost impossible, and all variables are still fully available.
- Partially synthetic: Only sensitive data is replaced with synthetic data, which requires a heavy dependency on the imputation model. This leads to decreased model dependence but does mean that some disclosure is possible due to the actual values within the dataset.

| Solution                                                                                                                        | Notes                                                                                                                                                                                                                                                                                                                                                                                                                                            |
|---------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [Synthea](https://synthetichealth.github.io/synthea/)                                                                           | Synthea was developed with numerous data sources collected on the internet, including US Census Bureau demographics, Centers for Disease Control and Prevention prevalence and incidence rates, and National Institutes of Health reports. The source code and disease models include annotations and citations for all data, statistics, and treatments. These models of diseases and treatments interact appropriately with the health record. |
| [PII dataset generator](https://github.com/microsoft/presidio-research/blob/master/presidio_evaluator/data_generator/README.md) | A synthetic data generator developed on top of Fake Name Generator which takes a text file with templates (e.g. my name is *PERSON*) and creates a list of Input Samples which contain fake PII entities instead of placeholders.                                                                                                                                                                                                                |
| [CheckList](https://github.com/marcotcr/checklist)                                                                              | CheckList provides a framework for perturbation techniques to evaluate specific behavioral capabilities of NLP models systematically                                                                                                                                                                                                                                                                                                             |
| [Mimesis](https://github.com/lk-geimfari/mimesis)                                                                               | Mimesis a high-performance fake data generator for Python, which provides data for a variety of purposes in a variety of languages.                                                                                                                                                                                                                                                                                                              |
| [Faker](https://github.com/joke2k/faker)                                                                                        | Faker is a Python package that generates fake data for you. Whether you need to bootstrap your database, create good-looking XML documents, fill-in your persistence to stress test it, or anonymize data taken from a production service, Faker is for you.                                                                                                                                                                                     |
| [Plaitpy](https://github.com/plaitpy/plaitpy)                                                                                   | The idea behind plait.py is that it should be easy to model fake data that has an interesting shape. Currently, many fake data generators model their data as a collection of IID variables; with plait.py we can stitch together those variables into a more coherent model.                                                                                                                                                                    |

### Trusted research and modeling environments

#### Trusted research environments

Trusted Research Environments (TREs) enable organizations to create secure workspaces for analysts,
data scientists and researchers who require access to sensitive data.

TREs enforce a secure boundary around distinct workspaces to enable information governance controls.
Each workspace is accessible by a set of authorized users, prevents the exfiltration of sensitive data,
and has access to one or more datasets provided by the data platform.

We highlight several alternatives for Trusted Research Environments:

| Solution                                                                                                                            | Notes                         |
|-------------------------------------------------------------------------------------------------------------------------------------|-------------------------------|
| [Azure Trusted Research Environment](https://github.com/microsoft/azuretre)                                                         | An Open Source TRE for Azure. |
| [Aridhia DRE](https://appsource.microsoft.com/en-us/product/web-apps/aridhiainformatics.analytixagility_workspace_123?tab=Overview) |                               |

#### Eyes-off machine learning

In certain situations, Data Scientists may need to train models on data they are not allowed to see. In these cases, an "eyes-off" approach is recommended.
An eyes-off approach provides a data scientist with an environment in which scripts can be run on the data but direct access to samples is not allowed.
When using Azure ML, tools such as the [Identity Based Data Access](https://learn.microsoft.com/en-us/azure/machine-learning/how-to-identity-based-data-access) can enable this scenario,
alongside proper role assignment for users.

During the processing within the eyes-off environment, only certain outputs (e.g. logs) are allowed to be extracted back to the user.
For example, a user would be able to submit a script which trains a model and inspect the model's performance, but would not be able to see on which samples the model predicted the wrong output.

In addition to the eyes-off environment, this approach usually entails providing access to an "eyes-on" dataset, which is a representative, cleansed, sample set of data for model design purposes.
The Eyes-on dataset is often a de-identified subset of the private dataset, or a synthetic dataset generated based on the characteristics of the private dataset.

#### Private data sharing platforms

Various tools and systems allow different parties to share data with 3rd parties while protecting private entities, and securely process data while reducing the likelihood of data exfiltration.
These tools include [Secure Multi Party Computation (SMPC)](https://en.wikipedia.org/wiki/Secure_multi-party_computation) systems,
[Homomorphic Encryption](#homomorphic-encryption) systems, [Confidential Computing](https://azure.microsoft.com/en-us/solutions/confidential-compute/),
private data analysis frameworks such as [PySift](https://github.com/OpenMined/PySyft) among others.

### Privacy preserving data pipelines and ML

Even when our data is secure, private entities can still be extracted when the data is consumed.
Privacy preserving data pipelines and ML models focus on minimizing the risk of private data exfiltration during data querying or model predictions.

#### Differential Privacy

Differential privacy (DP) is a system that enables one to extract meaningful insights from datasets about subgroups of people, while also providing strong guarantees with regards to protecting any given individual's privacy.
This is typically achieved by adding a small statistical noise to every individual's information,
thereby introducing uncertainty in the data.
However, the insights gleaned still accurately represent what we intend to learn about the population in the aggregate.
This approach is known to be robust to re-identification attacks and data reconstruction by adversaries who possess auxiliary information.
For a more comprehensive overview,
check out [Differential privacy: A primer for a non-technical audience](https://dash.harvard.edu/bitstream/handle/1/38323292/4_Wood_Final.pdf?sequence=1&isAllowed=y).

DP has been widely adopted in various scenarios such as learning from census data, user telemetry data analysis, audience engagement to advertisements, and health data insights where PII protection is of paramount importance. However, DP is less suitable for small datasets.

Tools that implement DP include [SmartNoise](https://github.com/opendifferentialprivacy/smartnoise-samples), [Tensorflow Privacy](https://github.com/tensorflow/privacy) among some others.

#### Homomorphic Encryption

Homomorphic Encryption (HE) is a form of encryption allowing one to perform calculations on encrypted data without decrypting it first.
The result of the computation *F* is in an encrypted form, which on decrypting gives us the same result if computation *F* was done on raw unencrypted data.
([source](https://en.wikipedia.org/wiki/Homomorphic_encryption#:~:text=Homomorphic%20encryption%20is%20a%20form,performed%20on%20the%20unencrypted%20data.))

Homomorphic Encryption frameworks:

| Solution                                                                          | Notes                                                                                                                                                                                                                                                                                    |
|-----------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [Microsoft SEAL](https://www.microsoft.com/en-us/research/project/microsoft-seal) | Secure Cloud Storage and Computation, ML Modeling. A widely used open-source library from Microsoft that supports the BFV and the CKKS schemes.                                                                                                                                          |
| [Palisade](https://palisade-crypto.org/)                                          | A widely used open-source library from a consortium of DARPA-funded defense contractors that supports multiple homomorphic encryption schemes such as BGV, BFV, CKKS, TFHE and FHEW, among others, with multiparty support. [Link to repo](https://gitlab.com/palisade/palisade-release) |
| [PySift](https://github.com/OpenMined/PySyft) | Private deep learning. PySyft decouples private data from model training, using Federated Learning, Differential Privacy, and Encrypted Computation (like Multi-Party Computation (MPC) and Homomorphic Encryption (HE)) within the main Deep Learning frameworks like PyTorch and TensorFlow.

A list of additional OSS tools can be found [here](https://homomorphicencryption.org/introduction/).

#### Federated learning

Federated learning is a Machine Learning technique which allows the training of ML models in a decentralized way without having to share the actual data.
Instead of sending data to the processing engine of the model, the approach is to distribute the model to the different data owners and perform training in a distributed fashion.

Federated learning frameworks:

| Solution                                                                 | Notes                                                                                                                          |
|--------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------|
| [TensorFlow Federated Learning](https://github.com/tensorflow/federated) | OSS federated learning system built on top of TensorFlow                                                                       |
| [FATE](https://fate.fedai.org/)                                          | An OSS federated learning system with different options for deployment and different algorithms adapted for federated learning |
| [IBM Federated Learning](https://github.com/IBM/federated-learning-lib)  | A Python based federated learning framework focused on enterprise environments.                                                |

### Data loss prevention

Organizations have sensitive information under their control such as financial data, proprietary data, credit card numbers, health records, or social security numbers.
To help protect this sensitive data and reduce risk, they need a way to prevent their users from inappropriately sharing it with people who shouldn't have it.
This practice is called [data loss prevention (DLP)](https://learn.microsoft.com/en-us/microsoft-365/compliance/dlp-learn-about-dlp).

Below we focus on two aspects of DLP: Sensitive data classification and Access management.

#### Sensitive data classification

Sensitive data classification is an important aspect of DLP, as it allows organizations to track, monitor, secure and identify sensitive and private data.
Furthermore, different sensitivity levels can be applied to different data items, facilitating proper governance and cataloging.

There are typically four levels data classification levels:

1. Public
2. Internal
3. Confidential
4. Restricted / Highly confidential

Tools for data classification on Azure:

| Solution                                                                                                                                                                                                       | Notes                                                                                                                                                                               |
|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [Microsoft Information Protection](https://learn.microsoft.com/en-us/microsoft-365/compliance/information-protection) (MIP)                                                                                    | A suite for DLP, sensitive data classification, cataloging  and more.                                                                                                               |
| [Azure Purview](https://azure.microsoft.com/en-us/services/purview/)                                                                                                                                           | A unified data governance service, which includes the classification and cataloging of sensitive data. Azure Purview leverages the MIP technology for data classification and more. |
| [Data Discovery & Classification for Azure SQL Database, Azure SQL Managed Instance, and Azure Synapse](https://learn.microsoft.com/en-us/azure/azure-sql/database/data-discovery-and-classification-overview) | Basic capabilities for discovering, classifying, labeling, and reporting the sensitive data in Azure SQL and Synapse databases.                                                     |
| [Data Discovery & Classification for SQL Server](https://learn.microsoft.com/en-us/sql/relational-databases/security/sql-data-discovery-and-classification?view=sql-server-ver15&tabs=t-sql)                   | Capabilities for discovering, classifying, labeling & reporting the sensitive data in SQL Server databases.                                                                         |

Often, tools used for de-identification can also serve as sensitive data classifiers. Refer to [de-identification tools](#data-de-identification) for such tools.

Additional resources:

- [Example guidelines for data classification](https://www.cmu.edu/iso/governance/guidelines/data-classification.html)
- [Learn about sensitivity levels](https://learn.microsoft.com/en-us/microsoft-365/compliance/sensitivity-labels?view=o365-worldwide)

#### Access management

Access control is an important component of privacy by design and falls into overall data lifecycle protection.
Successful access control will restrict access only to authorized individuals that should have access to data.
Once data is secure in an environment, it is important to review who should access this data and for what purpose.
Access control may be audited with a comprehensive logging strategy which may include the integration of [activity logs](https://learn.microsoft.com/en-us/azure/azure-monitor/platform/platform-logs-overview) that can provide insight into operations performed on resources in a subscription.

- [OWASP Access Control Cheat Sheet](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Access_Control_Cheat_Sheet.md)
