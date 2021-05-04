# Custom Connector Testing

When developing Custom Connectors to put data into the Power Platform there are some strategies you can follow:

## Unit Testing

There are several verifications one can do while developing custom connectors in order to be sure the code is working properly.

There are two main ones: 
- validating the OpenAPI schema which the connector is defined and 
- validating if the schema also have all the information necessary for the certified connector process

(the later one is optional, but necessary in case you want to publish it as a certified connector).

For testing if OpenAPI schema is valid, there are several tool available. A list of them are available in this [link](https://openapi.tools/#description-validators). CSE Business Apps teams have been using [swagger-cli](https://github.com/APIDevTools/swagger-cli).

On the other hand, to validate if the custom connector you are building is correct to become a certified connector, use the [paconn-cli](https://github.com/microsoft/PowerPlatformConnectors/tree/dev/tools/paconn-cli), since it has a validate command that shows missing information from the custom connector definition.
