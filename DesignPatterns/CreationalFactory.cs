using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalFactory
{
    public class Point
    {
        private double x, y;

        // internal Point() can be thought
        protected Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(double a,
            double b, // name do not communicate intent
            CoordinateSystem cs = CoordinateSystem.Cartesian)
        {
            switch (cs)
            {
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    x = a;
                    y = b;
                    break;
            }

            // steps to add a new system
            // 1. augmnet CoordinateSystem
            // 2. change ctor

        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        // factory property
        public static Point Origin => new Point(0, 0);

        // singleton field ??
        public static Point Origin2 = new Point(0, 0);

        // factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }

        // make it lazy
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y); 
            }
        }
    }

    public static class PointFactory
    {
        public static Point NewCartesianPoint(float x, float y)
        {
            return new Point(x, y); // needs to be public
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
/*
    public class Demo
    {
        static void Main(string[] args)
        {
            // not a good idea
            var p1 = new Point(2, 3, Point.CoordinateSystem.Cartesian);

            var origin = Point.Origin;

            // better approach using Factory inner class
            var p2 = Point.Factory.NewCartesianPoint(1, 2);

            // it also possible but constructor should be public
            var p3 = PointFactory.NewCartesianPoint(4, 5);

            // factory method
            var p4 = Point.NewCartesianPoint(2, 3);

            Console.WriteLine(p2);
        }
  */ 
}
