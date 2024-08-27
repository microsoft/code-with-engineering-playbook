# Decision Log

This document is used to track key decisions that are made during the course of the project.
This can be used at a later stage to understand why decisions were made and by whom.

| Decision | Date | Alternatives Considered | Reasoning | Detailed doc | Made By | Work Required |
| -- | -- | -- | -- | -- | -- | -- |
| Use Architecture Decision Records | 01/25/2021 | Standard Design Docs | An easy and low cost solution of tracking architecture decisions over the lifetime of a project | Record Architecture Decisions | Dev Team | #21654 |
| Use ArgoCD | 01/26/2021 | FluxCD | ArgoCD is more feature rich, will support more scenarios, and will be a better tool to put in our tool belts. So we have decided at this point to go with ArgoCD | [GitOps Trade Study](./trade-studies/gitops.md) | Dev Team | #21672 |
| Use Helm | 01/28/2021 | Kustomize, Kubes, Gitkube, Draft | Platform maturity, templating, ArgoCD support | K8s Package Manager Trade Study | Dev Team | #21674 |
| Use CosmosDB | 01/29/2021 | Blob Storage, CosmosDB, SQL Server, Neo4j, JanusGraph, ArangoDB | CosmosDB has better Azure integration, managed identity, and the Gremlin API is powerful. | Graph Storage Trade Study and Decision | Dev Team | #21650 |
| Use Azure Traffic Manager | 02/02/2021 | Azure Front Door | A lightweight solution to route traffic between multiple k8s regional clusters | Routing Trade Study | Dev Team | #21673 |
| Use Linkerd + Contour | 02/02/2021 | Istio, Consul, Ambassador, Traefik | A CNCF backed cloud native k8s stack to deliver service mesh, API gateway and ingress | Routing Trade Study | Dev Team | #21673 |
| Use ARM Templates | 02/02/2021 | Terraform, Pulumi, Az CLI | Azure Native, Az Monitoring and incremental updates support | Automated Deployment Trade Study | Dev Team | #21651 |
| Use 99designs/gqlgen | 02/04/2021 | graphql, graphql-go, thunder | Type safety, auto-registration and code generation | GraphQL Golang Trade Study | Dev Team | #21775 |
| Create normalized role data model | 03/25/2021 | Career Stage Profiles (CSP), Microsoft Role Library | Requires a data model that support the data requirements of both role systems | Role Data Model Schema | Dev Team | #22035 |
| Design for edges and vertices | 03/25/2021 | N/A | N/A | Data Model | Dev Team | #21976 |
| Use grammes | 03/29/2021 | Gremlin, gremgo, gremcos | Balance of documentation and maturity | Gremlin API library Trade Study | Dev Team | #21870 |
| Design for Gremlin implementation | 04/02/2021 | N/A | N/A | Gremlin | Dev Team | #21980 |
| Design for Gremlin implementation | 04/02/2021 | N/A | N/A | Gremlin | Dev Team | #21980 |
| Expose 1:1 data model from API to DB | 04/02/2021 | Exposing a minified version of data model contract | Team decided that there were no pieces of data that we can rule out as being useful. Will update if data model becomes too complex | API README | Dev Team | #21658 |
| Deprecate SonarCloud | 04/05/2021 | Checkstyle, PMD, FindBugs | Requires paid plan to use in a private repo | Code Quality & Security | Dev Team | #22090 |
| Adopted Stable Tagging Strategy | 04/08/2021 | N/A | Team aligned on the proposed docker container tagging strategy  | Tagging Strategy | Dev Team | #22005 |
