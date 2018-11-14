# Logging and Monitoring

This section is designed to give a deeper understanding of logging and monitoring practices.

## Logging

### Logging Levels

Each language/logging library defines its own logging level. They all have an order of importance that usually goes from critical &rarr; error &rarr; warning &rarr; info &rarr; debug. As a user of the logging library we can define what is the minimum log level that will be processed. For instance, setting "warning" as minimum log level will cause logs in warning, error and critical levels to be processed, the rest will be discarded.

Be conscious about logging levels for production environment. You might want to enable debug logging during a troubleshooting session, otherwise use a higher level to avoid collecting too much data and slowing down the system.

### Logging Categories

A few logging libraries have the additional concept of categories. Categories allow us to define different logging levels for each subsystem of an application. It enables a scenario where we turn debug logging for the authentication subsystem to troubleshoot login failures while leaving all other subsystems on a higher log level to minimize data being collected.

### Sink/Output

Most logging libraries have the concept of sink or output. A sink defines where logs will be written to. This enables us to have distinct destinations during development (console) and production (file). Sink distinctions can also be used based on log category. Common sinks are:

- Debug: when using and IDE displays logged content into an output/debug window
- Console: well suited during development or when using a log collector based on stdout
- File: suited for scenarios where logged data will be collected and moved to a logging system. Important to use rolling files to prevent using all available disk space.
- Log Management Services: DataDog, Splunk, Elasticsearch, Application Insights, Azure Log Analytics.
- Many others: databases, Microsoft Teams, Slack, ...

### Semantic/Structured Logging

Basic logging writes content to a sink as simple text. For instance:

```C#
log.Debug("Adding {0}x SKU #{1} to basket {2}", qty, productId, basketId);
```

Outputs: "Adding 2x SKU #13991 to basket AB904."

Semantic logging allows you to add dimensions to the information being logged.

```C#
log.Debug("Adding {qty}x SKU #{productId} to basket {basketId}", 2, 13991, "AB904");
```

When using semantic capable library and sink (Log Analytics, Application Insights, Elasticsearch, etc) custom dimensions (qty, productId, basketId) will be searchable. We can then search for logs where the product '13991' was added to a basket, like in the example below using Application Insights:

```sql
traces
| project op=customDimensions.qty, productId=customDimensions.productId, basketId=customDimensions.basketId
| where productId == '13991'
```

### Logging Configuration

Most logging libraries offer configuration via code or settings files. Whenever possible rely on setting files, because it enables us to change logging levels and/or sinks without making changes to application code (i.e. enable verbose logging to troubleshoot a problem in production).

### Logging in Production

In a production environment it is highly recommended to have a single logging destination (known as Log Management System), that allows us to look at logged data as a whole. Log management systems allow us to build dashboards and alerts to better understand and react to a running system. Additionally, it allows us to search through millions of log entries using a SQL like syntax, which is very important when investigating issues.

There are many log managements systems, both open source and SaaS. To name a few:

- Azure Application Insights
- Azure Log Analytics
- Logstash
- DataDog
- Splunk
- Elasticsearch

### Logging Anti-patterns

A few anti-patterns regarding logging:

- Logging too much: excessive logging might cause performance problems (i.e. inside a long for loop).

- Meaningless logging: 'reading new configuration file', 'file xxx.txt opened', 'finished reading file' logs add too much noise and are hard to correlate to the same action. Prefer using a consistent log describing the whole action 'read configuration from file xxx.txt'

- Logging without context: 'login failed' does not help us narrow down the problem, where '{login} via {web} by user #{1231} {failed}' does.
  
- Logging in every catch block: instead of repeating the same pattern of `try..catch..log` use a pattern where unhandled exceptions are caught in a single place. If the exception will be handled by the caller, but we still need to be aware of its occurrence, log before throwing a more specific exception.

```C#
public void NotifyUser(User user, Notification notification)
{
    try
    {
        this.notificationHub.Notify(user.Email, notification.Message);
    }
    catch (NotificationHubException ex)
    {
        // This exception will be handled by the caller, but we still want to find when it happens
        logger.LogError("Failed to notify user {user.Id} about {notification.Type}", ex);

        throw new NotifyUserException("Error notifying user", user, notification, ex);
    }
}
```

## Monitoring

Logging helps you understand application behavior and faults. However, in order to understand the performance and health of a running system, application metrics are used. Common metrics will report:

- Amount of requests per second being handled
- Operation execution time
- Length of a queue
- CPU/memory usage
- Page views
- Domain specific metrics such as "amount of orders in status pending", "amount of users created"

With these metrics in hand we understand when a system is under heavy load or experiencing availability degradation. Moreover, We perceive the effects of a new release comparing metrics from before and after a deployment.

## Logging and Monitoring details per Language

- [.NET/C#](./DevOpsLoggingDetailsCSharp.md)
- JavaScript (pending)
- Go (pending)
- Python (pending)
- Java (pending)