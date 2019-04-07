using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogData;
using BlogModel;


namespace BlogConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var repository = new BlogRepository())
            {
                // Get name for a new Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                // Create and save new Blog 
                var blog = new Blog { Name = name };
                repository.Add(blog);

                // Display all Blogs from the database 
                var list = repository.GetAll();

                Console.WriteLine("All blogs in the database:");
                foreach (var item in list)
                {
                    Console.WriteLine($"* {item.Name}");
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }

        }
    }
}
