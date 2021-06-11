# Dockerfile and docker-compose

This recipe describes the required files to run Locust using Docker.

## Dockerfile

The `Dockerfile` is pretty straight-forward and tells Docker the locust image to use.

```yaml
FROM locustio/locust
WORKDIR /home/locust/test/
RUN pip3 install jmespath
COPY ./ ./
```

## docker-compose.yml

The docker-compose used here is the basic one that should run in most environments. It:

- uses the default port,
- starts Locust in headless mode,
- stores the results in `csv` format,
- stores the logs in the `/home/locust/test/result/result` directory.

```yaml
version: '3'
services:
  main:
    env_file:
      - .env
    build:
      context: .
      dockerfile: Dockerfile
    container_name: locust-main
    user: root
    ports:
      - "8089:8089"
    environment:
      LOCUST_MODE_MASTER: "true"
      LOCUST_HOST: "http://"
      LOCUST_HEADLESS: "true"
      LOCUST_CSV: /home/locust/test/result/result
      LOCUST_LOGFILE: /home/locust/test/result/locusttest.log
    networks:
      - locust-net
    volumes:
      - ./results/:/home/locust/test/result/
  worker:
    env_file:
      - .env
    build:
      context: .
      dockerfile: Dockerfile
    container_name: locust-worker
    user: root
    environment:
      LOCUST_MODE_WORKER: "true"
      LOCUST_MASTER_NODE_HOST: main
      LOCUST_MASTER_NODE_PORT: "8089"
      LOCUST_HOST: "http://"
      LOCUST_HEADLESS: "true"
    depends_on:
       - main
    networks:
      - locust-net
    volumes:
      - ./results/:/home/locust/test/result/
networks:
  locust-net:
    driver: bridge
```

### docker-compose.override.yml

This is where different parameters can be set, so the tests described in `locustfile.py` can perform different test
cases or scenarios.

```yaml
version: '3'
services:
  main:
    command: <locust_command>
    environment:
        LOCUST_USERS: <locust_users>
        LOCUST_EXPECT_WORKERS: <locust_expect_workers>
        LOCUST_SPAWN_RATE: <locust_spawn_rate>
        LOCUST_RUN_TIME: <locust_run_time>s
  worker:
    command: <locust_command>
```

The parameters in `< >` have to be updated, here is a definition for each one of them:

- `command`: The test class to run. In the [example](locustfile_py.md) this is `TestSmallScaleCreateAndCloseCase`
- `LOCUST_USERS`: Number of users to be considered in the tests
- `LOCUST_EXPECT_WORKERS`: Number of workers to be considered in the tests
- `LOCUST_SPAWN_RATE`: Number of simultaneous users to be considered in the tests
- `LOCUST_RUN_TIME`: Time, in seconds, for the tests to run
