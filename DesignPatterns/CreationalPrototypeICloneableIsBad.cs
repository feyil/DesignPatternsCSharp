using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPrototypeICloneableIsBad
{
    // ICloneable is ill-specified

    public class Person : ICloneable
    {
        public string[] Names { get; }
        public Address Address { get; }

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            // shallow copy happens
            return new Person(Names, Address);
        }
    }

    public class Address : ICloneable
    {
        public string StreetName { get; }
        public int HouseNumber { get; set; }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }
    }

    public class Demo
    {
        public static void Main(string[] args)
        {
            var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));

            var jane = (Person)john.Clone();
            jane.Address.HouseNumber = 321; // opps, John is now at 321

            // this doesn't work
            // var jane = john;

            // but clone is typically shallow copy
            jane.Names[0] = "Jane";

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }
    }
}
