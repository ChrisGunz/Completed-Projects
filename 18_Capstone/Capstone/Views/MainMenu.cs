using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;


namespace Capstone.Views
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public MainMenu() : base()
        {
            this.Title = "*** Vend-O-Matic 500 ***";
            this.menuOptions.Add("1", "Display Vending Machine Items");
            this.menuOptions.Add("2", "Purchase");
            this.menuOptions.Add("Q", "Quit");
        }

        //  This allows the menu object to access our vending machine
        public VendingMachine VendOMatic { get; private set; }
        // *******
        public Customer customer { get; private set; }
        /// <summary>
        /// Send access to our vending machine object
        /// </summary>
        /// <param name="machine">The machine we need to access</param>
        public void Receive(VendingMachine machine, Customer cust)
        {
            this.VendOMatic = machine;
            this.customer = cust;
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                case "1":
                    //  Print out the stock of our vending machine
                    //  TODO: Format these items so everything is lined up
                    foreach (KeyValuePair<string, List<Item>> product in VendOMatic.Stock)
                    {
                        Console.WriteLine($"{product.Value[0].SlotID}\t{product.Value[0].ItemCategory}" +
                            $"\t{product.Value[0].ItemName}\t{product.Value[0].Price}\t{product.Value.Count}");
                    }
                    Console.ReadKey();
                    return true;
                case "2":
                    //  The purchase sub menu
                    {
                        PurchaseMenu purchaseMenu = new PurchaseMenu();
                        purchaseMenu.Receive(VendOMatic, this.customer);
                        purchaseMenu.Run();
                    }
                    return true;
            }
            return true;
        }
    }
}