# ML Feasibility Studies

The main goal of Machine Learning (ML) feasibility studies is to assess whether it is feasible to solve the problem satisfactorily using ML with the available data. We want to avoid investing too much in the solution before we have:

* Sufficient evidence that a ML solution would be the best technical solution given the business case
* Sufficient evidence that a ML solution is possible
* Some vetted direction on what a ML solution should look like

This effort ensures quality solutions backed by the appropriate, thorough amount of consideration and evidence.

## When are ML feasibility studies useful?

Every engagement with a ML component, potentially excluding pure ML Ops engagements, can benefit from a ML feasibility study early in the project.

Architectural discussions can still occur in parallel as the team works towards a gaining solid understanding and definition of what will be built.

Feasibility studies can last between 3-12 weeks, depending on specific problem details, volume of data, state of the data etc. Starting with a 3 week milestone might be useful, during which it can be determined how much more time, if any, is required for completion.

## Who collaborates on ML feasibility studies?

Collaboration from individuals with diverse skillsets is desired at this stage, including data scientists, data engineers, software engineers, PMs and domain experts. It embraces the use of engineering fundamentals, with some flexibility. For example, not all experimentation requires full test coverage and code review. Experimentation is typically not part of a CI/CD pipeline. Artifacts may live in the master branch as a folder excluded from the CI/CD pipeline, or as a separate experimental branch, depending on customer/team preferences.

## What do ML feasibility studies entail?

### ML problem definition and desired outcome

* Ensure that the problem is complex enough that coding rules or manual scaling is unrealistic
* Clear definition of the problem from the ML perspective
* Definition of precisely what will the ML component solve

### Data access

* Verify that the full team has access to the data
* Set up a dedicated and/or restricted environment if required
* Perform any required de-identification or redaction of sensitive information
* Understand data acess requirements (retention, role-based access, etc.)

### Data discovery

* Hold a data exploration workshop and deep dive with domain experts
* Understand the data dictionary, data quality and access (availability)
* Ensure required data is present in reasonable volumes
* For supervised problems (most common), assess the availability of labels or data that can be used to effectively approximate labels
* If applicable, ensure all data can be joined as required and understand how
  * Ideally obtain or create an entity relationship diagram (ERD)
* Potentially uncover new useful data sources

### Architecture discovery

* Clear picture of existing architecture
* Infrastructure spikes

### Exploratory data analysis (EDA)

* Data deep dive
* Understand feature and label value distributions
* Understand correlations among features and between features and labels
* Understand data specific problem constraints like missing values, categorical cardinality, potential for data leakage etc.
* Identify any gaps in data that couldn’t be identified in the data discovery phase
* Pave the way of further understanding of what techniques are applicable
* Establish a mutual understanding of what data is in or out of scope for feasibility, ensuring that the data in scope is significant for the business

### Data pre-processing

* Happens during EDA and hypothesis testing
* Feature engineering
* Sampling
* Scaling and/or discretization
* Noise handling

### Hypothesis testing

* Design several potential solutions using theoretically applicable algorithms and techniques, starting with the simplest reasonable baseline
* Train model(s)
* Evaluate performance and determine if satisfactory
* Tweak experimental solution designs based on outcomes
* Iterate
* Thoroughly document each step and outcome, plus any resulting hypotheses for easy following of the decision making process

### Risk assessment

* Identification and assessment of risks and constraints from ML standpoint

### Responsibile AI

* Consideration of responsible AI and fairness
* Discussion and feedback from diverse perspectives around any resposible AI concerns

## Output of a ML feasibilty study

### Possible outcomes

If there is not enough evidence to support the hypothesis that this problem can be solved using ML, as aligned with the pre-determined performance measures and business impact

* We reject this hypothesis and the feasibility study fails
* We may scope down the project without ML, if applicable
* We may look at re-scoping the problem taking into account the findings of the feasibility study
* We assess the possibility to collect more data or improve data quality

If there is enough evidence to support the hypothesis that this problem can be solved using ML

* We accept this hypothesis and the feasibility study passes
* We produce a feasibility summary document which details each stage of the feasibility study, outcomes and recommendations on how to proceed
* Move on to implementation

### Recommendations on how to proceed

* Based on findings and candidate solutions, make recommendations on how to proceed to the implementation phase
* Include drift and adaptation considerations
