using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class Stocker
    {
        //public List<Item> items;
        public string FilePath;

        public Stocker()
        {
            this.FilePath = Path.GetFullPath(".");
            this.FilePath = @"..\..\..\..\etc\vendingmachine.csv";
        }

        public Dictionary<string, List<Item>> Restock()
        {
            //  Create a temp list
            List<Item> items = new List<Item>();
            //  Open the file, read contents
            using (StreamReader sr = new StreamReader(this.FilePath))
            {
                while (!sr.EndOfStream)
                {
                    //  Each item in the vendingmachine.csv is formatted like this: A1|Potato Crisps|3.05|Chip
                    string input = sr.ReadLine();
                    string[] itemProperties = input.Split('|');

                    //  Item.Price is a decimal and must be cast
                    decimal price = decimal.Parse(itemProperties[2]);

                    //  Build the item using the Item constructor
                    Item newItem = new Item(itemProperties[0],
                        itemProperties[1],
                        price,
                        itemProperties[3]);

                    //  Add it to the list
                    items.Add(newItem);
                }
            }// End using

            Dictionary<string, List<Item>> tempDictionary = new Dictionary<string, List<Item>>();

            foreach (Item item in items)
            {
                List<Item> tempList = new List<Item>();
                tempList.Add(item);
                tempList.Add(item);
                tempList.Add(item);
                tempList.Add(item);
                tempList.Add(item);
                tempDictionary.Add(item.SlotID, tempList);
            }
            return tempDictionary;
        }
    }
}