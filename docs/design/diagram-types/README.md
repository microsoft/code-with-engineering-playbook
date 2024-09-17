# Diagram Types

Creating and maintaining diagrams is a challenge for any team. Common reasons across these challenges include:

- Not leveraging tools to assist in generating diagrams
- Uncertainty on what to include in a diagram and when to create one

Overcoming these challenges and effectively using design diagrams can amplify a team's ability to execute throughout the entire Software Development Lifecycle, from the design phase when proposing various designs to leveraging it as documentation as part of the maintenance phase.

This section will share sample tools for diagram generation, provide a high level overview of the different types of diagrams and provide examples of some of these types.

There are two primary classes of diagrams:

- Structural
- Behavior

Within each of these classes, there are many types of diagrams, each intended to convey specific types of information. When different types of diagrams are effectively used in a solution, system, or repository, one can deliver a cohesive and incrementally detailed design.

## Sample Design Diagrams

This section contains educational material and examples for the following design diagrams:

- [Class Diagrams](./class-diagrams.md) - Useful to document the structural design of a codebase's relationship between classes, and their corresponding methods
- [Component Diagrams](./component-diagrams.md) - Useful to document a high level structural overview of all the components and their direct "touch points" with other Components
- [Sequence Diagrams](./sequence-diagrams.md) - Useful to document a behavior overview of the system, capturing the various "use cases" or "actions" that triggers the system to perform some business logic
- [Deployment Diagram](./deployment-diagrams.md) - Useful in order to document the networking and hosting environments where the system will operate in

## Supplemental Resources

Each of the above types of diagrams will provide specific resources related to its type. Below are the generic resources:

- [Visual Paradigm UML Structural vs Behavior Diagrams](https://www.visual-paradigm.com/cn/guide/uml-unified-modeling-language/uml-)
- [PlantUML](https://marketplace.visualstudio.com/items?itemName=jebbs.plantuml) - requires a generator from code to PlantUML syntax to generate diagrams
  - [C# to PlantUML](https://marketplace.visualstudio.com/items?itemName=pierre3.csharp-to-plantuml)
  - [Drawing manually](https://towardsdatascience.com/drawing-a-uml-diagram-in-the-vs-code-53c2e67deffe)
