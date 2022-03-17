# The role of a TPM in AI projects?

Jack opened his notebook and started churning out python code, he and
Jane were so close to increasing the accuracy of their image detection
model to 95%. Voila!! they could now distinguish a Cat from a Dog (I
know, another Cat-Dog cliché). Time to push this into production and
party! And then someone asked, what customer problem are we solving?

In most Artificial Intelligence (AI) projects, the Machine Learning (ML)
component is a part of an overall business problem and NOT the problem
itself. A Technical Program Manager (TPM) can play a vital role in the
realization of value for Machine Learning within the larger scope of a
project. We explore some of these considerations and suggest
recommendations for TPMs to better up-skill for projects with a ML
Component.

**Is this an AI problem?**

Identifying of value for ML is very important in the early phases of the
project. As a TPM, we need to determine the overall business problem
first and then evaluate if ML can help address a part of the problem
space. Few considerations here:

-   Engage experts in human experience and employ techniques such as
    [Design
    Thinking](https://www.ideou.com/blogs/inspiration/what-is-design-thinking)
    to understand the customer needs and human behavior first. For
    example, if your customer wants to talk about [Topic
    Modeling](https://en.wikipedia.org/wiki/Topic_model) instead of
    [Personas](https://en.wikipedia.org/wiki/Persona_(user_experience)),
    you are having the wrong conversation.

-   Focus on System Design principles to identify the architectural
    components, entities, interfaces, constraints. Ask the right
    questions early and explore design alternatives with the engineering
    team. **Mona Soliman Habib**, Principal Data and Applied Scientist
    at Microsoft considers this to be one of the core fundamentals of a
    ML Focused project where TPMs can have significant impact.

-   Think hard about the costs of ML and whether you can solve a
    repetitive problem at scale. Many a times, you can solve customer
    problems with data analytics, dashboards, or rule-based algorithms.
    I know not so cool, but true!

**Taming the ambiguity beast**

Ok, so you figured, Machine Learning might help in your project, now
what?

ML projects are plagued with a phenomenon I call as the "**Death by
Unknowns**". It's like you were told that angels will meet you at the
end of a dark tunnel, but no one mentioned that there are Merpeople,
Trolls and a Basilisk waiting for you (Harry Potter fans are smiling J).
Unlike software engineering projects, ML focused projects can result in
quick success early (aka sudden decrease in error rate), but this may
flatten eventually. Few things to consider:

-   The most important thing as TPM here is to set expectations. If the
    customer wants \> 95% accuracy with limited data and time, they are
    living in Lala land. Identify the performance metrics and discuss on
    a "good enough" prediction rate that will bring value to the
    business. An 80% "good enough" rate may save business costs and
    increase productivity but if going from 80 to 95% would require
    unimaginable amount of cost and effort. Is it worth it? Can it be a
    progressive roadmap?

-   Create a smaller team and undertake a feasibility analysis through
    techniques like
    [EDA](https://en.wikipedia.org/wiki/Exploratory_data_analysis)
    (Exploratory Data Analysis). A [feasibility
    study](https://microsoft.github.io/code-with-engineering-playbook/machine-learning/ml-feasibility-study/)
    is much cheaper to evaluate data quality, customer constraints and
    model feasibility. It allows a TPM to better understand customer use
    cases and current environment and can act as a fail-fast mechanism.
    Note that feasibility should be shorter (in weeks) else it misses
    the point of saving costs.

-   As in any project, there will be new needs (additional data sources,
    technical constraints, hiring data labelers, business users time
    etc.), factor these in your cost and schedule to avoid surprises.

**Notebooks != ML Production**

You saw a YouTube video where a coding ninja worked her python magic to
build a natural language processing engine in notebooks, she even shared
the. iPynb to get you started. Sadly, that will not get you to
production. As a TPM, you need to be the myth buster here:

-   Understand the end-end flow of data management, how data will be
    made available (ingestion flows), what's the frequency, storage,
    retention of data. Plan user stories and spikes around these flows
    to ensure you are building a robust ML pipeline and not a ML demo.

-   Your engineering team should follow the same rigor in building ML
    projects as in any software engineering project. We at CSE
    (Commercial Software Engineering) have built a good set of resources
    from our learnings in our [engineering
    handbook](https://microsoft.github.io/code-with-engineering-playbook/machine-learning/).

-   ML Focussed projects are not a "one-shot" release solution, they
    need to be nurtured, evolved, and improved over time. An analogy
    from my friend **Craig Rodger**, Principal Data and Applied
    Scientist at Microsoft: "It is like deciding to adopt a puppy, it
    may look cheap to begin with, but it should be seen as a 15-year
    commitment/journey".

**Garbage Data In -\> Garbage Model Out**

A book can be (and [have
been](https://www.amazon.com/s?k=Data+Cleaning+machine+learning&i=stripbooks-intl-ship&ref=nb_sb_noss))
written on how data quality is a major factor in affecting model
performance. As a TPM, you may not get directly involved in the data
cleansing and engineering activities, but you need to understand why
your data team keeps saying, data is not good quality (as if it was the
sushi from that shady store in downtown).

-   During feasibility, have your team generate a report on data quality
    -- missing values, duplicates, unlabeled data, expired or not valid
    data, incomplete data (e.g., only having male representation in a
    people dataset).

-   Understand data source reliability (e.g., are the images from a
    production or industrial camera or taken from an iPhone)

-   Understand the data acquisition constraints (legal, contractual,
    Privacy, regulation, ethics) before leveraging the data sets.

-   Identify if we have enough data for sampling the required business
    use case and how will the data be improved over time. The thumb rule
    here is that data should be enough for generalization to avoid
    overfitting.

**You need more people, like right now!**

An ML Project has multiple stages, and each stage may require additional
roles. For example, Design Research & Designers for Human Experience,
Data Engineer for Data Collection, Feature Engineering, a Data Labeler
for labeling structured data, engineers for MLOps and model deployment
and the list can go on. As a TPM, you need to factor in having these
resources available at the right time to avoid any schedule risks.

**Your Feature is not my Feature**

TPM are familiar with Features, they are the core release mechanism for
any project. However, in the ML world, Features have a whole different
meaning. Feature Engineering enables the transformation of data so that
it becomes usable for an algorithm. The input to Feature Engineering is
raw data, and the output is generally called a Feature Vector. Creating
the right features is an art and may require experimentation as well as
domain expertise. Consider these factors when defining schedule and
allocate time for domain experts in the project. For example, for a
natural language processing engine for text extraction of financial
documents, we hired financial researchers who were able to run a
relevance judgment exercise with the engineering team to identify the
right features.

**It's a Biased world out there**

Bias in machine learning could be the number one issue of a model not
performing to its intended needs. There are many reasons for bias to get
introduced in the data which can impact the model performance. As a TPM,
you can help your machine learning team by identifying the right use
cases scenario and target personas. For example, for a person
recognition algorithm, if the data source is only feeding a specific
skin type, then production scenarios will not provide good results.
Think about [Responsible AI
principles](https://www.microsoft.com/en-us/ai/responsible-ai?activetab=pivot1%3aprimaryr6)
from Day 1 to ensure fairness, security, privacy and transparency of the
models. Shout out to **Bujuanes Livermore**, Principal Design Researcher
at Microsoft for relentlessly emphasizing on the Responsible AI
principles.

**The learning Journey for a TPM**

As we can see, Machine Learning projects require the appreciation of few
additional skills beyond the conventional software development
processes.

So, should you as a TPM, start learning about Gradient Descent and how
to build Convolutional Neural Networks? Well, not exactly. (All power to
you if you want to)

The skills required for a TPM is to understand the nuances and
complication of a Machine learning project, however it does not
necessarily need a TPM to become a Data Scientist or an Applied ML
Engineer. Here is a simple framework to think about your up-skilling for
ML projects:

![](media/image1.png){width="4.193675634295713in"
height="2.0647790901137357in"}**PM Fundamentals**: Core to a TPM role
are the fundamentals that include bringing clarity to the team, design
thinking, managing risk, managing stakeholders, backlog management,
project management. These are your superpowers and the Data Science
community generally lack these. You complement your machine learning
team by ensuring the stakeholder expectations and driving customer
objectives. I write about core TPM responsibilities in my earlier posts
[The TPM Don't M\*ck up
framework](https://www.linkedin.com/pulse/tpm-dont-mck-up-framework-nikhil-sachdeva/)
and [The mind of a
TPM](https://www.linkedin.com/pulse/mind-technical-program-manager-nikhil-sachdeva/)

**ML Fundamentals**: You will need to spend time in at least
understanding how Machine Learning Engineering works. Note, this does
not mean you need to know in-depth of how to build models, but you
should be aware of the model development and deployment lifecycle and
the constraints around Feature Engineering, Model Evaluation, Model
Training, Model Monitoring etc. Here are some resources to help you:

[AI Learning Paths by
Microsoft](https://docs.microsoft.com/en-sg/learn/browse/?roles=ai-engineer&products=azure&resource_type=learning%20path&WT.mc_id=sitertzn_homepage_mslearn-banner-aischool)

[CSE Engineering Handbook for
ML](https://microsoft.github.io/code-with-engineering-playbook/machine-learning/)

Books:

[Data Science for
Business](https://www.amazon.com/Data-Science-Business-Data-Analytic-Thinking/dp/1449361323):
Thanks to Chris Auld for Recommendation.

[The Hundred Page Machine Learning](http://themlbook.com/): Succinct
summary of ML concepts

[Machine Learning Engineering](http://www.mlebook.com/wiki/doku.php):
Covers the machine learning project lifecycle very well.

[Agile Data Science
2.0](https://www.oreilly.com/library/view/agile-data-science/9781491960103/):
Leveraging Agile for Data Science projects.

[Designing Data Intensive
Application](https://www.amazon.com/Designing-Data-Intensive-Applications-Reliable-Maintainable/dp/1449373321/ref=sr_1_2?crid=2WH5HBIBGU6RI&keywords=system+design&qid=1647500771&sprefix=system+desi%2Caps%2C341&sr=8-2):
System Design for Data driven architectures.

**Domain Applicability:** The understanding of the underlying domain is
also important for TPMs to have the right AI solution conversations with
customers. For example, understanding the Quality Inspection scenarios
in an Assembly line, TPMs can understand how a defect detection
algorithm can help optimize the process efficiency and reduce costs for
the manufacturer. Additionally, when understanding a domain, TPMs get a
overview of the technical constraints within the deployment environment
such as networking and security constraints in a Manufacturing Plant
which can help them define the non-functional requirements better.

Hope this post helps give an understanding of the uniqueness of Machine
learnings projects from a TPMs point of view and areas where you as a
TPM can up-skill to be effective in your next ML project.
