# Continuous Delivery

The inspiration behind continuous delivery is constantly delivering valuable software to users and developers more frequently. Applying the principles and practices laid out in this readme will help you reduce risk, eliminate manual operations and increase quality and confidence.

Deploying software involves the following principles:

1. Provision and manage the cloud environment runtime for your application (cloud resources, infrastructure, hardware, services, etc).

1. Install the target application version across your cloud environments.

1. Configure your application, including any required data.

A continuous deployment pipeline is an automated manifestation of your process to streamline these very principles in a consistent and repeatable manner.

## Goal

* Follow industry best practices for delivering software changes to customers and developers.

* Establish consistency for the guiding principles and best practices when assembling continuous delivery workflows.

## General Guidance

### Define a Release Strategy

It's important to establish a common understanding between the technical lead and application stakeholder(s) around the release strategy / design  during the planning phase of a project. This common understanding includes the deployment and maintenance of the application throughout its SDLC.

#### Release Strategy Principles

*Continuous Delivery* by Jez Humble, David Farley cover the key considerations to follow when creating a release strategy:

* _Parties in charge of deployments to each environment, as well as in charge of the release._

* _An asset and configuration management strategy._

* _An enumeration of the environments available for acceptance, capacity, integration, and user acceptance testing, and the process by which builds will be moved through these environments._

* _A description of the processes to be followed for deployment into testing and production environments, such as change requests to be opened and approvals that need to be granted._

* _A discussion of the method by which the application’s deploy-time and runtime configuration will be managed, and how this relates to the automated deployment process._

* _Description of the integration with any external systems. At what stage and how are they tested as part of a release? How does the technical operator communicate with the provider in the event of a problem?_

* _A disaster recovery plan so that the application’s state can be recovered following a disaster. Which steps will need to be in place to restart or redeploy the application should it fail._

* _Production sizing and capacity planning: How much data will your live application create? How many log files or databases will you need? How much bandwidth and disk space will you need? What latency are clients expecting?_

* _How the initial deployment to production works._

* _How fixing defects and applying patches to the production environment will be handled._

* How upgrades to the production environment will be handled, including data migration. How will upgrades be carried out to the application without destroying its state.

### Application Release and Environment Promotion

Your release manifestation process should take the binaries created from your commit stage and deploy them across all cloud environments, starting with your test environment.

The test environment (_often called Integration_) acts as a gate to validate your test suite completes successfully for all release candidates.

#### The First Deployment

The very first deployment of any application should be showcased to the customer in a production-like environment (_UAT_) to solicit feedback early and often.

#### Criteria for a production-like environment

* Runs the same operating system as production.
* Has the same software installed as production.
* Is sized and configured the same way as production.
* Mirrors production's networking topology.
* Simulated production-like load tests are executed following a release to surface any latency or throughput degradation.

#### Modeling your Release Pipeline

It's critical to model your test and release process to establish a common understanding between the application engineers and customer stakeholders. Specifically aligning expectations for how many cloud environments need to be pre-provisioned as well as defining sign-off gate roles and responsibilities.

![image](https://user-images.githubusercontent.com/7635865/89290276-426ca200-d61e-11ea-9c79-bd183dc72050.png)

##### The release pipeline model should depict:

* All stages an application change would have to go through before it is released to production.
* All release gate controls.
* Customer-specific Cloud RBAC groups which have the authority to approve release candidates per environment.

#### Release Pipeline Stages

The stages within your release workflow are ultimately testing a version of your application to validate it can be released in accordance to your acceptance criteria. The release pipeline should account for the following conditions:

* Release Selection: The developer carrying out application testing should have the capability to select which release version to deploy to the testing environment.
* Environment Readiness - Clean the target cloud environment so it is ready to host a new version of the application.
* Deployment - Release the application binary(s) to the target cloud environment.
* Configuration - Applications should be configured in a consistent manner across all your environments. This configuration is applied at the time of deployment. Application Secrets should not be exposed within the runtime environment. Sensitive data like app secrets and certificates should be mastered in Key Vault and sourced internally within the application itself. We encourage 12 Factor principles, especially when it comes to [configuration management](https://12factor.net/config).
* Data Migration - Pre populate application state and/or data records which is needed for your runtime environment. This may also include test data required for your end-to-end integration test suite.
* Deployment smoke test. Your smoke test should also verify that your application is pointing to the correct configuration (e.g. production pointing to a UAT Database).
* Perform any manual or automated acceptance test scenarios.
* Approve the release gate to promote the application version to the target cloud environment. This promotion should also include the environment's configuration state (e.g. new env settings, feature flags, etc).

#### Pre-production releases

Application release candidates should be deployed to a staging environment similar to production for carrying out final manual/automated tests (_including capacity testing_). Your production and staging / pre-prod cloud environments should be setup at the beginning of your project.

Application warm up should be a quantified measurement that's validated as part of your pre-prod smoke tests.

### Rolling-Back Releases

Your release strategy should account for rollback scenarios in the event of unexpected failures following a deployment.

Rolling back releases can get tricky, especially when database record/object changes occur in result of your deployment (*either inadvertently or intentionally*). If there are no data changes which need to be backed out, then you can simply trigger a new release candidate for the last known production version and promote that release along your CD pipeline.

For rollback scenarios involving data changes, there are several approaches to mitigating this which fall outside of the scope of this guide. Some involve database record versioning, time machining database records / objects, etc. All data files and databases should be backed up prior to each release so they could be restored. The mitigation strategy for this scenario will vary across our projects. The expectation is that this mitigation strategy should be covered as part of your release strategy.

### Zero Downtime Releases

A hot deployment follows a process of switching users from one release to another with no impact to the user experience. As an example, Azure managed app services allows developers to validate app changes in a staging deployment slot before swapping it with the production slot. App Service slot swapping can also be fully automated once the source slot is fully warmed up (and [auto swap](https://docs.microsoft.com/en-us/azure/app-service/deploy-staging-slots#configure-auto-swap) is enabled). Slot swapping also simplifies release rollbacks once a technical operator restores the slots to their pre-swap states.

Kubernetes natively supports [rolling updates](https://kubernetes.io/docs/tutorials/kubernetes-basics/update/update-intro/).

### Blue-Green Deployments

Blue / Green is a deployment technique which reduces downtime by running two identical instances of a production environment called _Blue_ and _Green_.

Only one of these environments accepts live production traffic at a given time.

![image](https://user-images.githubusercontent.com/7635865/89334870-d4939b00-d65c-11ea-8e82-9c374518766a.png)

In the above example, live production traffic is routed to the Green environment. During application releases, the new version is deployed to the blue environment which occurs independently from the Green environment. Live traffic is unaffected from Blue environment releases. You can point your end-to-end test suite against the Blue environment as one of your test checkouts.

Migrating users to the new application version is as simple as changing the router configuration to direct all traffic to the Blue environment.

This technique simplifies rollback scenarios as we can simply switch the router back to Green.

Database providers like Cosmos and Azure SQL natively support data replication to help enable fully synchronized Blue Green database environments.

### Canary Releasing

Canary releasing enables development teams to gather faster feedback when deploying new features to production. These releases are rolled out to a subset of production nodes (_where no users are routed to_) to collect early insights around capacity testing and functional completeness and impact.
![image](https://user-images.githubusercontent.com/7635865/89341436-ee39e000-d666-11ea-98f8-4b3980f670ae.png)

Once smoke and capacity tests are completed, you can route a small subset of users to the production nodes hosting the release candidate.

Canary releases simplify rollbacks as you can avoid routing users to bad application versions.

Try to limit the number of versions of your application running parallel in production, as it can complicate maintenance and monitoring controls.