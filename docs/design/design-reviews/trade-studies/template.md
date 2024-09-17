# Trade Study Template

This generic template can be used for any situation where we have a set of requirements that can be satisfied
by multiple solutions. They can range in scope from choice of which open source package to use, to full
architecture designs.

## Trade Study/Design: [Trade Study Name]

- **Conducted by:** {Names of those that can answer follow-up questions and at least one email address}
- **Backlog Work Item:** {Link to the work item to provide more context}
- **Sprint:** {Which sprint did the study take place? Include sprint start date}
- **Decision:** {Solution chosen to proceed with}
- **Decision Makers:**

**IMPORTANT** Designs should be completed within a sprint. Most designs will benefit from brevity. To accomplish this:

1. Narrow the scope of the design.
1. Narrow evaluation to 2 to 3 solutions.
1. Design experiments to collect evidence as fast as possible.

## Overview

Description of the problem we are solving. This should include:

1. Assumptions about the rest of the system
1. Constraints that apply to the system, both business and technical
1. Requirements for the functionality that needs to be implemented, including possible inputs and outputs
1. (optional) A diagram showing the different pieces

### Desired Outcomes

The following section should establish the desired capabilities of the solution for it to be successful. This can be done by answering the following questions either directly or via link to related artifact (i.e. PBI or Feature description).

1. Acceptance: What capabilities should be demonstrable for a stakeholder to accept the solution?
1. Justification: How does this contribute to the broader project objectives?

> **IMPORTANT** This is **not** intended to define outcomes for the design activity itself. It is intended to define the outcomes for the solution being designed.

As mentioned in the [User Interface](../../../UI-UX/README.md) section, if the trade study is analyzing an application development solution, make use of the _persona stories_ to derive desired outcomes. For example, if a persona story exemplifies a certain accessibility requirement, the parallel desired outcome may be "The application must be accessible for people with vision-based disabilities".

### Evaluation Criteria

The former should be condensed down to a set of "evaluation criteria" that we can rate any potential solutions
against. Examples of evaluation criteria:

- Runs on Windows and Linux - Binary response
- Compute Usage - Could be categories that effectively rank different options: High, Medium, Low
- Cost of the solution – An estimated numeric field

The results section contains a table evaluating each solution against the evaluation criteria.

#### Key Metrics (Optional)

If available, describe any measurable metrics that are important to the success of the solution. Examples include, but are not limited to:

- Performance & Scale targets such as, Requests/Second, Latency, and Response time (at a given percentile).
- Azure consumption cost budget. For example, given certain usage, solution expected to cost X dollars per month.
- Availability uptime of XX% over X time period.
- Consistency. Writes available for read within X milliseconds.
- Recovery point objective (RPO) & Recovery time objective (RTO).

#### Constraints (Optional)

If applicable, describe the boundaries from which we have to design the solution. This could be thought of as the "box" the team has to work within. This box may be defined as:

- Technologies, services, and languages an organization is comfortable operating/managing.
- Devices, operating systems, and/or browsers that must be supported.
- Backward Compatibility. For example, public interfaces consumed by client or third party apps cannot introduce breaking changes.
- Integrations or dependencies with other systems. For example, push notifications to client apps must be done via existing websockets channel.

#### Accessibility

**Accessibility is never optional**. Microsoft has made a public commitment to always produce accessible applications. For more information visit the official [Microsoft accessibility site](https://www.microsoft.com/accessibility) and read the [Accessibility](../../../non-functional-requirements/accessibility.md) page.

Consider the following prompts when determining application accessibility requirements:

- Does the application meet industry accessibility standards?
- Are training, support, and documentation resources accessible?
- Is the application designed to be inclusive for people will a broad range of abilities, languages, and cultures?

## Solution Hypotheses

Enumerate the solutions that are believed to deliver the outcomes defined above.

> **Note:** Limiting the evaluated solutions to 2 or 3 potential candidates can help manage the time spent on the evaluation. If there are more than 3 candidates, prioritize what the team feels are the top 3. If appropriate, the eliminated candidates can be mentioned to capture why they were eliminated. Additionally, there should be at least two options compared, otherwise you didn't need a trade study.

### [Solution 1]

Add a **brief** description of the solution and how its expected to produce the desired outcomes. If appropriate, illustrations/diagrams can be used to reduce the amount of text explanation required to describe the solution.

> NOTE: Using present tense language to describe the solution can help avoid confusion between current state and future state. For example, use "This solution works by doing..." vs. "This solution would work by doing...".

Each solution section should contain the following:

1. Description of the solution
1. (optional) A diagram to quickly reference the solution
1. Possible variations - things that are small variations on the main solution can be grouped together
1. Evaluation of the idea based on the evaluation criteria above

The depth, detail, and contents of these sections will vary based on the complexity of the functionality
being developed.

#### Experiment(s)

Describe how the solution will be evaluated to prove or dis-prove that it will produce the desired outcomes. This could take many forms such as building a prototype and researching existing documentation and sample solutions.

Additionally, **document any assumptions** made as part of the experiment.

> NOTE: Time boxing these experiments can be beneficial to make sure the team is making the best use of the time by focusing on collecting key evidence in the simplest/fastest way possible.

#### Evidence

Present the evidence collected during experimentation that supports the hypothesis that this solution will meet the desired outcomes. Examples may include:

- Recorded or live demos of a prototype providing the desired capabilities
- Metrics collected while testing the prototype
- Documentation that indicates the solution can provide the desired capabilities

> NOTE: **Evidence is not required for every capability, metric, or constraint for the design to be considered done.** Instead, focus on presenting evidence that is most relevant and impactful towards supporting or eliminating the hypothesis.

### [Solution 2]

...

### [Solution N]

...

## Results

This section should contain a table that has each solution rated against each of the evaluation criteria:

| Solution   | Evaluation Criteria 1 | Evaluation Criteria 2 | ... | Evaluation Criteria N |
|------------|-----------------------|-----------------------|-----|-----------------------|
| Solution 1 |                       |                       |     |                       |
| Solution 2 |                       |                       |     |                       |
| ...        |                       |                       |     |                       |
| Solution M |                       |                       |     |                       |

Note: The formatting of the table can change. In the past, we have had success with qualitative descriptions
in the table entries and color coding the cells to represent good, fair, bad.

## Decision

The chosen solution, or a list of questions that need to be answered before the decision can be made.

In the latter case, each question needs an action item and an assigned person for answering the question. Once those questions are answered, the document must be updated to reflect the answers, and the final decision.

In the first case, describe which solution was chosen and why. Summarize what evidence informed the decision and how that evidence mapped to the desired outcomes.

> **Note:** Decisions should be made with the understanding that they can change as the team learns more. It's a starting point, not a contract.

## Next Steps

What work is expected once a decision has been reached? Examples include but are not limited to:

1. Creating new PBI's or modifying existing ones
1. Follow up spikes
1. Creating specification for public interfaces and integrations between other work streams.
1. Decision Log Entry
