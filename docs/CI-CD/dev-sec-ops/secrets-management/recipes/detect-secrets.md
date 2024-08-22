# Credential Scanning Tool: `detect-secrets`

## Background

The [`detect-secrets`](https://github.com/Yelp/detect-secrets) tool is an open source project that uses heuristics and rules to scan for [a wide range](https://github.com/Yelp/detect-secrets#currently-supported-plugins) of secrets. We can extend the tool with custom rules and heuristics via a simple [Python plugin API](https://github.com/Yelp/detect-secrets/blob/a9dff60/detect_secrets/plugins/base.py#L27-L49).

Unlike other credential scanning tools, `detect-secrets` does not attempt to check a project's entire git history when invoked, but instead scans the project's current state. This means that the tool runs quickly which makes it ideal for use in continuous integration pipelines.

`detect-secrets` employs the concept of a "baseline file", i.e. a list of known secrets already present in the repository, and we can configure it to ignore any of these pre-existing secrets when running. This makes it easy to gradually introduce the tool into a pre-existing project.

The baseline file also provides a simple and convenient way of handling false positives. We can white-list the false positive in the baseline file to ignore it on future invocations of the tool.

## Setup

```sh
# install system dependencies: diff, jq, python3 (if on Linux-based OS)
apt-get install -y diffutils jq python3 python3-pip

# install system dependencies: diff, jq, python3 (if on Windows)
winget install Python.Python.3
choco install diffutils jq -y

# install the detect-secrets tool
python3 -m pip install detect-secrets

# run the tool to establish a list of known secrets
# review this file thoroughly and check it into the repository
detect-secrets scan > .secrets.baseline
```

## Pre-Commit Hook

It is recommended to use `detect-secrets` in your development environment as a Git pre-commit hook.

First, follow the [`pre-commit` installation instructions](https://pre-commit.com/#install) to install the tool in your development environment.

Then, add the following to your `.pre-commit-config.yaml`:

```yaml
repos:
-   repo: https://github.com/Yelp/detect-secrets
    rev: v1.4.0
    hooks:
    -   id: detect-secrets
        args: ['--baseline', '.secrets.baseline']
```

## Usage in CI Pipelines

```sh
# backup the list of known secrets
cp .secrets.baseline .secrets.new

# find all the secrets in the repository
detect-secrets scan --baseline .secrets.new $(find . -type f ! -name '.secrets.*' ! -path '*/.git*')

# if there is any difference between the known and newly detected secrets, break the build
list_secrets() { jq -r '.results | keys[] as $key | "\($key),\(.[$key] | .[] | .hashed_secret)"' "$1" | sort; }

if ! diff <(list_secrets .secrets.baseline) <(list_secrets .secrets.new) >&2; then
  echo "Detected new secrets in the repo" >&2
  exit 1
fi
```
