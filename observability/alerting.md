# Alerting and Observability

One of the goals of building a highly observable systems is to provide valuable insight into the behavior of the application. The need for observable systems is to identify problem areas and surface them by raising appropriate alerts before it starts impacting end users.

## Best Practices

- The foremost thing to do before creating alerts is to implement observability.
- Identify what the application's minimum viable service quality needs to be. It is not what you intend to deliver, but is acceptable for the customer. These are [Service Level Objectives](https://landing.google.com/sre/sre-book/chapters/service-level-objectives/)(SLOs) and is a metric for measurement of the application's performance.
- SLOs are defined with respect to the end users. The alerts must watch for visible impact to the user. For example, alerting on request rate, latency and errors.
- Use automated, scriptable tools mimic end-to-end important code paths relatable to activities in the application. Create alert polices on user impacting events or metric rate of change.
- Establish a secondary channel for items that needs to be looked into and does not affect the users, yet. For example, storage that nearing capacity threshold. These items will be what the engineering services will look to regularly to monitor the health of the system.
- Learn from incidents - after every failure event has been triaged, conduct a post mortem of the scenario. Configuring an alert to detect that scenario is a good idea to see if event occurs again.
- Alerts must be created only for immediate user impacting events.

