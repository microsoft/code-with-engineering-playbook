# Continuous Integration

Developers working on [CSE](../CSE.md) projects should make an early investment(typically Sprint 0) to establish an automated and repeatable pipeline that can integrate the code across the engineering team. Each integration should be verified by an automated build which runs a series of tests to surface integration errors and block any generation of build artifact(s) in the presence of failures.

We encourage teams to implement the CI/CD pipelines before any service code is written in a project, which usually happens in Sprint 0(N). This way, the engineering team can develop and test their work in isolation and avoid impacting other developers on the team. 

<!-- markdownlint-disable MD036 -->
**Table of contents**
<!-- markdownlint-enable MD036 -->

1. [Goals](#goals)
1. [Single Source Repository](#single-source-repository)
1. [Build Automation](#build-automation)
1. [Build Environment Dependencies](#build-environment-dependencies)
1. [Evidence and Measures](#evidence-and-measures)
1. [Resources](#resources)

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

All artifacts required to build a project / service should be maintained in a single git repository. This does not mean all artifacts for an engagement should exist within a single repo as engagements typically maintain multiple build definitions. Artifacts required for a build should be co-located into a single repository. Your build [pipeline definition](https://docs.microsoft.com/en-us/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#define-pipelines-using-yaml-syntax) should also be managed within this repository.

## Build Automation

An automated build should encompass the following principles:

&#9745; The build definition should include steps like compiling the code, executing unit tests, running [code style checks](https://github.com/checkstyle/checkstyle), [static type checks](http://mypy-lang.org/) and [semantic validation checks](https://github.com/python/mypy/wiki/Semantic-Analyzer).

&#9745; In real world systems, different engineering teams are responsible for developing and maintaining various parts of a system. In that instance, it's unnecessary to have a single definition automate the build across the whole product. Build automation process(s) should be structured / developed for each individual part of the system.

&#9745; The build should include all steps required to setup an environment for use. This means the build should automate pulling database schemas from the scm repository and applying it to the target environment. Also, should include seeding that environment with the necessary test data required to run isolated end-to-end automated tests.  

&#9745; A single command should have the capability of building the system. This is true for builds running on a CI server or on a developers local machine. 

&#9745; It's essential to have a master build that's runnable through standalone scripts and not dependent on a particular IDE. Build manifests should run locally for developers through their IDE of choice and should promote the flexibility to run within a CI server. As an example, dockerizing your build process offers this level of flexibility as VSCode and IntelliJ supports [docker plugin](https://code.visualstudio.com/docs/containers/overview) extensions.

## Build Environment Dependencies

&#9745; Build automation scripts often require certain software packages to be pre-installed within the runtime environment of the OS. This presents some challenges as build processes typically version lock these dependencies. For these reasons, the below principles should be considered when implementing your build automation tool chain. 

&#9745; Dependent software package installation like Docker, Maven, npm, etc should be baked into your build automation process. For this reason, docker should be considered as part of your CI workflow. 

&#9745; We want to put an emphasis on maintaining a consistent developer experience for all members of a dev crew. There should be a central automated manifest / process that streamlines the installation and setup of any software dependencies. This way developers can replicate the same build environment locally as the one running on a CI server.

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

