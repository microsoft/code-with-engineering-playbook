# Code First or Contract First Approach

As different development teams exposes APIs to access various REST based services, its important to have an API contract to share between producer and consumers of APIs. [Open API](https://www.openapis.org/) format is one of the most popular API description format. This Open API contract can be produced in two ways:

- Contract First - Team starts developing APIs by first defining API contract and later generates server side boilerplate code out of this defined API contract.
- Code First - Team starts writing the server side api interface code e.g. controllers, DTOs etc. and later generates and API contract from it.
