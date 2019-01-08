using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPrototypeCopyConstructors
{
    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Address(string streetAddress, string city, string country)
        {
            StreetAddress = streetAddress;
            City = city;
            Country = country;
        }

        // Copy constructor
        public Address(Address other)
        {
            StreetAddress = other.StreetAddress;
            City = other.City;
            Country = other.Country;
        }

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(City)}: {City}, {nameof(Country)}: {Country}";
        }
    }

    public class Employee
    {
        public string Name;
        public Address Address;

        public Employee(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        // copy constructor
        public Employee(Employee other)
        {
            Name = other.Name;
            // calling address copy constructor
            Address = new Address(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }
    /*
    public class CopyConstructors
    {
        public static void Main(string[] args)
        {
            var john = new Employee("John", new Address("123 London Road", "London", "UK"));

            // var chris = john;
            var chris = new Employee(john);

            chris.Name = "Chris";
            Console.WriteLine(john); 
            Console.WriteLine(chris);
        }
    }
    */
}
