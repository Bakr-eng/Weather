using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    internal class ReadFiles
    {
        
        public static void Read(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(Program.Path + fileName))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(" " + line);
                        line = reader.ReadLine();
                    }

                }
            }
            catch
            {
                Console.WriteLine("hittades inte någon fil!!!");
            }

        }
    }
}
