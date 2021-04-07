# Trade Studies

Trade studies are a tool for selecting the best option out of several possible options for a given problem (for example: compute, storage).
They evaluate potential choices against a set of objective criteria/requirements to clearly lay out the benefits and limitations
of each solution.

[Trade studies](https://en.wikipedia.org/wiki/Trade_study) are a concept from systems engineering that we adapted for software projects. Trade
studies have proved to be a critical tool to drive alignment with the stakeholders, earn credibility while doing so and ensure our decisions
were backed by data and not bias.  

## When to use the tool

Trade studies go hand in hand with high level architecture design. This usually occurs as project requirements are solidifying, before
coding begins. Trade studies continue to be useful throughout the project at any time where there are multiple options that need
to be selected from. New decision point could occur from changing requirements, getting results of a research spike, or identifying
challenges that were not originally seen.

Trade studies should be avoided if there is a clear solution choice. Because they require each solution to be fully thought out, they
have the potential to take a lot of time to complete. When there is a clear design, the trade study should be omitted and an entry
should be made in the [Decision Log](../decision-log/readme.md) documenting the decision.

## Why Trade Studies

Trade studies are a way of formalizing the design process and leaving a documentation record for why the decision was made. This gives a few advantages:

1. The trade study template guides a user through the design process. This provides structure to the design stage.
1. Having a uniform design process aids splitting work amongst team members. We have had success with engineers pairing to define requirements, evaluation criteria, and brainstorming possible solutions. Then they can each split to review solutions in parallel, before rejoining to make the final decision.
1. The completed trade study document helps drive alignment across the team and decision makers. For presenting results of the study, the document itself can be used to highlight the main points. Alternatively, we have extracted requirements, diagrams for each solution and the results table into a slide deck to give high level overviews of the results.
1. The completed trade study gets checked into the code repository, providing documentation of the decision process. This leaves a history of the requirements at the time that lead to each decision. Also, the results table gives a quick reference for how the decision would be impacted if requirements change as the project proceeds.

## Flow of a Trade Study

Trade studies can vary widely in scope; however, they follow the common pattern below:

1. Solidify the requirements – Work with the stakeholders to agree on the requirements for the functionality that you are trying to build.
1. Create evaluation criteria – This is a set of qualitative and quantitative assessment points that represent the requirements. Taken together, they become an easy to measure stand-in for the potentially abstract requirements.
1. Brainstorm solutions – Gather a list of possible solutions to the problem. Then, use your best judgement to pick the 2-4 solutions that seem most promising. For assistance narrowing solutions, remember to reach out to subject matter experts and other teams who may have gone through a similar decision.
1. Evaluate shortlisted solutions – Dive deep into each solution and measure it against the evaluation criteria. In this stage, time box your research to avoid overly investing in any given area.
1. Compare results and choose solution - Align the decision with the team. If you are unable to decide, then a clear list of action items and owners to drive the final decision must be produced.

## Template

See [template.md](./template.md) for an example of how to structure the above information. This template was created to guide a user
through conducting a trade study. Once the decision has been made we recommend adding an entry to the
[Decision Log](../decision-log/readme.md) that has references back to the full text of the trade study.
