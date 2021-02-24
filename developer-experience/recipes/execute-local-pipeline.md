# Execute Local Pipeline

## Abstract

Having the ability to execute pipeline activities locally has been identified as an opportunity to promote positive developer experience.
In this document we will explore a solution which will allow us to have the local CI experience to be as similar as possible to the remote process in the CI server.

Using the suggested method will allow us to:

1. Build
2. Lint
3. Unit test
4. E2E test
5. Deploy
6. Be OS and environment agnostic.

## Enter Docker Compose

[Docker Compose](https://docs.docker.com/compose/) allows to build, push or run multi-container Docker applications.

### Method of work

1. Dockerize your application(s), including a build step if possible.
2. Add a step in your docker file to execute unit tests.
3. Add a step in the docker file for linting.
4. Create a new dockerfile, possibly in a different folder, which executes end-to-end tests against the cluster. Make sure the default endpoints are configurable (This will become handy in your remote CI server, where you will be able to test against a live environment, if you choose to).
5. Create a docker-compose file which allows to choose which of the services to run. The default will run only the applications, and an additional parameter can enable e2e tests for example.

### Examples

TODO: Add dockerfile and docker-compose samples, plus Azure Pipeline yaml to use it as a CI and a set of script commands to use it locally, to show how you can use the same resources locally and in the CI.

