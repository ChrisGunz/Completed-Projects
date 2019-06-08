using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine 
    {
        public Dictionary <string,List<Item>> Stock { get; private set; }
        public decimal Balance { get; private set; } = 0;
       
        public void Load(Dictionary<string, List<Item>> items)
        {
            this.Stock = items;
            this.Balance = 0;
        }

        public void ShowContents()
        {
            //  TODO: Make printout line up correctly
            Console.Clear();
            foreach (KeyValuePair<string, List<Item>> product in this.Stock)
            {
                Console.Write($"{product.Key}\t");
                if(product.Value.Count == 0)
                {
                    Console.WriteLine("*** SOLD OUT ***");
                }
                else
                {
                    Console.Write($"{product.Value[0].ItemCategory}\t");
                    Console.Write($"{product.Value[0].ItemName}\t\t");
                    if(product.Value[0].ItemName.Length < 16)
                    {
                        Console.Write("\t");
                        if (product.Value[0].ItemName.Length < 8)
                        {
                            Console.Write("\t");
                        }
                    }
                    Console.WriteLine($"{product.Value.Count}\t{product.Value[0].Price:C}");
                }
            }
        }

        /// <summary>
        /// Add money to the machine
        /// </summary>
        /// <param name="money"></param>
        public void FeedMoney(decimal money)
        {
            this.Balance += money;
        }

        /// <summary>
        /// Remove money from balance and dispense the requested item
        /// </summary>
        /// <param name="money">Amount of money to remove from Balance</param>
        /// <param name="slotID">Slot of item to be dispensed</param>
        public void Purchase(string slotID)
        {
            this.Balance -= this.Stock[slotID][0].Price;
            this.Stock[slotID].RemoveAt(0);
        }
    }
}