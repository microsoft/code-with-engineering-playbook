# Reliability

All of the other CSE Eng Fundamentals work towards a more reliable infrastrucute. Automated integration and deployment ensures code is properly tested, and helps remove human error, while slow releases build confidence in the code. Observability helps more quickly pinpoint errors when they arise to get back to a stable state, and so on.

However there are some additional steps we can take, that don't neatly fit into the previous categories, to help ensure a more reliable solution. We'll explore these below.

## Remove "Foot-Guns"

Prevent your dev team from shooting themselves in the foot. People make mistakes; any mistake made in production is not the fault of that person, moreso it's the collective fault of the system to not prevent that mistake from happening.

Check out the below list for some common tooling to remove these foot guns:

* In Kubernetes, leverage [Admission Controllers](https://kubernetes.io/docs/reference/access-authn-authz/admission-controllers/) to prevent "bad things" from happening.
  * You can create custom controllers using the Webhook Admission controller.
* [Gatekeeper](https://github.com/open-policy-agent/gatekeeper) is a pre-built Webhook Admission controller, leveraging [OPA](https://github.com/open-policy-agent/opa) underneath the hood, with support for some [out-of-the-box protections](https://github.com/open-policy-agent/gatekeeper-library/tree/master/library)

If a user ever makes a mistake, don't ask: "how could somebody possibly do that?", do ask: "how can we prevent this from happening in the future?"

## Autoscaling

Whenever possible, leverage autoscaling for your deployments. Vertical autoscaling can scale your VM's by tuning parameters like CPU, disk, and RAM, while horizontal autoscaling can tune the number of running images backing your deployments. Autoscaling can help your system respond to inorganic growth in traffic, and prevent failing requests due to resource starvation.

> Note: In environments like K8s, both horizontal and vertical autoscaling are offered as a native solution. The VM's backing each Pod however, may also need autoscaling to handle an increase in the number of Pods.

It should also be noted that the parameters that affect autoscaling can be difficult to tune. Typical metrics like CPU or RAM utilization, or request rate may not be enough. Sometimes you might want to consider custom metrics, like cache eviction rate.

## Loadshedding & DOS Protection

Often we think of Denial of Service [DOS] attacks as an act from a malicious actor, so we place some Loadshedding at the gates to our system and call it a day. In reality, many DOS attacks are unintentional, and self-inflicted. A bad deployment that takes down a Cache results in hammering downstream services. Polling from a distributed system synchronizes and results in a [thundering herd](https://en.wikipedia.org/wiki/Thundering_herd_problem). A misconfiguration results in an error which triggers clients to retry uncontrollably. Requests append to a stored object until it is so big that future reads crash the server. The list goes on.

Follow these steps to protect yourself:

* Add a jitter (random) to any action that occurs from a non user triggered flow (ie: add a random duration to the sleep in a cron, or job that continously polls a downstream service).
* Implement [exponential backoff retry policies](https://en.wikipedia.org/wiki/Exponential_backoff) in your client code
* Add loadshedding to your servers (yes, your internal microservices too).
  * This can be configured easily when leveraging a sidecar like envoy.
* Be careful when deserializing user requests, and use buffer limits.
  * ie: HTTP/gRPC Servers can set limits on how much data will get read from the socket.
* Set alerts for utilization, servers restarting, or going offline to detect when your system may be failing.

These types of errors can result in Cascading Failures, where a non-critical portion of your system takes down the entire service. Plan accordingly, and make sure to put extra thought into how your system might degrade during failures.

## Backup Data

Data gets lost, corrupted, or accidentally deleted. It happens. Take data backups to help get your system back up online as soon as possible. It can happen in the application stack, with code deleting or corrupting data, or at the storage layer by losing the volumes, or losing encryption keys.

Consider things like:

* How long will it take to restore data.
* How much data loss can you tolerate.
* How long will it take you to notice there is data loss.

Look into the difference between **snapshot** and **incremental** backups. A good policy might be to take incremental backups on a period of N, and a snapshot backup on a period of M (where N < M).

## Target Uptime & Failing Gracefully

It's a known fact that systems cannot target 100% uptime. There are too many factors in today's software systems to achieve this, many outside of our control. Even a service that never gets updated and is 100% bug free will fail. Upstream DNS servers have issues all the time. Hardware breaks. Power outages, backup generators fail. The world is chaotic. Good services target some number of "9's" of uptime. ie: 99.99% uptime means that the system has a "budget" of 4 minutes and 22 seconds of uptime each month. Some months might achieve 100% uptime, which means that budget gets rolled over to the next month. What uptime means is different for everybody, and up to the service to define.

A good practice is to use any leftover budget at the end of the period (ie: year, quarter), to intentionally take that service down, and ensure that the rest of your systems fail as expected. Often times other engineers and services come to rely on that additional achieved availability, and it can be healthy to ensure that systems fail gracefully.

We can build graceful failure (or graceful degradation) into our software stack by anticipating failures. Some tactics include:

* Failover to healthy services
  * [Leader Election](https://en.wikipedia.org/wiki/Leader_election) can be used to keep healthy services on standby in case the leader experiences issues.
  * Entire cluster failover can redirect traffic to another region or availability zone.
  * Propagate downstream failures of **dependent services** up the stack via healthchecks, so that your ingress points can re-route to healthy services.
* [Circuit breakers](https://techblog.constantcontact.com/software-development/circuit-breakers-and-microservices/#:~:text=The%20Circuit%20breaker%20pattern%20helps,unavailable%20or%20have%20high%20latency.) can bail early on requests vs. propogating errors throughout the system

## Practice

[None of the above recommendations will work if they are not tested](https://thinkmeta.net/2010/11/06/what-is-an-untested-dr-plan-worth/). Your backups are meaningless if you don't know how to mount them. Your cluster failover and other mitigations will regress over time if they are not tested. Here's some tips to test the above:

### Maintain Playbooks

No software service is complete without playbooks to navigate the devs through unfamiliar territory. Playbooks should be thorough and cover all known failure scenarios and mitigations.

### Run maintenance exercises

Take the time to fabricate scenarios, and run a D&D style campaign to solve your issues. This can be as elaborate as spinning up a new environment and injecting errors, or as simple as asking the "players" to navigate to a dashboard and describing would they would see in the fabricated scenario (small amounts of imagination required). The playbooks should **easily** navigate the user to the correct solution/mitigation. If not, update your playbooks.

### Chaos Testing

Leverage automated chaos testing to see how things break. Check out the list of the following tools:

* [Chaos Monkey](https://netflix.github.io/chaosmonkey/)
* [Kraken](https://github.com/cloud-bulldozer/kraken)
* Many services meshes, like [Linkerd](https://linkerd.io/2/features/fault-injection/), offer fault injection tooling through the use of their sidecars.
* [Chaos Mesh](https://github.com/chaos-mesh/chaos-mesh)

## Analyze all Failures

Writing up a [post-mortem](https://en.wikipedia.org/wiki/Postmortem_documentation) is a great way to document the root causes, and action items for your failures. They're also a great way to track recurring issues, and create a strong case for prioritizing fixes.

This can even be tied into your regular Agile [restrospectives](../agile-development/retrospectives/readme.md).
