using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    internal class Place
    {
        public static void Inomhus()
        {
            Console.Clear();
            WindowLayout.Inomhus();
            var key = Console.ReadKey(true);

            switch (char.ToLower(key.KeyChar))
            {
                case '1': Show.MedelTempPerDag("tempdata5-med fel.txt", "Inne"); break;
                case '2': Show.VarmasteDag("tempdata5-med fel.txt", "Inne"); break;
                case '3': Show.torrasteDag("tempdata5-med fel.txt", "Inne"); break;
                case '4': Show.Searching("tempdata5-med fel.txt", "Inne"); break;
                case '5': Show.RiskMögel("tempdata5-med fel.txt", "Inne"); break;
               

            }
        }
        public static void Utomhus()
        {
            Console.Clear();
            WindowLayout.Utomhus();


            var key = Console.ReadKey(true);

            switch (char.ToLower(key.KeyChar))
            {
                case '1': Show.MedelTempPerDag("tempdata5-med fel.txt", "Ute"); break;
                case '2': Show.VarmasteDag("tempdata5-med fel.txt", "Ute"); break;
                case '3': Show.torrasteDag("tempdata5-med fel.txt", "Ute"); break;
                case '4': Show.Searching("tempdata5-med fel.txt", "Ute"); break;
                case '5': Show.RiskMögel("tempdata5-med fel.txt", "Ute"); break;
                

            }
        }
    }
}
