# Recommended Technologies

The purpose of this page is to review the commonly selected technology options when developing user interface applications. To reiterate from the general guidance section:

> Keep in mind that like all software, there is no "right way" to build a user interface application. Leverage and trust your team's or your customer's experience and expertise for the best development experience.

Additionally, while some of these technologies are presented as alternate options, many can be combined together. For example, you can use React in a basic HTML/CSS/JS workflow by inline-importing React along with Babel. See the [Add React to a Website](https://reactjs.org/docs/add-react-to-a-website.html) for more details. Similarly, any [Fast](https://www.fast.design/) web component can be [integrated into any existing React application](https://fast.design/docs/integrations#react). And of course, every JavaScript technology can also be used with TypeScript!

## TypeScript

> TypeScript is JavaScript with syntax for types. TypeScript is a strongly typed programming language that builds on JavaScript, giving you better tooling at any scale.
> [typescriptlang.org](https://www.typescriptlang.org/)

TypeScript is highly recommended for all new web application projects. The stability it provides for teams is unmatched, and can make it easier for folks with C# backgrounds to work with web technologies.

There are many ways to integrate TypeScript into a web application. The easiest way to get started is by reviewing the [TypeScript Tooling in 5 Minutes](https://www.typescriptlang.org/docs/handbook/typescript-tooling-in-5-minutes.html) guide from the official TypeScript docs. The other sections on this page contain information regarding integration with TypeScript.

## React

React is a framework developed and maintained by Facebook. React is used throughout Microsoft and has a vast open source community.

### Documentation & Recommended Resources

One can expect to find a multitude of guides, answers, and posts on how to work with React; don't take everything at face value. The best place to review React concepts is the React documentation. From there, you can review articles from various sources such as [React Community Articles](https://reactjs.org/community/articles.html), [Kent C Dodd's Blog](https://kentcdodds.com/blog?q=react), [CSS Tricks Articles](https://css-tricks.com/?s=react), and [Awesome React](https://github.com/enaqx/awesome-react).

The React API has changed dramatically over time. Older resources may contain solutions or patterns that have since been changed and improved upon. Modern React development uses the [React Hooks](https://reactjs.org/docs/hooks-intro.html) pattern. Rarely will you have to implement something using [React Class](https://reactjs.org/docs/react-component.html) pattern. If you're reading an article/answer/docs that instruct you to use the class pattern you may be looking at an out-of-date resource.

### Bootstrapping

There are many different ways to bootstrap a React application. Two great tool sets to use are [create-react-app](https://create-react-app.dev/) and [vite](https://vitejs.dev/guide).

#### create-react-app

From [Adding TypeScript](https://create-react-app.dev/docs/adding-typescript/)

```sh
npx create-react-app my-app --template typescript
```

#### Vite

From [Scaffolding your First Vite Project](https://vitejs.dev/guide/#scaffolding-your-first-vite-project)

```sh
# npm 6.x
npm init vite@latest my-app --template react-ts

# npm 7.x
npm init vite@latest my-app -- --template react-ts
```
