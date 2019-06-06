using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Dictionary <string,List<Item>> Stock { get; private set; }

        public void Load(List<Item> items)
        {
            this.Stock = new Dictionary<string, List<Item>>();

            foreach(Item item in items)
            {
                List<Item> tempList = new List<Item>();
                tempList.Add(item);
                tempList.Add(item);
                tempList.Add(item);
                tempList.Add(item);
                tempList.Add(item);
                this.Stock.Add(item.SlotID, tempList);
            }
        }
    }
}