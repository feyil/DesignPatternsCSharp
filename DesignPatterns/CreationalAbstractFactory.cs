using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalAbstractFactory
{
    public interface IHotDrink
    {
        void Consume();
    }

    // Think about internal classes
    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This teas is nice...");
        }
    }

    internal class Coffe : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This coffe is delicious!");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in tea bag, boild water, pour {amount} ml, add lemon..");
            return new Tea();
        }
    }

    internal class CoffeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans, boil water, pour {amount} ml add cream and suger, enjoy!");
            return new Coffe();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvaliableDrink // violates open-closed principle
        {
            Coffe, Tea
        }

        //// for enum implemation is used
        //private Dictionary<AvaliableDrink, IHotDrinkFactory> factories =
        //    new Dictionary<AvaliableDrink, IHotDrinkFactory>();

        // for other impl
        private List<Tuple<string, IHotDrinkFactory>> namedFactories =
            new List<Tuple<string, IHotDrinkFactory>>();
        
        public HotDrinkMachine()
        {
            //// enum impl
            //// return all enum values in list
            //foreach(AvaliableDrink drink in Enum.GetValues(typeof(AvaliableDrink)))
            //{
            //    // creates factories for enum types
            //    var factory = (IHotDrinkFactory)Activator.CreateInstance(
            //         Type.GetType("CreationalAbstractFactory." + Enum.GetName(typeof(AvaliableDrink), drink) + "Factory"));
            //      factories.Add(drink, factory);
            //}

            
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    // creates factories for enum types
                    namedFactories.Add(Tuple.Create(
                      t.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)Activator.CreateInstance(t)));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            Console.WriteLine("Available drinks");
            for(var index = 0; index < namedFactories.Count; index++)
            {
                var tuple = namedFactories[index];
                Console.WriteLine($"{index}: {tuple.Item1}");
            }

            while(true)
            {
                string s;
                if((s = Console.ReadLine()) != null
                    && int.TryParse(s, out int i)
                    && i >= 0
                    && i < namedFactories.Count)
                {
                    Console.Write("Specify amount: ");
                    s = Console.ReadLine();
                    if(s != null
                        && int.TryParse(s, out int amount)
                        && amount > 0)
                    {
                        return namedFactories[i].Item2.Prepare(amount);
                    }
                }
            }
            Console.WriteLine("Incorrect input, try again.");
        }

        //// enum impl
        //public IHotDrink MakeDrink(AvaliableDrink drink, int amount)
        //{
        //    return factories[drink].Prepare(amount);
        //}
    }
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();

            //// enum impl
            //var drink = machine.MakeDrink(HotDrinkMachine.AvaliableDrink.Tea, 300);
            //drink.Consume();

            IHotDrink drink = machine.MakeDrink();
            drink.Consume();

            //// It doesn't give mechanism to forbid use of new keyword
            //// think about it
            //IHotDrink drink2 = new Tea();
        }
    }
    */
}
