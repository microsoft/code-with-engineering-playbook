# REST API Design Guidance

## Goals

* Elevate Microsoft's published [REST API design guidelines](https://github.com/microsoft/api-guidelines).
* Highlight common design decisions and factors to consider when designing.
* Provide additional resources to inform API design in areas not directly addressed by the Microsoft guidelines.

## Common API Design Decisions

The [Microsoft REST API guidelines](https://github.com/microsoft/api-guidelines) provide design guidance covering a multitude of use-cases.
The following sections are a good place to start as they are likely required considerations by any REST API design:

* [URL Structure](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#71-url-structure)
* [HTTP Methods](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#74-supported-methods)
* [HTTP Status Codes](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#711-http-status-codes)
* [Collections](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#9-collections)
* [JSON Standardizations](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#11-json-standardizations)
* [Versioning](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#12-versioning)
* [Naming](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#17-naming-guidelines)

## How to Interpret and Apply The Guidelines

The API guidelines document includes a section on [how to apply the guidelines](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#4-interpreting-the-guidelines) depending on whether the API is new or existing.
In particular, when working in an existing API ecosystem, be sure to align with stakeholders on a definition of what constitutes a [breaking change](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#123-definition-of-a-breaking-change) to understand the impact of implementing certain best practices.

> We do not recommend making a breaking change to a service that predates these guidelines simply for the sake of compliance.

## Additional Resources

* [Microsoft's Recommended Reading List for REST APIs](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#31-recommended-reading)
* [Detailed HTTP status code definitions](https://www.restapitutorial.com/httpstatuscodes.html)
* [Semantic Versioning](https://semver.org/)
* [Other Public API Guidelines](http://apistylebook.com/design/guidelines/)
