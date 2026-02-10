
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
            var data = Load(Program.Path + fileName)
                .Where(x => x.Place == place);

            var result = data
                .GroupBy(x => x.Time.Date)
                .Select(g => new
                {
                    Datum = g.Key,  // Key = för varje datom 
                    Temp = g.Average(x => x.temp),
                    Fukt = g.Average(x => x.Humidity)
                })
                .OrderBy(x => x.Datum);



            Console.Clear();
            Console.WriteLine("Medeltemperatur och luftfuktighet per dag (UTE)");
            Console.WriteLine("------------------------------------------------------");
            foreach (var r in result)
            {
                Console.WriteLine($"{r.Datum:yyyy-MM-dd} Temp: {r.Temp:F1}°C Fukt: {r.Fukt:F0}%"); // F = floating point (decimal)
            }
            Console.ReadKey();

        }

        public static void VarmasteDag(string fileName, string place)
        {
            var data = Load(Program.Path + fileName)
                .Where(x => x.Place == place);

            var result = data
                .GroupBy(x => x.Time.Date)
                .Select(g => new
                {
                    Datum = g.Key,  // Key = för varje datom 
                    Temp = g.Average(x => x.temp),
                    Fukt = g.Average(x => x.Humidity)
                })
                .OrderByDescending(x => x.Temp);



            Console.Clear();
            Console.WriteLine("Varmaste till kalast dag (UTE)");
            Console.WriteLine("------------------------------------------------------");
            foreach (var r in result)
            {
                Console.WriteLine($"{r.Datum:yyyy-MM-dd} Temp: {r.Temp:F01}°C"); // F = floating point (decimal)
            }
            Console.ReadKey();

        }
        public static List<WeatherRecord> Load(string filePath)
        {
            var List = new List<WeatherRecord>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                var p = line.Split(',');  // Dela upp texten vid varje komma

                if (!DateTime.TryParse(p[0], out DateTime time)) // Hämtar inte felaktiga rader!!
                {

                    continue;
                }

                List.Add(new WeatherRecord
                {
                    Time = time,
                    Place = p[1],
                    temp = double.Parse(p[2]),
                    Humidity = int.Parse(p[3])
                });
            }
            return List;
        }
    }
}
