using System.Xml.Schema;

namespace Weather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("välj en alternativ!");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. utomhus");
            Console.WriteLine("2. inomhus");
            Console.WriteLine("0. Lässa hela filen");
            char index;


            var key = Console.ReadKey();
            switch (char.ToLower(key.KeyChar))
            {
                case '1': Utomhus.Show(); break;
                case '2': InomHus.Show(); break;
                case '0': ReadFiles.Read("tempdata5-med fel.txt"); break;

            }

        }
    }
}
