# Overview

Argo CD is a declarative, GitOps continuous delivery tool kit for Kubernetes (k8s).
After conducting extensive trade study of comparing Flux and Argo CD the team decided to use Argo CD in this project due to the fact that Argo CD is feature rich and supports extensive scenarios needed for this project as compared to Flux.
Detailed information about the trade study can be found in [GitOps Trade Study](../Trade-Studies/Gitops.md).

The application infrastructure pipeline (deploy-iac) handles the deployment of Argo CD to AKS cluster.
The whole process of Argo CD configuration and deployment is handled through a declarative approach which takes away the need to touch the `argocd` command-line tool for setup.

In this project Argo CD is configured to watch the `main` branch for any changes and when changes are detected an automated deployment of the application is triggered. This process seamlessly automates the manual process of deploying newer version of application following any new changes to main branch.
Another important feature is that in the worst case scenario where any parts of the application are changed or deleted Argo CD detects these issues and re-deploys the cluster to keep application running as intended.
