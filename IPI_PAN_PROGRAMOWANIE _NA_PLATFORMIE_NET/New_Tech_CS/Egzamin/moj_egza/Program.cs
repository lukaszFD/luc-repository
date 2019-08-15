using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moj_egza
{
    class Program
    {
        public abstract class Osoba
        {
            abstract public void Logowanie();
            abstract public void Wyloguj();
        }

        static void Main(string[] args)
        {
            Ewidencja e = new Ewidencja();
            e.Logowanie("haslo", "login");
            Console.WriteLine(e);
            List<Kierowca> list = new List<Kierowca>(e.WyszukanieKierowcy(11223344));

            foreach (var item in list)
            {
                Console.WriteLine(item.Nazwisko + Environment.NewLine + item.NiezaplaconeMandaty + Environment.NewLine + item.LiczbaPunktowKarnych);
            }

            e.DodanieKierowcyDoEwidencji("nikt", 23232323, 10, 250);

            foreach (var item in Ewidencja.kierowca)
            {
                Console.WriteLine(item.Nazwisko + Environment.NewLine + item.NiezaplaconeMandaty + Environment.NewLine + item.LiczbaPunktowKarnych);
            }

            e.Wyloguj();
            Console.ReadKey();
        }
        class Policjant : Osoba
        {
            public override void Logowanie()
            {
            }

            public override void Wyloguj()
            {
            }
        }
        class Kierowca : Osoba
        {
            public string Nazwisko { get; set; }
            public int Pesel { get; set; }
            public int LiczbaPunktowKarnych { get; set; }
            public int NiezaplaconeMandaty { get; set; }

            public override void Logowanie()
            {
            }

            public override void Wyloguj()
            {
            }
        }

        class Ewidencja
        {
            private String Login = "login";
            private String Password = "haslo";
            private bool Logged = false;

            public static Queue<Kierowca> kierowca;
            public Ewidencja(string test)
            { }
            public Ewidencja()
            {
                kierowca = new Queue<Kierowca>();
                kierowca.Enqueue(new Kierowca() { Nazwisko = "Dejko", Pesel = 11223344, LiczbaPunktowKarnych = 25, NiezaplaconeMandaty = 50 });
                kierowca.Enqueue(new Kierowca() { Nazwisko = "Oleksy", Pesel = 78787878, LiczbaPunktowKarnych = 4, NiezaplaconeMandaty = 250 });
                kierowca.Enqueue(new Kierowca() { Nazwisko = "Czubak", Pesel = 90909090, LiczbaPunktowKarnych = 7, NiezaplaconeMandaty = 800 });
            }
            public void UkaranieMandatem(string nazwisko, int pesel, int punkty, int mandaty)
            {
                Ewidencja.kierowca.Enqueue(new Kierowca() { Nazwisko = nazwisko, Pesel = pesel, LiczbaPunktowKarnych = punkty, NiezaplaconeMandaty = mandaty });
            }
            public void ZaplacenieMandatu(int pesel)
            {
                Kierowca k = Ewidencja.kierowca.Dequeue();
                k.Pesel = pesel;
            }
            public List<Kierowca> WyszukanieKierowcy(int pesel)
            {
                List<Kierowca> list = new List<Kierowca>();

                foreach (var item in Ewidencja.kierowca)
                {
                    if (item.Pesel == pesel)
                    {
                        list.Add(new Kierowca() { NiezaplaconeMandaty = item.NiezaplaconeMandaty, Nazwisko = item.Nazwisko, LiczbaPunktowKarnych = item.LiczbaPunktowKarnych });
                    }
                }
                return list;
            }
            public void DodanieKierowcyDoEwidencji(string nazwisko, int pesel, int punkty, int mandaty)
            {
                Ewidencja.kierowca.Enqueue(new Kierowca() { Nazwisko = nazwisko, Pesel = pesel, LiczbaPunktowKarnych = punkty, NiezaplaconeMandaty = mandaty });
            }
            public void Logowanie(String log, String pass)
            {
                if ((Login == log) && (Password == pass))
                {
                    Logged = true;
                }
                else
                {
                    Console.WriteLine("Błędne hasło");
                }
            }

            public void Wyloguj()
            {
                Logged = false;
            }
            public override string ToString()
            {
                return string.Format("Zalogowany jako : {0}", Login);
            }
        }
    }
}
