# Component Versioning

## Goal

Larger applications consist of multiple components that reference each other and rely on compatibility of the interfaces/contracts of the components.

To achieve the goal of loosely coupled applications, each component should be versioned independently hence allowing developers to detect breaking changes or seamless updates just by looking at the version number.

## Version Numbers and Versioning schemes

For developers or other components to detect breaking changes the version number of a component is important.

There is different versioning number schemes, e.g.

`major.minor[.build[.revision]]`

or

`major.minor[.maintenance[.build]]`.

Upon build / CI these version numbers are being generated. During CD / release components are pushed to a *component repository* such as Nuget, NPM, Docker Hub where a history of different versions is being kept.

Each build the version number is incremented at the last digit.

Updating the major / minor version indicates changes of the API / interfaces / contracts:

* Major Version: A breaking change
* Minor Version: A backwards-compatible minor change
* Build / Revision: No API change, just a different build.

## Semantic Versioning

Semantic Versioning is a concept of calculating the version number automatically based on a certain source code repository.

The `semver` tool looks at a GIT source control branch and comes up with a *repeatable* and *unique* version number based on

* number of commits since last major or minor release
* commit messages
* tags
* branch names

Examples of semver version numbers:

* **1.0.0-alpha.1**: +1 commit *after* the alpha release of 1.0.0
* **2.1.0-beta**: 2.1.0 in beta branch
* **2.4.2**: 2.4.2 release

Version Updates happen through:

* Commit messages or tags for Major / Minor / Revision updates.
* Branch names (e.g. develop, release/..) for Alpha / Beta / RC
* Otherwise: Number of commits (+12, ..)

Recommendation is to run semver during your CI process to make each build uniquely identifiable.

## Resources

* [Semantic Versioning](https://semver.org/)
* [Versioning in C#](https://docs.microsoft.com/en-us/dotnet/csharp/versioning)
* [SemVer Task for VSTS](https://marketplace.visualstudio.com/items?itemName=geeklearningio.gl-vsts-tasks-semver)
