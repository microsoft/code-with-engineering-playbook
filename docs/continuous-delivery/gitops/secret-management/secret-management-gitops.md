# Secret Management with GitOps

GitOps primarily have git repositories in the center considered a source of truth for managing both infrastructure and application. This Infrastructure and application will require secured access to other resources of the system through secrets. Committing clear text secrets into git repositories is unacceptable even if the repositories are private to your team and organization. Teams need a secure way to handle secrets when using GitOps.

There are many ways to manage secrets with GitOps and at high level can be categorized into:

1. Encrypted Secrets in Git Repositories
1. Reference to secrets stored in the external key vault

## 1. Encrypted Secrets in Git Repositories

In this approach, secrets are manually encrypted by developers using a public key and the custom Kubernetes controller running in the target cluster can only decrypt the key. Some popular tools for his approach are [Bitnami Sealed Secrets](https://github.com/bitnami-labs/sealed-secrets), [Mozilla SOPS](https://github.com/mozilla/sops)

- Secret changes are managed by making changes within the GitOps repository which provides great traceability of the changes made
- All secrets can be rotated by making changes in GitOps, without accessing the cluster

### [Bitnami Sealed Secrets](https://github.com/bitnami-labs/sealed-secrets)

Sealed secrets use asymmetric encryption to encrypt secrets. Kubernetes controller generates key pair(private-public) and stores the private key in etcd as Kubernetes secret. Developers use [Kubeseal CLI](https://github.com/bitnami-labs/sealed-secrets#public-key--certificate) to seal secrets before committing to the git repo.

- [Support automatic key rotation](https://github.com/bitnami-labs/sealed-secrets#sealing-key-renewal) for the private key and can be used to enforce re-encryption of secrets
  - Due to [automatic renewal of the sealing key](https://github.com/bitnami-labs/sealed-secrets#sealing-key-renewal), the key needs to be prefetched from the cluster or cluster set up to store the sealing key on renewal in a secondary location
- Multi-tenancy support at the namespace level can be enforced by the controller
- When sealing secrets developers needs a connection to the cluster control plane to fetch the public key or the public key has to be explicitly shared with the developer
- Potential risk of secret checked into a git repo
- If the private key in the cluster is lost for some reason all secrets need to be re-encrypted followed by a new key-pair generation
- Does not scale with Multi-cluster here every cluster will require a controller having its own key pair
- Secrets are stored encrypted in the gitops repository, if the private encryption key is leaked, all secrets can be decrypted

### [Mozilla SOPS](https://github.com/mozilla/sops)

SOPS: Secrets OPerationS is an encryption tool that supports YAML, JSON, ENV, INI, and BINARY formats and encrypts with AWS KMS, GCP KMS, Azure Key Vault, age, and PGP and is not just limited to Kubernetes. It supports integration with some common key management systems including Azure Key Vault. Where the key management system is used to store the encryption key for encrypting secrets and not the actual secrets.

- [Flux](https://toolkit.fluxcd.io/guides/mozilla-sops/#azure) has better support for SOPS with cluster-side decryption.
- An added layer of security as the private key used for decryption is protected in an external key vault.
- Needs plugin to work with Helm([Helm Secrets](https://github.com/jkroepke/helm-secrets)) and Kustomization ([KSOPS](https://github.com/viaduct-ai/kustomize-sops))([kustomize-sopssecretgenerator](https://github.com/goabout/kustomize-sopssecretgenerator))
- Does not scale with larger teams as each developer has to encrypt the secrets
- The public key is sufficient for creating brand new files. The secret key is required for decrypting and editing existing files because SOPS computes a MAC on all values.  When using the public key solely to add or remove a field, the whole file should be deleted and recreated.

## 2. Reference to secrets stored in an external key vault (recommended)

This approach relies on a key management system like [Azure Key Vault](https://learn.microsoft.com/en-us/azure/key-vault/general/overview) to hold the secrets and the git manifest in the repositories has reference to the key vault secrets. Developers do not perform any cryptographic operations with files in repositories. Kubernetes operators running in the target cluster are responsible for pulling the secrets from the key vault and making them available either as Kubernetes secrets or secrets volume mounted to the pod.

For secret rotation ideas, see [Secrets Rotation on Environment Variables and Mounted Secrets](#secrets-rotation-on-environment-variables-and-mounted-secrets)

For how to authenticate private container registries with a Service principal see: [Authenticated Private Container Registry](#authenticated-private-container-registry)

All the below options provide the following:

- Secrets are not stored in the repository
- Supports Prometheus metrics for observability
- Supports sync with Kubernetes Secrets
- Supports Linux and Windows containers
- Provides enterprise-grade external secret management
- Easily scalable with multi-cluster and larger teams
- Both solutions support either Service Principal or Managed Identity for [authentication with the Key Vault](https://learn.microsoft.com/en-us/azure/key-vault/general/authentication).

### [Azure Key Vault Provider for Secrets Store CSI Driver](https://github.com/Azure/secrets-store-csi-driver-provider-azure)

Azure Key Vault Provider (AKVP) for Secrets Store CSI Driver is an azure vault provider for [Kubernetes secret store CSI Driver](https://github.com/kubernetes-sigs/secrets-store-csi-driver) allows you to get secret content stored in Azure Key vault instance and use the Secrets Store CSI driver interface to mount them into Kubernetes pods. Mounts secrets/keys/certs to pod using a CSI Inline volume.

Azure Key Vault Provider for Secrets Store CSI Driver [install guide](https://secrets-store-csi-driver.sigs.k8s.io/getting-started/installation.html).

CSI driver will need access to Azure Key vault either through  or managed identity(recommended). To make this access secure you can leverage [Azure Workload Identity](https://github.com/Azure/azure-workload-identity)(recommended) or [AAD Pod Identify](https://github.com/Azure/aad-pod-identity). Please note AAD pod identity will soon be replaced by Azure WorkLoad Identity.

Product Group Links provided for AKVP with SSCSID:

  1. Differences between ESO / SSCSID ([GitHub Issue](https://github.com/external-secrets/external-secrets/issues/478))
  2. Secrets Management on K8S talk [here](https://www.youtube.com/watch?v=EW25WpErCmA) (Native Secrets, Vault.io, and ESO vs. SSCSID)

Advantages:

- Supports pod portability with the SecretProviderClass CRD
- Supports auto rotation of secrets with customizable sync intervals per **cluster**.
- Seems to be the MSFT choice (Secrets Store CSI driver is heavily contributed by [MSFT](https://github.com/kubernetes-sigs/secrets-store-csi-driver) and Kubernetes-SIG)

Disadvantages:

- [Missing disconnected scenario support](https://github.com/kubernetes-sigs/secrets-store-csi-driver/issues/446): When the node is offline the SSCSID fails to fetch the secret and thus mounting the volume fails, making scaling and restarting pods not possible while being offline
- AKVP can only access Key Vault from a non-Azure environment using a [Service Principal](https://azure.github.io/secrets-store-csi-driver-provider-azure/docs/configurations/identity-access-modes/service-principal-mode/#configure-service-principal-to-access-keyvault)
- The [Kubernetes Secret containing the Service Principal credentials](https://azure.github.io/secrets-store-csi-driver-provider-azure/docs/configurations/identity-access-modes/service-principal-mode/) need to be created as a secret in the same namespace as the application pod. If pods in multiple namespaces need to use the same SP to access Key Vault, this Kubernetes Secret needs to be created in each namespace.
- The GitOps repo must contain the name of the key vault within the SecretProviderClass
- Must mount secrets as volumes to allow syncing into Kubernetes Secrets
- [Missing disconnected scenario support](https://github.com/kubernetes-sigs/secrets-store-csi-driver/issues/446): When the node is offline the SSCSID fails to fetch the secret and thus mounting the volume fails, making scaling and restarting pods not possible while being offline
- Uses more resources (4 pods; CSI Storage driver and provider) and is a daemonset - not test on RPS / resource usage

### [External Secrets Operator with Azure Key Vault](https://external-secrets.io/)

The External Secrets Operator (ESO) is an open-sourced Kubernetes operator that can read secrets from external secret stores (e.g., Azure Key Vault) and sync those into Kubernetes Secrets. In contrast to the CSI Driver, the ESO controller creates the secrets on the cluster as K8s secrets, instead of mounting them as volumes to pods.

Docs on using ESO Azure Key vault provider [here](https://external-secrets.io/v0.4.4/provider-azure-key-vault/).

Advantages:

- Supports auto rotation of secrets with customizable sync intervals per **secret**.
- Components are split into different CRDs for namespace (ExternalSecret, SecretStore) and cluster-wide (ClusterSecretStore, ClusterExternalSecret) making syncing more manageable i.r.t. different deployments/pods etc.
- Service Principal secret for the (Cluster)SecretStores could placed in a namespaced that only the ESO can access (see [Shared ClusterSecretStore](https://external-secrets.io/v0.7.1/guides/multi-tenancy/)).
- Resource efficient (single pod) - not test on RPS / resource usage.
- Open source and high contributions, ([GitHub](https://github.com/external-secrets/external-secrets))
- Mounting Secrets as volumes is supported via K8S's APIs (see [here](https://kubernetes.io/docs/concepts/configuration/secret/#using-secrets-as-files-from-a-pod))
- Disconnected scenario support: As ESO is using native K8s secrets the cluster can be offline, and it does not have any implications towards restarting and scaling pods while being offline

Disadvantages:

- The GitOps repo must contain the name of the Key Vault within the SecretStore / ClusterSecretStore or a ConfigMap linking to it
- Must create secrets as K8s secrets

## Important Links

- [Sealed Secrets with Flux v2](https://toolkit.fluxcd.io/guides/sealed-secrets/)
- [Mozilla SOPS with Flux v2](https://toolkit.fluxcd.io/guides/mozilla-sops/)
- [Secret Management with Argo CD](https://argo-cd.readthedocs.io/en/stable/operator-manual/secret-management/)
- [Secret management Workflow](https://www.youtube.com/watch?v=-k6HEXaE75k)

## Appendix

### Secrets Rotation on Environment Variables and Mounted Secrets

1. Mapping Secrets via secretKeyRef with environment variables.

   If we map a K8s native secret via a `secretKeyRef` into an environment variable and we rotate keys the environment variable is not updated even though the K8s native secret has been updated. We need to restart the Pod so changes get populated. [Reloader](https://github.com/stakater/Reloader) solves this issue with a K8S controller.

   ```yaml
   ...
        env:
            - name: EVENTHUB_CONNECTION_STRING
              valueFrom:
                secretKeyRef:
                  name: poc-creds
                  key: EventhubConnectionString
   ...
   ```

2. Mapping Secrets via volumeMounts (ESO way)

   If we map a K8s native secret via a volume mount and we rotate keys the file gets updated. The application needs to then be able pick up the changes without a restart (requiring most likely custom logic in the application to support this). Then no restart of the application is required.

   ```yaml
   ...
        volumeMounts:
        - name: mounted-secret
          mountPath: /mnt/secrets-store
          readOnly: true
      volumes:
      - name: mounted-secret
        secret:
          secretName: poc-creds
   ...
   ```

3. Mapping Secrets via volumeMounts (AKVP SSCSID way)

   SSCSID focuses on mounting external secrets into the CSI. Thus if we rotate keys the file gets updated. The application needs to then be able pick up the changes without a restart (requiring most likely custom logic in the application to support this). Then no restart of the application is required.

   ```yaml
   ...
        volumeMounts:
        - name: app-secrets-store-inline
          mountPath: "/mnt/app-secrets-store"
          readOnly: true
      volumes:
      - name: app-secrets-store-inline
        csi:
          driver: secrets-store.csi.k8s.io
          readOnly: true
          volumeAttributes:
            secretProviderClass: akvp-app
          nodePublishSecretRef:
            name: secrets-store-sp-creds
   ...
   ```

### Authenticated Private Container Registry

An option on how to authenticate private container registries (e.g., ACR):

1. Use a `dockerconfigjson` Kubernetes Secret on Pod-Level with `ImagePullSecret` (This can be also defined on [namespace-level](https://kubernetes.io/docs/concepts/containers/images/#referring-to-an-imagepullsecrets-on-a-pod))
