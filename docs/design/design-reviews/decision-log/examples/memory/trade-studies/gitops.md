# Trade Study: GitOps

- Conducted by: Tess and Jeff
- Backlog Work Item: #21672
- Decision Makers: Wallace, whole team

## Overview

For Memory, we will be creating a cloud native application with infrastructure as code.
We will use GitOps for Continuous Deployment through pull requests infrastructure changes to be reflected.

Overall, between our two options, one is more simple and targeted in a way that we believe would meet the requirements for this project.
The other does the same, with additional features that may or may not be worth the extra configuration and setup.

### Evaluation Criteria

1. Repo style: mono versus multi
1. Policy Enforcement
1. Deployment Methods
1. Deployment Monitoring
1. Admission Control
1. Azure Documentation availability
1. Maintainability
1. Maturity
1. User Interface

## Solutions

### Flux

[Flux](https://toolkit.fluxcd.io/) is a tool created by Waveworks and is built on top of Kubernetes' API extension system, supports multi-tenancy, and integrates seamlessly with popular tools like Prometheus.

#### Flux Acceptance Criteria Evaluation

1. Repo style: mono versus multi
   - Flux supports both as of v2
1. Policy Enforcement
   - [Azure Policy is in Preview](https://learn.microsoft.com/en-us/azure/azure-arc/kubernetes/use-azure-policy)
1. Deployment Methods
   - Define a Helm [release](https://toolkit.fluxcd.io/guides/helmreleases/) using Helm Controllers
   - [Kustomization](https://toolkit.fluxcd.io/get-started/#deploy-podinfo-application) describes deployments
1. Deployment Monitoring
   - Flux works with Prometheus for deployment monitoring as well as Grafana dashboards
1. Admission Control
   - Flux uses RBAC from Kubernetes to lock down sync permissions.
   - [Uses the service account to access image pull secrets](https://docs.fluxcd.io/en/1.21.1/faq/#how-do-i-give-flux-access-to-an-image-registry)
1. Azure Documentation availability
   - Great, better when using Helm Operators
1. Maintainability
   - Manage via YAML files in git repo
1. Maturity
   - [v2 is published under Apache license in GitHub](https://github.com/fluxcd/flux2), it works with Helm v3, and has PR commits from as recently as today
   - 945 stars, 94 forks
1. User Interface
   - CLI, the simplest lightweight option

Other features to call out (see more on website)

- Flux only supports Pull-based deployments which means it must be paired with an operator
- Flux can send notifications and receive webhooks for syncing
- Health assessments
- Dependency management
- Automatic deployment
- Garbage collection
- Deploy on commit

#### Variations

##### Controllers

Both Controller options are optional.

The Helm Controller additionally fetches helm artifacts to publish, see below diagram.

The Kustomize Controller manages state and continuous deployment.

We will not decide between the controller to use here, as that's a separate trade study, however we will note that Helm is more widely documented within Flux documentation.

##### Flux v1

[Flux v1](https://github.com/fluxcd/flux) is only in maintenance mode and should not be used anymore.
So this section does not consider the v1 option a valid option.

##### GitOps Toolkit

Flux v2 is built on top of the [GitOps Toolkit](https://toolkit.fluxcd.io/components/), however we do not evaluate using the [GitOps Toolkit](https://toolkit.fluxcd.io/components/) alone as that is for when you want to make your own CD system, which is not what we want.

### ArgoCD with Helm Charts

ArgoCD is a declarative, GitOps-based Continuous Delivery (CD) tool for Kubernetes.

#### ArgoCD with Helm Acceptance Criteria Evaluation

1. Repo style: mono versus multi
   - ArgoCD supports both
1. Policy Enforcement
   - [Azure Policy is in Preview](https://learn.microsoft.com/en-us/azure/azure-arc/kubernetes/use-azure-policy)
1. Deployment Methods
   - Deploy with [Helm](https://argo-cd.readthedocs.io/en/stable/user-guide/helm/) Chart
   - Use [Kustomize](https://argo-cd.readthedocs.io/en/stable/user-guide/kustomize/) to apply some post-rendering to the Helm release templates
1. Deployment Monitoring
   - Argo CD expose two sets of [Prometheus](https://argo-cd.readthedocs.io/en/stable/operator-manual/metrics/) metrics (application metrics and API server metrics) for deployment monitoring.
1. Admission Control
   - ArgoCD use RBAC feature.
     [RBAC](https://argo-cd.readthedocs.io/en/stable/operator-manual/rbac/) requires SSO configuration or one or more local users setup.
     Once SSO or local users are configured, additional RBAC roles can be defined
   - Argo CD does not have its own user management system and has only one built-in user admin.
     The admin user is a superuser, and it has unrestricted access to the system
   - [Authorization is handled via JWT tokens](https://argo-cd.readthedocs.io/en/stable/operator-manual/security/#authentication) and checking group claims in them
1. Azure Documentation availability
   - Argo has [documentation](https://argo-cd.readthedocs.io/en/stable/operator-manual/user-management/microsoft/) on Azure AD
1. Maturity
   - Has PR commits from as recently as today
   - 5,000 stars, 1,100 forks
1. Maintainability
   - Can use GitOps to manage it
1. User Interface
   - ArgoCD has a GUI and can be used across clusters

Other features to call out (see more on website)

- ArgoCD support both pull model and push model for continuous delivery
- Argo can send notifications, but you need a separate tool for it
- Argo can receive webhooks
- Health assessments
- Potentially much more useful multi-tenancy tools.
  Manages multiple projects, maps them to teams, etc.
- SSO Integration
- Garbage collection

![Architecture](https://argo-cd.readthedocs.io/en/stable/assets/argocd_architecture.png)

## Results

This section should contain a table that has each solution rated against each of the evaluation criteria:

| Solution | Repo style  | Policy Enforcement    | Deployment Methods            | Deployment Monitoring | Admission Control | Azure Doc              | Maintainability       | Maturity                                  | UI                                 |
|----------|-------------|-----------------------|-------------------------------|-----------------------|-------------------|------------------------|-----------------------|-------------------------------------------|------------------------------------|
| Flux     | mono, multi | Azure Policy, preview | Helm, Kustomize               | Prometheus, Grafana   | RBAC              | Yes on Azure           | YAML in git repo      | 945 stars, 94 forks, currently maintained | CLI                                |
| ArgoCD   | mono, multi | Azure Policy, preview | Helm, Kustomize, KSonnet, ... | Prometheus, Grafana   | RBAC              | Only in their own docs | manifests in git repo | 5,000 stars, 1,100 forks                  | GUI, multiple clusters in same GUI |

## Decision

ArgoCD is more feature rich, will support more scenarios, and will be a better tool to put in our tool belts.
So we have decided at this point to go with ArgoCD.

## Resources

1. [GitOps](https://www.gitops.tech/#:~:text=What%20is%20GitOps?%20GitOps%20is%20a%20way%20of,familiar%20with,%20including%20Git%20and%20Continuous%20Deployment%20tools.)
1. [Enforcement](https://learn.microsoft.com/en-us/azure/azure-arc/kubernetes/use-azure-policy)
1. [Monitoring](https://learn.microsoft.com/en-us/azure/azure-monitor/insights/container-insights-onboard)
1. [Policies](https://learn.microsoft.com/en-us/azure/governance/policy/concepts/policy-for-kubernetes)
1. [Deployment](https://learn.microsoft.com/en-us/azure/azure-arc/kubernetes/use-gitops-with-helm)
1. [Push with ArgoCD in Azure DevOps](https://www.linkedin.com/pulse/azure-devops-gitops-aks-argocd-ajay-vikram-singh?articleId=6677601917633355776)
