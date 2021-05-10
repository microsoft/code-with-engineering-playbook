# Trade Study: K8s Package Management

Conducted by: Neeraj Mandal, Wallace Breza & Tanner Barlow

Backlog Work Item: #21674

Decision: Helm

Decision Makers: Team

Date: 1/28/2021

## Overview

As a team, we've decided to use Kubernetes as our container orchestration solution.
In order to use Kubernetes effectively, we need a **package manager** to handle deploying solutions to the Kubernetes cluster.
This document will assess a few options and guide the decision on which package management solution we will use for this project.
As a team, we've already made the decision to use **ArgoCD** as our GitOps deployment mechanism, so integration with that tool will be critical.

### Evaluation Criteria

- Supports Templating Logic - Configuration files support templating (Yes, No)
- Supports YAML Methods - Logic can be applied inside `.yaml` files (Yes, No)
- Supports Multiple Environments - Support multiple deployment environments (Yes, No)
- Supports Rollbacks - Supports rolling back deployments made (Yes, No)
- Supports Packaging - Supports packaging of components (Yes, No)
- Supports Hooks - Supports actions to be run at various stages of deployment lifecycle (Yes, No)
- Production Ready - Ready for production use (Yes, No)
- Platform Maturity / Support - Qualitative measure for current maturity and support (Low, Med, High)
- ArgoCD Integration - Documentation available for integration of ArgoCD into package management tools.

The results section contains a table evaluating each solution against the evaluation criteria.

## Solutions

### Helm

- Helm is a popular package manager for Kubernetes which integrates with popular GitOps tools like [Flux](https://docs.fluxcd.io/en/1.17.0/tutorials/get-started-helm.html) and [ArgoCD](https://argoproj.github.io/argo-cd/user-guide/helm/).
- Helm makes its possible to template Kubernetes manifest files and provide configuration values through values.yaml or command line to customize deployments.
- Helm's greater scope of supporting hooks, rollback, packaging and server for distribution makes Helm better options that other Kubernetes package management tools.
- Helm makes it possible to organize Kubernetes objects in a packaged application that anyone can download and install in one click, or configure to their specific needs.

#### Use Case - Helm

- Hassle free deployment of the application to multiple environments like dev, prod & testing.
- Simplified leveraging of Kubernetes packages through a single CLI command.
- Reusable chart repo.
- Distribution and reusability.
- Nesting of charts — dependencies
- Deploy an image that is already built.
- Upgrades and rollbacks of multiple k8s objects together — lifecycle management.

#### Community - Helm

- Stars: 18,800
- Forks: 5,500
- Last Commit: 01/24/2021

#### Architecture - Helm

![Architecture](https://miro.medium.com/max/700/1*mClrYLFakC6B6f62vVnhcA.png)

#### Resources - Helm

- [Helm](https://helm.sh/)
- [Helm GitHub Repo](https://github.com/helm/helm)

### Kustomize

- Built into `kubectl` command
- Write `kustomization.yaml` to decorate existing YAML K8s files
- Logic in `.yaml` files
- No templating logic whatsoever
- Different environments require their own `.yaml` files
- To create different environments, use overlays

  ```bash
  kubectl apply -k overlays/dev
  kubectl apply -k overlays/prod
  ```

#### Use Case - Kustomize

- Deploy multiple components to a Kubernetes cluster
- Define configurations for each environment

#### Community - Kustomize

- Stars: 6,700
- Forks: 1,300
- Latest Commit: 1/27/2021 (today at the time of writing this doc)

#### Usage

![Resources](https://github.com/kubernetes-sigs/kustomize/raw/master/docs/images/base.jpg)

##### Overlays

Use [overlays](https://kubernetes-sigs.github.io/kustomize/api-reference/glossary#overlay) to create new environments.

![Overlays](https://github.com/kubernetes-sigs/kustomize/raw/master/docs/images/overlay.jpg)

``` bash
~/someApp
├── base
│   ├── deployment.yaml
│   ├── kustomization.yaml
│   └── service.yaml
└── overlays
    ├── development
    │   ├── cpu_count.yaml
    │   ├── kustomization.yaml
    │   └── replica_count.yaml
    └── production
        ├── cpu_count.yaml
        ├── kustomization.yaml
        └── replica_count.yaml
```

### Kubes

- Kubes is a Kubernetes deployment tool that builds Docker images, creates Kubernetes YAML, and runs kubectl apply on compiled Kubernetes YAML files.
- Kubes supports templating, deployment to multiple environments and docker builds.

#### Use Case - Kubes

- Developing apps that run on Kubernetes
- Easy deployment using simple `kubes deploy` which first builds docker, complies Kubernetes YAML files and calls kubectl apply.
- Deployment to multiple environments like dev and prod using the same YAML file.

#### Community - Kubes

- Stars: 32
- Forks: 3
- Last Commit: 12/24/2020

#### Architecture (Not Available)

#### Resources - Kubes

- [Kubes](https://kubes.guru/)
- [Kubes GitHub Repo](https://github.com/boltops-tools/kubes)

### Gitkube

- Recommended for fast prototyping and pushing WIP changes to a cluster for testing.
- Tooling installed directly on cluster, no CLI or dev tools
- Easily push container via simple `git push` command to new remote

#### Use Case - Gitkube

- Easy deployments using git, without docker builds
- Developing apps on Kubernetes
- While development, WIP branch can be pushed multiple times to see immediate results

#### Community - Gitkube

- Stars: 3,400
- Forks: 177
- Last Commit: 4/8/2020

#### Architecture - Gitkube

![Architecture](https://hasura.io/blog/content/images/downloaded_images/draft-vs-gitkube-vs-helm-vs-ksonnet-vs-metaparticle-vs-skaffold-f5aa9561f948/1-n9Il4vKaq9gHC5qQyF-9Tg.png)

#### Resources - Gitkube

- [https://gitkube.sh/](https://gitkube.sh/)
- [https://github.com/hasura/gitkube](https://github.com/hasura/gitkube)

### Draft

Draft makes it easy to build applications that run on Kubernetes.
Draft targets the "inner loop" of a developer's workflow: as they hack on code, but before code is committed to version control.

This is Draft's goal; to empower teams to be able to develop on top of Kubernetes - without adding complexity to their workflow.

Developed by the same team behind Helm.

- Not targeted for production k8s packaging scenarios
- Does not appear to be actively maintained.
- Requires Helm as a cluster prerequisite

#### Community - Draft

- Stars: 3,900
- Forks: 418
- Last Commit: 10/9/2019
- Repo on GitHub is updated to `read-only`

#### Architecture - Draft

![Draft Architecture](https://hasura.io/blog/content/images/downloaded_images/draft-vs-gitkube-vs-helm-vs-ksonnet-vs-metaparticle-vs-skaffold-f5aa9561f948/1-kV56ClDz_rrMg5wT4lpQ5Q.png)

#### Use Case - Draft

- Developing apps that run on Kubernetes
- Used in “inner loop”, before code is committed onto version control
- Pre-CI: Once development is complete using draft, CI/CD takes over
- Not to be used in production deployment

#### Resources - Draft

- [https://draft.sh/](https://draft.sh/)
- [https://github.com/Azure/draft](https://github.com/Azure/draft)

### Alternative Decisions

Here we will discuss any alternative solutions not being fully treated as their own option.

#### Helm + Kustomize

Because Helm and Kustomize provide different offerings, we can consider using both. We'll outline this section from the perspective of an application design that has already chosen Helm and might want to consider adding Kustomize as well.

##### Use Case

- Using a root `.yaml` generated by Helm, Kustomize can additionally provide another layer on top through defining additional information in a separate .yaml file that can be used to patch after a deployment of the root `.yaml`.
- Kustomize has a feature to get rid of the auto-generated secrets in the generated `.yaml` - "secretGenerator / configMapGenerator"
- `kustomize build` command: validate manifests and patches
- namespace cohesion: you can define a single `kustomization.yaml` to `build` multiple `.yaml` files.
- ArgoCD can be setup to automatically sync via calling `kustomize build` and `kubectl apply -f`, or manually.

##### Additional Resources

- [How to use Kustomize to patch Helm templates](https://medium.com/faun/patch-any-helm-chart-template-using-a-kustomize-post-renderer-c9e000c53199)
- [Better GitOps when adding Kustomize](https://blog.container-solutions.com/using-helm-and-kustomize-to-build-more-declarative-kubernetes-workloads)

## Results

This section should contain a table that has each solution rated against each of the evaluation criteria:

| Solution         | Templating | YAML Methods | Multiple Envs | Rollbacks | Packaging | Hooks | Production Ready | Maturity/Support | ArgoCD Integration |
|:-----------------|:----------:|:------------:|:-------------:|:---------:|:---------:|:-----:|:----------------:|:----------------:|:------------------:|
| Helm             |    Yes     |      No      |      Yes      |    Yes    |    Yes    |  Yes  |       Yes        |       High       |        Yes         |
| Kustomize        |     No     |     Yes      |      Yes      |    No     |    No     |  No   |       Yes        |       High       |        Yes         |
| Helm + Kustomize |    Yes     |     Yes      |      Yes      |    Yes    |    Yes    |  Yes  |       Yes        |       High       |        Yes         |
| Kubes            |    Yes     |      No      |      Yes      |    No     |    Yes    |  Yes  |       Yes        |       Low        |         No         |
| Gitkube          |     No     |      No      |      No       |    No     |    No     |  No   |        No        |       Low        |         No         |
| Draft            |    Yes     |      No      |      No       |    No     |    No     |  No   |        No        |       Low        |         No         |

## Decision

We propose using Helm as our package manager, considering the community support, platform maturity, templating ability and ArgoCD integration.
