# Trade Study: Golang GraphQL Library

Conducted by: Zach Miller zamiller@microsoft.com

Backlog Work Item: #21764 #21755

Decision: 99designs/gqlgen

Decision Makers: The Memory Team

## Overview

We want a library which will allow us to create a GraphQL API in golang.
The library should be fast, reliable, mature, well-documented, and well-maintained.

We want the GraphQL endpoint to be self documenting.
Luckily, [this is a feature](http://spec.graphql.org/June2018/#sec-Descriptions) of GraphQL.

Any library should be a great choice for this.

### Evaluation Criteria

The former should be condensed down to a set of "evaluation criteria" that we can rate any potential solutions
against. Examples of evaluation criteria:

* Is GraphQL: Does the library implement the specification for the GraphQL type system?
* Maturity: Is the library mature?
* Usage Example: How do we use the library?
* Documentation: Is the library well documented?
* Typed Return: Does the library leverage the type system when resolving queries?
* Resolver Discovery and Registration: Does the library discover, and register resolvers automatically?
* Resolver Generation: Does the library generate resolvers automatically?

## Solutions

[This blog post](https://medium.com/open-graphql/choosing-a-graphql-server-library-in-go-8836f893881b) was useful as a guide for selecting libraries.
[The official graphql website](https://graphql.org/code/#go-server) also had some recommendations.

### {Solution 1} - graphql-go/graphql

[The `graphql-go/graphql` library](https://github.com/graphql-go) looks to be the official offering of GraphQL in go.
To get this interacting over HTTP, [the `handler` library is recommended](https://github.com/graphql-go/handler).
The main advantage of this library is its maturity.

1. Is GraphQL?
   * Yes.
2. Maturity
   * 7.3 thousand stars.
   * Last commit 3 days before this document was written.
   * 637 forks.
3. Usage Example

```go
   Resolve: func(p graphql.ResolveParams) (interface{}, error) {
        return "world", nil
    },
```
<!-- markdownlint-disable MD029 -->
4. Documentation
   * Documentation is available [here](https://pkg.go.dev/github.com/graphql-go/graphql).
It looks well-maintained.
5. Typed Return
   * No.
6. Resolver Discovery and Registration
   * No.
7. Resolver Generation
   * No.
<!-- markdownlint-enable MD029 -->
The referenced documentation shows how to check for relevant fields in returned `structs` to properly filter on them.

### {Solution 2} - graph-gophers/graphql-go

[The `graph-gophers/graphql-go` library](https://github.com/graph-gophers/graphql-go) is an offering from a team formed from the intersection of go and GraphQL fans.
While less mature, things like auto-discovery and type safety can be nice.

1. Is GraphQL?
   * Yes.
2. Maturity
   * 3.6 thousand stars.
   * Last commit was November 2020.
   * 383 forks.
3. Usage Example

```golang
func (r *helloWorldResolver) Hello(ctx context.Context) (string, error) {
    return "Hello world!", nil
}
```
<!-- markdownlint-disable MD029 -->
4. Documentation
   * Sparse.
[The wiki](https://github.com/graph-gophers/graphql-go/wiki) and [the README](https://github.com/graph-gophers/graphql-go) seem to be about it.
5. Typed Return
   * Yes.
6. Resolver Discovery and Registration
   * Resolvers [are automatically discovered and registered](https://github.com/graph-gophers/graphql-go#resolvers).
7. Resolver Generation
   * No.
<!-- markdownlint-enable MD029 -->

### {Solution 3} - samsarahq/thunder

[Samsara](https://www.samsara.com/) provides a library for GraphQL called [Thunder](https://github.com/samsarahq/thunder).
This solution is the least mature, but supports plenty of toys out of the box.

1. Is GraphQL?
   * Yes.
2. Maturity
   * 1.3 thousand stars.
   * Last commit 6 days before this document was written.
   * 83 forks.
3. Usage Example

```golang
object.FieldFunc("posts", func() []post {
        return posts
})
```

<!-- markdownlint-disable MD029 -->
4. Documentation
   * Frankly, sparse.
You get [the README](https://github.com/samsarahq/thunder), a [page on pagination](https://github.com/samsarahq/thunder/blob/master/doc/pagination.md), and that's about it.
5. Typed Return
   * Yes.
6. Resolver Discovery and Registration
   * [Schema-building example](https://github.com/samsarahq/thunder#reflection-based-schema-building).
   * [Auto-registration example](https://github.com/samsarahq/thunder/tree/master/example).
7. Resolver Generation
   * No.
<!-- markdownlint-enable MD029 -->

### {Solution 4} - 99designs/gqlgen

This library by [99designs/gqlgen](https://github.com/99designs/gqlgen) is notable for its typed return and automatic resolver registration, as well as generation.
Its maturity also makes it a strong contender.
[This comparison chart](https://gqlgen.com/feature-comparison/) is handy.

1. Is GraphQL?
   * Yes.
2. Maturity
   * 5 thousand stars.
   * Last commit was 22 days ago.
   * 573 forks.
3. Usage Example

```golang
func (r *queryResolver) Todos(ctx context.Context) ([]*model.Todo, error) {
   return r.todos, nil
}
```

<!-- markdownlint-disable MD029 -->
4. Documentation
   * [Comprehensive](https://gqlgen.com/).
5. Typed Return
   * Yes.
6. Resolver Discovery and Registration
   * Resolvers are discovered and registered from the schema.
7. Resolver Generation
   * [Code generation for resolvers](https://gqlgen.com/getting-started/#implement-the-resolvers) when our models and data schema align.
This looks to be quite powerful.
Furthermore, types are treated with a little more gravity.
Whereas other mature resolver libraries return strings or interfaces, these resolvers return concrete types.
<!-- markdownlint-enable MD029 -->

## Results

| Solution                 | Is GraphQL? | Maturity | Usage Example | Documentation | Typed Return | Resolver Discovery and Registration | Resolver Generation |
| ------------------------ | ----------- | -------- | ------------- | ------------- | ------------ | ----------------------------------- | ------------------- |
| graph-go/graphql         | ✅           | Highest  | Simple        | Wonderful     | 🚫            | 🚫                                   | 🚫                   |
| graph-gophers/graphql-go | ✅           | Middle   | Simpler       | OK            | ✅            | ✅                                   | 🚫                   |
| samsarahq/thunder        | ✅           | Lowest   | Simplest      | Poor          | ✅            | ✅                                   | 🚫                   |
| 99designs/gqlgen         | ✅           | Highest  | Simplest      | Wonderful     | ✅            | ✅                                   | ✅                   |

## Decision

We've decided to move forward with the 99designs gqlgen library.
Although we're hesitant about code generation, as it can be painful when it doesn't work, leveraging the type system is a plus, and the maturity stacks up about evenly with the graphql library.
