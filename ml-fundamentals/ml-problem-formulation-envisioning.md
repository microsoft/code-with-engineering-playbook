# Envisioning & Problem formulation

Before beginning a data science investigation, we need to define a problem statement which the data science team can explore; this problem statement can have a significant influence on whether the project is likely to be successful.

## Envisioning goals

The main goals of the envisioning process are:

* Establish a clear understanding of the problem domain and the underlying business objective
* Define how a potential solution would be used and how its performance should be measured
* Determine what data is available to solve the problem
* Understand the capabilities and working practices of the data science team

The envisioning process usually entails a a series of 'envisioning' sessions where the data science team work alongside subject matter experts to formulate the problem in such a way that there is a shared understanding a shared understanding of the problem domain, a clear goal, and a predefined approach to evaluating a potential solution.

## Understanding the problem domain

Generally, before defining a project scope for a data science investigation, we must first understand the problem domain:

* What is the problem?
* Why does the problem need to be solved?
* Does this problem require a machine learning solution?
* How would a potential solution be used?

However, establishing this understanding can prove difficult, especially for those unfamiliar with the problem domain. To ease this process, we can approach problems in a structured way by taking the following steps:  

* Identify a measurable problem and define this in business terms. The objective should be clear, and we should have a good understanding of the factors that we can control - that can be used as inputs - and how they affect the objective. Be as specific as possible.
* Decide how the performance of a solution should be measured and identify whether this is possible within the restrictions of this problem. Make sure it aligns with the business objective and that you have identified the data required to evaluate the solution. Note that the data required to evaluate a solution may differ from the data needed to create a solution.
* Thinking about the solution as a black box, detail the function that a solution to this problem should perform to fulfil the objective and verify that the relevant data is available to solve the problem.
  * One way of approaching this is by thinking about how a subject matter expert could solve the problem manually and the data that would be required; if a human subject matter expert is unable to solve the problem given the available data, this is indicative that additional information is required and/or more data needs to be collected.
* Based on the available data, define specific hypothesis statements - which can be proved
or disproved - to guide the exploration of the data science team. Where possible, each hypothesis statement should have a clearly defined success criteria (e.g., *with an accuracy of over 60%*), however, this is not always possible - especially for projects where no solution to the problem currently exists. In these cases, the measure of success could be based on a subject matter expert verifying that the results meet their expectations.
* Document all the above information, to ensure alignment between stakeholders and establish a clear understanding of the problem to be solved. Try to ensure that as much relevant domain knowledge is captured as possible, and that the features present in available data - and the way that the data was collected - are clearly explained, such that they can be understood by a non-subject matter expert.

Once an understanding of the problem domain has been established, it may be necessary to break down the overall problem into smaller, meaningful chunks of work to maintain team focus and ensure a realistic project scope within the given time frame.

## Envisioning Guidance

During envisioning sessions, the following may prove useful for guiding the discussion. Many of these points are taken directly, or adapted from, [[1]](##References) and [[2]](##References).

### Problem Framing

1. Define the objective in business terms.
2. How will the solution be used?
3. What are the current solutions/workarounds (if any)? What work has been done in this area so far? Does this solution need to fit into an existing system?
4. How should performance be measured?
5. Is the performance measure aligned with the business objective?
6. What would be the minimum performance needed to reach the business objective?
7. Are there any known constraints around non-functional requirements that would have to be taken into account? (e.g., computation times)
8. Frame this problem (supervised/unsupervised, online/offline, etc.)
9. Is human expertise available?
10. How would you solve the problem manually?
11. Are there any restrictions on the type of approaches which can be used? (e.g., does the solution need to be completely explainable?)
12. List the assumptions you or others have made so far. Verify these assumptions if possible.
13. Define some initial hypothesis statements to be explored.
14. Highlight and discuss any responsible AI concerns if appropriate.

### Data Exploration

1. Understand and document the features, location, and availability of the data.
2. What order of magnitude is the current data (e.g., GB, TB)? Is this all relevant?
3. How does the organization decide when to collect additional data or purchase external data? Are there any examples of this?
4. What data has been used so far to analyse recent data-driven projects? What has been found to be most useful? What was not useful? How was this judged?
5. What additional internal data may provide insights useful for data-driven decision making for proposed projects? What external data could be useful?
6. What are the possible constraints or challenges in accessing or incorporating this data?
7. How was the data collected? Are there any obvious biases due to how the data was collected?
8. What changes to data collection, coding, integration, etc has occurred in the last 2 years that may impact the interpretation or availability of the collected data

### Workflow

1. What data science skills exist in the organization?
2. How many data scientists/engineers would be available to work on this project? In what capacity would these resources be available (full-time, part-time, etc.)?
3. What does the team's current workflow practices look like? Do they work on the cloud/on-prem? In notebooks/IDE? Is version control used?
4. How are data, experiments and models currently tracked?
5. Does the team employ an Agile methodology? How is work tracked?
6. Are there any ML solutions currently running in production? Who is responsible for maintaining these solutions?
7. Who would be responsible for maintaining a solution produced during this project?
8. Are there any restrictions on tooling that must/cannot be used?

## Example - a recommendation engine problem

To illustrate how the above process can be applied to a tangible problem domain, as an example, consider that we are looking at implementing a recommendation engine for a clothing retailer. This example was, in part, inspired by [[3]](##References).

Often, the objective may be simply presented, in a form such as "to improve sales". However, whilst this is ultimately the main goal, we would benefit from being more specific here. Suppose that we were to deploy a solution in November and then observed a December sales surge; how would we be able to distinguish how much of this was as a result of the new recommendation engine, as opposed to the fact that December is a peak buying season?

A better objective, in this case, would be "to drive additional sales by presenting the customer with items that they *would not otherwise have purchased without the recommendation*". Here, the inputs that we can control are the choice of items that are presented to each customer, and the order in which they are displayed; considering factors such as how frequently these should change, seasonality, etc.

The data required to evaluate a potential solution in this case would be which recommendations resulted in new sales, and an estimation of a customer's likeliness to purchase a specific item without a recommendation. Note that, whilst this data could also be used to build a recommendation engine, it is unlikely that this data will be available before a recommendation system has been implemented, so it is likely that we will have to use an alternate data source to build the model.

We can get an initial idea of how to approach a solution to this problem by considering how it would be solved by a subject matter expert. Thinking of how a personal stylist may provide a recommendation, they are likely to recommend items based on one or more of the following:

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

## References

Many of the ideas presented here - and much more - were inspired by, and can be found in the following resources; all of which are highly recommended.

[1]: [Aurélien Géron's Machine learning project checklist](https://github.com/ageron/handson-ml/blob/master/ml-project-checklist.md)

[2]: [Fast.ai's Data project checklist](https://www.fast.ai/2020/01/07/data-questionnaire)

[3]: [Designing great data products. Jeremy Howard, Margit Zwemer and Mike Loukides](https://www.oreilly.com/radar/drivetrain-approach-data-products/)
