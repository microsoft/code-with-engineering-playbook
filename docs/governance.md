# Engineering Playbook Governance Model

This document outlines how contributions to the UL Engineering Playbook are managed, reviewed, and maintained.

---

## Purpose

The Engineering Playbook is a shared repository of UL-wide standards and best practices. Governance ensures:
- Every contribution is reviewed for quality and alignment
- Teams follow a structured contribution process
- The playbook evolves in a controlled, traceable way

---

## Review Process

All contributions (Feature, User Story, Task markdown files) must:

1. Be linked to an Azure DevOps (ADO) work item
2. Follow the provided markdown templates in `/templates/`
3. Be placed in the correct Epic folder under `/engineering-playbook/`
4. Be submitted through a Pull Request (PR) with the [PR template](../.github/PULL_REQUEST_TEMPLATE.md)
5. Be reviewed and approved by at least one member of the V-Team (auto-enforced via CODEOWNERS)

---

## V-Team Responsibilities

V-Team members are responsible for:

- Reviewing PRs assigned to them within 2 business days
- Ensuring documentation follows template and structure
- Tagging additional reviewers if cross-domain input is needed
- Rejecting or requesting changes for unclear, incomplete, or misaligned submissions

V-Team member list is defined in [`CODEOWNERS`](../.github/CODEOWNERS).

---

## Folder Structure & Naming

- Epic folders live in `/engineering-playbook/`
- Each `.md` file should be clearly named and match the topic (e.g., `code-review-checklist.md`)
- Avoid duplicating content across folders

---

## Change Control & Versioning

- All updates must go through PR and V-Team review
- Existing files may be edited only with a clear explanation in the PR
- Major changes should reference a related ADO Work Item
- Optional future feature: Tag releases by quarter for versioning (`v1.0`, `v2.0`, etc.)

---

## Questions or Feedback

For support, reach out to the Playbook Facilitator or comment in the PR. Updates to this governance model may be proposed and reviewed like any other playbook contribution.
