# Credential Scanning

Credential scanning is the practice of automatically inspecting a project to ensure that no secrets are included in the project's source code. Secrets include database passwords, storage connection strings, admin logins, service principals, etc.

## Why Credential Scanning

Including secrets in a project's source code is a significant risk, as it might make those secrets available to unwanted parties. Even if it seems that the source code is accessible to the same people who are privy to the secrets, this situation is likely to change as the project grows. Spreading secrets in different places makes them harder to manage, access control, and revoke efficiently. Secrets that are committed to source control are also harder to discard of, since they will persist in the source's history.
Another consideration is that coupling the project's code to its infrastructure and deployment specifics is limiting and considered a bad practice. From a software design perspective, the code should be independent of the runtime configuration that will be used to run it, and that runtime configuration includes secrets.
As such, there should be a clear boundary between code and secrets: secrets should be managed outside of the source code and credential scanning should be employed to ensure that this boundary is never violated.

## Applying Credential Scanning

Ideally, credential scanning should be run as part of a developer's workflow (e.g. via a [git pre-commit hook](https://pre-commit.com/)), however, to protect against developer error, credential scanning must also be enforced as part of the continuous integration process to ensure that no credentials ever get merged to a project's main branch.
To implement credential scanning for a project, consider the  following:

1. Store secrets in an external secure store that is meant to store sensitive information
1. Use secrets scanning tools to asses your repositories current state by scanning it's full history for secrets
1. Incorporate an automated secrets scanning tool into your CI pipeline to detect unintentional committing of secrets
1. Avoid `git add .` commands on git
1. Add sensitive files to .gitignore

## Credential Scanning Frameworks and Tools

Recipes and Scenarios -

1. [detect-secrets](./recipes/detect-secrets.md) is an aptly named module for detecting secrets within a code base.
1. Use [detect-secrets inside Azure DevOps Pipeline](./recipes/detect-secrets-ado.md)
1. [Microsoft Security Code Analysis extension](https://learn.microsoft.com/en-us/azure/security/develop/security-code-analysis-overview)

Additional Tools -

1. [CodeQL](https://securitylab.github.com/tools/codeql)  – GitHub security. CodeQL lets you query code as if it was data. Write a query to find all variants of a vulnerability
1. [Git-secrets](https://github.com/awslabs/git-secrets)  - Prevents you from committing passwords and other sensitive information to a git repository.

## Conclusion

Secret management is essential to every project. Storing secrets in external secrets store and incorporating this mindset into your workflow will improve your security posture and will result in cleaner code.
