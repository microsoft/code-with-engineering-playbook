# The role of a TPM in AI projects?

In this document, we explore some of the Program Management considerations for Machine Learning (ML) projects and suggest recommendations for Technical Program Managers (TPM) to effectively work with Data engineering teams.

## Is it an AI problem?

In Artificial Intelligence (AI) projects, the ML component is generally a part of an overall business problem and **NOT** the problem itself. Few considerations for identifying the right fit for your project:

- Determine the value for Machine Learning within the larger scope of a project. Think about the overall business problem first and then evaluate if ML can help address a part of the problem space.

- Engage experts in human experience and employ techniques such as [Design Thinking](https://www.ideou.com/blogs/inspiration/what-is-design-thinking) to **understand the customer needs** and human behavior first. For example, if your customer wants to talk about [Topic Modeling](https://en.wikipedia.org/wiki/Topic_model) instead of [Personas](https://en.wikipedia.org/wiki/Persona_(user_experience)), you are having the wrong conversation.

- Focus on **System Design** principles to identify the architectural components, entities, interfaces, constraints. Ask the right questions early and explore design alternatives with the engineering team.

- Think hard about the **costs of ML** and whether you can solve a repetitive problem at scale. Many a times, you can solve customer problems with data analytics, dashboards, or rule-based algorithms.

### Taming the ambiguity beast

ML projects can be plagued with a phenomenon we can call as the "**Death by Unknowns**". Unlike software engineering projects, ML focused projects can result in quick success early (aka sudden decrease in error rate), but this may flatten eventually. Few things to consider:

- **Set clear expectations**: Identify the performance metrics and discuss on a "good enough" prediction rate that will bring value to the business. An 80% "good enough" rate may save business costs and increase productivity but if going from 80 to 95% would require unimaginable amount of cost and effort. Is it worth it? Can it be a progressive road map?
  
- Create a smaller team and **undertake a feasibility analysis** through techniques like [EDA](https://en.wikipedia.org/wiki/Exploratory_data_analysis) (Exploratory Data Analysis). A [feasibility study](https://microsoft.github.io/code-with-engineering-playbook/machine-learning/ml-feasibility-study/) is much cheaper to evaluate data quality, customer constraints and model feasibility. It allows a TPM to better understand customer use cases and current environment and can act as a fail-fast mechanism. Note that feasibility should be shorter (in weeks) else it misses the point of saving costs.

- As in any project, there will be new needs (additional data sources, technical constraints, hiring data labelers, business users time etc.). Incorporate [Agile](/docs/machine-learning/ml-project-management.md) techniques to fail fast and minimize cost and schedule surprises.

### Notebooks != ML Production

Notebooks are a great way to kick start Data Analytics and Applied Machine Learning efforts, however for a production releases, additional constraints should be considered: 

- Understand the **end-end flow of data management**, how data will be made available (ingestion flows), what's the frequency, storage, retention of data. Plan user stories and spikes around these flows to ensure you are building a robust ML pipeline and not a ML demo.

- Your engineering team should follow the same rigor in building ML projects as in any software engineering project. We at CSE (Commercial Software Engineering) have built a good set of resources from our learnings in our [engineering playbook](https://microsoft.github.io/code-with-engineering-playbook/).
- Think about the how the model will be deployed, for example, do you have technical constraints on the an edge device, or network constraints that will prevent updating the model. Understanding of the environment is critical, refer to the [Model Production Checklist](/docs/machine-learning/ml-model-checklist.md) as a reference to determine you model deployment choices.

- ML Focussed projects are not a "one-shot" release solution, they need to be nurtured, evolved, and improved over time. Plan for a continuos improvement lifecycle, the initial phases can be model feasibility and validation to get the good enough prediction rate, the later phases can be then be scaling and improving the models through feedback loops and fresh data sets.

### Garbage Data In -\> Garbage Model Out

Data quality is a major factor in affecting model performance. When managing an AI project, work with your engineering team on following:

- During feasibility, have your team **generate a report on data quality** that includes missing values, duplicates, unlabeled data, expired or not valid data, incomplete data (e.g., only having male representation in a people dataset).

- **Understand data source reliability** (e.g., are the images from a production or industrial camera or taken from an iPhone)

- **Understand data acquisition constraints** (legal, contractual, Privacy, regulation, ethics) before leveraging the data sets.

- Identify if we have enough data for sampling the required business use case and how will the data be improved over time. The thumb rule here is that **data should be enough for generalization** to avoid overfitting.

### Plan for Unique Roles in AI projects

An ML Project has multiple stages, and each stage may require additional roles. For example, Design Research & Designers for Human Experience, Data Engineer for Data Collection, Feature Engineering, a Data Labeler for labeling structured data, engineers for MLOps and model deployment and the list can go on. As a TPM, factor in having these resources available at the right time to avoid any schedule risks.

### Feature Planning and Tuning

Feature Engineering enables the transformation of data so that it becomes usable for an algorithm. Creating the right features is an art and may require experimentation as well as domain expertise. Allocate time for domain experts to help with improving and identifying the best features. For example, for a natural language processing engine for text extraction of financial documents, you may involve financial researchers can run a relevance judgment exercise and provide a feedback loop to evaluate model performance.

### Responsible AI considerations

Bias in machine learning could be the number one issue of a model not performing to its intended needs. Plan to incorporate [Responsible AI principles](/docs/machine-learning/responsible-ai.md) from Day 1 to ensure fairness, security, privacy and transparency of the models.  For example, for a person recognition algorithm, if the data source is only feeding a specific skin type, then production scenarios may not provide good results.
