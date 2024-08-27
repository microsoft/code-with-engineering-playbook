# Diagnostic tools

Besides [Logging](./pillars/logging.md), [Tracing](./pillars/tracing.md) and [Metrics](./pillars/metrics.md), there are additional tools to help diagnose issues when applications do not behave as expected. In some scenarios, analyzing the memory consumption and drilling down into why a specific process takes longer than expected may require additional measures. In these cases, platform or programming language specific diagnostic tools come into play and are useful to debug a memory leak, profile the CPU usage, or the cause of delays in multi-threading.

## Profilers and Memory Analyzers

There are two types of diagnostics tools you may want to use: profilers and memory analyzers.

### Profiling

Profiling is a technique where you take small snapshots of all the threads in a running application to see the stack trace of each thread for a specified duration. This tool can help you identify where you are spending CPU time during the execution of your application. There are two main techniques to achieve this: CPU-Sampling and Instrumentation.

CPU-Sampling is a non-invasive method which takes snapshots of all the stacks at a set interval. It is the most common technique for profiling and doesn't require any modification to your code.

Instrumentation is the other technique where you insert a small piece of code at the beginning and end of each function which is going to signal back to the profiler about the time spent in the function, the function name, parameters and others. This way you modify the code of your running application. There are two effects to this: your code may run a little bit more slowly, but on the other hand you have a more accurate view of every function and class that has been executed so far in your application.

#### When to use Sampling vs Instrumentation?

Not all programming languages support instrumentation. Instrumentation is mostly supported for compiled languages like .NET and Java, and some languages interpreted at runtime like Python and Javascript. Keep in mind that enabling instrumentation can require to modify your build pipeline, i.e. by adding special parameters to the command line argument. You should normally start with Sampling because it doesn't require to modify your binaries, it doesn't affect your process performance, and can be quicker to start with.

Once you have your profiling data, there are multiple ways to visualize this information depending of the format you saved it. As an example for .NET (dotnet-trace), there are three available formats to save these traces: Chromium, NetTrace and SpeedScope. Select the output format depending on the tool you are going to use. [SpeedScope](https://www.speedscope.app/) is an online web application you can use to visualize and analyze traces, and you only need a modern browser. Be careful with online tools, as dumps/traces might contain confidential information that you don't want to share outside of your organization.

### Memory Analyzers

Memory analyzers and memory dumps are another set of diagnostic tools you can use to identify issues in your process.  Normally these types of tools take the whole memory the process is using at a point in time and saves it in a file which  can be analyzed. When using these types of tools, you want to stress your process as much as possible to amplify whatever deficiency you may have in terms of memory management. The memory dump should then be taken when the process is in this stressed state.

In some scenarios we recommend to take more than one memory dump during the reproduction of a problem. For example, if you suspect a memory leak and you are running a test for 30 min, it is useful to take at least 3 dumps at different intervals (i.e. 10, 20 & 30 min) to compare them with each other.

There are multiple ways to take a memory dump depending the operating system you are using. Also, each operating system has it own debugger which is able to load this memory dump, and explore the state of the process at the time the memory dump was taken.

The most common debuggers are:

- Windows - [WinDbg and WinDgbNext](https://learn.microsoft.com/en-us/windows-hardware/drivers/debugger/debugger-download-tools) (included in the Windows SDK), [Visual Studio](https://visualstudio.microsoft.com/) can also load a memory dump for a .NET Framework and .NET Core process
- Linux - [GDB is the GNU Debugger](https://www.gnu.org/software/gdb/)
- Mac OS - [LLDB Debugger](https://lldb.llvm.org/)

There are a range of developer platform specific diagnostic tools which can be used:

- [.NET Core diagnostic tools](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/#net-core-diagnostic-global-tools), [GitHub repository](https://github.com/dotnet/diagnostics)
- [Java diagnostic tools - version specific](https://docs.oracle.com/en/java/javase/16/troubleshoot/general-java-troubleshooting.html)
- [Python debugging and profiling - version specific](https://docs.python.org/3/library/debug.html)
- [Node.js Diagnostics working group](https://github.com/nodejs/diagnostics)

## Environment for Profiling

To create an application profile as close to production as possible, the environment in which the application is intended to run in production has to be considered and it might be necessary to perform a snapshot of the application state [under load](../automated-testing/performance-testing/README.md).

### Diagnostics in Containers

For monolithic applications, diagnostics tools can be installed and run on the VM hosting them. Most scalable applications are developed as [microservices](./microservices.md) and have complex interactions which require to install the tools in the containers running the process or to leverage a sidecar container (see [sidecar pattern](https://learn.microsoft.com/en-us/azure/architecture/patterns/sidecar)). Some platforms expose endpoints to interact with the application and return a dump.

#### Resources

- [.NET Core diagnostics in containers](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/diagnostics-in-containers)
- [Experimental tool dotnet-monitor](https://devblogs.microsoft.com/dotnet/introducing-dotnet-monitor/), [What's new](https://devblogs.microsoft.com/dotnet/whats-new-in-dotnet-monitor/), [GItHub repository](https://github.com/dotnet/dotnet-monitor/tree/main/documentation)
- [Spring Boot actuator endpoints](https://docs.spring.io/spring-boot/docs/current-SNAPSHOT/reference/htmlsingle/#actuator.endpoints)
