using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace LaunchEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of parts.
            List<Part> parts = new List<Part>();

            // Add parts to the list.
            parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
            parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
            parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
            parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
            parts.Add(new Part() { PartName = "shift lever", PartId = 1634 });

            //XML.CretaeXMLDoc(parts, @"C:\Users\Luc\Documents\GitHub\luc-repository\Utils\Files\Part.xml");
            foreach (IEnumerable<char> g in parts.Chunk(3))
            {
                // Print out the group.
                Console.Write("Group: {0} - ", ++count);

                // Print the items.
                foreach (char c in g)
                {
                    // Print the item.
                    Console.Write(c + ", ");
                }

                // Finish the line.
                Console.WriteLine();
            }

            Console.WriteLine(parts.Count()/4);
            Console.ReadKey();

        }
    }
}
