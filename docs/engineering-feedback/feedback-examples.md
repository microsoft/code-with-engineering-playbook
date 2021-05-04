# Engineering Feedback Examples

The following are real-world examples of Engineering Feedback that have led to product improvements and unblocked customers.

## Windows Server Container support for Azure Kubernetes Service

The Azure Kubernetes Service should have first class Windows container support so solutions that require Windows workloads can be deployed on a wildly popular container orchestration platform. The need was to be able to deploy Windows Server containers on AKS the managed Azure Kubernetes Service. According to [this FAQ](https://docs.microsoft.com/en-us/azure/aks/faq#can-i-run-windows-server-containers-on-aks) (and in parallel confirmation) it is not available yet.

 We tried to deploy anyway as a test, and it did not work – the deployment would be pending without success.

More than a dozen large partners/customers are blocked in deploying Windows workloads to AKS due to a lack of support for Windows Server containers. They need this feature so solutions requiring Windows workloads can be deployed to this popular container orchestration platform.

We are seeing an emergence of companies beginning to try Windows containers as an option to move their Windows workloads to the cloud.  Gartner is claiming that 80% of enterprise apps run on Windows. Containers have become the de facto deployment mechanism in the industry, and deployment consistency and speed are a few of the important factors companies are looking for. Enabling Windows applications and ensuring that developers have a good experience when moving their workloads to Azure via Windows containers is key to keeping existing Windows customers within the Azure ecosystem and driving Azure adoption for new workloads.

We are also seeing increased interest, particularly among enterprise customers, in using a single orchestrator control plane for managing both Linux and Windows workloads.

> This feedback was created as a high priority feedback and followed up internally until addressed. Here is [the announcement](https://azure.microsoft.com/en-in/blog/announcing-the-preview-of-windows-server-containers-support-in-azure-kubernetes-service/).

## Support Batch Receiving with Sessions in Azure Functions Service Bus Trigger

Customer scenario was to receive a total of 250 messages per second from 50 producers with requirement for ordering & minimum latency, using a Service Bus topic with sessions enabled for ordering. According to [Microsoft documentation](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-performance-improvements#prefetching-and-receivebatch), batch receiving is recommended for better performance but this is not currently supported in Azure Functions Service Bus Trigger. The impact (and work around) was choosing containers over Functions. The Acceptance Criteria is for Azure Functions to support Service Bus sessions with batch and non-batch processing for all Azure Functions GA languages.

> This feedback was [created as a feedback](https://github.com/Azure/azure-functions-servicebus-extension/issues/15) with the Azure Functions product group and also followed up internally until addressed.

## Stream Analytics - No support for zero-downtime scale-down

In order to update the Streaming Unit number in Stream Analytics you need to stop the service and wait for minutes for it to restart. This unacceptable by customers who need near real-time analysis​. In order to have a job re-started, up to 2 minutes are needed and this is not acceptable for a real-time streaming solution. It would also be optimal if scale-up and scale-down could be done automatically, by setting threshold values that when reached increase or decrease automatically the amount of RU available. This feedback is for customers' request for zero down-time scale-down capability in stream analytics.

Problem Statement: In order to update the "Streaming Unit" number, partners must stop the service and wait until it restarts. The partner needs to be able to update the number without stopping the service.

Desired Experience: Partners should be able to update the Streaming Unit number without stopping the associated service.

> This feedback was created as a high priority feedback and followed up until addressed in December 2019.

## Python Support for Azure Functions

Several customers already use Python as part of their workflow, and would like to be able to use Python for Azure Functions. This is specially true since many of them are already have scripts running on other clouds and services.

In addition, Python support has been in Preview for a very long time and it's missing a lot of functionality.  

This feature request is one of the most asked and a huge upside potential to pull through Machine Learning (ML) based workloads.

> This feedback was created as a feedback with the Azure Functions product group and also followed up internally until addressed. Here is [the announcement](https://azure.microsoft.com/en-us/blog/announcing-the-general-availability-of-python-support-in-azure-functions/).
