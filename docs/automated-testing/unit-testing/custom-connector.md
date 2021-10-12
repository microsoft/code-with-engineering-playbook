# Custom Connector Testing

When developing Custom Connectors to put data into the Power Platform there are some strategies you can follow:

## Unit Testing

There are several verifications one can do while developing custom connectors in order to be sure the code is working properly.

There are two main ones:

- Validating the OpenAPI schema which the connector is defined.
- Validating if the schema also have all the information necessary for the certified connector process.

(the later one is optional, but necessary in case you want to publish it as a certified connector).

There are several tool to help validate the OpenAPI schema, a list of them are available in this [link](https://openapi.tools/#description-validators). A suggested tool would be [swagger-cli](https://github.com/APIDevTools/swagger-cli).

On the other hand, to validate if the custom connector you are building is correct to become a certified connector, use the [paconn-cli](https://github.com/microsoft/PowerPlatformConnectors/tree/dev/tools/paconn-cli), since it has a validate command that shows missing information from the custom connector definition.
