# Secret Management with GitOps

GitOps primarily have git repositories in the center considered a source of truth for managing both infrastructure and application. This Infrastructure and application will require secured access to other resources of the system through secrets. Committing clear text secrets into git repositories is unacceptable even if the repositories are private to your team and organization. Teams need a secure way to handle secrets when using GitOps.

There are many ways to manage secrets with GitOps and at high level can be categorized into:

1. Encrypted Secrets in Git Repositories
1. Reference to secrets stored in the external key vault

## 1. Encrypted Secrets in Git Repositories

In this approach, secrets are manually encrypted by developers using a public key and the custom Kubernetes controller running in the target cluster can only decrypt the key. Some popular tools for his approach are [Bitnami Sealed Secrets](https://github.com/bitnami-labs/sealed-secrets), [Mozilla SOPS](https://github.com/mozilla/sops)

- ### [Bitnami Sealed Secrets](https://github.com/bitnami-labs/sealed-secrets)

   Sealed secrets use asymmetric encryption to encrypt secrets. Kubernetes controller generates key pair(private-public) and stores the private key in etcd as Kubernetes secret. Developers use [Kubeseal CLI](https://github.com/bitnami-labs/sealed-secrets#public-key--certificate) to seal secrets before committing to the git repo.

- Support automatic key rotation for the private key and can be used to enforce re-encryption of secrets
- Multi-tenancy support at the namespace level can be enforced by the controller
- When sealing secrets developers needs a connection to the cluster control plane to fetch the public key or the public key has to be explicitly shared with the developer
- Potential risk of secret checked into a git repo
- If the private key in the cluster is lost for some reason all secrets need to be re-encrypted followed by a new key-pair generation
- Does not scale with Multi-cluster here every cluster will require a controller having its own key pair

- ### [Mozilla SOPS](https://github.com/mozilla/sops)

   SOPS: Secrets OPerationS is an encryption tool that supports YAML, JSON, ENV, INI, and BINARY formats and encrypts with AWS KMS, GCP KMS, Azure Key Vault, age, and PGP and is not just limited to Kubernetes. It supports integration with some common key management systems including Azure Key Vault. Where the key management system is used to store the encryption key for encrypting secrets and not the actual secrets.

- [Flux](https://toolkit.fluxcd.io/guides/mozilla-sops/#azure)  has better support for SOPS with cluster-side decryption.
- An added layer of security as the private key used for decryption is protected in an external key vault.
- Needs plugin to work with Helm([Helm Secrets](https://github.com/jkroepke/helm-secrets)) and Kustomization ([KSOPS](https://github.com/viaduct-ai/kustomize-sops))([kustomize-sopssecretgenerator](https://github.com/goabout/kustomize-sopssecretgenerator))
- Does not scale with larger teams as each developer has to encrypt the secrets
- The public key is sufficient for creating brand new files. The secret key is required for decrypting and editing existing files because SOPS computes a MAC on all values.  When using the public key solely to add or remove a field, the whole file should be deleted and recreated.

## 2. Reference to secrets stored in an external key vault (Recommended)

This approach relies on a key management system like [Azure Key Vault](https://docs.microsoft.com/en-us/azure/key-vault/general/overview) to hold the secrets and the git manifest in the repositories has reference to the key vault secrets. Developers do not perform any cryptographic operations with files in repositories. Kubernetes operators running in the target cluster are responsible for pulling the secrets from the key vault and making them available either as Kubernetes secrets or secrets volume mounted to the pod.

[Azure Key Vault Provider for Secrets Store CSI Driver](https://github.com/Azure/secrets-store-csi-driver-provider-azure) is an azure vault provider for [Kubernetes secret store CSI Driver](https://github.com/kubernetes-sigs/secrets-store-csi-driver) allows you to get secret content stored in Azure Key vault instance and use the Secrets Store CSI driver interface to mount them into Kubernetes pods.

- Mounts secrets/keys/certs to pod using a CSI Inline volume
- Provides enterprise-grade external secret management
- Easily scalable with multi-cluster and larger teams
- Supports sync with Kubernetes Secrets(Optional)
- Supports Linux and Windows containers
- Supports pod portability with the SecretProviderClass CRD

Azure Key Vault Provider for Secrets Store CSI Driver [install Guide](https://secrets-store-csi-driver.sigs.k8s.io/getting-started/installation.html).
CSI driver will need access to Azure Key vault either through service principle or managed identity(recommended). To make this access secure you can leverage [Azure Workload Identity](https://github.com/Azure/azure-workload-identity)(recommended) or [AAD Pod Identify](https://github.com/Azure/aad-pod-identity). Please note AAD pod identity will soon be replaced by Azure WorkLoad Identity.

## Important Links

- [Sealed Secrets with Flux v2](https://toolkit.fluxcd.io/guides/sealed-secrets/)
- [Mozilla SOPS with Flux v2](https://toolkit.fluxcd.io/guides/mozilla-sops/)
- [Secret Management with Argo CD](https://argo-cd.readthedocs.io/en/stable/operator-manual/secret-management/)
- [Secret management Workflow](https://www.youtube.com/watch?v=-k6HEXaE75k)
