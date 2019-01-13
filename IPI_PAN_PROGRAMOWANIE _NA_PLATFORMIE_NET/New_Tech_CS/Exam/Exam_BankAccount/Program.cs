using Exam_BankAccount.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("1234");
            double kasa = bank.WyszukajKonto();

            KontoLokata lokata = new KontoLokata();

            lokata.Saldo = kasa;
            double zysk = lokata.ObliczZysk(12.00);

            Console.WriteLine(kasa.ToString() + Environment.NewLine + zysk.ToString());

            Console.ReadKey();
        }

    }
}
