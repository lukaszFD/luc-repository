using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_20190525
{
    class Program
    {
        static void Main(string[] args)
        {
            Lekarz l = new Lekarz();
            l.NowyPacjent("test", "57656");
            Console.WriteLine(l);
            Console.ReadKey();

        }

        public class Osoba
        {
            public string Nazwisko { get; set; }
            public string Pesel { get; set; }

            public Osoba()
            { }
        }

        class Pacjent : Osoba 
        {
            private Pacjent pacjent;

            public wizyta RodzajWizyty { get; set; }
            public int DataWizyty { get; set; }
            public Pacjent() 
            {
            }

            public Pacjent(Pacjent pacjent)
            {
                this.pacjent = pacjent;
            }

            public enum wizyta { zlecona, zwykla};

            public override string ToString()
            {
                return "Pacjent Pesel: " + Pesel + ", Nazwisko: " + Nazwisko;
            }
        }

        class Ewidencja 
        {
            private static Queue<Pacjent> pacienci;
                
            public Ewidencja()
            {
                pacienci = new Queue<Pacjent>();
                pacienci.Enqueue(new Pacjent() { Nazwisko = "Dejko", Pesel = "1234"});
            }

            public void NowyPacjent(string nazwisko, string pesel)
            {
                Ewidencja.pacienci.Enqueue(new Pacjent() { Nazwisko = nazwisko, Pesel = pesel });
            }

            public Pacjent WyszukajPacjenta(string pesel)
            {
                foreach (Pacjent pacjent in pacienci)
                {
                    if (pacjent.Pesel.Equals(pesel))
                    {
                        return pacjent;
                    }
                    Console.WriteLine("Nie ma takiego pacjenta");
                }
                return null;
            }
            public Pacjent PobierzPacjenta(string pesel)
            {
                Pacjent p = Ewidencja.pacienci.Dequeue();
                p.Pesel = pesel;
                return p;
            }

            public void WstawDoKolejki(Pacjent pacjent)
            {
                Ewidencja.pacienci.Enqueue(new Pacjent(pacjent));
            }

            public Pacjent ShowPacjenci()
            {
                foreach (Pacjent pacjent in pacienci)
                {
                  return pacjent;
                }
                return null;
            }
        }

        class Lekarz : Osoba
        {
            public void NowyPacjent(string nazwisko, string pesel)
            {
                new Ewidencja().NowyPacjent(nazwisko, pesel);

            }

            public void PrzyjecieWgKolejki(Ewidencja ewidencja, RodzajWizyty rodzaj, string dataWizyty)
            {
            }

            public void PrzyjeciePozaKolejka(Ewidencja ewidencja, string pesel, RodzajWizyty rodzaj, string dataWizyty)
            {
            }
        }
    }
}
