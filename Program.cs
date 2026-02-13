using System.Xml.Schema;

namespace Weather
{
    internal class Program
    {
        public static string Path = "../../../files/";
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\x1b[3J");

                WindowLayout.Title();


                var key = Console.ReadKey();
                switch (char.ToLower(key.KeyChar))
                {
                    case '0': ReadFiles.Read("tempdata5-med fel.txt"); break;
                    case '1': Place.Utomhus(); break;
                    case '2': Place.Inomhus(); break;
                    case 'a': WeatherReportWriter.CreateReport("tempdata5-med fel.txt"); break;
                    case 'b': WeatherReportWriter.CreateReport("tempdata5-med fel.txt"); break;
                    case 'm': AlgoritmForMogel.CalculateMogelRisk("tempdata5-med fel.txt"); break;


                }
            }


        }
    }
}
