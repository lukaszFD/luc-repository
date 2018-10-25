using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia_1.CLasses
{
    class Point
    {
        protected int WspX;
        protected int WspY;
        public Point(int x, int y)
        {
            WspX = x; WspY = y;
        }
        public Point()
        {
        
        }
        public void Move(int dx, int dy)
        {
            WspX += dx; WspY += dy;
        }
    }
}
