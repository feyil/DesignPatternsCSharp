# Design Patterns with C#

Design Pattern implementations with C# (Tutorial)

Created to understand design patterns deeply. These codes written by following a series of tutorials. I am putting these to access whenever I need to recap design patterns. 

### The SOLID Design Principles

##### Single Responsibilility Principle

* A class should only have one reason to change
* Sepation of concerns - different classes handling different, independent tasks/problems

##### Open-Closed Principle

* Classes should be open for extension but closed for modification

##### Liskov Substition Principle

* You should be able to substitute a base type for a subtype

##### Interface Segregation Principle

* Don't put too much into an interface; split into seperate interfaces
* YAGNI - You ain't going to need it

##### Dependency Inversion Principle

* High-level modules should not depend upon low-level ones; use abstractions

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

### Singletons

* Making a 'safe' singleton is easy: construct a static Lazy<T> and return its Value
* Singletons are difficult to test
* Instead of directly using a singleton, consider depending on an abstraction (e.g, an interface)
* Consider defining singleton lifetime in DI container