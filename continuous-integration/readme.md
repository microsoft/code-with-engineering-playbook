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
1. [Integration Validation](#Integration-Validation)
1. [Git Driven Workflow](#Git-Driven-Workflow)
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

&#9745; All artifacts required to build a project / service should be maintained in a single git repository. This does not mean all artifacts for an engagement should exist within a single repo as engagements typically maintain multiple build definitions. Artifacts required for a build should be co-located into a single repository. Your build [pipeline definition](https://docs.microsoft.com/en-us/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#define-pipelines-using-yaml-syntax) should also be managed within this repository.

## Build Automation

An automated build should encompass the following principles:

&#9745; The build definition should include steps like compiling the code, executing unit tests, running [code style checks](https://github.com/checkstyle/checkstyle), [static type checks](http://mypy-lang.org/) and [semantic validation checks](https://github.com/python/mypy/wiki/Semantic-Analyzer).

&#9745; In real world systems, different engineering teams are responsible for developing and maintaining various parts of a system. For such a case, it's unnecessary to have a single definition automate the build across the whole product. Build automation process(s) should be structured / developed for each individual part of the system.

&#9745; The build should include all steps required to setup an environment for use. This means the build should automate pulling database schemas from the scm repository and applying it to the target environment. This also includes automating the steps to seed that environment with the necessary test data required to run isolated end-to-end automated tests.

&#9745; A single command should have the capability of building the system. This is true for builds running on a CI server or on a developers local machine. 

&#9745; It's essential to have a master build that's runnable through standalone scripts and not dependent on a particular IDE. Build manifests should run locally for developers through their IDE of choice and should promote the flexibility to run within a CI server. As an example, dockerizing your build process offers this level of flexibility as VSCode and IntelliJ supports [docker plugin](https://code.visualstudio.com/docs/containers/overview) extensions.

## Build Environment Dependencies

&#9745; Build automation scripts often require certain software packages to be pre-installed within the runtime environment of the OS. This presents some challenges as build processes typically version lock these dependencies. For these reasons, the below principles should be considered when implementing your build automation tool chain. 

&#9745; Dependent software package installation like Docker, Maven, npm, etc should be baked into your build automation process. For this reason, docker should be considered as part of your CI workflow. 

&#9745; We want to put an emphasis on maintaining a consistent developer experience for all members of a dev crew. There should be a central automated manifest / process that streamlines the installation and setup of any software dependencies. This way developers can replicate the same build environment locally as the one running on a CI server.

## Integration Validation 

An effective way to identify bugs in your build at a rapid pace is to invest early into a reliable suite of automated tests that validate the baseline functionality of the system:

&#9745; Include tests in your pipeline to validate the build candidate conforms to automated business functionality assertions. Any bugs or broken code should be reported in the test results including the failed test and relevant stack trace. All tests should be invoked through a single command.

&#9745; Automated build checks, tests, lint runs, etc should be validated locally before committing your changes to the scm repo. [Test Driven Development](https://martinfowler.com/bliki/TestDrivenDevelopment.html) is a practice dev crews should consider to help identify bugs and failures as early as possible within the development lifecycle. 

&#9745; If the build step happens to fail then the build pipeline run status should be reported as failed including relevant logs and stacktraces.

## Git Driven Workflow

Every commit to the baseline repository should trigger the CI pipeline to create a new build candidate. Some principles to consider regarding build trigger events:

&#9745; The build pipeline is configured in a way where a pipeline run is triggered on every git commit.

&#9745; Any build artifact(s) are built, packaged, validated and deployed continuously into a non-production environment per commit.

&#9745; Merges into the master branch trigger releases into the production environment. This way the master branch becomes a dependable baseline for the code running in production.

&#9745; There should be no commented out tests in the mainline branch. By commenting out tests, we get an incorrect indication of the status of the build.

&#9745; Branch policies should be setup on the master branch so that the build pipeline status becomes a pre-req validation prior to starting a code review. Code review approvers will only start reviewing a pull request once the CI build run passes.

## Everyone Commits Their Work Every Day

## Remediate Build Failures

## Build Runtime

## Isolated Environments

## Developer Access to Latest Release Artifacts

## Integration Observability 

## Build Pipeline Status with Respect to Branch Policies

## Evidence and Measures

## Resources

