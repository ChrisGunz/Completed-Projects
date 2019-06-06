using Capstone.Views;
using System;
using Capstone.Classes;
using System.Collections.Generic;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            // If you want to use the CLI menu, you can create an instance in Main, and 
            // Run it.  You can customize the Main menu, and create other menus in the Views folder.
            // If you do not want to use the CLI menu, you can delete the files from the Views folder.
            VendingMachine VendOMatic = new VendingMachine();

            Stocker stocker = new Stocker();

            VendOMatic.Load(stocker.Restock());

            foreach (KeyValuePair<string, List<Item>> product in VendOMatic.Stock)
            {
                Console.WriteLine($"{product.Value[0].SlotID}\t{product.Value[0].ItemCategory}" +
                    $"\t{product.Value[0].ItemName}\t{product.Value[0].Price}\t{product.Value.Count}");
            }
            Console.ReadKey();

            //MainMenu menu = new MainMenu();
            //menu.Run();
        }
    }
}