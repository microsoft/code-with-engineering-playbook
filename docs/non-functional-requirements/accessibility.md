# Accessibility

Accessibility is a critical component of any successful project and ensures the solutions we build are usable and enjoyed by as many people as possible. While meeting accessibility compliance standards is required, accessibility is much broader than compliance alone. Accessibility is about using techniques like inclusive design to infuse different perspectives and the full range of human diversity into the products we build. By incorporating accessibility into your project from the initial envisioning through MVP and beyond, you are promoting a more inclusive environment for your team and helping close the "Disability Divide" that exists for many people living with disabilities.

## Getting Started

If you are new to accessibility or are looking for an overview of accessibility fundamentals, Microsoft Learn offers a great training course that covers a broad range of topics from creating accessible content in Office to designing accessibility features in your own apps. You can learn more about the course or get started at [Microsoft Learn: Accessibility Fundamentals](https://learn.microsoft.com/en-us/learn/paths/accessibility-fundamentals/).

## Inclusive Design

Inclusive design is a methodology that embraces the full range of human diversity as a resource to help build better products and services. Inclusive design compliments accessibility going beyond accessibility compliance standards to ensure products are usable and enjoyed by all people. By leveraging the inclusive design methodology early in a project, you can expect a more inclusive and better solution for everyone. The [Microsoft Inclusive Design](https://www.microsoft.com/design/inclusive/) website offers a variety of resources for incorporating inclusive design in your projects including inclusive design activities that can be used in envisioning and architecture design sessions.

The Microsoft Inclusive Design methodology includes the following principles:

### Recognize Exclusion

Designing for inclusivity not only opens up our products and services to more people, it also reflects how people really are. All humans grow and adapt to the world around them and we want our designs to reflect that.

### Solve for One, Extend to Many

Everyone has abilities, and limits to those abilities. Designing for people with permanent disabilities actually results in designs that benefit people universally. Constraints are a beautiful thing.

### Learn from Diversity

Human beings are the real experts in adapting to diversity. Inclusive design puts people in the center from the very start of the process, and those fresh, diverse perspectives are the key to true insight.

## Tools

### Accessibility Insights

[Accessibility Insights](https://accessibilityinsights.io/) is a free, open-source solution for identifying accessibility issues in Windows, Android, and web applications. Accessibility Insights can identify a broad range of accessibility issues including problems with missing image alt tags, heading organization, tab order, color contrast, and many more. In addition, you can use Accessibility Insights to simulate color blindness to ensure your user interface is accessible to those that experience some form of color blindness. You can download Accessibility Insights here: [https://accessibilityinsights.io/downloads/](https://accessibilityinsights.io/downloads/)

### Accessibility Linter

[Deque Systems](https://www.deque.com/) are web accessibility experts that provide accessibility training and tools to many organizations including Microsoft. One of the many tools offered by Deque is the [axe Accessibility Linter for VS Code](https://marketplace.visualstudio.com/items?itemName=deque-systems.vscode-axe-linter). This VS Code extension use the [axe-core rules](https://github.com/dequelabs/axe-core/blob/develop/doc/rule-descriptions.md#:~:text=WCAG%202.0%20Level%20A%20%26%20AA%20Rules%20,%20%20%20%2011%20more%20rows%20?msclkid=604d209ed16411eca3c4c2af8c378e89) engine to identify accessibility issues in HTML, Angular, React, Markdown, and Vue. Using an accessibility linter can help ensure accessibility issues get addressed early in the development lifecycle.

## Practices

### Accessibility Testing

Accessibility testing is a specialized subset of software testing and includes automated tools and manual testing processes that vary from project to project. In addition to tools like Accessibility Insights discussed earlier, there are many other solutions for accessibility testing. The W3C provides a comprehensive list of evaluation and testing tools on their website at [https://www.w3.org/WAI/ER/tools/](https://www.w3.org/WAI/ER/tools/).

If you are looking to add automated testing to your Azure Pipelines, you may want to consider the [Accessibility Testing extension](https://marketplace.visualstudio.com/items?itemName=DrewLewis.Accessibility) built by Drew Lewis, a former Microsoft employee.

It's important to keep in mind that automated tooling alone is not enough - make sure to augment your automated tests with manual ones. Accessibility Insights (linked above) can guide users through some manual testing steps.

### Code and Documentation Basics

Before you get to testing, you can make some small changes in how you write code and documentation.

- Document! Beyond text documentation, this also means code comments, clear variable and file naming, and pipeline or script outputs that clearly report success or failure and give details.
- Avoid small case for variable and file names, hashtags, neologisms, etc. Use camelCase, snake_case, or other methods of creating separation between words.
- Introduce abbreviations by spelling the full term out, then the abbreviation in parentheses.
- Use headers effectively to break up content by topic. Don't use more than one h1 per page, and don't skip levels (e.g. use an h3 directly under an h1). Avoid using formatting to make something *look* like a header when it's not.
- Use descriptive link text. Avoid attaching a link to phrases like "Read more" and ensure that the text directly states what it links to. Link text should be able to stand on its own.
- When including images or diagrams, add alt text. This should never just be "Image" or "Diagram" (or similar). In your description, highlight the purpose of the image or diagram in the page and what it is intended to convey.
- Prefer tabs to spaces when possible. This allows users to default to their preferred tab width, so users with a range of vision can all take in code easily.

## Resources

* [Microsoft Accessibility Technology & Tools](https://www.microsoft.com/accessibility)
* [Web Content Accessibility Guidelines (WCAG)](https://www.w3.org/TR/WCAG20/#intro)
* [Accessibility Guidelines and Requirements | Microsoft Style Guide](https://learn.microsoft.com/en-us/style-guide/accessibility/accessibility-guidelines-requirements)
* [Google Developer Style Guide: Write Accessible Documentation](https://developers.google.com/style/accessibility)

