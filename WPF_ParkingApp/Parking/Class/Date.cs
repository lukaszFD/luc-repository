using System;

namespace Parking.Class
{
    class Date
    {
        public static DateTime Format(DateTime dateTime)
        {
            return Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd"));
        }
        public static string Format(string stringDate)
        {
            return Convert.ToDateTime(stringDate).ToString("yyyy-MM-dd");
        }
    }
}
