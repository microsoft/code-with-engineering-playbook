# Trade Study: Golang Gremlin Library

Conducted by: Zach Miller <zamiller@microsoft.com>.

Backlog Work Item: #21859

Decision: grammes

Decision Makers: The Memory Team

## Overview

Because [we are using a graph database through CosmosDB](GolangGraphQL.md), we will be using a Gremlin API golang library.

See the [design documentation](../Architecture/Gremlin.md).

![A lovely diagram of the relationship between a Graph API and the Gremlin API.](../.attachments/GraphAndGremlin.png)

Please note here that 1 corresponds to a Graph API, and 2 represents Gremlin's API.
Gremlin's interface being graph-like makes it a great fit with a Graph API.

Please see [the golang GraphQL trade study](GolangGraphQL.md) for more details.

### Evaluation Criteria

The library will be evaluated on the following criteria:

- Maturity: Is the library well-established?
- Documentation: Is the library well-documented?

## Solutions

### {Solution 1} - [gremlin](https://github.com/go-gremlin/gremlin)

Go-gremlin/gremlin's library shows up early in common searches.
The name of the library appears official, which was promising.
However, it doesn't look well-maintained or documented.

- Maturity:
  - 95 stars.
  - Last commit was 3 years ago.
  - 48 forks.
- Documentation:
  - Looks like there is [only the README](https://github.com/go-gremlin/gremlin).

### {Solution 2} - [grammes](https://github.com/northwesternmutual/grammes)

- Maturity:
  - 80 stars.
  - Last commit was 1 year ago.
  - 24 forks.
- Documentation:
  - Lots of it, just not much in the way of explicit API docs.
  - [README](https://github.com/northwesternmutual/grammes)
  - [Docs subdirectory](https://github.com/northwesternmutual/grammes/tree/master/docs).
  - [Examples subdirectory](https://github.com/northwesternmutual/grammes/tree/master/examples).
  - [Blog post](https://medium.com/@damienstamates/introducing-grammes-ba26b20ec6)

### {Solution 3} - [gremgo](https://github.com/qasaur/gremgo)

- Maturity:
  - 92 stars.
  - Last commit was 1.5 years ago.
  - 41 forks.
  - However...

> Please keep in mind that gremgo is still under heavy development and although effort is being made to fully cover gremgo with reliable tests, bugs may be present in several areas.

- Documentation:
  - Has [a godoc](https://pkg.go.dev/github.com/qasaur/gremgo)!

### {Solution 4} - [gremcos](https://github.com/supplyon/gremcos/)

- Maturity:
  - 3 stars.
  - Last commit was 4 months ago.
  - 13 forks.
- Documentation:
  - [Repository](https://github.com/supplyon/gremcos/).
  - This seems to be [the official Cosmos offering](https://docs.microsoft.com/en-us/azure/cosmos-db/gremlin-support).

## Results

| Library | Maturity | Documentation |
| ------- | -------- | ------------- |
| Gremlin | Meh      | Good          |
| grammes | Good     | Good          |
| gremgo  | Poor     | Great         |
| gremcos | Meh      | Good          |

## Decision

On the `demo/grammes-vs-gremcos` branch there is a demo file you can test locally if you like:
Fill in the `<snip>`ed password with the primary key from a cosmos instance.
The one [here](https://ms.portal.azure.com/#@microsoft.onmicrosoft.com/resource/subscriptions/2f4bae45-523c-4220-b7b2-db3b8d7d2a1b/resourceGroups/zm-memory/providers/Microsoft.DocumentDB/databaseAccounts/zamiller/keys) may work.
If a new instance is needed, be sure to populate it with sample nodes and edges.

Based on playing around with it a little bit, and the [wealth of grammes examples](https://github.com/northwesternmutual/grammes/tree/master/examples) and [dearth of gremcos examples](https://github.com/supplyon/gremcos/tree/master/examples/cosmos), grammes seems the better option.

Because of its good combination between maturity and documentation, we've chosen to go with [grammes](#solution-2---grammes).
