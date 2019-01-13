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

        public double KontrolaWypłaty(double kwotawyplaty)
        {
            throw new NotImplementedException();
        }

        public override void Wplac()
        {
            throw new NotImplementedException();
        }

        public override void Wyplac()
        {
            throw new NotImplementedException();
        }
    }
}
