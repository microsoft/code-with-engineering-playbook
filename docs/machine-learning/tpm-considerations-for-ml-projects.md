# TPM considerations for Machine Learning projects

In this document, we explore some of the Program Management considerations for Machine Learning (ML) projects and suggest recommendations for Technical Program Managers (TPM) to effectively work with Data and Applied Machine Learning engineering teams.

## Determine the Need for Machine Learning in the Project

In Artificial Intelligence (AI) projects, the ML component is generally a part of an overall business problem and **NOT** the problem itself. Determine the overall business problem first and then evaluate if ML can help address a part of the problem space.
Few considerations for identifying the right fit for the project:

- Engage experts in human experience and employ techniques such as [Design Thinking](https://www.microsoft.com/en-us/haxtoolkit/ai-guidelines/) and [Problem Formulation](./envisioning-and-problem-formulation.md) to **understand the customer needs** and human behavior first. Identify the right stakeholders from both business and technical leadership and invite them to these workshops. The outcome should be end-user scenarios and [personas](https://en.wikipedia.org/wiki/Persona_(user_experience)) to determine the real needs of the users.

- Focus on [System Design](https://learn.microsoft.com/en-us/azure/architecture/data-guide/big-data/ai-overview) principles to identify the architectural components, entities, interfaces, constraints. Ask the right questions early and explore design alternatives with the engineering team.

- Think hard about the **costs of ML** and whether we are solving a repetitive problem at scale. Many a times, customer problems can be solved with data analytics, dashboards, or rule-based algorithms as the first phase of the project.

### Set Expectations for High Ambiguity in ML components

ML projects can be plagued with a phenomenon we can call as the "**Death by Unknowns**". Unlike software engineering projects, ML focused projects can result in quick success early (aka sudden decrease in error rate), but this may flatten eventually. Few things to consider:

- **Set clear expectations**: Identify the performance metrics and discuss on a "good enough" prediction rate that will bring value to the business. An 80% "good enough" rate may save business costs and increase productivity but if going from 80 to 95% would require unimaginable cost and effort. Is it worth it? Can it be a progressive road map?

- Create a smaller team and **undertake a feasibility analysis** through techniques like [EDA](https://en.wikipedia.org/wiki/Exploratory_data_analysis) (Exploratory Data Analysis). A [feasibility study](./feasibility-studies.md) is much cheaper to evaluate data quality, customer constraints and model feasibility. It allows a TPM to better understand customer use cases and current environment and can act as a fail-fast mechanism. Note that feasibility should be shorter (in weeks) else it misses the point of saving costs.

- As in any project, there will be new needs (additional data sources, technical constraints, hiring data labelers, business users time etc.). Incorporate [Agile](./agile-development-considerations-for-ml-projects.md) techniques to fail fast and minimize cost and schedule surprises.

### Notebooks != ML Production

Notebooks are a great way to kick start Data Analytics and Applied Machine Learning efforts, however for a production releases, additional constraints should be considered:

- Understand the [end-end flow of data management](https://learn.microsoft.com/en-us/azure/architecture/data-guide/big-data/ai-overview), how data will be made available (ingestion flows), what's the frequency, storage, retention of data. Plan user stories and design spikes around these flows to ensure a robust ML pipeline is developed.

- Engineering team should follow the same rigor in building ML projects as in any software engineering project. We at ISE (Industry Solutions Engineering) have built a good set of resources from our learnings in our [ISE Engineering Playbook](../README.md).
- Think about the how the model will be deployed, for example, are there technical constraints due to an edge device, or network constraints that will prevent updating the model. Understanding of the environment is critical, refer to the [Model Production Checklist](./ml-model-checklist.md) as a reference to determine model deployment choices.

- ML Focussed projects are not a "one-shot" release solution, they need to be nurtured, evolved, and improved over time. Plan for a continuous improvement lifecycle, the initial phases can be model feasibility and validation to get the good enough prediction rate, the later phases can be then be scaling and improving the models through feedback loops and fresh data sets.

### Garbage Data In -\> Garbage Model Out

Data quality is a major factor in affecting model performance and production roll-out, consider the following:

- Conduct a [data exploration](./data-exploration.md) workshop and **generate a report on data quality** that includes missing values, duplicates, unlabeled data, expired or not valid data, incomplete data (e.g., only having male representation in a people dataset).

- **Identify data source reliability** to ensure data is coming from a production source. (e.g., are the images from a production or industrial camera or taken from an iPhone/Android phone.)

- **Identify data acquisition constraints**: Determine how the data is being obtained and the constraints around it. Some example may include legal, contractual, Privacy, regulation, ethics constraints. These can significantly slow down production roll out if not captured in the early phases of the project.

- **Determine data volumes**: Identify if we have enough data for sampling the required business use case and how will the data be improved over time. The thumb rule here is that **data should be enough for generalization** to avoid overfitting.

### Plan for Unique Roles in AI projects

An ML Project has multiple stages, and each stage may require additional roles. For example, Design Research & Designers for Human Experience, Data Engineer for Data Collection, Feature Engineering, a Data Labeler for labeling structured data, engineers for MLOps and model deployment and the list can go on. As a TPM, factor in having these resources available at the right time to avoid any schedule risks.

### Feature Engineering and Hyperparameter Tuning

Feature Engineering enables the transformation of data so that it becomes usable for an algorithm. Creating the right features is an art and may require experimentation as well as domain expertise. Allocate time for domain experts to help with improving and identifying the best features. For example, for a natural language processing engine for text extraction of financial documents, we may involve financial researchers and run a [relevance judgment](https://nlp.stanford.edu/IR-book/html/htmledition/information-retrieval-system-evaluation-1.html) exercise and provide a feedback loop to evaluate model performance.

### Responsible AI Considerations

Bias in machine learning could be the number one issue of a model not performing to its intended needs. Plan to incorporate [Responsible AI principles](responsible-ai.md) from Day 1 to ensure fairness, security, privacy and transparency of the models.  For example, for a person recognition algorithm, if the data source is only feeding a specific skin type, then production scenarios may not provide good results.

### PM Fundamentals

Core to a TPM role are the fundamentals that include bringing clarity to the team, design thinking, driving the team to the right technical decisions, managing risk, managing stakeholders, backlog management, project management. **These are a TPM superpowers**. A TPM can complement the machine learning team by ensuring the problem and customer needs are understood, a wholistic system design is evaluated, the stakeholder expectations and driving customer objectives.
Here are some references that may help:

- [The T in a TPM](https://www.linkedin.com/pulse/should-technical-program-manager-tpm-nikhil-sachdeva/)
- [The TPM Don't M\*ck up framework](https://www.linkedin.com/pulse/tpm-dont-mck-up-framework-nikhil-sachdeva/)
- [The mind of a TPM](https://www.linkedin.com/pulse/mind-technical-program-manager-nikhil-sachdeva/)
- [ML Learning Journey for a TPM](https://medium.com/data-science-at-microsoft/the-role-of-a-technical-program-manager-in-ai-projects-8f1ff41905b0)
