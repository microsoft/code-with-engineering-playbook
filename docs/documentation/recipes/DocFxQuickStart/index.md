# CSE Documentation

This is the landing page of the CSE Documentation website. This is the page to introduce everything on the website.

You can add specific links that are important to provide direct access.

> [!TIP]
> Try not to duplicate the links on the top of the page, unless it really makes sense.

To get started with the setup of this website, read the getting started document with the title [Using DocFx and Companion Tools](./docs/getting-started/README.md).

## Style of this website

This documentation website is currently setup with the basics of the [DocFx Material](https://ovasquez.github.io/docfx-material/) style added with the Microsoft logo. The combination can be found in **/templates/cse**.

## DocFx Markdown extra's

There are some extra DocFx annotations in Quotes you can use to have information jump out on a page. Using specific syntax inside a block quote to indicate the meaning.

```markdown
> [!NOTE]
> <note content>

> [!TIP]
> <tip content>

> [!WARNING]
> <warning content>

> [!IMPORTANT]
> <important content>

> [!CAUTION]
> <caution content>
```

This will result in:
> [!NOTE]
> note content
> [!TIP]
> tip content
> [!WARNING]
> warning content
> [!IMPORTANT]
> important content
> [!CAUTION]
> caution content
