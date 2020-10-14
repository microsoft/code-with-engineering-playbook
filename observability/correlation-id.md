# Correlation IDs

## The Need

In a distributed system architecture (microservice architecture), it is highly difficult to understand a single end to end customer transaction flow through the various components.

Here are some the general challenges -

* It becomes challenging to understand the end-to-end behavior of a client request entering the application.
* Aggregation: Consolidating logs from multiple components and making sense out of these logs is difficult, if not impossible.
* Cyclic dependencies on services, course of events and asynchronous requests are not easily deciphered.
* While troubleshooting a request, the diagnostic context of the logs are very important to get to the root of the problem.

## Solution

A Correlation ID is a unique identifier that is added to the very first interaction (incoming request) to  identify the context and is passed to all components that are involved in the transaction flow. Correlation ID becomes the glue that binds the transaction together and helps to draw a overall picture of events.

>Note: Before implementing your own Correlation ID, investigate if your telemetry tool of choice provides a auto-generated Correlation ID and that it serves the purposes of your application. For instance, [Application Insights](https://docs.microsoft.com/en-us/azure/azure-monitor/app/auto-collect-dependencies) offers dependency auto-collection for some application frameworks

### Recommended Practices

1. Assign each external request a Correlation ID that binds the message to a transaction.
2. The Correlation ID for a transaction must be assigned as early as you can.
3. Propagate Correlation ID to all downstream components/services.
4. All components/services of the transaction use this Correlation ID in their logs.
5. For a HTTP Request, Correlation ID is typically passed in the header.
6. Where possible also add it to an outgoing response.
7. Based on the use case, there can be additional correlation IDs that may be needed. For instance, tracking logs based on both Session ID and User ID may be required. While adding multiple correlation ID, remember to propagate them through the components.

## Use Cases

### Log Correlation

Log correlation is the ability to track disparate events through different parts of the application. Having a Correlation ID provides more context making it easy to build rules for reporting and analysis.

### Secondary reporting/observer systems

Using Correlation ID helps secondary systems to correlate data without application context. Some examples - generating metrics based on tracing data, integrating runtime/system diagnostics etc. For example, feeding AppInsights data and correlating it to infrastructure issues.

### Troubleshooting Errors

For troubleshooting an errors, Correlation ID is a great starting point to trace the workflow of a transaction.
