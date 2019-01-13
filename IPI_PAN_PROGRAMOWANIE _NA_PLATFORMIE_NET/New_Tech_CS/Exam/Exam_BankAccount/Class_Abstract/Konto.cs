namespace Exam_BankAccount.Class_Abstract
{
    public abstract class Konto
    {
        public abstract string NumerKonta { get; set; }
        public abstract double Saldo { get; set; }

        abstract public void Wplac();
        abstract public void Wyplac();
    }
}
