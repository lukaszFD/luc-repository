using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Class
{
    class Days
    {
        public static List<DateTime> Weekend(DateTime now, DateTime lastDay)
        {
            List<DateTime> list = new List<DateTime>();
            TimeSpan diff = lastDay - now;
            int days = diff.Days;
            for (var i = 0; i <= days; i++)
            {
                var date = now.AddDays(i);
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
