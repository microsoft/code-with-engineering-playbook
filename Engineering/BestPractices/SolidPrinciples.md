# SOLID Principles of Object Oriented Design

Some argue that good code is code that is easy to read. The faster someone can understand your code, the faster they can expand upon it, or fix issues. 


## TL;DR;
Here's the short version: 

| Abbreviation | Principle | What does it mean? |
| ------------ | ----------| ------------------ |
| SRP          | Single Responsibility | Write classes that only need ONE single reason to be changed | 
| OCP          | Open Closed | Never change a method after putting it in production. Instead extend the class with new methods! | 
| LSP | Liskovs Substitution | A class that inherits another class must behave like it's superclass. That is not always the case! | 
| ISP | Interface Segregation | Keep your interfaces small and well defined. Choose multiple interfaces instead of making one large superclass where all methods aren't going to be implemented. This usually breaks SRP anyway! |
| DIP | Dependency Inversion | Don't use **new()** but instead inject dependencies using constructors or accessors.

Curious? Read on then!

## And now, the longer version:
The [SOLID](https://en.wikipedia.org/wiki/SOLID) Principles are a set of coding guidelines that, when followed,helps the developer produce a highly maintainable codebase. They are widely adopted all around the globe to the point of being defined as the "Core" principle for good software craftmanship by many developers and influencers. You will often find references to SOLID in software litterature, blogs and vlogs.

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

The rest of this document details each of the principles. 

----

## Single Responsibility Principle (SRP)
In short: A class, should have only ***one***, single reason to change. If your class is doing multiple things, it will be harder to maintain, because more moving parts usually lead to more points of failure and more complex unit-tests. Also, classes with multiple responsibilities tend to have less meaningful names, and are instantly harder to understand.

> Classnames ending in ***-Tools*** and ***-Helper*** say nothing about the responsibilities within them.

Let's look at an example:

```csharp
public class AccountManager
{
    public AccountNumber CreateAccount(AccountHolder accountHolder)
    { 
        /* implementation */ 
    }
    
    public void CalculateInterest(AccountNumber accountNumber)
    { 
        /* implementation */ 
    }    
}
```
### I give up, what's the problem here?
It would appear as this class is simple and easy to maintain, however, the *way* you would code **CreateAccount()** is vastly different to how you would implement **CalculateInterest()**. Additionally, the name **AccountManager** will tell you that it manages accounts for sure, but forces you to look closer to understand it's capabilities. In a large solution having loosely named objects like this steal time.

**Class AccountManager** is in *violation* of the SRP, because it holds **several** responsibilities: 
* If the routines implemented for account creation change, **CreateAccount()** probably needs to change
* If the way the interest rate is calculated is changed, then **CalculateInterest()** needs to change

To solve this,  consider two different classes: 
```csharp
public class AccountCreator
{
    public AccountNumber Create(AccountHolder accountHolder)
    { 
        /* implementation */ 
    }
}

public class InterestCalculator
{
    public void CalculateForAccount(AccountNumber accountNumber)
    { 
        /* implementation */ 
    }    
}
```
By limiting the responsibility in class **AccountCreator** it's implementation becomes more easy to understand and it will only change if the requirements of creating an account needs to change. Likewise for **InterestCalculator**. You, as a developer, would have no doubt about the responsibilities of either of these two classes.


**Conclusion** <br />
Keep responsibilities to ONE class. This means you will only have ONE reason to change that class, and thus reduce clutter and increase maintainability. Classes that follow SRP are usually easier to name and understand.

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
> The **[Obsolete]** Attribute is a construct of the C# language and allows the developer to notify the library client that he should update his code, but without breaking anything. If your language supports this kind of constructs, use them! 
----
## Liskovs Substitution Principle (LSP)
Sometimes, something that sounds right in natural language does not quite work in code. For example, in mathematics, a `square` is a `rectangle`. It is a specialization of a rectangle. This inference of "is a" would lead you to model this in code by using inheritance, however, if you let yourself derive a `square` from a `rectangle`, you would run in to some unexpected behavior: 

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

----

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
This is a simple interface with two methods, and it seems straightforward to implement: 

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


This kind of discrepancy is what violates the ISP. As a developer, you might be tempted to just implement the *DoWork()* method with a comment, stating something like "No Code".. What happens is, a few weeks later, you might onboard a new developer to the team who sees the unimplemented method and tries to write something for the *Eat()* method out of kindness/desire to help. Hey, **You** might even do it yourself, a year after you wrote it! This happens - more often than you think! 

### OK! OK! How do I fix it?
The violation here, is that the `interface` is ill-defined, and IT needs to be changed! Let's split it up:  

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

Ok, so time to implement. Just about every language supports multiple interface inheritance: 

```csharp
/* A plumber works, but needs a break from time to time! */
public class Plumber : IWorker, IEater
{
    public void DoWork(){ /*implementation*/}
    public void Eat(){ /*implementation*/}
}

/* Robots work tirelessly, they are never on a break */
public class Robot : IWorker
{
    public void DoWork(){ /*implementation*/}
}
```

And let's see a potential use case where the ISP is solved: 

```csharp
/* Somewhere else entirely */
List<IWorker> workers = GetWorkersFromSomewhere();

foreach(var worker in workers)
{    
    // Give them a  break if they need it, otherwise keep'em working
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
Now, the **Plumber**, who inherits the contracts from `IWorker` and `IEater` will be identified as an eater and get his lunchbreak when time is due, but the **Robot**, not being an `IEater`, will simply keep working. 

**Conclusion** <br />
When you're depending on methods that you're not using, it means that your abstractions are wrong. Think about wether your abstractions are resusable, composable and wether your objects are encapsulated and cohesive.

----

## Dependency Inversion Principle (DIP)
The DIP states: "*high level modules should not depend on low level modules; both should depend on abstractions*"

### Whaa...
Ok, so this one needs an example right away:

Consider a user interface with a button on it. Whenever the user presses the button, an event is fired, which creates a new instance of some Business logic  layer (BLL) class, which agains calls an instance of a data access class (DAL) to look into a database. The dependency tree look something like: 

**UI -> BLL -> DAL -> DB**

```csharp
// In the UI Form Code-behind
public class TheForm
{
    // Someone clicked the button
    public void MyButtonClick(object sender, ButtonClickEvent e)
    {
        var businessHandler = new BusinessHandler();
        someTextField.Value = businessHandler.LookupSomething();
    }
}

// Somewhere in your BLL:
public class BusinessHandler
{
    public void LookupSomething()
    {
        var reader = new DataReader();
        var stuff = reader.GetStuff();
        
        if(string.IsNullOrEmpty(stuff))
        {
            var logger = new Logger();
            logger.Warning("No stuff to process!");
        }
        return stuff;
    }
}

// Somewhere in your DAL
publik class DataReader
{
    public string GetStuff(){
        var connection = new Connection(...);
        var sqlStatement = "SELECT top 1 * from something";

        var result = connection.ExecuteSql(sqlStatement);
        return result ?? "no stuff";
    }
}
```
These classes and methods are all `tightly coupled` together because of all the direct instantiation that is occuring (the keyword *new*). Similarly, you'll see this behavior if you are using static calls. 

### But, it looks fine to me! What's the problem?
One of the problems with this is that you're very depending on the  details of the DAL. When creating the **DataReader** instance, you probably have to provide connection string details that tightly couples the code to whatever database you're using! 

Another problem with this is that the classes become *untestable*. In order to verify the logic that goes on inside of the business handler, you DEPEND on having a database ready to connect to  to execute the code. And you cannot easily simulate connection loss, erratic or faulty data as part of your unit-testing regime. Some languages allow for workarounds but the resulting unit-tests often become needlessly complicated and hard to read.

### Dependency Inversion to the rescue!
DIP states that we need to get rid of this form of `coupling`. One of the ways to achieve this is by using a process known as  `Dependency injection`, which allows you to insert the dependencies as part of object construction. 

For the above example, it means a couple of things: 
* Define `interfaces` for all the dependencies, starting with the business layer
* Let a `Class Factory` instance or `Inversion of Control` container resolve the interfaces for you. 

This leaves you with code that is easy to unit-test, and easy to replace!
Every dependency is abstracted in an interface that is easy to Mock out for your unit testing requirements, and if you need to change your datareader to point to SQL instead of Oracle, you only need to implement the `IDataReader.DoStuff()` in a different class to support both!

Additionally, it is often recommended to define all entities and interfaces in one single, domain-wide layer: 

```csharp
/*
 * Contracts (interfaces) within the bounded scope of the application
 */
public interface IBusinessHandler{
    string LookupSomething();
}

public interface IDataReader{
    string GetStuff();
}

public interface ILogger{
    void Warning(string message);
}

public interface IValidator{
    bool IsValid(string someValue);
}
```

This helps a new developer get an overview over the entities and contracts in the current application.

### Sample implementation

```csharp
// IBusinessHandler implementation in BLL
public class BusinessHandler : IBusinessHandler
{
    // External dependencies
    private readonly IDataReader _dataReader;
    private readonly IValidator  _validator;
    private readonly ILogger     _log;

    // Constructor with dependencies injected 
    public BusinessHandler(IDataReader dataReader, IValidator validator, ILogger log)
    {
        _dataReader = dataReader;
        _validator  = validator;
        _log        = log;
    }

    public string LookupSomething()
    {        
        var stuff = _dataReader.GetStuff();

        if(_validator.IsValid(stuff))
            _log.Warning("No stuff to be found");

        return stuff;
    }
}

// IValidator implementation in BLL
public class Validator : IValidator 
{
    public bool IsValid(string stuff)
    {
        if(string.IsNullOrEmpty(stuff))
            return false;

        if(string.Length > 255)
            return false;

        if(string.Contains("evil"))
            return false;

        return true;
    }
}

// IDataReader implementation in DAL
public class SqlDataReader : IDataReader
{
    // External dependencies
    private readonly ILogger _log;

    // Constructor with dependency injection
    public DataReader(ILogger log)
    {
        _log = log;
    }

    public string GetStuff()
    {
        var connection = new Connection(...);
        var sqlStatement = "SELECT top 1 * from something";

        var result = connection.ExecuteSql(sqlStatement);
        if(string.IsNullOrEmpty(result))
            _log.Warning("SQL found nothing");

        return result ?? "no stuff";        
    }
}

 // Finally, somewhere In the UI:
public class TheForm
{
    private IBusinessHandler _businessHandler;

    // Constructor example using an IoC Container
    public TheForm()
    {
        _businessHandler = App.Current.DIContainer.GetInstance<IBusinessHandler>();
    }

    // Someone clicked the button
    public void MyButtonClick(object sender, ButtonClickEvent e)
    {        
        someTextField.Value = _businessHandler.LookupSomething();
    }
}
```

> **NOTE**: <br />
> IoC Containers and Class Factories are out of the scope of this document

### Whoa! What happened there?
In the (lengthy) example above, you can see how the UI layer no longer has any dependencies on classes, but instead only has knowledge of the `IBusinessHandler` interface. In the code example, an `IoC Container` is used to create an instance of the class that implements that contract (our **BusinessHandler** class defined further above). The Container will detect that this **BusinessHandler** has 3 dependencies, and instanciate those properly. 

This makes the **BusinessHandler** class fully unit-testable. All of the code branches can be tested without touching any of the dependencies since, at the time of running the unit test, those classes can be easilly replaced with `fakes`, `stubs` or `mocks`. 

So, if you're the developer behind this solution, and your manager asks you to support Oracle, all you have to do is to provide a *new* implementation of your **IDataReader** interface:


```csharp
public class OracleDataReader : IDataReader
{
    // Constructor with dependency injection
    public DataReader(ILogger log)
    {
        _log = log;
    }

    public string GetStuff()
    {
        var connection = new Connection(...);
        var sqlStatement = "SELECT * from something WHERE rownum = 1;";

        var result = connection.GetFromTSql(sqlStatement);
        if(string.IsNullOrEmpty(result))
            _log.Warning("Oracle found nothing");

        return result ?? "no stuff";        
    }    
}
```

Deciding between Oracle and SQL Server now becomes as easy as to configure the IoC Container which implementation of the `IDataReader` to choose. **DIP** gives your code modularity!



**Conclusion** <br />
Avoid creating objects inside your class methods. Instead inject all object dependencies to allow your code to be modular and more unit-testable, as well as easier to maintain!

## Final Thoughts 
In projects that implement SOLID, you will often find classes whose single responsibility is to orchestrate together a set of external dependencies in a specified order. Keeping SRP means every class is easy to understand and maintain. By extending your classes instead of modifying them (OCP) you are keeping your libraries compatible across multiple versions. LSP and ISP are there to keep your code sane, coherent and clear. And last, but definetly not least, the ISP is the principle that makes Unit-Testing and modularizing your project a breeze.

By adopting the SOLID principles, you will be well on your way to writing code that is easy to maintain, easy to understand, and easy to unit-test. These principles also give you alternative ways to communicate questions and concerns about code, i.e. "John, can you help me overlook this piece of code? I think I may be in violation of the substitution principle, but I can't be sure". 

