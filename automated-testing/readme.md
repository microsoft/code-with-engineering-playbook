# Testing

## Unit vs Integration vs System vs E2E Testing

To better understand which testing methodology when to apply it in your project, the below table illustrates the most critical characteristics and differences between Unit, Integration, System and End-to-End testing:

| Unit Test | Integration Test | System Testing | E2E Test |
|-----------|------------|------|----------|
A module, APIs | Modules, Interfaces | Application, System | All sub-systems, network dependencies, services and databases |
Tiny | Small to Medium | Large | X-Large |
Dev Environment | Integration test Environment | QA test environment | Production like real environment |
Mock data | Test data | Test data | Copy of real production data |
Isolated unit test | Tests interfaces and flow data between the modules | Tests a particular system as a whole | Tests an application flow from start to end |
The test scenarios use developers perspectives | The test scenarios use developers and IT Pro testers perspectives | The test scenarios use the developers and QA testers perspectives | The test scenarios use the end-user perspectives |
Unit testing happens after each build | Integration test happens after Unit testing | System testing happens before the E2E testing and after Unit and Integration testing | E2E testing happens after System testing |
Automation testing | It can be manual or automation testing | It can be manual or automation testing | It can be manual or automation testing |

## Sections within Testing

- [Unit testing](unit-testing/readme.md)
- [Integration testing](integration-testing/readme.md)
- [End-to-End testing](e2e-testing/readme.md)
- [UI testing](ui-testing/readme.md)
- [Synthetic Monitoring testing](synthetic-monitoring-tests/readme.md)
- [Performance testing](performance-testing/readme.md)
