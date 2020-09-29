# 2. App-level Logging with Serilog and Application Insights

Date: 2020-04-08

## Status

Accepted

## Context

Due to the microservices design of the platform, we need to ensure consistency of logging throughout each service so tracking of usage, performance, errors etc. can be performed end-to-end. A single logging/monitoring framework should be used where possible to achieve this, whilst allowing the flexibility for integration/export into other tools at a later stage. The developers should be equipped with a simple interface to log messages and metrics.

## Decision

We have agreed to utilise Serilog as the Dotnet Logging framework of choice at the application level, with integration into Log Analytics and Application Insights for analysis.

## Consequences

Sampling will need to be configured in Application Insights so that it does not become overly-expensive when ingesting millions of messages, but also does not prevent capture of essential information.
The team will need to only log what is agreed to be essential for monitoring as part of design reviews, to reduce noise and unneccesary levels of sampling.
