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
            List<string> title = new List<string> {"1. Läsa hela filen", "2. Utomhus", "3. Inomhus", "4. läsa den nya filen",
                "5. Läsa dagen för vinter och höst", "6. Läs algoritm för mögelrisk"};
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
