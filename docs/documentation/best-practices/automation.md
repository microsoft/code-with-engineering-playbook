# Replacing Documentation with Automation

You can document how to set up your dev machine with the right version of the framework required to run the code, which extensions are useful to develop the application with your editor, or how to configure your editor to launch and debug the application. If it is possible, a better solution is to provide the means to automate tool installs, application startup, etc., instead.

Prefer automation over generated setup prose when the reader needs a repeatable result. AI-assisted instructions can help draft context, explain trade-offs, or summarize what a script does, but they should not replace executable setup, validation, or recovery steps that the team can test.

Automation is usually the better artifact when:

- The same commands must run on every developer machine, build agent, or test environment.
- The instructions include version pinning, environment variables, credentials setup, generated files, or ordered prerequisites.
- A failure should stop early with a clear error instead of relying on a reader to notice a missed step.
- The process must stay current as dependencies, toolchains, containers, or cloud resources change.

Use documentation to explain intent, boundaries, troubleshooting, and when not to run the automation. Keep generated prose source-backed by the script, task, container definition, or pipeline it describes.

Some examples are provided below:

## Dev Containers in Visual Studio Code

The [Visual Studio Code Remote - Containers extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers) lets you use a Docker container as a full-featured development environment. It allows you to open any folder inside (or mounted into) a container and take advantage of Visual Studio Code's full feature set.

Additional information: [Developing inside a Container](https://code.visualstudio.com/docs/remote/containers).

## Launch Configurations and Tasks in Visual Studio Code

[Launch configurations](https://code.visualstudio.com/Docs/editor/debugging#_launch-configurations) allows you to configure and save debugging setup details.

[Tasks](https://code.visualstudio.com/Docs/editor/tasks) can be configured to run scripts and start processes so that many of these existing tools can be used from within VS Code without having to enter a command line or write new code.
