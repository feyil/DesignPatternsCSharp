using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDecorator
{
    public interface IShape
    {
        string AsString();
    }

    public class Circle : IShape
    {
        private float radius;

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public void Resize(float factor)
        {
            radius *= factor;
        }
        
        public string AsString()
        {
            return $"A cirlce with radius {radius}";
        }
    }

    public class Square : IShape
    {
        private float side;

        public Square(float side)
        {
            this.side = side;
        }

        public string AsString()
        {
            return $"A square with side {side}";
        }
    }

    public class ColoredShpae : IShape
    {
        private IShape shape;
        private string color;
        
        public ColoredShpae(IShape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }

        public string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }

    public class TransparentShape : IShape
    {
        private IShape shape;
        private float transparency;

        public TransparentShape(IShape shape, float transparency)
        {
            this.shape = shape;
            this.transparency = transparency;
        }

        public string AsString()
        {
            return $"{shape.AsString()} has {transparency * 100.0}% transparency";
        }
    }

    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    var square = new Square(1.23f);
        //    Console.WriteLine(square.AsString());

        //    var redSquare = new ColoredShpae(square, "red");
        //    Console.WriteLine(redSquare.AsString());

        //    var redHalfTranparentSquare = new TransparentShape(redSquare, 0.5f);
        //    Console.WriteLine(redHalfTranparentSquare.AsString());
        //}
    }

}
