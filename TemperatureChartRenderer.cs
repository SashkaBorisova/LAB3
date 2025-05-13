using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace LAB3
{

    public class TemperatureChartRenderer
    {
        private Chart Chart { get; set; }

        public TemperatureChartRenderer(Chart chart)
        {
            Chart = chart;
        }

        public void RenderChart(List<int> days, Dictionary<string, List<double>> temperatures, List<double> forecast)
        {
            Chart.Series.Clear();
            Chart.ChartAreas[0].AxisX.Title = "Day";
            Chart.ChartAreas[0].AxisY.Title = "Temperature (°C)";

            foreach (var type in temperatures)
            {
                var series = new Series(type.Key)
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    Color = type.Key.Contains("Max") ? Color.Red :
                            type.Key.Contains("Min") ? Color.Blue :
                            Color.Green
                };
                for (int i = 0; i < type.Value.Count; i++)
                {
                    series.Points.AddXY(days[i], type.Value[i]);
                }
                Chart.Series.Add(series);
            }

            if (forecast.Any())
            {
                var forecastSeries = new Series("Avg Temperature Forecast")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    BorderDashStyle = ChartDashStyle.Dash,
                    Color = Color.Orange
                };
                var forecastDays = new List<int>(days);
                for (int i = 1; i <= forecast.Count - days.Count; i++)
                {
                    forecastDays.Add(days.Last() + i);
                }
                for (int i = 0; i < forecast.Count; i++)
                {
                    forecastSeries.Points.AddXY(forecastDays[i], forecast[i]);
                }
                Chart.Series.Add(forecastSeries);
            }
        }
    }
}
