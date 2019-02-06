# Design Patterns with C#

Design Pattern implementations with C# (Tutorial)

Created to understand design patterns deeply. These codes written by following a series of tutorials. I am putting these to access whenever I need to recap design patterns. 

### The SOLID Design Principles

##### Single Responsibilility Principle

* A class should only have one reason to change
* Sepation of concerns - different classes handling different, independent tasks/problems

##### Open-Closed Principle

* Classes should be open for extension but closed for modification
* You can easily change the lens of most SLR cameras without having to saw off the old lens and weld on a new one. You can add filters to most SLR cameras lens by just screwing them on

##### Liskov Substition Principle

* Objects in a program should be replaceable with instances of their subtypes without altering the correctness of that program
* Functions that use pointers or references to base classes must be able to use objects of devierd classes without knowing it
* As you extend objects the original functionality of the elements that makeup the object should not change
* Any Base 10 calculator should produce result of 4 when you press 2+2 regardless of the age or sophistication of the device
* The original functionality of objects should be preserved as you build on them.

##### Interface Segregation Principle

* Don't put too much into an interface; split into seperate interfaces
* YAGNI - You ain't going to need it

##### Dependency Inversion Principle (Inversion of Control) (Dependency Injection)

* High level modules should not depend upon low level modules. Both should depend upon abstractions
* Abstractions should not depend upon details. Details should depend upon abstractions.
* Screwdriver bits do not care what brand or type of Slotted Screwdriver they are used with

### Builder Design Pattern

* A builder is a separate component for building an object
* Can either give builder a constructor or return it via a static function
* To make builder fluent, return this
* Different facets of an object can be built with different builders working in tandem via a base class

### Factories

* A factory method is a static method that creates objects
* A factory can take care of object creation
* A factory can be external or reside inside the object as an inner class
* Hierarchies of factories can be used to create related objects

### Prototype

* To implement a prototype partially construct an object and store it somewhere
* Clone the prototype
	* Implement your own deep copy fuctionality: or
	* Serialize and deserialize
* Customize the resulting instance

### Singleton

* Making a 'safe' singleton is easy: construct a static Lazy< T > and return its Value
* Singletons are difficult to test
* Instead of directly using a singleton, consider depending on an abstraction (e.g, an interface)
* Consider defining singleton lifetime in DI container

### Adapter

* Implementing an Adapter is easy
* Determine the API you have and the API you need
* Create a component which aggregates(has a reference to, ...) the adaptee
* Intermediate repsresentations can pile up: use caching and other optimizations.

### Bridge

* Decouple abstraction from implementation
* Both can exist as hierarchies
* A stronger form of encapsulation

### Composite

* Objects can use other objects via inheritance/composition
* Some composed and singular objects need similar/identical behaviors
* Composite design pattern lets us threat both types of objects uniformly
* C# has special support for the enumeration concept
* A single object can masquerade as a collection with yield return this;

### Decorator

* A decorator keeps the reference to the decorated object(s)
* May or may not proxy over calls
* Exist in a static variation
	* X< Y < Foo > >
	* Very limited due to inability to inherit from type parameters

### Façade

* Build a Façade to provide a simplified API over a set of classees
* May wish to (optionally) expose internals through the façade
* May allow users to 'escalate' to use more complex APIs if they need to

### Flyweight

* Store common data externally
* Define idea of 'ranges' on homogeneous collections and store data related to those ranges
* .NET string interning is the Flyweight pattern

### Proxy

* A proxy has the same interface as the underlying object
* To create a proxy, simply replicate the existing interface of an object
* Add relevant functionality to the redfined member functions
* Different proxies (communication, logging, caching, etc.) have completely different behaviors

### Proxy vs. Decorator

* Proxy provides an identical interface; decorator provides an enhanced interface
* Decorator typically aggregates (or has reference to) what it is decorating; proxy doesn not have to
* Proxy might not even be working with a materialized object

### Chain of Responsibility

* Chain of Responsibility can be implemented as a chain of references or a centralized construct
* Enlist objects in the chain possibly controlling their order
* Object removal from chain (e.g in Dispose())

### Command

* Encapsulate all details of an operation in a separate object
* Define instruction for applying the command (either in the command itself, or elsewhere)
* Optionally define intructions for undoing the command
* Can create composite commands (a.k.a. macros)

### Interpreter

* Barring simple cases, an interpreter acts in two stages
* Lexing turns text into a set of tokens, e.g. (Star, Lpran, Lit, Plus, Lit, Rparen)
* Parsing tokens into meaninful constructs (MultiplicationExpression, Integer, AddtionExpression, Integer)
* Parsed data can then be traversed

### Iterator

* An iterator specified how you can traverse an object
* An iterator object, unlike a method, cannot be recursive
* Generally, an IEnumerable<T> returning method is enough
* Iteration works through duck typing - you need a GetEnumerator() that yields a type that has Current and MoveNext()

### Mediator

* Create the mediator and have each object in the system refer to it
* Mediator engages in bidirectional communication with its connected components
* Mediator has functions the components can call
* Components have functions the mediator can call
* Event processing libraries make communication easier to implement

### Memento

* Mementos are used to roll back states arbitrarily
* A memento is simply a token/handle class with (typically) no functions of its own
* A memento is not required to expose directly state(s) to which it reverts the system
* Can be used to implement undo/redo