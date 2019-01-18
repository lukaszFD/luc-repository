using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokoj p = new Pokoj();

            //p.Zarezerwuj(5, "Lipa");
            //p.Wycofaj(1, "Dejko");
            p.Wydaj(10, "Mały");

            Console.WriteLine(p);

            foreach (var item in Hotel.pokojeHotelowe)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }

    public abstract class Metody
    {
        abstract public void WyszukajWolnyPokoj();
        abstract public void ZarezerwujPokoj();
    }

    class Pokoj
    {
        public string Nazwisko { get; set; }
        public int NumerPokoju { get; set; }
        public Stan StanPokoju { get; set; }

        public enum Stan
        {
            wolny, 
            zajety, 
            zarezerwowany,
            wycofany,
        }
        public Pokoj() { }

        public Pokoj(int numer, string nazwisko, Stan stan)
        {
            this.NumerPokoju = numer;
            this.Nazwisko = nazwisko;
            this.StanPokoju = stan;
        }

        public void Zarezerwuj(int numerek, string nazwisko)
        {
            Hotel.pokojeHotelowe.Enqueue(new Pokoj(numerek, nazwisko, Stan.zarezerwowany));
        }

        public void Wycofaj(int numerek, string nazwisko)
        {
            Pokoj pok = Hotel.pokojeHotelowe.Dequeue();

            pok.NumerPokoju = numerek;
            pok.Nazwisko = nazwisko;
            pok.StanPokoju = Stan.wycofany;
        }
        public void Przyjmij(int numerek, string nazwisko)
        {
            Pokoj pok = Hotel.pokojeHotelowe.Dequeue();

            pok.NumerPokoju = numerek;
            pok.Nazwisko = nazwisko;
            pok.StanPokoju = Stan.wolny;
        }
        public void Wydaj(int numerek, string nazwisko)
        {
            foreach (var item in Hotel.pokojeHotelowe)
            {
                if (item.StanPokoju == Pokoj.Stan.wolny && item.NumerPokoju == numerek)
                {
                    Hotel.pokojeHotelowe.Enqueue(new Pokoj(numerek, nazwisko, Stan.zarezerwowany));
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Klient : {0} , Numer pokoju : {1}, Status : {2}",Nazwisko,NumerPokoju, StanPokoju);
        }
    }
    class Gosc : Metody
    {
        string Nazwisko { get; set; }

        public override void WyszukajWolnyPokoj()
        {
            throw new NotImplementedException();
        }

        public override void ZarezerwujPokoj()
        {
            throw new NotImplementedException();
        }
    }

    class Hotel
    {
        public static Queue<Pokoj> pokojeHotelowe { get; set; }

        static Hotel()
        {
            pokojeHotelowe = new Queue<Pokoj>();
            pokojeHotelowe.Enqueue(new Pokoj(1, "Dejko", Pokoj.Stan.zarezerwowany));
            pokojeHotelowe.Enqueue(new Pokoj(2, "Kowalski", Pokoj.Stan.zarezerwowany));
            pokojeHotelowe.Enqueue(new Pokoj(10, "Kostek", Pokoj.Stan.wolny));
        }
        //dodawanie Queue.enqueue(element)
        //usuwanie Queue.dequeue()
        //spr ile Queue.Count
        //czy zawiera Queue.Contains(element)
        //wywaleanie z kolejki Queue.Clear
    }

    class DyrektorHotelu
    {
        void DodajPokoj()
        {

        }

        void WycofajPokoj()
        {

        }
    }

    class Recepcjonista : Metody
    {
        public override void WyszukajWolnyPokoj()
        {
            throw new NotImplementedException();
        }

        public override void ZarezerwujPokoj()
        {
            throw new NotImplementedException();
        }

        void WyszukajZarezerwowany()
        {

        }

        void ZwolnijPokoj()
        {

        }
    }
}
