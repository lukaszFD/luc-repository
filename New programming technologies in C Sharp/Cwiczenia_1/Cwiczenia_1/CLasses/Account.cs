using System;
using System.Threading;

namespace Cwiczenia_1.CLasses
{
    class Account
    {
        public String User { get; }
        public String Number { get; }
        private String Login;
        private String Password;
        private String NewPassword;
        private bool Logged = false;
        private double Saldo = 0;

        public void ChangePassword(String log, String pass)
        {
            Console.WriteLine("W celu zmiany hasła musisz się zalogować.");
            Thread.Sleep(1000);
            Zaloguj(Password, Login);

            if (Logged)
            {
                int i = 1;
                Console.WriteLine("Udało się zalogować \n\rPodaj nowe hasło. Pamietaj że nie może być takie jak poprzednio (masz trzy próby).");
                do
                {
                    NewPassword = Console.ReadLine();
                    if (Password == NewPassword)
                    {
                        if (Password != NewPassword)
                        {
                            Console.WriteLine(string.Format("Hasło {0} zostało zmienione na {1}", Password, NewPassword));
                        }
                        else
                        {
                            Console.WriteLine(string.Format("Hasło nie może być takie jak poprzednio. Pozostało prób : {0}", 3 - i));
                        }
                        i++;
                    }
                    else
                    {
                        Console.WriteLine(string.Format("Hasło {0} zostało zmienione na {1}", Password, NewPassword));
                        return;
                    }
                } while (i <= 3);
                Console.WriteLine("Konto zostało zablokowane");
            }
            else
            {
                Console.WriteLine("błędne hasło");
            }
        }
        public Account(String user, String num, String log, String pass)
        {
            this.User = user; Number = num; Login = log; Password = pass;
        }
        public void Zaloguj(String log, String pass)
        {
            if ((Login == log) && (Password == pass))
            {
                Logged = true;
            }
        }
        public void Wyloguj() { Logged = false; }
        public void Wplac(double suma)
        {
            if (Logged)
            {
                Saldo += suma;
            }
            else Console.WriteLine("Wpłata - nie jestes zalogowana/y");
        }
        public void Wyplac(double suma)
        {
            if (Logged)
            {
                if (Saldo >= suma)
                {
                    Saldo -= suma;
                }
                else Console.WriteLine("Wypłata {0:C} - brak srodków!", suma);
            }
            else Console.WriteLine("Wypłata - nie jestes zalogowana/y");
        }
        public override String ToString()
        {
            return "\nUzytkownik konta " + User + " o numerze " + Number +
                   " posiada na koncie " + Saldo;
        }
    }
}
