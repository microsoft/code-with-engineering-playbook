# SOLID Principles of Object Oriented Design

The [SOLID](https://en.wikipedia.org/wiki/SOLID) Principles are a set of coding guidelines that, when followed,helps the developer produce a highly maintainable codebase. 

SOLID was promoted by [Robert C Martin](https://en.wikipedia.org/wiki/Robert_C._Martin) and is used across the object-oriented design spectrum. When applied, it makes your code more extendable, logical and easier to read.

The SOLID principles can be applied to any programming language where an Object-Oriented approach is possible.

Additionally, the SOLID principles form a syllabus; words that can help developers express themselves when discussing particlar pieces of code.
The words defined by SOLID are: 

- **S**ingle Reponsibility Principle
- **O**pen Closed Principle
- **L**iskovs Substitution Principle
- **I**nterface Segregation Principle
- **D**ependency Inversion Principle

> **NOTE**<br />
> Not all principles apply as clearly to every developer language, but as a general rule, the guidelines offered by SOLID induce a way of thinking about code that is healthy. 

----

## Single Responsibility Principle (SRP)
In short: A class, should have only ONE, single reason to change. Is your class doing multiple things? Consider the following class: 

```csharp
public class Modem
{
    public event EventHandler<string> OnDataReceived;

    public void EstablishConnection(){ /* implementation */ }
    public void Transmit(string data){ /* implementation */ }    
}
```

It would appear as this class is simple and easy to maintain, however, the *way* a connection is established is a different subject than how data is transmitted. **Class Modem** is in *violation* of the SRP, because it holds **several** responsibilities: 
* It has to know what AT codes to send to initiate a connection
* It has to know which AT codes to send to transmit data
* It needs to know how data is received, and unwrapped

***conclusion, SRP*** <br />
Keep responsibilities to ONE class. This means you will only have ONE reason to change that class, and thus reduce clutter and increase maintainability. 

----

## Open Closed Principle
This principle states that a classs and entities should be **Open** for extensability, but **Closed** for changes. This principle essentially states that once you go live with a new method inside your class, you do not modify it. Consider that you have a library v1.0 running the following class: 

```csharp
public class IdentityManager
{
    public User SignIn(string userName, string password){
        /*implementation*/
    }
}
```
Now, assume that in v2.0 of the same library you have **changed** the implementation details: 

```csharp
public class IdentityManager
{
    public User SignIn(SecurityPrincipal securityPrincipal){
        /*implementation*/
    }
}
```
It goes without saying that this introduce a breaking change to any code where youwant to upgrade to the latest & greatest version. 

**Solution** <br />
To prevent breaking changes to your libraries, should **add** the new method by *extending* your library: 

```csharp
public class IdentityManager
{
    // v1.0
    [Obsolete("SignIn using a security principal instead")]
    public User SignIn(string userName, string password){
        /*implementation remains unchanged */
    }

    // v2.0    
    public User SignIn(SecurityPrincipal securityPrincipal){
        /*implementation*/
    }
}
```
In the above code, you can see that instead of *modifying* the **SignIn()** method, we added another method instead. 

> **Note** <br />
> The **[Obsolete]** Attribute is a construct of the C# language and allows the developer to notify the library client that he should update his code, but without breaking anything.
----
## Liskosvs Substitution Principle (LSP)
Sometimes, something that sounds right in natural language does not quite work in code. For example, in mathematics, a `square` is a `rectangle`. It is a specialization of a rectangle. This inference of "is a" would lead you to model this with inheritance, however, if you let yourself derive a `square` from a rectangle, you would run in to some unexpected behavior: 

```csharp
public class Rectangle
{
    public void SetWidth(int width){
        /* implementation */
    }

    public void SetHeight(int height){
        /* implementation */
    }
}

public class Square : Rectangle
{    
    public void SetSideLength(int sideLength){
        SetWidth(sideLength);
        SetHeight(sideLength);
    }
}
```
In the code above, you can see that the Square now have two nonsensical methods *SetWidth()* and *SetHeight()*. This fails the Liskov Substitution Test with `Rectangle` and the abstraction of having `Square` inherit from `Rectangle` is a bad one. 

It fails because in a collection of `Rectangles`, calling each `Rectangle` to perform scaling would produce undefined behavior on the `Square` objects.

**Conclusion** <br />
Always ask yourself if the class you're inheriting in any way breaks the understanding of the parent object. If it does, you should probably not inherit.  

## Interface Segregation Principle (ISP)
In many languages, the concept of an `interface` exists to define a contract for any classes that inherit it. This is useful for a number of reasons. But sometimes, ill-defined interfaces can lead to unexpected implementations. 

ISP states that no client should be forced to depend on methods that it does not use.

Consider the following interface: 

```csharp
public interface IWorker
{
    void DoWork();
    void Eat();
}
```
This is a simple interface with two methods, and it seems easily implemented: 

```csharp
public class Plumber : IWorker
{
    public void DoWork(){
        /* implementation */
    }

    public void Eat(){
        /* implementation */ 
    }
}
```
The above implementation *seems* to make perfect sense. A plumber does his work, and sometimes, he needs a break to eat, right? Well, let's introduce another class: 

```csharp
public class Robot : IWorker
{
    public void DoWork(){
        /* implementation */
    }

    public void Eat(){
        /* Hmm, what to do? Robots don't need breaks */ 
    }
}
```
> **NOTE** <br />
> These discrepancies are never this easy to spot. You need a keen eye to detect them in normal production code!


This kind of discrepancy is what violates the ISP. As a developer, you might be tempted to just implement the *DoWork()* method with a comment, stating something like "No Code".. What happens is, a few weeks later, you might onboard a new developer to the team who sees the unimplemented method and tries to write something for the *Eat()* method. You might even do it yourself, a year after you wrote it. 

The violation here, is that the `interface` is ill-defined, and IT needs to be changed: 

```csharp
public interface IWorker
{
    void DoWork();
}

public interface IEater
{
    void Eat();
}
```

This now makes much more sense, and in your production code, you can have the following logic: 

```csharp
/* class defined as a worker AND eater */
public class Plumber : IWorker, IEater
{
    /* Implementation of all methods in the interfaces */
}

public class Robot : IWorker
{
    /* implementation of the IWorker interface only */
}

/* Somewhere else entirely */
List<IWorker> workers = GetWorkersFromSomewhere();

foreach(var worker in workers)
{    
    if(worker is IEater eater && IsLunchBreak(DateTime.Now))
    {
        eater.Eat();
    }    
    else
    {
        worker.DoWork();
    }
}
```
Now, the Plumber, who inherits the contracts from `IWorker` and `IEater` will be identified as an eater and get his lunchbreak when time is due, but the robot, not being an `IEater`, will simply keep working. 

**Conclusion** <br />
When you're depending on methods that you're not using, it means that your abstractions are wrong. Think about wether your abstractions are resusable, composable and wether your objects are encapsulated and cohesive.

## Dependency Inversion Principle (DIP)

