# Privacy and Data

## Goal

The goal of this section is to briefly describe best practices in privacy fundamentals for data heavy projects or portions of a project that may contain data.

**What it is not**: This document is not a checklist for how customers or readers should handle data in their environment, and does not override Microsoft's or the customers' policies for data handling, data protection and information security.

## Introduction

Microsoft runs on trust. Our customers trust ISE to adhere to the highest standards when handling their data.
Protecting our customers' data is a joint responsibility between Microsoft and the customers;
both have the responsibility to help projects follow the guidelines outlined on this page.

Developers working on ISE projects should implement best practices and guidance on handling data throughout the project phases. This page is not meant to suggest how customers should handle data in their environment. **It does not override**:

- [Microsoft's Information Security Policy](https://aka.ms/CTRMSsecppext)
- [Limited Data Protection Addendum](https://aka.ms/mpsldpa)
- [Professional Services Data Protection Addendum](https://www.microsoft.com/licensing/docs/view/Microsoft-Products-and-Services-Data-Protection-Addendum-DPA)

## 5 W's of Data Handling

When working on an engagement it is important to address the following 5 **W**'s:

- **Who** – gets access to and with whom will we share the data and/or models developed with the data?
- **What** – data is shared with us and under what expectations and understanding.
Customers need to be explicit about how the data they share applies to the overarching effort.
The understanding shouldn't be vague and we shouldn't have access to broad set of data if not necessary.
- **Where** – will the data be stored and what legal jurisdiction will preside over that data.
This is particularly important in countries like Germany, where different privacy laws apply
but also important when it comes to responding to legal subpoenas for the data.
- **When** – will the access to data be provided and for how long?
It is important to not leave straggling access to data once the engagement is completed, and define a priori the data retention policies.
- **Why** – have you given access to the data?
This is particularly important to clarify the purpose and any restrictions on usage beyond the intended purpose.

Please use the above guidelines to ensure the data is used only for intended purposes and thereby gain trust.
It is important to be aware of data handling best practices and ensure the required clarity is provided to adhere to the above 5Ws.

## Handling Data in ISE Engagements

Data should never leave customer-controlled environments and contractors and/or other members in the engagement
should never have access to complete customer data sets but use limited customer data sets using the following prioritized approaches:

1. Contractors or engagement partners do not work directly with production data, data will be copied before processing per the guidelines below.
1. Always apply [data minimization](https://www.forbes.com/sites/bernardmarr/2016/03/16/why-data-minimization-is-an-important-concept-in-the-age-of-big-data/#3fb711e91da4)
principles to minimize the blast radius of errors, only work with the minimal data set required to achieve the goals.
1. Generate synthetic data to support engagement work. If synthetic data is not possible to achieve project goals,
request anonymized data in which the likelihood that unique individuals can be re-identified is minimal.
1. Select a suitably diverse, limited data set, again,
follow the Principles of Data Minimization and attempt to work with the fewest rows possible to achieve the goals.

Before work begins on data, ensure OS patches are up to date and permissions are properly set with no open internet access.

Developers working on ISE projects will work with our customers to define the data needed for each engagement.

If there is a need to access production data,
ISE needs to review the need with their lead and work with the customer to put audits in place verifying what data was accessed.

Production data must only be shared with approved members of the engagement team and must not be processed/transferred outside of the customer controlled environment.

Customers should provide ISE with a copy of the requested data in a location managed by the customer.
The customer should consider turning any logging capabilities on so they can clearly identify who has access and what they do with that access.
ISE should notify the customer when they are done with the data and suggest the customer destroy copies of the data if they are no longer needed.

### Our Guiding Principles when Handling Data in an Engagement

- Never directly access production data.
- Explicitly state the intended purpose of data that can be used for engagement.
- Only share copies of the production data with the approved members of the engagement team.
- The entire team should work together to ensure that there are no dead copies of data. When the data is no longer needed,
the team should promptly work to clean up engagement copies of data.
- Do not send any copies of the production data outside the customer-controlled environment.
- Only use the minimal subset of the data needed for the purpose of the engagement.

### Questions to Consider when Working with Data

- What data do we need?
- What is the legal basis for processing this data?
- If we are the processor based on contract obligation what is our responsibility listed in the contract?
- Does the contract need to be amended?
- How can we contain data proliferation?
- What security controls are in place to protect this data?
- What is the data breech protocol?
- How does this data benefit the data subject?
- What is the lifespan of this data?
- Do we need to keep this data linked to a data subject?
- Can we turn this data into Not in a Position to Identify (NPI) data to be used later on?
- How is the system architected so data subject rights can be fulfilled? (ex manually, automated)
- If personal data is involved have engaged privacy and legal teams for this project?

## Summary

It is important to only pull in data that is needed for the problem at hand,
when this is put in practice we find that we only maintain data that is adequate,
relevant and limited to what is necessary in relation to the purposes for which they are processed.
This is particularly important for personal data. Once you have personal data there are many rules and regulations that apply,
some examples of these might be HIPAA, GDPR, CCPA.
The customer should be aware of and surface any applicable regulations that apply to their data.
Furthermore the [seven principles of privacy by design](https://www.onetrust.com/blog/principles-of-privacy-by-design/)
should be reviewed and considered when handling any type of sensitive data.

## Resources

- [Microsoft Trust Center](https://www.microsoft.com/en-us/trust-center/privacy)
- [Tools for responsible AI - Protect](https://www.microsoft.com/en-us/ai/responsible-ai-resources?activetab=pivot1:primaryr5)
- [Data Protection Resources](https://servicetrust.microsoft.com/ViewPage/TrustDocuments?command=Download&docTab=6d000410-c9e9-11e7-9a91-892aae8839ad_AuditedControls)
- [FAQ and White Papers](https://servicetrust.microsoft.com/ViewPage/TrustDocuments?command=Download&docTab=6d000410-c9e9-11e7-9a91-892aae8839ad_AuditedControls)
- [Microsoft Compliance Offerings](https://learn.microsoft.com/en-us/compliance/regulatory/offering-home?view=o365-worldwide)
- [Accountability Readiness Checklists](https://learn.microsoft.com/en-us/compliance/regulatory/gdpr-arc?view=o365-worldwide#gdpr-compliance-controls)
- [Privacy by Design The 7 Foundational Principles](https://www.onetrust.com/blog/principles-of-privacy-by-design/)
