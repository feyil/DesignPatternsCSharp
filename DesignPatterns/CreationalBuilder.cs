using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalBuilder
{
    class HtmlElement
    {
        public String Text { get; set; }
        public string Name { get; set; }
        public List<HtmlElement> Elements { get; set; }
        private const int indentSize = 2;

        public HtmlElement()
        {
            Elements = new List<HtmlElement>();
        }

        public HtmlElement(string name, string text) : this()
        {
            Name = name;
            Text = text;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.Append($"{i}<{Name}>\n");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.Append(Text);
                sb.Append("\n");
            }

            // TODO Look where the Elements is filled.
            foreach(var e in Elements)
            {
                sb.Append(e.ToStringImpl(indent + 1));
            }

            sb.Append($"{i}</{Name}>\n");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    class HtmlBuilder
    {
        private readonly string rootName;
        public HtmlElement Root {get; set;}

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            Root = new HtmlElement();
            Root.Name = rootName;
        }

        // not fluent
        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            Root.Elements.Add(e);
        }

        // fluent interface allow chaining
        public HtmlBuilder AddChildFluent(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            Root.Elements.Add(e);
            return this;
        }

        public void Clear()
        {
            Root = new HtmlElement { Name = rootName };
        }

        public override string ToString()
        {
            return Root.ToString();
        }
    }
    /*
    public class Demo
    {
        static void Main(string[] args)
        {
            // if you want to build a simple HTML paragraph using StringBUilder
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            // now I want an HTML list with 2 words in it
            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach(var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);

            // ordinary non-fluent builder
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            Console.WriteLine(builder.ToString());

            // fluent builder
            sb.Clear();
            builder.Clear();
            builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
            Console.WriteLine(builder);

        }
    }
    */
}
