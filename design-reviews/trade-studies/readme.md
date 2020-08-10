# Trade Studies

Trade studies are a tool for selecting the best option out of several possible options for a given problem (for example: compute, storage).
They evaluate potential choices against a set of objective criteria/customer requirements to clearly lay out the benefits and limitations
of each solution.

[Trade studies](https://en.wikipedia.org/wiki/Trade_study) are a concept from systems engineering that we adapted for CSE projects. Trade
studies have proved to be a critical tool to drive alignment with the customers, earn credibility while doing so and ensure our decisions
were backed by data and not bias.  

## When to use the tool

The ideal stage to do trade studies is after the game plan completion and before coding begins; they go hand in hand with defining high
level architecture design. Further they can be used whenever the project requirements are changing, and we need to reevaluate solutions.

Trade studies should be avoided if there is a clear solution choice. Because they require each solution to be fully thought out, they
have the potential to take a lot of time to complete. When there is a clear design, the trade study should be omitted and an entry
should be made in the [Decision Log](../decision-log/readme.md) documenting the decision.

## Why Trade Studies

The biggest advantage of using trade studies is formalizing the decision-making process in a clear and objective manner. This gives a clear
flow for presenting the information to decision makers. We recommend the following approach for sharing information:

|Sharing Approach|Customer Cloud Maturity|Content Presentations|Tools Used fo Writing/Sharing|
|-|-|-|-|
|Lightweight|Beginner|Executive summary, Diagrams/visuals, comparison tables | Word doc with referenced Visio diagram and Excel tables, Wiki software with built-in visuals|
|Full Experience|Intermediate to advanced|All of the above, 30-50% of the trade study text|Same as above|

Additionally, filling out the trade study template provides structure to the design phase and leaves a documentation record of assumptions
and data that went into each decision.

## Flow of a Trade Study

Trade studies can vary widely in scope; however, they follow the common pattern below:

1. Solidify the requirements – Work with the customer to agree on the requirements for the functionality that you are trying to build.
1. Create evaluation criteria – This is a set of qualitative and quantitative assessment points that represent the requirements. Taken together, they become an easy to measure stand-in for the potentially abstract requirements.
1. Brainstorm solutions – Gather a list of possible solutions to the problem. Then, use your best judgement to pick the 2-4 solutions that seem most promising. For assistance narrowing solutions, reach out to Tech Domains, Product Groups and other XDC teams that have faced similar problems.
1. Evaluate shortlisted solutions – Dive deep into each solution and measure it against the evaluation criteria. In this stage, timebox your research to avoid overly investing in any given area.
1. Compare results and choose solution - Align the decision with the team. If you are unable to decide, then a clear list of action items and owners to drive the final decision must be produced.

## Template

See [template.md](./template.md) for an example of how to structure the above information. This template was created to guide a user
through conducting a trade study. Once the decision has been made we recommend adding an entry to the
[Decision Log](../decision-log/readme.md) that has references back to the full text of the trade study.
