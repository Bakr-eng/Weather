using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    internal class WeatherRecord
    {
        public DateTime Time { get; set; }
        public string Place { get; set; }
        public double temp { get; set; }
        public int Humidity { get; set; }



        public static List<WeatherRecord> Load(string filePath)
        {
            var List = new List<WeatherRecord>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (!RegExHandler.GetMatch(line)) continue; // Kollar om datan är rätt formulerad

                var p = line.Split(',');  // Dela upp texten vid varje komma

                if (!DateTime.TryParse(p[0], out DateTime time)) continue;// Hämtar inte felaktiga rader!!
             
                
               

                List.Add(new WeatherRecord
                {
                    Time = time,
                    Place = p[1],
                    temp = double.Parse(p[2], CultureInfo.InvariantCulture.NumberFormat),
                    Humidity = int.Parse(p[3])
                });
            }
            return List;
        }
    }
}
