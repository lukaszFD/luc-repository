using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperQuick
{
    public class SuperQuickInitializer : DropCreateDatabaseAlways<SuperQuickContext>
    {
        protected override void Seed(SuperQuickContext context)
        {
            //Create some dummy data
            Address addressOne = new Address
            {
                Line1 = "Address Line 1",
                Line2 = "Address Line 2",
                PostCode = "AB1 ABC",
                Town = "The Town"
            };

            Address addressTwo = new Address
            {
                Line1 = "Second Address 1",
                Line2 = "Second Address 2",
                PostCode = "DE2 DEF",
                Town = "Second Town"
            };

            Customer customerOne = new Customer
            {
                Address = addressOne,
                FirstName = "Jon",
                LastName = "Preece",
            };

            Customer customerTwo = new Customer
            {
                Address = addressTwo,
                FirstName = "Mike",
                LastName = "Smith"
            };

            //  Orders below ...
            Order order = new Order
            {
                Amount = 10,
                Item = "Mouse"
            };

            Order orderTwo = new Order
            {
                Amount = 20,
                Item = "Keyboard"
            };

            Order orderThree = new Order
            {
                Item = "Monitor",
                Amount = 100
            };

            customerOne.Orders.Add(order);
            customerTwo.Orders.AddRange(new[] { orderTwo, orderThree });

            //Add to the context
            context.Customers.Add(customerOne);
            context.Customers.Add(customerTwo);

            //Save changes
            context.SaveChanges();
        }
    }

}
