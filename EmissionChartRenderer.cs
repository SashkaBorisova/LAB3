using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace LAB3
{
    public class EmissionChartRenderer
    {
        private Chart Chart { get; set; }

        public EmissionChartRenderer(Chart chart)
        {
            Chart = chart;
        }

        public void RenderChart(List<int> years, Dictionary<string, List<double>> emissions, List<double> forecast)
        {
            Chart.Series.Clear();
            Chart.ChartAreas[0].AxisX.Title = "Year";
            Chart.ChartAreas[0].AxisY.Title = "Emissions (thousand tons)";

            foreach (var gas in emissions)
            {
                var series = new Series(gas.Key)
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2
                };
                for (int i = 0; i < gas.Value.Count; i++)
                {
                    series.Points.AddXY(years[i], gas.Value[i]);
                }
                Chart.Series.Add(series);
            }

            if (forecast.Any())
            {
                var forecastSeries = new Series("CO2 Forecast")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    BorderDashStyle = ChartDashStyle.Dash,
                    Color = Color.Red
                };
                var forecastYears = new List<int>(years);
                for (int i = 1; i <= forecast.Count - years.Count; i++)
                {
                    forecastYears.Add(years.Last() + i);
                }
                for (int i = 0; i < forecast.Count; i++)
                {
                    forecastSeries.Points.AddXY(forecastYears[i], forecast[i]);
                }
                Chart.Series.Add(forecastSeries);
            }
        }
    }
}