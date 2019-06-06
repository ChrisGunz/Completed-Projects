using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Dictionary <string,List<Item>> Stock { get; private set; }

        public void Load(Dictionary<string, List<Item>> items)
        {
            this.Stock = items;
        }
    }
}