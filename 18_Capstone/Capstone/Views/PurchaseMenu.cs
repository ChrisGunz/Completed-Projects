﻿using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using Capstone.Views;

namespace Capstone.Classes
{
    public class PurchaseMenu : MainMenu
    {
        public PurchaseMenu() : base()
        {
            this.menuOptions = new Dictionary<string, string>();
            this.Title = "*** Purchase Menu ***";
            this.menuOptions.Add("1", "Feed Money");
            this.menuOptions.Add("2", "Select Product");
            this.menuOptions.Add("3", "Finish Transaction");
            this.menuOptions.Add("Q", "Back to Main Menu");
        }

        protected override bool ExecuteSelection(string choice)
        {
            string selection = "";
            switch(choice)
            {
                case "1":
                    Console.WriteLine("*** Feed money ***");
                    Console.WriteLine($"***Current balance: ${VendOMatic.Balance}***");
                    Console.WriteLine("1. Add 1¢");
                    Console.WriteLine("2. Add 5¢");
                    Console.WriteLine("3. Add 10¢");
                    Console.WriteLine("4. Add 25¢");
                    Console.WriteLine("5. Add $1");
                    Console.WriteLine("6. Add $2");
                    Console.WriteLine("7. Add $5");
                    Console.WriteLine("8. Add $10");
                    Console.WriteLine("Q. Quit");

                    selection = Console.ReadLine().Trim();
                    selection = selection.Substring(0, 1).ToUpper();
                    if (selection != "Q")
                    {
                        this.AddMoney(selection);
                    }
                    Console.WriteLine();
                    return true;

                case "2":
                    Console.WriteLine("please Enter a slotID on item you want");
                    selection = Console.ReadLine().Trim();
                    selection = selection.Substring(0, 2).ToUpper();
                    this.MakePurchase(selection);
                    return true;



                case "Q":
                    return false;
            }
            return true;
        }

        private void AddMoney(string choice)
        {

            switch (choice)
            {
                case "1":
                    VendOMatic.FeedMoney(0.01M);
                    break;
                case "2":
                    VendOMatic.FeedMoney(0.05M);
                    break;
                case "3":
                    VendOMatic.FeedMoney(0.1M);
                    break;
                case "4":
                    VendOMatic.FeedMoney(0.25M);
                    break;
                case "5":
                    VendOMatic.FeedMoney(1.0M);
                    break;
                case "6":
                    VendOMatic.FeedMoney(2.0M);
                    break;
                case "7":
                    VendOMatic.FeedMoney(5.0M);
                    break;
                case "8":
                    VendOMatic.FeedMoney(10.0M);
                    break;
            }
        }
        public void MakePurchse(string selection)
        {
            Item purchaseItem = VendOMatic.Stock[selection][0];
            if (!VendOMatic.Stock.ContainsKey(selection))
            {
                Console.WriteLine("Invalid slotID TRANSACTION DENIED");

            }
            else if (VendOMatic.Stock[selection].Count == 0)
            {
                Console.WriteLine("selection is SOLD OUT!");
            }
            else if (purchaseItem.Price > VendOMatic.Balance)
            {
                Console.WriteLine("you dont have enugh money for this item");               
            }
            else
            {
                
            }
        }
        
   
    }
}

            
            