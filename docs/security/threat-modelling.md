# Threat Modeling

Threat modeling is an effective way to help secure your systems, applications, networks, and services. It's a systematic approach that identifies potential threats and recommendations to help reduce risk and meet security objectives earlier in the development lifecycle.

## Threat Modeling Phases

1. *Diagram*
    Capture all requirements for your system and create a data-flow diagram
2. *Identify*
    Apply a threat-modeling framework to the data-flow diagram and find potential security issues. Here we can use [STRIDE framework](https://learn.microsoft.com/en-us/training/modules/tm-use-a-framework-to-identify-threats-and-find-ways-to-reduce-or-eliminate-risk/1b-threat-modeling-framework) to identify the threats.
3. *Mitigate*
    Decide how to approach each issue with the appropriate combination of security controls.
4. *Validate*
    Verify requirements are met, issues are found, and security controls are implemented.

Example of these phases is covered in the [threat modelling example.](./threat-modelling-example.md)
More details about these phases can be found at [Threat Modeling Security Fundamentals.](https://learn.microsoft.com/en-us/training/paths/tm-threat-modeling-fundamentals/)

## Threat Modeling Example

   [Here is an example](./threat-modelling-example.md) of a threat modeling document which talks about the architecture and different phases involved in the threat modeling. This document can be used as reference template for creating threat modeling documents.

## Resources

* [Threat Modeling](https://www.microsoft.com/en-us/securityengineering/sdl/threatmodeling)
* [Microsoft Threat Modeling Tool](https://learn.microsoft.com/en-us/azure/security/develop/threat-modeling-tool)
* [STRIDE (Threat modeling framework)](https://learn.microsoft.com/en-us/training/modules/tm-use-a-framework-to-identify-threats-and-find-ways-to-reduce-or-eliminate-risk/1b-threat-modeling-framework)
