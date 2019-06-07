using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine 
    {
        public Dictionary <string,List<Item>> Stock { get; private set; }
      
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
    }
}