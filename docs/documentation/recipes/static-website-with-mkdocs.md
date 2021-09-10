# How to create a static website for your documentation based on mkdocs and mkdocs-material

MKDocs is a tool built to create static websites from raw markdown files. Other alternatives include [Sphinx](https://www.sphinx-doc.org/en/master/) and [Jekyll](https://jekyllrb.com/). 

We found MKDocs to be a good choice since:

1. It's easy to set up and looks great even with the vanilla version.
2. It works well with markdown, which is what we already have in the playbook.
3. It uses a Python stack which is friendly to many contributors of this playbook.

For comparison, Sphinx mainly generates docs from restructured-text (rst) format, and Jekyll is written in Ruby.

To setup an mkdocs website, the main assets needed are:

1. An ```mkdocs.yaml``` file, similar to the one we have [in our repo](https://github.com/microsoft/code-with-engineering-playbook/blob/main/mkdocs.yml). This is the configuration file that defines the appearance of the website, the navigation, the plugins used and more.
2. A Github action for automatically generating the website (e.g. on every commit to main), similar to [this one from our repo](https://github.com/microsoft/code-with-engineering-playbook/blob/main/.github/workflows/mkdocs.yml).
3. A list of plugins used during the build phase of the website. We specified ours [here](https://github.com/microsoft/code-with-engineering-playbook/blob/main/requirements-docs.txt).

Setting up locally is also very easy (see some documentation [here](https://www.mkdocs.org/getting-started/)). For publishing the website, there's a [good integration with Github for storing the website as a Github Page](https://www.mkdocs.org/user-guide/deploying-your-docs/).

The plugins we've used:

- [Material for MKDocs](https://squidfunk.github.io/mkdocs-material/): Material design appearance and user experience.
- [pymdown-extensions](https://facelessuser.github.io/pymdown-extensions/): Improves the appearance of markdown based content.
- [mdx_truly_sane_lists](https://github.com/radude/mdx_truly_sane_lists): For defining the indent level for lists without having to refactor the entire documentation we already had in the playbook.
