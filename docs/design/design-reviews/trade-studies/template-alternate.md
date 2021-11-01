# Design: {Name}

- **Conducted by:** {Names of those that can answer follow-up questions}
- **Backlog Work Item:** {Link to the work item to provide more context}
- **Sprint:** {Which sprint did the study take place? Include sprint start date}

**IMPORTANT** Designs should be completed within a sprint. Most designs will benefit from brevity. To accomplish this:

1. Narrow the scope of the design.
2. Narrow evaluation to 2 to 3 solutions.
3. Design experiments to collect evidence as fast as possible.

## Desired Outcomes

The following section should establish the desired capabilities of the solution for it to be successful. This can be done by answering the following questions either directly or via link to related artifact (i.e. PBI or Feature description).

1. Acceptance: What capabilities should be demonstrable for a stakeholder to accept the solution?
2. Justification: How does this contribute to the broader project objectives?

> **IMPORTANT**: This is **not** intended to define outcomes for the design activity itself. It is intended to define the outcomes for the solution being designed.

### Key Metrics (Optional)

If available, describe any measurable metrics that are important to the success of the solution. Examples include, but are not limited to:

- Performance & Scale targets such as, Requests/Second, Latency, and Response time (at a given percentile).
- Azure consumption cost budget. For example, given certain usage, solution expected to cost X dollars per month.
- Availability uptime of XX% over X time period.
- Consistency. Writes available for read within X milliseconds.
- Recovery point objective (RPO) & Recovery time objective (RTO).

### Constraints (Optional)

If applicable, describe the boundaries from which we have to design the solution. This could be thought of as the "box" the team has to work within. This box may be defined as:

- Technologies, services, and languages an organization is comfortable operating/managing.
- Devices, operating systems, and/or browsers that must be supported.
- Backward Compatibility. For example, public interfaces consumed by client or third party apps cannot introduce breaking changes.
- Integrations or dependencies with other systems. For example, push notifications to client apps must be done via existing websockets channel.

## Solution Hypotheses

Enumerate the solutions that are believed to deliver the outcomes defined above.

> NOTE: Limiting the evaluated solutions to 2 or 3 potential candidates can help manage the time spent on the evaluation. If there are more than 3 candidates, prioritize what the team feels are the top 3. If appropriate, the eliminated candidates can be mentioned to capture why they were eliminated.

### {Solution 1} - Short and recognizable name

Add a **brief** description of the solution and how its expected to produce the desired outcomes. If appropriate, illustrations/diagrams can be used to reduce the amount of text explanation required to describe the solution.

> NOTE: Using present tense language to describe the solution can help avoid confusion between current state and future state. For example, use "This solution works by doing..." vs. "This solution would work by doing...".

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

### {Solution 2}

...

### {Solution N}

...

## Decision

Describe which solution was chosen and why. Summarize what evidence informed the decision and how that evidence mapped to the desired outcomes.

> **IMPORTANT**: Decisions should be made with the understanding that they can change as the team learns more. It's a starting point, not a contract.

## Next Steps

What work is expected once a decision has been reached? Examples include but are not limited to:

1. Creating new PBI's or modifying existing ones
2. Follow up spikes
3. Creating specification for public interfaces and integrations between other work streams.
4. Decision Log Entry
