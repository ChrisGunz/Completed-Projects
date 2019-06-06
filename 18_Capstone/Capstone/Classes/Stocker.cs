using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class Stocker
    {
        public string FilePath;

        /// <summary>
        /// Default constructor, sets relative path to vendingmachine.csv
        /// </summary>
        public Stocker()
        {
            this.FilePath = Path.GetFullPath(".");
            this.FilePath = @"..\..\..\..\etc\vendingmachine.csv";
        }

        /// <summary>
        /// This function creates a dictionary that will be the stock of our Vending Machine
        /// </summary>
        /// <returns>Dictionary representing the stock of our vending machine object</returns>
        public Dictionary<string, List<Item>> Restock()
        {
            /*  First we will create a temporary list of items
             *  Then we will make a dictionary
             *  The dictionary key is the ID of that item's slot in the vending machine
             *  The value is a list of objects of that item
             *  Each of these lists will start with five items, representing our stock
             */

            List<Item> items = new List<Item>();

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
                    Item newItem = new Item(itemProperties[0], itemProperties[1], price, itemProperties[3]);
                    //  Add our item to the list
                    items.Add(newItem);
                }
            }// End using
            
            Dictionary<string, List<Item>> tempDictionary = new Dictionary<string, List<Item>>();

            foreach (Item item in items)
            {
                List<Item> tempList = new List<Item>();
                //  Five of each item
                for(int i = 0; i < 5; i++)
                {
                    tempList.Add(item);
                }
                tempDictionary.Add(item.SlotID, tempList);
            }
            return tempDictionary;
        }
    }
}