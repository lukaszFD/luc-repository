using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperQuick
{
    public class Address
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Town { get; set; }

        public string PostCode { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}\n{3}",
                                 Line1, Line2, Town, PostCode);
        }
    }

}
