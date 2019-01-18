using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_BankAccount.Class_Abstract;
using Exam_BankAccount.Interface;

namespace Exam_BankAccount.Class
{
    public class KontoOsobiste : Konto, IOsobista
    {
        public override string NumerKonta
        {
            get; set;
        }
        
        public override double Saldo
        {
            get; set;
        }

        public override void Wplac(double kwotaDoWplaty)
        {
            Saldo += kwotaDoWplaty;
        }

        public override void Wyplac(double kwotaDoWyplaty)
        {
            KontrolaWypłaty(kwotaDoWyplaty);
        }

        public void KontrolaWypłaty(double kwota)
        {
            if (Saldo >= kwota)
            {
                Saldo -= kwota;
            }
            else
            {
                Console.WriteLine("Proszę wybrać niższą kwotę która jest mniejsza lub równa wysokości salda.");
            }

        }
    }
}
