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
                    case '1': ReadFiles.Read("tempdata5-med fel.txt"); break;
                    case '2': Place.Utomhus(); break;
                    case '3': Place.Inomhus(); break;
                    case '4': WeatherReportWriter.CreateReport("tempdata5-med fel.txt"); break;
                    case '5': DateForWinterAndAutumn.CreateReport("tempdata5-med fel.txt"); break;
                    case '6': AlgoritmForMogel.CalculateMogelRisk("tempdata5-med fel.txt"); break;


                }
            }


        }
    }
}
