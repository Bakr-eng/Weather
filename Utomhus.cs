using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    internal class Utomhus
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("Utom hus");
            Console.WriteLine("----------------------");

            Console.WriteLine("1. Medeltemperatur och luftfuktighet per dag");
            Console.WriteLine("2. Varmast till kallaste dagen enligt medeltemperatur per dag");

            var key = Console.ReadKey();

            switch (char.ToLower(key.KeyChar))
            {
                case '1': MedelTempPerDag("tempdata5-med fel.txt"); break;

            }
        }

        public static void MedelTempPerDag(string fileName)
        {
            var data = Load(Program.Path + fileName)
                .Where(x => x.Place == "Ute");

            var result = data
                .GroupBy(x => x.Time.Date)
                .Select(g => new
                {
                    Datum = g.Key,
                    Temp = g.Average(x => x.temp),
                    Fukt = g.Average(x => x.Humidity)
                })
                .OrderBy(x => x.Datum);



            Console.Clear();
            Console.WriteLine("Medeltemperatur och luftfuktighet per dag (UTE)");
            Console.WriteLine("------------------------------------------------------");

            foreach (var r in result)
            {
                Console.WriteLine($"{r.Datum:yyyy-MM-dd} Temp: {r.Temp:F1}°C Fukt: {r.Fukt:F0}%");
            }
            Console.ReadKey();

        }

        public static List<WeatherRecord> Load(string filePath)
        {
            var List = new List<WeatherRecord>();

            foreach ( var line in  File.ReadAllLines(filePath))
            {
                var p = line.Split(',');

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
