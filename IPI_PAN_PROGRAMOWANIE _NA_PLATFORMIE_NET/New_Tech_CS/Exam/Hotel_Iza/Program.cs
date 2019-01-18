using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Iza
{
    public class Pokoj
    {
        public int NrPokoju { get; set; }
        public stanPokoju AktualnyStan { get; set; }
        public string NazwiskoGoscia { get; set; }
        public enum stanPokoju { wolny, zajety, zarezerwowany, wycofany };

        public Pokoj(int NrPokoju, stanPokoju AktualnyStan, string NazwiskoGoscia)
        {
            this.NrPokoju = NrPokoju;
            this.AktualnyStan = AktualnyStan;
            this.NazwiskoGoscia = NazwiskoGoscia;
        }

        public void Zarezerwuj(int NrPokoju, string nazwisko)
        {
            AktualnyStan = stanPokoju.wolny;
            NazwiskoGoscia = nazwisko;
        }
        public void Wydaj(int NrPokoju, string nazwisko)
        {
            AktualnyStan = stanPokoju.zajety;
            NazwiskoGoscia = nazwisko;
        }
        public void Przyjmij(int NrPokoju, string nazwisko)
        {
            AktualnyStan = stanPokoju.wolny;
            NazwiskoGoscia = nazwisko;
        }
        public void Wycofaj(int NrPokoju, string nazwisko)
        {
            AktualnyStan = stanPokoju.wycofany;
            NazwiskoGoscia = nazwisko;
        }

        public override String ToString()
        {
            if (AktualnyStan == stanPokoju.zajety || AktualnyStan == stanPokoju.zarezerwowany)
            {
                return "Stan pokoju numer " + NrPokoju + " to " + AktualnyStan + ". Gość o nazwisku " + NazwiskoGoscia;
            }
            else
            {
                return "Stan pokoju numer " + NrPokoju + " to " + AktualnyStan;
            }
        }
    }

    public abstract class ObslugaPokoju
    {
        public abstract int WyszukajWolnyPokoj();
        public abstract bool ZarezerwujPokoj(int nrpokoju, string nazwisko);

    }
    public class Gosc : ObslugaPokoju
    {
        public override int WyszukajWolnyPokoj()
        {
            List<Pokoj> listaWolnych = new List<Pokoj>();
            foreach (var pokoj in Hotel.Pokoje)
            {
                if (pokoj.AktualnyStan == Pokoj.stanPokoju.wolny)
                {
                    listaWolnych.Add(pokoj);
                }
            }
            return listaWolnych.First().NrPokoju;
        }
        public override bool ZarezerwujPokoj(int nr, string nazwisko)
        {
            bool flaga = false;
            foreach (var item in Hotel.Pokoje)
            {
                if (item.NrPokoju == nr && item.AktualnyStan == Pokoj.stanPokoju.wolny)
                {
                    item.AktualnyStan = Pokoj.stanPokoju.zarezerwowany;
                    item.NazwiskoGoscia = nazwisko;
                    flaga = true;
                }
            }
            if (flaga == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Hotel
    {
        public static Queue<Pokoj> Pokoje { get; set; }
        static Hotel()  // to jest konstruktor, inna nazwa nie gra
        {
            Pokoje = new Queue<Pokoj>();
            Pokoje.Enqueue(new Pokoj(1, Pokoj.stanPokoju.wolny, "Kowalski"));
            Pokoje.Enqueue(new Pokoj(2, Pokoj.stanPokoju.zajety, "Michni"));
            Pokoje.Enqueue(new Pokoj(3, Pokoj.stanPokoju.wolny, "Kwit"));
            Pokoje.Enqueue(new Pokoj(4, Pokoj.stanPokoju.zarezerwowany, "Koleba"));
            Pokoje.Enqueue(new Pokoj(5, Pokoj.stanPokoju.wolny, "Ktory"));
            Pokoje.Enqueue(new Pokoj(6, Pokoj.stanPokoju.zajety, "Krok"));
        }
    }

    public class DyrektorHotelu
    {
        public bool DodajPokoj(Pokoj pokoj)
        { return true; }
        public bool WycofajPokoj(Pokoj pokoj)
        { return true; }

    }
    public class Recepcjonista : ObslugaPokoju
    {
        public override int WyszukajWolnyPokoj()
        {
            List<Pokoj> listaWolnych = new List<Pokoj>();
            foreach (var pokoj in Hotel.Pokoje)
            {
                if (pokoj.AktualnyStan == Pokoj.stanPokoju.wolny)
                {
                    listaWolnych.Add(pokoj);
                }
            }
            return listaWolnych.First().NrPokoju;
        }
        public override bool ZarezerwujPokoj(int nr, string nazwisko)
        {
            bool flaga = false;
            foreach (var item in Hotel.Pokoje)
            {
                if (item.NrPokoju == nr && item.AktualnyStan == Pokoj.stanPokoju.wolny)
                {
                    item.AktualnyStan = Pokoj.stanPokoju.zarezerwowany;
                    item.NazwiskoGoscia = nazwisko;
                    flaga = true;
                }
            }
            if (flaga == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int WyszukajZarezerwowany()
        {
            List<Pokoj> listazarezerwowanych = new List<Pokoj>();
            foreach (var pokoj in Hotel.Pokoje)
            {
                if (pokoj.AktualnyStan == Pokoj.stanPokoju.zarezerwowany)
                {
                    listazarezerwowanych.Add(pokoj);
                }
            }
            return listazarezerwowanych.First().NrPokoju;
        }

        public bool ZwolnijPokoj(int nr)
        {
            bool flaga = false;
            foreach (var item in Hotel.Pokoje)
            {
                if (item.NrPokoju == nr && item.AktualnyStan == Pokoj.stanPokoju.zajety)
                {
                    item.AktualnyStan = Pokoj.stanPokoju.wolny;
                    item.NazwiskoGoscia = "";
                    flaga = true;
                }
            }
            if (flaga == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Hotel.Pokoje.Enqueue(new Pokoj(126, Pokoj.stanPokoju.zarezerwowany, "ZpoziomuProgramu"));

            foreach (var item in Hotel.Pokoje)
            {
                Console.WriteLine(item.ToString());
            }

            Gosc gosc = new Gosc();
            int a = gosc.WyszukajWolnyPokoj();
            Console.WriteLine("Wolny pokoj to " + a);
            gosc.ZarezerwujPokoj(a, "Milosz");
            foreach (var item in Hotel.Pokoje)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
}
