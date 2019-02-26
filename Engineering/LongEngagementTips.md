# Tips for CSE's Longer Code-With Engagements 
_Dan Massey_

## Overview 

CSE has myriad super powers, including deep industry-rooted customer technical engagement, structured hacks, product team collaboration, and code-with engagements. I'm focusing on the longer variety of the code-with engagements here, because it's the area that gets most of my attention. I've had the opportunity to engage as an IC on some code-with engagements and to facilitate retrospectives for some of our more challenging engagements. I also get to see many code-with engagement checkpoint reviews and game plans. In the spirit of cross-pollination, I would like to share some tips that I learned from CSE engagement crews.

## Terminology

It's useful to have some common terms for the items below. We have agreed that the compound adjective "code-with" refers to the whole engagement. On-site sprints, also just referred to as sprints, can mean either sprints our engagement crew spends at a customer or partner (henceforth collectively referred to as customer) site or sprints a customer's team spends on site with our engagement crew. Prep sprints and wrap-up or follow-up sprints refer to the work done on either side of on-site sprints. A CSE engagement crew for a longer code-with engagement includes some or all of: an SE/I, a tech lead, a data science lead, a PM, one or more durable dev crews (potentially with additional leads), any number of SE/Ts, other data scientists, participants from EE&ST.


## Tips

1. Make sure the basics are in place, including a clear and shared understanding of the business problem we're solving together and a committed catcher for the project.

2. A one or two page onboarding document with a summary of the business problem and proposed solution is also helpful to get the crew aligned.

3. Know how you will measure your solution's success before you write a line of code. Concrete and quantified measures are great. A true metric, which includes a standard for the measurement, is even better.

4. Optimize for the quality, not quantity or hastiness, of on-site sprints. We tell ourselves that an on-site sprint is just another sprint, so that we maintain engineering discipline and share our best practices with our customers. However, we have prep sprints for a reason. We want to have enough of the technical pieces in place to make real code-level progress with customer developers when on site with customers. Know what should be done before an on-site sprint begins and push the sprint out if you aren't ready to succeed. Shortcutting prep sprints to get on site with a customer faster or more frequently is a recipe for engagement issues and heroic effort.

5. Use the engagement backlog to prioritize the tasks and stories that best set you up for working collaboratively with the customer on the hard problems. For example, the crew should swarm on CI/CD and end-to-end system spikes early. Some crews have also started to include a level of observability in the basics to swarm on early. Get those working before developers take on other tasks.

6. Someone else is going to write up what we're recommending for including ML in engagement backlogs. It's very much along the lines of tip 5. Quick summary: Get any, probably horrible, model working in the end-to-end very early in the project. Then drive the data science with hypothesis stories.

7. Manage your risk through backlog prioritization and shorter sprints. In a four-to-twelve week engagement, one-week sprints are the longest increment you should be willing to bust. If you typically choose two-week sprints, because one-week sprints involve too much overhead, get more efficient at scrum practices. We even have some crews who run exemplary one-day sprints for the week they are on site with a customer. This makes sense, because even one day is almost too much to risk when you're on site. To sum up this point: swarm on the fundamentals first and give yourself many opportunities to adjust the crew's priorities.

8. Use your wrap-up sprints to tie up loose ends from the on-site sprint. Use them to clean up anything the customer is going to take over that you aren't yet proud of, including documentation and open bugs and tasks. Use them to give your crew some recovery time. Being on site with a customer has performance and social components that require additional energy. Do not schedule back-to-back on sites with a customer, even if you're alternating locales.

9. The 2 prep weeks, 1 on-site week, and 1 wrap-up week milestone template comes from experience. You can adjust it as needed, but any adjustments should be about more prep or wrap-up time per on-site week, not less. It's acceptable to tell a customer or account team, "We know you want us there sooner, but in our experience these engagements are more effective if we..." Many SE/Is and crew tech leads have also become good at using shorter ADSes, kick-offs, or game plan sessions to get in some time on site before real sprints begin.

10. The crew leadership should start using the backlog as early as the ADS or game plan sessions to assign spikes to individual crew devs. This is an effective way to manage risk and to starting bringing the whole crew into the project. The best game plan reviews have evidence that spikes have already started to answer the hard technical questions.
Include necessary experts. If your design calls for Helm and no one currently on the crew is a Helm expert, for example, request an SE/T or someone from EE&ST who is.

12. Keep the technical solutions simple. Don't include pieces of Azure just to have them. Don't compose more containers than you strictly need. Don't start with ML when something simpler will do. Don't write code that you might need some day in the future. It's easier to build, monitor, and hand off simple solutions. You're also less likely to leave the customer with incomplete pieces.

13. Occasionally, we will end up in a bake-off situation or some other form of code-for engagement that does not follow our normal code-with template. Acknowledge that explicitly with the whole crew and make the adjustments necessary to create a sustainable project plan for the people working on it.


## Prep Sprints Scope and Deliverables

We start from the premise that prep-sprints are code-with sprints. They're just not on site. We expect the crew and customer to plan, standup, demo, and retro together, even before the on-site sprint. The customer's developers might work on the items below with our crew before we're on site. The tech lead is accountable for applying CSE's engineering fundamentals*: CI/CD, unit tests, code reviews, and retrospectives.
 
* **Business problem** - Everyone on the crew should understand the business problem we're solving, including the business process context and key measures. A one to three page document with a couple of diagrams should be sufficient.

* **Backlog** - It's hard to have an efficient on-site sprint if you aren't starting with a prioritized backlog of stories with acceptance criteria. We should also have some tasks broken out for stories at the top of the backlog.

* **CI/CD** - In most cases, it's more powerful if we have smooth CI/CD running before we get on site. The customer can see us assemble it during prep sprints and we can always walk them through it and provide documentation for it, but everything runs smoother on site if it's already in place. Every PR can have visible value when we're on site.

* **End-to-end** - At least the simplest version of each part of the system should exist in an end-to-end development environment that deploys via CI/CD. Either before the first sprint or as part of one of the prep-sprint demos, we should have a code-level design walkthrough that serves as the demo of the architecture. That's after the team has done design and design review tasks as part of prep-sprints. Design reviews and design communication are an area we have identified for improvement based on our engineering fundamentals surveys among durable dev crews. All of this is designed to make sure that everyone understands the pieces of the architecture and how it goes together and can contribute to any piece. This helps with lower level design decisions, planning, stand ups, etc.

* **Measurement** - We should know what about the system is important to measure and how we're going to measure it. Ideally, some automated measurement system will be in place before the on-site sprint.

* **Example tests** - We should make it easy for customers to see how we test code and modules that will run in Azure or otherwise take Azure dependencies.

* **Data** - This is a common focus for data scientists in prep sprints. We should understand the data the customer has versus what we believe we will need to solve data science-related problems. Prep-sprints are a good time to work on data cleaning and understanding data sets. We will postpone on-site sprints if we are not comfortable with the data available for data-heavy projects. Let's even get a dumb model in place, so we know we can deploy models and run them as part of the end-to-end.

* **Crew cadence** - Everyone should be comfortable with our stand ups, PR reviews, planning, demos, retros, etc.

* **Monitoring** - The basic services implemented for the end-to-end should have at least some basic logging, both for examples and to make debugging easier in the dev environment.

It looks like a lot, but this is what we do every day. If we show up with this, we can focus on working with the customer, frequently using paired programming, to get the real business logic running in the system. In many cases, our customers learn the next level in some of these disciplines from us. It's easier to communicate the value by showing up with them. Then we have ways to make sure the customer knows how to do it for themselves the next time.

 
\* We started with four, but we are adding more, now that we're seeing good consistency in the first set. Observability/monitoring, security, and privacy are our next candidates.
