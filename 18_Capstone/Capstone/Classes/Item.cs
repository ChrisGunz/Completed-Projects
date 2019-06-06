using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone.Classes
{
    public class Item
    {
        public string SlotID { get; private set; }

        public string ItemName { get; }

        public decimal Price { get; private set; }

        public string ItemCategory { get; }

        public Item(string slotID, string itemName, decimal price, string itemCategory)
        {
            //  A1|Potato Crisps|3.05|Chip
            this.SlotID = slotID;
            this.ItemCategory = itemCategory;
            this.ItemName = itemName;
            this.Price = price;
        }
    }
}