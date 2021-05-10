# Cloud-Based Code Quality and Security Tool

Date: 04-05-2021

## Status

Deprecated

## Context

To write high quality code we wanted to have a tool that could detect bug, security vulnerabilities and code smells therefore reducing the technical debt.
The team decided to integrate SonarCloud in Azure pipeline to detect any issues within the code.

## Decision

We have agreed to not use SonarCloud for this project since the free version is limited only to public repositories and the Memory tool is a private repository.
Using SonarCloud would involve subscribing to their paid plan.
Other code smell tools like Checkstyle, PMD & FindBugs exist but they do not have extensive Go support like SonarCloud.
Additional research into alternatives will be accomplished as part of backlog item #22169.

Detailed SonarCloud pricing plan information can be found [here](https://sonarcloud.io/pricing).

## Consequences

- Not implementing SonarCloud leaves the project`s code quality and code security at potential risk which otherwise could be readily detected using the tool.
