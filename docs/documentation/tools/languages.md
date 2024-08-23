# Languages

## Markdown

Markdown is one of the most popular markup languages to add rich formatting, tables and images to your documentation using plain text documents.

Markdown files (.md) can be source-controlled along with your code.

More information:

- [Getting Started](https://www.markdownguide.org/getting-started/)
- [Cheat Sheet](https://www.markdownguide.org/cheat-sheet/)
- [Basic Syntax](https://www.markdownguide.org/basic-syntax/)
- [Extended Syntax](https://www.markdownguide.org/extended-syntax/)
- [Wiki Markdown Syntax](https://learn.microsoft.com/en-us/azure/devops/project/wiki/wiki-markdown-guidance?view=azure-devops)

Tools:

- [Markdown and Visual Studio Code](https://code.visualstudio.com/docs/languages/markdown)
- [How to automate simple checks](./automation.md)

## Mermaid

Mermaid lets you create diagrams using text definitions that can later be rendered with a diagramming and charting tool.

Mermaid files (.mmd) can be source-controlled along with your code. It's also recommended to include image files (.png) with the rendered diagrams under source control. Your markdown files should link the image files, so they can be read without the need of a Mermaid rendering tool (e.g., during Pull Request review).

### Example Mermaid Diagram

This is an example of a Mermaid flowchart diagram written as code.

```mermaid
graph LR
    A[Diagram Idea] -->|Write mermaid code| B(mermaid.mmd file)
    B -->|Add to source control| C{Code repo}
    B -->|Export as .png| G(.png file of diagram)
    G -->|Add to source control| C
```

This is an example of how it can be rendered as an image.

![Example mermaid diagram](./images/example-mermaid-diagram.png)

More information:

- [About Mermaid](https://mermaid-js.github.io/mermaid/#/)
- [Diagram syntax](https://mermaid-js.github.io/mermaid/#/./n00b-syntaxReference)

Tools:

- [Mermaid Live Editor](https://mermaid.live)
- [Markdown Preview Mermaid Support for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=bierner.markdown-mermaid)
