using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralObserverEvents
{
    public class FallsIllEventArgs
    {
        public string Address { get; set; }
    }

    public class Person
    {
        public event EventHandler<FallsIllEventArgs> FallsIll;

        public void CatchACold()
        {
            FallsIll?.Invoke(this,
                new FallsIllEventArgs { Address = "123 London Road" });
        }
    }

    public class Demo
    {
        //public static void Main(string[] args)
        //{
        //    var person = new Person();

        //    person.FallsIll += CallDoctor;

        //    person.CatchACold();
        //}

        private static void CallDoctor(object sender, FallsIllEventArgs eventArgs)
        {
            Console.WriteLine($"A doctor has been called to {eventArgs.Address}");
        }
    }
}
