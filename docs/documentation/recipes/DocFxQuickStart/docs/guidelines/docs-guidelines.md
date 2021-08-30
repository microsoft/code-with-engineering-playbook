# Documentation guidelines

## Folder structure

All documentation is stored in the **/docs** folder. In that folder there are standard defined sub-folders:

* **architecture-decisions** - All architecture decisions are documented here. Everything lands in the [decision log](../architecture-decisions/decision-log.md) in the root of the docs folder. All decisions that need more explanation than a one line will have separate docs here.

* **getting-started** - Limited documentation with the purpose of helping new people on the team to get started and setup.
* **guidelines** - General guidelines for the project.
* **working-agreements** - All working agreements.
* **developer** - All documentation important for developers, including how to's.

## Sub-folders and entry document

When adding documents think about the location it should be added to. Prevent a folder with lots of markdown files as it is harder to have an overview. It's better to group markdown files in sub-folders with sensible names.

> [!TIP]
> Prevent creating folders in the root level as much as possible.

Once all documents are generated into the documentation website, all folders will have an entry document. You can provide your own entry document by providing a README.md or INDEX.md in the folder. If you don't provide either of them, an INDEX.md is generated with a list of directories and files in the folder when the `TocDocFxCreation` tool is used.

You can also order the files and directories in a folder. This can be done by using a .order file in each folder. This is a text-file that just lists the filename *without extension* and/or directory names in a particular order. These names are case-sensitive. See [documentation on the Azure DevOps WIKI .order file](https://docs.microsoft.com/azure/devops/project/wiki/wiki-file-structure?view=azure-devops#order-file) for more information.

## Markdownlint

Standard documentation is writting using Markdown files (MD). [Markdownlint](https://github.com/markdownlint/markdownlint) should be used to check for properly structured markdown syntax. This is needed for the generation of static HTML documentation. You can use [Mardownlint extension for Visual Studio code](https://marketplace.visualstudio.com/items?itemName=DavidAnson.vscode-markdownlint) to get these checks and helps while you type in Visual Studio code.

## Use of images and other attachments

If you are writing a document and you have images or other files attached to that document, these extra files must be place in the **/docs/.attachments** folder. This is because of how [DocFX](https://dotnet.github.io/docfx/) is working, which is being used to generate documentation including API documentation from the source code. Also, the `DocLinkChecker` tool uses this location to validate documents versus attachments for orphaned items.
