using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralVisitorClassic
{
    public abstract class Expression
    {
        public abstract void Accept(IExpresionVisitor visitor);
    }

    public class DoubleExpression : Expression
    {
        public double Value;

        public DoubleExpression(double value)
        {
            Value = value;
        }

        public override void Accept(IExpresionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class AdditionExpression : Expression
    {
        public Expression Left;
        public Expression Right;

        public AdditionExpression(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }

        public override void Accept(IExpresionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }


    public interface IExpresionVisitor
    {
        void Visit(DoubleExpression de);
        void Visit(AdditionExpression ae);
    }

    public class ExpressionPrinter : IExpresionVisitor
    {
        StringBuilder sb = new StringBuilder();

        public void Visit(DoubleExpression de)
        {
            sb.Append(de.Value);
        }

        public void Visit(AdditionExpression ae)
        {
            sb.Append("(");
            ae.Left.Accept(this);
            sb.Append("+");
            ae.Right.Accept(this);
            sb.Append(")");
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }

    public class ExpressionCalculator : IExpresionVisitor
    {
        public double Result;

        // what we really want is int Visit(...)

        public void Visit(DoubleExpression de)
        {
            Result = de.Value;
        }

        public void Visit(AdditionExpression ae)
        {
            ae.Left.Accept(this);
            var a = Result;
            ae.Right.Accept(this);
            var b = Result;
            Result = a + b;
        }
    }

    public class Demo
    {
        public static void Main()
        {
            var e = new AdditionExpression(
                left: new DoubleExpression(1),
                right: new AdditionExpression(
                    left: new DoubleExpression(2),
                    right: new DoubleExpression(3)));

            var ep = new ExpressionPrinter();
            ep.Visit(e);
            Console.WriteLine(ep.ToString());

            var calc = new ExpressionCalculator();
            calc.Visit(e);
            Console.WriteLine($"{ep} = {calc.Result}");
        }
    }
}
