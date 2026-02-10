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
            WindowLayout.Uomhus();


            var key = Console.ReadKey();

            switch (char.ToLower(key.KeyChar))
            {
                case '1': Linq.MedelTempPerDag("tempdata5-med fel.txt", "Ute"); break;
                case '2': Linq.VarmasteDag("tempdata5-med fel.txt", "Ute"); break;

            }
        }
    }
}
