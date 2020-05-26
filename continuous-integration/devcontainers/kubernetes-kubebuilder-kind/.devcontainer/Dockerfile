FROM golang:1.13.5

# Avoid warnings by switching to noninteractive
ENV DEBIAN_FRONTEND=noninteractive

# Configure apt, install packages and tools
RUN apt-get update \
    # Install recommended utils
    && apt-get -y install --no-install-recommends apt-utils 2>&1 \
    # Install sudo
    && apt-get -y install sudo \
    # Verify git, process tools, lsb-release (common in install instructions for CLIs) installed
    && apt-get -y install git procps lsb-release \
    # Install gocode-gomod
    && go get -x -d github.com/stamblerre/gocode 2>&1 \
    && go build -o gocode-gomod github.com/stamblerre/gocode \
    && mv gocode-gomod $GOPATH/bin/ \
    && GO111MODULE=on go get -v golang.org/x/tools/gopls@latest 2>&1 \
    # Install Go tools
    && go get -u -v \
        github.com/mdempsky/gocode \
        github.com/uudashr/gopkgs/cmd/gopkgs \
        github.com/ramya-rao-a/go-outline \
        github.com/acroca/go-symbols \
        github.com/godoctor/godoctor \
        golang.org/x/tools/cmd/guru \
        golang.org/x/tools/cmd/gorename \
        github.com/rogpeppe/godef \
        github.com/zmb3/gogetdoc \
        github.com/haya14busa/goplay/cmd/goplay \
        github.com/sqs/goreturns \
        github.com/josharian/impl \
        github.com/davidrjenni/reftools/cmd/fillstruct \
        github.com/fatih/gomodifytags \
        github.com/cweill/gotests/... \
        golang.org/x/tools/cmd/goimports \
        golang.org/x/lint/golint \
        github.com/alecthomas/gometalinter \
        honnef.co/go/tools/... \
        github.com/mgechev/revive \
        github.com/derekparker/delve/cmd/dlv 2>&1 \
    # Clean up
    && apt-get autoremove -y \
    && apt-get clean -y \
    && rm -rf /var/lib/apt/lists/*

RUN apt-get update \
    # Install Docker CE CLI
    && apt-get install -y apt-transport-https ca-certificates curl gnupg-agent software-properties-common lsb-release \
    && curl -fsSL https://download.docker.com/linux/$(lsb_release -is | tr '[:upper:]' '[:lower:]')/gpg | apt-key add - 2>/dev/null \
    && add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/$(lsb_release -is | tr '[:upper:]' '[:lower:]') $(lsb_release -cs) stable" \
    && apt-get update \
    && apt-get install -y docker-ce-cli \
    # Install kubectl
    && curl -sSL -o /usr/local/bin/kubectl https://storage.googleapis.com/kubernetes-release/release/$(curl -s https://storage.googleapis.com/kubernetes-release/release/stable.txt)/bin/linux/amd64/kubectl \
    && chmod +x /usr/local/bin/kubectl \
    # Install kubebuilder
    && curl -sL https://go.kubebuilder.io/dl/2.3.1/linux/amd64 | tar -xz -C /tmp \
	&& mv /tmp/kubebuilder_2.3.1_linux_amd64 /usr/local/kubebuilder \
    # Install kustomize
    && curl -o /usr/local/kubebuilder/bin/kustomize -sL "https://go.kubebuilder.io/kustomize/linux/amd64" \
	&& chmod a+x /usr/local/kubebuilder/bin/kustomize \
    # Install kind
    && GO111MODULE="on" go get sigs.k8s.io/kind@v0.8.1 \
    # Install Helm
    && curl -s https://raw.githubusercontent.com/helm/helm/master/scripts/get-helm-3 | bash - \
    # Install Azure CLI
    && curl -sL https://aka.ms/InstallAzureCLIDeb | bash -

# Verify git, process tools installed
RUN apt-get -y install git procps wget nano zsh inotify-tools jq
RUN wget https://github.com/robbyrussell/oh-my-zsh/raw/master/tools/install.sh -O - | zsh || true

# Save command line history 
RUN echo "export HISTFILE=/root/commandhistory/.zsh_history" >> "/root/.zshrc" \
    && echo "export PROMPT_COMMAND='history -a'" >> "/root/.zshrc" \
    && mkdir -p /root/commandhistory \
    && touch /root/commandhistory/.zsh_history

# Add useful aliases
RUN echo "alias k=kubectl" >> "/root/.zshrc"

ENV PATH="/usr/local/kubebuilder/bin:${PATH}"
ENV GO111MODULE=on
ENV KUBECONFIG="/root/.kube/kind-config-kind"

# Set the default shell to bash instead of sh
ENV SHELL /bin/zsh
