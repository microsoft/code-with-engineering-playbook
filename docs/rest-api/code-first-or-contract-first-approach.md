# Code-First or Contract-First Approach

As different development teams exposes APIs to access various REST based services, its important to have an API contract to share between producer and consumers of APIs. [Open API](https://www.openapis.org/) format is one of the most popular API description format. This Open API contract can be produced in two ways:

- Contract-First - Team starts developing APIs by first defining API contract and later generates server side boilerplate code out of this defined API contract.
- Code-First - Team starts writing the server side api interface code e.g. controllers, DTOs etc. and later generates and API contract from it.

## Contract-First Approach

Contract-first approach means that APIs are treated as "first-class citizens" and everything about a project revolves around the idea that at the end these APIs will be consumed by clients. So based on the business requirements api development team first writes API contract in Open API format and collaborate with the stakeholders to gather feedback on the design of an API before any actual implementation code is written.

This approach is quite useful if a project is about developing publicly exposed set of APIs which will be consumed by external partners. As here we first agreed upon an API contract definition that's why expectations on api producer and consumer side remains strictly clear and both side teams can work in parallel as per the pre-agreed API contract.

### Key Benefits

- Early API design feedback.
- Expectations remains clear on consumer & producer side as both agreed upon an API contract.
- Development teams can work in parallel.
- During an agile development cycle API definitions are not impacted by incremental dev changes.
- API design is not influenced by actual implementation limitations & code structure. 
- May improve collaboration between api producer & consumer teams.

### Planning a Contract-First Development



### Points to consider 

