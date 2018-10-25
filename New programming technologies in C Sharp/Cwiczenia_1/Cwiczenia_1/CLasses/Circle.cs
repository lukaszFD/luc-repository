using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia_1.CLasses
{
    class Circle :Point 
    {
        double Radius; 
        public Circle(int x, int y, double radius) : base(x, y)
        {
            Radius = radius;
        }
        public void Scale(double ratio)
        {
            Radius *= ratio;
        }
        public override string ToString()
        {
            return "Srodek koła [" + WspX + "," + WspY +"]. Promień " + Radius;
        }
    }
}
