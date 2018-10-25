using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia_1.CLasses
{
    class Rectangle : Point
    {
        int SideA;
        int SideB;
        public Rectangle(int x, int y, int a, int b) : base(x, y)
        {
            SideA = a; SideB = b;
        }
        public Rectangle(int a, int b)
        {
            SideA = a; SideB = b;
        }

        public double Diagonal()
        {
            return Math.Sqrt(Math.Pow(2, SideA) + Math.Pow(SideB, 2));
        }

    }
}
