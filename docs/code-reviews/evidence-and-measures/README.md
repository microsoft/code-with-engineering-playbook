# Evidence and Measures

## Evidence

Many of the code quality assurance items can be automated or enforced by policies in modern version control and work item tracking systems. Verification of the policies on the main branch in [Azure DevOps](https://azure.microsoft.com/en-us/services/devops/) (AzDO) or [GitHub](https://github.com/), for example, may be sufficient evidence that a project team is conducting code reviews.

* [ ] The main branches in all repositories have branch policies. - [Configure branch policies](branch-policy.md)
* [ ] All builds produced out of project repositories include appropriate linters, run unit tests.
* [ ] Every bug work item should include a link to the pull request that introduced it, once the error has been diagnosed. This helps with learning.
* [ ] Each bug work item should include a note on how the bug might (or might not have) been caught in a code review.
* [ ] The project team regularly updates their code review checklists to reflect common issues they have encountered.
* [ ] Dev Leads should review a sample of pull requests and/or be co-reviewers with other developers to help everyone improve their skills as code reviewers.

## Measures

The team can collect metrics of code reviews to measure their efficiency. Some useful metrics include:

* Defect Removal Efficiency (DRE) - a measure of the development team's ability to remove defects prior to release
* Time metrics:
  * Time used preparing for code inspection sessions
  * Time used in review sessions
* Lines of code (LOC) inspected per time unit/meeting

It is a perfectly reasonable solution to track these metrics manually e.g. in an Excel sheet. It is also possible to utilize the features of project management platforms - for example, AzDO enables dashboards for metrics including [tracking bugs](https://docs.microsoft.com/en-us/azure/devops/boards/backlogs/manage-bugs?view=azure-devops&tabs=new-web-form). You may find ready-made plugins for various platforms - see [GitHub Marketplace](https://github.com/marketplace) for instance - or you can choose to implement these features yourself.

Remember that since defects removed thanks to reviews is far less costly compared to finding them in production, the cost of doing code reviews is actually negative!

For more information, see links under [resources](#resources).

## Resources

* [A Guide to Code Inspections](http://www.ganssle.com/inspections.pdf)
* [Defect Removal Effectiveness](https://www.westfallteam.com/sites/default/files/papers/defect_removal_effectiveness.pdf)
