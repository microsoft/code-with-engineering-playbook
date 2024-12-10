# Data Exploration

After [envisioning](./envisioning-and-problem-formulation.md), and typically as part of the [ML feasibility study](./feasibility-studies.md), the next step is to confirm resource access and then dive deep into the available data through data exploration workshops.

## Purpose of the Data Exploration Workshop

The purpose of the data exploration workshop is as follows:

1. Ensure the team can access the data and compute resources that are necessary for the ML feasibility study
1. Ensure that the data provided is of quality and is relevant to the ML solution
1. Make sure that the project team has a good understanding of the data
1. Make sure that the SMEs (Subject Matter Experts) needed are present for Data Exploration Workshop
1. List people needed for the data exploration workshop

## Accessing Resources

Prior to diving into data exploration workshops, it is important to confirm that you have access to the necessary resources (including data).

Below is an **example** list of questions to consider before starting a data exploration workshop.

1. What are the requirements for an account to be set up in order for the team to access data and compute resources?
2. Are there security requirements around accessing resources (Subscriptions, Azure Resources, project management, etc.) such as VPN, 2FA, jump boxes, etc.?
3. Data access:
    * Is it on-prem or on Azure already?
    * If it is on-prem, can we move the needed data to Azure under the appropriate subscription? Who has permission to move the data?
    * Is the data access approved from a legal/compliance perspective?
4. Computation:
    * Is a VPN needed for the project team to access these computation nodes (Virtual Machines, Databricks clusters, etc) from their work PCs/Macs?
    * Any restrictions on accessing the source data system from these computation nodes?
    * If we want to create some compute resources, who has permissions to do so?
5. Source code repository:
    * Do you have any preference on source code repository location?
6. Backlog management and work planning:
    * Do you have any preference on backlog management and work planning, such as Azure DevOps, Jira or anything else?
    * If an existing system, are special accounts / system setups required to access?
7. Programming Language:
    * Is Python/PySpark a preferred language?
    * Is there any internal approval processes for the Python/PySpark libraries we want to use for this engagement?

## Data Exploration Workshop

Key objectives of the exploration workshops include the following:

1. Understand and document the features, location, and availability of the data.
2. What order of magnitude is the current data (e.g., GB, TB)? Is this all relevant?
3. How does the organization decide when to collect additional data or purchase external data? Are there any examples of this?
4. Understand the quality of the data. Is there already a data validation strategy in place?
5. What data has been used so far to analyze recent data-driven projects? What has been found to be most useful? What was not useful? How was this judged?
6. What additional internal data may provide insights useful for data-driven decision-making for proposed projects? What external data could be useful?
7. What are the possible constraints or challenges in accessing or incorporating this data?
8. How was the data collected? Are there any obvious biases due to how the data was collected?
9. What changes to data collection, coding, integration, etc has occurred in the last 2 years that may impact the interpretation or availability of the collected data
