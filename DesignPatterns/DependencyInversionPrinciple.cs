using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    // High level parts of the system should not depend on low level
    // part of the system directly instead we should introduce abstraction
    
    public enum Relationship
    {
        Parent, 
        Child,
        Sibling
    }

    public class Person
    {
        public string Name { get; set; }
        // public DateTime DateOfBirth;
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser // low level
    {
        private List<(Person, Relationship, Person)> relations;

        public Relationships()
        {
            relations = new List<(Person, Relationship, Person)>();
        }

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
        }

        public List<(Person, Relationship, Person)> Relations => relations;

        public IEnumerable<Person> FindAllChildrenOf(String name)
        {
            return relations
                .Where(x => x.Item1.Name == name
                            && x.Item2 == Relationship.Parent).Select(r => r.Item3);
        }
    }
    /*
    public class Research
    {
        //public Research(Relationships relationships)
        //{
        //    // high-level: find all of John's children
        //    var relations = relationships.Relations;
        //    foreach (var r in relations
        //        .Where(x => x.Item1.Name == "John"
        //                    && x.Item2 == Relationship.Parent))
        //    {
        //        Console.WriteLine($"John has a child called {r.Item3.Name}");
        //    }

        //    // Crtl + K + C
        //    // Crtl + K + U
        //}

        public Research(IRelationshipBrowser browser)
        {
            foreach(var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {p.Name}");
            }
        }

        public static void Main(string[] args)
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Matt" };

            // low-level module
            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);

        }
    }
    */
}
