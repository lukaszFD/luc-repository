using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_egz
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        interface ILogowanie
        {
            void Logowanie(string haslo , string login );
            void Wyloguj();
        }
        class Uzytkownik : ILogowanie
        {
            public void Logowanie(string haslo, string login)
            {
                throw new NotImplementedException();
            }

            public void Wyloguj()
            {
                throw new NotImplementedException();
            }
        }

        class Policjant : Uzytkownik
        {
            public void Logowanie(string haslo, string login)
            {
                throw new NotImplementedException();
            }

            public void Wyloguj()
            {
                throw new NotImplementedException();
            }
        }

        public abstract class Osoba
        {
            public string Login;
            public string Password;
            public bool Zalogowany = false;

            //public void UkarzMandatem()
            //{
            //}

            //public void PunktyKarne()
            //{
            //}

            //public void Wyszukaj()
            //{
            //}
        }

        public class Kierowca 
        {
            public int Pesel { get; set; }
            public string Nazwisko { get; set; }
            public string LiczbaPunktów { get; set; }
            public string Mandaty { get; set; }

        }

        public class Ewidencja
        {
            Queue<Kierowca> ewidencja = new Queue<Kierowca>();

            Ewidencja()
            {

            }
        }
    }
}
