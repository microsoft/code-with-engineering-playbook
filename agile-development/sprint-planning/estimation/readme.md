# Goals for Estimation

When a team adopts agile, as the team works together, the process of estimating
new work becomes more effective. Over time, they get a sense for how their team
approaches the stories and the effort that will be required to complete each story.
With a few successful sprints completed, the team can start to see patterns of
success and where the team has had failures. The team can start to look at their
velocity against their estimates and begin to predict with greater accuracy what
effort will be needed to complete the next story.

If the makeup of the team is regularly changing, the process of estimation becomes
challenging as the patterns that drive the estimation process also change. Initially,
it will take three to five or more sprints to find a good rhythm to the team estimations.
When the team changes to a new project or a team is reorganized to join with another
team, the estimation model is essentially reset and a new baseline must be formed.

Before beginning the estimation process, the team should be clear what the goal of
the user story is. This means that the work to be done should be clear and the
acceptance criteria is agreed on by the team members that are doing estimation.
If the story is not ready to be handed off to a developer to start working on, it
is not ready for estimation.

## Sizing

There are many ways to size stories. This is usually where teams get hung up on
finding the balance between sizing that feel "willy nilly" and accurately estimating
the hours to complete the work. It is helpful to remember that this exercise is
to accurately determine what work can be completed in the sprint...not a precise
time allocation for the work to be complete.

In the beginning, to determine sizing, the team will generally pick two or three
stories that reflect a known amount of work of varying size. Usually, a simple,
an average and a complex story will work best. A simple story is one that can be
completed by a single developer in a time that is relatively short compared to the
length of the sprint. For example, if your team is running weeklong sprints, a
simple story might be able to be completed in a day, an average story might be
two days, and a complex story might take the entire sprint. The key is that there
is consensus on the team for what the relative sizes reflect. After a baseline is
agreed upon, the planning team will estimated each story that is ready for development
and will be given a relative sizing based on the sizing agreed to by the team. Examples
of estimating approaches are given below.

As the team works together, they will gain more experience about how the team
estimates the size stories. There will be more stories to help gauge the relative
size of the stories being estimated. This will tend to make the estimates more
accurate over time. As the team works together they will have better data to know
how much work can be committed to for the next sprint.

### Planning Poker

Possibly the most popular approach to sizing is called Planning Poker. This approach
assigns sizing based on the fibonacci numbers 1, 2, 3, 5, 8, 13 and 21. This can be
done with something as low tech as holding up fingers to online tools that allow
teams to remotely vote. Co-located teams can even choose to purchase playing cards
that reflect the fibonacci numbers and distribute the cards during the estimating
time.

Online tools like Azure Dev Ops have extensions that can be installed that help
remote team members to do estimating effectively. One example of this is the
"Estimate" extension by Microsoft DevLabs that ties planning poker directly to the
stories and will update "Story Points" field in the user story.

Depending on how granular the team wants the numbers, the team should focus not on
time but on relative work to be done. If you find that your team is saying "this
should take one day, so it is an 8" you will soon lose the value of the estimation
exercise. Rather, you should think "this story is more difficult than that story".
So when the team is estimating a story, the team can ask "How difficult is this
story compared to the work we did last sprint that was a 5?" Less difficult maybe
it's a 2 or 3. More difficult it's an 8 or three times as difficult...13. When you
go beyond 21 you may want to ask if the story can be broken down into smaller chunks.

### T-Shirt Sizes

When using numbers, teams start to over analyze what the points should be or they
try to begin to correlate points to hours on the clock. Teams start to pad their
estimates so they can justify their work with their time sheet. When you see this
start to happen, it may be time to remind the team this is about relative sizing
not about hours to complete the work.

One way to do this is to switch to T-Shirt sizing. With this approach you have extra
small, small, medium, large, extra-large, and double extra-large. When you remove
the correlation to numbers, the team remembers that their goal is only to determine
how difficult the work is before committing to the work to be done. It also gives
the product owner visibility that what was perceived as a simple task may be more
costly and thus less desirable than a couple of other features of a smaller size.

Another benefit of using a less granular approach is that the team won't spend so
much time trying to come to agreement on the precise measurement of the work. Decisions
on medium or large are easier than deciding a work item is 5 or 8 points. That said
this will also put the agile team leader in the position of converting sizes into
numeric values for the purpose of charting and tracking velocity over time.

## Estimation in Planning

As the team continues the exercise of estimating in the planning meeting, it should be
viewed as an exercise in relative sizing of the work. Comparing the expected work
to work that has already been done is helpful for the team to understand how they
view the complexity of the work.

Estimation can be done at any time with the consensus of the team and doesn't
always have to be done during the sprint planning. It may be helpful to the product
owner to understand the relative effort for the stories in order to prioritize
the work. If the Product Owners sees that one feature that they highly value,
might not be as valuable when they see that three other features that get pushed
out because of that one story's complexity.

In the planning meeting, the team looks at the prioritized items that are ready
for development. The team should work through the items in priority making sure
that if there is already an estimate the team still agrees with the estimate.
Finally, the team should estimate how many points the team can deliver in the sprint
and then make a commitment for the sprint. During the sprint, the team takes the highest
priority items off of the backlog and works on them to completion. At the end of
the sprint, the team reports the number of story points completed during the sprint.
The agile coordinator should track this information so that over time, the team
can work to get better at estimating the points that each story requires
as well as how many points can be delivered in a given sprint.

### Relative Mass

If there are a lot of stories to be estimated, the team can be overwhelmed doing
this all at once and the process can be long and unproductive. However, because
the stories are estimated relative to each other, it may be easier to do a relative
mass estimation.

For each story, either a card or a sticky note is created. The first card is read
and then placed in the center of the table or board. Then, as each card is read,
the team asks "Is this easier or harder that that card?" and it is placed in either lower
or higher position than the story that already exist on the table. This continues
with each card being placed in a line of difficulty from easiest to most difficult
until all stories are placed. Finally, the team then finds the "breaks" that represent
their relative sizing model and record the estimation for each of the cards in that
grouping.

When working with remote teams this can be done with a shared story board or a list
where the work items can be placed in an ordered ranking. Again, starting with the
top story, each subsequent story is placed higher or lower in the list based on
the relative mass of the story.
