# Feasibility Studies

The main goal of feasibility studies is to assess whether it is feasible to solve the problem satisfactorily using ML with the available data. We want to avoid investing too much in the solution before we have:

* Sufficient evidence that a solution would be the best technical solution given the business case
* Sufficient evidence that a solution is compatible with the problem context
* Sufficient evidence that a solution is possible
* Some vetted direction on what a solution should look like

This effort ensures quality solutions backed by the appropriate, thorough amount of consideration and evidence.

## When are Feasibility Studies Useful?

Every engagement can benefit from a feasibility study early in the project.

Architectural discussions can still occur in parallel as the team works towards gaining a solid understanding and definition of what will be built.

Feasibility studies can last between 4-16 weeks, depending on specific problem details, volume of data, state of the data etc. Starting with a 4-week milestone might be useful, during which it can be determined how much more time, if any, is required for completion.

## Who Collaborates on Feasibility Studies?

Collaboration from individuals with diverse skill sets is desired at this stage, including data scientists, data engineers, software engineers, PMs, human experience researchers, and domain experts. It embraces the use of engineering fundamentals, with some flexibility. For example, not all experimentation requires full test coverage and code review. Experimentation is typically not part of a CI/CD pipeline. Artifacts may live in the `main` branch as a folder excluded from the CI/CD pipeline, or as a separate experimental branch, depending on customer/team preferences.

## What do Feasibility Studies Entail?

### Problem Definition and Desired Outcome

* Ensure that the problem is complex enough that coding rules or manual scaling is unrealistic
* Clear definition of the problem from business and technical perspectives

### Deep Contextual Understanding

Confirm that the following questions can be answered based on what was learned during the Discovery Phase of the project. For items that can not be satisfactorily answered, undertake additional investigation to answer.

* Understanding the people who are using and/or affected by the solution
* Understanding the contextual forces at play around the problem, including goals, culture, and historical context
* To accomplish this a researcher will:
* Collaborate with customers and colleagues to explore the landscape of people who relate to and may be affected by the problem space being explored (Users, stakeholders, subject matter experts, etc)
* Formulate the research question(s) to be addressed
* Select and design research to best serve the research question(s)
* Identify and select representative research participants across the problem space with whom to conduct the research
* Construct a research plan and necessary preparation documents for the selected research method(s)
* Conduct research activity with the participants via the selected method(s)
* Synthesize, analyze, and interpret research findings
* Where relevant, build frameworks, artifacts and processes that help explore the findings and implications of the research across the team
* Share what was uncovered and understood, and the implications thereof across the engagement team and relevant stakeholders.
* If the above research was conducted during the Discovery phase, it should be reviewed, and any substantial knowledge gaps should be identified and filled by following the above process.

### Data Access

* Verify that the full team has access to the data
* Set up a dedicated and/or restricted environment if required
* Perform any required de-identification or redaction of sensitive information
* Understand data access requirements (retention, role-based access, etc.)

### Data Discovery

* Hold a [data exploration](./data-exploration.md) workshop and deep dive with domain experts
* Understand data availability and confirm the team's access
* Understand the data dictionary, if available
* Understand the quality of the data. Is there already a data validation strategy in place?
* Ensure required data is present in reasonable volumes
* For supervised problems (most common), assess the availability of labels or data that can be used to effectively approximate labels
* If applicable, ensure all data can be joined as required and understand how
  * Ideally obtain or create an entity relationship diagram (ERD)
* Potentially uncover new useful data sources

### Architecture Discovery

* Clear picture of existing architecture
* Infrastructure spikes

### Concept Ideation and Iteration

* Develop value proposition(s) for users and stakeholders based on the contextual understanding developed through the discovery process (e.g. key elements of value, benefits)
* As relevant, make use of
* Co-creation with team
* Co-creation with users and stakeholders
* As relevant, create vignettes, narratives or other materials to communicate the concept
* Identify the next set of hypotheses or unknowns to be tested (see concept testing)
* Revisit and iterate on the concept throughout discovery as understanding of the problem space evolves

### Exploratory Data Analysis (EDA)

* Data deep dive
* Understand feature and label value distributions
* Understand correlations among features and between features and labels
* Understand data specific problem constraints like missing values, categorical cardinality, potential for data leakage etc.
* Identify any gaps in data that couldn't be identified in the data discovery phase
* Pave the way of further understanding of what techniques are applicable
* Establish a mutual understanding of what data is in or out of scope for feasibility, ensuring that the data in scope is significant for the business

### Data Pre-Processing

* Happens during EDA and hypothesis testing
* Feature engineering
* Sampling
* Scaling and/or discretization
* Noise handling

### Hypothesis Testing

* Design several potential solutions using theoretically applicable algorithms and techniques, starting with the simplest reasonable baseline
* Train model(s)
* Evaluate performance and determine if satisfactory
* Tweak experimental solution designs based on outcomes
* Iterate
* Thoroughly document each step and outcome, plus any resulting hypotheses for easy following of the decision-making process

### Concept Testing

* Where relevant, to test the value proposition, concepts or aspects of the experience
* Plan user, stakeholder and expert research
* Develop and design necessary research materials
* Synthesize and evaluate feedback to incorporate into concept development
* Continue to iterate and test different elements of the concept as necessary, including testing to best serve RAI goals and guidelines
* Ensure that the proposed solution and framing are compatible with and acceptable to affected people
* Ensure that the proposed solution and framing is compatible with existing business goals and context

### Risk Assessment

* Identification and assessment of risks and constraints

### Responsible AI

* Consideration of responsible AI principles
* Understanding of users and stakeholders’ contexts, needs and concerns to inform development of RAI
* Testing AI concept and experience elements with users and stakeholders
* Discussion and feedback from diverse perspectives around any responsible AI concerns

## Output of a Feasibility Study

The main outcome is a feasibility study report, with a recommendation on next steps:

If there is not enough evidence to support the hypothesis that this problem can be solved using ML, as aligned with the pre-determined performance measures and business impact:

* We detail the gaps and challenges that prevented us from reaching a positive outcome
* We may scope down the project, if applicable
* We may look at re-scoping the problem taking into account the findings of the feasibility study
* We assess the possibility to collect more data or improve data quality

If there is enough evidence to support the hypothesis that this problem can be solved using ML

* Provide recommendations and technical assets for moving to the operationalization phase
