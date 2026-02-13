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
                "2. Varmast till kallaste dagen","3. torast till fuktigaste", "4. Sök på dagens temperatur och luftfuktighet", "5. Minst till störst risk av mögel"};
            var windowInomhus = new Window("Inomhus",0,0, inomhus);
            windowInomhus.Draw();
        }
        public static void Utomhus()
        {
            List<string> utomhus = new List<string> { "1. Medeltemperatur och luftfuktighet per dag",
                "2. Varmast till kallaste dagen","3. Torast till fuktigaste", "4. Sök på dagens temperatur och luftfuktighet", "5. Minst till störst risk av mögel"};
            var windowUomhus = new Window("Utomhus", 0, 0, utomhus);
            windowUomhus.Draw();
        }
        public static void InfoAlgoritm()
        {
            List<string> information = new List<string> { "", "Algoritm för mögelrisk:", "Mögelrisken beräknar genom att kombinera temperatur och luftfuktighet.",
            "Hög temperatur och hög luftfuktighet ökar risken för mögel.", "Förmel: ", "(temperatur / 30) * (luftfuktighet / 100) * 100", "" };
            var windowInfo = new Window("Information", 0, 0, information);
            windowInfo.Draw();

            
        }
        public static void Skala()
        {
            List<string> risk = new List<string> {"", "Skalan är 0-100% där:", "0 = ingen risk", "100 = maximal risk.","" };
            var windowRisk = new Window("skala", 49, 10, risk);
            windowRisk.Draw();
        }


        

    }
}
