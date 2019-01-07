using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalBuilderInheritance
{
    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string BirthDate { get; set; }
        public string Manager { get; set; }

        //class Builder : PersonInfoBuilder<Builder> { /* degenerate */}

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}, {nameof(BirthDate)}: {BirthDate}";
        }
    }

    // write public it causes error at some times
    public abstract class PersonBuilder
    {
        protected Person person; // TODO intialize

        public PersonBuilder()
        {
            person = new Person();
        }

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<SELF> : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorkAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }

        public SELF BirthDate(string birthDate)
        {
            person.BirthDate = birthDate;
            return (SELF)this;
        }
    }
/*
    public class BuilderInheritanceDemo
    {
        static void Main(string[] args)
        {
            var me = Person.New
                .Called("Furkan")
                .WorkAsA("Developer")
                .Build();
            Console.WriteLine(me);

            var he = Person.New
                .WorkAsA("Doctor")
                .BirthDate("10/12/14")
                .Called("Emre")
                .Build();
            Console.WriteLine(he);
        }
    }
    */
}


