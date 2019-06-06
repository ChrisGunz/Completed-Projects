using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public List<Item> Stock { get; private set; }

        public void Load(List<Item> items)
        {
            this.Stock = items;
        }
    }
}