
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    internal class AlgoritmForMogel
    {
        public static void CalculateMogelRisk(string fileName)
        {
                       var data = WeatherRecord.Load(Program.Path + fileName);
            var result = data
                .GroupBy(x => x.Time.Month)
                .Select(g => new
                {
                    Månad = g.Key,  // Key = för varje datom 
                    Temp = g.Average(x => x.temp),
                    Fukt = g.Average(x => x.Humidity),
                    MögelRisk = g.Average(x => (x.temp / 30.0) * (x.Humidity / 100.0) * 100)
        })
                .OrderBy(x => x.MögelRisk)
                .ToList();




            using (var writer = new StreamWriter(Program.Path + "MogelRisk.txt"))
            {
                writer.WriteLine("Algoritm för mögelrisk:");
                writer.WriteLine("Mögelrisken beräknar genom att kombinera temperatur och luftfuktighet.");
                writer.WriteLine("Hög temperatur och hög luftfuktighet ökar risken för mögel.\n");
                writer.WriteLine("Förmel: ");
                writer.WriteLine("(temperatur / 30) * (luftfuktighet / 100) * 100\n");
                writer.WriteLine("Skalan är 0-100% där: \n0 = ingen risk  \n100 = maximal risk.");
                writer.WriteLine("----------------------------------------------\n");
                foreach (var m in result)
                {
                    writer.WriteLine($"Månad {m.Månad}: Mögelrisk {m.MögelRisk:F1}%");
                }
            }



            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Algoritm för mögelrisk:");
            Console.WriteLine("Mögelrisken beräknar genom att kombinera temperatur och luftfuktighet.");
            Console.WriteLine("Hög temperatur och hög luftfuktighet ökar risken för mögel.\n");
            Console.ResetColor();

            Console.WriteLine("Förmel: ");
            Console.WriteLine("(temperatur / 30) * (luftfuktighet / 100) * 100\n");

            Console.WriteLine("Skalan är 0-100% där: \n0 = ingen risk  \n100 = maximal risk.");
            Console.WriteLine("----------------------------------------------\n");
            foreach (var m in result)
            {
                Console.WriteLine($"Månad {m.Månad}: Mögelrisk {m.MögelRisk:F1}%");
            }
            Console.ReadKey();
        }
    }
}
