
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
                .Where(x => x.Place == place && IsIncludedDate(x.Time));

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
                .Where(x => x.Place == place && IsIncludedDate(x.Time));

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

        // Default Value version
        public static bool IsIncludedDate(DateTime time)
        {
            if (time.Year == 2016 && time.Month > 5) // Only includes date in 2016, since data to be grabbed is only between 2016-05-31 to 2016-12-31
            {
                return true;
            }
            return false;
        }
        // These are version to checks before/after specific date
        // Will also (for now) exclude data outside default range (2016)
        public static bool IsIncludedDate(DateTime time, DateTime target, bool is_before)
        {
            if (is_before)
            {
                return time < target && IsIncludedDate(time);
            }
            else
            {
                return time >= target && IsIncludedDate(time);
            }
        }
        // Checks if time is between two specified dates
        public static bool IsIncludedDate(DateTime time, DateTime? lower_range = null, DateTime? upper_range = null)
        {
            if (lower_range == null || upper_range == null)
            {
                // If either is available
                if (lower_range != null)
                {
                    return IsIncludedDate(time, (DateTime)lower_range, true);
                }
                if (upper_range != null)
                {
                    return IsIncludedDate(time, (DateTime)upper_range, true);
                }
                // If not enough information is placed default value
                return IsIncludedDate(time);
            }
            return time >= lower_range && time < upper_range;
        }
    }
}
