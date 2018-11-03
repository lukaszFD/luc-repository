using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking.Class
{
    class Days
    {
        private DateTime _date { get; set; }

        public List<DateTime> Weekend(int d)
        {
            List<DateTime> list = new List<DateTime>();
            TimeSpan diff = DateTime.Now.AddDays(d) - DateTime.Now; 
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

        public List<DateTime> WorkingDays(DateTime dateFrom, DateTime dateTo)
        {
            List<DateTime> list = new List<DateTime>();
            TimeSpan diff = dateTo - dateFrom;
            int days = diff.Days;
            for (var i = 0; i <= days; i++)
            {
                if (dateFrom == dateTo)
                {
                    _date = dateFrom;
                }
                else
                {
                    _date = dateFrom.AddDays(i);
                }
                switch (_date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        list.Add(_date);
                        break;
                }
            }
            return list;
        }
    }
}
