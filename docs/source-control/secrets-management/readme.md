# Working with secrets in source control

The best way to avoid leaking secrets is to store them in local/private files and exclude these from git tracking with a [.gitignore](https://git-scm.com/docs/gitignore) file.
E.g. the following pattern will exclude all files with the extension `.private.config`:

```bash
# remove private configuration
*.private.config
```

For more details on proper management of credentials and secrets in source control, and handling an accidental commit of secrets to source control, please refer to the [Secrets Management](../../continuous-delivery/secrets-management/readme.md) document which has further information, split by language as well.

As an extra security measure, apply [credential scanning](../../continuous-integration/credential-scanning/recipes/detect-secrets.md) in your CI/CD pipeline.
