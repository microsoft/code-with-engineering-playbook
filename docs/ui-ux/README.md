# User Interface and User Experience Engineering

Also known as _UI/UX_, _Front End Development_, or _Web Development_, user interface and user experience engineering is a broad topic and encompasses many different aspects of modern application development. When a user interface is required, CSE primarily develops a **web application**. Web apps can be built in a variety of ways with many different tools.

## Goal

The goal of the **User Interface** section is to provide guidance on developing web applications. Everyone should begin by reading the [General Guidance](#general-guidance) for a quick introduction to the four main aspects of every web application project. From there, readers are encouraged to dive deeper into each topic, or begin reviewing technical guidance that pertains to their engagement. All UI/UX projects should begin with a detailed design document. Review the [Design Document](#design-document) section for more details, and a template to get started.

Keep in mind that like all software, there is no "right way" to build a user interface application. Leverage and trust your team's or your customer's experience and expertise for the best development experience.

## General Guidance

The state of web platform engineering is fast moving. There is no one-size-fits-all solution. For any team to be successful in building a UI, they need to have an understanding of the higher-level aspects of all UI project.

1. [**Accessibility**](./accessibility.md) - applications must be accessible for everyone. Exclusive design may work in the immediate time frame but will create major problems in the future. Accessibility is not complicated when included from the beginning. Furthermore, at Microsoft **accessibility is never optional**.
1. [**Usability**](./usability.md) - how effortless should it be for any given user to use the application? Do they need special training or a document to understand how to use it, or will it be intuitive?
1. [**Maintainability**](./maintainability.md) - is the application just a proof of concept to showcase an idea for future work, or will it be an MVP and act as the starting point for a larger, production-ready application? Sometimes you don't need React or any other framework. Sometimes you need React, but not all the bells and whistles from create-react-app. Understanding project maintainability requirements can simplify an engagement’s tooling needs significantly and let folks iterate without headaches.
1. [**Stability**](./stability.md) - what is the cost of adding a dependency? Is it actively stable/updated/maintained? If not, can you afford the tech debt (sometimes the answer can be yes!)? Could you get 90% of the way there without adding another dependency?

More information is available for each general guidance section in the corresponding pages.

## Design Document

When beginning a UI/UX project, the first step is to produce a detailed design document that outlines the prospective solution. Design documents are meant to be a starting point, and unlike a gameplan document, they can change throughout an engagement.

> Be certain to not over-promise on UI/UX requirements in the gameplan document. CSE teams should **not** agree to delivering production-ready user interface applications. The engineering complexities and requirements are far too much for an engagement. Committing to proof-of-concept or minimum-valuable-product applications is significantly more achievable within the timeline of a single (or even multiple) engagements.

User interface application design documents cover a variety of aspects. Before detailling the technical implementation requirements, the design document should focus on the intended user and the proposed solutions. Commonly referred to as "user stories", this section should contain prose-like paragraphs describing a literal user of the application attempting to do something with it. Generally, this section appears as a list with the personas and stories listed together. Personas are generally used more than once for each of the applications intended user paths. Stories should specific to the persona.

For example, here are some user stories and personas for an application for searching through a data set of images tagged with common descriptors.

1. Persona: A user that can see and use a mouse without assistance.

   Story: I start by accessing the application in my browser. I log in using my corporate account, and then see a search box and a list of images. I start typing "dog" into the search box. The images begin shuffling around, with ones tagged "dog" appearing at the top.

1. Persona: A user that requires an audio-aide for browsing the web since they cannot see.

   Story: I start by accessing the application in my browser and with my audio-aide enabled. I am immediately focussed on the authentication form and enter my corporate information. Once I land on the main page, I'm focussed on the search box. I tab to the image list and use my aide to listen to the first 10 images displayed. I tab back to the search box and type "dog". I then tab to the image list against and listen to the list of images, now all returning some form of my search "dog".

User stories help you and your team understand application and feature requirements. In application design, the user drives the features. By completely understanding your user, you in turn can completely understand what you need to build.

Following the user stories, the design document should detail the accessibility requirements of the application. **Accessibility is never optional**. No matter who you determine your users are, Microsoft has made a public commitment to always produce accessible appliations. For more information visit the official [Microsoft accessibility site](https://www.microsoft.com/en-us/accessibility).

> If you haven't already, download the [Accessibility Insights](https://accessibilityinsights.io/) browser tool. You can use this, in combination with other accessibility-related tools, to easily check your application for accessibility issues.

Accessibility requirements vary from project-to-project based on your intended user base. Aside from the default level of accessibility, this section should contain details about any other aspects you must consider during development. Could the application be used by someone who cannot see? What about someone with color blindness? What about someone who cannot use a mouse? If your application has an audio aspect, what about users that cannot hear?

> Did you know that approximately 4.5% of the worlds population is color blind[*](https://www.colorblindguide.com/post/colorblind-people-population-live-counter)? That is over 355 Million people! Accessible design is a requirement for all user interface applications.

After listing accessibility requirements, the last section of the design document is technical considerations. This section outlines any and all implementation options your team wants to consider. Within CSE, we often reach for tools such as the [React] framework. React is a great tool when wielded by an experienced team. Otherwise, it can create more hurdles than it is worth. Keep in mind that even if _you_ feel capable with React, the rest of your team and your customer's dev team needs to as well. Some other great options to consider when building a proof-of-concept or minimum-valuable-product are:

1. HTML/CSS/JavaScript
   - Back to the basics! Start with a single **index.html**, include a popular CSS framework such as [Bootstrap](https://getbootstrap.com/) using their CDN link, and start prototyping!
   - Rarely will you have to support legacy browsers; thus, you can rely on modern JavaScript language features! No need for build tools or even TypeScript (did you know you can [type check JavaScript](https://www.typescriptlang.org/docs/handbook/intro-to-js-ts.html)).
1. Web Component frameworks
   - Web Components are now standardized in all modern browsers
   - Microsoft has their own, stable & actively-maintained framework, [Fast](https://fast.design)

For more information of choosing the right implementation tool, read the [Recommended Technologies](./recommended-technologies.md) document.

### Template

```md
# {User Interface Application Solution Title}

{General Description; 3-5 sentences.}

## User Stories

### Personas

#### {Persona Title 1}

#### {Persona Title 2}

### Stories

#### {Story Title 1}

#### {Story Title 2}

## Accessibility Requirements

### {Requirement 1}

### {Requirement 2}

## Technical Considerations

### {Option 1}

#### Pros

#### Cons

### {Option 2}

#### Pros

#### Cons
```

#### Example

> Coming soon!
