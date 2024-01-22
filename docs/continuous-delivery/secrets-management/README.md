# Secrets Management

Secrets Management refers to the way in which we protect configuration settings and other sensitive data which, if
made public, would allow unauthorized access to resources. Examples of secrets are usernames, passwords, api keys, SAS
tokens etc.

We should assume any repo we work on may go public at any time and protect our secrets, even if
the repo is initially private.

## General Approach

The general approach is to keep secrets in separate configuration files that are not checked in
to the repo. Add the files to the [.gitignore](https://git-scm.com/docs/gitignore) to prevent that they're checked in.

Each developer maintains their own local version of the file or, if required, circulate them via private channels e.g. a Teams chat.

In a production system, assuming Azure, create the secrets in the environment of the running process. We can do this by manually editing the 'Applications Settings' section of the resource, but a script using
the Azure CLI to do the same is a useful time-saving utility. See [az webapp config appsettings](https://learn.microsoft.com/en-us/cli/azure/webapp/config/appsettings?view=azure-cli-latest) for more details.

It's best practice to maintain separate secrets configurations for each environment that you run. e.g. dev, test, prod, local etc

The [secrets-per-branch recipe](./../azure-devops/secret-management-per-branch.md) describes a simple way to manage separate secrets configurations for each environment.

> Note: even if the secret was only pushed to a feature branch and never merged, it's still a part of the git history. Follow [these instructions](https://help.github.com/en/github/authenticating-to-github/removing-sensitive-data-from-a-repository) to remove any sensitive data and/or regenerate any keys and other sensitive information added to the repo. If a key or secret made it into the code base, rotate the key/secret so that it's no longer active

## Keeping Secrets Secret

The care taken to protect our secrets applies both to how we get and store them, but also to how we use them.

- **Don't log secrets**
- Don't put them in reporting
- Don't send them to other applications, as part of URLs, forms, or in any other way other than to make a request to the service that requires that secret

## Enhanced-Security Applications

The techniques outlined below provide *good* security and a common pattern for a wide range of languages. They rely on
the fact that Azure keeps application settings (the environment) encrypted until your app runs.

They do *not* prevent secrets from existing in plaintext in memory at runtime. In particular, for garbage collected languages those values may exist for longer than the lifetime of the variable, and may be visible when debugging a memory dump of the process.

> If you are working on an application with enhanced security requirements you should consider using additional techniques to maintain encryption on secrets throughout the application lifetime.

Always rotate encryption keys on a regular basis.

## Techniques for Secrets Management

These techniques make the loading of secrets  transparent to the developer.

### C#/.NET

#### Modern .NET Solution

For .NET SDK (version 2.0 or higher) we have `dotnet secrets`, a tool provided by the .NET SDK that allows you to manage and protect sensitive information, such as API keys, connection strings, and other secrets, during development. The secrets are stored securely on your machine and can be accessed by your .NET applications.

```shell
# Initialize dotnet secret 
dotnet user-secrets init

# Adding secret
# dotnet user-secrets set <KEY> <VALUE>
dotnet user-secrets set ExternalServiceApiKey my-api-key-12345

# Update Secret
dotnet user-secrets set ExternalServiceApiKey updated-api-key-67890

```

To access the secrets;

```csharp
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .AddUserSecrets<Startup>();

var configuration = builder.Build();
var externalServiceApiKey = configuration["ExternalServiceApiKey"];

```

##### Deployment Considerations

When deploying your application to production, it's essential to ensure that your secrets are securely managed. Here are some deployment-related implications:

- Remove Development Secrets: Before deploying to production, remove any development secrets from your application configuration. You can use environment variables or a more secure secret management solution like Azure Key Vault or AWS Secrets Manager in production.

- Secure Deployment: Ensure that your production server is secure, and access to secrets is controlled. Never store secrets directly in source code or configuration files.

- Key Rotation: Consider implementing a secret rotation policy to regularly update your secrets in production.

#### .NET Framework Solution

Use the [`file`](https://learn.microsoft.com/en-us/dotnet/framework/configure-apps/file-schema/appsettings/appsettings-element-for-configuration) attribute of the appSettings element to load secrets from a local file.

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings file="..\..\secrets.config">
  …
  </appSettings>
  <startup>
      <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
  </startup>
  …
</configuration>
```

Access secrets:

```C#
static void Main(string[] args)
{
    String mySecret = System.Configuration.ConfigurationManager.AppSettings["mySecret"];
}
```

When running in Azure, ConfigurationManager will load these settings from the process environment. We don't need to upload secrets files to the server or change any code.

### Node

Store secrets in environment variables or in a `.env` file

```bash
$ cat .env
MY_SECRET=mySecret
```

Use the [dotenv](https://www.npmjs.com/package/dotenv) package to load and access environment variables

```node
require('dotenv').config()
let mySecret = process.env("MY_SECRET")
```

### Python

Store secrets in environment variables or in a `.env` file

```bash
$ cat .env
MY_SECRET=mySecret
```

Use the [dotenv](https://pypi.org/project/python-dotenv/) package to load and access environment variables

```Python
import os
from dotenv import load_dotenv


load_dotenv()
my_secret = os.getenv('MY_SECRET')
```

Another good library for reading environment variables is `environs`

```Python
from environs import Env


env = Env()
env.read_env()
my_secret = os.environ["MY_SECRET"]
```

### Databricks

Databricks has the option of using dbutils as a secure way to retrieve credentials and not reveal them within the notebooks running on Databricks

The following steps lay out a clear pathway to creating new secrets and then utilizing them within a notebook on Databricks:

1. [Install and configure the Databricks CLI](https://docs.databricks.com/user-guide/dev-tools/databricks-cli.html#set-up-the-cli) on your local machine
2. [Get the Databricks personal access token](https://docs.databricks.com/api/latest/authentication.html#token-management)
3. [Create a scope for the secrets](https://learn.microsoft.com/azure/databricks/security/secrets/secret-scopes)
4. [Create secrets](https://learn.microsoft.com/azure/databricks/security/secrets/)

### Validation

Automated credential scanning can be performed on the code regardless of the programming language. Read more about it [here](../../continuous-integration/dev-sec-ops/secret-management/credential_scanning.md)
