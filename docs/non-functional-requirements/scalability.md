# Scalability

Scalability is the capability of a system to handle larger volumes, or its potential to accommodate additional growth. For example, a system is considered scalable if it is capable of increasing its total output under an increased load when resources (typically hardware) are added. An example of this is a system that can handle a growing number of requests when more memory is added to it.

## Characteristics

- Elasticity: The system should be able to scale up or down based on demand, and be able to automatically provision or de-provision resources as needed.
- Latency: The system should be able to maintain low latency even under high load, and be able to handle a large number of concurrent requests without slowing down.

## Examples

- Load Balancing: The application must be able to handle a minimum of 250 concurrent users and support load balancing across at least 3 servers to handle peak traffic.
- Database Scalability: The application's database must be able to handle at least 1 million records and support partitioning or sharding to ensure efficient storage and retrieval of data.
- Cloud-Based Infrastructure: The application must be deployed on cloud-based infrastructure that can handle at least 100,000 requests per hour, and be able to scale up or down to meet changing demand.
- Microservices Architecture: The application must be designed using a microservices architecture that allows for easy scaling of individual services, and be able to handle at least 500 requests per second.
- Caching: The application must be able to cache at least 10,000 records, with a cache hit rate of 95%, and support caching across multiple servers to ensure high availability.
