## Secrets Management

Secrets Management refers to the way in which we protect configuration settings and other sensitive data which, if 
made public, would allow unauthorized access to resources. Examples of secrets are usernames, passwords, api keys, SAS 
tokens etc.

We should assume any repo we work on may be made public at any time and follow the appropriate procedures, even if 
the repo is initially private.

### General Approach

The general approach is to keep secrets in a separate configuration file during development which is never checked in 
to the repo. Best practice would be to add this file name to the [.gitignore](https://git-scm.com/docs/gitignore) to prevent it being accidentally checked in.
Each developer may maintain their own version of the file or, if required, it may be circulated via private channels e.g. a Teams chat.

In a production system, assuming Azure, the secrets would be created in the environment of the running process. This can be done by manually editing the 'Applications Settings' section of the resource but is suggested that a script using
the Azure CLI to do the same is a useful time-saving utility. See [here](https://docs.microsoft.com/en-us/cli/azure/webapp/config/appsettings?view=azure-cli-latest) for more details.

*It is best practice to maintain separate secrets configurations for each separate environment that you run. e.g. dev, test, prod, local etc*

### Keeping Secrets Secret

It should be obvious, but all the care taken to protect secrets is all for nothing if we aren't careful about how we use secrets once we have them. Primarily: **DON'T LOG SECRETS!!**. Don't put them in logging or reporting. Don't send them to other applications, don't use them in URLs, forms or in any other way other than to make a request to the service that requires that secret.

### Enhanced-Security Applications

The techniques outlined below provide 'good' security and a common pattern for a wide range of languages. They rely on 
the fact that Azure keeps application settings (the environment) encrypted until just before your app is run. Encryption keys are regularly rotated. They do *not* prevent secrets from existing in plaintext in memory at runtime. Particularly in garbage collected languages those values may exist for longer than the lifetime of the variable.

*If you are working on an application with enhanced security requirements you should consider using additional techniques to maintain encryption on secrets throughout the application lifetime.*


### Techniques for Secrets Management

Below we outline a number of techniques that we can use to make the loading of secrets transparent to the 
developer.

#### C#/.NET

Use the 'file' attribute of the appSettings element to load secrets from a local file. A full description of this attribute can be found [here](https://docs.microsoft.com/en-us/dotnet/framework/configure-apps/file-schema/appsettings/appsettings-element-for-configuration).


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

#### Node

Use the [dotenv](https://www.npmjs.com/package/dotenv) package.

```bash
$ cat .env
MY_SECRET=mySecret
```

```node
require('dotenv').config()
let mySecret = process.env("MY_SECRET")
```

Secrets are loaded into the environment from the .env file if it exists. If not just use existing environment i.e. ApplicationSettings.

#### Python

Load config settings into environment manually.

```bash
$ cat secrets.json
{
  "MY_SECRET" : "mySecret"
}
```


```Python

import os
import json

try:
  config = json.loads(open("./secrets.json", "r").read())

  # Works for all versions
  for k,v in config.items():
    os.environ[k] = v

  # Python >= 3.5 one-liner
  # os.environ = { **os.environ, **config }

except IOError:
  pass # No secrets.json
except json.decoder.JSONDecodeError:
  pass # Malformed secrets.json

print(os.environ["MY_SECRET"])

```

Settings file doesn't *have* to be JSON. You might prefer yaml, key=value etc

#### Databricks

Databricks has the option of using dbutils as a secure way to retrieve credentials and not reveal them within the notebooks running on Databricks
 
The following steps lay out a clear pathway to creating new secrets and then utilizing them within a notebook on Databricks: 
 
1) Install and configure the Databricks CLI on your local machine following the instructions from here: https://docs.databricks.com/user-guide/dev-tools/databricks-cli.html#set-up-the-cli [Follow the Setup the CLI section only]
2) Get the Databricks personal access token following instructions here: https://docs.databricks.com/api/latest/authentication.html#token-management 
3) Create a scope for the secrets by following the instructions on https://docs.azuredatabricks.net/user-guide/secrets/secret-scopes.html#create-a-databricks-backed-secret-scope [Follow the Create a Databricks backed Secret Scope section only]
4) Create secrets by following the steps listed here: https://docs.azuredatabricks.net/user-guide/secrets/secrets.html 
