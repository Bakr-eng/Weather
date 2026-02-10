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
                    Fukt = g.Average(x => x.Humidity)
                })
                .ToList();


            string reportPath = Program.Path + "Månadsrapport.txt";
            using (var writer = new StreamWriter(Program.Path + "textfil"))
            {
                writer.WriteLine("Medeltemperatur och luftfuktighet per månad");
                writer.WriteLine("------------------------------------------------------");

                foreach (var r in result)
                {
                    writer.WriteLine($"Månad {r.Månad}: Temp {r.Temp}°C");
                }

            }


            // för att se i Consolen...
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Medeltemperatur och luftfuktighet per dag (UTE)");
            Console.WriteLine("------------------------------------------------------");
            Console.ResetColor();
            foreach (var r in result)
            {
                Console.WriteLine($"{r.Månad} Temp: {r.Temp:F0}°C"); // F = floating point (decimal)
            }
            Console.ReadKey();

        }

    }
}
