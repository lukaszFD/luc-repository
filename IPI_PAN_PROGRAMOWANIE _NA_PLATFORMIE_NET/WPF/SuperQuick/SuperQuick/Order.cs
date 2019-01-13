using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperQuick
{
    public class Order
    {
        public int OrderId { get; set; }

        public string Item { get; set; }

        public double Amount { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }

}
