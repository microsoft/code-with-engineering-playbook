# Role Data Model Schema

Date: 03/23/2021

## Status

In Development

## Context

We need to create a data schema that is going to be used to store the structure of the [Career State Profiles (CSP)](https://microsoft.sharepoint.com/sites/hrw/careerguide/Pages/careerguide.aspx) and Roles from the [Microsoft Role Library](https://microsoft.sharepoint.com/sites/hrw/Pages/RoleLibrary.aspx).
The structure should be a normalized union of the requirements from both systems that can be leveraged in the Memory app.

When users are recording accomplishments using the application they will need the ability to link accomplishments against a role's responsibilities or competencies.

### Career Stage Profile (CSP)

The following describes the current data model supported by the Career Stage profiles within the engineering organizations at Microsoft

- Career Stage Profile
  - Title: The name of the CSP
  - Level Band: The level band applicable to the CSP
  - Category - The key result category
  - Title: Name of the category ex) Product and Service Design
  - Description: Short description of the category
    - Items
    - A key result expected of an engineer within the CSP

#### CSP Example

- Role: Stage 5/6: Principal Software Engineering Lead
- Product Service & Design
  - Description of responsibilities

### Microsoft Role Library

The following describes the current data model supported by the Microsoft role library.

- Profession - Top level professions that categorize available Roles
  - Discipline: The associated discipline (Text)
    - Title: Name of the profession
    - Description: Description of the profession
    - Roles:
      - Title: The name of the role
      - Responsibilities: List of responsibility categories
      - Category - The name of the category
        - Title: The title of the category ex) Design
        - Items - List of responsibilities within a category
          - Description of responsibility
      - Qualifications: List of prerequisites to be eligible for the role.
      - Free text field
      - Knowledge, Skills & Abilities
      - Free text field

#### Role Example

- Profession: Engineering
- Discipline: Site Reliability Engineering
- Role: Site Reliability Engineering IC2
- Responsibilities:
  - Technical Knowledge and Domain Specific Expertise
    - List of responsibilities

## Decision

An extensible data model was developed that support the requirements of both the Career Stage Profiles (CSP) and roles from the Microsoft Role library.

Detailed information on the data model can be found at [Data Model](../../Architecture/Data-Model.md)

## Consequences

None, both data models requirements should be fully supported in the new normalized schema.
