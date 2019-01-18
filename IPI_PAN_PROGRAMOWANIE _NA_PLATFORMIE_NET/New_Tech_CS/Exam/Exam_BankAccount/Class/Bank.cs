using Exam_BankAccount.Class_Abstract;
using System;
using System.Collections;
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
        public bool WyszukajKonto()
        {
            ArrayList listaKont = new ArrayList();
            listaKont.Add( "3333");
            listaKont.Add( "2222");
            listaKont.Add( "0000");
            listaKont.Add( "1111");

            bool czyJestNumerKonta = false;
            foreach (var item in listaKont)
            {
                if (item.ToString() == _numerDoWyszukania)
                {
                    czyJestNumerKonta = true;
                }
            }
            return czyJestNumerKonta;
        }
    }
}

