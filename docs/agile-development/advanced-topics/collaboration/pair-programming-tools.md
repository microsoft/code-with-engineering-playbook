# Effortless Pair Programming with GitHub Codespaces and VSCode

Pair programming used to be a software development technique in which two programmers work together on a single computer, sharing one keyboard and mouse, to jointly design, code, test, and debug software. It is one of the patterns explored in the section [why collaboration?](./why-collaboration.md) of this playbook, however with teams that work mostly remotely, sharing a physical computer became a challenge, but opened the door to a more efficient approach of pair programming.

Through the effective utilization of a range of tools and techniques, we have successfully implemented both pair and swarm programming methodologies. As such, we are eager to share some of the valuable insights and knowledge gained from this experience.

## How to Make Pair Programming a Painless Experience?

### Working Sessions

In order to enhance pair programming capabilities, you can create regular working sessions that are open to all team members. This facilitates smooth and efficient collaboration as everyone can simply join in and work together before branching off into smaller groups. This approach has proven particularly beneficial for new team members who may otherwise feel overwhelmed by a large codebase. It emulates the concept of the "[humble water cooler](https://www.inverse.com/innovation/how-companies-have-optimized-the-humble-office-water-cooler)," which fosters a sense of connectedness among team members through their shared work.

Additionally, scheduling these working sessions in advance ensures intentional collaboration and provides clarity on user story responsibilities. To this end, assign a single person to each user story to ensure clear ownership and eliminate ambiguity. By doing so, this could eliminate the common problem of engineers being hesitant to modify code outside of their assigned tasks due to the sentiment of lack of ownership. These working sessions are instrumental in promoting a cohesive team dynamic, allowing for effective knowledge sharing and collective problem-solving.

### GitHub Codespaces

[GitHub Codespaces](https://code.visualstudio.com/docs/remote/codespaces) is a vital component in an efficient development environment, particularly in the context of pair programming. Prioritize setting up a Codespace as the initial step of the project, preceding tasks such as local machine project compilation or VSCode plugin installation. To this end, make sure to update the Codespace documentation before incorporating any quick start instructions for local environments. Additionally, consistently demonstrate demos in codespaces environment to ensure its prominent integration into our workflow.

With its cloud-based infrastructure, GitHub Codespaces presents a highly efficient and simplified approach to real-time collaborative coding. As a result, new team members can easily access the GitHub project and begin coding within seconds, without requiring installation on their local machines. This seamless, integrated solution for pair programming offers a streamlined workflow, allowing you to direct your attention towards producing exemplary code, free from the distractions of cumbersome setup processes.

### VSCode Live Share

[VSCode Live Share](https://code.visualstudio.com/learn/collaboration/live-share) is specifically designed for pair programming and enables you to work on the same codebase, in real-time, with your team members. The arduous process of configuring complex setups, grappling with confusing configurations, straining one's eyes to work on small screens, or physically switching keyboards is not a problem with LiveShare. This innovative solution enables seamless sharing of your development environment with your team members, facilitating smooth collaborative coding experiences.

Fully integrated into Visual Studio Code and Visual Studio, LiveShare offers the added benefit of terminal sharing, debug session collaboration, and host machine control. When paired with GitHub Codespaces, it presents a potent tool set for effective pair programming.

> Tip: Share VSCode extensions (including Live Share) using a base [devcontainer.json](https://code.visualstudio.com/docs/devcontainers/create-dev-container). This ensure all team members have available the same set of extensions, and allow them to focus in solving the business needs from day one.

## Resources

* [GitHub Codespaces](https://code.visualstudio.com/docs/remote/codespaces).
* [VSCode Live Share](https://code.visualstudio.com/learn/collaboration/live-share).
* [Create a Dev Container](https://code.visualstudio.com/docs/devcontainers/create-dev-container).
* [How companies have optimized the humble office water cooler](https://www.inverse.com/innovation/how-companies-have-optimized-the-humble-office-water-cooler).
