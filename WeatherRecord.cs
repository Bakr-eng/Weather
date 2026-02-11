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
            var list = new List<WeatherRecord>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var p = line.Split(',');
                if (p.Length != 4)
                    continue;

                if (!DateTime.TryParse(p[0].Trim(), out DateTime time))
                    continue;

                string place = p[1].Trim();
                if (place != "Inne" && place != "Ute")
                    continue;

                if (!double.TryParse(p[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double temp))
                    continue;

                if (!int.TryParse(p[3].Trim(), out int humidity))
                    continue;

                list.Add(new WeatherRecord
                {
                    Time = time,
                    Place = place,
                    temp = temp,
                    Humidity = humidity
                });
            }

            return list;
        }

    }
}
