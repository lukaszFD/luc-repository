using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia_1.CLasses
{
    class Worker
    {
        private string Name { get; set; }
        public int Salary {  get; set; }
        public Worker(string _Name, int _Salary)
        {
            Name = _Name;
            Salary = _Salary;
        }
        public override string ToString()
        {
            return Name + " " + Salary + " zł.";
        }
    }
}
