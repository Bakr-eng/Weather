using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    internal class WeatherReportWriterForWinterAndAutumn
    {
        public static void CreateReport(string fileName)
        {
            // Läs in data och filtrera på UTE
            var data = WeatherRecord.Load(Program.Path + fileName)
                .Where(x => x.Place == "Ute")
                .Where(x => !(x.Time.Year == 2016 && x.Time.Month == 5))  // Ignorera maj 2016
                .Where(x => !(x.Time.Year == 2017 && x.Time.Month == 1))  // Ignorera januari 2017
                .ToList();

            Console.WriteLine("Månader som finns i UTE-datan efter filtrering:");
            var months = data
                .Select(x => x.Time.Month)
                .Distinct()
                .OrderBy(x => x);

            foreach (var m in months)
                Console.WriteLine(m);



            // Beräkna meteorologisk höst och vinter
            var autumnDate = GetMeteorologicalAutumnDate(data);
            var winterDate = GetMeteorologicalWinterDate(data);

            // Gruppberäkning per månad
            var result = data
                .GroupBy(x => x.Time.Month)
                .Select(g => new
                {
                    Månad = g.Key,
                    Temp = g.Average(x => x.temp),
                    Fukt = g.Average(x => x.Humidity)
                })
                .OrderBy(x => x.Månad)
                .ToList();

            // Skriv rapportfil
            string reportPath = Program.Path + "Månadsrapport.txt";

            using (var writer = new StreamWriter(reportPath))
            {
                writer.WriteLine("Månadsrapport");
                writer.WriteLine("------------------------------------------------------");
                writer.WriteLine();

                writer.WriteLine("Meteorologiska årstider:");
                writer.WriteLine($"Höst:  {autumnDate?.ToShortDateString() ?? "Ingen höst hittad"}");
                writer.WriteLine($"Vinter: {winterDate?.ToShortDateString() ?? "Ingen vinter (mild vinter)"}");
                writer.WriteLine();

                writer.WriteLine("Medeltemperatur och luftfuktighet per månad:");
                writer.WriteLine("------------------------------------------------------");

                foreach (var r in result)
                {
                    writer.WriteLine($"Månad {r.Månad}: Temp {r.Temp:F1}°C, Fukt {r.Fukt:F0}%");
                }
            }

            // Skriv till konsolen
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Månadsrapport");
            Console.WriteLine("------------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine($"Meteorologisk höst:  {autumnDate?.ToShortDateString() ?? "Ingen höst"}");
            Console.WriteLine($"Meteorologisk vinter: {winterDate?.ToShortDateString() ?? "Ingen vinter (mild vinter)"}");
            Console.WriteLine();

            foreach (var r in result)
            {
                Console.WriteLine($"{r.Månad}: Temp {r.Temp:F1}°C, Fukt {r.Fukt:F0}%");
            }

            Console.ReadKey();
        }

        // ---------------------------------------------------------
        // METEOROLOGISK HÖST (SMHI-regler)
        // ---------------------------------------------------------
        private static DateTime? GetMeteorologicalAutumnDate(List<WeatherRecord> data)
        {
            var daily = GetDailyMeans(data);

            // Höst får tidigast börja 1 augusti
            daily = daily.Where(d => d.Date >= new DateTime(d.Date.Year, 8, 1)).ToList();

            for (int i = 0; i < daily.Count - 4; i++)
            {
                var fiveDays = daily.Skip(i).Take(5).ToList();

                // SMHI: 5 dygn i rad med 0 < temp < 10
                if (fiveDays.All(d => d.MeanTemp < 10 && d.MeanTemp > 0))
                    return fiveDays.First().Date;
            }

            return null;
        }

        // ---------------------------------------------------------
        // METEOROLOGISK VINTER (SMHI-regler)
        // ---------------------------------------------------------
        private static DateTime? GetMeteorologicalWinterDate(List<WeatherRecord> data)
        {
            var daily = GetDailyMeans(data);

            for (int i = 0; i < daily.Count - 4; i++)
            {
                var fiveDays = daily.Skip(i).Take(5).ToList();

                // SMHI: 5 dygn i rad med temp <= 0
                if (fiveDays.All(d => d.MeanTemp <= 0))
                    return fiveDays.First().Date;
            }

            return null;
        }
        private static List<(DateTime Date, double MeanTemp)> GetDailyMeans(List<WeatherRecord> data)
        {
            return data
                .GroupBy(x => x.Time.Date)
                .Select(g => (Date: g.Key, MeanTemp: g.Average(x => x.temp)))
                .OrderBy(x => x.Date)
                .ToList();
        }

    }
}