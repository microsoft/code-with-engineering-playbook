# Discovery
##### Envisioning and Problem Formulation

Before beginning a data science investigation, we need to define a problem statement which the data science team can explore; this problem statement can have a significant influence on whether the project is likely to be successful.

## Discovery goals

The main goals of the discovery process are:
*	Establish existing understanding of the problem domain and the underlying business objectives
*	Examine the nature and dimensions of the problem domain, and reframe where relevant to ensure appropriate problem scoping 
*	State how potential hypothesized solutions might interface with the existing context, and how their performance might be measured
*	Determine what data is available to solve the problem, as well as the availability, preparedness, and origin of that data. Special care should be taken to understand how the data is collected, and if any potential bias or framing might be affecting it.
*	Understand the capabilities and working practices of  the combined team of data scientists, designers and researchers involved in the project.¬¬
*	Ensure all parties have the same understanding of the scope and next steps (e.g., onboarding, data exploration workshop)

The Discovery phase seeks to understand the social, technical, and organizational aspects of a problem space, with deep attention paid to potential users and people impacted by a Machine Learning solution. This is particularly important in AI projects given the amplification and acceleration of bias and error inherent in this type of technology. Focusing on the social, technical, and organizational aspects helps to create an awareness of the opportunities and constraints of possible future scenarios and solutions. 
Partnering with Human-Centered Researchers and Designers during Discovery activities helps to ensure time and focus is dedicated to the non-technical, but highly influential factors that can impact the success of future solutions. Discovery is more comprehensive and reliable when diverse perspectives are included in the process, with focus on needs beyond technical requirements. It is a necessary step to create an understanding amongst all contributing disciplines to work through realistic goals and measures for evaluating a potential solution.


## Understanding the problem domain

Generally, before defining a project scope for a data science investigation, we must first understand the problem domain:

* What is the problem as understood by those proposing a solution?
*	What are the business, stakeholder and user contexts in which the problem resides?
*	Why does the problem need to be solved?
*	Could the problem benefit from a machine learning solution?
*	How would a potential solution be used?


However, establishing this understanding can prove difficult, especially for those unfamiliar with the problem domain. To ease this process, we can approach problems in a structured way by taking the following steps:  

*	Uncover and articulate the terminology roles, goals, concepts, and other relevant forces at play within the problem context that affect or relate to the problem at hand. If significant contextual knowledge gaps are identified or suspected to exist, document them and engage the HX Research team for assistance.
*	Identify a measurable problem and define this in business terms. The objective should be clear, and we should have a good understanding of the factors that we can control - that can be used as inputs - and how they affect the objective. Be as specific as possible.
*	Decide how the success of a future solution should be measured and identify whether this is possible within the restrictions of the problem space and the context of the engagement as a whole. Make sure it aligns with the business objective and that you have identified the data required to evaluate the solution. Note that the data required to evaluate a solution may differ from the data needed to create a solution.
*	Thinking about the future solution as a black box, detail the function that a solution to this problem may perform to fulfil the objective and verify that the relevant data is available to solve the problem.
**	One way of approaching this is by interviewing a subject-matter expert who solves the problem manually, and the data that is required to do so; if a human subject-matter expert is unable to solve the problem given the available data, this is indicative that additional information is required and/or more data needs to be collected.
*	Based on the available data, define specific hypothesis statements - which can be proved or disproved - to guide the exploration of the data science team. Where possible, each hypothesis statement should have a clearly defined success criteria (e.g., with an accuracy of over 60%), however, this is not always possible - especially for projects where no solution to the problem currently exists. In these cases, the measure of success could be based on a subject-matter expert verifying that the results meet their expectations.
*	Document all the above information, to ensure alignment between stakeholders and establish a clear understanding of the problem to be solved. Try to ensure that as much relevant domain knowledge is captured as possible, and that the features present in available data - and the way that the data was collected - are clearly explained, such that they can be understood by a non-subject matter expert.


Once an understanding of the problem domain has been established, it may be necessary to break down the overall problem into smaller, meaningful chunks of work to maintain team focus and ensure a realistic project scope within the given time frame.

## Learning from people affected by the solution

These problems are complex and require understanding from a variety of perspectives. It is not uncommon for the engagement stakeholders to not be wholly representative of those who will use or be affected by the outcomes of the solution framework. In these cases, engaging the affected people in research efforts is critical to the success of the project. Informing our approach with the sociotechnical context of those affected will allow for reduction of risk, increased alignment to business value, improved user adoption and higher chances of long-term customer success.

The following questions can help guide discussion in understanding the stakeholders' perspectives:

*	Who are the people affected by the outcomes of the proposed system? (These may not be just end users)
*	What is the current practice related to the business problem?
*	What are the local initiatives related to the current problem statement? How can we learn from, leverage, and build on those efforts?
*	What is the current solution? How does it perform?
*	What opportunities or untapped potential exists in the problem space? 
*	What are the frictions experienced by people who are affected by the problem today?
*	What are the most consistent or pressing challenges related to the problem?
*	What is the state of the data used to build the solution?
*	How does the end user or SME envision the solution?


## Envisioning Phase

During the envisioning phase and related efforts, the following guides may prove useful for directing the discussion and activities, as well as identifying and coordinating with key resources on the project. Many of these points are taken directly, or adapted from, [[1]](#references) and [[2]](#references).

### Problem Framing & Hypothesis Generation

1. Define the objective in business terms, if there is a lack of consensus re-visit previous work undertaken to achieve this objective definition, and consider any new information or perspectives brought forward.
2. Review the understanding of the problem context that was gathered through research and sensemaking activities prior to the workshop, including but not limited to:
   0.	History of the problem
   1.	Human context and impact
   2.	Social and organizational context
   3.	Potential impact of intended outcomes
3. What are the current solutions/workarounds (if any). Is it possible to solve manually? How?
4. Review the work that has been done in this area so far.
5. Identify if this solution needs to fit into existing business IT/production systems.
6. Identify the existing or proposed business processes that this solution must fit within.
7. Determine how performance should be measured.
8. Confirm the performance measure is aligned with the business objective.
9. Define the minimum performance needed to reach the business objective.
10. Identify any known constraints around non-functional requirements that would have to be considered. (e.g., computation times)
11. Provide a framing for this problem based on understanding from discovery activities and participant input (supervised/unsupervised, online/offline, etc.)
12. Identify if human expertise is available.
13. Identify any restrictions on the type of approaches which can be used? (e.g., does the solution need to be completely explainable?)
14. List the assumptions you or others have made so far. Verify these assumptions if possible.
15. Define some initial hypothesis statements to be explored.
16. Highlight and discuss any responsible AI concerns.
17. Sketch, Define, or otherwise Articulate potential solutions which might be explored.

### Project Coordination

1. What data science skills exist in the organization?
2. How many data scientists/engineers would be available to work on this project? In what capacity would these resources be available (full-time, part-time, etc.)?
3. What does the team's current workflow practices look like? Do they work on the cloud/on-prem? In notebooks/IDE? Is version control used?
4. How are data, experiments and models currently tracked?
5. Does the team employ an Agile methodology? How is work tracked?
6. Are there any ML solutions currently running in production? Who is responsible for maintaining these solutions?
7. Who would be responsible for maintaining a solution produced during this project?
8. Are there any restrictions on tooling that must/cannot be used?
9. Who closest to the problem context can serve as the human experience research sponsor?
10.	Which stakeholders, users and subject matter experts may we need to learn from?
11.	What is the availability of stakeholders, users and subject matter experts for human experience research participation?


## Example - a recommendation engine problem

To illustrate how the above process can be applied to a tangible problem domain, as an example, consider that we are looking at implementing a recommendation engine for a clothing retailer. This example was, in part, inspired by [[3]](#references).

Often, the objective may be simply presented, in a form such as "to improve sales". However, whilst this is ultimately the main goal, we would benefit from being more specific here. Suppose that we were to deploy a solution in November and then observed a December sales surge; how would we be able to distinguish how much of this was as a result of the new recommendation engine, as opposed to the fact that December is a peak buying season?

A better objective, in this case, would be "to drive additional sales by presenting the customer with items that they *would not otherwise have purchased without the recommendation*". Here, the inputs that we can control are the choice of items that are presented to each customer, and the order in which they are displayed; considering factors such as how frequently these should change, seasonality, etc.

The data required to evaluate a potential solution in this case would be which recommendations resulted in new sales, and an estimation of a customer's likeliness to purchase a specific item without a recommendation. Note that, whilst this data could also be used to build a recommendation engine, it is unlikely that this data will be available before a recommendation system has been implemented, so it is likely that we will have to use an alternate data source to build the model.

We can get an initial idea of how to approach a solution to this problem by considering how it would be solved by a subject-matter expert. Thinking of how a personal stylist may provide a recommendation, they are likely to recommend items based on one or more of the following:

* generally popular items
* items similar to those liked/purchased by the customer
* items that were liked/purchased by similar customers
* items which are complementary to those owned by the customer

Whilst this list is by no means exhaustive, it provides a good indication of the data that is likely to be useful to us:

* item sales data
* customer purchase histories
* customer demographics
* item descriptions and tags
* previous outfits, or sets, which have been curated by the stylist

We would then be able to use this data to explore:

* a method of measuring similarity between items
* a method of measuring similarity between customers
* a method of measuring how complementary items are relative to one another

which can be used to create and rank recommendations. Depending on the project scope, and available data, one or more of these areas could be selected to create hypotheses to be explored by the data science team. Some examples of such hypothesis statements could be:

* From the descriptions of each item, we can determine a measure of similarity between different items to a degree of accuracy which is specified by a stylist.
* Based on the behavior of customers with similar purchasing histories, we are able to predict certain items that a customer is likely to purchase; with a certainty which is greater than random choice.
* Using sets of items which have previously been sold together, we can formulate rules around the features which determine whether items are complementary or not which can be verified by a stylist.

## Next Steps

To ensure clarity and alignment, it is useful to summarise the envisioning stage findings focusing on proposed detailed scenarios, assumptions and agreed decisions as well as next steps.

We suggest confirming that you have access to all necessary resources (including data) as a next step before proceeding with data exploration workshops.

Below are the links to the exit document template and to some questions which may be helpful in confirming resource access.

* [Summary of Scope Exit Document Template](./ml-envisioning-summary-template.md)
* [List of Resource Access Questions](./ml-data-exploration.md)
* [List of Data Exploration Workshop Questions](./ml-data-exploration.md)

## References

Many of the ideas presented here - and much more - were inspired by, and can be found in the following resources; all of which are highly recommended.

1. [Aurélien Géron's Machine learning project checklist](https://github.com/ageron/handson-ml/blob/master/ml-project-checklist.md)

2. [Fast.ai's Data project checklist](https://www.fast.ai/2020/01/07/data-questionnaire)

3. [Designing great data products. Jeremy Howard, Margit Zwemer and Mike Loukides](https://www.oreilly.com/radar/drivetrain-approach-data-products/)
