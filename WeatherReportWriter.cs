using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    internal class WeatherReportWriter
    {
        public static void CreateReport(string fileName)
        {
            var data = WeatherRecord.Load(Program.Path + fileName);

            var result = data
                .GroupBy(x => x.Time.Month)
                .Select(g => new
                {
                    Månad = g.Key,  // Key = för varje datom 
                    Temp = g.Average(x => x.temp),
                    Fukt = g.Average(x => x.Humidity),
                    MögelRisk = g.Average(x => (x.temp * x.Humidity) / 100)
                })
                .OrderBy(x => x.Månad)
                .ToList();


            using (var writer = new StreamWriter(Program.Path + "textfil"))
            {
                writer.WriteLine("Medeltemperatur per månad (Inne/UTE)"); // temperatur
                writer.WriteLine("------------------------------------------------------");

                foreach (var r in result)
                {
                    writer.WriteLine($"Månad {r.Månad}: Temp {r.Temp:F0}°C");
                }


                writer.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++\n");

                writer.WriteLine("Medel luftfuktighet per månad (Inne/UTE)"); // luftfuktighet
                writer.WriteLine("------------------------------------------------------");

                foreach (var r in result)
                {
                    writer.WriteLine($"Månad {r.Månad}: Fukt {r.Fukt:F0}%");
                }

                writer.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++\n");

                writer.WriteLine("Mögelrisk per månad (Inne/UTE)"); // mögelrisk
                writer.WriteLine("------------------------------------------------------");

                foreach (var m in result)
                {
                    writer.WriteLine($"Månad {m.Månad}: Mögelrisk {m.MögelRisk:F1}%");
                }
            }


            // för att se i Consolen...
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Medeltemperatur per månad (Inne/UTE)");
            Console.WriteLine("------------------------------------");
            Console.ResetColor();
            foreach (var r in result)
            {
                Console.WriteLine($"Månad {r.Månad}: Temp {r.Temp:F0}°C"); // F = floating point (decimal)
            }


            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Medel luftfuktighet per månad (Inne/UTE)");
            Console.WriteLine("----------------------------------------");
            Console.ResetColor();

            foreach (var r in result)
            {
                Console.WriteLine($"Månad {r.Månad}: Fukt {r.Fukt:F0}%");
            }


            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Mögelrisk per månad (Inne/UTE)");
            Console.WriteLine("------------------------------");
            Console.ResetColor();

            foreach (var m in result)
            {
                Console.WriteLine($"Månad {m.Månad}: Mögelrisk {m.MögelRisk:F1}%");

            }



            Console.ReadKey();
        }
    }
}
