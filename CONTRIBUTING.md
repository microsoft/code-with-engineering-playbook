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

## Purpose of this repo

Demonstrating Engineering Fundamentals is core to what we do at CSE and is one of the primary values we bring to our customers, helping them to level up while collaborating on their business scenarios.

The purpose of this repo is to provide guidance to CSE Dev Crews with regards to engineering fundamentals. It  describes recommended practices based on continuous project learnings in different areas. It can be used as a tool at the beginning of an engagement that can be shared with customers to help set the project up for success. This repo is *not* intended as a code repo, instead it provides guidance and links to appropriate sample code repos that represent good examples.

## Permissions & Contributions

There are two ways in which you can help update the content:

* **One-off:** \
If you are not a regular contributor to the project, but you would like to
contribute some changes, the best way to do it is to follow these [steps](#how-to-contribute)

* **Periodic and regular contributions:** \
If you plan to update the content semi-regularly or regularly, you can be added
to the project's Contributors group. Please contact [Federica Nocera](https://github.com/fnocera) or [Brock Davis](https://github.com/brockneedscoffee) to be added to the group.
You will still need to submit a PR against master in order to merge your changes.

## What to contribute

Contribute to the playbook repo anything that is:

* related to the fundamentals
* can be publicly visible (avoid confidential info)
* Generally applicable (not specific to internal processes)
* Short code snippets or links to OSS repos (no large code assets)

## How to contribute

When you have an idea for a contribution do one of two things:

* Contact one of the champions in the appropriate fundamental area and discuss your idea with them (check the reviewer groups [here](https://github.com/microsoft/code-with-engineering-playbook/blob/main/.github/reviewers.yml) to find a champion in the appropriate fundamental area)
* Look in the opened issues, if you cannot find a similar one then open an issue following the issue templates
  * **Note:** Adding new labels for an issue are only available for the project's Contributors group. Proposals for new labels are welcomed.

Once you have discussed your contribution:

* Add your changes to a new branch following [this](#branch-naming-convention)
* Open a PR and reviewers should be automatically assigned based on the location of your files changed. You need 2 approvals to merge your PR.

## Git guidance

Consistent with the practices suggested in this playbook, please follow the
specifics regarding git as described in this section.

### Branch naming convention

In this repo, we use this branch naming [approach](docs/source-control/naming-branches.md)

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

You can find information about other linters, general writing guidelines and code review check lists for Markdown in the [Markdown code review recipe](docs/code-reviews/recipes/markdown.md).

We have automatic quality gates for pull requests.
As such, we've provided tooling to lint locally through `npm`.

1. [Install npm](https://www.npmjs.com/get-npm).
2. Run `npm i` at the root of this repository.
3. Run `npm run lint` to run all linters.
Please see [the `package.json` file](package.json) for other scripts.

### Pull requests

When creating pull requests, follow guidance similar to the one suggested in
this repo, as described in the [Pull Request Template](docs/code-reviews/pull-request-template/pull-request-template.md)
section, under "Code Reviews". This includes linking to the work item that
prompted the pull request.

### Merging strategy

The preferred merging strategy for this repo is **linear**.
You can familiarize yourself with [merging strategies](docs/source-control/merge-strategies.md) described in the Source Control section of this repo.

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
