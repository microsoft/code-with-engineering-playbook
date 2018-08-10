## Secrets Management

Secrets Management refers to the way in which we protect configuration settings and other sensitive data which, if 
made public, would allow unauthorized access to resources. Examples of secrets are usernames, passwords, api keys, SAS 
tokens etc.

We should assume any repo we work on may be made public at any time and follow the appropriate procedures, even if 
the repo is initially private.

### General Approach

The general approach is to keep secrets in a separate configuration file during development which is never checked in 
to the repo. Best practice would be to add this file name to the .gitignore to prevent it being accidentally checked in.
Each developer may maintain their own version of the file or, if required, it may be circulated via private channels e.g. a Teams chat.

In a production system, assuming Azure, the secrets would be created in the environment of the running process. This can be done by manually editing the 'Applications Settings' section of the resource but is suggested that a script using
the Azure CLI to do the same is a useful time-saving utility. See [here](https://docs.microsoft.com/en-us/cli/azure/webapp/config/appsettings?view=azure-cli-latest) for more details.

### Keeping secrets secret

It should be obvious, but all the care taken to protect secrets is all for nothing if we aren't careful about how we use secrets once we have them. Primarily: **DON'T LOG SECRETS!!**. Don't put them in logging or reporting. Don't send them to other applications, don't use them in URLs, forms or in any other way other than to make a request to the service that requires that secret.

### Techniques for Secrets Management

Below we outline a number of techniques that developers can use to make the loading of secrets transparent to the 
developer.

#### C#/.NET

Use the 'file' attribute of the appSettings element to load secrets from a local file.


``` XML
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings file="..\..\secrets.config">
  ...
  </appSettings>
  <startup> 
      <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
  </startup>
  ...
</configuration>
```

Secrets can then be accessed like so:

```C#

    static void Main(string[] args) 
    {
      String mySecret = System.Configuration.ConfigurationManager.AppSettings["mySecret"];
    }
```

When running in Azure ConfigurationManager will load these settings from the process environment. No secrets file need to be uploaded to the server and no code needs to be changed.


