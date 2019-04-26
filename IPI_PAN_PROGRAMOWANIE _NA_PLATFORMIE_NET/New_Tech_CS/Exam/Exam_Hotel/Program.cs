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

            p.Zarezerwuj(10, "Mały");
            //p.Wycofaj(1, "Dejko");
            p.Wydaj(8, "Dejko");

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
                if (item.StanPokoju != Pokoj.Stan.zarezerwowany && item.NumerPokoju == numerek)
                {
                    Hotel.pokojeHotelowe.Enqueue(new Pokoj(numerek, nazwisko, Stan.zarezerwowany));
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0} pokój numer : {1} jest w statusie : {2}",Nazwisko,NumerPokoju, StanPokoju);
        }
    }
    class Gosc : Metody
    {
        private string Nazwisko { get; set; }
        private int NumerPokoju { get; set; }

        public Gosc(int numer, string nazwisko)
        {
            this.NumerPokoju = numer;
            this.Nazwisko = nazwisko;
        }

        public override void WyszukajWolnyPokoj()
        {
            new Pokoj().Zarezerwuj(NumerPokoju, Nazwisko);
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
        }
    }

    class DyrektorHotelu : Pokoj
    {
        void DodajPokoj(int numerek, string nazwisko)
        {
            Zarezerwuj(numerek, nazwisko);
        }

        void WycofajPokoj(int numerek, string nazwisko)
        {
            Wycofaj(numerek, nazwisko);
        }
    }

    class Recepcjonista : Metody
    {
        private string Nazwisko { get; set; }
        private int NumerPokoju { get; set; }

        public Recepcjonista(int numer, string nazwisko)
        {
            this.NumerPokoju = numer;
            this.Nazwisko = nazwisko;
        }
    
        public override void WyszukajWolnyPokoj()
        {
            new Pokoj().Zarezerwuj(NumerPokoju, Nazwisko);
        }

        public override void ZarezerwujPokoj()
        {
            throw new NotImplementedException();
        }
    }
}
