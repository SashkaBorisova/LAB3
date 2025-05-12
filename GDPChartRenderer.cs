using System.Collections.Generic;
using System.Drawing;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace LAB3
{
    // Класс для построения графиков ВВП и ВНП (вариант 4)
    public class GDPChartRenderer
    {
        private Chart Chart { get; set; }

        public GDPChartRenderer(Chart chart)
        {
            Chart = chart;
        }

        public void RenderChart(List<int> years, Dictionary<string, List<double>> indicators, List<double> gdpForecast, List<double> gnpForecast)
        {
            Chart.Series.Clear();
            Chart.ChartAreas[0].AxisX.Title = "Year";
            Chart.ChartAreas[0].AxisY.Title = "Billion Rubles";

            // Построение графиков ВВП и ВНП
            foreach (var indicator in indicators)
            {
                var series = new Series(indicator.Key)
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    Color = indicator.Key == "GDP" ? Color.Blue : Color.Green
                };
                for (int i = 0; i < indicator.Value.Count; i++)
                {
                    series.Points.AddXY(years[i], indicator.Value[i]);
                }
                Chart.Series.Add(series);
            }

            // Построить прогноз ВВП
            if (gdpForecast.Any())
            {
                var gdpForecastSeries = new Series("GDP Forecast")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    BorderDashStyle = ChartDashStyle.Dash,
                    Color = Color.Red
                };
                var forecastYears = new List<int>(years);
                for (int i = 1; i <= gdpForecast.Count - years.Count; i++)
                {
                    forecastYears.Add(years.Last() + i);
                }
                for (int i = 0; i < gdpForecast.Count; i++)
                {
                    gdpForecastSeries.Points.AddXY(forecastYears[i], gdpForecast[i]);
                }
                Chart.Series.Add(gdpForecastSeries);
            }


            // Построить прогноз ВНП
            if (gnpForecast.Any())
            {
                var gnpForecastSeries = new Series("GNP Forecast")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    BorderDashStyle = ChartDashStyle.Dash,
                    Color = Color.Orange
                };
                var forecastYears = new List<int>(years);
                for (int i = 1; i <= gnpForecast.Count - years.Count; i++)
                {
                    forecastYears.Add(years.Last() + i);
                }
                for (int i = 0; i < gnpForecast.Count; i++)
                {
                    gnpForecastSeries.Points.AddXY(forecastYears[i], gnpForecast[i]);
                }
                Chart.Series.Add(gnpForecastSeries);
            }
        }
    }
}
