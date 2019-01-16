using Exam_BankAccount.Class_Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_BankAccount.Class
{
    public class Bank
    {
        private string _numerDoWyszukania {get;set;}

        public Bank(string numerDoWyszukania)
        {
           this._numerDoWyszukania = numerDoWyszukania;
        }
        public double WyszukajKonto()
        {

            List<KontoOsobiste> listaKont = new List<KontoOsobiste>();
            listaKont.Add(new KontoOsobiste() { NumerKonta = "5678", Saldo = 1500.25 });
            listaKont.Add(new KontoOsobiste() { NumerKonta = "1234", Saldo = 150000.25 });
            listaKont.Add(new KontoOsobiste() { NumerKonta = "0000", Saldo = 15.01 });

            double saldoKonta = 0;

            foreach (var item in listaKont)
            {
                if (item.NumerKonta == _numerDoWyszukania)
                {
                    saldoKonta = item.Saldo;
                }
            }
            return saldoKonta;
        }
    }
}
