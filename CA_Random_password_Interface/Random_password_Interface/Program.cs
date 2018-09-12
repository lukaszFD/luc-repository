using System;
using Random_password_Interface.Class;
using Random_password_Interface.Class.Generator;
using System.Net;
using System.IO;

namespace Random_password_Interface
{
    class Program 
    {
        static void Main(string[] args)
        {

            string p  = new Passwords().Pass(new RndPasswordManyDifferentCharacters());
            string p2 = new Passwords().Pass(new RndPasswordNumbers());
            string p3 = new Passwords().Pass(new RndPasswordSpecialCharacters());
            string p4 = new Passwords().Pass(new RndPasswordUpperAndLowercaseLetters());

            Console.WriteLine(p + Environment.NewLine + p2 + Environment.NewLine + p3 + Environment.NewLine + p4);

            Console.ReadKey();

        }
    }
}
