# Trade Study Template

This generic template can be used for any situation where we have a set of requirements that can be satisfied
by multiple solutions. They can range in scope from choice of which open source package to use through full
architecture designs.

## Trade Study: {study name goes here}

Conducted by: {Names and at least one email address for follow up questions}

Backlog Work Item: {Link to the work item to provide more context}

Date:

Decision: {Solution chosen to proceed with}

Decision Makers:

Date:

## Overview

Description of the problem we are solving. This should include:

1. Assumptions about the rest of the system
1. Constraints that apply to the system, both business and technical
1. Requirements for the functionality that needs to be implemented, including possible inputs and outputs
1. [Optional] A diagram showing the different pieces

### Evaluation Criteria

The former should be condensed down to a set of "evaluation criteria" that we can rate any potential solutions
against. Examples of evaluation criteria:

* Runs on Windows and Linux - Binary response
* Compute Usage - Could be categories that effectively rank different options: High, Medium, Low
* Cost of the solution – An estimated numeric field

The results section contains a table evaluating each solution against the evaluation criteria.

## Solutions

The following sections enumerate possible solutions to this problem. There should be at least two options
compared, otherwise you didn't need a trade study.

### {Solution 1} - Short easily recognizable name

Each solution section should contain the following:

1. Description of the solution
1. (optional) A diagram to quickly reference the solution
1. Possible variations - things that are small variations on the main solution can be grouped together
1. Evaluation of the idea based on the evaluation criteria above

The depth, detail, and contents of these sections will vary based on the complexity of the functionality
being developed.

### {Solution 2}

...

### {Solution N}

## Results

This section should contain a table that has each solution rated against each of the evaluation criteria:

|Solution|Evaluation Criteria 1|Evaluation Criteria 2|...|Evaluation Criteria N|
|--------|---------------------|---------------------|---|---------------------|
|Solution 1|||||
|Solution 2|||||
|...|||||
|Solution M|||||

Note: The formatting of the table can change. In the past, we have had success with qualitative descriptions
in the table entries and color coding the cells to represent good, fair, bad.

## Decision

The chosen solution, or a list of questions that need to be answered before the decision can be made.

In the latter case, each question needs an action item and an assigned person for answering the question.
Once those questions are answered, the document must be updated to reflect the answers and the final decision
