# Correlation IDs

## The Need

In a distributed system architecture (microservice architecture), it is highly difficult to understand a single end-to-end customer transaction flow through the various components. 

Here are some the general challenges -
* It becomes challenging to understand the end-to-end behavior of a client request entering the application.
*  Aggregation: Consolidating logs from multiple components and making sense out of these logs is difficult, if not impossible.
*  Cyclic dependencies on services, course of events and asynchronous requests are not easily deciphered.
* While troubleshooting a request, the diagnostic context of the logs are very important to get to the root of the problem.

## Solution

A Correlation ID is a unique identifier that is added to the very first interaction (incoming request) to  identify the context and is passed to all components that are involved in the transaction flow. Correlation ID becomes the glue that binds the transaction together and helps to draw a overall picture of events.

*Note: Before implementing your own Correlation ID, investigate if your telemetry tool of choice provides a auto-generated Correlation ID and that it serves the purposes of your application. For instance, [Application Insights](https://docs.microsoft.com/en-us/azure/azure-monitor/app/auto-collect-dependencies) offers dependency auto-collection for some application frameworks*  

### Recommended Practices

1. Assign each external request a Correlation ID that binds the message to a transaction. 
2. Correlation ID for a transaction must be assigned as early as you can.
3. Propagate Correlation ID to downward all components/services.
4. All components/services of the transaction use this Correlation ID in their logs.
5. For a HTTP Reqest, Correlation ID is, typically passed in the header.
6. Based on the usecase, there can be additional correlation IDs that may be needed. For instance, tracking logs based on both Session ID and User ID may be required. While adding multiple correlation ID, remember to propagate them through the components. 

## Use Cases

### Log Correlation

Log correlation is the ability to track disparate events through different parts of the application. Having a Correlation ID provides more context making it easy to building rules on collected logs.

### Trace Observers

For developing a secondary observation system, for example generates reporting

### Troubleshooting Errors

For troubleshooting an errors, Correlation ID is a great starting point to trace the workflow of a transaction.
