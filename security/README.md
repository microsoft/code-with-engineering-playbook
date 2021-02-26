# Security

Developers working on [CSE](../CSE.md) projects should adhere to industry-recommended standard practices for secure design and implementation of code. For the purposes of our customers, this means our engineers should understand the [OWASP Top 10 Web Application Security Risks](https://owasp.org/www-project-top-ten/), as well as how to mitigate as many of them as possible, using the resources below.

**If you are looking for a fast way to get started** evaluating your application or design, check out the "Secure Coding Practices Quick Reference" document below, which contains an itemized checklist of high-level concepts you can validate are being done properly. This checklist covers many common errors associated with the OWASP Top 10 list linked above, and should be the minimum amount of effort being put into security.

## Requesting Security Reviews

When requesting a security review for your application, please make sure you have familiarized yourself with the [Rules of Engagement](rules-of-engagement.md). This will help you to prepare the application for testing, as well as understand the scope limits of the test.

## Quick References

* [Secure Coding Practices Quick Reference](https://owasp.org/www-pdf-archive/OWASP_SCP_Quick_Reference_Guide_v2.pdf)
* [Web Application Security Quick Reference](https://owasp.org/www-pdf-archive//OWASP_Web_Application_Security_Quick_Reference_Guide_0.3.pdf)
* [Security Mindset/Creating a Security Program Quick Start](https://github.com/OWASP/Quick-Start-Guide/blob/master/OWASP%20Quick%20Start%20Guide.pdf?raw=true)

## Azure DevOps Security

* [Security Engineering DevSecOps Practices](https://www.microsoft.com/en-us/securityengineering/devsecops)
* [Azure DevOps Data Protection Overview](https://docs.microsoft.com/en-us/azure/devops/organizations/security/data-protection?view=azure-devops)
* [Security and Identity in Azure DevOps](https://docs.microsoft.com/en-us/azure/devops/organizations/security/about-security-identity?view=azure-devops)
* [Security Code Analysis](https://secdevtools.azurewebsites.net/)

## OWASP Cheat Sheets

> Note: OWASP is considered to be the gold-standard in computer security information. OWASP maintains an extensive series of cheat sheets which cover all of the OWASP Top 10 and more. Below, many of the more relevant cheat sheets have been summarized. To view all of the cheat sheets, check out their [Cheat Sheet Index](https://github.com/OWASP/CheatSheetSeries/blob/master/Index.md).

* [Access Control Basics](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Access_Control_Cheat_Sheet.md)
* [Attack Surface Analysis](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Attack_Surface_Analysis_Cheat_Sheet.md)
* [Content Security Policy (CSP)](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Content_Security_Policy_Cheat_Sheet.md)
* [Cross-Site Request Forgery (CSRF) Prevention](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Cross-Site_Request_Forgery_Prevention_Cheat_Sheet.md)
* [Cross-Site Scripting (XSS) Prevention](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Cross_Site_Scripting_Prevention_Cheat_Sheet.md)
* [Cryptographic Storage](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Cryptographic_Storage_Cheat_Sheet.md)
* [Deserialization](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Deserialization_Cheat_Sheet.md)
* [Docker/Kubernetes (k8s) Security](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Docker_Security_Cheat_Sheet.md)
* [Input Validation](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Input_Validation_Cheat_Sheet.md)
* [Key Management](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Key_Management_Cheat_Sheet.md)
* [OS Command Injection Defense](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/OS_Command_Injection_Defense_Cheat_Sheet.md)
* [Query Parameterization Examples](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Query_Parameterization_Cheat_Sheet.md)
* [Server-Side Request Forgery Prevention](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Server_Side_Request_Forgery_Prevention_Cheat_Sheet.md)
* [SQL Injection Prevention](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/SQL_Injection_Prevention_Cheat_Sheet.md)
* [Unvalidated Redirects and Forwards](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.md)
* [Web Service Security](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Web_Service_Security_Cheat_Sheet.md)
* [XML Security](https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/XML_Security_Cheat_Sheet.md)

## Recommended Tools

Check out the list of tools to help enable security in your projects.

> Note: Although some tools are agnostic, the below list is geared towards Cloud Native security, with a focus on Kubernetes.

* Vuln Scanning
  * [SonarCloud](https://sonarcloud.io/)
    * Integrates with Azure Devops with the click of a button.
  * [Snyk](https://github.com/snyk/snyk)
  * [Trivy](https://github.com/aquasecurity/trivy)
  * [Cloudsploit](https://github.com/aquasecurity/cloudsploit)
  * [Anchore](https://github.com/anchore/anchore-engine)
  * [Other tools from OWASP](https://owasp.org/www-community/Vulnerability_Scanning_Tools)
  * [See why you should check for vulnerabilities at all layers of the stack](https://sysdig.com/blog/image-scanning-best-practices/), as well as a couple of other useful tips to reduce surface area for attacks.

* Runtime Security
  * [Falco](https://github.com/falcosecurity/falco)
  * [Tracee](https://github.com/aquasecurity/tracee)
  * [Kubelinter](https://github.com/stackrox/kube-linter)
    * May not fully qualify as runtime security, but helps ensure you're enabling best practices.

* Binary Authorization

  Binary authorization can happen both at the docker registry layer, and runtime (ie: via a K8s admission controller).
  The authorization check ensures that the image is signed by a trusted authority. This can occur for both (pre-approved) 3rd party images,
  and internal images. Taking this a step further the signing should occur *only* on images where all code has been reviewed and approved.
  Binary authorization can both reduce the impact of damage from a compromised hosting environment, as well as the damage from malicious insiders.

  * [Harbor](https://github.com/goharbor/harbor/)
    * [Operator available](https://github.com/goharbor/harbor-operator)
  * [Portieris](https://github.com/IBM/portieris)
  * [Notary](https://github.com/theupdateframework/notary)
    * Note harbor leverages notary internally.
  * [TUF](https://github.com/theupdateframework/tuf)

* Other K8s Security

  * [OPA](https://github.com/open-policy-agent/opa), [Gatekeeper](https://github.com/open-policy-agent/gatekeeper), and the [Gatekeeper Library](https://github.com/open-policy-agent/gatekeeper-library/tree/master/library)
  * [cert-manager](https://github.com/jetstack/cert-manager) for easy certifcate provisioning and automatic rotation.
  * [Quickly enable mTLS between your microservices with Linkerd](https://linkerd.io/2/features/automatic-mtls/).
