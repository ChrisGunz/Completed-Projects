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

        public VendingMachine Vendomatic { get; private set; }

        public void RecieveMachine(VendingMachine machine)
        {
            this.Vendomatic = machine;
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
                    foreach (KeyValuePair<string, List<Item>> product in Vendomatic.Stock)
                    {
                        Console.WriteLine($"{product.Value[0].SlotID}\t{product.Value[0].ItemCategory}" +
                            $"\t{product.Value[0].ItemName}\t{product.Value[0].Price}\t{product.Value.Count}");
                    }
                    Console.ReadKey();
                    return true;
                case "2":
                    // Get some input form the user, and then do something
                    int someNumber = GetInteger("Please enter a whole number:");
                    int anotherNumber = GetInteger("Please enter another whole number:");
                    Console.WriteLine($"{someNumber} + {anotherNumber} = {someNumber + anotherNumber}.");
                    Pause("");
                    return true;
            }
            return true;
        }

    }
}
