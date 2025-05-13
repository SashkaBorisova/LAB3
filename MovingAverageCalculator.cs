using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace LAB3
{
    // класс для вычисления скользящей средней
    public class MovingAverageCalculator
    {
        public List<double> CalculateMovingAverage(List<double> values, int n)
        {
            var forecast = new List<double>();
            for (int i = 0; i < values.Count; i++)
            {
                if (i + n <= values.Count)
                {
                    var window = values.Skip(i).Take(n).ToList();
                    forecast.Add(window.Average());
                }
                else
                {
                    forecast.Add(forecast.Last());
                }
            }
            for (int i = 0; i < n; i++)
            {
                forecast.Add(forecast.Last());
            }
            return forecast;
        }
    }
}
