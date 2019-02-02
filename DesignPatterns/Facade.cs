using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public interface Shape
    {
        void Draw();
    }

    public class Rectangle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Rectangle::Draw()");
        }
    }

    public class Square : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Square::Draw()");
        }
    }

    public class Circle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Circle::Draw()");
        }
    }

    // facade class 
    public class ShapeMaker
    {
        private Shape circle;
        private Shape rectangle;
        private Shape square;

        public ShapeMaker()
        {
            circle = new Circle();
            rectangle = new Rectangle();
            square = new Square();
        }

        public void DrawCircle()
        {
            circle.Draw();
        }

        public void DrawRectangle()
        {
            rectangle.Draw();
        }

        public void DrawSquare()
        {
            square.Draw();
        }
    }

    // Use the facde to draw various types of shapes
    public class Program
    {
        public static void Main(string[] args)
        {
            ShapeMaker shapeMaker = new ShapeMaker();

            shapeMaker.DrawCircle();
            shapeMaker.DrawRectangle();
            shapeMaker.DrawSquare();
        }
    }

}
