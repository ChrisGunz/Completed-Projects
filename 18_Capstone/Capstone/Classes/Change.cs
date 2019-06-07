using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Change 
    {
        /// <summary>
        /// Returns a string that shows how much change the customer received
        /// </summary>
        /// <param name="balance">The starting balance of the vending machine, which we use to make change</param>
        /// <returns></returns>
        public string TotalValue(decimal balance)
        {
            if (balance == 0.0M)
            {
                return "the vending machine returned nothing";
            }
            else//  Balance should never be < 0
            {
                string message = "the vending machine returned ";

                int coins = (int)(balance / 0.25M);
                if (coins > 0)
                {
                    message += $"/n{coins} Quarters";
                    balance %= 0.25M;
                }
                coins = (int)(balance / 0.10M);
                if (coins > 0)
                {
                    message += $"/n{coins} Dimes";
                    balance %= 0.10M;
                }
                coins = (int)(balance / 0.05M);
                if (coins > 0)
                {
                    message += $"/n{coins} nickels";
                    balance %= 0.05M;
                }
                coins = (int)(balance / 0.01M);
                if (coins > 0)
                {
                    message += $"/n{coins} pennies";
                    balance %= 0.01M;
                }
                message += ".";
                return message;
            }
        }
    }
}

//public int TenDollarBills { get; }
//public int FiveDollarBills { get; }
//public int DollarBills { get; }
//public int Quarters { get; }
//public int Dimes { get; }
//public int Nickels { get; }
//public int Pennies { get; }

////TenDollarBills = (int)(balanceToReturn / 10);
////balanceToReturn %= 10;

// //FiveDollarBills = (int)(balanceToReturn / 5);
// //balanceToReturn %= 5;

// //DollarBills = (int)(balanceToReturn / 1);
// //balanceToReturn %= 1;

//Quarters = (int)(balanceToReturn / .25m);
// balanceToReturn %= .25m;

// Dimes = (int)(balanceToReturn / .10m);
// balanceToReturn %= .10m;

//Nickels = (int)(balanceToReturn / .05m);
// balanceToReturn %= .05m;

// Pennies = (int)(balanceToReturn / .01m);