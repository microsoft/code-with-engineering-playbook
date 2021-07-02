# Engineering Feasibility Spikes: identifying and mitigating risk

## Introduction

Some engagements require more de-risking than others, and after Architectural Design Sessions (ADS) may still have substantial unknowns. These types of engagements warrant an exploratory/validation phase where Engineering Feasibility Spikes are conducted to reduce risk in the engagement, bring clarity, and help drive a sound architecture.

**Engineering feasibility spikes** are a regimented yet collaborative feedback loop to capitalize on individual learnings to inform the team and increase the team’s knowledge and understanding while minimizing engagement risks. These spikes can be conducted during an exploratory/investigate phase immediately after the ADS and before engineering sprints.

The following guidelines outline how Microsoft and the customer can incorporate engineering feasibility spikes into the day-to-day agile processes. It describes how to prioritize the spikes, set guardrails around this process and capitalize on associated benefits.

## Background

Sometimes in an engagement the engineering spike phase is very short or non-existent pre Game Plan. Often, the Dev Crew moves immediately to engineering sprints after ADS. This leads to some of the engineering spikes being conducted in parallel with the actual engineering sprints. When these spikes are conducted, they are usually done as part of a checklist exercise but have little impact on driving the direction of the engagement.

## Pre-Mortem

When an engagement has a plethora of risks, they can all seem too equally important. However, a good way to gauge what engineering spikes to conduct is to do a [pre-mortem](https://www.facebook.com/business/m/thinkkit/exercises/strong-starts/pre-mortem).

### What is a pre-mortem?

A pre-mortem focuses on both business and technology risks/concerns. It allows the entire team [not just the technical program manager (TPM) and Dev Lead] to initially raise concerns and risks early in the engagement. A pre-mortem can be done in a 90-minute meeting after envisioning/ADS that includes the entire team (and can also include the customer). The purpose of the pre-mortem is to be a thought exercise where the team members answer the following prompt _“imagine the project has failed you are now considering the problems and challenges that caused the project to fail.”_

Answering this prompt highlights risks in the project and unspoken assumptions that need to be validated.
This useful input can be used to decide which risks to pursue as engineering spikes. In addition, the engineering spikes can then be prioritized accordingly based on the risks identified in the pre-mortem.

## Sharing Learnings & Current Progress

### Feedback loop

The engineering feasibility spikes process works when rigor is applied; ensuring that the team has a defined, narrow scope, tight feedback loop, and time boxed investigatory activities.

The distinction here is that the feedback loop is significantly tighter/shorter than in sprint-based agile process. Instead of using the Sprint as the forcing function to adjust/pivot/re-prioritize, the interim sharing sessions were the trigger.

The goal in the exploratory/investigative phase is to de-risk faster, bring clarity, and raise the team’s greater understanding of the technology/architecture (not to develop usable code or parts of the solution) through the engineering feasibility spikes.

The key element from conducting the engineering feasibility spikes is sharing the outcomes in flight. The team can get together and share learning on a weekly basis or more frequently if needed. The sharing can be done via a 30-minute call. Everyone on the Dev Crew joins the call, even if not everyone is assigned an engineering spike story or even if the spike work was underway and not fully completed.

In other words, sharing can happen not after everyone is done, but after everyone had done a meaningful amount of initial research and could give an interim progress report on how they were proceeding within their area of investigation.

### Re-prioritizing the next spikes

After the team shares current progress, a next round of planning can be done. This allows the team to establish a very close feedback loop. The team can then re-prioritize the next spike(s) because of the outcome from the engineering spikes.

During the sharing call/discussion, and when the team believes it has enough information, the team can sometimes come to the realization that the original spike acceptance criteria was no longer valid. This allows the team to pivot into another area that provides more value. It is not because the team was initially on the wrong path but because the team would focus on the thing that would provide the most value. A [decision log](../decision-log/README.md) can be used to track outcomes.

### Adjusting based on context

For example, suppose the original spike was to investigate WebSocket mechanisms that were compatible with the customer constraints. Originally, the spike could have called out Socket.IO, Server-Sent Events, SockJS, and SignalR as possible candidates. As part of the investigation sharing phase, the team quickly determines that the most logical candidates were Socket.IO and SignalR based on new contextual customer information that was learned just the day before. This can allow the spike owner to focus on only those two choices. As stated earlier, it is the feedback loop that can allow the team to adjust the focus on the spikes on the fly rather than be rigid to the acceptance criteria. This allows the team to react based on the changing context and questions.

The above steps are depicted in the diagram below.

![Engineering feasibility spike feedback loop](images/engineering-feasibility-spike-feedback-loop.png)

## Benefits

### Creating code samples to prove out ideas

It is important to note to be intentional about the spikes not aiming to produce production-level code. As mentioned, the purpose of the spike was for learning. The team sometimes must write code to arrive at the learning.

However, the team must be cognizant that the code written for the spikes is not going to serve also as the code for the final solution. Rather, it is just enough to drive the investigation forward.

For example, supposed the team was exploring the API choreography of creating a Graph client with various Azure Active Directory (AAD) authentication flows and permissions. The code to demonstrate this is implemented in a console app, but it could have been done via an Express server, etc. The fact that it was a console app was not important, but rather the ability of the Graph client to be able to do operations against the Graph API endpoint with the minimal number of permissions is the main learning goal.

### Targeted conversations

By sharing the progress of the spike, the team’s collective knowledge can increase. The spikes can allow the team to drive conversations with various Product Groups (PGs) and other subject matter experts (SMEs).

The team can have very targeted, succinct conversations with PGs and SMEs regarding technical blockers and platform limitations. Rather than speaking at a hypothetical level, the engineering feasibility spikes allow the team to playback project/architecture concerns and concretely point out why something is a showstopper or not a viable way forward. The PGs are then able to quickly validate the gaps in the product and suggest an alternate course of action.

### Weekly risk assessments

The spikes can allow the team to have a weekly risk assessment. In other words, it allows the team to answer _what is our current risk in the engagement?_ Unlike a Game Plan, for example, where the risks are outlined, mitigate once, and go forward, this process allows the team to have a near immediate risk gauge.

### Increased customer trust

Lastly, this process can lead to increased customer trust. Using this process, the team is able to bring the customer along in the decision-making process and guide them how to go forward. The team can provide answers with confidence and suggest sound architectural designs. This gives the customer a full understanding of what the Dev Crew would realistically be able to deliver to drive alignment and commitment to the solution before starting engineering sprints.

## Employing engineering feasibility spikes as a practice

Regardless of length of engagement, or even if the engagement appears to have little risk, consider conducting a pre-mortem with your team. It might help uncover risks that may have been overlooked. After this the Dev Crew can come back to the customer with a more targeted ADS equipped with learnings from the exploration phase.

Even after this exploratory phase, it is worthwhile to have some mechanisms to bring up any new risks that have emerged on a weekly basis, play them back against current risk and stack rank them. Some Dev Crews do keep risks tracked within their backlog. This approach would be an additional way to surface new risks. In any case, the point here to not lose the risk gauge once the engagement is out of the engineering spike phase. For example, this approach can be adopted as an immediate risk discussion in current ceremony process such as retro (a new column in the retro tool can be added for emerging risks). This can give the TPM and Dev Lead a pulse on new risks that have been identified by the team.

Conducting engineering feasibility spikes sets the team and the customer up for success, especially if it highlights technology learnings that help the customer fully understand the feasibility/viability of an engineering solution.

## Summary of key points

- A pre-mortem can involve the whole team in surfacing business and technical risks
- The key purpose of the engineering feasibility spike is learning
- Learning comes from both conducting and sharing insights from spikes
- Use new spike infused learnings to revise, refine, re-prioritize, or create the next set of spikes
- When spikes are completed, look for new weekly rhythms like retro ‘risk’ ‘risk’ column or topic at [daily standup](../../../agile-development/stand-ups/README.md) to identify emerging risks
