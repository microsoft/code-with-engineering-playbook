# Code Completion

Code completion is a feature used in live programming that actively reads the user's current code in context to present code suggestions in real-time. The code suggestions may be intended to complete the code for efficiency or improve the code quality.

## Code Completion Tools

### 1. GitHub Co-Pilot: A Code Completion Tool

![GitHub Code Pilot](images/github-copilot.png)

Benefits:

- Autocompletion of verbose boilerplate code
  - For example, constructors, getters, setters, and other common code
  - Writing mocks for unit tests
- Auto-generated code suggestions based on:
  - function names
  - descriptive comments
  - existing code
- Easy to get started, and works automatically
- Works with many common languages including Python, JavaScript, TypeScript, Ruby, Go, C#, or C++.

Downsides:

- Experience is limited in offline scenarios.

Usage:

Install the VS Code Extension, and log in to your Microsoft GitHub Account.

Sign Up:

[GitHub-CoPilot - Home Page](https://aka.ms/github/copilot)

Docs:

[GitHub-CoPilot - GitHub - Docs](https://docs.github.com/en/copilot)

### 2. VS Code's Intellisense

![Visual Studio Code - Intellisense](images/VSCode.png)

Benefits:

- Native feature of VS Code
- Works with many common languages out of the box (JavaScript, TypeScript, JSON, HTML, CSS, SCSS, and Less)
- Has a marketplace for additional code completion extensions needed for other languages like Python, C/C++, C#, Java, Go, plus more.
- Works offline

Downsides:

- Can conflict with GitHub CoPilot if both are enabled.

Usage:

Install the VS Code. Install additional extensions for additional language support.

Docs:

[VSCode Intellisense - Docs](https://code.visualstudio.com/docs/editor/intellisense)
