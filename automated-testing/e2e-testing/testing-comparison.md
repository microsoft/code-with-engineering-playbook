# Unit vs Integration vs System vs E2E Testing

The table blow illustrates the most critical charactersitics and differences among Unit, Integration, System, and End-to-End Testing, and when to apply each metholodology in a project.

|  | Unit Test | Integration Test | System Testing | E2E Test |
|----|-----------|------------|------|----------|
| **Scope** | Modules, APIs | Modules, Interfaces | Application, System | All sub-systems, network dependencies, services and databases |
| **Size** | Tiny | Small to Medium | Large | X-Large |
| **Environment** | Development | Integration test | QA test | Production like |
| **Data** | Mock data | Test data | Test data | Copy of real production data |
| **SUT** | Isolated unit test | Tests interfaces and flow data between the modules | Tests a particular system as a whole | Tests an application flow from start to end |
| **Scenarios** | Developer perspectives | Developers and IT Pro tester perspectives | Developer and QA tester perspectives | End-user perspectives |
| **When it happens** | After each build | After Unit testing | Before the E2E testing and after Unit and Integration testing | After System testing |
**Automated or Manual** | Automation | Manual or automated  | Manual or automated | Manual |
