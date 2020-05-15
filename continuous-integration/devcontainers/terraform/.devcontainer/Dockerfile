FROM golang:1.13-stretch

# Avoid warnings by switching to noninteractive
ENV DEBIAN_FRONTEND=noninteractive

ARG TERRAFORM_VERSION=0.12.24
ARG TFLINT_VERSION=0.15.3
ARG TERRAFORM_PROVIDER_AZUREDEVOPS_NAME=terraform-provider-azuredevops
ARG TERRAFORM_PROVIDER_AZUREDEVOPS_REPO=https://github.com/microsoft/terraform-provider-azuredevops.git

RUN apt-get update \
    && apt-get -y install --no-install-recommends apt-utils 2>&1 \
    # Verify git, process tools, lsb-release (common in install instructions for CLIs), unzip installed
    && apt-get -y install git procps lsb-release unzip \
    # Install Editor
    && apt-get install vim -y \
    # Install JQ
    && apt-get install jq -y \
    # Install Terraform, tflint
    && mkdir -p /tmp/docker-downloads \
    && curl -sSL -o /tmp/docker-downloads/terraform.zip https://releases.hashicorp.com/terraform/${TERRAFORM_VERSION}/terraform_${TERRAFORM_VERSION}_linux_amd64.zip \
    && unzip /tmp/docker-downloads/terraform.zip \
    && mv terraform /usr/local/bin \
    && curl -sSL -o /tmp/docker-downloads/tflint.zip https://github.com/wata727/tflint/releases/download/v${TFLINT_VERSION}/tflint_linux_amd64.zip \
    && unzip /tmp/docker-downloads/tflint.zip \
    && mv tflint /usr/local/bin \
    && cd ~ \ 
    && rm -rf /tmp/docker-downloads \
    # Install the Azure CLI
    && curl -sL https://aka.ms/InstallAzureCLIDeb | bash \
    # Clean up
    && apt-get autoremove -y \
    && apt-get clean -y \
    && rm -rf /var/lib/apt/lists/*

# Enable go modules
ENV GO111MODULE=on

# Install Go tools
RUN \
    # --> Delve for debugging
    go get github.com/go-delve/delve/cmd/dlv@v1.4.0 \
    # --> Go language server
    && go get golang.org/x/tools/gopls@v0.3.4 \
    # --> GolangCI-lint
    && curl -sfL https://install.goreleaser.com/github.com/golangci/golangci-lint.sh | sed 's/tar -/tar --no-same-owner -/g' | sh -s -- -b $(go env GOPATH)/bin \
    # --> Go-outline for extracting a JSON representation of the declarations in a Go source file
    && go get -v github.com/ramya-rao-a/go-outline \
    #
    # Clean up
    && rm -rf /go/src/ && rm -rf /go/pkg

# Install AzDO terraform provider
RUN git clone ${TERRAFORM_PROVIDER_AZUREDEVOPS_REPO}
RUN ./${TERRAFORM_PROVIDER_AZUREDEVOPS_NAME}/scripts/build.sh
RUN ./${TERRAFORM_PROVIDER_AZUREDEVOPS_NAME}/scripts/local-install.sh
RUN rm -rf ${TERRAFORM_PROVIDER_AZUREDEVOPS_NAME}

# Git command prompt
RUN git clone https://github.com/magicmonty/bash-git-prompt.git ~/.bash-git-prompt --depth=1 \
    && echo "if [ -f \"$HOME/.bash-git-prompt/gitprompt.sh\" ]; then GIT_PROMPT_ONLY_IN_REPO=1 && source $HOME/.bash-git-prompt/gitprompt.sh; fi" >> "/root/.bashrc"

# Add alias
RUN echo "alias tf=terraform" >> "/root/.bashrc"
