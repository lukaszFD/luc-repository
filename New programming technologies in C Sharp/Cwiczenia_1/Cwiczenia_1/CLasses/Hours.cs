using System;

namespace Cwiczenia_1.CLasses
{
    class Hours
    {
        private int hour;
        private int second;
        private string przyrostek;
        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value >= 0 && value <= 24)
                {
                    second = value * 3600;
                    if (value < 12)
                    {
                        hour = value;
                        przyrostek = "AM";
                    }
                    if (value > 12)
                    {
                        hour = value - 12;
                        przyrostek = "PM";
                    }
                    if (value == 12)
                    {
                        hour = value;
                        przyrostek = "PM";
                    }

                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
        public override string ToString()
        {
            return "Godzina " + hour + " " + przyrostek + "; " + second + " sekunda tej doby.";
        }
    }
}
