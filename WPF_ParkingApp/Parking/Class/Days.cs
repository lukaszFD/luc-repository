using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Class
{
    class Days
    {
        public List<DateTime> Weekend()
        {
            List<DateTime> list = new List<DateTime>();
            TimeSpan diff = DateTime.Now.AddMonths(6) - DateTime.Now;
            int days = diff.Days;
            for (var i = 0; i <= days; i++)
            {
                var date = DateTime.Now.AddDays(i);
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        list.Add(date);
                        break;
                }
            }
            return list;
        }
    }
}
