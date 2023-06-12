# Copilots

There are a number of AI tools that can improve the developer experience. This article will discuss tooling that is available as well as advice on when it might be appropriate to use such tooling.

## GitHub Copilot

The current version of GitHub Copilot can provide code completion in many popular IDEs. For instance, the [VS Code extension](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) that can be installed from the VS Code Marketplace. It requires a GitHub account to use. For more information about what IDEs are supported, what languages are supported, cost, features, etc., please checkout out the information on [Copilot](https://github.com/features/copilot) and [Copilot for Business](https://resources.github.com/copilot-for-business/).

Some example use-cases for GitHub Copilot include:

- **Write Documentation**. For example, the above paragraph was written using Copilot.

- **Write Unit Tests**. Given that setup and assertions are often consistent across unit tests, Copilot tends to be very accurate.

- **Unblock**. It is often hard start writing when staring at a blank page, Copilot can fill the space with something that may or may not be what you ultimately want to do, but it can help get you in the right head space.

If you want Copilot to write something useful for you, try writing a comment that describes what your code is going to do - it can often take it from there.

## GitHub Copilot Labs

Copilot has a [GitHub Copilot Labs extension](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot-labs) that offers additional features that are not yet ready for prime-time. For VS Code, you can install it from the VS Code Marketplace. These features include:

- **Explain**. Copilot can explain what the code is doing in natural language.

- **Translate**. Copilot can translate code from one language to another.

- **Brushes**. You can select code that Copilot then modifies inline based on a "brush" you select, for example, to make the code more readable, fix bugs, improve debugging, document, etc.

- **Generate Tests**. Copilot can generate unit tests for your code. Though currently this is limited to JavaScript and TypeScript.

## GitHub Copilot X

The next version of Copilot offers a number of new use-cases beyond code completion. These include:

- **Chat**. Rather than just providing code completion, Copilot will be able to have a conversation with you about what you want to do. It has context about the code you are working on and can provide suggestions based on that context. Beyond just writing code, consider using chat to:

  - **Build SQL Indexes**. Given a query, ChatGPT can generate a SQL index that will improve the performance of the query.

  - **Write Regular Expressions**. These are notoriously difficult to write, but ChatGPT can generate them for you if you give some sample input and describe what you want to extract.

  - **Improve and Validate**. If you are unsure of the implications of writing code a particular way, you can ask questions about it. For instance, you might ask if there is a way to write the code that is more performant or uses less memory. Once it gives you an opinion, you can ask it to provide documentation validating that assertion.

- **Explain**. Copilot can explain what the code is doing in natural language.

- **Write Code**. Given prompting by the developer it can write code that you can one-click deploy into existing or new files.

- **Debug**. Copilot can analyze your code and propose solutions to fix bugs.

It can do most of what Labs can do with "brushes" as "topics", but whereas Labs changes the code in your file, the chat functionality just shows what it would change in the window. However, there is also an "inline mode" for GitHub Copilot Chat that allows you to make changes to your code inline which does not have this same limitation.

## ChatGPT / Bing Chat

For coding, generic AI chat tools such as ChatGPT and Bing Chat are less useful, but they still have their place. GitHub Copilot will only answer "questions about coding" and it's interpretation of that rule can be a little restrictive. Some cases for using ChatGPT or Bing Chat include:

- **Write Documentation**. Copilot can write documentation, but using ChatGPT or Bing Chat, you can expand your documentation to include business information, use-cases, additional context, etc.

- **Change Perspective**. ChatGPT can impersonate a persona or even a system and answer questions from that perspective. For example, you can ask it to explain what a particular piece of code does from the perspective of a user. You might have ChatGPT imagine it is a database administrator and ask it to explain how to improve a particular query.

When using Bing Chat, experiment with modes, sometimes changing to Creative Mode can give the results you need.

## Prompt Engineering

Chat AI tools are only as good as the prompts you give them. The quality and appropriateness of the output can vary greatly depending on the prompt. In addition, many of these tools restrict the number of prompts you can send in a given amount of time. To learn more about prompt engineering, you might review some open source documentation [here](https://github.com/brexhq/prompt-engineering).

## Considerations

It is important when using AI tools to understand how the data (including private or commercial code) might be used by the system. Read more about how GitHub Copilot handles your data and code [here](https://resources.github.com/copilot-for-business/).
