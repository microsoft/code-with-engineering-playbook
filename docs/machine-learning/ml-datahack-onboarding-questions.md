# Onboarding questions

Below are an example list of questions to send to the customer before starting a [data exploration workshop (data hack)](./ml-data-exploration.md). This helps ensure that we would have access to their resources on time.

## List of questions

1. Is an external customer account needed in order for the Microsoft team to access the data and compute?
2. Are there security requirements around accessing resources (Subscriptions, Azure Resources, project management, etc.) such as VPN, 2FA, jump boxes, etc.?
3. Source data system:
    * Is it on-prem or on Azure already?
    * If it is on-prem, can we move the needed data to Azure under the customers subscription? Will the Microsoft team be able to do so once onboarding is completed, or do we need someone from the customer's team to do that?
4. Computation:
    * Is a VPN needed for the Microsoft team to access these computation nodes (Virtual Machines, Databricks clusters, etc) from Microsoft PCs/Macs?
    * Any restrictions on accessing the source data system from these computation nodes?
    * If we want to create some compute resources, can the Microsoft team do so or does it need to be created by the customers?
        * If we are allowed to do so, we will keep KHC colleagues informed.
5. Data security:
    * Do you allow the Microsoft team to download the data to PCs/Macs within Microsoft CorpNet in order to facilitate the DS work?
        * If yes, we will get your approval before we make any data movement out of the source data system.
6. Source code repository:
    * Do you have any preference on source code repository location?
7. Backlog management and work planning:
    * Do you have any preference on backlog management and work planning, such as Azure DevOps, Jira or anything else?
    * If an existing system, are special accounts / system setups required to access?
8. Programming Language:
    * Is Python/PySpark a preferred language?
    * Is there any customer internal approval process for the Python/PySpark libraries we want to use for this engagement?
