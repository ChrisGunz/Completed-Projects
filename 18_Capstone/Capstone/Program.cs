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
            //  Create a vending machine and load it
            VendingMachine VendOMatic = new VendingMachine();
            Stocker stocker = new Stocker();
            VendOMatic.Load(stocker.Restock());

            //  Create a menu object and give it access to VendOMatic
            MainMenu menu = new MainMenu();
            menu.ReceiveMachine(VendOMatic);
            menu.Run();//   Almost everything happens within the menu object

            Console.ReadKey();
        }
    }
}