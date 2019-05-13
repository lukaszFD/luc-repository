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

            p.Zarezerwuj(1, "Mały");
            //p.Wycofaj(1);
            p.Wydaj();

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

    class Pokoj : IEquatable<Pokoj>
    {
        public bool Equals(Pokoj other)
        {
            return (other.NumerPokoju == this.NumerPokoju && other.Nazwisko == this.Nazwisko && other.StanPokoju == Stan.wolny);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Pokoj);
        }

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

        public void Zarezerwuj(int numerek, string nazwisko)
        {
            if (Hotel.pokojeHotelowe.Contains(new Pokoj() { NumerPokoju = numerek, Nazwisko = null, StanPokoju = Stan.wolny }))
            {
                Wycofaj(numerek);
                Hotel.pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = numerek, Nazwisko = nazwisko, StanPokoju = Stan.zajety });
            }
        }

        public void Wycofaj(int numerek)
        {
            Pokoj pok = Hotel.pokojeHotelowe.Dequeue();
            pok.NumerPokoju = numerek;
        }
        public void Przyjmij(int numerek)
        {
            Wycofaj(numerek);
            Hotel.pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = numerek, Nazwisko = null, StanPokoju = Stan.wolny });
        }
        public void Wydaj()
        {
            List<int> list = new List<int>();
            try
            {
                foreach (var item in Hotel.pokojeHotelowe)
                {
                    if (item.StanPokoju == Stan.wolny)
                    {
                        list.Add(item.NumerPokoju);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                int fisrt = list.FirstOrDefault();
                Console.WriteLine(fisrt);
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
            new Pokoj().Wydaj();
        }

        public override void ZarezerwujPokoj()
        {
            new Pokoj().Zarezerwuj(NumerPokoju, Nazwisko);
        }
    }

    class Hotel
    {
        public static Queue<Pokoj> pokojeHotelowe;

        static Hotel()
        {
            pokojeHotelowe = new Queue<Pokoj>();
            pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = 1, Nazwisko = null, StanPokoju = Pokoj.Stan.wolny });
            pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = 2, Nazwisko = null, StanPokoju = Pokoj.Stan.wolny });
            pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = 3, Nazwisko = null, StanPokoju = Pokoj.Stan.wolny });
            pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = 4, Nazwisko = null, StanPokoju = Pokoj.Stan.wolny });
            pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = 5, Nazwisko = null, StanPokoju = Pokoj.Stan.wolny });
            pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = 6, Nazwisko = null, StanPokoju = Pokoj.Stan.wolny });
            pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = 7, Nazwisko = null, StanPokoju = Pokoj.Stan.wolny });
            pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = 8, Nazwisko = null, StanPokoju = Pokoj.Stan.wolny });
            pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = 9, Nazwisko = null, StanPokoju = Pokoj.Stan.wolny });
            pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = 10, Nazwisko = null, StanPokoju = Pokoj.Stan.wolny });
        }
    }

    class DyrektorHotelu : Pokoj
    {
        void DodajPokoj(int numerek)
        {
            Hotel.pokojeHotelowe.Enqueue(new Pokoj() { NumerPokoju = numerek, Nazwisko = null, StanPokoju = Stan.wolny });
        }

        void WycofajPokoj(int numerek)
        {
            Wycofaj(numerek);
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
            new Pokoj().Wydaj();
        }

        public override void ZarezerwujPokoj()
        {
            new Pokoj().Zarezerwuj(NumerPokoju, Nazwisko);
        }
    }
}
