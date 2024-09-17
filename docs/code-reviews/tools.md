# Code Review Tools

## Customize ADO

### Task Boards

- AzDO: [Customize cards](https://learn.microsoft.com/en-us/azure/devops/boards/boards/customize-cards?view=azure-devops)
- AzDO: [Add columns on task board](https://learn.microsoft.com/en-us/azure/devops/boards/sprints/customize-taskboard?view=azure-devops#add-columns)

### Reviewer Policies

- Setting required reviewer group in AzDO - [Automatically include code reviewers](https://learn.microsoft.com/en-us/azure/devops/repos/git/branch-policies?view=azure-devops#automatically-include-code-reviewers)

## Configuring Branch Policies

1. AzDO: [Configure branch policies](https://learn.microsoft.com/en-us/azure/devops/repos/git/branch-policies?view=azure-devops#configure-branch-policies)
1. AzDO: Configuring branch policies with the CLI tool:
   2. [Create a policy configuration file](https://learn.microsoft.com/en-us/azure/devops/cli/policy-configuration-file?view=azure-devops#create-a-policy-configuration-file)
   2. [Approval count policy](https://learn.microsoft.com/en-us/rest/api/azure/devops/policy/configurations/create?view=azure-devops-rest-5.1#approval-count-policy)
1. GitHub: [Configuring protected branches](https://help.github.com/en/github/administering-a-repository/about-protected-branches)

## VSCode

### GitHub: [GitHub Pull Requests](https://marketplace.visualstudio.com/items?itemName=GitHub.vscode-pull-request-github)

Supports processing GitHub pull requests inside VS Code.

1. Open the plugin from the **Activity Bar**
1. Select **Assigned To Me**
1. Select a PR
1. Under **Description** you can choose to **Check Out** the branch and get into **Review Mode** and get a more integrated experience

### Azure DevOps: [Azure DevOps Pull Requests](https://marketplace.visualstudio.com/items?itemName=ankitbko.vscode-pull-request-azdo)

Supports processing Azure DevOps pull requests inside VS Code.

1. Open the plugin from the **Activity Bar**
1. Select **Assigned To Me**
1. Select a PR
1. Under **Description** you can choose to **Check Out** the branch and get into **Review Mode** and get a more integrated experience

## Visual Studio

The following extensions can be used to create an integrated code review experience in Visual Studio working with either GitHub or Azure DevOps.

### GitHub: [GitHub Extension for Visual Studio](https://marketplace.visualstudio.com/items?itemName=GitHub.GitHubExtensionforVisualStudio)

Provides extended functionality for working with pull requests on GitHub directly out of Visual Studio.

1. View -> Other Windows -> GitHub
1. Click on the **Pull Requests** icon in the task bar
1. Double click on a pending pull request

### Azure DevOps: [Pull Requests for Visual Studio](https://marketplace.visualstudio.com/items?itemName=VSIDEVersionControlMSFT.pr4vs)

Work with pull requests on Azure DevOps directly out of Visual Studio.

1. Open Team Explorer
1. Click on **Pull Requests**
1. Double-click a pull request - the **Pull Request Details** open
1. Click on **Checkout** if you want to have the full change locally and have a more integrated experience
1. Go through the changes and make comments

## Web

### Reviewable: [Seamless multi-round GitHub reviews](https://home.reviewable.io/)

Supports multi-round GitHub code reviews, with keyboard shortcuts and more. VS Code extension is in-progress.

1. Visit the [Review Dashboard](https://reviewable.io/reviews) to see reviews awaiting your action, that have new comments for you, and more.
1. Select a Pull Request from that list.
1. Open any file in your browser, in Visual Studio Code, or any editor you've configured by clicking on your profile photo in the top-right
1. Select an editor under "External editor link template". VS Code is an option, but so is any editor that supports URI's.
1. Review the diff on an overall or per-file basis, leaving comments, code suggestions, and more
