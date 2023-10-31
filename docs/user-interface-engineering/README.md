# User Interface and User Experience Engineering

Also known as _UI/UX_, _Front End Development_, or _Web Development_, user interface and user experience engineering is a broad topic and encompasses many different aspects of modern application development. When a user interface is required, ISE primarily develops a **web application**. Web apps can be built in a variety of ways with many different tools.

## Goal

The goal of the **User Interface** section is to provide guidance on developing web applications. Everyone should begin by reading the [General Guidance](#general-guidance) for a quick introduction to the four main aspects of every web application project. From there, readers are encouraged to dive deeper into each topic, or begin reviewing technical guidance that pertains to their engagement. All UI/UX projects should begin with a detailed design document. Review the [Design Process](#design-process) section for more details, and a template to get started.

Keep in mind that like all software, there is no "right way" to build a user interface application. Leverage and trust your team's or your customer's experience and expertise for the best development experience.

## General Guidance

The state of web platform engineering is fast moving. There is no one-size-fits-all solution. For any team to be successful in building a UI, they need to have an understanding of the higher-level aspects of all UI project.

1. [**Accessibility**](../accessibility/README.md) - ensuring your application is usable and enjoyed by as many people as possible is at the heart of accessibility and inclusive design.
1. [**Usability**](./usability.md) - how effortless should it be for any given user to use the application? Do they need special training or a document to understand how to use it, or will it be intuitive?
1. [**Maintainability**](./maintainability.md) - is the application just a proof of concept to showcase an idea for future work, or will it be an MVP and act as the starting point for a larger, production-ready application? Sometimes you don't need React or any other framework. Sometimes you need React, but not all the bells and whistles from create-react-app. Understanding project maintainability requirements can simplify an engagement’s tooling needs significantly and let folks iterate without headaches.
1. [**Stability**](./stability.md) - what is the cost of adding a dependency? Is it actively stable/updated/maintained? If not, can you afford the tech debt (sometimes the answer can be yes!)? Could you get 90% of the way there without adding another dependency?

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

The benefit of building software applications is that there are truly infinite ways to build something. A team can use the latest shiny tools, or they can utilize the tried-and-tested ones. It is for this reason that focussing completely on the user until a solution is defined is better than obsessing over technology choices. Within ISE, we often reach for tools such as the [React](https://reactjs.org/) framework. React is a great tool when wielded by an experienced team. Otherwise, it can create more hurdles than it is worth. Keep in mind that even if _you_ feel capable with React, the rest of your team and your customer's dev team needs to as well. Some other great options to consider when building a proof-of-concept or minimum-viable-product are:

1. HTML/CSS/JavaScript
   - Back to the basics! Start with a single **index.html**, include a popular CSS framework such as [Bootstrap](https://getbootstrap.com/) using their CDN link, and start prototyping!
   - Rarely will you have to support legacy browsers; thus, you can rely on modern JavaScript language features! No need for build tools or even TypeScript (did you know you can [type check JavaScript](https://www.typescriptlang.org/docs/handbook/intro-to-js-ts.html)).
1. Web Component frameworks
   - Web Components are now standardized in all modern browsers
   - Microsoft has their own, stable & actively-maintained framework, [Fast](https://www.fast.design/)

For more information of choosing the right implementation tool, read the [Recommended Technologies](./recommended-technologies.md) document.

Continue reading the [Trade Study](./../design/design-reviews/trade-studies/README.md) section of this site for more information on completing this step in the design process.

After iterating through multiple trade study documents, this design process can be considered complete! With an agreed upon solution and implementation in mind, it is now time to begin development. A natural continuation of the design process is to get users (or stakeholders) involved as early as possible. Constantly look for design and usability feedback, and utilize this to improve the application as it is being developed.

### Example

> Coming soon!
