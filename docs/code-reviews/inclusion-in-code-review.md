# Inclusion in Code Review

You may be thinking why care about inclusiveness in code reviews. Below are some points which emphasize why inclusivity in code reviews is important:

* Doing Code Review is an important part of our job as Software Professionals;
* As CSE, we work with cross cultural teams from across the globe;
* How we communicate while doing code review affects team morale;
* Inclusive code reviews make new developer comfortable with the team;
* Rude or personal attacks doing code reviews are very common, people unknowingly make rude comments in reviewing Pull Requests.

## Types of non-inclusive code review behavior

* Inequitable review assignment;
* Negative Inter-Personal Interactions;
* Biased Decision Making;

## Examples of Non-Inclusive Code Reviews

* Assigning lot of PRs to a single person for review and not assigning any PRs for other people in team. - _Inequitable review assignment_
* Long arguments in the pull requests over subjective topics like style of coding . - _Negative Inter-Personal Interactions_
* Commenting on the developer and not the code. Assuming code from developer X will always be good and hence not reviewing it properly and vice versa. - _Biased Decision Making_

## Examples of Inclusive Code Reviews

* Anyone and everyone in the team should be assigned PRs to review.
* Reviewer should be clear about what is an opinion, their personal preference, best practice or a fact. Arguments over personal preferences and opinions are mostly avoidable.
* Using inclusing language and tone in the code review comments. For example, being suggestive rather being prescriptive in the review comments is a good way to get the point across the table.
* For the author of PRs- It's a good practise to thank the reviewer for the review if they have contributed in improving your code or you have learnt something new.
* Using the Sandiwch technique, for recommending a code change to a new developer or a new customer, sandwich the suggestion between 2 compliments. Something like- "Great Work so far, but i would recommend a few changes here. Btw, i loved the use of XYZ here, great work!!."

## Responsibility of the author to make code reviews inclusive

* Aim to write a code that is easy to read, review and maintain.
* It’s important to ensure that whoever is looking at the code, whether that be the reviewer or a future engineer, can understand the motivations and how your code achieves that.
* Proactively asking for targeted help or feedback.
* Respond clearly to questions asked by the reviewers.
* Avoid huge commits to submitting incremental changes.

## Responsibility of the Reviewer to make code reviews inclusive

* Assume positive intent from the author
* Write clear and elaborative comments on the PR
* Identify subjectivity, choice of coding and best practice. It is good to discuss coding style and subjective coding choices in some other forum and not in the PR. A PR should not become a ground to discuss subjective coding choices and having long arguments over it
* If you do not understand the code properly, refrain from commenting like for e.g. "This code is incomprehensible". Better is to get in a call with the author and get a basic understanding of what they have done.
* Be suggestive and not prescriptive. A reviewer should suggest changes and not prescribe changes, let the author decide if they really want to accept the changes proposed. 


## Culture and Code Reviews

We as CSE, may come across situations in which code reviews are not ideal and often we are observing non inclusive code review behaviors. Its important to be cognizant of the fact that culture and communication style of a particular geography also influences how people interact over pull requests.
In such cases, assuming positive intent of the author and reviewer is a good start to start analyzing quality of code reviews.

## Tools

Below are some tools which may help in establishing inclusive code review culture within our teams.

* [anonymous_github](https://github.com/tdurieux/anonymous_github)
* [blind-reviews](https://github.com/zombie/blind-reviews/)
* [gitmask](https://www.gitmask.com/)
* [inclusivelint](https://github.com/inclusivelint)
