# Continuous Integration

Developers working on [CSE](../CSE.md) projects should make an early investment(typically Sprint 0) to establish an automated and repeatable pipeline that can integrate the code across the engineering team. Each integration should be verified by an automated build which runs a series of tests to surface integration errors and block any generation of build artifact(s) in the presence of failures.

We encourage teams to implement the CI/CD pipelines before any service code is written in a project, which usually happens in Sprint 0(N). This way, the engineering team can develop and test their work in isolation and avoid impacting other developers on the team. 

<!-- markdownlint-disable MD036 -->
**Table of contents**
<!-- markdownlint-enable MD036 -->

1. [Goals](#goals)
1. [Single Source Repository](#single-source-repository)
1. [First Design Pass](#first-design-pass)
1. [Code Quality Pass](#code-quality-pass)
1. [Evidence and Measures](#evidence-and-measures)
1. [Language Specific Guidance](#language-specific-guidance)
1. [Resources](#resources)
1. [Q&A](#q&a)

## Goals

Continuous integration automation is an integral part of the software development lifecycle intended to reduce errors during build integration and maximize velocity across a dev crew. A robust build automation / validation pipeline will ultimately:

1. Accelerate team velocity where build automation tool chains(Maven, MSBuild, etc) can run either locally or in a CI Server and continuously report errors.

1. Prevent integration problems

1. Avoid last minute chaos during release dates

1. Staging Builds

1. Enforces discipline of frequent automated testing

1. Quick feedback cycle for system-wide impact of local changes

1. Software Build and Deployment Separation 

1. Measuring metrics around build failures / success(s)

1. Increase visibility across the team enabling tighter communication

1. Most importantly, automating the build

## Single Source Repository

## Build Automation

## Integration Validation 

## Git Commit Driven Workflow

## Remediate Build Failures

## Build Runtime

## Isolated Environments

## Developer Access to Latest Release Artifacts

## Integration Observability 

## Daily SCM Checkins

## Build Pipeline Status with Respect to Branch Policies

## Evidence and Measures

## Resources

