# Observability in Microservices

microservices is a very popular software architecture, where the application is arranged as a collection of loosely coupled services. Some of those services can be written in different languages by different teams.

## Motivations

We need to consider special cases when creating a microservice architecture from the perspective of observability. The main reason for that is because we want to capture the interaction between those microservices are going to have when making request between each other that can't be correlated.

Imagine we have a microservice that accesses the database and retrieve some data as part of a request. This microservice is going to be called by someone else as part of an incoming http request or an internal process being executed. What happen if during the retrieval of the data (or the update of the data) something wrong happen? How we can associate, or correlate, that this particular call failed in the destination microservice?

This is a common issue. When calling other microservices, depending on the technology stack we use, we can hide errors and exceptions that might happen on the other side even without wanting it. If we are using a simple REST interface, the other microservice can return to us a 500 HTTP status code and we don't have any idea what happen inside that microservice.

More important, we don't have any way to associate our Correlation Id to whatever happens inside that microservice. Therefore, is so important to have a plan in place to be able to extend your traceability and monitoring efforts, especially when using a microservice architecture.

## How to extend your tracing information between microservices

The W3C consortium is working in a [Trace Context](https://www.w3.org/TR/trace-context/) definition that we can use when using HTTP as the protocol in our microservice architecture. But let's explain how we can implement this functionality in our software.

The main idea behind this is to propagate the correlation information between http request so other pieces of software can read this information and correctly correlate telemetry across microservices.

The way to propagate this information is to use HTTP Headers for the Correlation Id, parent Correlation Id, etc.

When you are in the scope of a HTTP Request, your tracing system should already have created four properties that you can use to send across your microservices.

- RequestId:0HLQV2BC3VP2T:00000001,
- SpanId:da13aa3c6fd9c146,
- TraceId:f11a03e3f078414fa7c0a0ce568c8b5c,
- ParentId:5076c17d0a604244

This is an example of the four properties you can find which identify the current request.

- RequestId is the unique id that represent the current HTTP Request.
- SpanId is the default automatically generated span. You can have more than one Span that scope different functionality inside your software.
- TraceId represent the id for current log trace.
- ParentId is the parent span id, that in some case can be the same or something different.

## Example

Now we are going to explore an example with 3 microservices that calls to each other in a row.

![image](./microservices.png)

This image is the summary of what is needed in each microservice to propagate the trace-id from A to C.

The root caller is A and that is why it doesn't have a parent-id, only have a new trace-id. Next, A calls B using HTTP. To propagate the correlation information as part of the request, we are using two new headers, that based on the W3C Correlation specification, are: trace-id and parent-id. So, in this example because A is the root caller, he only sends his own trace-id to the microservice B.

When the microservice B received the incoming http request, checks the content of these two headers. Reads the content of the trace-id header and sets as his own parent-Id (as shown in the green rectangle inside's B). Also, create a new trace-id to signal that is a new scope for the telemetry. During the execution of the microservice B, it also calls microservice C and it's the same situation. As part of the request include the two headers and propagate trace-id and parent-id as well.

Finally, the microservice C, reads the value for the incoming trace-id and sets as his own parent-id, but also create a new trace-id that will use to send telemetry about his own operations.

## Summary

A lot of APM technology already support most of this Correlation Propagation. The most popular is [OpenZipkin/B3-Propagation](https://github.com/openzipkin/b3-propagation). But W3C already proposed recommendation for the [W3C Trace Context](https://www.w3.org/blog/2019/12/trace-context-enters-proposed-recommendation/), where you can see what SKD and frameworks already support this functionality. It's important to correctly implement the propagation specially when there are different teams that used different technology stacks in the same project.