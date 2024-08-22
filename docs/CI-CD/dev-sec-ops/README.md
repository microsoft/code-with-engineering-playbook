# DevSecOps

## The Concept of DevSecOps

DevSecOps or DevOps security is about introducing security earlier in the life cycle of application development (a.k.a shift-left), thus minimizing the impact of vulnerabilities and bringing security closer to development team.

## Why

By embracing shift-left mentality, DevSecOps encourages organizations to bridge the gap that often exists between development and security teams to the point where many of the security processes are automated and are effectively handled by the development team.

## DevSecOps Practices

This section covers different tools, frameworks and resources allowing introduction of DevSecOps best practices to your project at early stages of development.
Topics covered:

1. [Credential Scanning](./secrets-management/credential_scanning.md) - automatically inspecting a project to ensure that no secrets are included in the project's source code.
1. [Secrets Rotation](./secrets-management/secrets_rotation.md) - automated process by which the secret, used by the application, is refreshed and replaced by a new secret.
1. [Static Code Analysis](./secrets-management/static-code-analysis.md) - analyze source code or compiled versions of code to help find security flaws.
1. [Penetration Testing](./penetration-testing.md) - a simulated attack against your application to check for exploitable vulnerabilities.
1. [Container Dependencies Scanning](./dependency-and-container-scanning.md) - search for vulnerabilities in container operating systems, language packages and application dependencies.
1. [Evaluation of Open Source Libraries](./evaluate-open-source-software.md) - make it harder to apply open source supply chain attacks by evaluating the libraries you use.
