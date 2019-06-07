using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Capstone.Classes
{
    public class AuditLog
    {
        public string FilePath;

        public AuditLog()
        {
            this.FilePath = Path.GetFullPath(".");
            this.FilePath = @"..\..\..\..\etc\Log.txt";
        }

        /// <summary>
        /// This function appends one line to Log.txt containing the relevant information
        /// </summary>
        /// <param name="transaction">The name of the transaction, possibly the item that was purchased</param>
        /// <param name="startBalance">The vending machine balance before the transaction</param>
        /// <param name="endBalance">The vending machine balance after the transaction</param>
        public void Log(string transaction, decimal startBalance, decimal endBalance)
        {
            using (StreamWriter sw = new StreamWriter(FilePath, true))
            {
                sw.WriteLine($"{DateTime.Now} {transaction} {startBalance:C} {endBalance:C}");
            }
        }
    }
}
