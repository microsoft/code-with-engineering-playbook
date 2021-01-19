# Observability in Microservices

Micro-services is a very popular software architecture, where the application is arranged as a collection of loosely coupled services. Some of those services can be written in different languages by different teams.

## Motivations

We need to consider special cases when creating a micro-service architecture from the perspective of observability. The main reason for that is because the interaction those micro-services are going to have and the can potentially loose the correlation between things that happens within those micro-services.

Imagine we have a micro-service that access the database and retrieve some data as part of a request. This micro-service is going to be called by someone else as part of an incoming http request or a internal process being executed. What happen if during the retrieval of the data (or the update of the data) something wrong happen? How we can associate, or correlated, that this particular call failed in the destination micro-service?

This is a common issue. When calling other micro-services, depending of the technology stack we use, we can hide errors and exceptions that might happen on the other side even without wanting it. If we are using a simply REST interface, the other micro-service can return to us a 500 HTTP status code and we don't have any idea what happen inside that micro-service.

More important, we don't have any way to associate our Correlation Id to whatever happen inside that micro-service. Therefore, is so important to have a plan in place to be able to extend your traceability and monitoring efforts, especially when using a micro-service architecture.

## How to extend your tracing information between microservices

The W3C consortium is working in a [Trace Context](https://www.w3.org/TR/trace-context/) definition that we can use when using HTTP as the protocol in our micro-service architecture. But let's explain how we can implement this functionality in our software.

The main idea behind is to propagate the correlation information between http request so other pieces of software can read this information and correctly correlate telemetry across micro-services.

The way to propagate this information is to use HTTP Headers for the Correlation Id, parent Correlation Id, etc.

When you are in the scope of a HTTP Request, your tracing system should already created four properties that you can use to send across your micro-services.

- RequestId:0HLQV2BC3VP2T:00000001,
- SpanId:da13aa3c6fd9c146,
- TraceId:f11a03e3f078414fa7c0a0ce568c8b5c,
- ParentId:5076c17d0a604244

This is an example of the four properties that you can find that identify the current request.

- RequestId is the unique id that represent the current HTTP Request.
- SpanId is the default automatically generated span. You can have more than one Span that scope different functionality inside your software.
- TraceId represent the id for current log trace.
- ParentId is the parent span id, that in some case can be the same or something different.

Imagine now that as part of the processing of this request we have to call another micro-service to get data from the database. We would like to send our current SpanId as the future ParentId in the destination micro-service.

| A Micro-service | B - Micro-service 1 | C - Micro-service 2 |
| ----------- | ----------- | ----------- |
| RequestId   | (New)RequestId | (New)RequestId
| SpanId | ParentId |  |
|  | (New)SpanId | ParentId |
| TraceId | (New)TraceId | (New)TraceId |


This table summarize what can happen with two micro-service that are called in a row.

A -> B -> C

So the SpanId of **A** is converted into ParentId in **B**, if as part of the same request **B** call **C** then his own SpanId is begin propagated to **C** so we can make explicit that this is new call from **B**.

Each of this three micro-services have his own SpanId and TraceId and they have internal API to create new SpanId or TraceId that will signal the telemetry system that a new internal operation is started. That can be used to track third party dependency or different software sub-modules within the same code.

