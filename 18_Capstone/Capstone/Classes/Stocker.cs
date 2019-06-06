using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class Stocker
    {
        public List<Item> items;


        public string FilePath;

        public Stocker()
        {
            this.FilePath = Path.GetFullPath(".");
            this.FilePath = @"..\..\..\etc\vendingmachine.csv";
        }
        


        public List<item> Restock()
        {

        }

        
    }


}
