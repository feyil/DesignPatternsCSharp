using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class Journal
    {
        private static int count = 0;
        private readonly List<string> entries;

        public Journal()
        {
            this.entries = new List<string>();
        }

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class JournalPersistence
    {

        public JournalPersistence()
        {

        }

        public void SaveToFile(Journal j, string fileName, bool overwrite = false)
        {
            if (overwrite || !File.Exists(fileName))
            {
                File.WriteAllText(fileName, j.ToString());
            }
        }
    }
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("Furkan");
            j.AddEntry("Emre");

            Console.WriteLine(j);

            var p = new JournalPersistence();
            // anything seen as escape sequence is ignore with '@'
            var fileName = @"c:\temp\journal.txt";
            p.SaveToFile(j, fileName, true);
            Process.Start(fileName);

            Console.ReadKey();
        }
    }
    */
}
