using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Weather
{
    internal class RegExHandler
    {
        public static bool GetMatch(string line)
        {
            string pattern = @"([0-9]{4})-([01|02|03|04|05|06|07|08|09|10|11|12]{2})-([0-9]{2}) (([0-9]{2}:){2}[0-9]{2}),([Inne|Ute]{3,4},)([0-9.]{1,5}),([0-9]{1,3})";
            // In order pattern checks for:
            // # - stands for number between '0-9'
            // ¤ - stands for number between '0-9' also '.'
            // ####-##-## ##:##:##,(Inne|Ute),¤¤¤¤¤,###
            Regex rg = new Regex(pattern);

            /*
            if (rg.IsMatch(line))
            {
                Console.Write("y");
            }
            else
            {
                Console.WriteLine("n");
                Thread.Sleep(1000);
            }
            */

            return rg.IsMatch(line);
        }
    }
}
