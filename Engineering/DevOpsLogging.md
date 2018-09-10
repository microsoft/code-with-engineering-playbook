# Logging and Monitoring

Services that CSE develop use logging and monitoring for understanding service performance, get insight into complex workflows and a tool for debugging service failures.

## Goals

1. Collect and evaluate key performance metrics on a service and across multiple services
2. Trace complex requests and workflows within and across multiple services
3. Ability to diagnose and debug errors and service outages
4. Provide the required information to understand the state of the running system

## Evidence and Measures

- [ ] Application faults and errors are logged
- [ ] Additional log information (warning, debug, trace) are collected depending on configuration
- [ ] Logging configuration can be modified without code changes (i.e. increase verbosity when troubleshooting problems)
- [ ] Metrics are collected to identify service health
- [ ] In microservice architectures correlation ID is used to follow the flow of an operation among participant services
- [ ] GDPR compliance is ensured regarding personal identifiable information

## General Guidance

Logging should be taken care since the beginning of the software development. We should avoid a scenario where production has issues but our application does not provide enough information to help us identity the problem.

A good exercise during software development is to ask ourselves what can go wrong in this operation/action? Once problem areas have been identified add log information. A few guidelines:

- When interacting with an external system we should know when a call fails. On a more detailed level we might want to log all calls made to external system. Doing so allows us to answer questions as *"Are you calling our system? When? What were the inputs and outputs?"*.
  
- Be able to identity which configuration settings our application is running. For instance, `using API located at http://xyz` or `setting min io threads to 5`. This information helps identity why reading files asynchronously is taking longer than expected.

- Log when important events occurred, i.e. when an order is created. Not finding logs for "order created" in the last 30 minutes might indicate a problem.

- Adding more information about errors. For instance, when a SQL call fails by default we only know the low level reason (stored procedured failed). By catching the error and logging "Failed to update basket" we also know in which scenario the stored procedure was called
  
### Logging

- Use existing logging frameworks and store logs in separate storage
- Ensure log messages are machine readable/parsable and follow a common schema across all services
- Add contextual information and use log severity levels
- Have consistency when using log severity levels

### Monitoring

- Leverage quality of service to continuously validate application availability and responsiveness
- Use metrics to have an overview of the system performance and health (request times, request counts, queue lenght, etc.)

## GDPR

General Data Protection Regulation requires paying attention to log content. Email addresses, usernames, phone numbers, IP addresses are among the type of information considered personal, which has restrict rules regarding storage.
It is important to pay attention to what is logged. A technique to overcome this is anonymizing sensitive data (for instance replacing last digits of IP address).
Moreover, pay attention to log transmission and data at rest, ensuring that encryption is in place.

## Resources

- [Monitoring and diagnostics](https://docs.microsoft.com/en-us/azure/architecture/best-practices/monitoring)
- [Logging and monitoring in a micro services architecture](https://docs.microsoft.com/en-us/azure/architecture/microservices/logging-monitoring)
- [CSE logging and monitoring details](./DevOpsLoggingDetails.md)