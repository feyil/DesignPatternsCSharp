using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacetedBuilder
{
    public class Person
    {
        // address
        public string StreetAddress { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }

        // employment
        public string CompanyName { get; set; }
        public string Position { get; set; }

        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    // I think we can change it as an interface also
    public class PersonBuilder // facade
    {
        // the object we're goint to build
        protected Person person = new Person(); // this is a reference

        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public PersonJobBuilder Works => new PersonJobBuilder(person);

        // think about it
        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonBuilder Earning(int annualIncome)
        {
            person.AnnualIncome = annualIncome;
            return this;
        }
     }

    public class PersonAddressBuilder : PersonBuilder
    {
        // might not work with a value type!
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb
                .Lives
                    .At("123 London Road")
                    .In("London")
                    .WithPostcode("SW12BC")
                .Works
                    .At("Fabrikam")
                    .AsA("Engineer")
                    .Earning(123000);

            Console.WriteLine(person);
        }
    }
}
