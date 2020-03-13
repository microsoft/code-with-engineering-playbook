![image](https://user-images.githubusercontent.com/7635865/76624154-c2c12800-6502-11ea-912d-a260c821ac41.png)

# Continuous Integration

Developers working on [CSE](../CSE.md) projects should make an upfront investment(typically Sprint 0) to establish an automated and repeatable pipeline that integrates code continuously across the engineering team. Each integration should be verified by an automated build which runs a series of tests to surface integration errors and block any generation of build artifact(s) in the presence of failures.

We encourage teams to implement the CI/CD pipelines before any service code is written in a project, which usually happens in Sprint 0(N). This way, the engineering team can develop and test their work in isolation and avoid impacting other developers on the team. This way, both the dev crew and our customer(s) follow a consistent devops workflow.

These [principles](https://martinfowler.com/articles/continuousIntegration.html) map directly to key agile and lean SDLC practices. 

<!-- markdownlint-disable MD036 -->
**Table of contents**
<!-- markdownlint-enable MD036 -->

1. [Goals](#goals)
1. [Single Source Repository](#single-source-repository)
1. [Build Automation](#build-automation)
1. [Build Environment Dependencies](#build-environment-dependencies)
1. [Infrastructure As Code](#Infrastructure-as-Code)
1. [Integration Validation](#Integration-Validation)
1. [Git Driven Workflow](#Git-Driven-Workflow)
1. [Everyone Commits Their Work Every Day](#Everyone-Commits-Their-Work-Every-Day)
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

### Principles

&#9745; All artifacts required to build a project / service should be maintained in a single git repository. This does not mean all artifacts for an engagement should exist within a single repo as engagements typically maintain multiple build definitions. Artifacts required for a build should be co-located into a single repository. Your build [pipeline definition](https://docs.microsoft.com/en-us/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#define-pipelines-using-yaml-syntax) should also be managed within this repository.

## Build Automation

An automated build should encompass the following principles:

### Principles

&#9745; The build definition should include steps like compiling the code, executing unit tests, running [code style checks](https://github.com/checkstyle/checkstyle), [static type checks](http://mypy-lang.org/) and [semantic validation checks](https://github.com/python/mypy/wiki/Semantic-Analyzer).

&#9745; In real world systems, different engineering teams are responsible for developing and maintaining various parts of a system. For such a case, it's unnecessary to have a single definition automate the build across the whole product. Build automation process(s) should be structured / developed for each individual part of the system. For example, one dev team may have one CI build pipeline to automate micro service integration and another to automate serverless components like Azure Functions and another for Databricks jobs.

&#9745; The build should include all steps required to setup an environment for use. This means the build should automate pulling database schemas from the scm repository and applying it to the target environment. This also includes automating the steps to seed that environment with the necessary test data required to run isolated end-to-end automated tests.

&#9745; A single command should have the capability of building the system. This is true for builds running on a CI server or on a developers local machine. 

&#9745; It's essential to have a master build that's runnable through standalone scripts and not dependent on a particular IDE. Build manifests should run locally for developers through their IDE of choice and should promote the flexibility to run within a CI server. As an example, dockerizing your build process offers this level of flexibility as VSCode and IntelliJ supports [docker plugin](https://code.visualstudio.com/docs/containers/overview) extensions.

## Build Environment Dependencies

### Principles

&#9745; Build automation scripts often require certain software packages to be pre-installed within the runtime environment of the OS. This presents some challenges as build processes typically version lock these dependencies. For these reasons, the below principles should be considered when implementing your build automation tool chain. 

&#9745; Dependent software package installation like Docker, Maven, npm, etc should be baked into your build automation process. For this reason, docker should be considered as part of your CI workflow. 

&#9745; We want to put an emphasis on maintaining a consistent developer experience for all members of a dev crew. There should be a central automated manifest / process that streamlines the installation and setup of any software dependencies. This way developers can replicate the same build environment locally as the one running on a CI server.

## Infrastructure as Code

One approach we recommend: manage (almost) everything as code. This includes: 

- Configuration Files
- Configuration Management
- Secret Management
- Cloud Resource Provisioning
- Role Assignments
- Load Test Scenarios
- Availability Alerting / Monitoring Rules and Conditions

Decoupling infrastructure from the application codebase simplifies engineering teams move to cloud native applications.

**Why**

- Repeatable and auditable changes to infrastructure make it easier to roll back to known good configurations and to rapidly expand to new stages and regions without having to hand-wire cloud resources

- Battle tested and templatized IAC reference projects like [Cobalt](https://github.com/microsoft/cobalt) and [Bedrock](https://github.com/microsoft/bedrock) enable more business teams deploy secure and scalable solutions at a much more rapid pace

- Simplify “lift and shift” scenarios by abstracting the complexities of cloud-native computing away from application developer teams.

**IAC DevOPS: Operations by Pull Request**

- The Infrastructure deployment process built around a repo that holds the current expected state of the system / Azure environment.

- Operational changes are made to the running system by making commits on this repo.

- Git also provides a simple model for auditing deployments and rolling back to a previous state.

**Infrastructure Advocated Patterns**

- You define infrastructure as code in Terraform / ARM / Ansible templates

- Templates are repeatable cloud resource stacks with a focus on configuration sets aligned with app scaling and throughput needs.

### Principles

&#9745; All cloud resources are provisioned through a set of infrastructure as code templates. This also includes secrets, service configuration settings, role assignments and monitoring conditions.

&#9745; When the IAC templates change through a git-based workflow, A CI build pipeline should build, validate and reconcile the target infrastructure environment's current state and expected state. The infrastructure execution plan candidate for these fixed environments should be reviewed by an cloud administer as a gate check prior to execution.

&#9745; Developer accounts in active directory should have read-only access to fixed environments in Azure. Developers can interface with these environments through a system generated service principal which has read/write access.

&#9745; Secrets and configuration changes should only be carried out through the IAC devops workflow. In summary, secret management should be automated and repeatable to promote consistency across environments and developer-specific test environments.

## Integration Validation 

An effective way to identify bugs in your build at a rapid pace is to invest early into a reliable suite of automated tests that validate the baseline functionality of the system:

### Principles

&#9745; Include tests in your pipeline to validate the build candidate conforms to automated business functionality assertions. Any bugs or broken code should be reported in the test results including the failed test and relevant stack trace. All tests should be invoked through a single command.

&#9745; Automated build checks, tests, lint runs, etc should be validated locally before committing your changes to the scm repo. [Test Driven Development](https://martinfowler.com/bliki/TestDrivenDevelopment.html) is a practice dev crews should consider to help identify bugs and failures as early as possible within the development lifecycle. 

&#9745; If the build step happens to fail then the build pipeline run status should be reported as failed including relevant logs and stacktraces.

&#9745; Any mocked dataset(s) used for unit and end-to-end integration tests should be checked into the mainline repository. Minimize any external data dependencies with your build process.

## Git Driven Workflow

Every commit to the baseline repository should trigger the CI pipeline to create a new build candidate. Some principles to consider regarding build trigger events:

### Principles

&#9745; The build pipeline is configured in a way where a pipeline run is triggered on every git commit.

&#9745; Any build artifact(s) are built, packaged, validated and deployed continuously into a non-production environment per commit. Each commit against the repository results into a CI run which checks out the sources onto the integration machine, initiates a build, and notifies the committer of the result of the build.

&#9745; Merges into the master branch trigger releases into the production environment(s). This way the master branch becomes a dependable baseline for the code running in production. 

&#9745; Avoid commenting out tests in the mainline branch. By commenting out tests, we get an incorrect indication of the status of the build.

&#9745; Branch policies should be setup on the master branch so that the build pipeline status becomes a pre-req validation prior to starting a code review. Code review approvers will only start reviewing a pull request once the CI pipeline run passes for the latest pushed git commit.

## Deliver Quickly / Daily

"By committing regularly, every committer can reduce the number of conflicting changes. Checking in a week's worth of work runs the risk of conflicting with other features and can be very difficult to resolve. Early, small conflicts in an area of the system cause team members to communicate about the change they are making."

In the spirit of transparency and embracing frequent communication across a dev crew, we encourage developers to commit code on a daily cadence. This approach provides visibility to feature progress and accelerates pair programming across the team. Here are some principles to consider:

### Principles

&#9745; End of day checked-in code should contain unit tests at the minimum.

&#9745; Run the build locally before checking in to avoid CI pipeline failure saturation. You should verify what caused the error, and try to solve it as soon as possible instead of committing your code. We encourage developers to follow a [lean SDLC principles](https://leankit.com/learn/lean/principles-of-lean-development/) and isolate work in small chunks which ties directly to business value and refactor incrementally.

## Isolated Environments

## Developer Access to Latest Release Artifacts

## Integration Observability 

## Build Pipeline Status with Respect to Branch Policies

## Evidence and Measures

## Resources

