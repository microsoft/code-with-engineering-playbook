# Logging and Monitoring with .NET/C#

## Logging

.NET Core introduced a generic logging interface, [ILogger](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger), which is well integrated in the framework and ecosystem. The common usage scenario is to inject the concrete ILogger into the application using dependency injection, while not having any class dependent on the actual log provider (as we might change the provider in the future).

There are mainly two ways to use ILogger:

- By injecting into the class constructor, which makes writing unit test simpler. It is recommended if instances of the class will be created using dependency injection (like mvc controllers). Not intended to be used in classes that will be instantiated directly, because it would require us to pass ILogger through the call stack (i.e. `var msg = new Message(this.logger)`).

```c#
public class MyController
{
    ILogger logger;
    public MyController(ILogger<MyController> logger)
    {
        this.logger = logger;
        this.logger.LogDebug($"New {nameof(MyController)} created");
    }
}
```

- Using a utility class to make logging available to all library classes, without having to add ILogger to the constructor of every class that logs data. It makes unit testing a less clean as we need to provide a concrete implementation onto the static class.
  
```c#
internal static class ApplicationLogging
{
    internal static ILoggerFactory LoggerFactory { get; set; }
    internal static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
    internal static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
}

public class MyController
{
    static ILogger logger = ApplicationLogging.CreateLogger<MyController>();

    public MyController()
    {
        logger.LogDebug($"New {nameof(MyController)} created");
    }
}
```

### Logging Levels for ILogger

Logging levels for ILogger are listed below, in order of high to low importance:

|Level|Description|Example|
|-|-|-|
|Critical|When the application reaches a scenario where immediate attention is required. It can often cause it to end abnormally|No memory or disk space|
|Error|An unexpected exception has happened, most of the time aborting the current operation|Cannot reach a REST API or failed to update a database record|
|Warning|When something unexpected happens that requires attention, however the application remains working|Configuration file was not found|
|Information|Track general application flow|Request received, file opened, user created|
|Debug|Track important information during development or troubleshooting production system| ```Using API located at http://myapi:8080``` or ```Listening on port 8080```|
|Trace|Track important for development purposes, might contain sensitive information|```Using connection string: server=dbserver;UserID=sa;password=mysecret```|

### Logging Providers

Even though .NET Core has built-in logging providers (debug, console, event source, [etc](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1#built-in-logging-providers)) it is often recommended to use a specialized library that offers more configuration and sink options. Most popular libraries are:

|Library|Semantic Log|Sinks|
|-|-|-|
|[Serilog](https://github.com/serilog/serilog-extensions-logging)|Yes|Log Analytics, Application Insights, File, DataDog and [many others](https://github.com/serilog/serilog/wiki/Provided-Sinks)|
|[NLog](https://github.com/NLog/NLog)|Yes|Application Insights, Elastic Search and [many others](https://nlog-project.org/config/?tab=targets)|
|[Log4Net](https://github.com/apache/logging-log4net/)|No|File, SQL and [many others] (https://logging.apache.org/log4net/release/config-examples.html)

A complete logging providers list can be found [here](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1#third-party-logging-providers).

### Logging in a Library

When developing a class library we most often cannot choose the logging provider. Our responsibility instead is to provide logging support which includes deciding a category strategy:

- One category per class: each class has a unique category ("MyLibrary.MyClass") which allows log control at the class level. Library wide rules are still supported by defining a rule using the main namespace as category (i.e. "MyLibrary")
- Custom categories: allows grouping classes with same category name ("MyLibrary.Models", "MyLibrary.Repositories")
- Single category: defining a user defined category valid for all library classes ("MyLibrary")

A common pattern is to receive the logger in the class constructor (either a ILogger&lt;T&gt; or ILoggerFactory). ILogger&lt;T&gt; is a shortcut to ILoggerFactory.Create(typeof(T).Name). ILoggerFactory.Create(string category) creates a logger for the specified category as the example below illustrates:

```C#
namespace MyLibrary
{
    // This class will have the log category "MyLibrary.UsingGenericILogger"
    public class UsingGenericILogger
    {
        public UsingGenericILogger(ILogger<UsingGenericLogger> logger)
        {
        }
    }

    // This class will have the log category "MyLibrary"
    public class UsingILoggerFactory
    {
        public UsingILoggerFactory(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger("MyLibrary");
        }
    }
}
```

Another way to implement logging in libraries without taking dependency on ILogger can be found in the [LibLog](https://github.com/damianh/LibLog) repository.

### Logging in a ASP.NET Core Application

When developing an ASP.NET Core application we are responsible for choosing a log provider. By default, logging is enabled with debug and console providers as you can see in the [WebHost.CreateDefaultBuilder](https://github.com/aspnet/MetaPackages/blob/master/src/Microsoft.AspNetCore/WebHost.cs#L188) implementation.

```c#
...
ConfigureLogging((hostingContext, logging) =>
{
    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    logging.AddConsole();
    logging.AddDebug();
})
...
```

WebHost.CreateDefaultBuilder also reads logging configuration from the `Logging` section in `appsettings.json` file. (the file appsettings.Development.json is used in addition when running the application in the Development environment). The example below defines the following rules:

- Categories System and Microsoft: log level "Information"
- All others: log level "Debug"

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  }  
}
```

An option to handle application errors in a single place is through  [app.UseExceptionHandler](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling). A few more resources can be found here:
- [Centralized exception handling and request validation in ASP.NET Core](https://www.strathweb.com/2018/07/centralized-exception-handling-and-request-validation-in-asp-net-core/) 
- [Error handling in ASP.NET Core applications](https://blog.dudak.me/2017/error-handling-in-asp-net-core-applications/)

#### ASP.NET Core and Application Insights

Application Insights integrates well with ASP.NET Core. With [little effort](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-dotnetcore-quick-start) request, error, dependency, traces, metrics and many more information becomes available on Application Insights Portal. If you double down on Application Insights as your Log Management system you can use a sink that output application logs to it. This way application and web logs will be available in a single searchable database.

#### Adding a custom provider to ASP.NET Core Project

This section demonstrates how to add Serilog to an ASP.NET Core project. Adding another provider requires similar steps. Detailed instructions can be found [here](https://github.com/serilog/serilog-aspnetcore). For a quick implementation based on configuration files follow the steps below (assuming you start from a ASP.NET Core project using default WebHost builder):

1. Add required nuget packages 

```text
Serilog.AspNetCore
Serilog.Settings.Configuration
Serilog.Sinks.Console (optional, in case console sink is needed)
```

1. Remove the console and debug providers by modifying the Program.cs file and clearing the registered providers.

```C#
 public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((logging) => {
                    logging.ClearProviders();
                });  // this will remove Console and Debug loggers
```

3. Add Serilog to the services collection

```C#
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseMvc();

    var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(this.Configuration)
        .CreateLogger();
    loggerFactory.AddSerilog(logger);
}
```

4. Modify the appsettings.json to setup Serilog (in this case adding console sink). For more examples [check here](https://github.com/serilog/serilog-settings-configuration).

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "Serilog": {
    "MinimumLevel": "Debug",
    "Using": [ "Serilog.Sinks.Console" ],
    "WriteTo": [
      {
        "Name": "Console"
      }
    ]
  }
}
```

### Logging in a .NET Core Console Application

Unlike ASP.NET Core, .NET Core Console apps don't have dependency injection by default. Adding it is simple and allows using ILogger as in the web application. The code below illustrates a way to add dependency injection to a console app:

```C#
public class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();
        var app = serviceProvider.GetService<Application>();
        app.Run();

    }

    private static void ConfigureServices(ServiceCollection services)
    {
        ILoggerFactory loggerFactory = new LoggerFactory();

        services.AddSingleton(loggerFactory);
        services.AddLogging(); // Allow ILogger<T>

        var configuration = GetConfiguration();


        services.AddSingleton<IConfigurationRoot>(configuration);
        services.AddTransient<Application>();
    }

    private static IConfigurationRoot GetConfiguration()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .Build();
    }
}
```

The actual application code resides in the Application class. The Program class only has infrastructural code to setup DI and logging.

```C#
public class Application
{
    private readonly ILogger logger;

    public Application(ILogger<Application> logger)
    {
        this.logger = logger;
    }

    internal void Run()
    {
        this.logger.LogInformation("Application {applicationEvent} at {dateTime}", "Started", DateTime.UtcNow);

        Thread.Sleep(2000);

        this.logger.LogInformation("Application {applicationEvent} at {dateTime}", "Ended", DateTime.UtcNow);

        if (System.Diagnostics.Debugger.IsAttached)
        {
            Console.WriteLine("PRESS <ENTER> TO EXIT");
            Console.ReadLine();
        }
    }
}
```

Keep in mind that the default console log flushes content of a separated thread. If your console application is quick you might not see any log. This issue is tracked [here](https://github.com/aspnet/Logging/issues/631)

### High Performance Logging

For high performance workloads it is recommended to use the [LoggerMessage pattern](
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/loggermessage). It has less computational and memory requirements compared to using ILogger extension methods.

## Monitoring

As we previously discussed, monitoring allow us to validate the performance and health of a running system through key performance indicators.

In .NET a great option to add monitoring capabilities is Application Insights. By [adding Application Insights](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-asp-net-core) to an ASP.NET Core application we get out of the box requests, [errors](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-asp-net-exceptions), [dependencies](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-asp-net-dependencies) and [many more metrics](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-devops).

A few additional features of Application Insights:
- [add annotations to new releases](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-annotations), making easier to correlate changes in KPIs with new releases
- [add custom metrics](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-api-custom-events-metrics), to track domain specific events and metrics
- [receive logs](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-asp-net-trace-logs) from multiple frameworks. Here is the [sink for Serilog](https://github.com/serilog/serilog-sinks-applicationinsights).
- [add correlation across services](https://docs.microsoft.com/en-us/azure/application-insights/application-insights-correlation)
- [add custom telemetry properties](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-api-filtering-sampling#add-properties) for a whole application
- [integrate releases with monitoring](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-vsts-continuous-monitoring), allowing gated deployments based on metrics
- [monitor web availability](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-monitor-web-app-availability)