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
        public void Log(string transaction, decimal startBalance, decimal endBalance)
        {
            using (StreamWriter sw = new StreamWriter(FilePath, true))
            {
                sw.WriteLine($"{DateTime.Now} {transaction} {startBalance:C} {endBalance:C}");
            }
        }
    }
}
