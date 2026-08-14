# Design

Designing software well is hard.

ISE has collected a number of practices which we find help in the design process.
This covers not only technical design of software, but also architecture design and non-functional requirements gathering for new projects.

## Goals

- Provide recommendations for how to design software for maintainability, ease of extension, adherence to best practices, and sustainability.
- Reference or define process or checklists to help ensure well-designed software.
- Collate and point to reference sources (guides, repos, articles) that can help shortcut the learning process.

## Designing AI-assisted and AI-enabled systems

When a design uses AI tools, models, retrieval, generated content, or agents, make the intended use explicit before implementation. The design should state who is affected, what the AI component is allowed to do, and what non-AI alternatives or fallback paths exist.

- Define autonomy boundaries, tool permissions, human approval points, and rollback behavior.
- Identify failure modes, abuse cases, data sensitivity, accessibility concerns, and evaluation criteria.
- Capture responsible AI, security, privacy, observability, and review decisions in design review artifacts.
- Confirm which AI tools are approved for this project and data type before using project or customer context in design exploration.

Use the [AI-Assisted Engineering](../ai-assisted-engineering/README.md) guide for shared oversight, data, evaluation, and governance practices.

## Code Examples

- Folder Structure
  - [Folder Structure For Python Repository](https://github.com/microsoft/cookiecutter_template_for_python)
- Project Templates
  - Rust
    - [Actix Web, Diesel ORM, Test Containers, Onion Architecture](https://github.com/microsoft/cookiecutter-rust-actix-clean-architecture)
  - Python
    - [Flask, SQLAlchemy ORM, Test Containers, Onion Architecture](https://github.com/microsoft/cookiecutter-python-flask-clean-architecture)
