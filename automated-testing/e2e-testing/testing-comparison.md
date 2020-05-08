# Unit vs Integration vs System vs E2E Testing

To better understand which testing methodology when to apply it in your project, the below table illustrates the most critical characteristics and differences between Unit, Integration, System and End-to-End testing:

| **Characteristics** | Unit Test | Integration Test | System Testing | E2E Test |
|----|-----------|------------|------|----------|
**Scope** | A module, APIs | Modules, Interfaces | Application, System | All sub-systems, network dependencies, services and databases |
**Size** | Tiny | Small to Medium | Large | X-Large |
**Environment** | Development | Integration test | QA test | Production like |
**Data** | Mock data | Test data | Test data | Copy of real production data |
**SUT** | Isolated unit test | Tests interfaces and flow data between the modules | Tests a particular system as a whole | Tests an application flow from start to end |
**Scenarios** | The test scenarios use developers perspectives | The test scenarios use developers and IT Pro testers perspectives | The test scenarios use the developers and QA testers perspectives | The test scenarios use the end-user perspectives |
**When it happens** | Unit testing happens after each build | Integration test happens after Unit testing | System testing happens before the E2E testing and after Unit and Integration testing | E2E testing happens after System testing |
**Automated or Manual** | Automation testing | It can be manual or automation testing | It can be manual or automation testing | It is a manual testing |
