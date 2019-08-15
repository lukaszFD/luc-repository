using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egzamin
{
    class Kierowca
    {
        public string Pesel { get; }
        public int PunktyKarne { get; set; }
        public int Mandaty { get; set; }
        public Kierowca(string pesel)
        {
            Pesel = pesel;
        }
        public void Zaplac(int kwota)
        {
            Mandaty -= kwota;
        }
        public void Ukarz(int kwota, int punkty)
        {
            Mandaty += kwota;
            PunktyKarne += punkty;
        }
        public override string ToString()
        {
            return "Kierowca Pesel: " + Pesel + ", Mandaty: " +
                    Mandaty + ", Punkty karne: " + PunktyKarne;
        }
    }
    class Ewidencja
    {
        private Queue<Kierowca> ewidencja = new Queue<Kierowca>();

        public void DodajKierowce(string pesel)
        {
            ewidencja.Enqueue(new Kierowca(pesel));
        }

        public Kierowca Wyszukaj(string pesel)
        {
            foreach (Kierowca kierowca in ewidencja)
                if (kierowca.Pesel.Equals(pesel))
                {
                    return kierowca;
                }
            Console.WriteLine("Nie ma takiego kierowcy");
            return null;
        }
        public void Ukarz(Kierowca wyszukany, int mandat, int punkty)
        {
            wyszukany.Ukarz(mandat, punkty);
        }

        public void Zaplac(Kierowca wyszukany, int kwota)
        {
            wyszukany.Zaplac(kwota);
        }
    }
    abstract class Osoba
    {
        public string Login;
        public string Password;
        public bool Zalogowany = false;
        public abstract Kierowca Wyszukaj(Ewidencja ewidencja, string pesel);
    }
    interface ILogowanie
    {
        void Zaloguj(string login, string haslo);
        void Wyloguj();
    }
    class User : Osoba, ILogowanie
    { //Klasa zbiorcza, definiuje metody wspólne dla użytkownka
      //i policjanta, ponadto dziedziczy dane składowe z interfejsu
        public void Zaloguj(string login, string haslo)
        {
            if ((login == Login) && (haslo == Password))
            {
                Zalogowany = true;
            }
            else
            {
                Zalogowany = false;
                Console.WriteLine("Logowanie nie powiodło się");
            }
        }
        public void Wyloguj()
        {
            Zalogowany = false; 
}
        public override Kierowca Wyszukaj(Ewidencja ewidencja, string pesel)
        {
            if (Zalogowany)
            {
                return ewidencja.Wyszukaj(pesel);
            }
            else
            {
                return null;
            }
        }
    }
    class Uzytkownik : User
    { //Klasa użytkownika dziedziczy wszystko z klasy User, oraz
      //definiuje metodę własną użytkownika
        public void Zaplac(Kierowca kierowca, int kwota)
        {
            kierowca.Zaplac(kwota);
        }

    }
    class Policjant : User
    { //Klasa policjanta dziedziczy wszystko z klasy User, oraz
      //definiuje metody własne policjanta
        public void DodajKierowce(Ewidencja ewidencja, string pesel)
        {
            ewidencja.DodajKierowce(pesel);
        }
        public void Ukarz(Kierowca kierowca, int kwota, int punkty)
        {
            kierowca.Ukarz(kwota, punkty);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {   //przykładowe debagowanie

            //poniżej tworzenie ewidencji, użytkownika i policjanta
            Ewidencja kierowcy = new Ewidencja();
            Uzytkownik obywatel = new Uzytkownik();
            Policjant policjant = new Policjant();

            //ustalenie loginów i haseł dla użytkownika i policjanta
            policjant.Login = "glina"; policjant.Password = "Bob";
            obywatel.Login = "cywil"; obywatel.Password = "frajer";

            Kierowca k; //zmienna pomocnicza - przechowuje referencję
                        //do wyszukanego w ewidencji kierowcy
                        //użytkownik loguje się i próbuje się wyszukać w ewidencji
            obywatel.Zaloguj("cywil", "frajer");
            k = obywatel.Wyszukaj(kierowcy, "123");

            //policjant loguje się i szuka kierowcy
            policjant.Zaloguj("glina", "Bob");
            policjant.Wyszukaj(kierowcy, "123");

            //nie znalazł więc dodaje do ewidencji aby ukarać,
            //wyszukuje go i nakłada karę
            policjant.DodajKierowce(kierowcy, "123");
            k = policjant.Wyszukaj(kierowcy, "123");
            policjant.Ukarz(k, 100, 2);

            //użytkownik wyszukuje siebie i sprawdza
            k = obywatel.Wyszukaj(kierowcy, "123");
            Console.WriteLine(k);

            //użytkownik spłaca częściowo karę
            k.Zaplac(50);
            Console.WriteLine(k);

            Console.ReadKey();
        }
    }
}
