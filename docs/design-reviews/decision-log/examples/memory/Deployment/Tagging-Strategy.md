# Container Version Tagging Strategy

Docker container tagging strategy to set a standard for tagging containers before deployment.

## Stable Tags

Stable tags mean a developer, or a build system, can continue to pull a specific tag, which continues to get updates. 
Stable doesn’t mean the contents are frozen.
Rather, stable implies the image should be stable for the intent of that version.
To stay “stable”, it might be serviced to apply security patches or framework updates.

## Example for Stable Tags

The dev team deploy version `1.0` of Memory app and in the future we might deploy minor updates based on feedback.
In this case to support stable tags for major and minor versions we will be using two sets of stable tags.

- `:1` - a stable tag for the major version. `1` represents the “newest” or “latest” * version.
- `:1.0` - a stable tag for minor version `1.0`, allowing a developer to bind to updates of `1.0`, and not be rolled forward to 1.1 when it is released.
- `:1.0.0` - a tag for patch version, used to represent bug fixes.
- `:latest` which will point to the latest stable tag, no matter what the current major version.

![alt text](https://stevelaskerblog.files.wordpress.com/2018/03/stabletagging.gif)

## Conclusion

We as a dev team have decided to move forward with Stable tagging strategy for docker images based on the guidance from official Microsoft documentation found in the "References" section.

## References

[Recommendations for tagging and versioning container images](https://docs.microsoft.com/en-us/azure/container-registry/container-registry-image-tag-version)
