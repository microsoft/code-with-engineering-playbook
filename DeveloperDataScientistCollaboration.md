# The Developer and the Data Scientist Should be Friends
_Dan Massey_

**About the author**: Dan has run an engineering organization in Bing that included two data science teams and three SDE groups that worked together to ship intelligent services in Xbox, Windows, Windows Phone, Office, and Cortana. Dan has run DevOps for services at Microsoft and other places.

## Overview

Congratulations! You're on an engagement that involves machine learning. This is going to be fun, but you might be wondering what to expect.
Let's start with some **context**.

1. Our goal is to code with customers to solve tier 1 business problems in production.
2. We will bring the same level of commitment to engineering fundamentals to ML engagements that we bring to other engagements.
3. In CSE we embrace T-shaped skill sets. We expect everyone to have broad exposure to Azure and to be competent in our engineering fundamentals. We also expect each dev or data scientist to have deep expertise in a particular area.
4. We also want people to be able to upskill on projects by working with experts in areas in which they are not currently experts.

## Team

We assemble a **team**, including:

1. SE/I
2. Tech Lead
3. PM
4. Data Science lead
5. One or more dev crews
6. Any other data scientists
7. Any SE/Ts
8. Developers, data experts, and other stakeholders from the customer or the customer's catcher

## Framing the Problem

The first thing the team should agree on is, "What customer problem are we solving?" That is quickly followed by, "How will we know if we are successful?" The answer to the second question should almost always take the form of a metric*, "85% end customer scenario success, as measured by...".

## Preparing the Customer

On most of our ML projects, we spend weeks ahead of any on-site sprints working with the customer to identify and prepare data for use in training and validation. At this point, we should also build a shared understanding with the customer of what a data science program looks like, including bootstrapping, running ML in production, engineering solutions around ML, and maintaining models. 

## Engineering with ML/AI

### Resilience

ML models are not perfect. Systems should continue to work even when ML models produce wrong outputs. Many intelligent systems require more than one model,often produced on different algorithm. Systems should strive for a result that is better than the combination of the capabilities of the individual models. We can easily build systems that compound errors. It is a more challenging engineering problem to build a system that accounts for the error rates of different parts of the system to produce more robust results. Bing and Cortana, which uses the Bing stack, are built so that the interactions of all the classifiers and rankers and other models involved lead to better results than you might expect from the results of any constituent model.

### DevOps

ML also comes with special DevOps responsibilities. Can we learn from usage? Can we evaluate new models for regressions? Can we characterize our training data and expected output ranges to monitor for inputs and outputs to models that are well outside of expected or trained parameters? Can we measure for bias in the production system? Can we easily "forget" some training data as when required for some GDPR scenarios? Can we explain or debug ML outputs when needed? (Sometimes explainable models/algorithms are better than models/algorithms that produce better results.) 

### Upskilling

It's this combination of engineering and data science that powers Microsoft's intelligent services. We want to bring this experience to our customers. As part of this process, we expect some cross-pollination: developers get experience with ML training and evaluation and data scientists get experience with DevOps and production monitoring of ML. However, becoming an expert in either of these areas, at the level expected in big tech companies like Microsoft, is a full-time commitment. We build our engineering processes around these highly valuable areas of expertise. Luckily, Microsoft provides plenty of opportunities for us to work together as well as paths from one area of expertise to the other.

## Tips

**Start with the measures and metrics** - Always start with system success, "better architecture".
 
**Simple scales and is easier to understand** - Algorithm may be complex and there may be a lot of science behind the models, but the individual components should be relatively simple and easy to understand. The complexity in the behaviors comes from composition.
 
**Layers** - Layers are an amazing organizing principle when operating at scale. Layers make systems like Bing understandable. It's counterintuitive, but adding layers can also drop latencies, when done correctly. This applies to ML too. Often, the best answer is to compose a chorus of models under some other ML model or to compose ML in an easy to understand pipeline.
 
**Automation** - AutoPilot does not go far enough in terms of scaling and isolation, but it does a lot to help with DevOps.
 
**Observability** - If you can't see into your running system, you are unlikely to understand how to modify it.
 
**Feature flags and flighting** - When you deploy new code, no behavior should change. You use feature flags and flighting to turn on new behaviors. This makes service deployment much more reliable. If you see a change to your operational measures when you roll out new bits, you immediately rollback. 

\* Measures and a metrics are two different, but related, ideas.


