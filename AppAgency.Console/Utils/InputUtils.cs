using Microsoft.Identity.Client;
using System;

namespace AppAgency.Console.Utils
{
    public static class InputUtils
    {
        public static int ReadInt(string prompt = "", int? min=null, int? max = null)
        {
            int choice = 0;
            bool valid = false;
            do
            {
                if(prompt != "")
                {
                    System.Console.Write(prompt);
                }
                string? input = System.Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    if ((min == null || choice >= min) && (max == null || choice <= max))
                    {
                        valid = true;
                    }
                }
            } while (valid == false);

            return choice;
        }

        public static decimal ReadDecimal(string prompt = "", decimal? min=null, decimal? max=null)
        {
            decimal choice = 0;
            bool valid = false;
            do
            {
                if (prompt != "")
                {
                    System.Console.Write(prompt);
                }
                string? input = System.Console.ReadLine();
                if (decimal.TryParse(input, out choice))
                {
                    if ((min == null || choice >= min) && (max == null || choice <= max))
                    {
                        valid = true;
                    }
                }
            } while (valid == false);
            return choice;
        }
    
        public static DateTime ReadDate(string prompt = "")
        {
            DateTime date;
            bool valid = false;
            do
            {
                if (prompt != "")
                {
                    System.Console.Write(prompt);
                }
                string? input = System.Console.ReadLine();
                if (DateTime.TryParse(input, out date))
                {
                    valid = true;
                }
            } while (valid == false);
            return date;
        }
    }
}
