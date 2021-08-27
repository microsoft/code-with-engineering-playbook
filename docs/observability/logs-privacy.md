# Guidance for Privacy

## Overview

To ensure the privacy of your system users, as well as comply with several regulations like GDPR, some types of data shouldn’t exist in logs.
This includes customer's sensitive, Personal Identifiable Information (PII), and any other data that wasn't legally sanctioned.

### Recommended Practices

1. Separate components and minimize the parts of the system that log sensitive data.
2. Keep sensitive data out of URLs, since request URLs are typically logged by proxies and web servers.
3. Avoid using PII data for system debugging as much as possible. For example, use ids instead of usernames.
4. Use Structured Logging and include a deny-list for sensitive properties.
5. Put an extra effort on spotting logging statements with sensitive data during code review, as it is common for reviewers to skip reading logging statements. This can be added as an additional checkbox if you're using Pull Request Templates.
6. Include mechanisms to detect sensitive data in logs, on your organizational pipelines for QA or Automated Testing.

### Tools and Implementation Methods

Use these tools and methods for sensitive data de-identification in logs.

#### Application Insights

Application Insights offers telemetry interception in some of the SDKs, that can be done by implementing the `ITelemetryProcessor` interface.
ITelemetryProcessor processes the telemetry information before it is sent to Application Insights, and can be useful in many situations, such as filtering and modifications. Below is an example of intercepting 'trace' typed telemetry:

```csharp
using Microsoft.ApplicationInsights.DataContracts;

namespace Example
{
    using Microsoft.ApplicationInsights.Channel;
    using Microsoft.ApplicationInsights.Extensibility;

    internal class RedactTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            var requestTelemetry = telemetry as TraceTelemetry;
            if (requestTelemetry == null) return;
            # redact emails from the message parameter
            requestTelemetry.Message = Regex.Replace(requestTelemetry.Message, @"[^@\s]+@[^@\s]+\.[^@\s]+", "[email removed]");
        }
    }
}
```

#### Elastic Stack

Elastic Stack (formerly "ELK stack") allows logs interception by Logstash's [filter-plugins](https://www.elastic.co/guide/en/logstash/current/filter-plugins.html).
Using some of the existing plugins, like 'mutate', 'alter' and 'prune' might be sufficient for most cases of deidentifying and redacting PIIs.
For a more robust and customized use-case, a 'ruby' plugin can be used, executing arbitrary Ruby code.
Filter plugins also exists in some Logstash alternatives, like [Fluentd](https://docs.fluentd.org/filter) and [Fluent Bit](https://docs.fluentbit.io/manual/pipeline/filters).

#### Presidio

[Presidio](https://github.com/microsoft/presidio) offers data protection and anonymization API. It provides fast identification and anonymization modules for private entities in text.
Presidio allows using predefined or custom PII recognizers, leveraging Named Entity Recognition, regular expressions, rule based logic and checksum with relevant context in multiple languages.
It can be used alongside the log interception methods mentioned above to help and ensure sensitive data is properly managed and governed.
Presidio is containerized for REST HTTP API and also can be installed as a python package, to be called from python code.
Instead of handling the anonymization in the application code, both APIs can be used using external calls.
Elastic Stack, for example, can handle PII redaction using the 'ruby' filter plugin to call Presidio in REST HTTP API, or by calling a python script consuming Presidio as a package:

`logstash.conf`

```ruby
input {
    ...
}

filter {
   ruby {
    code => 'require "open3"
             message = event.get("message")
             # Call a python script triggering Presidio analyzer and anonymizer, and printing the result.
             cmd =  "python /path/to/presidio/anonymization/script.py \"#{message}\""
             # Fetch the script's stdout
             stdin, stdout, stderr = Open3.popen3(cmd)
             # Override message with the anonymized text.
             event.set("message", stdout.read)
             filter_matched(event)'
   }
}

output {
    ...
}
```
