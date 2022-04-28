# Preferred Diagram Tooling

At each stage in the engagement process, diagrams are a key part of the design review.
The preferred tooling for creating and maintaining diagrams is the `.drawio` format from [diagrams.net](http://diagrams.net) (formerly [draw.io](http://draw.io))

The `.drawio` format uses the metadata layer within the PNG file-format to hide SVG vector graphics representation, then renders the .png when saving.
This clever use of both the meta layer and image layer allows anyone to further edit the PNG file.
It also renders like a normal PNG in browsers and other viewers, making it easy to transfer and embed.
Furthermore, it can be edited within VSCode very easily using the [Draw.io Integration VSCode Extension](https://marketplace.visualstudio.com/items?itemName=hediet.vscode-drawio).

This tooling can be used like Visio or LucidChart, without the licensing/remote storage concerns.
Furthermore, Diagrams.net has a collection of Azure/Office/Microsoft icons, as well as other well-known tech, so it is not only useful for swimlanes and flow diagrams, but also for architecture diagrams.
