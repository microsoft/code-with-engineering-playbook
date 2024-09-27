# Graph Model

## Graph Vertices and Edges

The set of vertices (entities) and edges (relationships) of the graph model

| Vertex (Source) | Edge Type        | Relationship Type | Vertex (Target) | Notes                                                                                                | Required |
|-----------------|------------------|-------------------|-----------------|------------------------------------------------------------------------------------------------------|----------|
| Profession      | _Applies_        | 1:many            | Discipline      | Top most level of categorization                                                                     | \*       |
| Discipline      | _Defines_        | 1:many            | Role            | Groups of related roles within a profession                                                          | \*       |
|                 | _AppliedBy_      | 1:1               | Profession      |                                                                                                      | 1        |
| Role            | _Requires_       | 1:many            | Responsibility  | Individual role mapped to an employee                                                                | 1+       |
|                 | _Requires_       | 1:many            | Competency      |                                                                                                      | 1+       |
|                 | _RequiredBy_     | 1:1               | Discipline      |                                                                                                      | 1        |
|                 | _Succeeds_       | 1:1               | Role            | Supports career progression between roles                                                            | 1        |
|                 | _Precedes_       | 1:1               | Role            | Supports career progression between roles                                                            | 1        |
|                 | _AssignedTo_     | 1:many            | User Profile    |                                                                                                      | \*       |
| Responsibility  | _Expects_        | 1:many            | Key Result      | A group of expected outcomes and key results for employees within a role                             | 1+       |
|                 | _ExpectedBy_     | 1:1               | Role            |                                                                                                      | 1        |
| Competency      | _Describes_      | 1:many            | Behavior        | A set of behaviors that contribute to success                                                        | 1+       |
|                 | _DescribedBy_    | 1:1               | Role            |                                                                                                      | 1        |
| Key Result      | _ExpectedBy_     | 1:1               | Responsibility  | The expected outcome of performing a responsibility                                                  | 1        |
| Behavior        | _ContributesTo_  | 1:1               | Competency      | The way in which one acts or conducts oneself                                                        | 1        |
| User Profile    | _Fulfills_       | many:1            | Role            |                                                                                                      | 1+       |
|                 | _Authors_        | 1:many            | Entry           |                                                                                                      | \*       |
|                 | _Reads_          | many:many         | Entry           |                                                                                                      | \*       |
| Entry           | _SharedWith_     | many:many         | User Profile    | Business logic should add manager to this list by default. These users should only have read access. | \*       |
|                 | _Demonstrates_   | many:many         | Competency      |                                                                                                      | \*       |
|                 | _Demonstrates_   | many:many         | Behavior        |                                                                                                      | \*       |
|                 | _Demonstrates_   | many:many         | Responsibility  |                                                                                                      | \*       |
|                 | _Demonstrates_   | many:many         | Result          |                                                                                                      | \*       |
|                 | _AuthoredBy_     | many:1            | UserProfile     |                                                                                                      | 1+       |
|                 | _DiscussedBy_    | 1:many            | Commentary      |                                                                                                      | \*       |
|                 | _References_     | many:many         | Artifact        |                                                                                                      | \*       |
| Competency      | _DemonstratedBy_ | many:many         | Entry           |                                                                                                      | \*       |
| Behavior        | _DemonstratedBy_ | many:many         | Entry           |                                                                                                      | \*       |
| Responsibility  | _DemonstratedBy_ | many:many         | Entry           |                                                                                                      | \*       |
| Result          | _DemonstratedBy_ | many:many         | Entry           |                                                                                                      | \*       |
| Commentary      | _Discusses_      | many:1            | Entry           |                                                                                                      | \*       |
| Artifact        | _ReferencedBy_   | many:many         | Entry           |                                                                                                      | 1+       |

## Graph Properties

The full set of data properties available on each vertex and edge

| Vertex/Edge    | Property        | Data Type | Notes                                                  | Required |
|----------------|-----------------|-----------|--------------------------------------------------------|----------|
| **(Any)**      | ID              | guid      |                                                        | 1        |
| Profession     | Title           | String    |                                                        | 1        |
|                | Description     | String    |                                                        | 0        |
| Discipline     | Title           | String    |                                                        | 1        |
|                | Description     | String    |                                                        | 0        |
| Role           | Title           | String    |                                                        | 1        |
|                | Description     | String    |                                                        | 0        |
|                | Level Band      | String    | SDE, SDE II, Senior, etc                               | 1        |
| Responsibility | Title           | String    |                                                        | 1        |
|                | Description     | String    |                                                        | 0        |
| Competency     | Title           | String    |                                                        | 1        |
|                | Description     | String    |                                                        | 0        |
| Key Result     | Description     | String    |                                                        | 1        |
| Behavior       | Description     | String    |                                                        | 1        |
| User Profile   | Theme selection | string    | there are only 2: dark, light                          | 1        |
|                | PersonaId       | guid[]    | there are only 2: User, Admin                          | 1+       |
|                | UserId          | guid      | Points to AAD object                                   | 1        |
|                | DeploymentRing  | string[]  | Is used to deploy new versions                         | 1        |
|                | Project         | string[]  | list of user created projects                          | \*       |
| Entry          | Title           | string    |                                                        | 1        |
|                | DateCreated     | date      |                                                        | 1        |
|                | ReadyToShare    | boolean   | false if draft                                         | 1        |
|                | AreaOfImpact    | string[]  | 3 options: self, contribute to others, leverage others | \*       |
| Commentary     | Data            | string    |                                                        | 1        |
|                | DateCreated     | date      |                                                        | 1        |
| Artifact       | Data            | string    |                                                        | 1        |
|                | DateCreated     | date      |                                                        | 1        |
|                | ArtifactType    | string    | describes the artifact type: markdown, blob link       | 1        |

## Vertex Descriptions

### Profession

Top most level of categorization

```json
{
    "title": "Software Engineering",
    "description": "Description of profession",
    "disciplines": []
}
```

### Discipline

Groups of related roles within a profession

```json
{
  "title": "Site Reliability Engineering",
  "description": "Description of discipline",
  "roles": []
}
```

### Role

Individual role mapped to an employee

```json
{
  "title": "Site Reliability Engineering IC2",
  "description": "Detailed description of role",
  "responsibilities": [],
  "competencies": []
}
```

### Responsibility

A group of expected outcomes and key results for employees within a role

```json
{
  "title": "Technical Knowledge and Domain Specific Expertise",
  "results": []
}
```

### Competency

A set of behaviors that contribute to success

```json
{
  "title": "Adaptability",
  "behaviors": []
}
```

### Key Result

The expected outcome of performing a responsibility

```json
{
  "description": "Develops a foundational understanding of distributed systems design..."
}
```

### Behavior

The way in which one acts or conducts oneself

```json
{
  "description": "Actively seeks information and tests assumptions."
}
```

### User

The user object refers to whom a person is.
We do not store our own rather use Azure OIDs.

### User Profile

The user profile contains any user settings and edges specific to Memory.

### Persona

A user may hold multiple personas.

### Entry

The same entry object can hold many kinds of data, and at this stage of the project we decide that we will not store external data, so it's up to the user to provide a link to the data for a reader to click into and get redirected to a new tab to open.

> **Note:** This means that in the web app, we will need to ensure links are opened in new tabs.

### Project

Projects are just string fields to represent what a user wants to group their entries under.

### Area of Impact

This refers to the 3 areas of impact in the venn-style diagram in the HR tool.
The options are: self, contributing to impact of others, building on others' work.

### Commentary

A comment is essentially a piece of text.
However, anyone that an entry is shared with can add commentary on an entry.

### Artifact

The artifact object contains the relevant data as markdown, or a link to the relevant data.

## Full Role JSON Example

```json
{
  "id": "abc123",
  "title": "Site Reliability Engineering IC2",
  "description": "Detailed description of role",
  "responsibilities": [
    {
      "id": "abc123",
      "title": "Technical Knowledge and Domain Specific Expertise",
      "results": [
        {
          "description": "Develops a foundational understanding of distributed systems design..."
        },
        {
          "description": "Develops an understanding of the code, features, and operations of specific products..."
        }
      ]
    },
    {
      "id": "abc123",
      "title": "Contributions to Development and Design",
      "results": [
        {
          "description": "Develops and tests basic changes to optimize code..."
        },
        {
          "description": "Supports ongoing engagements with product engineering teams..."
        }
      ]
    }
  ],
  "competencies": [
    {
      "id": "abc123",
      "title": "Adaptability",
      "behaviors": [
        { "description": "Actively seeks information and tests assumptions." },
        {
          "description": "Shifts his or her approach in response to the demands of a changing situation."
        }
      ]
    },
    {
      "id": "abc123",
      "title": "Collaboration",
      "behaviors": [
        {
          "description": "Removes barriers by working with others around a shared need or customer benefit."
        },
        {
          "description": " Incorporates diverse perspectives to thoroughly address complex business issues."
        }
      ]
    }
  ]
}
```

## API Data Model

Because there is no internal edges or vertices that need to be hidden from API consumers, the API will expose a 1:1 mapping of the current data model for consumption.
This is subject to change if our data model becomes too complex for downstream users.
