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
                //Console.WriteLine("välj en alternativ!");
                //Console.WriteLine("------------------------------");
                //Console.WriteLine("0. Läsa hela filen");
                //Console.WriteLine("1. Utomhus");
                //Console.WriteLine("2. Inomhus");

                WindowLayout.Title();



                var key = Console.ReadKey();
                switch (char.ToLower(key.KeyChar))
                {
                    case '0': ReadFiles.Read("tempdata5-med fel.txt"); break;
                    case '1': Place.Utomhus(); break;
                    case '2': Place.Inomhus(); break;
                    case 'a': WeatherReportWriter.CreateReport("tempdata5-med fel.txt"); break;
                    

                }
            }


        }
    }
}
