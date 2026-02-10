using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    internal class InomHus
    {
        public static void Show()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Inomhus");
            Console.WriteLine("----------------------");

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("1. Medeltemperatur och luftfuktighet per dag");
            Console.WriteLine("2. Varmast till kallaste dagen");
            Console.ResetColor();

            var key = Console.ReadKey();

            switch (char.ToLower(key.KeyChar))
            {
                case '1': Linq.MedelTempPerDag("tempdata5-med fel.txt", "Inne"); break;
                case '2': Linq.VarmasteDag("tempdata5-med fel.txt", "Inne"); break;

            }
        }
    }
}
