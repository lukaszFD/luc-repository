using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperQuick
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        public virtual List<Order> Orders { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", LastName.ToUpper(), FirstName);
        }
    }

}
