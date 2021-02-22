# Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether
you need to provide a CLA and decorate the PR appropriately (e.g., label,
comment). Simply follow the instructions provided by the bot. You will only need
to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of
Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct
FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any
additional questions or comments.

## Permissions & Contributions

There are two ways in which you can help update the content:

* **One-off:** \
If you are not a regular contributor to the project, but you would like to
contribute some changes, the best way to do it is:

  1. Fork the repo or create a new feature branch
  2. Write in your contributions
  3. Create a PR into this repo

* **Periodic and regular contributions:** \
If you plan to update the content semi-regularly or regularly, you can be added
to the project's Contributors group. Please contact one of the project's
administrators to be added to the group.
You will still need a PR against master in order to merge your changes.

## How to contribute

When you have an idea for contribution open an *issue*!

More details can be found in the internal CSE Wiki under the page `Contributing_to_the_Code-With_Engineering_Playbook`.

## Git guidance

Consistent with the practices suggested in this playbook, please follow the
specifics regarding git as described in this section.

### Branch naming convention

In this repo, we use the following branch naming conventions:

| Branch Type | Pattern | Example |
| - | - | - |
| Feature | feature/\<issue#>-\<short description> | feature/498-reorganize-scm-section |
| Bug Fix | fix/\<bug#>-\<short description> | bug/978-correct-grammar-myfile.md |

> **Note:**
>
> * Please, do not use personal branches. Work should refer back to a
feature/bug fix in the backlog.
> * Mind the capitalization of the branch prefix (feature, fix). Tools that
display branches as a hierarchy are typically case sensitive, and will display
different hierarchies for the same words with different capitalization.

### Linting

If you use VSCode as your preferred editor, please install the [markdownlint
extension](https://marketplace.visualstudio.com/items?itemName=DavidAnson.vscode-markdownlint)
and ensure that all rules are followed. This will help ensure consistency in the
look and feel of the documentation in this repo.

You can find information about other linters, general writing guidelines and code review check lists for Markdown in the [Markdown code review recipe](code-reviews/recipes/Markdown.md).

### Contributions and Pull requests

When creating pull requests, follow guidance similar to the one suggested in
this repo, as described in the ["Pull Request Template"](./code-reviews/pull-request-template.md)
section, under "Code Reviews". This includes linking to the work item that
prompted the pull request.

### Merging strategy

The preferred merging strategy for this repo is **linear**.
You can familiarize yourself with [merging strategies](./source-control/contributing/merge-strategies.md) described in the Source Control section of this repo.

## Adding a new section

### Structure/Pattern

Each section consist of the following parts

1. Summary
   1. Explain why this will positively impact the project
   2. What are potential consequences of not using this in my project?
   3. Describe how the concept works
2. Detailed Description
   1. Dive into specific areas of what is described in the above summary (i.e
   Refinement > Estimation > establish baseline estimates)
3. Recipes
   1. Tool specific implementations of the concept
   2. Named patterns or games that implement the concept (usually applies to
   agile ceremonies)

### Example Directory Hierarchy

The following illustrates how the directory structure could be organized.

```plaintext
- /continuous-integration
    - README.md (Conceptual)
    - /e2e-testing-in-ci
        - README.md
    - /static-code-analysis
        - README.md
    - /recipes
        - /azure-devops
            - versioning-ci-builds-in-azure-devops.md
            - sonar-qube-integration.md
            - ci-pipeline-for-dotnet-core.md
            - ci-pipeline-for-python.md
        - /jenkins
```

## Legal Notices

Microsoft and any contributors grant you a license to the Microsoft
documentation and other content in this repository under the
[Creative Commons Attribution 4.0 International Public License](https://creativecommons.org/licenses/by/4.0/legalcode),
see the [LICENSE](LICENSE) file, and grant you a license to any code in the
repository under the [MIT License](https://opensource.org/licenses/MIT), see the
[LICENSE-CODE](LICENSE-CODE) file.

Microsoft, Windows, Microsoft Azure and/or other Microsoft products and services
referenced in the documentation may be either trademarks or registered
trademarks of Microsoft in the United States and/or other countries.
The licenses for this project do not grant you rights to use any Microsoft
names, logos, or trademarks. Microsoft's general trademark guidelines can be
found at <http://go.microsoft.com/fwlink/?LinkID=254653>.

Privacy information can be found at <https://privacy.microsoft.com/en-us/>

Microsoft and any contributors reserve all others rights, whether under their
respective copyrights, patents, or trademarks, whether by implication, estoppel
or otherwise.
