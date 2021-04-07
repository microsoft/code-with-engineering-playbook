# Unit vs Integration vs System vs E2E Testing

The table below illustrates the most critical characteristics and differences among Unit, Integration, System, and End-to-End Testing, and when to apply each methodology in a project.

|  | Unit Test | Integration Test | System Testing | E2E Test |
|----|-----------|------------|------|----------|
| **Scope** | Modules, APIs | Modules, interfaces | Application, system | All sub-systems, network dependencies, services and databases |
| **Size** | Tiny | Small to medium | Large | X-Large |
| **Environment** | Development | Integration test | QA test | Production like |
| **Data** | Mock data | Test data | Test data | Copy of real production data |
| **System Under Test** | Isolated unit test | Interfaces and flow data between the modules | Particular system as a whole | Application flow from start to end |
| **Scenarios** | Developer perspectives | Developers and IT Pro tester perspectives | Developer and QA tester perspectives | End-user perspectives |
| **When** | After each build | After Unit testing | Before E2E testing and after Unit and Integration testing | After System testing |
**Automated or Manual** | Automated | Manual or automated  | Manual or automated | Manual |
