# Java Code Reviews

## Java Style Guide

[CSE](../../CSE.md) developers generally follow the [Google Java Style Guide](https://google.github.io/styleguide/javaguide.html).

## Code Analysis / Linting

We strongly believe that consistent style increases readability and maintainability of a code base. Hence we are recommending analyzers to enforce consistency and style rules.

We make use of [Checkstyle](https://github.com/checkstyle/checkstyle) using the [same configuration used in the Azure Java SDK](https://github.com/Azure/azure-sdk-for-java/blob/master/eng/code-quality-reports/src/main/resources/checkstyle/checkstyle.xml).  

Also frequently used is [FindBugs](http://findbugs.sourceforge.net/) and [PMD](https://pmd.github.io/).

## Automatic Code Formatting

Eclipse, and other Java IDEs, support automatic code formatting.  If using Maven, some developers also make use of the [formatter-maven-plugin](https://github.com/revelc/formatter-maven-plugin).

## Build Validation

It's important to enforce your code style and rules in the CI to avoid any team members merging code that does not comply with standards into your git repo.  If building using Azure DevOps, the [Maven and Gradle build tasks support](https://docs.microsoft.com/en-us/azure/devops/java/standalone-tools?view=azure-devops) using [PMD](https://pmd.github.io/), [Checkstyle](https://checkstyle.sourceforge.io/), and [FindBugs](http://findbugs.sourceforge.net/) code analysis tools as part of every build.

Here is an example yaml for a Maven build task with all three analysis tools enabled:

```yaml
    - task: Maven@3
    displayName: 'Maven pom.xml'
    inputs:
        mavenPomFile: '$(Parameters.mavenPOMFile)'
        checkStyleRunAnalysis: true
        pmdRunAnalysis: true
        findBugsRunAnalysis: true
```

Here is an example yaml for a Gradle build task with all three analysis tools enabled:

```yaml
    - task: Gradle@2
    displayName: 'gradlew build'
    inputs:
        checkStyleRunAnalysis: true
        findBugsRunAnalysis: true
        pmdRunAnalysis: true
```

## Code Review Checklist

In addition to the [Code Review Checklist](../process-guidance/reviewer-guidance.md) you should also look for these Java specific code review items

* [ ] Does the project use Lambda to make code cleaner?
* [ ] Is dependency injection (DI) used?  Is it setup correctly?
* [ ] If the code uses Spring Boot, are you using @Inject instead of @Autowire?
* [ ] Does the code handle exceptions correctly?
* [ ] Is the [Azul Zulu OpenJDK](https://docs.microsoft.com/en-us/java/azure/jdk/java-jdk-install?view=azure-java-stable) being used?
* [ ] Is a build automation and package management tool (Gradle or Maven) being used?
