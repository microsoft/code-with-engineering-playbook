# Application Deployment

The Memory application leverages [Azure DevOps](https://learn.microsoft.com/en-gb/azure/devops/index?view=azure-devops) for work item tracking as well as continuous integration (CI) and continuous deployment (CD).

## Environments

The Memory project uses multiple environments to isolate and test changes before promoting releases to the global user base.

New environment rollouts are automatically triggered based upon a successful deployment of the previous stage /environment.

The **development**, **staging** and **production** environments leverage slot deployment during an environment rollout.
After a new release is deployed to a staging slot, it is validated through a series of functional integration tests.
Upon a 100% pass rate of all tests the staging & production slots are swapped effectively making updates to the environment available.

Any errors or failed tests halt the deployment in the current stage and prevent changes to further environments.

Each deployed environment is completely isolated and does not share any components.
They each have unique resource instances of Azure Traffic Manager, Cosmos DB, etc.

### Deployment Dependencies

| Development      | Staging     | Production      |
|------------------|-------------|-----------------|
| CI Quality Gates | Development | Staging         |
|                  |             | Manual Approval |

### Local

The local environment is used by individual software engineers during the development of new features and components.

Engineers leverage some components from the deployed development environment that are not available on certain platforms or are unable to run locally.

- CosmosDB (Emulator only exists for Windows)

The local environment also does not use Azure Traffic Manager.
The frontend web app directly communicates to the backend REST API typically running on a separate localhost port mapping.

### Development

The development environment is used as the first quality gate.
All code that is checked into the `main` branch is automatically deployed to this environment after all CI quality gates have passed.

#### Dev Regions

- West US (westus)

### Staging

The staging environment is used to validate new features, components and other changes prior to production rollout.
This environment is primarily used by developers, QA and other company stakeholders.

#### Staging Regions

- West US (westus)
- East US (eastus)

### Production

The production environment is used by the worldwide user base.
Changes to this environment are gated by manual approval by your product's leadership team in addition to other automatic quality gates.

#### Production Regions

- West US (westus)
- Central US (centralus)
- East US (eastus)

## Environment Variable Group

### Infrastructure Setup (memory-common)

- appName
- businessUnit
- serviceConnection
- subscriptionId

### Development Setup (memory-dev)

- environmentName (placeholder)

### Staging Setup (memory-staging)

- environmentName (placeholder)

### Production Setup (memory-prod)

- environmentName (placeholder)
