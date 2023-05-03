# Reusing dev containers within a pipeline

Given a repository with a local development container aka [dev container](../devcontainers/README.md) that contains all the tooling required for development, would it make sense to reuse that container for running the tooling in the Continuous Integration pipelines?

## Considered Options

- Run CI pipelines in native environment
- Run CI pipelines in the dev container via building image locally
- Run CI pipelines in the dev container with a container registry

Here are below pros and cons for both approaches:

### Run CI pipelines in native environment

| Pros                                                  | Cons                                                                                                                                         |
| ----------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------- |
| Can use any pipeline tasks available                  | Need to keep two sets of tooling and their versions in sync                                                                                  |
| No container registry                                 | Can take some time to start, based on tools/dependencies required                                                                            |
| Agent will always be up to date with security patches | The dev container should always be built within each run of the CI pipeline, to verify the changes within the branch haven't broken anything |

> Tools can be Terraform/Terragrunt/linting utilities/unit tests framework. Dependencies are what our Python code will require to run (SDK Purview for instance)

### Run CI pipelines in the dev container with building image locally

| Pros                                                                                               | Cons                                                                                                                           |
| -------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------ |
| Utilities scripts will work out of the box                                                         | Need to rebuild the container for each run, given that there may be changes within the branch being built                      |
| Rules used (for linting or unit tests) will be the same on the CI                                  | Not everything in the container is needed for the CI pipeline&#185;                                                            |
| No surprise for the developers, local outputs (of linting for instance) will be the same in the CI | Some tools were installed via a definition in `devcontainer.json`, resulting in a different container from the dev environment |
| All tooling and their versions defined in a single place                                           | Some pipeline tasks will not be available                                                                                      |
| Tools/dependencies are already present                                                             | Building the image for each pipeline run is slow&#178;                                                                         |
| The dev container is being tested to include all new tooling in addition to not being broken       |                                                                                                                                |

> &#185;: container size can be reduces by exporting the layer that contains only the tooling needed for the CI pipeline
>
> &#178;: could be mitigated via adding image caching without using a container registry

### Run CI pipelines in the dev container with image registry

| Pros                                                                                                                                                                                                                                                                                            | Cons                                                                                                                                 |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| Utilities scripts will work out of the box                                                                                                                                                                                                                                                      | Need to rebuild the container for each run, given that there may be changes within the branch being built                            |
| No surprise for the developers, local outputs (of linting for instance) will be the same in the CI                                                                                                                                                                                              | Not everything in the container is needed for the CI pipeline&#185;                                                                  |
| Rules used (for linting or unit tests) will be the same on the CI                                                                                                                                                                                                                               | Some tools were installed via a definition in `devcontainer.json`, resulting in a different container from the dev environment&#178; |
| All tooling and their versions defined in a single place                                                                                                                                                                                                                                        | Some pipeline tasks will not be available &#179;                                                                                     |
| Tools/dependencies are already present                                                                                                                                                                                                                                                          | Require access to a container registry to host the container within the pipeline&#8308;                                              |
| The dev container is being tested to include all new tooling in addition to not being broken                                                                                                                                                                                                    |                                                                                                                                      |
| Publishing the container built from `devcontainer.json` allows you to reference it in the cacheFrom in `devcontainer.json` (see [docs](https://containers.dev/implementors/json_reference/#image-specific)). By doing this, VS Code will use the published image as a layer cache when building |                                                                                                                                      |

> &#185;: container size can be reduces by exporting the layer that contains only the tooling needed for the CI pipeline. This would require building the image without tasks
>
> &#178;: building dev container with [GitHub - devcontainers/ci](https://github.com/devcontainers/ci) builds the container with the `devcontainer.json`. Example here: [devcontainers/ci · Getting Started](https://github.com/devcontainers/ci/blob/main/docs/github-action.md#getting-started)
>
> &#179;: using container jobs in AzDO you can use all tasks (as far as I can tell). Reference: [Dockerizing DevOps V2 - AzDO container jobs - DEV Community](https://dev.to/eliises/dockerizing-devops-v2-azdo-container-jobs-3hbf)
>
> &#8308;: within GH actions, the default Github Actions token can be used for accessing GHCR without setting up separate registry, see the example below.
> **NOTE:** This does not build the `Dockerfile` together with the `devcontainer.json`

```yaml
    - uses: whoan/docker-build-with-cache-action@v5
        id: cache
        with:
          username: $GITHUB_ACTOR
          password: "${{ secrets.GITHUB_TOKEN }}"
          registry: docker.pkg.github.com
          image_name: devcontainer
          dockerfile: .devcontainer/Dockerfile
```


