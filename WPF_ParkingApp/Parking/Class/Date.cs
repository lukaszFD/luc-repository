using System;

namespace Parking.Class
{
    class Date
    {
        public static DateTime Format(DateTime dateTime)
        {
            return Convert.ToDateTime(Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd"));
        }
        public static DateTime Format(string stringDate)
        {
            return Convert.ToDateTime(Convert.ToDateTime(stringDate).ToString("yyyy-MM-dd"));
        }
    }
}
