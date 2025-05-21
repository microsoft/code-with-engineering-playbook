# Feature: Secure the CI/CD Pipeline

## User Story: Store all secrets securely and scan for leaks

### Tasks:
- Audit codebase for secrets using TruffleHog or Gitleaks
- Replace all secrets with environment variable references
- Configure managed identity access for Key Vault
- Add pre-commit secret scanning hook to all repos

## User Story: Integrate DevSecOps scanning tools in CI/CD

### Tasks:
- Add SonarQube / Semgrep / GitHub CodeQL for SAST
- Run OWASP ZAP or Dastardly for DAST in UAT
- Fail builds if critical vulnerabilities are found
- Publish scan reports to pipeline artifact folder