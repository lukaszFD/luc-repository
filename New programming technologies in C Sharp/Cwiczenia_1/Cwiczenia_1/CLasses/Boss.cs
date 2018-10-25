using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia_1.CLasses
{
    class Boss
    {
        public void Increase(Worker w, int newSalary)
        {
            w.Salary += newSalary;
        }
    }
}
