# Performance Testing

Performance Testing is an overloaded term that is used to refer to several sub
categories of performance related testing, each of which has different purpose.

A good description of overall performance testing is as follows:

> Performance testing is a type of testing intended to determine the
responsiveness, throughput, reliability, and/or scalability of a system under a
given workload. [Performance Testing Guidance for Web
Applications](https://docs.microsoft.com/en-us/archive/blogs/dajung/ebook-pnp-performance-testing-guidance-for-web-applications).

The important take away here is that performance testing goes beyond simple user
experience. Performance has a clear impact on scalability and reliability.
Applications whether they are client applications are back in server services
are unable to scale during peak demands and therefore impact reliability as
well.

Before getting into the different subcategories of performance tests let us
understand why performance testing is typically done.

## Why Performance Testing

Performance testing is commonly conducted to accomplish one or more the
following:

- To help in assessing whether a **system is ready for Release**:

  - Estimating / Predicting the performance characteristics (such as response
    time, throughput) which an application is likely to have when it is released
    in to production. The results can help in predicting the satisfaction level
    of the users when interacting with the system. The predicted values can also
    be compared with agreed values (success criteria) for the performance
    characteristics when available.

  - To help in accessing the adequacy of the infrastructure / managed service
    SKUs to meet the desired performance characteristics of a system

  - Identifying bottlenecks and issues with the application at different load
    levels

- To compare the **performance impact of application changes**

  - Comparing the performance characteristics of an application after a change
    to the values of performance characteristics during previous runs (or
    baseline values), can provide an indication of performance issues or
    enhancements introduced due to a change

- To **support system tuning**

  - Comparing performance characteristics of a system for different system
    configurations

- To assist **capacity planning**

  - Capacity planning is the process of determining what type of hardware and
    software resources are required to run an application with the given user
    load. Poor performing applications require more hardware and thus are more
    expensive to operate. Capacity planning involves identifying business
    expectations, the periodic fluctuations of application usage, considering
    the cost of running the hardware and software infrastructure.

- To reduce **downtime**

  - Systems that go down cost money. For every second thought. Amazon Web
    services is down, is a loss of eleven hundred dollars per second. And for
    financial services firms’ downtime could mean lawsuits and customer
    attrition.

## Key Performance Testing categories

Performance testing is a broad topic. There are many areas where you can perform
tests. In broad strokes you can perform tests on the backend and on the front
end. You can test the performance of individual components as well as testing
the end\-to\-end functionality.

There are several categories of tests as well:

### Load Testing

This is the subcategory of performance testing which focuses on validating the
performance characteristics of a system, when the system faces load volumes
which are expected during production operation. **Endurance Test** or **Soak
Test** is a load test carried over a long duration ranging from several hours to
days.

### Stress Testing

This is the subcategory of performance testing which focuses on validating the
performance characteristics of a system when the system faces extreme load. The
goal is to evaluate how does the system handles being pressured to its limits,
does it recover (i.e., scale\-out) or does it just break and fail?

### Endurance testing

The goal of endurance testing is to make sure that the software can maintain
good performance when extended periods of load.

### Spike testing

The goal of Spike testing is to validate that a software system can respond well
to large and sudden spikes.

### Chaos testing

Chaos testing or Chaos engineering is the practice of experimenting on a system
to build confidence that the system can withstand turbulent conditions in
production. Its goal is to identify weaknesses before the manifest system wide.
Developers often implement fallback procedures for service failure. Chaos
testing arbitrarily shuts down different parts of the system to validate that
fallback procedures function correctly.

## Performance monitor metrics

When conducing the various types of testing approaches, whether it is stress,
endurance, spike, or chaos testing, it will be important to capture various
metrics to see how the system performs.

At the basic hardware level, there are four areas to consider.

- Physical disk
- Memory
- Processor
- Network

These four areas are inextricably linked, meaning that poor performance in one
area will lead to poor performance in another area. Engineers concerned with
understanding application performance, should focus on these four core areas.

The classic example of how performs in one area can affect performance in
another area is memory pressure.

If an application's available memory is running low, the operating system will
try to compensate for shortages in memory by transferring pages of data from
memory to disk, thus freeing up memory. But this work requires help from the CPU
and the physical disk.

This means that when you look at performance when there are low amounts of
memory, you will also notice spikes in disk activity as well as CPU.

## Physical Disk

Almost all software systems are dependent on the performance of the physical disk. This is especially true for the performance of databases. More modern approaches to using SSD’s for physical disk storage can dramatically improve the performance of applications. Here are some of the metrics that you can capture and analyze:

### Avg. Disk Queue Length

This value is derived using the (Disk Transfers/sec)*(Disk sec/Transfer) counters.  This metric describes the disk queue over time, smoothing out any quick spikes.  Having any physical disk with an average queue length over 2 for prolonged periods of time can be an indication that your disk is a bottleneck.

### % Idle Time

This is a measure of the percentage of time that the disk was idle. ie. there are no pending disk requests from the operating system waiting to be completed. A low number here is a positive sign that disk has excess capacity to service or write requests from the operating system.

### Avg. Disk sec/Read and Avg. Disk sec/Write

These both measure the latency of your disks. Latency is defined as the average time it takes for a disk transfer to complete.  You obviously want is low numbers as possible but need to be careful to account for inherent speed differences between SSD and traditional spinning disks. For this counter is important to define a baseline after the hardware is installed. Then use this value going forward to determine if you are experiencing any latency issues related to the hardware.

### Disk Reads/sec and Disk Writes/sec

These counters each measure the total number of IO requests completed per second.  Similar to the latency counters, good and bad values for these counters depend on your disk hardware but values higher than your initial baseline don't normally point to a hardware issue in this case.  This counter can be useful to identify spikes in disk I/O.

## Processor

### % Processor time

This is the percentage of total elapsed time that the processor was busy
executing. This counter can either be too high or too low. If your processor
time is consistently below 40%, then there is a question as to whether you
have over provisioned your CPU. 70% is generally considered a good target
number and if you start going higher than 70%, you may want to explore why
there is high CPU pressure.

### % Privileged time

This measures the percentage of elapsed time the processor spent executing in
kernel mode.  Since this counter takes into account only kernel operations a
high percentage of privileged time (greater than 25%) may indicate driver or
hardware issue that should be investigated.

### % User time

The percentage of elapsed time the processor spent executing in user mode
(your application code). A good guideline is to be consistently below 65% as you want to have some buffer for both the kernel operations mentioned above as well as any other bursts of CPU required by other applications.

### Queue Length

This is the number of threads that are ready to execute but waiting for a core to become available.  On single core machines a sustained value greater than 2-3 can mean that you have some CPU pressure.  Similarly, for a multicore machine divide the queue length by the number of cores and if that is continuously greater than 2-3 there might be CPU pressure.

## Network Adapter

Network speed is often a hidden culprit of poor performance. Finding the root
cause to poor performance is often difficult. Often times the source of issues
can come from videoconferencing, transaction data, network backups, recreational
videos.

Packet loss is another area that contributes to poor performance. It occurs when
packets fail to reach their destination, either by errors in the data
transmission or network congestion. Packet loss can also be caused by Dos/DDoS
attacks.

Some of the tools that can help include:

- ifconfig
- netstat
- iperf
- tcpretrans
- tcpdump
- WireShark

For most of these counters below, there are no hard and fast numbers. Wi-Fi
speeds are lower as compared to wired, ethernet speeds. Networking speeds have
increased dramatically over the years. We can expect all the numbers below to
change over time.

| Network Type | Speed  |
|:-------------------- |:--------------------  |
| Basic Wifi Speed | 3 to 8 Mpbs  |
| Moderate Wifi Speed | 10 to 25 Mpbs  |
| Fast Wifi Speed | 300 to 1000 Mbps  |
| Fast Ethernet | 100 Mbps  |
| Gigabit Ethernet | 1,000 Mbps  |
| 10 Gigabit Ethernet | 10,000 Mbps  |

### Network Counters

The table above gives you some reference points to better understand what you
can expect out of your network. Here are some counters that can help you
understand where the bottlenecks might exist:

### Bytes Received/sec

The rate at which bytes are received over each network adapter.

### Bytes Sent/sec

The rate at which bytes are sent over each network adapter.

### Bytes Total/sec

The number of bytes sent and received over the network.

### Segments Received/sec

The rate at which segments are received for the protocol

### Segments Sent/sec

The rate at which segments are sent.

### % Interrupt Time

The percentage of time the processor spends receiving and servicing hardware
interrupts. This value is an indirect indicator of the activity of devices that
generate interrupts, such as network adapters.

> There is an important distinction between **latency** and **throughput**.
**Latency** measures the time it takes for a packet to be transferred across the
network, either in terms of a one\-way transmission or a round\-trip
transmission. **Throughput** is different and attempts to measure the quantity
of data being sent and received within a unit of time.

## Memory

### Available MBs

This counter represents the amount of memory that is available to applications
that are executing. Low memory can trigger Page Faults, whereby additional
pressure is put on the CPU to swap memory to and from the disk. if the amount
of available memory dips below 10%, more memory should be obtained.

### Pages/sec

This is actually the sum of "Pages Input/sec" and "Pages Output/sec" counters which is the rate at which pages are being read and written as a result of pages faults.  Small spikes with this value do not mean there is an issue but sustained values of greater than 50 can mean that system memory is a bottleneck.

### Paging File(_Total)\% Usage

The percentage of the system page file that is currently in use.  This is not directly related to performance, but you can run into serious application issues if the page file does become completely full and additional memory is still being requested by applications.

## Key Performance testing activities

Performance testing activities vary depending on sub category of performance
test, the engagement requirements and constraints. For specific guidance you can
follow the link to the sub category of performance tests listed above. Following
are some activities which will generally be involved:

### Identify and Define the Acceptance criteria for the tests

This will generally include identifying and defining the goals and constrains
for the performance characteristics of the system

### Plan and design the tests

In general we need to consider the following points:

- Defining the load the application would be tested with

- Establishing the metrics to be collected

- Establish which tools will be used for the tests

- Establish the performance test frequency : whether the performance tests be
  done as a part of the feature development sprints, or only prior to release to
  a major environment?

### Test implementation

- Apply the design and create the performance tests based on them

### Test Execution

- Execute the tests and collect the performance metrics. Take note of the
  previous section Around Load Testing, Chaos Testing, Stress and Spike Testing

### Result analysis and re-testing

- The test are executed, the results are collected and the environments are monitored

- The results are analysed

- Depending on the scenario, modification of application or configuration are
  done and testing cycle is repeated again

## Resources

- [Patters and Practices: Performance Testing Guidance for Web
  Applications](https://docs.microsoft.com/en-us/archive/blogs/dajung/ebook-pnp-performance-testing-guidance-for-web-applications)
