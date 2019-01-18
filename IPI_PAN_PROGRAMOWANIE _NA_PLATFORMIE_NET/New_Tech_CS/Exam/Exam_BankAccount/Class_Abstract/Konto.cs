namespace Exam_BankAccount.Class_Abstract
{
    public abstract class Konto
    {
        public abstract string NumerKonta { get; set; }
        public abstract double Saldo { get; set; }

        abstract public void Wplac(double kwotaDoWplaty);
        abstract public void Wyplac(double kwotaDoWyplaty);

        public override string ToString()
        {
            return string.Format("Na koncie : {0} jest {1} zł.", NumerKonta, Saldo);
        }
    }
}
