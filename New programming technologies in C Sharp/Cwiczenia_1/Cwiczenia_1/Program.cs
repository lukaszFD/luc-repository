using System;
using System.Threading;
using Cwiczenia_1.CLasses;

namespace Cwiczenia_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Cwiczenie_1

            //Account k = new Account("Jan Kowalski", "37562", "mala", "czarna");
            //k.Zaloguj("mala", "czarna");
            //Console.WriteLine(k);
            //k.Wyloguj();
            //k.Wplac(10.50);
            //Console.WriteLine(k);
            //k.Wyplac(10.50);
            //Console.WriteLine(k);
            //Console.WriteLine("\nNaciœnij dowolny klawisz");
            //Thread.Sleep(1000);
            //k.Zaloguj("mala", "czarna");
            //k.ChangePassword("mala", "czarna");
            //Console.ReadKey();

            #endregion

            #region Cwiczenie_2

            //Hours godz0 = new Hours();
            //Hours godz1 = new Hours();
            //Hours godz2 = new Hours();
            //godz0.Hour = 0;
            //godz1.Hour = 9;
            //godz2.Hour = 18;
            //Console.WriteLine(godz0);
            //Console.WriteLine(godz1);
            //Console.WriteLine(godz2);
            //Console.ReadKey();

            #endregion

            #region Cwiczenie_3

            //string[] account = { "Podstawowe", "VIP" };

            //for (int i = 0; i < account.Length; i++)
            //{
            //    Console.WriteLine(account[i]);
            //}
            //Console.ReadKey();

            #endregion

            #region Cwiczenie_4

            //Worker work = new Worker("Nowak", 3200);
            //Console.WriteLine(work);
            //Boss boss = new Boss();
            //boss.Increase(work, 4000);
            //Console.WriteLine(work);
            //Console.ReadKey();

            /*
            odpowiedz : Ponieważ w właściwości "Salary" Get-er był prywatny oraz w metodzie "Increase" brakowało operatora dodawania.
            */
            #endregion

            #region Cwiczenie_6

            Console.WriteLine(new Rectangle(2,4).Diagonal());
            Console.ReadKey();

            #endregion
        }
    }
}
