# Evaluate Open Source Software

Given the rise in threat of [open source software supply chain attacks](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/), developers should identify potential candidates for open-source dependencies and evaluate them against your needs and the required security posture.

## Why Evaluate Open Source Software

Open source software is a critical part of modern software development. It is important to evaluate the open source software uses to ensure it meets the needs and is secure.
Security is not a given with open source software, and furthermore, what is secure today may not be secure tomorrow so scanning dependencies for known vulnerabilities doesn't always cover all bases.
This is why we need to look for evidence of a strong security posture and a commitment to security from the maintainers of the open source software we use.

## When to Evaluate Open Source Software

You should evaluate open source software before you use it in your project. This is especially important if the software is a dependency of your project, as it can introduce security vulnerabilities and other issues into your project.
Code reviewers should also be aware of the open source software used in the project and be able to use the tools and resources mentioned below to evaluate the security of the open source software that is being added to the project.

## Applying Open Source Software Evaluation

When evaluating open source software, consider the following:

- Can you avoid adding it as a dependency? The best dependency is the one you don't have.
- Is it maintained? How often and at what engineering rigor (i.e. code reviews, branch protection, tests)
- Is there evidence that effort is taken to make it secure?
- Can you find a reference that it is used significantly downstream by other projects or is referenced by known and trusted documentation? How many stars and forks does it have on GitHub?
- Is it easy to use securely?
- Does the license allow you to use it in your project?
- Are there instructions on how to report vulnerabilities?
- Does it have any known vulnerabilities or security issues?
- Are its dependencies secure, or at least up to date and actively maintained?
- Has it been audited by a third party such as the [OpenSSF Security Reviews](https://github.com/ossf/security-reviews/blob/main/Overview.md#readme)?

## Tools for Evaluating Open Source Software

- [OpenSSF Scorecards](https://github.com/ossf/scorecard) - This tool actually automates some of the checks in the list above and can be used to evaluate the security posture of open source projects. This can run as a GitHub action or in the Command Line Interface (CLI) to provide a security scorecard for open source projects. Note which metrics are important to you, your organization and the customer's. This tool is used by [known open source program offices (OSPO)](https://securityscorecards.dev/#part-of-the-oss-community) for measuring open source contributions by their employees.
- [OWASP Dependency-Check](https://owasp.org/www-project-dependency-check/) - a software composition analysis utility that identifies project dependencies and checks if there are any known, publicly disclosed, vulnerabilities.
- [Concise Guide for Evaluating Open Source Software](https://github.com/ossf/wg-best-practices-os-developers/blob/main/docs/Concise-Guide-for-Evaluating-Open-Source-Software.md) - a guide to help you expand upon the knowledge in this page to evaluate open source software.
