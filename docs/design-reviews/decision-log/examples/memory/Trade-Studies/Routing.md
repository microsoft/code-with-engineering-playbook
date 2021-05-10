# Trade Study: Routing

Conducted by:

- Wallace Breza (wabrez@microsoft.com)
- Tess DiStefano (tedistef@microsoft.com)

Backlog Work Item: #21738

Decision - 2/2/2021

- Internet Routing: [Azure Traffic Manager](<#Azure-Traffic-Manager-(ATM)>)
- Cluster Routing: [Linkerd](#Linkerd) + [Contour](#Contour)

Decision Makers: Memory Dev Crew

## Overview

The Memory application is built to support a geo-redundant and highly available infrastructure.
The application will be deployed in multiple regions with and include a data replication strategy.
Users of the application will be routed to the closest region based on latency between the users and the available regions.

Ex) If we deployed 3 regions in West US, Western Europe and Asia and a user access the application from Seattle, WA, the users request should be serviced by the West US instance assuming it is online and available.

1. Users will access the application through a single entry point, ex) <https://memory.contoso.com>
1. Regional specific endpoints should not be accessible via the public internet
1. If a region goes down due to maintenance or other issues requests are routed to an alternate region

This trade study will evaluate multiple routing / service mesh / gateway technologies.
1 or more technology can be selected to complete the solution.
Likely to have 1 selection to be used as an internet based router and other option for inter-cluster routing.

## Evaluation Criteria

### Internet Routing

- TLS termination
- HTTP/HTTPS request load balancing
- URL rewriting
- Session affinity
- Custom domains
- Web Access Firewall (WAF)
- Cost (High / Medium / Low)
- Maintainability
- Maturity

### Cluster Routing

[Cluster routing](https://kubernetes.io/docs/concepts/cluster-administration/networking/) refers to using the IP addresses, ports, etc of pods for routing as if they were their own machines.

- [CNCF](https://www.cncf.io/) Project
- Easy of use
- ArgoCD
- Helm
- Services Provided: service mesh, API gateway, ingress control
- Traffic Shifting
- Cost (High / Medium / Low)
- Maturity

## Internet Routing Solutions

The following candidate solution are being evaluated:

- [Azure Front Door (AFD)](<#Azure-Front-Door-(AFD)>)
- [Azure Traffic Manager (ATM)](<#Azure-Traffic-Manager-(ATM)>)

### Azure Front Door (AFD)

A global endpoint for your application that supports load balancing, custom domains, web application firewalls, session affinity, URL rewriting and more.

- Supports multiple configurations leveraging Network Security Groups (NSG) and Azure Firewall to protect ingress into regional AKS clusters
- Most application routing features would be handled by k8s service mesh making many of these features redundant
- Does not support [HTTP/2](https://docs.microsoft.com/en-us/azure/frontdoor/front-door-http2) to backend pools only uses HTTP 1.1.
- Higher cost when compared to ATM
- Supports Web Application Firewall (WAF)

#### AFD with Network Security Group (NSG)

![AFD with NSG](https://github.com/phillipgibson/Cloud-Azure-AKS-Using-AFD-with-AKS/raw/master/images/aks-azure-front-door.png)

#### AFD with Azure Firewall

![AFD with WAF](https://github.com/phillipgibson/Cloud-Azure-AKS-Using-AFD-with-AKS/raw/master/images/afd-aks-azfirewall-arch.png)

#### AFD References

- [Using AFD with AKS](https://github.com/phillipgibson/Cloud-Azure-AKS-Using-AFD-with-AKS)
- [Differences between AFD & Traffic Manager](https://medium.com/awesome-azure/azure-difference-between-traffic-manager-and-front-door-service-in-azure-4bd112ed812f)

### Azure Traffic Manager (ATM)

[Azure Traffic Manager](https://docs.microsoft.com/en-us/azure/traffic-manager/) is a DNS based traffic load balancer that can distribute network traffic across regions.
Use Traffic Manager to route users based on cluster response time or based on geography.

- Since routing happens at the DNS level all levels/versions of HTTP are supported (HTTP/2 gRPC)
- SSL Termination would need to be performed at the cluster level
- With routing at a DNS layer, traffic always goes from point to point.
  Routing from your branch office to your on premises datacenter can take a direct path; even on your own network using Traffic Manager.
- Lower cost when compared with AFD

![K8s with ATM](https://github.com/phillipgibson/Cloud-Azure-AKS-Using-AFD-with-AKS/raw/master/images/aks-azure-traffic-manager.png)

#### ATM References

- [AKS best practices](https://docs.microsoft.com/en-us/azure/aks/operator-best-practices-multi-region)
- [Configure Traffic Manager](https://docs.microsoft.com/en-us/azure/traffic-manager/traffic-manager-configure-geographic-routing-method)
- [Differences between AFD & Traffic Manager](https://medium.com/awesome-azure/azure-difference-between-traffic-manager-and-front-door-service-in-azure-4bd112ed812f)

## Cluster Routing Solutions

The following candidates are being evaluated:

- [Istio](#Istio)
- [Linkerd](#Linkerd)
- [Consul Connect](#Consul-Connect)
- [Ambassador](#Ambassador)
- [Traefik](#Traefik)
- [Contour](#Contour)

### Istio

[Istio](https://istio.io/latest/docs/concepts/what-is-istio/) is an OSS service mesh for connecting micro-services.
It uses [Envoy](https://www.envoyproxy.io/) to manage inter-pod routing.
While we will be using Kubernetes, Istio also supports running alone on virtual machines as well as Consul registered services.

- CNCF
  - No, not a CNCF project
- Easy of use
  - Istio seems easy to use but the docs seem to focus only on Linux and MacOS
- ArgoCD
  - Yes, [documentation on Istio website](https://argoproj.github.io/argo-rollouts/getting-started/istio/)
- Helm
  - Yes, [documentation on Istio website](https://argoproj.github.io/argo-rollouts/getting-started/setup/#helm)
- Services Provided: service mesh, API gateway, ingress control
  - Service Mesh: yes, builtin
  - API Gateway: [yes, builtin](https://istio.io/latest/docs/reference/config/networking/gateway/)
  - Ingress Control: can use [Kubernetes Ingress](https://istio.io/latest/docs/tasks/traffic-management/ingress/Kubernetes-ingress/).
    This supports the popular Nginx as well as other options outlined in the [Kubernetes docs](https://kubernetes.io/docs/concepts/services-networking/ingress/).
- Traffic Shifting
  - Yes Istio simplifies A/B testing, canary and staged rollouts, as well as percentage-based rollouts.
- Cost (High / Medium / Low)
  - OSS
- Maturity
  - 1,900+ stars, 277 forks, most recent commit was this month

![Istio Architecture](https://istio.io/latest/docs/ops/deployment/architecture/arch.svg)

#### Additional features

- [Authentication](https://istio.io/latest/docs/concepts/security/#authentication): Istio supports TLS for service-to-service, and uses JWT tokens for end-user authentication, supporting OIDC.
- [Azure docs](https://docs.microsoft.com/en-us/azure/aks/servicemesh-istio-install?pivots=client-operating-system-linux): Istio is supported in the AKS docs on Azure, alongside Linkerd and Consul.
  Though these docs only show how to use with an anonymous identity.
  There are also docs on the [Istio site](https://istio.io/latest/docs/setup/platform-setup/azure/) for how to integrate with Azure
- [Observability](https://istio.io/latest/docs/concepts/observability/) is extensive and includes metrics, traces, and logs.

### Linkerd

Linkerd is a service mesh for Kubernetes.
It makes running services easier and safer by giving you runtime debugging, observability, reliability, and security—all without requiring any changes to your code.

Pronounced as **_Linker-D_**

- [CNCF](https://www.cncf.io/) Project
  - Yes, A [CNCF Incubating project](https://www.cncf.io/projects/)
- Easy of use
  - Yes, easy learning curve
  - Relatively easier to adapt due to opinionated and out of the box configuration compared to Istio
- ArgoCD
  - No specific docs around ArgoCD
  - Installed via custom CLI
- Helm
  - No specific docs around Helm
  - Installed via custom CLI
- Services Provided: Service mesh
  - Supports all standard protocols (gRPC, HTTP/2, HTTP/1.x, WebSockets & TCP)
  - Supports OpenCensus for tracing support
  - Ships with out of the box dashboards for Prometheus / Grafana
- Traffic Shifting
  - Can use any ingress controller (None included by default)
  - Rings and traffic splitting supported via [Proxy Ingress Mode](https://linkerd.io/2/tasks/using-ingress/)
- Cost (High / Medium / Low)
  - Low, OSS with Apache license
- Maturity
  - 10,000+ GitHub stars
  - 700+ forks
  - New commits everyday
  - Created by [Buoyant](https://buoyant.io/)

![Architecture](https://linkerd.io/images/architecture/control-plane.png)

#### Linkerd Dashboard

![Dashboard](https://linkerd.io/images/architecture/stat.png)

#### Linkerd References

- [Features](https://linkerd.io/2/features/)
- [FAQ](https://linkerd.io/2/faq/#whats-the-difference-between-linkerd-and-istio)
- [Istio vs Linkerd](https://www.infracloud.io/blogs/service-mesh-comparison-istio-vs-linkerd/)

### Consul Connect

Service Networking Across Any Cloud.
A platform to discover, automate and secure service networking across any cloud or runtime.

- [CNCF](https://www.cncf.io/) Project
  - No, project is not part of CNCF
  - Developed by HashiCorp (creators of Vault, Terraform, and Vagrant)
- Easy of use
  - Seems overly enterprise focused
  - Does not feel focused on Kubernetes but rather can work in many different cloud based environments
  - Consul Connect uses an agent running on each node in a daemonset as the control plane, while Istio and Linkerd’s Conduit use centralized services.
  - Consul Connect is an extension of Consul, a highly available and distributed service discovery and KV store.
    Consul Connect adds service mesh capabilities and was created in July 2018 by HashiCorp.
    As an extension of Consul, Consul Connect can synchronize Kubernetes and Consul services
  - For the data plane, uses a “sidecar” pattern that places a proxy running in a separate container within each pod
- ArgoCD
  - No specific mention of Argo support
- Helm
  - Yes, via [Helm Chart Installation](https://www.consul.io/docs/k8s/installation/install#helm-chart-installation)
- Services Provided: Service Mesh
- Traffic Shifting
  - No built in gateway or ingress configuration
- Cost (High / Medium / Low)
  - Offers Open Source and Enterprise versions
- Maturity
  - 21,000+ GitHub stars
  - 3,600+ forks
  - Very active community
  - Last commit: 1/29/2021 (Same day as writing)

#### Consul Architecture

![Architecture](https://learn.hashicorp.com/img/k8s-consul-simple.png)

#### Consul References

- [Use Cases](https://learn.hashicorp.com/collections/consul/kubernetes)

### Ambassador

Route traffic to your Kubernetes services with the most popular Envoy Proxy-based Kubernetes Ingress Controller and API Gateway.

- CNCF Project
  - No, not a member of CNCF
- Easy of use
  - Works with service mesh providers like Istio, Linkerd & Consul
  - Supports wide range of protocols including gRPC & HTTP/2
  - Can be used for TLS termination
- ArgoCD
  - No specific documentation found around ArgoCD
- Helm
  - Yes, can be managed via [Helm Chart](https://www.getambassador.io/docs/latest/topics/install/helm/#install-with-helm)
- Services Provided: service mesh, API gateway, ingress control
- Traffic Shifting
  - Supports modern traffic management include load balancing, circuit breaking & progressive delivery
- Cost (High / Medium / Low)
  - Free version only supports up to 5 services & 5 RPS (Deal breaker)
- Maturity
  - 3,200+ stars and 480+ forks
  - Built using Envoy side car

#### Ambassador Architecture

![Ambassador Architecture](https://cdn.sanity.io/images/e3vd3ukt/production/b5af77fbdfcc4d3ead19ffd52a681ddab38e5018-628x400.png?fm=webp)

![Sample YAML](https://cdn.sanity.io/images/e3vd3ukt/production/ab4bf44ed3467a1ab5da8ebd8b07bac053884d01-699x672.png?fm=webp)

### Traefik

Traefik is a leading modern reverse proxy and load balancer that makes deploying microservices easy.
Traefik integrates with your existing infrastructure components and configures itself automatically and dynamically.

- Easy of use
  - Uses TOML or YAML files
  - Includes UX dashboard
- ArgoCD
  - Not able to find any docs specific to ArgoCD
- Helm
  - Yes - [Helm Charts](https://doc.traefik.io/traefik/getting-started/install-traefik/#use-the-helm-chart) are available
- Services Provided: Service mesh, API gateway, ingress control
- Traffic Shifting
  - Yes, through [configuration of entry points and rules](https://doc.traefik.io/traefik/routing/routers/#configuring-http-routers)
- Cost (High / Medium / Low)
  - Ingress is OSS while service mesh and API are paid enterprise offerings
- Maturity
  - 32,400+ stars, 3,600+ forks. (Proxy aka ingress)
    Last commit 1/25/2021 (1 week ago)

#### Traefik Architecture

![Traefik Solution](https://doc.traefik.io/traefik/assets/img/traefik-architecture.png)

### Contour

Contour is an open source Kubernetes ingress controller providing the control plane for the Envoy edge and service proxy.​ Contour supports dynamic configuration updates and multi-team ingress delegation out of the box while maintaining a lightweight profile.

- [CNCF](https://www.cncf.io/) Project
  - Yes, Contour is a [CNCF Incubating Project](https://www.cncf.io/projects/)
- Easy of use
  - Leverages Envoy sidecar
  - Supports API gateway or ingress controller
  - Supports TLS termination
  - Includes HTTP Proxy for request routing
  - Supports advanced traffic routing
  - Integrates well with logging tools like Prometheus
  - Supports CORS & WebSockets
  - Supports URL Rewriting
- ArgoCD
  - No docs referencing ArgoCD specifically
- Helm
  - Yes, [Install using Helm](https://projectcontour.io/getting-started/#option-3-install-using-helm)
- Services Provided: API gateway, Ingress controller
- Traffic Shifting
  - Yes, via [Request Routing](https://projectcontour.io/docs/v1.11.0/config/request-routing/)
- Cost (High / Medium / Low)
  - Low (OSS with Apache license)
- Maturity
  - 2,600+ Github Stars
  - Is a [CNCF](https://cncf.io/) incubating project
  - Acquired by VMware as part of Heptio acquisition

#### Contour Architecture

![Contour Architecture](https://projectcontour.io/docs/v1.11.0/img/archoverview.png)
![Request Traffic](https://projectcontour.io/docs/v1.11.0/img/contour_deployment_in_k8s.png)

## Internet Routing Results

| Solution              | HTTP Redirection | TLS Termination | Url Rewrite | Session Affinity | Custom Domains | HTTP/2 | WAF | Cost   |
| --------------------- | ---------------- | --------------- | ----------- | ---------------- | -------------- | ------ | --- | ------ |
| Azure Front Door      | Yes              | Yes             | Yes         | Yes              | Yes            | No     | Yes | Medium |
| Azure Traffic Manager | Yes              | No              | No          | No               | Yes            | Yes    | No  | Low    |

## Cluster Routing Results

| Solution   | CNCF | ArgoCD | Helm | Service Mesh | API Gateway | Ingress Controller | Traffic Shifting | Cost | Maturity  |
| ---------- | ---- | ------ | ---- | ------------ | ----------- | ------------------ | ---------------- | ---- | --------- |
| Istio      | No   | Yes    | Yes  | Yes          | Yes         | Yes                | Yes              | Low  | Excellent |
| Linkerd    | Yes  | ??     | Yes  | Yes          | No          | No                 | No               | Low  | Good      |
| Consul     | No   | Yes    | Yes  | Yes          | No          | No                 | No               | High | Excellent |
| Contour    | Yes  | ??     | Yes  | No           | Yes         | Yes                | Yes              | Low  | Good      |
| Ambassador | No   | Yes    | Yes  | No           | Yes         | Yes                | Yes              | High | Good      |
| Traefik    | No   | ??     | Yes  | Yes          | Yes         | Yes                | Yes              | High | Excellent |

Note: The formatting of the table can change.
In the past, we have had success with qualitative descriptions
in the table entries and color coding the cells to represent good, fair, bad.

## Decision

### Internet Routing Decision

1. **Azure Traffic Manager**

   - Most of the features of Azure Front Door are already handled by choices in cluster routing which would make AFD redundant.
   - Azure Traffic manager can point to multiple AKS clusters in different regions and hand off other concerns to the cloud native stack.

### Cluster Routing Decision

After investigation there are 2 major directions to take.

1. **Istio**

   - Istio has a long history in cloud native applications on k8s.
     The stack consists of all required services from service mesh, API Gateway & ingress controllers
   - It has received the reputation of being difficult to manage and configure.

1. **Linkerd + Contour (CNCF Stack)**
   - Linkerd & Contour are both up and coming CNCF incubating projects.
     CNCF graduated projects include those such as Kubernetes itself, Prometheus, Helm & Envoy.
   - Both projects have learned from projects before and offer simplified APIs and configurations.
