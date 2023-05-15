# Non-Functional Requirements Capture

## Goals

In software engineering projects, important characteristics of the system providing for necessary e.g., testability, reliability, scalability, observability, security, manageability are best considered as first-class citizens in the requirements gathering process.
By defining these non-functional requirements in detail early in the engagement, they can be properly evaluated when the cost of their impact on subsequent design decisions is comparatively low.

To support the process of capturing a project's _comprehensive_ non-functional requirements, this document offers a taxonomy for non-functional requirements and provides a framework for their identification, exploration, assignment of customer stakeholders, and eventual codification into formal engineering requirements as input to subsequent solution design.

---

## Areas of Investigation

### [Enterprise Security](../../security/README.md)

- Privacy
  - PII
  - HIPAA
- Encryption
- Data mobility
  - at rest
  - in motion
  - in process/memory
- Key Management
  - responsibility
    - platform
    - BYOK
    - CMK
- INFOSEC regulations/standards
  - e.g., FIPS-140-2
    - Level 2
    - Level 3
  - ISO 27000 series
  - NIST
  - Other
- Network security
  - Physical/Logical traffic boundaries/flow topology
    - Azure <-- --> On-prem
    - Public <-- --> Azure
    - VNET
    - PIP
    - Firewalls
    - VPN
    - ExpressRoute
      - Topology
      - Security
  - Certificates
    - Issuer
      - CA
      - Self-signed
      - Rotation/expiry
- INFOSEC Incident Response
  - Process
  - People
  - Responsibilities
  - Systems
  - Legal/Regulatory/Compliance

### Enterprise AuthN/AuthZ

- Users
- Services
- Authorities/directories
- Mechanisms/handshakes
  - Active Directory
  - SAML
  - OAuth
  - Other
- RBAC
  - Perms inheritance model

### [Enterprise Monitoring/Operations](../../observability/README.md)

- Logging
  - Operations
  - Reporting
  - Audit
- Monitoring
  - Diagnostics/Alerts
  - Operations
- HA/DR
  - Redundancy
  - Recovery/Mitigation
- Practices
  - Principle of least-privilege
  - Principle of separation-of-responsibilities

### Other standard Enterprise technologies/practices

- Developer ecosystem
  - Platform/OS
    - Hardened
    - Approved base images
    - Image repository
  - Tools, languages
    - Approval process
  - Code repositories
    - Secrets management patterns
      - Env var
      - Config file(s)
      - Secrets retrieval API
  - Package manager source(s)
    - Private
    - Public
    - Approved/Trusted
  - CI/CD
  - Artifact repositories

### Production ecosystem

- Platform/OS
  - Hardened
  - Approved base images
  - Image repository
- Deployment longevity/volatility
  - Automation
  - Reproducibility
    - IaC
    - Scripting
    - Other

### Other areas/topics not addressed above (requires customer input to comprehensively enumerate)

---

## Investigation Process

1. Identify/brainstorm likely areas/topics requiring further investigation/definition
1. Identify customer stakeholder(s) responsible for each identified area/topic
1. Schedule debrief/requirements definition session(s) with each stakeholder
   - as necessary to achieve sufficient understanding of the probable impact of each requirement to the project
   - both current/initial milestone and long-term/road map
1. Document requirements/dependencies identified and related design constraints
1. Evaluate current/near-term planned milestone(s) through the lens of the identified requirements/constraints
   - Categorize each requirement as affecting immediate/near-term milestone(s) or as applicable instead to the longer-term road map/subsequent milestones
1. Adapt plans for current/near-term milestone(s) to accommodate immediate/near-term-categorized requirements

---

## Structure of Outline/Assignment of Responsible Stakeholder

In the following outline, assign name/email of 'responsible stakeholder' for each element after the appropriate level in the outline hierarchy. Assume inheritance model of responsibility assignment: stakeholder at any ancestor (parent) level is also responsible for descendent (child) elements unless overridden at the descendent level).

e.g.,

- Parent1 _[Susan/susan@domain.com]_
  - child1
  - child2 _[John/john@domain.com]_
    - grandchild1
  - child3
- Parent2 _[Sam/sam@domain.com]_
  - child1
  - child2

In the preceding example, 'Susan' is responsible for `Parent1` and all of its descendants _except_ for `Parent1/child2` and `Parent1/child2/grandchild1` (for which 'John' is the stakeholder). 'Sam' is responsible for the entirety of `Parent2` and all of its descendants.

This approach permits the retention of the logical hierarchy of elements themselves while also flexibly interleaving the 'stakeholder' identifications within the hierarchy of topics if/when they may need to diverge due to e.g., customer organizational nuances.
