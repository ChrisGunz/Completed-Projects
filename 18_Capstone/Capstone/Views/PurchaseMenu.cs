using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using Capstone.Views;

namespace Capstone.Classes
{
    public class PurchaseMenu : CLIMenu
    {
        private Change change;

        public PurchaseMenu() : base()
        {
            this.menuOptions = new Dictionary<string, string>();
            this.Title = "*** Purchase Menu ***";
            this.menuOptions.Add("1", "Feed Money");
            this.menuOptions.Add("2", "Select Product");
            this.menuOptions.Add("3", "Finish Transaction");
            this.menuOptions.Add("Q", "Back to Main Menu");
            this.change = new Change();
        }

        protected override bool ExecuteSelection(string choice)
        {
            string selection = "";
            switch(choice)
            {
                case "1":
                    Console.Clear();
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
                    VendOMatic.ShowContents();
                    Console.WriteLine("please Enter a slotID on item you want");
                    selection = Console.ReadLine().Trim();
                    this.MakePurchase(selection);
                    return true;

                case "3":
                    Console.WriteLine(this.change.TotalValue(VendOMatic.Balance));
                    Stocker stocker = new Stocker();
                    log.Log("GIVE CHANGE", VendOMatic.Balance, 0.0M);
                    VendOMatic.Load(stocker.Restock());
                    this.Customer.Eat();
                    Console.ReadKey();
                    return false;

                case "Q":
                    return false;
            }
            return true;
        }

        private void AddMoney(string choice)
        {
            decimal startBalance = VendOMatic.Balance;
            switch (choice)
            {
                case "1":
                    VendOMatic.FeedMoney(0.01M);
                    log.Log("FEED MONEY", startBalance, VendOMatic.Balance);
                    break;
                case "2":
                    VendOMatic.FeedMoney(0.05M);
                    log.Log("FEED MONEY", startBalance, VendOMatic.Balance);
                    break;
                case "3":
                    VendOMatic.FeedMoney(0.1M);
                    log.Log("FEED MONEY", startBalance, VendOMatic.Balance);
                    break;
                case "4":
                    VendOMatic.FeedMoney(0.25M);
                    log.Log("FEED MONEY", startBalance, VendOMatic.Balance);
                    break;
                case "5":
                    VendOMatic.FeedMoney(1.0M);
                    log.Log("FEED MONEY", startBalance, VendOMatic.Balance);
                    break;
                case "6":
                    VendOMatic.FeedMoney(2.0M);
                    log.Log("FEED MONEY", startBalance, VendOMatic.Balance);
                    break;
                case "7":
                    VendOMatic.FeedMoney(5.0M);
                    log.Log("FEED MONEY", startBalance, VendOMatic.Balance);
                    break;
                case "8":
                    VendOMatic.FeedMoney(10.0M);
                    log.Log("FEED MONEY", startBalance, VendOMatic.Balance);
                    break;
            }
        }
        private void MakePurchase(string selection)
        {
            decimal startBalance = VendOMatic.Balance;

            //  Using this variable to keep track of our transaction's validity
            //  Makes each if statement decoupled from the other
            //  Otherwise we have a bunch of nested if/else statements that got super messy
            bool validTransaction = true;

            if (selection.Length < 2)
            {
                Console.WriteLine("Invalid slot ID, transaction denied.");
                validTransaction = false;
            }
            string slotID = selection.Substring(0, 2).ToUpper();
            if (validTransaction && !VendOMatic.Stock.ContainsKey(slotID))
            {
                Console.WriteLine("Invalid slot ID, transaction denied.");
                validTransaction = false;
            }
            
            if (validTransaction && VendOMatic.Stock[slotID].Count < 1)
            {
                Console.WriteLine("This item is sold out.");
                validTransaction = false;
            }

            //  If validTransaction is still true, we know we have a valid key
            if (validTransaction)
            {
                Item purchaseItem = VendOMatic.Stock[slotID][0];

                if (validTransaction && VendOMatic.Balance < purchaseItem.Price)
                {
                    Console.WriteLine("Insufficient funds, transaction denied.");
                    validTransaction = false;
                }

                if (validTransaction)
                {
                    Customer.Cart.Add(purchaseItem);
                    VendOMatic.Stock[slotID].RemoveAt(0);
                    VendOMatic.Purchase(purchaseItem.Price);
                    log.Log(purchaseItem.ItemName, startBalance, VendOMatic.Balance);
                    Console.WriteLine($"You bought {purchaseItem.ItemName}.");
                }
            }
            Console.ReadKey();
        }
    }
}