# Logging

Logging refers to recording application actions in order to provide a better understanding of what is happening during its execution.

## General Approach

Logging should be taken care since the beginning of the software development. We should avoid a scenario where production has issues but our application does not provide any information to help us identity the problem.

A good exercise during the sofware development is to ask ourselves what can go wrong in this operation/action and add logging information which enables a DevOps team to identity and solve it without having to call software engineers. A few guidelines:

- When interacting with an external system we should know when calls failed. On a more detailed level we might want to log all calls made to the external system. Doing so allows us to answer questions as *"Are you calling our system? When? What were the inputs and outputs?"*.
  
- Be able to identity which settings our application is using. For instance, `using API located at http://xyz` or `connecting to database located at xyz`. This information helps identity why reading from the database is failing.

- Log when important events occurred, i.e. when an order is created. Not finding logs for "order created" in the last 30 minutes might indicate a problem.

- Adding more information about errors. For instance, when a SQL call fails by default we only know the low level reason (stored procedured failed). By catching the error and logging "Failed to update basket" we also know in which scenario the stored procedure was called

## Logging Levels

Each language/logging library defines its own logging level. They all have an order of importance that usually goes from critical &rarr; error &rarr; warning &rarr; info &rarr; debug. As a user of the logging library we can define what is the minimum log level that will be processed. For instance, setting "warning" as minimum log level will cause logs in warning, error and critical levels to be processed.

When running in production we only enable low logging levels during troubleshooting sessions in order to minimize the amount of data being collected.

## Logging Categories

A few logging libraries additional have the concept of categories. Categories allow us to define different logging levels for each subsystem of an application. It enables a scenario where we turn debug logging for the authentication subsystem to troubleshoot login failures while leaving all other subsystems on a higher log level to minimize data being collected.

## Sink/Output

Most logging libraries have the concept of sink or output. A sink defines where logs will be written to. This enable us to have distinct destinations during development (console) and production (file). Common sinks are:

- Debug: when using and IDE displays logged content into a output/debug window
- Console: well suited during development or when using a log collector based on stdout
- File: suited for scenarios where logged data will be collected and moved to a logging system. Important to use rolling files to prevent using all available disk space.
- Log Management Services: DataDog, Splunk, Elasticsearch, Application Insights, Azure Log Analytics.
- Many others: databases, Microsoft Teams, Slack, ...

## Semantic/Structured Logging

Basic logging writes text to a sink. For instance:

```C#
log.Debug("Adding {0}x SKU #{1} to basket {2}", qty, productId, basketId);
```

Outputs: "Adding 2x SKU #13991 to basket abgt1."

Semantic logging allows you to add dimensions to the information being logged.

```C#
log.Debug("Adding {qty}x SKU #{productId} to basket {basketId}", qty, productId, basketId);
```

When using a semantic capable library and sink (Log Analytics, Application Insights, Elasticsearch, etc) custom dimensions (qty, productId, basketId) will be searchable. This allow us for instance to search for logs where the product '13991' was added to a basket, like in the example using Application Insights:

```sql
traces
| project op=customDimensions.qty, productId=customDimensions.productId, basketId=customDimensions.basketId
| where productId == '13991'
```

## Logging Configuration

Most logging libraries offer configuration via code or settings files. Whenever possible rely on setting files, because it enable us to change logging levels and/or sinks without making changes to application code (i.e. enable verbose logging to troubleshoot a problem in production).

## Logging in Production

In a production environment it is highly recommended to have a single logging destination (known as Log Management System), that allow us to look at logged data as a whole. Log management systems allow us to build dashboards and alerts to better understand and react to a running system. Additionally, it allows us to search through millions of log entries using a SQL like syntax, which is very important when investigating issues.

There are many log managements systems, both open source and SaaS. To name a few:

- Azure Application Insights
- Azure Log Analytics
- Logstash
- DataDog
- Splunk

## GDPR

General Data Protection Regulation requires paying attention to log content. Email addresses, usernames, phone numbers, IP addresses are among the type of information considered personal, which has restricting rules regarding storage.
It is important to pay attention to what is logged. A technique to overcome this is anonymizing sensitive data (for instance replacing last digits of IP address).
Also pay attention to log transmission and data at rest, ensuring that encryption is in place.

## Anti-patterns

A few anti-patterns regarding logging:

- Logging too much: excessive logging might cause performance problems (i.e. inside a long for loop).

- Meaningless logging: 'reading new configuration file', 'file xxx.txt opened', 'finished reading file' logs add too much noise and are hard to correlate to the same action. Rather use a consistent log describing the whole action 'read configuration from file xxx.txt'

- Logging without context: 'login failed' does not help us narrow down the problem, where '{login} via {web} by user #{1231} {failed}' does.
  
- Logging in every catch block: instead of repeating the same pattern of `try..catch..log` use a pattern where unhandled exceptions are caught in a single place. If the exception will be handled by the caller, but we still need to be aware of its occurence it, log before throwing a more specific exception.

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

## Logging tips per language

- [.NET/C#](./DevOps-Logging-CSharp.md)
- JavaScript (pending)
- Go (pending)
- Python (pending)
- Java (pending)