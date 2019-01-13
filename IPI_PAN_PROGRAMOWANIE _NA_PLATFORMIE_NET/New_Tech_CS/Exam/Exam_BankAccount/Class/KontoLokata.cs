﻿using Exam_BankAccount.Class_Abstract;
using Exam_BankAccount.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_BankAccount.Class
{
    public class KontoLokata : Konto, IZysk
    {
        public override string NumerKonta
        {
            get; set;
        }

        public override double Saldo
        {
            get; set;
        }

        public double ObliczZysk(double stopaProcentowa)
        {
            return Saldo * stopaProcentowa / 100.00;
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
