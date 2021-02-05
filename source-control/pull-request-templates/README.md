# Pull Request Templates

To keep pull requests consistent and to help ensure quality across the project, pull request templates are essential. Pull request templates can be used in any solution that can interpret markdown.

## GitHub

In order to use a specific pull request template in GitHub, you must include the specific template in your URL. For example: if you want to use `bug-template-md`, you need to use query parameters when you open the PR, `https://github.com/[USERNAME OR ORG NAME]/[REPO NAME]/compare/master...[BRANCH NAME]?expand=1&template=bug-template.md`. If you want to have a default template so you do not have to always specify the template in the URL make sure you have `PULL_REQUEST_TEMPLATE.md` in the root of your `.github` folder. Example below:

```plaintext
- /.github
    - /PULL_REQUEST_TEMPLATE
        - bug-template.md
        - feature-template.md
    - PULL_REQUEST_TEMPLATE.md
...
```

It is also worth noting that the rendering of markdown is different between Azure DevOps and GitHub. Checkout the [GitHub Documentation](https://docs.github.com/en/free-pro-team@latest/github/building-a-strong-community/creating-a-pull-request-template-for-your-repository) for more information.

## Azure DevOps

Within Azure DevOps you can have multiple pull request templates and you select which one to use from the dropdown in the pull request screen. To use pull request templates create a folder in the root of your repo called `.azuredevops`. The default will be whatever you specific within `pull_request_template.md`.

It is worth noting that though technically you can put your templates in `docs` or `.vsts` it is cleaner to put it in the `.azuredevops` folder so that if you port your code over to GitHub at some point there isn't collision since there are formatting nuances between the two platforms.

```plaintext
- /.azuredevops
    - pull_request_template.md
    - bug-request.md
    - feature-request.md
```

![Azure DevOps Template List](./images/azdo-template-list.png)

## Example Templates

The example template below is generic and can be used for either features or bugs. If the team prefers, in their
repository, this example can be altered, or it can be split into separate Pull Request Types
per the documentation above.

- [Default Pull Request](./pull_request_template.md)
