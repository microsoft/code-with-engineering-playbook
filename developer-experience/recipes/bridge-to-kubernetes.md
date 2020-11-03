
# Bridge to Kubernetes

Bridge to Kubernetes allows developers to seamlessly work on services both in a shared cluster and locally in debug mode.

To learn more about Bridge to Kubernetes:

- [Introduction](https://code.visualstudio.com/docs/containers/bridge-to-kubernetes)

- [How it works](https://docs.microsoft.com/en-us/visualstudio/containers/overview-bridge-to-kubernetes)

- [Configuration](https://docs.microsoft.com/en-us/visualstudio/containers/configure-bridge-to-kubernetes)

- [VS Code Setup](https://docs.microsoft.com/en-us/visualstudio/containers/bridge-to-kubernetes?view=vs-2019)

- [Repository](https://github.com/Microsoft/mindaro)

## Useful Scenarios

We believe this technology can be most helpful...

- if a developer needs to test/debug a new or changed service against an ecosystem of services.

- if a developer does not have the domain knowledge to deploy all the micro services. This allows them to work against a "blackbox" set of already deployed services.

We found the technology very easy to implement so it can probably be used for a wide of cases with minimal training.

## Limitations

While many of these limitations are in the backlog, currently, you cannot use Bridge to Kubernetes in these circumstances...

- if your services need to have replicas.

- if your services require HTTPS and you are running in ISOLATION mode (ex. Istio mTLS).

- if your Pods have more than 1 container (ex. sidecars, Istio).

- if you are using WSL.

- if you are using dev-containers.

## Tested

We have tested the following scenarios with and without ISOLATION mode:

- from local service to shared service.

- from shared service to local service.

- from local service (computer A) to local service (computer B) - routing across AKS cluster.

## Contact

If you have questions, feel free to reach out to:

- Peter Lasne (CSE)

- Lila Molyva (CSE)

- Product Group Alias: BridgeToKubernetes@microsoft.com
