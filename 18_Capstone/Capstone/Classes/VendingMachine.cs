using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine 
    {
        public Dictionary <string,List<Item>> Stock { get; private set; }
        public decimal Balance { get; private set; } = 0;

      
        // TRAIL CODE ********************************
        //public decimal Balance { get; }
       

        //public VendingMachine(decimal currentBalance)
        //{
        //    currentBalance = 0;
        //    this.Balance = currentBalance;
        //}

        /// trial code
        
       
        public void Load(Dictionary<string, List<Item>> items)
        {
            this.Stock = items;
        }

        public void FeedMoney(decimal money)
        {
            //  The user feeds money into the balance of our machine
            //  Add to balance however much money is passed in
            //  Amount of money will be determined through the menu
            this.Balance += money;
        }
    }
}