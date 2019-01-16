namespace Exam_BankAccount.Class_Abstract
{
    public abstract class Konto
    {
        public abstract string NumerKonta { get; set; }
        public abstract double Saldo { get; set; }

        abstract public double Wplac(double kwotaDoWplaty);
        abstract public double Wyplac(double kwotaDoWyplaty);
    }
}
