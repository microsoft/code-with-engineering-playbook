# Engineering Feedback Guidance

The following guidance provides a minimum set of details that will result in actionable engineering feedback. Ensure that you provide as much detail for each of the following sections as relevant and possible.

## Title

Provide a meaningful and descriptive title. There is no need to include the Azure service in the title as this will be included as part of the **Categorisation** section.

Good examples:

- Supported X versions not documented
- Require all-in-one Y story

## Summary

Summarise the feedback in a short paragraph.

## Categorisation

### Azure Service

Which Azure service does this feedback item refer to? If there are multiple Azure services involved, pick the primary service and include the details of the others in the **Notes** section.

### Type

Select one of the following to describe what type of feedback is being provided:

- Business Blocker (eg. No SLA on X, Service Y not GA, Service A not in Region B)
- Technical Blocker (eg. Accelerated networking not available on Service X)
- Documentation (eg. Instructions for configuring scenario A missing)
- Feature Request (eg. Enable simple integration to X on Service Y)

### Stage

Select one of the following to describe the lifecycle stage of the engagement that has generated this feedback:

- Production
- Staging
- Testing
- Development

### Impact

Describe the impact to the customer and engagement that this feedback implies.

### Timeframe

Provide a timeframe that this feedback item needs to be resolved within (if relevant).

## Repro Steps 

The repro steps are important since they help confirm and replay the issue, and are essential in demonstrating success once there is a resolution.

### Pre-requisites

Provide a clear set of all conditions and pre-requisites required before following the set of repro steps. These could include:

- Platform (eg. AKS 1.16.4 cluster with Azure CNI, Ubuntu 19.04 VM)
- Services (eg. Azure Key Vault, Azure Monitor)
- Networking (eg. VNET with subnet)


### Steps

Provide a clear set of repeatable steps that will allow for this feedback to be reproduced. This can take the form of:

- Scripts (eg. bash, powershell, terraform, arm template)
- Command line instructions (eg. az, helm, terraform)
- Screen shots (eg. azure portal screens)

## Notes

Include items like architecture diagrams, screen shots, logs, traces etc which can help with understanding your notes and the feedback item.

### What didn't work?

Describe what didn't work or what feature gap you identified.

### What was your expectation or the desired outcome?

Describe what you expected to happen. What was the outcome that was expected?

### Describe the steps you took

Provide a clear description of the steps taken and the outcome/description at each point.

