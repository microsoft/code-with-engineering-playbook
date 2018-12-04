# Python Code Reviews

## Python Style Guide

[CSE](../CSE.md) developers follow [Google's Python Style Guide](https://google.github.io/styleguide/pyguide.html).

## Linters

[CSE](../CSE.md) projects should check Python code with automated tools. ```pylint``` is the minimum, but we prefer to run three different tools:

### [```Pyflakes```](https://github.com/PyCQA/pyflakes)

Pyflakes is a fast static analysis tool that identifies common errors in Python code.

### [```pycodestyle```](https://github.com/PyCQA/pycodestyle)

We follow the [PEP 8](https://www.python.org/dev/peps/pep-0008/) style guide.

### [```pydocstyle```](https://github.com/PyCQA/pydocstyle)

We follow the [PEP 257](https://www.python.org/dev/peps/pep-0257/) Docstring conventions.

### [```Flake8```](https://pypi.org/project/flake8/)

Flake8 is an option for teams who want a single wrapper for running Pyflakes and pycodestyle.

#### Integrating automated checks in the application's build pipeline

For containerized applications one of the ways to include these checks as a part of the application build pipeline is to add a stage for the reviews in the application's Dockerfile as shown below:

```Dockerfile
# Static code analysis stage / environment
FROM python:3.7.1-slim AS build-env
WORKDIR /app
COPY . ./

RUN pip install pyflakes
RUN echo "****** Checking source file errors using pyflakes....."
RUN pyflakes app.py
RUN echo "****** Successfully analysed code with pyflakes"

RUN pip install pycodestyle
RUN echo "****** Checking source file code style with pycodestyle....."
RUN pycodestyle app.py
RUN echo "****** Successfully analysed code style with pycodestyle"

RUN pip install pydocstyle
RUN echo "****** Checking source doc style with pydocstyle....."
RUN pydocstyle app.py
RUN echo "****** Successfully analysed source file doc style with pydocstyle....."


# Runtime environment
FROM python:3.7.1-slim

# set our App environment, either development or production
# defaults to production, compose may override this to development on build and run
ARG APP_ENV=production
ENV APP_ENV $APP_ENV

# default to port 5000 
ARG PORT=5000
ENV PORT $PORT
EXPOSE $PORT

RUN useradd --user-group --create-home --shell /bin/false app &&   mkdir -p /opt/app


# check every 30s to ensure this service returns HTTP 200
HEALTHCHECK CMD curl -fs http://localhost:$PORT/healthz/live || exit 1

WORKDIR /opt/app
COPY requirements.txt /opt/app
RUN pip install --no-cache-dir -r requirements.txt

RUN chown -R app:app /opt/app && chgrp -R app /opt/app
USER app

WORKDIR /opt/app
COPY . /opt/app

CMD ["python", "app.py"]
```

## Starter Code Review Checklist

