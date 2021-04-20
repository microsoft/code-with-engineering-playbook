# Credential scanning

Credential scanning is the engineering practice of automatically inspecting a project to ensure that no secrets are included in the project's source code. Secrets include database passwords, storage connection strings, admin logins, service principals, etc. See also [Secrets management](../../continuous-delivery/secrets-management/readme.md).

Having credentials included in a project's source code not only exposes the project to information security risks resulting from theft and impersonation of the credentials, but also exposes the project to architectural risks such as strongly coupling the project's source code to its infrastructure and deployment specifics. As such, there should be a clear boundary between code and secrets: should be managed outside of the source code, in a system such as [Azure Key Vault](https://azure.microsoft.com/en-us/services/key-vault/) or [HashiCorp Vault](https://www.vaultproject.io) and credential scanning should be employed to ensure that this boundary is never violated.

Ideally, credential scanning should be run as part of a developer's workflow (e.g. via a [git pre-commit hook](https://githooks.com)), however, to protect against developer error, credential scanning must also be enforced as part of the continuous integration process to ensure that no credentials ever get merged to a project's main branch.

To implement credential scanning for a project, consider building on-top of one of the following recipes:

- [detect-secrets](./recipes/detect-secrets.md)

- [detect-secrets inside Azure DevOps Pipeline](./recipes/detect-secrets-ado.md)
