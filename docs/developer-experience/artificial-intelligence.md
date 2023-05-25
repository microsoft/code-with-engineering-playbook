# Artificial Intelligence

There are a number of AI tools that can improve the developer experience. This article will discuss tooling that is available as well as advice on when it might be appropriate to use such tooling.

## GitHub Copilot

The current version of GitHub Copilot can provide code completion in Visual Studio Code. It is a VS Code extension that can be installed from the VS Code Marketplace. It is currently in beta and requires a GitHub account to use. It is free to use during the beta period. It is currently available for VS Code only, but there are plans to support other IDEs in the future. It is currently available for the following languages: JavaScript, TypeScript, Ruby, Go, Python, C#, C++, and Java. You can find more information about GitHub Copilot [here](https://copilot.github.com/).

Developers on our team have found the following use-cases for GitHub Copilot:

- __Write Documentation__. For example, the above paragraph was written using Copilot.
- __Write Unit Tests__. Given that setup and assertions are often consistent across unit tests, Copilot tends to be very accurate.
- __Unblock__. It is often hard start writing when staring at a blank page, Copilot can fill the space with something that may or may not be what you ultimately want to do, but it can help get you in the right headspace.

If you want Copilot to write something useful for you, try writing a comment that describes what your code is going to do - it can often take it from there.

## GitHub Copilot Labs

Copilot has extension that offers additional features that are not yet ready for prime-time. You can install it from the VS Code Marketplace. These features include:

- __Explain__. Copilot can explain what the code is doing in natural language.
- __Translate__. Copilot can translate code from one language to another.
- __Brushes__. You can select code that Copilot then modifies inline based on a "brush" you select, for example, to make the code more readable, fix bugs, improve debugging, document, etc.
- __Generate Tests__. Copilot can generate unit tests for your code. Though currently this is limited to JavaScript and TypeScript.

## GitHub Copilot X

This extention for Copilot is currently in technical preview. It will enable the following additional features:

- __Chat__. Rather than just providing code completion, Copilot will be able to have a conversation with you about what you want to do. It has context about the code you are working on and can provide suggestions based on that context.
- __Explain__. Copilot can explain what the code is doing in natural language.
- __Write Code__. Given prompting by the developer it can write code that you can one-click deploy into existing or new files.
- __Debug__. Copilot can analyze your code and propose solutions to fix bugs.

It can do most of what Labs can do with "brushes" as "topics", but whereas Labs changes the code in your file, the chat functionality just shows what it would change in the window. However, there is also an "inline mode" for GitHub Copilot Chat that allows you to make changes to your code inline which does not have this same limitation.

You must sign-up for the preview [here](https://github.com/features/preview/copilot-x). Once you are accepted, you will be able to install the extension from the VS Code Marketplace. You may require the Insiders build of VS Code.

## ChatGPT / Bing Chat

Prior to GitHub Copilot X chat availability, we used ChatGPT and Bing Chat to provide similar functionality. We found the generation of code using ChatGPT to be most valuable for these scenarios:

- __Write Code__. When using a library or framework that you are not familiar with, ChatGPT can help you get started by generating code.
- __Build SQL Indexes__. Given a query, ChatGPT can generate a SQL index that will improve the performance of the query.
- __Write Regular Expressions__. These are notoriously difficult to write, but ChatGPT can generate them for you if you give some sample input and describe what you want to extract.
- __Improve and Validate__. If you are unsure of the implications of writing code a particular way, you can ask ChatGPT questions about it. For instance, you might ask if there is a way to write the code that is more performant or uses less memory. Once it gives you an opinion, you can ask it to provide documentation validating that assertion.
- __Change Perspective__. ChatGPT can impersonate a persona or even a system and answer questions from that perspective. For example, you can ask it to explain what a particular piece of code does from the perspective of a user. You might have ChatGPT imagine it is a database adminstrator and ask it to explain how to improve a particular query.

When using Bing Chat, we found much better results using Creative Mode.

## Prompt Engineering

Prompt Engineering is a cutting edge subject area focused on prompting strategies designed to derive the most value from an AI response.

Most LLM services such as GPT-4 or Bing Chat have a limited number of prompts a user can send to it in a given amount of time. Even outside of that scenario, we want to get the most useful information as quickly as possible.

This is one open source example of documentation around prompt engineering, and should be seen as a jumping off point for further investigation. [Link](https://github.com/brexhq/prompt-engineering)

## Considerations

It is important when using AI tools to understand how the data (including private or commercial code) might be used by the system. GitHub Copilot provides guarantees on how data will be used that should align with customer expectations, however, we should always seek a customer's consent. More information on the privacy can be found [here](https://resources.github.com/copilot-for-business/).

ChatGPT allows data entered into the prompts to be used for training, so private or commercial code should not be copied into that system.