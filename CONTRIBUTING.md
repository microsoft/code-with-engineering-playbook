
# 📥 CONTRIBUTING.md – UL Software Engineering Playbook

## Overview
This document outlines the process for contributing to the UL Software Engineering Playbook repository using GitHub and Azure DevOps (ADO).

---

## 🧑‍💻 Step-by-Step Contribution Process

### 1. Identify Contribution Need
- Select a gap or improvement area.
- Refer to the Microsoft Engineering Playbook or internal observations.

### 2. Create ADO Work Item
- Create a Task or User Story tagged with:
  - `Playbook-Contribution`
  - `Epic-ID` (e.g., EPIC-04)
- Assign it to yourself or the right contributor.

### 3. Fork or Create a Feature Branch
- Fork the repo or create a new branch from `main`:
  ```
  feature/epic04-architecture-patterns
  ```

### 4. Author Content Using Templates
- Use the correct template from `/templates/`:
  - `Feature.md`
  - `UserStory.md`
  - `Task.md`
- Save in appropriate folder under `/engineering-playbook/`.

### 5. Commit and Push
- Use meaningful commit messages:
  ```
  feat: Added checklist for architecture review
  ```

### 6. Open a Pull Request (PR)
- Target `main` branch.
- Include:
  - Summary of changes
  - Link to ADO Work Item (`[ADO#12345]`)
  - Diagrams/screenshots (if applicable)
- Add appropriate labels:
  - `needs-review`, `epic-04`, `playbook-contribution`
- Assign reviewers from V-Team or Epic Owners.

### 7. Review & Approval
- Address reviewer comments.
- Once approved, PR is merged by a Maintainer.

### 8. Post-Merge
- Close ADO Work Item.
- Announce the update in the Teams channel.

---
