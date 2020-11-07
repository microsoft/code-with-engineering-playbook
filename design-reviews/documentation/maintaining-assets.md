# Documentation & Assets

There are many ways in which documentation can be created, updated and consumed. It is difficult to provide a "one-size fits all" solution because every team/product/company is so different. The goal of this _living_ document is to compare and contrast the various methods of maintaining documentation assets.

## Creating, Maintaining Documentation

| Method                                   | Pros | Cons |
| :--------------------------------------- | :--- | :--- |
| **Markdown in repo**                     | <ul><li>Version control</li><li>Requires review from team (helps ensure accuracy and align team on decisons)</li><li>Easy to contribute alongside code in PRs</li></ul> | <ul><li>Requires knowledge of Git</li><li>Requires review from team (slower updates)</li></ul> | Design documents for upcoming features |
| **Auto-generated docs from code**        | <ul><li>Easier to enforce existence of documentation with linters</li><li>More likely to be updated as changes occur in the code</li> | <ul><li>Some additional overhead at the start</li></ul> | Maintaining API documentation |
| **Wiki**                                 | <ul><li>Easy to update</li></ul> | <ul><li>Not easy to enforce documentation updates - can get stale quickly |
| **Word/PDF/PPT/etc. documents in shared storage** | <ul><li>Familiar to non-technical team members </li><li> Live collaboration tools </li><li> Required as policy by some companies</li></ul> | <ul><li>Not easy to enforce documentation updates - can get stale quickly </li><li> More difficult to version control </li></ul>|

## Sharing Documentation

For now, the "sharing" section is decoupled from the consideration of creation and maintenance of documentation since the two are not necessarily linked. This will mainly consider how the documentation is presented to those consuming it, including complexities around access policies.

| Method                                   | Pros | Cons |
| :--------------------------------------- | :--- | :--- |
| **Markdown in repo**                     | <ul><li>No additional security/access concerns - need repo access</li></ul> | <ul><li>Not as "polished" as other options</li></ul> |
| **GitHub Pages**                         | <ul><li>Free to host</li><li>More polish than raw markdown</li></ul>| <ul><li>More overhead in building & maintaining static web page</li></ul> |
| **Wiki**                                 | <ul><li>Quick updates</li></ul>| <ul><li>Complexity in access requirements</li></ul> |
| **Word/PDF documents in shared storage** | <ul><li>Familiar to less technical members</li><li>Can leverage access policies of shared storage (SharePoint)</li></ul>| <ul><li>Less discoverable</li></ul> |

TODO - Good use cases table??

