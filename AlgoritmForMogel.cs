
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
                .Where(x => Show.IsIncludedDate(x.Time))
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
                writer.WriteLine("(temperatur / 30) * (luftfuktighet / 100) * 100");
                writer.WriteLine("----------------------------------------------\n");
                writer.WriteLine("Skalan är 0-100% där: ");
                writer.WriteLine("0 = ingen risk  & 100 = maximal risk.\n");

                writer.WriteLine("--------------------------------------------");
                writer.WriteLine($"| {"Månad",-5} |{"Temperatur",-5} | {"Fukt",-6} | {"Mögelrisk %",-10} |");
                writer.WriteLine("--------------------------------------------");
                foreach (var m in result)
                {
                    writer.WriteLine($"| {m.Månad,-5} | {m.Temp,-9:F1} | {m.Fukt,-6:F1} | {m.MögelRisk,-11:F1} |");
                   
                }
                writer.WriteLine("--------------------------------------------\n");
            }
            Console.Clear();
            
            WindowLayout.InfoAlgoritm();


            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"| {"Månad",-5} |{"Temperatur",-5} | {"Fukt",-6} | {"Mögelrisk %",-10} |");
            Console.WriteLine("--------------------------------------------");
            foreach (var m in result)
            {
                Console.WriteLine($"| {m.Månad, -5} | {m.Temp, -9:F1} | {m.Fukt, -6:F1} | {m.MögelRisk, -11:F1} |");

            }
            Console.WriteLine("--------------------------------------------");

            WindowLayout.Skala();
            Console.ReadKey();
        }
    }
}
