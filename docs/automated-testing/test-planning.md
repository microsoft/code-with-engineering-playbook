# Test planning

We should be intentional when we think about how to test our applications. One way to make sure that we are testing the right things is to build test plans for various scenarios and work out test cases at the design stage of a user story.

This content aims to show some ways we can think about planning and give some examples using a web site with a login portal as an example.

## Building test cases for a user story

As we design the code for a user story we can start by defining a set of test cases that will ensure that all acceptance criteria are met.

This can be done as an exercise that includes both the developers and other stakeholders. Some of the test cases may initially be manual, and some may be planned for automation, depending on the situation.

Going through this exercise doesn't only produce test cases, it also helps clarify the acceptance criteria and informs how we should build the solution.

1. Understand the Acceptance Criteria
    - Thoroughly read and understand the acceptance criteria for the story
    - Clarify any ambiguities with the product owner or stake holders

2. Identify Test Scenarios
    - Consider both positive and negative scenarios (happy paths, and error cases) to cover edge cases
    - Determine what is in and out of scope, i.e. do we only test functional requirements, or are non-functional requirements such as security, accessibility, reliability etc. in scope for testing?

3. Define Test Cases
    - For each test scenario, define detailed test cases
    - Each test case should be documented with
        - **TestCase Title:** What is being tested
        - **Preconditions:** Any setup or test data required before executing the test
        - **Test Steps:** Step-by-step instructions to execute the test
        - **Expected Result:** The expected outcome of the test

    The test can be described in the Given-When-Then format to make it clear and concise:

    **Given** the initial context or state, **When** the action or event, **Then** the precise outcome

4. Automate where Possible
    - If feasible, automate the test cases
    - Focus on automating hot paths, and critical areas

5. Review and Refine
    - Review the test cases with peers or stakeholders to ensure that we have covered everything we want to cover, and that expected outcomes are correct
    - Refine the test cases based on feedback

### Examples of Test Cases using the Given-When-Then Format

| User Login | (Positive Test Case) |
| -- | -- |
| **Title** | Verify user login with valid credentials |
| **Preconditions** | User is on the login page |
| **Test Steps** | **Given** the user is on the login page **When** the user enters valid credentials and clicks the login button **Then** the user should be redirected to the dashboard |
| **Expected Result** | User is successfully logged in and redirected to the dashboard |

| User Login with Invalid Credentials | (Negative Test Case) |
| -- | -- |
| **Title** | Verify user login with invalid credentials |
| **Preconditions** | User is on the login page |
| **Test Steps** | **Given** the user is on the login page **When** the user enters invalid credentials and clicks the login button **Then** the user should se an error message indicating invalid username or password |
| **Expected Result** | Error message is displayed and the user remains on the login page |

| Security Testing for Login Page | (Non-Functional Requirement) |
| -- | -- |
| **Title** | Verify that the login page is protected against SQL injection attacks |
| **Preconditions** | User is on the login page |
| **Test Steps** | **Given** the user is on the login page **When** the user enters a SQL injection string (e.g. ' OR '1'=1) in the username field and clicks the login button **Then** the system should not allow login and should display an error message |
| **Expected Result** | The system prevents login and displays an error message |

| Usability Testing for Form Validation | (Non-Functional Requirement) |
| -- | -- |
| **Title** | Verify that the registration form provides clear error messages for invalid inputs |
| **Preconditions** | User is on the registration page |
| **Test Steps** | **Given** the user is on the registration page **When** the user enters invalid data (e.g. incorrect email format) and submits the form **Then** the system should display a clear and specific error message indicating the issue |
| **Expected Result** | Clear and specific error message is displayed |

| Reliability Testing for System Uptime | (Non-Functional Requirement) |
| -- | -- |
| **Title** | Verify that the system maintains 99.9% uptime over a month |
| **Preconditions** | System is monitored over a month |
| **Test Steps** | **Given** the system is up and running **When** the system is monitored for uptime over a month **Then** the system should maintain 99.9% uptime |
| **Expected Result** | System maintains 99.9% uptime over the monitored period |

## Grouping Test Cases into Test Plans

We can create different test plans, such as a full regression test plan, a smoke test plan, a functional test plan etc. and organize the test cases under these test plans.

A few benefits of creating test plans are:

- We can make sure that all aspects of the application are tested, including functional, non-functional and edge cases
- They provide clear objectives and scope, which helps developers understand what needs to be tested
- They help manage and execute tests systematically, i.e. we have a suite of tests to run validate integration etc.
- By identifying and prioritizing test cases based on risk, test plans help us focus on the most critical areas of the application.
- In some industries they are required for compliance with standards and regulation.
- They help us understand what tests are most important to automate

### Common Test Plans

Here are some examples of test plans we may want to create for our systems:

#### Full Regression Test plan

**Purpose:** To verify that recent changes have not adversely affected existing functionality
**Test Cases Included:**

- All functional test cases
- All integration test cases
- All system test cases
- All previously reported bugs that have been fixed

**Example:**

- Test001: Verify user login with valid credentials
- Test002: Verify user registration with valid details
- Test003: Verify password reset functionality

#### Smoke Test plan

**Purpose:** To perform a quick check to ensure that the most critical functionalities of the application are working
**Test Cases Included:**

- Basic functionality test cases
- High-priority test cases that cover the core features

**Example:**

- Test001: Verify user login with valid credentials
- Test004: Verify adding an item to the shopping cart
- Test005: Verify search functionality with a valid keyword

#### Functional Test Plan

**Purpose:** To verify that each function of the software application conforms to the specification
**Test Cases Included:**

- Test cases that validate specific functionality
- Test cases that cover user interactions and business logic

**Example:**

- Test002: Verify user registration with valid details
- Test006: Verify user login with invalid credentials
- Test005: Verify user registration with missing requirement fields

#### Area Regression Test Plan

**Purpose:** To verify that changes in a specific area of the application have not affected other parts of the application
**Test Cases Included:**

- Test cases related to the specific area where changes were made
- Test cases that cover the integration points of the affected area

**Example:** If changes were made to the user profile model

- Test008: Verify password reset functionality with an invalid email address
- Test009: Verify updating user profile information
- Test010: Verify changing user password

### Other Test Plan Examples

Here are some additional examples of test plans:

#### Integration Test Plan

To verify that different modules or services of the application work together as expected

- Test cases that validate the interaction between different modules
- Test cases that check data flow between integrated components

#### User Acceptance Test (UAT) Plan

To ensure the system meets the business requirements and is ready for production use

- Test cases based on real-world scenarios and user stories
- Test cases that validate end-to-end business processes

#### Load Test Plan

To determine how the system performs under heavy load conditions

- Test cases that simulate high user traffic
- Test cases that measure response times and system behavior under load

#### Security Test Plan

To identify and mitigate security vulnerabilities in the application

- Test cases that check for common security issues like SQL injection, XSS, and CSRF
- Test cases that validate user authentication and authorization mechanisms

#### Compatibility Test Plan

To ensure the application works across different devices, browsers, and operating systems

- Test cases that validate functionality on various devices and browsers
- Test cases that check for consistent user experiences across platforms

#### Recovery Test Plan

To verify the system's ability to recover from crashes, hardware failures, or other catastrophic problems

- Test cases that simulate system failures and recovery processes
- Test cases that validate data integrity after recovery

#### Localization Test Plan

To ensure the application is correctly adapted for different languages and regions

- Test cases that validate language translations
- Test cases that check for region specific content

### How to Group Test Cases into a Test Plan

1. **Identify the Scope:** Determine the scope of each test plan based on testing objectives
2. **Select Relevant Test Cases:** Chose test cases that align with the scope and objectives of each test plan
3. **Organize Test Cases:** Group the selected test cases into the respective test plans
4. **Review and Validate:** Review the grouped test cases to ensure they cover all necessary aspects and validate them with stakeholders if needed
5. **Document the Test Plans:** Clearly document each test plan, including the purpose, scope, and list of test cases

## Resources

- [The One Page Test Plan](https://www.ministryoftesting.com/articles/the-one-page-test-plan)
- [One-Page Test Plan | Write your Plan in Minutes](https://www.youtube.com/watch?v=BYN6AFhR4GE)
