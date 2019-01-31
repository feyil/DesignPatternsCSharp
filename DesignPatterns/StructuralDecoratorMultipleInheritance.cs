using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDecoratorMultipleInheritance
{
    public interface IBird
    {
        int Weight { get; set; }
        void Fly();
    }

    public interface ILizard
    {
        int Weight { get; set; }
        void Crawl();
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            Console.WriteLine($"Fly {Weight}");
        }
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl()
        {
            Console.WriteLine($"Crawl {Weight}");
        }
    }

    public class Dragon : IBird, ILizard
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();
        private int weight;

        public int Weight
        {
            get { return weight;  }
            set
            {
                weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            }
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }
    }

    public class Program
    {
        //static void Main(string[] args)
        //{
        //    var d = new Dragon();
        //    d.Weight = 123;
        //    d.Fly();
        //    d.Crawl();
        //}
    }
}
