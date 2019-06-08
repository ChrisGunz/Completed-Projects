using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Capstone.Classes
{
    public class AuditLog
    {
        public string FilePath;

        /// <summary>
        /// This function appends one line to Log.txt containing the relevant information
        /// </summary>
        /// <param name="transaction">The name of the transaction, possibly the item that was purchased</param>
        /// <param name="startBalance">The vending machine balance before the transaction</param>
        /// <param name="endBalance">The vending machine balance after the transaction</param>
        public void Log(string transaction, decimal startBalance, decimal endBalance)
        {
            this.FilePath = Path.GetFullPath(".");
            this.FilePath = @"..\..\..\..\etc\Log.txt";
            using (StreamWriter sw = new StreamWriter(FilePath, true))
            {
                sw.WriteLine($"{DateTime.Now} {transaction} {startBalance:C} {endBalance:C}");
            }
        }

        /// <summary>
        /// Logs entry in Transaction History, called every time the customer buys something
        /// </summary>
        /// <param name="purchase"></param>
        public void TransactionHistory(Item purchase)
        {
            this.FilePath = Path.GetFullPath(".");
            this.FilePath = @"..\..\..\..\etc\TransactionHistory.txt";
            //  This dictionary will hold everything in memory so we can rewrite the entire file
            //  Quantities of items will be held here as decimals and cast to ints later
            Dictionary<string, decimal> history = new Dictionary<string, decimal>();
            
            using (StreamReader sr = new StreamReader(FilePath))
            {
                while(!sr.EndOfStream)
                {
                    string input = sr.ReadLine();
                    if (input.StartsWith('*'))
                    {
                        string[] info = input.Split(' ');
                        decimal total = decimal.Parse(info[2]);
                        history.Add(info[0] + " " + info[1], total + purchase.Price);
                    }
                    else
                    {
                        string[] info = input.Split('|');
                        decimal total = decimal.Parse(info[1]);
                        history.Add(info[0], total);
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                foreach(KeyValuePair<string, decimal> entry in history)
                {
                    if(entry.Key.StartsWith("*"))
                    {
                        sw.WriteLine($"{entry.Key} {entry.Value}");
                    }
                    else if (entry.Key == purchase.ItemName)
                    {
                        sw.WriteLine($"{entry.Key}|{(int)entry.Value + 1}");
                    }
                    else
                    {
                        sw.WriteLine($"{entry.Key}|{(int)entry.Value}");
                    }
                }
            }
        }
    }
}