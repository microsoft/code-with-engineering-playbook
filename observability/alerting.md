# Alerting and Observability

One of the goals of building a highly observable systems is to provide valuable insight into the behavior of the application. The need for observable systems is to identify problem areas and surface them by raising appropriate alerts before it starts impacting end users.

## Best Practices

- The foremost thing to do before creating alerts is to implement observability. Without monitoring systems in place, it becomes next to impossible to know what activities needs to be monitored and when to alert the teams.
- Identify what the application's minimum viable service quality needs to be. It is not what you intend to deliver, but is acceptable for the customer. These [Service Level Objectives](https://landing.google.com/sre/sre-book/chapters/service-level-objectives/)(SLOs) is a metric for measurement of the application's performance.
- SLOs are defined with respect to the end users. The alerts must watch for visible impact to the user. For example, alerting on request rate, latency and errors.
- Use automated, scriptable tools mimic end-to-end important code paths relatable to activities in the application. Create alert polices on user impacting events or metric rate of change.
- Alert fatigue is real. Engineers are recommended to pay attention to their monitoring system so that right alerts and thresholds can be defined.
- Establish a primary channel for alerts that needs immediate attention and tag the right team/person(s) based on the nature of the incident. Not every single alert needs to be sent to the primary on-call channel.
- Establish a secondary channel for items that needs to be looked into and does not affect the users, yet. For example, storage that nearing capacity threshold. These items will be what the engineering services will look to regularly to monitor the health of the system.
- Learn from incidents - after every failure event has been triaged, conduct a [post mortem of the scenario](https://landing.google.com/sre/workbook/chapters/postmortem-culture/). Incidents will happen in a live service environment. Scenarios and situations that were not considered initially, occur and the post mortem workflow is a great way to highlight that to improve the monitoring/alerting of the system. Configuring an alert to detect that incident scenario is a good idea to see if event occurs again.
