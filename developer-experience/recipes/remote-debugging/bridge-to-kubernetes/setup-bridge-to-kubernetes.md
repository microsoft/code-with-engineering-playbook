# How to configure Bridge to Kubernetes in VS code

This guide contains the steps to configure [Bridge to Kubernetes in VS code](https://code.visualstudio.com/docs/containers/bridge-to-kubernetes) so that you can debug your service as if it was running on an AKS cluster.

## Prerequisites

- [Install the Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli)
- An AKS cluster up and running. If you do not already have one, [follow these steps to create an AKS Cluster](https://docs.microsoft.com/en-us/azure/aks/kubernetes-walkthrough)
- [Kubectl](https://kubernetes.io/docs/tasks/tools/install-kubectl/): The Kubernetest command-line tool that allows you to run commands against your  clusters
- [Visual Studio Code](https://code.visualstudio.com/)

## Set up

1. Install the VS code extension [Bridge to Kubernetes](https://marketplace.visualstudio.com/items?itemName=mindaro.mindaro)

2. Connect to the cluster using the Azure CLI with the command:

    ```bash
    az aks get-credentials --resource-group myResourceGroupName --name myAKSCluster
    ```

3. Configure Bridge to Kubernetes

    To configure Bridge to Kubernetes in VS code you will need a Launch configuration file that will be used to debug your service.

    - Open `Run/Add Configuration` from the navigation menu and create a launch.json configuration file.
    - Open the command pallette and choose `Bridge to Kubernetes: Configure`
    - Choose the service you want to use for remote debugging
    - Select your port
    - Launch
      > This step will add a preLaunchTask (generated in tasks.json) to your configuration.
      - No: Redirect all traffic to your local - The auto-generated task will be similar to the following example:

      ```json
      {
        "version": "2.0.0",
        "tasks": [
            {
                "label": "bridge-to-kubernetes.service",
                "type": "bridge-to-kubernetes.service",
                "service": "myService",
                "ports": [
                    8080
                ],
                "targetCluster": "myAKSCluster",
                "targetNamespace": "default",
            }
        ]
      }
      ```

      - Yes: Only redirect requests from subdomain (Isolated mode) - The auto-generated task will be similar to the following example:

      ```json
      {
        "version": "2.0.0",
        "tasks": [
            {
                "label": "bridge-to-kubernetes.service",
                "type": "bridge-to-kubernetes.service",
                "service": "myService",
                "ports": [
                    8080
                ],
                "targetCluster": "myAKSCluster",
                "targetNamespace": "default",
                "isolateAs": "mysubdomain-b6bb"
            }
        ]
      }
      ```

4. Run it.

   In the example below curl is used to test how the traffic was redirected. `http://x.x.x.x` is the cluster public IP, `8080` is the port number and `mickey` is the name of our service.

   ```bash
   # NOT ISOLATION MODE - will return the response from the service running locally
   curl http://x.x.x.x:8080/myService 

   # ISOLATION MODE
   # will return the response from the service running on the cluster
   curl http://x.x.x.x:8080/myService 

   # will return the response from the local service as the kubernetes-route-as header is set
   curl http://x.x.x.x:8080/myService -H 'kubernetes-route-as:mysubdomain-b6bb' 
   ```

## References

- [Use Bridge to Kubernetes with VS code](https://code.visualstudio.com/docs/containers/bridge-to-kubernetes)
- [Use Bridge to Kubernetes with AKS](https://code.visualstudio.com/docs/containers/bridge-to-kubernetes-aks)