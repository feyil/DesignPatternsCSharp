using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    // using a classic example
    public class Rectangle
    {
        // public int Width { get; set; }
        // public int Height { get; set; }

         public virtual int Width { get; set; }
         public virtual int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
 
        public override string ToString()
        {
            return $"{nameof(Width)} : {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        /*
        public new int Width
        {
            set { base.Width = base.Height = value; }
        }

        public new int Height
        {
            set { base.Width = base.Height = value; }
        }
        */

        public override int Width { get => base.Width ; set => base.Width = base.Height = value; }
        public override int Height { get => base.Height; set => base.Height = base.Width = value; }
    }
  /*
    public class Program
    {
        static public int Area(Rectangle r) => r.Width * r.Height;

        public static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            // Should be able to substitute a base type for a subtype
            Rectangle sq = new Square();
            sq.Width = 4;

           
            // If you don't use virtual and override polymorphism can not be succeed
            // Rectangle sq = new Square();
            // sq.Width = 4;
           
            
            Console.WriteLine($"{sq} has area {Area(sq)}");
        }
    }
    */

}
