# Preferred Diagram Tooling

At each stage in the engagement process, diagrams are a key part of the design review.
The preferred tooling for creating and maintaining diagrams is to choose **one** of the following:

- Microsoft Visio
- Microsoft PowerPoint
- The `.drawio.png` (or `.drawio`) format from [diagrams.net](http://diagrams.net) (formerly [draw.io](http://draw.io))

In all cases, we recommend storing the exported PNG images from these diagrams in the repo along with the source files so they can easily be referenced in documentation and more easily reviewed during PRs. The `.drawio.png` format stores both at once.

## Microsoft Visio

It contains a lot of shapes out of the box, including Azure icons, the desktop app exists on PC, and there's a great Web app. Most diagrams in the Azure Architecture Center are Visio diagrams.

## Microsoft PowerPoint

Diagrams can be easily reused in presentations, a PowerPoint license is pretty common, the desktop app exists on PC and on the Mac, and there's a great Web app.

## `.drawio.png`

There are different desktop, web apps and VS Code extensions.
This tooling can be used like Visio or LucidChart, without the licensing/remote storage concerns.
Furthermore, Diagrams.net has a collection of Azure/Office/Microsoft icons, as well as other well-known tech, so it is not only useful for swimlanes and flow diagrams, but also for architecture diagrams.

`.drawio.png` should be preferred over the `.drawio` format.
The `.drawio.png` format uses the metadata layer within the PNG file-format to hide SVG vector graphics representation, then renders the .png when saving.
This clever use of both the meta layer and image layer allows anyone to further edit the PNG file.
It also renders like a normal PNG in browsers and other viewers, making it easy to transfer and embed.
Furthermore, it can be edited within VSCode very easily using the [Draw.io Integration VSCode Extension](https://marketplace.visualstudio.com/items?itemName=hediet.vscode-drawio).
