# Code folder

This folder contains all the solutions for this project. Provide more details for your project here.

In this sample we have included the companion tools in this folder. More details can be found in [Getting Started readme](../docs/getting-started/README.md).

## defaults for your projects

In this folder the file **Directory.Build.props** is included. This file is picked up by all project files in any of the sub folders. It directs to the **build\dotnet\common.props** file to define common settings for all projects. For more information about this, see the article [Customize your build](https://docs.microsoft.com/en-us/visualstudio/msbuild/customize-your-build?view=vs-2019).

To generate complete reference information from code, proper triple slash-comments are required. In the common settings we enforced the use of StyleCop and FxCop, which in turn enforce proper comments. In the **build\dotnet\CodeAnalysis.ruleset** we switched off some rules for the projects in this folder. You can tailor that to your likings as well. For more information about this, see the article [Use rule sets to group code analysis rules](https://docs.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2019).
