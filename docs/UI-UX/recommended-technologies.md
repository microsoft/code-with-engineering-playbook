# Recommended Technologies

The purpose of this page is to review the commonly selected technology options when developing user interface applications. To reiterate from the general guidance section:

> Keep in mind that like all software, there is no "right way" to build a user interface application. Leverage and trust your team's or your customer's experience and expertise for the best development experience.

Additionally, while some of these technologies are presented as alternate options, many can be combined together. For example, you can use React in a basic HTML/CSS/JS workflow by inline-importing React along with Babel. See the [Add React to a Website](https://reactjs.org/docs/add-react-to-a-website.html) for more details. Similarly, any [Fast](https://www.fast.design/) web component can be [integrated into any existing React application](https://www.fast.design/docs/integrations/react). And of course, every JavaScript technology can also be used with TypeScript!

## TypeScript

> TypeScript is JavaScript with syntax for types. TypeScript is a strongly typed programming language that builds on JavaScript, giving you better tooling at any scale.
> [typescriptlang.org](https://www.typescriptlang.org/)

TypeScript is __highly recommended__ for all new web application projects. The stability it provides for teams is unmatched, and can make it easier for folks with C# backgrounds to work with web technologies.

There are many ways to integrate TypeScript into a web application. The easiest way to get started is by reviewing the [TypeScript Tooling in 5 Minutes](https://www.typescriptlang.org/docs/handbook/typescript-tooling-in-5-minutes.html) guide from the official TypeScript docs. The other sections on this page contain information regarding integration with TypeScript.


## Guidance on types and interfaces

In TypeScript, both `type` and `interface` can be used to define the shape of an object. However, it is generally recommended to prefer `type` over `interface` for most use cases due to its simplicity and flexibility.  It also prevents inheritance when using a `type` which can badly scale overtime unless explicitly declared.

### Example

Using `type`:

```typescript
type User = {
    name: string;
    age: number;
};
```

Using `interface`:

```typescript
interface User {
    name: string;
    age: number;
}
```

While both achieve the same result, `type` can also be used for other TypeScript features like union types, which makes it more versatile.

For more details, refer to the [TypeScript Handbook](https://www.typescriptlang.org/docs/handbook/2/everyday-types.html).

## Bootstrapping Web Projects

There are many different ways to bootstrap web applications. Two great tool sets to use are [create-react-app](https://create-react-app.dev/) and [vite](https://vitejs.dev/guide).

### Vite

[Vite](https://vitejs.dev/) is a modern build tool that provides a fast and optimized development experience for engineers. It leverages native ES modules in the browser to deliver lightning-fast hot module replacement (HMR) and instant server start. [Vite](https://vitejs.dev/) also offers a highly optimized build process using [Rollup](https://rollupjs.org/introduction/), ensuring efficient and performant production builds. By simplifying the setup and configuration, [Vite](https://vitejs.dev/) allows developers to focus more on writing code and less on tooling, making it an excellent choice for modern web development. For more details, visit the [Vite project](https://vitejs.dev/) and [Vite GitHub repository](https://github.com/vitejs/vite).

#### Documentation & Recommended Resources

- [Vite Documentation](https://vitejs.dev/guide/)
- [Vite GitHub Repository](https://github.com/vitejs/vite)
- [Vite Rollup Plugin](https://vitejs.dev/guide/api-plugin.html)
- [Vite HMR](https://vitejs.dev/guide/features.html#hot-module-replacement)
- [Vite Configuration](https://vitejs.dev/config/)
- [Vite Plugins](https://vitejs.dev/plugins/)
- [Vite Troubleshooting](https://vitejs.dev/guide/troubleshooting.html)

From [Scaffolding your First Vite Project](https://vitejs.dev/guide/#scaffolding-your-first-vite-project)

```sh
# npm 6.x
npm init vite@latest my-app --template react-ts

# npm 7.x
npm init vite@latest my-app -- --template react-ts
```





## React

React is a framework developed and maintained by Meta (Formerly Facebook). React is used throughout Microsoft's product stack and has a vast open source community.

### Quick note on create-react-app

> __create-react-app is deprecated as of January 2023 and should be avoided for new projects.__ It is recommended to use more modern tools like [Vite](#vite) for better performance and flexibility. For more details, refer to the [official React blog](https://reactjs.org/blog/2022/12/08/react-v18-update.html) and [Vite documentation](https://vitejs.dev/guide/why.html).


From [Adding TypeScript](https://create-react-app.dev/docs/adding-typescript/)

```sh
npx create-react-app my-app --template typescript
```

### Documentation & Recommended Resources

One can expect to find a multitude of guides, answers, and posts on how to work with React; don't take everything at face value. The best place to review React concepts is the React documentation. From there, you can review articles from various sources such as [React Community Articles](https://reactjs.org/community/articles.html), [Kent C Dodd's Blog](https://kentcdodds.com/blog?q=react), [CSS Tricks Articles](https://css-tricks.com/?s=react), and [Awesome React](https://github.com/enaqx/awesome-react).

The React API has changed dramatically over time. Older resources may contain solutions or patterns that have since been changed and improved upon. Modern React development uses the [React Hooks](https://reactjs.org/docs/hooks-intro.html) pattern. Rarely will you have to implement something using [React Class](https://reactjs.org/docs/react-component.html) pattern. If you're reading an article/answer/docs that instruct you to use the class pattern you may be looking at an out-of-date resource.

