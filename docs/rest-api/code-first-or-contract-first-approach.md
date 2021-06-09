# Code-First or Contract-First Approach

As different development teams exposes APIs to access various REST based services, its important to have an API contract to share between producer and consumers of APIs. [Open API](https://www.openapis.org/) format is one of the most popular API description format. This Open API contract can be produced in two ways:

- Contract-First - Team starts developing APIs by first defining API contract and later generates server side boilerplate code out of this defined API contract.
- Code-First - Team starts writing the server side api interface code e.g. controllers, DTOs etc. and later generates and API contract from it.

## Contract-First Approach

Contract-first approach means that APIs are treated as "first-class citizens" and everything about a project revolves around the idea that at the end these APIs will be consumed by clients. So based on the business requirements api development team first writes API contract in Open API format and collaborate with the stakeholders to gather feedback on the design of an API before any actual implementation code is written.

This approach is quite useful if a project is about developing externally exposed set of APIs which will be consumed by partners. As here we first agreed upon an API contract definition that's why expectations on api producer and consumer side remains strictly clear and both side teams can work in parallel as per the pre-agreed API contract.

### Key Benefits

- Early API design feedback.
- Expectations remains clear on consumer & producer side as both agreed upon an API contract.
- Development teams can work in parallel.
- Testing team can use API contracts to do an early test even before a business logic is in place. By looking at different models, paths, attributes and other aspects of the API testing can provide their input which can be very valuable.
- During an agile development cycle API definitions are not impacted by incremental dev changes.
- API design is not influenced by actual implementation limitations & code structure.
- Server side boilerplate code e.g. controllers, DTOs etc. can be auto generated from API contracts.
- May improve collaboration between API producer & consumer teams.

### Planning a Contract-First Development

1. Identify use cases & key services which API should offer.
2. Identify key stakeholders of API and try to include them during API contract design to get continuous feedback.
3. Write API contract definitions.
4. Maintain consistent style for API status codes, versioning, error responses etc.
5. Encourage peer reviews via pull requests.
6. Generate server side boilerplate code & client SDKs from API contract definitions.

### Points to consider

- If API requirements can changes often during initial development phase than Contract-First approach may not be a good fit as this will introduce an overhead to first update & maintain API contract definitions again & again.
- A platform specific code generator might not be able to generate a flexible & maintainable implementation of actual code.

## Resources

- [Understanding  the API-First Approach to Building Products](https://swagger.io/resources/articles/adopting-an-api-first-approach/)
- [Design First or Code First: What’s the Best Approach to API Development?](https://swagger.io/blog/api-design/design-first-or-code-first-api-development/)
