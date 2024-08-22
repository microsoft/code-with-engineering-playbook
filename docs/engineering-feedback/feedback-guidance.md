# Engineering Feedback Guidance

The following guidance provides a minimum set of details that will result in actionable engineering feedback. Ensure that you provide as much detail for each of the following sections as relevant and possible.

## Title

Provide a meaningful and descriptive title. There is no need to include the Azure service in the title as this will be included as part of the **Categorization** section.

Good examples:

- Supported X versions not documented
- Require all-in-one Y story

## Summary

Summarize the feedback in a short paragraph.

## Categorization

### Azure Service

Which Azure service does this feedback item refer to? If there are multiple Azure services involved, pick the primary service and include the details of the others in the **Notes** section.

### Type

Select one of the following to describe what type of feedback is being provided:

- Business Blocker (e.g. No SLA on X, Service Y not GA, Service A not in Region B)
- Technical Blocker (e.g. Accelerated networking not available on Service X)
- Documentation (e.g. Instructions for configuring scenario X missing)
- Feature Request (e.g. Enable simple integration to X on Service Y)

### Stage

Select one of the following to describe the lifecycle stage of the engagement that has generated this feedback:

- Production
- Staging
- Testing
- Development

### Impact

Describe the impact to the customer and engagement that this feedback implies.

### Time Frame

Provide a time frame that this feedback item needs to be resolved within (if relevant).

### Priority

Please provide the customer perspective priority of the feedback.  Feedback is prioritized at one of the following four levels:

- **P0 - Impact is critical and large**: Needs to be addressed immediately; impact is critical and large in scope (i.e. major service outage; makes service or functions unusable/unavailable to a high portion of addressable space; no known workaround).
- **P1 - Impact is high and significant**: Needs to be addressed quickly; impacts a large percentage of addressable space and impedes progress. A partial workaround exists or is overly painful.
- **P2 - Impact is moderate and varies in scope**: Needs to be addressed in a reasonable time frame (i.e. issues that are impeding adoption and usage with no reasonable workarounds). For example, feedback may be related to feature-level issue to solve for friction.
- **P3 - Impact is low**: Issue can be address when able or eventually (i.e. relevant to core addressable space but issue does not impede progress or has reasonable workaround). For example, feedback may be related to feature ideas or opportunities.

## Reproduction Steps

The reproduction steps are important since they help confirm and replay the issue, and are essential in demonstrating success once there is a resolution.

### Pre-requisites

Provide a clear set of all conditions and pre-requisites required before following the set of reproduction steps. These could include:

- Platform (e.g. AKS 1.16.4 cluster with Azure CNI, Ubuntu 19.04 VM)
- Services (e.g. Azure Key Vault, Azure Monitor)
- Networking (e.g. VNET with subnet)

### Steps

Provide a clear set of repeatable steps that will allow for this feedback to be reproduced. This can take the form of:

- Scripts (e.g. bash, PowerShell, terraform, arm template)
- Command line instructions (e.g. az, helm, terraform)
- Screen shots (e.g. azure portal screens)

## Notes

Include items like architecture diagrams, screenshots, logs, traces etc which can help with understanding your notes and the feedback item. Also include details about the scenario customer/partner verbatim as much as possible in the main content.

### What Didn't Work

Describe what didn't work or what feature gap you identified.

### What was Your Expectation or the Desired Outcome

Describe what you expected to happen. What was the outcome that was expected?

### Describe the Steps you Took

Provide a clear description of the steps taken and the outcome/description at each point.
