using Exam_BankAccount.Class;
using Exam_BankAccount.Class_Abstract;
using Exam_BankAccount.Interface;
using System;

namespace Exam_BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Konto k;
            KontoLokata lokata1 = new KontoLokata();
            KontoLokata lokata2 = new KontoLokata();
            KontoOsobiste konto1 = new KontoOsobiste();
            KontoOsobiste konto2 = new KontoOsobiste();
            
            Bank bank1 = new Bank("1111");
            Bank bank2 = new Bank("2222");
            Bank bank3 = new Bank("1111");
            Bank bank4 = new Bank("000");

            //wplacam kase i oczekuje zysku
            if (bank1.WyszukajKonto())
            {
                lokata1.Wplac(1000);
                lokata1.ObliczZysk(12.00);
                k = lokata1;
                Console.WriteLine(k);
            }

            //wplacam kase, oczekuje zysku oraz wyplacam 
            if (bank2.WyszukajKonto())
            {
                lokata2.Wplac(1000);
                lokata2.ObliczZysk(12.00);
                lokata2.Wyplac(600);
                k = lokata2;
                Console.WriteLine(k);
            }

            //wplacam kase i wyplacam wiecej 
            if (bank3.WyszukajKonto())
            {
                konto1.Wplac(1000);
                konto1.Wyplac(1100);
                k = konto1;
                Console.WriteLine(k);
            }

            //nieprawidłowy numer konta
            if (bank4.WyszukajKonto())
            {
                konto2.Wplac(1000);
                konto2.Wyplac(500);
                k = konto2;
                Console.WriteLine(k);
            }

            Console.ReadKey();
        }

    }


}
