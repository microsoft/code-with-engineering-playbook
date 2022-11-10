# Secret Detection

It is important to ensure that secrets don't make it in to the code base and compromise the security of our application data. The best way of doing so is by introducing a simple and easy way to detect secrets during its development, and gate for secrets in your CI/CD pipelines.
This section describes how we can use the open-source secrets detection framework [Yelp Detect-Secrets](https://github.com/Yelp/detect-secrets), to accomplish this together with two tools from the Detect-Secrets framework created by the CSE Engineering Fundamentals and Security group.
The Yelp Detect-Secrets tool utilizes a Shannon Entropy model to detect secrets in code bases and prevents new secrets from being entered.

## Detect Secrets Pre-Commit Hook

The Detect-Secrets pre-commit hook is a tool that keeps secrets from being entering the codebase at one of the earliest stages of development.
This tool will run a detect-secrets scan right before a Git commit occurs and if any findings occur, then mitigation can occur before any history of the secret is generated in Git history.
Using the Detect Secrets Pre-Commit approach developers can ensure they don't accidentally commit secrets at the earliest point in the development cycle but at a project level it requires all developers to adopt this approach to provide protection.

### Configuration for Environment

Below are two ways of setting up your environment depending on your use case.

- [Pre-Commit Hook within Existing Repo](https://github.com/wbreza/pre-commit-hooks/blob/main/detect-secrets/README.md)
  - Simple install script bootstraps existing repos with pre-commit hooks and helper scripts to help manage the secret detection lifecycle
- [Pre-Commit Hook with New Repo Template](https://github.com/wbreza/baseline-security-seed/blob/main/SECURITY.md)
  - Contains all of the above plus out of the box support for dev containers using the Github universal dev container image.
  - Also includes a GitHub workflow to additionally perform secret detection within pull requests

## Detect Secrets Azure DevOps Marketplace Extension

This extension scans the code base for secrets using sophisticated algorithms such as Shannon entropy and reports the findings into the Azure DevOps Pipeline model to enable quick feedback and response from development teams throughout the development life cycle.
As an extension deployed in the CI/CD pipeline Detect Secrets does not rely on developers to change their development environment.
Depending on how your pipeline is configured replying on the CI/CD extension can lead to situations where secrets are leaked into the repository before being detected.
Leaking secrets into source the repository does require cleanup which is why using both pre-commit and CI/CD protections are recommended.

### Configuration

Currently this extension is in private preview and to get access reach out to a member of the Security Solution Area and we will onboard you and your crew.
You can either reach out directly or email csesecuritysa@microsoft.com

### Below contains the nominal YAML configuration for this tool

- Add the Detect-Secrets plugin from the task assistant and configure the tool to point to you source location and word list file (allow list).
The source location default will point to your repositories root directory.

{% raw %}

```YAML
- task: CSEDetectSecrets@1
  inputs:
    sourceLocation: '$(Build.Repository.LocalPath)'
    usingwordListFile: true
    wordListFile: 'allow-list.txt'
```

{% endraw %}

To report on the detect-secrets scan results add the following underneath the Yelp task:

{% raw %}

```YAML
- task: PublishTestResults@2
  displayName: 'Publish Test Results'

  inputs:
    testResultsFormat: 'JUnit'
    testResultsFiles: 'report.xml'
    searchFolder: '$(Build.Repository.LocalPath)'
```

{% endraw %}

### Scan Argument Notes

The nominal scan will invoke the detect-secrets scanner with the arguments `-C <path to root directory> scan --force-use-all-plugins`.
If you would like to point the tool at a specific directory append the desired location in the YAML e.g., `$(Build.Repository.LocalPath)/desired_path` and you will have to update the searchFolder: `$(Build.Repository.LocalPath)` path to see the results of the scan.

If the pipeline is configured without the scanNonGitFiles is configured for your pipeline, then the `--all-files` argument will be set to scan git artifacts in your pipeline as well.

`setFailureasWarning` will be set to false unless otherwise indicated, which will fail the task if a finding occurs.

### Triage - Allow-List Scan Argument Notes

To mitigate against false positives in the nominal you can add an allow list to skip over false positive secrets in future runs.

You must first add an allow-list in your repository; this is a text file with a name of your choosing containing a list of allow-listed secrets separated by carriage return.

> You must populate this list with the NON-HASHED SECRET!* Then you must check the "Use a word-list file?" box and then fill in the field "Location of secrets word-list file in repository" with your new file location.

Save and run the pipeline! If you come across more false positives in your pipeline, simply add them into your new allow-list file.

### Reporting

After the detect-secrets tool has been executed in the pipeline it will fail red with the number of secrets found in the repository, or it will pass green with no secrets found.

To look at the full detailed results navigate to the detect-secrets run results by clicking on the pipeline job number that just finished executing.
For example, a path should have this form at the top of the page, to the right of the Azure DevOps Logo: `<username>/<org name>/Pipelines/<name of pipeline>/<run #>`.

Clicking on the `<run #>` field will take you to an Azure DevOps page which contains the following tabs: "Summary", "Tests", "Scans".

If you select the "Tests" tab you will be navigated to a very nice-looking report summary, which showcases the suspect file(s), line number, and a hashed version of the secret along with how many secrets were found in the repository classified as "<#> Total tests".

#### User Story Generation

To add these secrets into the backlog you can navigate to the "Test Plans" pane located in the navigation panel on the left, click on "Runs", and then double click your most recent run it will take you to a Junit XML report.

Under the "Test Results" tab you can select the desired fixes and click on "Create bug" above.
> You can ctrl click the desired issues and group them into one user story - or generate individual user stories.

Add a name and notice that clicking on the link icon to the far right of the story contains the information for the backlog item. Add a description if desired - Save and Close.
This will create the story in the "Boards" Pane related to this organization.

## Nominal Scenario for Tool Utilization

A nominal outcome to ensure that secrets are not being introduced in the source code is to utilize both of these tools.  
Teams can apply Detect Secrets to the CI/CD pipeline to protect the project irrespective of individual contributor development practices.
Individuals can apply Detect Secrets as a pre-commit check to reduce the chance an accident will cause a secret to link into the project repository.
Following both practices provides the best coverage and by following the instructions above the same pre-commit world-list file can be fully reused in the CI/CD extension.

## Additional Reading

- [Yelp/detect-secrets: An enterprise friendly way of detecting and preventing secrets in code.](https://github.com/Yelp/detect-secrets)
