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

## Creational Design Patterns

### Builder Design Pattern

* A builder is a separate component for building an object
* Can either give builder a constructor or return it via a static function
* To make builder fluent, return this
* Different facets of an object can be built with different builders working in tandem via a base class
* Seperate component for when object construction gets too complicated
* Can create mutally cooperating sub-builders
* Often has a fluent interface

### Factories

* A factory method is a static method that creates objects
* A factory can take care of object creation
* A factory can be external or reside inside the object as an inner class
* Hierarchies of factories can be used to create related objects
* Factory method more expressive than constructor
* Factory can be an outside class or inner class; inner class has the benefit of accessing private members

### Prototype

* To implement a prototype partially construct an object and store it somewhere
* Clone the prototype
	* Implement your own deep copy fuctionality: or
	* Serialize and deserialize
* Customize the resulting instance
* Creation of object from an existing object
* Requires either explicit deep copy or copy through serialization

### Singleton

* Making a 'safe' singleton is easy: construct a static Lazy< T > and return its Value
* Singletons are difficult to test
* Instead of directly using a singleton, consider depending on an abstraction (e.g, an interface)
* Consider defining singleton lifetime in DI container
* When you need to ensure just a single instance exists
* Made thread-sae and lazy with Lazy<T>
* Consider extracting interface or using dependency injection

## Structural Design Patterns

### Adapter

* Implementing an Adapter is easy
* Determine the API you have and the API you need
* Create a component which aggregates(has a reference to, ...) the adaptee
* Intermediate repsresentations can pile up: use caching and other optimizations.
* Converts the interface you get to the interface you need

### Bridge

* Decouple abstraction from implementation
* Both can exist as hierarchies
* A stronger form of encapsulation
* Decouple abstraction from implementation

### Composite

* Objects can use other objects via inheritance/composition
* Some composed and singular objects need similar/identical behaviors
* Composite design pattern lets us threat both types of objects uniformly
* C# has special support for the enumeration concept
* A single object can masquerade as a collection with yield return this;
* Allow clients to treat individual objects and compositions of objects uniformly

### Decorator

* A decorator keeps the reference to the decorated object(s)
* May or may not proxy over calls
* Exist in a static variation
	* X< Y < Foo > >
	* Very limited due to inability to inherit from type parameters
* Attach additional responsibilities to objects

### Fa�ade

* Build a Fa�ade to provide a simplified API over a set of classees
* May wish to (optionally) expose internals through the fa�ade
* May allow users to 'escalate' to use more complex APIs if they need to
* Provide a single unified interface over a set of classes/systems

### Flyweight

* Store common data externally
* Define idea of 'ranges' on homogeneous collections and store data related to those ranges
* .NET string interning is the Flyweight pattern
* Efficiently support very large numbers of similar objects

### Proxy

* A proxy has the same interface as the underlying object
* To create a proxy, simply replicate the existing interface of an object
* Add relevant functionality to the redfined member functions
* Different proxies (communication, logging, caching, etc.) have completely different behaviors
* Provide a surrogate object that forwards calls to the real object while performing additional functions
* Dynamic proxy creates a proxy dynamically, without the necessity of replicating the target object API

### Proxy vs. Decorator

* Proxy provides an identical interface; decorator provides an enhanced interface
* Decorator typically aggregates (or has reference to) what it is decorating; proxy doesn not have to
* Proxy might not even be working with a materialized object

## Behavioral Design Patterns

### Chain of Responsibility

* Chain of Responsibility can be implemented as a chain of references or a centralized construct
* Enlist objects in the chain possibly controlling their order
* Object removal from chain (e.g in Dispose())
* Allow components to process information/events in a chain
* Each element in the chain refers to next element; or
* Make a list and go through it

### Command

* Encapsulate all details of an operation in a separate object
* Define instruction for applying the command (either in the command itself, or elsewhere)
* Optionally define intructions for undoing the command
* Can create composite commands (a.k.a. macros)
* Good for audit, reply, undo/redo
* Part of CQS/CQRS (Query is also, effectively, a command)

### Interpreter

* Barring simple cases, an interpreter acts in two stages
* Lexing turns text into a set of tokens, e.g. (Star, Lpran, Lit, Plus, Lit, Rparen)
* Parsing tokens into meaninful constructs (MultiplicationExpression, Integer, AddtionExpression, Integer)
* Parsed data can then be traversed
* Transform textual input into object-oriented structures
* Used by interpreters compilers, static analysis tools, etc.
* Compiler Theory is a separate branch of Computer Science

### Iterator

* An iterator specified how you can traverse an object
* An iterator object, unlike a method, cannot be recursive
* Generally, an IEnumerable<T> returning method is enough
* Iteration works through duck typing - you need a GetEnumerator() that yields a type that has Current and MoveNext()
* Provides an interface for accesing elements of an aggregate object
* IEnumerable<T> should be used in 99% of cases

### Mediator

* Create the mediator and have each object in the system refer to it
* Mediator engages in bidirectional communication with its connected components
* Mediator has functions the components can call
* Components have functions the mediator can call
* Event processing libraries make communication easier to implement
* Provides mediation services between two objects
* E.g. message passing, chat room

### Memento

* Mementos are used to roll back states arbitrarily
* A memento is simply a token/handle class with (typically) no functions of its own
* A memento is not required to expose directly state(s) to which it reverts the system
* Can be used to implement undo/redo
* Yields tokens representing system states
* Tokens do not allow direct manipulation, but can be used in appropriate APIs

### Null Object

* Implement the required interface
* Rewrite the methods with empty bodies
	* If method is non-void, return default(T)
	* If these values are ever used, you are in trouble
* Supply an instance of Null Object in place of actual object
* Dynamic construction possible
	* With associated performance implications

### Observer

* Observer is an intrusive approach: an observable must provide an event to subscribe to
* Special care must be taken to prevent issues in multithreaded scenarios
* .NET comes with observable collections
* IObserver<T> / IObservable<T> are used in stream processing (Reactive Extensions)
* Built into C# with the event keyword
* Additional support provided for properties, collections and observable streams

### State

* Given sufficient complexity, it pays to formally define possible states and events/triggers
* Can define
	* State entry/exit behaviors
	* Action when a particular event causes a transition
	* Guard conditions enabling/disabling a transition
	* Default action when no transition are found for an event
* We model systems by having one of a possible states and transitions between these states
* Such a system is called a state machine
* Special framework exists to orchestrate state machines

### Strategy

* Define an algorithm at a high level
* Define the interface you expect each strategy to follow
* Provide for either dynamic or static composition of strategy in the overall algorithm

### Template

* Define an algorithm at a high level
* Define constituent parts as abstract methods/properties
* Inherit the algorithm class, providing necessary overrides

### Strategy & Template Method

* Both patterns define an algorithm blueprint/placeholder
* Strategy uses composition, Template Method uses inheritance

### Visitor

* Propagate an accept(Visitor v) method throughout the entire hierarchy
* Create a visitor with Visit(Foo), Visit(Bar), for each element in the hierarchy
* Each accept() simply calls visitor.Visi(this)
* Using dynamic, we can invoke right overload based on argument type alone (dynamic dispatch)
* Adding functionality to existing classes through double dispatch
* Dynamic visitor possible, but with performance cost.