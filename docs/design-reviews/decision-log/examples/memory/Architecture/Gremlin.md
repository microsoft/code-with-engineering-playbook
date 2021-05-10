# Gremlin

## Overview

As decided in the Gremlin trade study, we will be using [grammes](https://github.com/northwesternmutual/grammes) to access the Graph database on CosmosDB.
This document explains how to design this method of accessing the data, [whose model can be accessed here](./Data-Model.md).

## Traversing the graph

### Grammes Graph Traversal

To query a gremlin server, we use the term `traverse` rather than `query` to match the grammes documentation.
In the samples below, the error handling logic is removed, but we would expect implementation to handle the cases where `err != nil`.
Below is a non-exhaustive list for how to run graph queries using grammes.

To add a few vertices:

```golang
var apiData grammes.APIData
err = json.Unmarshal(raw, &apiData)
vertex1, err := client.AddAPIVertex(apiData)

vertex2, err := client.AddVertex("UserProfile",
    "oid", "some guid",
)
```

To add an edge:

```golang
vertex1.AddEdge(client, "authoredBy", vertex2.ID(),
    "someauthoredgeproperty", "something",
    "aomeotherauthoredproperty", 5,
)
```

To get a few vertices:

```golang
vertices, err := client.Vertices("entry")

vertices, err := client.VerticesByString("g.V().hasLabel('entry')")

vertices, err := client.VerticesByQuery(g.V().HasLabel("entry"))

vertices, err := client.Vertices("entry", "project", "Memory")

res, err := client.ExecuteQuery(
    g.V().HasLabel("entry").Properties(),
)

edges, err := vertex4.QueryOutEdges(client)
```

[Queries can also be run concurrently](https://github.com/northwesternmutual/grammes/blob/main/examples/concurrent-example/main.go).

While the documentation is sparse and separated by folders without a table of contents, the potentially most useful example is the one for [querying vertices by edge](https://github.com/northwesternmutual/grammes/blob/main/examples/vertex-edge-example/main.go).

### Obfuscating Querying

In order to obfuscate out the complexities of writing a gremlin query, we will create a helper tool.
For example, the implementation of a Memory API endpoint to get all `Entry` objects can be done via calling a helper function.
A non-exhaustive list of helper functions to obfuscate out gremlin logic from the business logic of the API:

- Gremlin Service
  - Create Client
  - Open/Close Connection
  - Get Query Builder
  - Run Query
  - Include: specific services for different types based on this service
- Gremlin Query Builder
  - Explicit query obfuscations
    - Get vertex by id
    - Get vertices by label
    - Get vertices by property filter
    - Get vertices by edge filter
    - Get edges by vertex
    - Add vertex with label, properties
    - Add edge with type and 2 vertices
    - Delete vertex by id
    - Delete edge by id
  - Helpers
    - Row Based Security (filter by AuthoredBy and SharedWith)
    - Convert To/From JSON (JSON for now but will likely change)
- Helper Objects
  - Filter: essentially a dictionary to map a field to filter with what to filter it by

## Data Model Relationships

As of now, the plan is for the API to expose the exact same data model as the [database data model design](./Data-Model.md)

## Security

### Authentication

Grammes uses [user/password authentication](https://github.com/northwesternmutual/grammes/blob/main/examples/auth-example/main.go), however as demonstrated in the grammes demo project, the values here can be the graph for the user, and the primary key as the password. This is really the only option we have with grammes.

### Row Based Security

In the query builder, there is a helper function that will filter any returned data such that if someone is not the Author or in the SharedWith list, they will not get that row.

## Extending This Design

This design is intended to be extremely flexible, such that nothing is query-specific.
However there may be features we never got around to making because there was no use case.
In that scenario, the recommendation is to update the Gremlin Query Builder code to reflect the logic for building queries, and then update the API code to make use of those queries and add additional business logic around when to call them and what values to pass in.

## Testing

For testing, grammes uses [goconvey](https://www.github.com/smartystreets/goconvey/) and [smartysheets](https://www.github.com/smartystreets/).
