using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowDemo;

namespace Weather
{
    internal class WindowLayout
    {
        public static void Title()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            List<string> title = new List<string> {"0. Läsa hela filen", "1. Utomhus", "2. Inomhus", "a. läsa den nya filen", "b. Läsa dagen för vinter och höst"};
            var windowTitle = new Window("Välj ett alternativ", 0, 0, title);
            windowTitle.Draw();
        }
        public static void Inomhus()
        {
            List<string> inomhus = new List<string> {"1. Medeltemperatur och luftfuktighet per dag",
                "2. Varmast till kallaste dagen", "3. Sök på dagens temperatur och luftfuktighet", "4. Minst till störst risk av mögel"};
            var windowInomhus = new Window("Inomhus",0,0, inomhus);
            windowInomhus.Draw();
        }
        public static void Uomhus()
        {
            List<string> utomhus = new List<string> { "1. Medeltemperatur och luftfuktighet per dag",
                "2. Varmast till kallaste dagen", "3. Sök på dagens temperatur och luftfuktighet", "4. Minst till störst risk av mögel"};
            var windowUomhus = new Window("Utomhus", 0, 0, utomhus);
            windowUomhus.Draw();
        }
    }
}
