# Developer Experience

Developer experience refers to the how easy or difficult it is for a developer to perform essential tasks needed to implement a change. A positive developer experience would mean these tasks are relatively easy for the team (see measures below).

The essential tasks are identified below.

- Build - Verify that changes are free of syntax error and compile.
- Test - Verify that all automated tests pass.
- Start - Launch end-to-end to simulate execution in a deployed environment.
- Debug - Attach debugger to started solution, set breakpoints, step through code, and inspect variables.

If effort is invested to make these activities as easy as possible, **the returns on that effort will be multiply the longer the project runs and the larger the team**.

## Goals

- Maximize the amount of time engineers spend on writing code that fulfills story acceptance and done-done criteria.
- Minimize the amount of time spent manual setup and configuration of tooling
- Minimize regressions and new defects by making end-to-end testing easy

## Impact

Developer experience can have a significant impact on the efficiency of the day to day execution of the team. A positive experience can pay dividends throughout the lifetime of the project; especially as new developers join the team.

- Increased Velocity - Team spends less time on non-value-add activities such as dev/local environment setup, waiting on remote environments to test, and rework (fixing defects).
- Improved Quality - When its easy to debug and test, developers will do more of it. This will translate to fewer defects being introduced.
- Easier Onboarding & Adoption - When dev essential tasks are automated, there is less documentation to write and, subsequently, less to read to get started!

**Most importantly, the customer will continue to accrue these benefits long after the code-with engagement.**

## Measures

### Time to First E2E Result (aka F5 Contract)

Assuming a laptop/pc that has never run the solution, how long does it take to setup and run the whole system end-to-end and see a result.

### Time To First Commit

How long does it take to make a change that can be verified/tested locally. A locally verified/tested change is one that passes test cases without introducing regression or breaking changes.

## Participation

The entire development team should take responsibility in ensuring positive experience. How

## Facilitation Guidance

The following outline examples of several strategies that can be adopted to promote a positive developer experience. It is expected that each team should define what a positive dev experience means within the context of their project. Additionally, refine that over time via feedback mechanisms such as sprint and project retrospectives.

### Establish Hotkeys

Assign hotkeys to each of the essential tasks.

[`TODO: Suggest hotkeys for mac`]

| Task                 | Windows      |
| -------------------- | ------------ |
| Build                | CTRL+SHIFT+B |
| Test                 | CTRL+R,T     |
| Start With Debugging | F5           |

### The F5 Contract

The F5 contract aims for the ability to run the end-to-end solution with the following steps.

1. Clone - git clone [`my-repo-url-here`]
2. Configure - set any configuration values that need to be unique to the individual (i.e. update a .env file)
3. Press F5 - launch the solution with debugging attached.

Most IDE's have some form of a task runner that can be used to automate the build, execute, and attach steps. Try to leverage these such that the steps can all be run with as few manual steps as possible.

### Pay Attention to the Struggles

Ask the team to surface the areas they spend significant time in that they consider non-value-add activities. For example, do they need to deploy their changes to an environment off their laptop before they can validate if what they did worked. Rather than debugging locally, do they have to do this repetitively to get to a working solution? Does this take several minutes each iteration? Does this block other developers due to the contention on the environment?

The following are a few strategies for surfacing dev experience struggles

- Retrospectives. Create a card that describes the struggle
- Standup Blockers. Call out being blocked not being able to test change and why that cant be done.

### Single IDE Instance

Avoid requiring multiple instances of the IDE to running concurrently to run and debug the solution locally. This will negatively impact the above measure. Additionally, that negative impact is multiplied by each instance required.

- Configuration steps * IDE instances
- Build steps * IDE instances
- Start/Debug steps * IDE instances
- Stop steps * IDE instances
- Run test steps * IDE instances
- Documenting all of the above * IDE instances

### Single Repository

Splitting a solution across multiple repositories can negatively impact the above measures. This can also negatively impact other areas such as Pull Requests, Automated Testing, Continuous Integration, and Continuous Delivery. Similar to the IDE instances, the negative impact is multiplied by the number of repositories.

- clone steps * # of repos
- branching steps * # of repos
- commit steps * # of repos
- CI * # of repos
- Pull request reviews & merges * # of repos

#### Atomic Pull Requests

When the solution is encapsulated within a single repository, it also allows pull requests to represent a change across multiple layers. This is especially helpful when a change requires changes to a shared contract between multiple components. For example, a story requires that an api endpoint is changed. With this strategy the api and web client could be updated with the same pull request. This avoids master being broken temporarily while waiting on dependent pull requests to merge.

[`TODO: Add link to other documented benefits of consolidated repos within source control section`]

### When to Split Into Multiple Repositories

[`TODO: Add link to source control section if it has guidance on this subject`]

(Typically try to have the repository align with the product backlog.)

### Minimize Remote Dependencies for Local Development

The fewer dependencies on components that cannot run a developer's machine translate to fewer steps required to get started. Therefore, fewer dependencies will positively impact the measures above.

The following strategies can be used to reduce these dependencies

#### Use an Emulator

If available, emulators are implementations of technologies that are typically only available in cloud environments. A good example is the [CosmosDB emulator](https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator).

#### Feature Toggle a Mock or Different Technology

Abstract the layer that has the remote dependency behind an interface owned by the solution (not the remote dependency). Create an implementation of that interface using a technology that can be run locally. Lastly, incorporate a feature flag that can be set to control which implementation is used.
