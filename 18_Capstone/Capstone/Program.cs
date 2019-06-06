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

            MainMenu menu = new MainMenu();
            menu.Run();
        }
    }
}
