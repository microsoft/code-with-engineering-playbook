# Secrets Rotation

Secret rotation is the process of refreshing the secrets that are used by the application.
The best way to authenticate to Azure services is by using a managed identity, but there are some scenarios where that isn't an option. In those cases, access keys or secrets are used. You should periodically rotate access keys or secrets.

## Why Secrets Rotation

Secrets are an asset and as such have a potential to be leaked or stolen. By rotating the secrets, we are revoking any secrets that may have been compromised. Therefore, secrets should be rotated frequently.

## Managed Identity

Azure Managed identities are automatically issues by Azure in order to identify individual resources, and can be used for authentication in place of secrets and passwords. The appeal in using Managed Identities is the elimination of management of secrets and credentials. They are not required on developers machines or checked into source control, and they don't need to be rotated. Managed identities are considered safer than the alternatives and is the recommended choice.

## Applying Secrets Rotation

If Azure Managed Identity can't be used. This and the following sections will explain how rotation of secrets can be achieved:

To promote frequent rotation of a secret - define an automated periodic secret rotation process.
The secret rotation process might result in a downtime when the application is restarted to introduce the new secret. A common solution for that is to have two versions of secret available, also referred to as Blue/Green Secret rotation. By having a second secret at hand, we can start a second instance of the application with that secret before the previous secret is revoked, thus avoiding any downtime.

## Secrets Rotation Frameworks and Tools

1. For rotation of a secret for resources that use one set of authentication credentials [click here](https://learn.microsoft.com/en-us/azure/key-vault/secrets/tutorial-rotation)
1. For rotation of a secret for resources that have two sets of authentication credentials [click here](https://learn.microsoft.com/en-us/azure/key-vault/secrets/tutorial-rotation-dual?tabs=azure-cli)

## Conclusion

Refreshing secrets is important to ensure that your secret stays a secret without causing downtime to your application.
