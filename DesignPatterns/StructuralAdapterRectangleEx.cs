using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralAdapterRectangleEx
{
    public class Square
    {
        public int Side { get; set; }
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        } 
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private readonly Square square;

        public SquareToRectangleAdapter(Square square)
        {
            this.square = square;
        }

        public int Width => square.Side;
        public int Height => square.Side;
    }

    public class Demo
    {
        public static void Main(string[] args)
        {

        }
    }

    namespace Test
    {
        [TestFixture]
        public class TestSuite
        {
            [Test]
            public void Test()
            {
                var sq = new Square { Side = 11 };
                var adapter = new SquareToRectangleAdapter(sq);
                Assert.That(adapter.Area(), Is.EqualTo(121));
            }
        }
    }

}


