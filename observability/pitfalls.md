# Things to watch for when building Observable Systems

## Observability as an after thought

One of the design goals when building a system should be to enable monitoring of the system. This helps planning and thinking application availability, logging and metrics at the time of design and development. Observability also acts as a great debugging tool providing developers a bird's eye view of the system. By leaving instrumentation and logging of metrics towards the end, the development teams lose valuable insights during development.

## Metric Fatigue

1. It is recommended to collect and measure *what you need* **and** *not what you can*. Don't attempt to monitor everything.
2. If the data is not actionable, it is useless and becomes noise. On the contrary, it is sometimes very difficult to forecast every possible scenario that could go wrong.
3. There must be a balance between collecting what is needed vs. logging every single activity in the system. A general rule of thumb is to follow these principles

   - rules that catch incidents must be simple, relevant and reliable
   - any data that is collected but not aggregated or alerted on must be reviewed if it is still required.

## Context

Every data logged must contain rich context, which is useful for getting an overall view of the system and easy to trace back errors/failures during troubleshooting. While logging data, care must also be taken to avoid data silos.

## Personally Identifiable Information

As a general rule, do not log any customer sensitive and Personal Identifiable Information (PII). Ensure any pertinent privacy regulations are followed regarding PII (Ex: GDPR etc.,)
