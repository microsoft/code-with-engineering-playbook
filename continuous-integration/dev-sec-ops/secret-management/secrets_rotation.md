# Secrets Rotation

Secret rotation is the process of refreshing the secrets that are used by the application.
For further reading see [CSEDevSecOps Secret Management Scenarios](https://github.com/microsoft/CSEDevSecOps/tree/master/Scenarios/SecretManagement)

## Why Secrets Rotation [The Why]

Secrets are an asset and as such have a potential to be leaked or stolen. By rotating the secrets, we are revoking any secrets that may have been compromised. Therefore, secrets should be rotated frequently. 

## Applying Secrets Rotation [the how]

To promote frequent rotation of a secret - define an automated periodic secret rotation process.
The secret rotation process might result in a downtime when the application is restarted to introduce the new secret. A common solution for that is to have two versions of secret available, also referred to as Blue/Green Secret rotation. By having a second secret at hand, we can start a second instance of the application with that secret before the previous secret is revoked, thus avoiding any downtime. 
 
## Secrets Rotation Frameworks and Tools

Use the tools and pipelines as suggested in [CSEDevSecOps Secret Management Scenarios](https://github.com/microsoft/CSEDevSecOps/tree/master/Scenarios/SecretManagement)

## Conclusion

Refreshing secrets is important to ensure that your secret stays a secret without causing downtime to your application. 
