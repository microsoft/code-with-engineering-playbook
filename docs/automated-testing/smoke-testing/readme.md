# Smoke Tests

Smoke tests, sometimes named ***Sanity***, ***Acceptance***, or ***Build/Release Verification*** tests, are a sub-type of system/functional tests that are usually used as gates that verify the application's readiness as a preliminary step. If an application passes the smoke tests, it is acceptable, or in a stable-enough state, for the next stages of testing or deployment.

## When To Use

### Problem Addressed

Smoke tests are meant to find, as early as possible, if an application is working or not. The goal of smoke tests is to save time; if the current version of the application does not pass smoke tests, then the rest of the integration or deployment chain for it can be abandoned. Smoke tests do not aim to provide full functionality coverage but instead focus on a few quick acceptance invocations for which the application should, at all times, respond correctly to.

### ROI Tipping Point

Smoke tests cover only the most critical application path, and should not be used to actually test the application's behaviour, keeping execution time and complexity to minimum. The tests can be formed of a subset of the application's integration or e2e tests, and they cover as much of the functionality with as little depth as required.

The golden rule of a good smoke test is that it saves time on validating that the application is acceptable to a stage where better, more thorough testing will begin.

### Applicable to

- [x] **Local dev desktop** - *Example:* Applying manual smoke testing to verify that the application is OK.
- [x] **Build pipelines** - *Example:* Running a small set of the integration test suite before running the full coverage of tests, which may take a long time.
- [x] **Non-production and Production deployments** - *Example:* Running a curl command to the product's API and asserting the response is 200 before running load test which consume resources.
- [x] **PR Validation** - *Example:* - Deploying the application chart to a test namespace and validating the release is successful and no immediate regressions are merged.

## Conclusion

Smoke testing is a low-effort, high-impact step to ship more reliable software. It should be considered amongst the first stages to implement when planning continuously integrated and delivered systems.

## Resources

- [Wikipedia - Smoke Testing](https://en.wikipedia.org/wiki/Smoke_testing_(software))
- [Google SRE Book - System Tests](https://landing.google.com/sre/sre-book/chapters/testing-reliability/#system-tests)
