
# Planning

## Why It Matters
Effective planning practices ensure that engineering teams are always aligned with business priorities, delivery goals, and available capacity. Structured rituals like OKR alignment, backlog grooming, and sprint planning lead to better predictability, reduced scope thrash, and higher stakeholder confidence.

---

## Industry Best Practices

- Define and track **Objectives and Key Results (OKRs)** to align engineering outcomes with business impact
- Maintain a **well-groomed backlog** with prioritized, INVEST-ready stories
- Apply **prioritization frameworks** (e.g., MoSCoW, WSJF, RICE)
- Conduct **backlog refinement**, **sprint planning**, and **release planning** regularly
- Emphasize high-quality **user story writing** with clear acceptance criteria
- Use structured **demo formats** to close feedback loops

[Microsoft: Backlog Refinement](https://microsoft.github.io/code-with-engineering-playbook/agile/backlog-refinement/)  
[Microsoft: Sprint Planning](https://microsoft.github.io/code-with-engineering-playbook/agile/sprint-planning/)

---

## Best Practices Observed (UL Teams)

- Teams use defined sprint cadences and planning meetings
- Some teams (e.g., platform groups) adopt quarterly OKR-style goal tracking
- Backlogs are maintained in Azure DevOps or GitHub Projects
- Story writing often includes personas and Gherkin-style AC
- Some demo rituals exist with stakeholder participation

---

## Gaps Identified (vs. Microsoft Playbook)

- OKRs are not consistently defined or visible
- Backlog grooming lacks a defined cadence in several teams
- Acceptance criteria are often incomplete or vague
- Prioritization approaches vary and are undocumented
- Sprint demos are inconsistent or focus on features vs outcomes

---

## UL Playbook Guidance

### Align Planning with Strategic Objectives

- Define **quarterly OKRs** for each project or product area
- Link Epics and Features directly to measurable key results
- Review OKRs during PI planning and in sprint reviews

---

### Backlog Grooming & Prioritization

- Conduct **bi-weekly grooming sessions** with cross-functional leads
- Use **MoSCoW** or **WSJF** prioritization techniques
- Maintain a **2-sprint ready** backlog
- Tag items with readiness indicators (e.g., Ready, Groomed, Blocked)

---

### Improve Story Quality

- Write stories using the **INVEST** model  
- Format: “As a [persona], I want [goal], so that [value]”
- Use **Gherkin syntax** or checklist-style AC
- Review every story for acceptance criteria completeness and DoR

---

### Strengthen Sprint Planning & Reviews

- Planning includes: team velocity, capacity, sprint goal, and blockers
- Sprint goal is documented and visible in Azure DevOps or Confluence
- Demos must connect back to user value or OKRs
- Stakeholders should be present and provide feedback

---

## Recommended Templates & Links

| Item | Type | Source |
|------|------|--------|
| OKR Tracker Template | GitHub Example | [GitHub – OKR README format](https://github.com/microsoft/code-with-engineering-playbook/blob/main/metrics/README.md#objectives-and-key-results-okrs) |
| Backlog Grooming Guide | GitHub | [Microsoft – Backlog Refinement Guide](https://github.com/microsoft/code-with-engineering-playbook/blob/main/agile/backlog-refinement/readme.md) |
| INVEST Story Checklist | GitHub Gist | [Microsoft – User Story Tips](https://github.com/microsoft/code-with-engineering-playbook/blob/main/agile/user-story-writing/readme.md) |
| Acceptance Criteria Format | GitHub | [Gherkin AC Format – Microsoft](https://github.com/microsoft/code-with-engineering-playbook/blob/main/agile/backlog-refinement/readme.md#acceptance-criteria) |
| Sprint Demo Guide | GitHub | [Microsoft – Sprint Review Format](https://github.com/microsoft/code-with-engineering-playbook/blob/main/agile/sprint-review/readme.md) |

---

## Governance

| Area | Owner | Frequency |
|------|-------|-----------|
| OKR Review | Engineering Lead / Product Owner | Quarterly |
| Grooming Cadence | Product Owner / Tech Lead | Bi-weekly |
| Sprint Planning | Scrum Master / Dev Team | Every Sprint |
| Demo Review | Product Owner | End of Sprint |

---

## Summary

Planning practices connect product vision to delivery execution. By aligning on clear goals, maintaining a well-prioritized backlog, and continuously grooming upcoming work, teams can stay adaptive, productive, and focused on delivering what matters.

**This section should be reviewed by all POs, Scrum Masters, and Product/Engineering Leads.**
