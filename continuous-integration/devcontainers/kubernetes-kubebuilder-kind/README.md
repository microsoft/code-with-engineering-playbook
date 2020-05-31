# Kubernetes + Kubebuilder + KIND + DevContainers

This folder contains samples demonstrating how you could set up a DevContainer with everything you need to get your local developement environment ready to started developing and debugging your very own kubernetes operator against a local KIND cluster.

## What's inside?

* This DevContainer contains the following:

  * [Go](https://golang.org/)
  * [Docker CE CLI]((https://www.docker.com/get-started))
  * [Kubectl](https://kubernetes.io/docs/reference/kubectl/overview/)
  * [Kubebuilder](https://github.com/kubernetes-sigs/kubebuilder)
  * [Kustomize](https://github.com/kubernetes-sigs/kustomize)
  * [KIND](https://github.com/kubernetes-sigs/kind/)
  * [Helm](https://helm.sh/)
  * [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)

* Default shell: **zsh**
* Additional volumes:

  * **K8s-zshhistory** - persists command histroy between rebuilds
  * **K8s-kindconfig** - persists kubeconfig between rebuilds

* Project: sample project built using kubebuilder.

## How to run

Prerequisites:

* [Docker](https://www.docker.com/get-started)
* [Visual Studio Code](https://code.visualstudio.com/Download)
* [Remote Development Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack)

### Running the container

1. Make sure docker is running.
2. Open project in Visual Studio Code.
3. Run the **Remote-Containers: Open Folder in Container...** command from the Command Palette (`F1`) and wait for the container to build.

Once the container has been built you should have a KIND cluster up and running, ready to go with everything you need to start developing.

**Note**: If you ever need to rebuild the KIND cluster, run `make recreate-kind`.

## How to debug

Prerequisites:

Make sure KIND is up and running. You can test this by running `kubectl get pods`.

### Preping KIND

1. Put a breakpoint on [this line](controllers/cronjob_controller.go#L41).
2. Next we need to install our CRD into our KIND cluster. Run `make install`.
3. Now we need to build our controller. Run `make docker-build`.
4. After that's done, next run `make deploy`. This will load our controller into KIND and deploy our CRD config.

**Note**: KIND does not like it when you tag your images with `latest` so keep in mind if you want to deploy a new version of the controller, you should pass `IMG=[NAME]:[TAG]` when running `make docker-build` and `make deploy`.

### Starting the debugger

1. Once KIND has been configured, hit `F5` to fire up the debugger and wait for the debugger run the project and attach itself (you should see activity in the `Debug Console`).
2. Next run `kubectl apply -f config\samples\batch_v1_cronjob.yaml`. This wil deploy a new resource into our KIND cluster.

It's at this point your breakpoint should hit. You should be now able to step through the code and debug the sample project.

## Resources

* [Kubebuilder](https://book.kubebuilder.io/)
