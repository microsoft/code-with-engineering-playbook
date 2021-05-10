# Memory Storage System

## Trade Study: Graph Database

Conducted by:

- Tess DiStefano tedistef@microsoft.com
- Zach Miller zamiller@microsoft.com
- Wallace Breza wabrez@microsoft.com

Backlog Work Item: #21650

Decision: CosmosDB

Decision Makers: Memory Team

## Overview

Memory has storage needs.
Namely, we need to be able to store data entered by the writer for easy retrieval later, as well as for analysis during a review.

We would like to store data in a graph database, as we intend to use a graph API to retrieve it.

### Evaluation Criteria

1. Graph database: Is this a graph database?
1. GoLang: What is the Quality of DX (dev experience) using GoLang?
1. Deployment: What are methods of deploying updates?
1. Access methods: Managed Identity?
1. Replicability: How easy is it to make the data geo-redundant?
1. Upskilling: Is this a new technology which will help us prepare for future projects?
1. Compute Usage: High, Medium, Low.
1. Cost of the solution window.

## Solutions

The proposed solutions are Blob Storage, Cosmos DB, SQL Server with a graph database option, Neo4j, JanusGraph, or ArangoDB.

### {Solution 1} - Blob Storage

Unfortunately, it doesn't look like Blob Storage supports use as graph storage.
This solution does not meet the first requirement of being a graph database.

### {Solution 2} - Cosmos DB

[Azure Cosmos DB](https://azure.microsoft.com/en-us/services/cosmos-db/) is a non-relational database which exposes the [Gremlin graph API](https://docs.microsoft.com/en-us/azure/cosmos-db/graph-introduction).
This API exposure allows readers to treat data as stored in a graph model.
Importantly, Cosmos DB [is not opinionated on the access pattern](https://docs.microsoft.com/en-us/azure/cosmos-db/relational-nosql#complex-networks-and-relationships):

> Azure Cosmos DB is a multi-model database service, which offers an API projection for all the major NoSQL model types; Column-family, Document, Graph, and Key-Value.
> The Gremlin (graph) and SQL (Core) Document API layers are fully interoperable.
> This has benefits for switching between different models at the programmability level.
> Graph stores can be queried in terms of both complex network traversals as well as transactions modeled as document records in the same store.

![A diagram of the Azure Cosmos DB with a Gremlin API.](https://docs.microsoft.com/en-us/azure/cosmos-db/media/graph-introduction/cosmosdb-graph-architecture.png)

1. Yes.
1. GoLang: What is the Quality of DX (dev experience) using GoLang?
   - As listed by [the official Azure Cosmos DB Gremlin support page](https://docs.microsoft.com/en-us/azure/cosmos-db/gremlin-support), there is [a library built by external contributors](https://github.com/supplyon/gremcos/).
     Frankly, it doesn't seem widely adopted, with only 3 stars.
   - Alternatively, [the golang package search site](https://pkg.go.dev/search?q=gremlin) suggests the [grammes package](https://github.com/northwesternmutual/grammes).
     This looks much better supported.
   - As a fall-back, we can interact with [the REST API](https://docs.microsoft.com/en-us/rest/API/cosmos-db-resource-provider/2020-04-01/gremlinresources) if the above libraries turn out too cumbersome.
1. Deployment: What are methods of deploying updates?
   - There is support for [terraform](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/cosmosdb_account).
   - There is support for [the Azure CLI](https://docs.microsoft.com/en-us/azure/cosmos-db/cli-samples-gremlin).
   - There is support for [ARM templates](https://docs.microsoft.com/en-us/azure/cosmos-db/templates-samples-gremlin).
1. Access methods: Managed Identity?
   - Looks like [Cosmos DB does support managed identities](https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/tutorial-linux-vm-access-cosmos-db).
1. Replicability: How easy is it to make the data geo-redundant?
   - Very easy.
     [Configurable via terraform](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/cosmosdb_account).
     [Data is automatically and transparently replicated with proper configuration](https://docs.microsoft.com/en-us/azure/cosmos-db/high-availability).
1. Upskilling: Is this a new technology which will help us prepare for future projects?
   - Yes.
1. Compute Usage: High, Medium, Low.
   - High?
1. Cost of the solution window.
   - [See pricing details here](https://azure.microsoft.com/en-us/pricing/details/cosmos-db/).

### {Solution 3} - SQL Server and SQL API

Azure SQL Server and SQL Database [provide graph database functionality](https://docs.microsoft.com/en-us/sql/relational-databases/graphs/sql-graph-overview?view=sql-server-ver15).
There are concerns around this approach, best summarized in [this Medium article](https://medium.com/swlh/microsoft-sql-servers-graph-an-attempt-that-fell-short-for-now-a4888245c483).

If you don't have access, try incognito mode/private browsing.
If that doesn't work, this quote from the conclusion should suffice.

> SQL Server is extremely mature with respect to Relational Database, but clearly a newbie in Graph Database.
> This Graph support is probably deemed to be contained in Relational Database mentality.

![SQL Server graph architecture.](https://docs.microsoft.com/en-us/sql/relational-databases/graphs/media/sql-graph-architecture.png?view=sql-server-ver15)

1. No: This is questionably a graph database, but does not expose a graphql API.
1. GoLang: What is the Quality of DX (dev experience) using GoLang?
   - Decent.
     There is a [SQL package](https://golang.org/pkg/database/sql/) with [a driver for MSSQL](https://github.com/denisenkom/go-mssqldb).
1. Deployment: What are methods of deploying updates?
   - There is support for [terraform](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/sql_database).
   - There is support for [the Azure CLI](https://docs.microsoft.com/en-us/cli/azure/sql/db?view=azure-cli-latest).
   - There is support for [ARM templates](https://docs.microsoft.com/en-us/azure/azure-sql/database/arm-templates-content-guide?tabs=single-database).
1. Access methods: Managed Identity?
   - [Yes](https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/tutorial-windows-vm-access-sql), Azure SQL works with managed identity.
1. Replicability: How easy is it to make the data geo-redundant?
   - [Easy](https://docs.microsoft.com/en-us/azure/azure-sql/database/active-geo-replication-overview).
     It's configurable [through powershell](https://docs.microsoft.com/en-us/azure/azure-sql/database/automated-backups-overview?tabs=single-database#configure-backup-storage-redundancy), at least.
1. Upskilling: Is this a new technology which will help us prepare for future projects?
   - No.
1. Compute Usage: High, Medium, Low.
   - High?
1. Cost of the solution window.
   - [See pricing details here](https://azure.microsoft.com/en-us/pricing/details/sql-database/single/).

### {Solution 4} - Neo4j

1. Graph database: Is this a graph database?
   - Yes, Neo4j is a native graph database that is commonly ranked #1 in many [graph database comparisons](https://db-engines.com/en/ranking/graph+dbms).
1. GoLang: What is the Quality of DX (dev experience) using GoLang?
   - There is a published and maintained [Neo4j driver for golang](https://pkg.go.dev/github.com/Neo4j/Neo4j-go-driver/Neo4j).
1. Deployment: What are methods of deploying updates?
   - Options available through [Azure Marketplace](https://azuremarketplace.microsoft.com/en-us/marketplace/apps/Neo4j.Neo4j-enterprise-edition?tab=Overview) which should support standard Azure deployment stacks like ARM templates / Azure CLI
1. Access methods: Managed Identity?
   - No, supports Neo4j driver with basic username / password authentication of can use TLS certificates.
1. Replicability: How easy is it to make the data geo-redundant?
   - Azure Marketplace supports multiple versions including single server or multi-server clusters (Casual Clusters).
1. Upskilling: Is this a new technology which will help us prepare for future projects?
   - Neo4j has been around since 2007 and has a rich ecosystem and is widely adopted by [many enterprise customers](https://Neo4j.com/customers/?ref=home) including Comcast, Adobe, eBay, Lyft, Airbnb, Cisco & Microsoft.
1. Compute Usage: High, Medium, Low.
   - Depends on cluster size
1. Cost of the solution window.
   - Powered by VMs & cost is calculated by VM SKU and usage

![Neo4j on Azure](https://dist.neo4j.com/wp-content/uploads/20170531004034/neo4j-settings-microsoft-azure-1024x502.png)

#### References

- [Neo4j on Azure Part 1](https://neo4j.com/blog/neo4j-microsoft-azure-marketplace-part-1)
- [Neo4j on Azure Part 2](https://neo4j.com/blog/deploy-neo4j-microsoft-azure-part-2)

### {Solution 5} - JanusGraph

We do not recommend [JanusGraph](https://docs.janusgraph.org/) due to its under performance on some evaluation criteria.
JanusGraph uses Apache Cassandra, Apache HBase, and Oracle Berkeley DB Java Edition for its data storage backend.

1. Graph database: Is this a graph database?
   - Yes
1. GoLang: What is the Quality of DX (dev experience) using GoLang?
   - Bad, [JanusGraph docs](https://docs.janusgraph.org/connecting/) only include official documentation for Java, Python, and .Net.
     However there are two divers for GoLang which use TinkerPop to enable graph traversal with the language, [gremgo](https://github.com/qasaur/gremgo) - last commit over a year ago - and [grammes](https://github.com/northwesternmutual/grammes) - last commit April 2020.
Each with under 100 stars.
1. Deployment: What are methods of deploying updates?
   - It seems to be that you can only deploy from gremlin console.
1. Access methods: Managed Identity?
   - [JanusGraph](https://docs.janusgraph.org/basics/server/) uses [Gremlin Server](https://tinkerpop.apache.org/docs/3.4.6/reference/#gremlin-server) which is most easily accessed using the Gremlin Console.
It does not support managed identity.
Gremgo uses username and password, and grammes doesn't seem to have documentation explicitly explaining how to authenticate.
1. Replicability: How easy is it to make the data geo-redundant?
   - [Cassandra](https://docs.janusgraph.org/storage-backend/cassandra/) as a backend will support replicability.
1. Upskilling: Is this a new technology which will help us prepare for future projects?
   - It is new but we don't believe it will help prepare for future projects.
1. Compute Usage: High, Medium, Low.
   - We could deploy [Cassandra on Azure VMs](https://docs.microsoft.com/en-us/azure/architecture/best-practices/cassandra) using standard Azure VMs.
1. Cost of the solution window.
   - Azure VMs

### {Solution 6} - ArangoDB

[ArangoDB](https://github.com/arangodb/arangodb/) is an up-and-coming offering.
While it's not as popular as its competitors, its got some good numbers, and looks to be a well-polished product.

However, because it's a costly managed database, it likely doesn't fit our needs.

1. Graph database: Is this a graph database?
   - Yes.
1. GoLang: What is the Quality of DX (dev experience) using GoLang?
   - The [GoLang driver](https://github.com/arangodb/go-driver) looks to be very well maintained.
1. Deployment: What are methods of deploying updates?
   - Looks like it requires [a proprietary cloud](https://cloud.arangodb.com/home), which accrues costs monthly.
1. Access methods: Managed Identity?
   - Doesn't seem to be supported.
1. Replicability: How easy is it to make the data geo-redundant?
   - Available in Enterprise edition.
1. Upskilling: Is this a new technology which will help us prepare for future projects?
   - Likely not.
1. Compute Usage: High, Medium, Low.
   - Medium.
1. Cost of the solution window.
   - High.

## Results

| Solution                | Graph Database                                          | GoLang                     | Deployment                          | Access Methods                      | Replicability       | Upskilling | Compute Usage | Cost              |
| ----------------------- | ------------------------------------------------------- | -------------------------- | ----------------------------------- | ----------------------------------- | ------------------- | ---------- | ------------- | ----------------- |
| ~~Blob~~                | No                                                      |                            |                                     |                                     |                     |            |               |                   |
| Cosmos DB (Gremlin API) | Yes                                                     | 3rd party support          | Terraform, ARM templates, Azure CLI | Managed Identity                    | Native              | Yes        | High?         | ?                 |
| SQL Server              | No: Graph data stored and accessed in relational model. | 3rd party support          | Terraform, ARM templates, Azure CLI | Managed Identity                    | Native              | No         | High?         | ?                 |
| Neo4j                   | Yes                                                     | 3rd party support          | ARM Templates                       | Basic Authentication / Certificates | Supports Clustering | Yes        | Scalable      | Based on VM sizes |
| JanusGraph              | Yes                                                     | outdated 3rd party support | Console                             | No                                  | Yes - Cassandra     | No         | Medium        | Based on VM sizes |
| ArangoDB                | Yes                                                     | ArangoDB support           | Managed                             | No                                  | At cost             | No         | Medium        | High              |

## Decision

Given its adherence to our evaluation criteria, we've chosen to move forward with CosmosDB as our graph storage solution.
Neo4j was also strongly considered.
Especially important to the decision were Cosmos's support for managed identity and the desire to learn our own offering for future engagements.
