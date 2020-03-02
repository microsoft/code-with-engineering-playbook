# Credential scanning tool suggestion: detect-secrets

## Background

The [detect-secrets](https://github.com/Yelp/detect-secrets) tool is an open source project that uses heuristics and rules to scan for [a wide range](https://github.com/Yelp/detect-secrets#currently-supported-plugins) of secrets. The tool can be extended with custom rules and heuristics via a simple [Python plugin API](https://github.com/Yelp/detect-secrets/blob/a9dff60/detect_secrets/plugins/base.py#L27-L49).

Unlike many credential scanning tools, detect-secrets does not attempt to check a project's entire git history when invoked, but instead only scans the project's current state. This means that the tool runs very quickly which makes it ideal for use in continuous integration pipelines. Additionally, detect-secrets employs the concept of a "baseline file", i.e. a list of known secrets already present in the repository, and can be configured to ignore any of these pre-existing secrets when running. This makes it easy to gradually introduce the tool into a pre-existing project. The baseline file also provides a simple and convenient way of handling false positives: white-list the false positive in the baseline file and it will be ignored on future invocations of the tool.

## Setup

```sh
# install system dependencies: diff, jq, python3
apt-get install -y diffutils jq python3 python3-pip

# install the detect-secrets tool
python3 -m pip install detect-secrets

# run the tool to establish a list of known secrets
# this file should be reviewed carefully and checked into the repository
detect-secrets scan > .secrets.baseline
```

## Usage

```sh
# backup the list of known secrets
cp .secrets.baseline .secrets.new

# find all the secrets currently in the repository
detect-secrets scan --update .secrets.new $(find . -type f ! -name '.secrets.*' ! -path '*/.git*')

# if there is any difference between the known and newly detected secrets, break the build
list_secrets() { jq -r '.results | keys[] as $key | "\($key),\(.[$key] | .[] | .hashed_secret)"' "$1" | sort; }

if ! diff <(list_secrets .secrets.baseline) <(list_secrets .secrets.new) >&2; then
  echo "Detected new secrets in the repo" >&2
  exit 1
fi
```
