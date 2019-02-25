using System;
using System.Linq;
using ConsoleTable.Core;

namespace ConsoleTable.Sample
{
    class Program
    {
        static void Main(String[] args)
        {
            var table = new Core.ConsoleTable("one", "two", "three");
            table.AddRow(1, 2, 3)
                 .AddRow("this line should be longer", "yes it is", "oh");

            Console.WriteLine("\nFORMAT: Default:\n");
            table.Write();

            Console.WriteLine("\nFORMAT: MarkDown:\n");
            table.Write(ConsoleTableFormat.MarkDown);

            Console.WriteLine("\nFORMAT: Alternative:\n");
            table.Write(ConsoleTableFormat.Alternative);
            Console.WriteLine();

            Console.WriteLine("\nFORMAT: Minimal:\n");
            table.Write(ConsoleTableFormat.Minimal);
            Console.WriteLine();

            table = new Core.ConsoleTable("I've", "got", "nothing");
            table.Write();
            Console.WriteLine();

            var rows = Enumerable.Repeat(new Something(), 10);



            Core.ConsoleTable.From<Something>(rows).Write();

            rows = Enumerable.Repeat(new Something(), 0);
            Core.ConsoleTable.From<Something>(rows).Write();

            var noCount =
            new Core.ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "one", "two", "three" },
                EnableCount = false
            });

            noCount.AddRow(1, 2, 3).Write();

            Console.ReadKey();
        }
    }

    public class Something
    {
        public Something()
        {
            Id = Guid.NewGuid().ToString("N");
            Name = "Khalid Abuhkameh";
            Date = DateTime.Now;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
