# Deployment Scripts

Overview of the helper scripts used to deploy the full application.

## Infrastructure Deployment

### Resources

The following is a list of resources currently required for the Memory application

|     | Global             | Regional                       |
| --- | ------------------ | ------------------------------ |
| 1   | Traffic Manager    |                                |
| 2   | Cosmos             |                                |
| 3   | Container Registry |                                |
| 4   |                    | Kubernetes Managed Cluster     |
| 5   |                    | Container Registry Replication |

### Script (deploy.sh)

A script typically used for setting up new environments for dev/test/qa.
Currently hard coded with values.

#### Parameters

- businessUnit - Your companies' business unit / team name
- appName - The name of your app
- env - The environment to deploy (dev, test, prod, etc)
- locations - The Azure location to deploy to

#### Example

```bash
bash deployment/scripts/deploy.sh
  -u cse \
  -a memory \
  -e prod \
  -r westus,eastus,centralus
```

> The script supports passing 1 or many locations as the last parameter

---

## Regional Deployment

The Memory app supports deployment to multiple regions

### region.json

The ARM template that composes all the required regional resources for the application including:

- Storage Account (Used for front end static app hosting)
- App Service (Used for backend API service)
- App Insights (Used for observability)
- App Service Plan (Used to host the API app service)
- API Management (Used to create a consistent API surface for all backend micro services)

### Script (deploy-region.sh)

The regional deployment script uses a combination of `businessUnit`, `appName`, `env` and `location` to construct a scoped suffix used as a naming convention for the resource group / resources required for this application.

The parameters are passed into the `region.json` ARM template and deployed through the Azure CLI

> This script is used within the Azure pipelines for parallel regional deployment

#### Regional Script Parameters

- businessUnit - Your companies' business unit / team name
- appName - The name of your app
- env - The environment to deploy (dev, test, prod, etc)
- location - The Azure location to deploy to

#### Regional Script Example

```bash
bash deployment/scripts/deploy-region.sh \
  -u cse \
  -a memory \
  -e prod \
  -r westus
```

> The script deploys to a single specified region

---

## Global Deployment

The Memory consists of global components required for deployment that work across regions

### global.json

The ARM template that composes all the required global resources for the application including:

- Cosmos DB
  - A multi-region deployment with multi-write database
- Traffic Manager
  - A DNS based load balancer to route traffic to closest deployed AKS cluster
- Container Registry
  - A central location to publish docker images referenced in Helm charts.
  - Replication is enabled to support low latency deployments from multiple clusters

### Script (deploy-global.sh)

The global deployment script that uses a combination of `businessUnit`, `appName` and `env` to construct a scoped suffix used as a naming convention for the resource group / resources required for this application.

> This script is used within the Azure pipelines after all regional deployment is completed

#### Global Script Parameters

- businessUnit - Your companies' business unit / team name
- appName - The name of your app
- env - The environment to deploy (dev, test, prod, etc)
- locations - The regional azure locations that are deployed

#### Global Script Example

```bash
bash deployment/scripts/deploy-global.sh \
  -u cse \
  -a memory \
  -e prod \
  -r westus,eastus,centralus
```

> This script is used within the Azure pipelines for parallel regional deployment
