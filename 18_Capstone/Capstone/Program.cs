using Capstone.Views;
using System;
using Capstone.Classes;

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

            foreach (Item item in VendOMatic.Stock)
            {
                Console.WriteLine($"{item.SlotID}\t{item.ItemCategory}\t{item.ItemName}\t{item.Price}");
            }
            Console.ReadKey();
            //MainMenu menu = new MainMenu();
            //menu.Run();
        }
    }
}