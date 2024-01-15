# Dev Containers: Going further

Dev Containers allow developers to share a common working environment, ensuring that the runtime and all dependencies versions are consistent for all developers.

Dev containers also allow us to:

1. Leverage existing tools to enhance the Dev Containers with more features,
2. Provide custom tools (such as scripts) for other developers.

## Existing tools

In the development phase, you will most probably need to use tools not installed by default in your Dev Container. For instance, if your project's target is to be deployed on Azure, you will need [Azure-cli](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) and maybe [Terraform](https://www.terraform.io/) for resources and application deployment. You can find such Dev Containers in the [VS Code dev container gallery repo](https://github.com/devcontainers/templates/tree/main/src).

Some other tools may be:

* Linters for [markdown](https://github.com/DavidAnson/markdownlint) files,
* Linters for [bash](https://www.shellcheck.net/) scripts,
* Etc...

Linting files that are not *the source code* can ensure a common format with common rules for each developer. These checks should be also run in a [Continuous Integration Pipeline](https://learn.microsoft.com/azure/devops/pipelines/architectures/devops-pipelines-baseline-architecture), but it is a good practice to run them prior opening a [Pull Request](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/about-pull-requests).

## Limitation of custom tools

If you decide to include [Azure-cli](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) in your Dev Container, developers will be able to run commands against their tenant. However, to make the developers' lives easier, we could go further by letting them prefill their connection information, such as the `tenant ID` and the `subscription ID` in a secure and persistent way (do not forget that your Dev Container, being a [Docker](https://www.docker.com/) container, might get deleted, or the image could be rebuilt, hence, all customization *inside* will be lost).

One way to achieve this is to leverage environment variables, with untracked `.env` file part of the solution being injected in the Dev Container.

Consider the following files structure:

```bash
My Application  # main repo directory
└───.devcontainer
|       ├───Dockerfile
|       ├───devcontainer.json
└───config
|       ├───.env
|       ├───.env-sample
```

The file `config/.env-sample` is a tracked file where anyone can find environment variables to set (with no values, obviously):

```bash
TENANT_ID=
SUBSCRIPTION_ID=
```

Then, each developer who clones the repository can create the file `config/.env` and fills it in with the appropriate values.

In order now to inject the `.env` file into the container, you can update the file `devcontainer.json` with the following:

```json
{
    ...
    "runArgs": ["--env-file","config/.env"],
    ...
}
```

As soon as the Dev Container is started, these environment variables are sent to the container.

Another approach would be to use Docker Compose, a little bit more complex, and probably *too much* for just environment variables. Using Docker Compose can unlock other settings such as custom dns, ports forwarding or multiple containers.

To achieve this, you need to add a file `.devcontainer/docker-compose.yml` with the following:

```yaml
version: '3'
services:
  my-workspace:
    env_file: ../config/.env
    build:
      context: .
      dockerfile: Dockerfile
    command: sleep infinity
```

To use the `docker-compose.yml` file instead of `Dockerfile`, we need to adjust `devcontainer.json` with:

```json
{
    "name": "My Application",
    "dockerComposeFile": ["docker-compose.yml"],
    "service": "my-workspace"
    ...
}
```

This approach can be applied for many other tools by preparing what would be required. The idea is to simplify developers' lives and new developers joining the project.

## Custom tools

While working on a project, any developer might end up writing a script to automate a task. This script can be in `bash`, `python` or whatever scripting language they are comfortable with.

Let's say you want to ensure that all markdown files written are validated against specific rules you have set up. As we have seen above, you can include the tool [markdownlint](https://github.com/DavidAnson/markdownlint) in your Dev Container . Having the tool installed does not mean developer will know how to use it!

Consider the following solution structure:

```bash
My Application  # main repo directory
└───.devcontainer
|       ├───Dockerfile
|       ├───docker-compose.yml
|       ├───devcontainer.json
└───scripts
|       ├───check-markdown.sh
└───.markdownlint.json
```

The file `.devcontainer/Dockerfile` installs [markdownlint](https://github.com/DavidAnson/markdownlint)

```dockerfile
...
RUN apt-get update \
    && export DEBIAN_FRONTEND=noninteractive \
    && apt-get install -y nodejs npm

# Add NodeJS tools
RUN npm install -g markdownlint-cli
...
```

The file `.markdownlint.json` contains the rules you want to validate in your markdown files (please refer to the [markdownlint site](https://github.com/DavidAnson/markdownlint) for details).

And finally, the script `scripts/check-markdown.sh` contains the following code to execute `markdownlint`:

```bash
# Get the repository root
repoRoot="$( cd "$( dirname "${BASH_SOURCE[0]}" )/.." >/dev/null 2>&1 && pwd )"

# Execute markdownlint for the entire solution
markdownlint -c "${repoRoot}"/.markdownlint.json
```

When the Dev Container is loaded, any developer can now run this script in their terminal:

```bash
/> ./scripts/check-markdown.sh
```

This is a small use case, there are unlimited other possibilities to capitalize on work done by developers to save time.

## Other considerations

### Platform architecture

When installing tooling, you also need to ensure that you know what host computers developers are using. All Intel based computers, whether they are running Windows, Linux or MacOs will have the same behavior.
However, the latest Mac architecture (Apple M1/Silicon) being ARM64, means that the behavior is not the same when building Dev Containers.

For instance, if you want to install [Azure-cli](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) in your Dev Container, you won't be able to do it the same way you do it for Intel based machines. On Intel based computers you can install the `deb` package. However, this package is not available on ARM architecture. The only way to install [Azure-cli](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) on Linux ARM is via the Python installer `pip`.

To achieve this you need to check the architecture of the host building the Dev Container, either in the Dockerfile, or by calling an external bash script to install remaining tools not having a universal version.

Here is a snippet to call from the Dockerfile:

```bash
# If Intel based, then use the deb file
if [[ `dpkg --print-architecture` == "amd64" ]]; then
    sudo curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash;
else
# arm based, install pip (and gcc) then azure-cli
    sudo apt-get -y install gcc
    python3 -m pip install --upgrade pip
    python3 -m pip install azure-cli
fi
```

### Reuse of credentials for GitHub

If you develop inside a Dev Container, you will also want to share your GitHub credentials between your host and the Dev Container. Doing so, you would avoid copying your ssh keys back and forth (if you are using ssh to access your repositories).

One approach would be to mount your local `~/.ssh` folder into your Dev Container. You can either use the `mounts` option of the `devcontainer.json`, or use Docker Compose

* Using `mounts`:

```json
{
    ...
    "mounts": ["source=${localEnv:HOME}/.ssh,target=/home/vscode/.ssh,type=bind"],
    ...
}
```

As you can see, `${localEnv:HOME}` returns the host `home` folder, and it maps it to the container `home` folder.

* Using Docker Compose:

```yaml
version: '3'
services:
  my-worspace:
    env_file: ../configs/.env
    build:
      context: .
      dockerfile: Dockerfile
    volumes:
      - "~/.ssh:/home/alex/.ssh"
    command: sleep infinity
```

Please note that using Docker Compose requires to edit the `devcontainer.json` file as we have seen above.

You can now access GitHub using the same credentials as your host machine, without worrying of persistence.

### Allow some customization

As a final note, it is also interesting to leave developers some flexibility in their environment for customization.

For instance, one might want to add aliases to their environment. However, changing the `~/.bashrc` file in the Dev Container is not a good approach as the container might be destroyed. There are numerous ways to set persistence, here is one approach.

Consider the following solution structure:

```bash
My Application  # main repo directory
└───.devcontainer
|       ├───Dockerfile
|       ├───docker-compose.yml
|       ├───devcontainer.json
└───me
|       ├───bashrc_extension
```

The folder `me` is untracked in the repository, leaving developers the flexibility to add personal resources. One of these resources can be a `.bashrc` extension containing customization. For instance:

```bash
# Sample alias
alias gaa="git add --all"
```

We can now adapt our `Dockerfile` to load these changes when the Docker image is built (and of course, do nothing if there is no file):

```dockerfile
...
RUN echo "[ -f PATH_TO_WORKSPACE/me/bashrc_extension ] && . PATH_TO_WORKSPACE/me/bashrc_extension" >> ~/.bashrc;
...
```
