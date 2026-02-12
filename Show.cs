
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    internal class Linq
    {
        public static void MedelTempPerDag(string fileName, string place)
        {
            var data = WeatherRecord.Load(Program.Path + fileName)
                .Where(x => x.Place == place);

            var result = data
                .GroupBy(x => x.Time.Date)
                .Select(g => new
                {
                    Datum = g.Key,  // Key = för varje datom 
                    Temp = g.Average(x => x.temp),
                    Fukt = g.Average(x => x.Humidity)
                })
                .OrderBy(x => x.Datum)
                .ToList();



            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Medeltemperatur och luftfuktighet per dag (UTE)");
            Console.WriteLine("------------------------------------------------------");
            Console.ResetColor();
            foreach (var r in result)
            {
                Console.WriteLine($"{r.Datum:yyyy-MM-dd} Temp: {r.Temp:F1}°C Fukt: {r.Fukt:F0}%"); // F = floating point (decimal)
            }
            Console.ReadKey();

        }

        public static void VarmasteDag(string fileName, string place)
        {
            Console.Clear();
            var data = WeatherRecord.Load(Program.Path + fileName)
                .Where(x => x.Place == place);

            var result = data
                .GroupBy(x => x.Time.Date)
                .Select(g => new
                {
                    Datum = g.Key,  // Key = för varje datom 
                    Temp = g.Average(x => x.temp),
                    Fukt = g.Average(x => x.Humidity)
                })
                .OrderByDescending(x => x.Temp)
                .ToList();



            Console.ForegroundColor= ConsoleColor.DarkCyan;
            Console.WriteLine("Varmaste till kalast dag (UTE)");
            Console.WriteLine("------------------------------------------------------");
            Console.ResetColor();

            foreach (var r in result)
            {
                Console.WriteLine($"{r.Datum:yyyy-MM-dd} Temp: {r.Temp:F01}°C"); // F = floating point (decimal)
            }
            Console.ReadKey();

        }
       
    }
}
