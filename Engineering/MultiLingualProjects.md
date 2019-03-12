# Multilingual Projects

## Overview 

We see more requests and on-going projects coming from clients that are not able or not comfortable using assigned DevCrew’s main language for an engagement. In this document, we want to collect useful patterns for running successfully multilingual projects. We call a project multilingual if the majority of the DevCrew members are not proficient in the official language of the engagement. We extracted lightweight framework that can be helpful when running multilingual projects. 

## The Ultimate Goal

During the work on multilingual engagements there will be many challenges. Thus, it is very important not to forget why engage in first place and what is our ultimate goal - **Empower the clients and make them feel comfortable so they can learn, build and deliver impactful projects that will benefit their organization!**.

## Team Structure

### Microsoft Team
1. **Multilingual Engineer** - The project will require at least one (better 2+) members of the team that can speak both DevCrew's main language and the client's preferred language. 
2. **Tech Lead / Scrum Master** - It is recommended that one of the Multilingual Engineers to be a tech lead / Scrum Master to facilitate the communication and requirements gathering / clarification.
3. **Track Leaders** - Divide the work into tracks and assign members from the DevCrew to be track leaders. This will help form smaller groups for more manageable communication.

### Client Team

1. **Multilingual Engineer** - Identify the Multilingual Engineer(s) on the client side. They will be very important for taking the lead when Microsoft's Multilingual Engineer(s) are not available or helping the local team to operate more smoothly and independently when required. The Multilingual Engineer also can help with translation during various meeting or on-site engagements. 

2. **Tack Members** - Assign 2 or maximum 3 members from the client team to a track to avoid issues with the communication. Change the tracks of the client members every few to several weeks to identify the Tech Lead(s) candidates, increase the visibility for the various aspects of the project and keep the excitement of the team if there are repetitive tasks. 

3. **Tech Lead** - Identify potential candidate(s) that can act as Tech Lead in the client's team. Since the communication will be sometimes challenging it is very important to empower as soon as possible the client to take decisions independently. This will help the client to take ownership of features and eventually will lead to better ownership and ability to maintain and further develop the solution after the DevCrew's disengagement. Natural choices for Tech Leads are people that successfully worked on at least two different tracks and can understand the project's big picture. 

4. **Product Owner** - The Product Owner is very important for the overall success of the project. Due to the communication issues DevCrew's Multilingual Engineer can spend most of his time on tactical tasks and feel the pressure to take key product decisions to speed up the work. Involving client's Product Owner for all major product decision is a must since s/he is responsible for the ultimate success of project and has unique knowledge. 

## Codebase

1. **Starting Point** - We recommend starting with English codebase and comments and translating to the client’s preferred language after few sprints. The DevCrew developers will feel more comfortable then with the keywords of the project in the client's preferred language. However, don't leave the translation of the code for the last moment. Translation of the code should be included in the definition of done on User Story level (not task). The Multilingual Engineer(s) will translate the code and the comments when the logic is complete and merged to the main development branch.

2. **Code** - The code should be in the client's preferred language. The code will stay with the client and if they are not comfortable reading or speaking the DevCrew’s main language, there is a high probability that they will not be comfortable reading, supporting and extending code written in DevCrew’s main language. However, check with the client in the beginning if they can accept code in DevCrew’s main language. The translation of the code includes all class names, methods, parameters and variables. 

3. **Comments** - All the comments need to be translated as well. We recommend keeping the comments in DevCrew’s main language for a while until the DevCrew team feels more comfortable with the key words for the project. Two step translation process is also helpful - first translate the code but keep the comments in DevCrew’s main language so the DevCrew members can keep the velocity high even with translated class names, methods and variables. In a few weeks translate the comments to the client's preferred language as well. 

## Process

The process is key for keeping the collaboration very active even when we work remotely. All the meetings will be held in the client’s preferred language with exception of Microsoft internal meetings. We recommend the following setup:

1. **Tasks** - The title and the description of the tasks should be in the client's preferred language and have translation in DevCrew’s main language. One possible approach is to have the title starting with the client's preferred language and then in brackets have the DevCrew’s main language translation. In the description first we have the details in the client's preferred language and then the DevCrew's main language version. 

2. **Retrospective Notes** - The retrospective notes need to be stored and have version both in the DevCrew's and the client's preferred language so everybody at the team can follow up accordingly. One useful tool is [Retrospective Board for Azure DevOps](https://marketplace.visualstudio.com/items?itemName=ms-devlabs.team-retrospectives). Every week identify few action items from the retrospective. The Scrum master should monitor the progress of implementing the action items throughout the week. 

3. **Velocity** - Measure the velocity of the team on a weekly basis. To improve we need to track closely the velocity. In few to several weeks the team will get better at planning. 

3. **Standup** - 15 minutes morning meeting for reporting status, next work item and blockers. It shouldn't be longer than 15 minutes even with big teams. Multilingual Engineers on both sides lead these with the whole team attending.

4. **Daily Action Meeting** - Late afternoon meeting for taking decision that are blocking members of the team or discussing topics that slow the development. Multilingual Engineers on both sides lead these with the whole team attending.

5. **Grooming** - Discuss the upcoming features and create tasks for them. Multilingual Engineers of both sides lead these with the whole team attending.

6. **Planning** - Assign story points and include tasks for the starting sprint. Multilingual Engineers on both sides lead these with the whole team attending.

7. **Track Meetings** - The members of each track meet and discuss issues and priorities for the tasks in the track. Track leaders lead these with the whole track’s team attending.

8. **1:1** - Meeting between DevCrew member and Client's member for quickly clarifying confusion, explanation or unblocking. 

## Tools

Tools are very important part of the process because they help us compensate the language barrier. 

1. **Microsoft Translator App** - Use this app for 1:1 meeting when the Multilingual Engineer is not available. If the conversation is getting complicated request help from the Multilingual Engineer. When using the app speak clearly and slowly. Avoid complex explanations and language structures such as slang.

2. **Microsoft Translator for Power Point** - Use this feature for on-site presentations. It will make presenting from DevCrew members possible. Speak slowly and clearly. Avoid complex structures and language structures such as slang.

3. **Microsoft Teams** - Use the text chat translation function. Each of the participants can write in their language and read the message exchanges again in their preferred language. This will be the tool you will use most of the time. 

4. **Microsoft Translator** - Few to several weeks in the projects DevCrew's members should feel comfortable to start adding code, comments and tasks in the client's preferred language. The translation should not be perfect, auto-translation tools can be used. The Multilingual Engineers will scan the assets and will improve the translation quality of the codebase accordingly. 

5. **Project Dictionary** - The DevCrew should accumulate over time a list of the 20 to 50 words form the language of the project in the client's preferred language. The list needs to be stored online in Teams’ channel for the project. This list will be very useful for new member joining half-way in the project or even for quick look up during development and meetings.

## On-site Code-with Engagements

1. **Cultural Guidance** - Before the on-site engagement, the Multilingual Engineer or local account manager should hold a cultural guidance explanation highlighting key difference and specifics of the local environment. Few examples are kissing when greeting, very narrow personal space, longer lunches and working late hours.

2. **Recruit more Multilingual On-Site Supporters** - During the on-site engagement, the use of translation technology will be limited since DevCrew members are facing their track members face-to-face. Find Microsoft local people that can help with the translation so each track can work smoothly. Have at least one person per tack capable of translating. The main Multilingual Engineers on both sides will not be able to cover the all tracks discussions. 

3. **Dinner** - On the second or third day of the onsite code-with engagement have a dinner with the client. Mix members of both DevCrew and Client's teams to encourage the discussions between the members. Building better relationship will pay back while the members are working later during the on-site engagement or remotely. You will be surprised to see that everybody is trying to speak DevCrew's main language or the local language and this will improve the morale of the whole team!

 
## Timeframe 

We recommend when planning project that will not be held in the DevCrew's main language to allocate 50% buffer above the usual estimate. The overhead will come from the communication difficulties that will slow down the overall development process.

## Risks

1. **Initial Pressure** - There will be a lot initial pressure for the Multilingual Engineer(s) on the DevCrew side to align the whole team, prepare the required documents and setup the onsite code-with engagements. In these first few weeks the team should support the Multilingual Engineer(s) and take any possible tasks that do not involve translation. DevCrew team members should proactively reach out to the Multilingual Engineer(s) and be ready to take new tasks to offload him/her. The overall process will get back to normal in a few weeks when both the DevCrew and client's team get used to daily and weekly routines and start to communicate better. 

2. **Upskilling** - Identify key upskilling areas in the beginning of the project such as Git, main Azure Services and others that can become blockers and delay the development. It is always better to spend a little bit more time on preparation in the beginning to avoid slowdown during the most important sprints.  

3. **Slow Complexity Increase** - It is better relatively early to encourage the client's team to work on more complex tasks. Of course, there should be gradual increase of the complexity of the tasks but avoid giving trivial or uninteresting tasks to the client's team. You will be surprised how quickly they can learn when working on a problem with a good guidance from the Track Leader. On the other hand, if the client's team are advised to pick only easy tasks, they will get bored and disengaged easily. 

4. **Code-For** - Due to the complex communication environment it is very easy to turn the engagement from Code-With to Code-For. Cultural specifics can support this transition such as shy and quiet character of the client team members. The DevCrew should take the lead at least in the beginning to get the project going but Tech Lead / Scrum Master / Multilingual Engineer should have a solid plan how to involve more and more the client's developers, product owner and key stakeholders. The DevCrew can successfully develop and deliver a project but if the client doesn't feel comfortable working, maintaining or extending it most probably the solution will not be very useful for the client's organization in long term.

## Strategy

1. **Empower the Client** - Depending on the complexity of the project (both communication and technical), we need to do our best to position the client for success after we disengage. Around the middle of the engagement we need to promote client's members to task and feature owners. This should be well planned process in which the complexity of the tasks is progressing with every new assignment.

2. **Demo** - As soon as possible we need to transition the complete responsibility for the demo to the client's team. Member of each track should present in the local language even though in the beginning the DevCrew will do the main work in the background. However, this is very important step to get better buy-in from the client's team as well as their main stakeholders that are joining the demos.

3. **DevCrew Benefit** - The whole process will be painful for the DevCrew members that needs to adjust a lot especially in the beginning but few to several weeks in the engagement the initial tension should be eliminated and the team will start to work smoothly. In the beginning the Tech Lead / Scrum Master / Multilingual Engineer needs to work on keeping the DevCrew's motivation high. It is always useful to focus on the fact that each of the engineers are getting advantage from learning how to work in new cultural context that enrich not only their technical but also soft skills which are even more important for our work in CSE. We meet customers from all over the world and being able to understand better their points includes big portion of cultural education. Thus, in future engineers that are familiar with more cultures will be more successful working on interesting international projects.
