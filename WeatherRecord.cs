using System;
using System.Collections.Generic;
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
    }
}
