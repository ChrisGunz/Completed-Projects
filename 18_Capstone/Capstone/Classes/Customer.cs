using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Customer
    {
        public List<Item> Cart;

        public Customer()
        {
            this.Cart = new List<Item>();
      
        }
        public void Eat()
        {
            foreach (Item item in Cart)
            {
                Console.WriteLine($"You eat the {item.ItemName}. {item.Eat()}");
            }
        }
    }
}
