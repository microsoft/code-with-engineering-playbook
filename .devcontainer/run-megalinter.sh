#!/usr/bin/env bash
# Run MegaLinter locally from the devcontainer — mirrors the CI setup in
# .github/workflows/mega-linter.yml and config in .mega-linter.yml.
#
# Usage:
#   .devcontainer/run-megalinter.sh              # lint only changed files
#   VALIDATE_ALL_CODEBASE=true .devcontainer/run-megalinter.sh  # lint everything
#
# Reports are written to ./megalinter-reports/ in the repo root.
set -euo pipefail

REPO_ROOT="$(git rev-parse --show-toplevel)"
VALIDATE_ALL="${VALIDATE_ALL_CODEBASE:-false}"

echo "Running MegaLinter (VALIDATE_ALL_CODEBASE=${VALIDATE_ALL})..."
docker run --rm \
  -v "${REPO_ROOT}:/tmp/lint" \
  -w /tmp/lint \
  -e VALIDATE_ALL_CODEBASE="${VALIDATE_ALL}" \
  -e DEFAULT_BRANCH=main \
  oxsecurity/megalinter:v8.1.0
