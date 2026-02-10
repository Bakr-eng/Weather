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
            List<string> title = new List<string> { "0. Läsa hela filen", "1. Utomhus", "2. Inomhus" };
            var windowTitle = new Window("Välj ett alternativ", 0, 0, title);
            windowTitle.Draw();
        }
    }
}
