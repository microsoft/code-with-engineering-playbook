# User Interface and User Experience Engineering

## Introduction

Also known as _UI/UX_, _Front End Development_, or _Web Development_, user interface and user experience engineering is a broad topic and encompasses many different aspects of modern application development. When a user interface is required, ISE primarily develops a **web application**. Web apps can be built in a variety of ways with many different tools.

## Goal

The goal of the **User Interface** section is to provide guidance on developing web applications. Everyone should begin by reading the [General Guidance](#general-guidance) for a quick introduction to the four main aspects of every web application project. From there, readers are encouraged to dive deeper into each topic, or begin reviewing technical guidance that pertains to their engagement. All UI/UX projects should begin with a detailed design document. Review the [Design Process](#design-process) section for more details, and a template to get started.

Keep in mind that like all software, there is no "right way" to build a user interface application. Leverage and trust your team's or your customer's experience and expertise for the best development experience.

## General Guidance

The state of web platform engineering is fast moving. There is no one-size-fits-all solution. For any team to be successful in building a UI, they need to have an understanding of the higher-level aspects of all UI project.

1. [**Accessibility**](../non-functional-requirements/accessibility.md) - ensuring your application is usable and enjoyed by as many people as possible is at the heart of accessibility and inclusive design.
1. [**Usability**](../non-functional-requirements/usability.md) - how effortless should it be for any given user to use the application? Do they need special training or a document to understand how to use it, or will it be intuitive?
1. [**Maintainability**](../non-functional-requirements/maintainability.md) - is the application just a proof of concept to showcase an idea for future work, or will it be an MVP and act as the starting point for a larger, production-ready application? Sometimes you don't need React or any other framework. Sometimes you need React, but not all the bells and whistles from create-react-app. Understanding project maintainability requirements can simplify an engagement’s tooling needs significantly and let folks iterate without headaches.
1. **Stability** - what is the cost of adding a dependency? Is it actively stable/updated/maintained? If not, can you afford the tech debt (sometimes the answer can be yes!)? Could you get 90% of the way there without adding another dependency?

More information is available for each general guidance section in the corresponding pages.

## Design Process

All user interface applications begin with the design process. The true definition for "the design process" is ever changing and highly opinion based as well. This sections aims to deliver a general overview of a design process _any_ engineering team could conduct when starting an UI application engagement.

> When committing to a UI/UX project, be certain to not over-promise on the web application requirements. Delivering a production-ready application involves a large number of engineering complexities resulting in a very long timeline. Always start with a proof-of-concept or minimum-viable-product first. These projects can easily be achieved within a couple month timeline (and sometimes even less).

The first step in the design process is to understand the problem at hand and outline what the solution should achieve. Commonly referred to as _Desired Outcomes_, the output of this first step should be a generalized list of outcomes that the solution will accomplish. Consider the following example:

A public library has a set of data containing information about its collection. The data stores text, images, and the status of a book (borrowed, available, reserved). The library librarian wants to share this data with its users.

1. As the librarian, I want to notify users before they receive late penalties for overdue books
1. As the librarian, I want to notify users when a book they have reserved becomes available

With the desired outcomes in mind, the next step in the design process is to define user personas. Regardless of the solution for a given problem, understanding the user needs leads to a better understanding of feature development and technological choices. Personas are written as prose-like paragraphs that describe different types of users. Considering the previous example, the various user personas could be:

1. An individual with no disabilities, but is unfamiliar with using software interfaces
1. An individual with no disabilities, and is familiar with using software interfaces
1. An individual with disabilities, and is unfamiliar with using software interfaces (with or without the use of accessibility tooling)
1. An individual with disabilities, but familiar with using software interfaces through the use of accessibility tooling

After defining these personas it is clear that whatever the solution is, it requires a lot of accessibility and user experience design work. Sometimes personas can be simpler than this, but **always include disabled users**. Even when a user set is predefined as a group of individuals without disabilities, there is no guarantee that the user set will remain that way.

After defining the _desired outcomes_ as well as the _personas_, the next step in the design process is to begin conducting [Trade Studies](./../design/design-reviews/trade-studies/README.md) for potential solutions. The first trade study should be high-level and solution oriented. It will utilize the results of previous steps and propose multiple solutions for achieving the desired outcomes with the listed personas in mind. Continuing with the library example, this first trade study may compare various application solutions such as automated emails or text messages, an RSS feed, or an user interface application. There are pros and cons for each solution both from an user experience and a developer experience perspective, but at this stage it is important to focus on the users. After arriving on the best solution, the next trade study can dive into different implementation methods. It is in this subsequent trade studies that developer experience becomes more important.

## Design Ops

Design Ops, short for Design Operations, is a practice that focuses on optimizing and streamlining the design process within an organization. For software engineers, understanding Design Ops can significantly enhance collaboration with design and engineering teams and improve the overall efficiency of product development.

### Key Components of Design Ops

1. **Establishing clear processes and workflows for design tasks:**
   - Utilizing project management tools like [Azure DevOps](https://azure.microsoft.com/en-us/services/devops/), [Jira](https://www.atlassian.com/software/jira), [Trello](https://trello.com/), or [Asana](https://asana.com/) to track design progress and dependencies.

2. **Collaboration Tools**:
   - Leveraging tools like [Figma](https://www.figma.com/), or [Sketch](https://www.sketch.com/) (Mac OS only) for design collaboration.
   - Ensuring seamless handoff between design and development through tools like [Zeplin](https://zeplin.io/) or [InVision](https://www.invisionapp.com/).
   - Validating Product Owner approved designs to be sent for development, and prevent design changes once approved.

3. **Design Systems**:
   - Creating and maintaining a design system that includes reusable components, style guides, and design tokens.
   - Promoting consistency and efficiency by using shared design assets.
   - For most projects within ISE we use [Fluent UI](https://developer.microsoft.com/en-us/fluentui#/controls/webcomponents) to handle most projects, this enables rapid development that allow for web application re-use on non-customer engagements or _white label_ applications.
   - Other Design Systems used by customers include: [Google's Material Design](https://mui.com/material-ui/), 

4. **Documentation**:
   - Documenting design decisions, guidelines, and best practices.
   - Ensuring that all team members have access to up-to-date design documentation.
   - Frameworks like [Storybook.js](https://storybook.js.org/) can create _Swagger like_ documentation for UI components.

5. **Feedback Loops**:
   - Establishing regular design reviews (including product owners and end users) and feedback sessions.
   - Encouraging iterative improvements on designs and UI/UX code implementation based on user and stakeholder feedback.

6. **Metrics and KPIs**:
   - Defining key performance indicators (KPIs) to measure the effectiveness of design processes.
   - Using metrics to identify areas for improvement and track progress over time.
   - __For long-term projects:__ Incorporate _A/B testing_ for better user experiences, and enhancements to the solution.

### Benefits of Design Ops for Software Engineers and Product Owners

- **Improved Collaboration**: Clear processes and tools facilitate better communication and collaboration between designers and developers.
- **Consistency**: Design systems ensure a consistent user experience across different parts of the application.
- **Efficiency**: Streamlined workflows and reusable components reduce redundant work and speed up development.
- **Quality**: Regular feedback loops and documentation help maintain high design standards and improve the final product.

By integrating Design Ops into the development process, software engineers can work more effectively with design teams, leading to better-designed products and a more efficient development cycle.  It also builds trust with a customer to better ideate on what the final outcome of a project could be.

## Establishing a web application's architecture

The benefit of building software applications is that there are truly infinite ways to build something. A team can use the latest shiny tools, or they can utilize the tried-and-tested ones. It is for this reason that focussing completely on the user until a solution is defined is better than obsessing over technology choices. 

When choosing a front-end framework or library, consider the project's complexity, performance, and scalability needs. Evaluate the team's expertise with potential options to ensure efficient development. Assess long-term maintainability and community support. Conduct [Trade Studies](./../design/design-reviews/trade-studies/README.md) to weigh pros and cons, focusing on alignment with project goals and user experience. This thorough analysis helps balance innovation with practicality.


### Some platforms/frameworks to consider when planning a project:

1. HTML/CSS/JavaScript
   - Back to the basics! Start with a single **index.html**, include a popular CSS framework such as [Bootstrap](https://getbootstrap.com/) using their CDN link, and start prototyping!
   - Rarely will you have to support legacy browsers; thus, you can rely on modern JavaScript language features! No need for build tools or even TypeScript (did you know you can [type check JavaScript](https://www.typescriptlang.org/docs/handbook/intro-to-js-ts.html)).
   - For static _vanilla_ websites like this; we still recommend a build system like [Vite](https://vitejs.dev/) to build and manage assets for deployment.
1. React
   - [React](https://reactjs.org/) allows for the creation of reusable UI components, and is used for most projects in ISE.
   - Ideal for projects that require a dynamic and responsive user interface.
   - Works well with a variety of state management libraries like Redux or Context API.
   - Has a massive 3rd party library support.
   - Supports [Fluent UI](https://developer.microsoft.com/en-us/fluentui#/controls/webcomponents) directly.
   - Has [extensive documentation for integrating with Azure on Microsoft Learn](https://learn.microsoft.com/en-us/training/paths/react/).
1. Angular
   - A robust framework for building client-side applications. [Angular](https://angular.dev/) provides a comprehensive solution with built-in features like dependency injection, routing, and state management.
   - Ideal for large-scale applications where maintainability and scalability are crucial.
   - Better Unit Testing support out of the box than React.
   - __Angular has no support for Fluent UI, and has tight integration with Google Cloud Platform.__
1. Blazor
   - A framework for building interactive web UIs using C# instead of JavaScript. [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) allows you to share code between the client and server.
   - Great for teams already familiar with the .NET ecosystem.
   - Fantastic platform where UI elements can be fully hosted and served server-side, adding security.
   - [Supports Fluent UI with its own supported library](https://www.fluentui-blazor.net/).
1. ASP.NET Core
   - A mature framework for building server-side web applications. [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet) supports MVC architecture, making it easier to manage complex applications.
   - Suitable for enterprise-level applications requiring robust security and performance. **(Great for Government web applications where security is paramount)**
1. Next.js
   - A React-based framework that enables server-side rendering and static site generation. [Next.js](https://nextjs.org/) improves performance and SEO.
   - Great for building fast, scalable web applications with a focus on developer experience.
   - Provides built-in support for API routes, making it easier to build full-stack applications.
   - __Recommended by Meta going forward rather than use create-react-app.__
   - Next.js is very heavy in terms of features, and it doesn't allow for re-use in non-Next.js applications like create-react-app, React-Native, or Electron based apps.
1. Svelte
   - [Svelte](https://svelte.dev/) is a modern framework that shifts much of the work to compile time, resulting in highly optimized and performant applications.
   - Ideal for projects where performance is critical and you want to minimize the amount of JavaScript sent to the client.
   - Svelte's syntax is simple and intuitive, making it easy to learn and use.
1. Solid
   - [Solid](https://solidjs.com/) is a declarative JavaScript library for building user interfaces, focusing on fine-grained reactivity.
   - Great for projects that require high performance and efficient updates, as Solid compiles to highly optimized JavaScript.
   - Solid's API is similar to React, making it easier for developers familiar with React to transition.
1. Web Component frameworks
   - Web Components are now standardized in all modern browsers.
   - Microsoft has their own, stable & actively-maintained framework, [Fast](https://www.fast.design/).
1. HTMX
   - [HTMX](https://htmx.org/) allows you to access modern browser features directly from HTML, making it easier to build dynamic web applications without relying heavily on JavaScript.
   - Ideal for projects that require a simpler, more declarative approach to adding interactivity to web pages.
   - Works well with server-side frameworks and can be integrated into existing projects with minimal effort.

### Further information

> For more information of utilizing any of these frameworks/platforms, read the [Recommended Technologies](./recommended-technologies.md) document.
> 
> Continue reading the [Trade Study](./../design/design-reviews/trade-studies/README.md) section of this site for more information on completing this step in the design process.
