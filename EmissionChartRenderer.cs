using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace LAB3
{
    // Class for rendering emission charts (Variant 12)
    public class EmissionChartRenderer
    {
        private Chart Chart { get; set; }

        public EmissionChartRenderer(Chart chart)
        {
            Chart = chart;
            if (Chart.ChartAreas.Count == 0)
            {
                Chart.ChartAreas.Add(new ChartArea("MainArea"));
            }
        }

        public void RenderChart(List<int> years, Dictionary<string, List<double>> emissions, List<double> forecast)
        {
            // Clear existing series
            Chart.Series.Clear();

            // Ensure ChartArea exists
            if (Chart.ChartAreas.Count == 0)
            {
                Chart.ChartAreas.Add(new ChartArea("MainArea"));
            }

            // Set axis titles
            Chart.ChartAreas[0].AxisX.Title = "Year";
            Chart.ChartAreas[0].AxisY.Title = "Emissions (thousand tons)";

            // Check if data is available
            if (years == null|| !years.Any() || emissions == null||!emissions.Any() || forecast == null || !forecast.Any())
            {
                MessageBox.Show("No data available to render the chart.");
                return;
            }

            // Plot emission series
            int index = 0;
            foreach (var gas in emissions)
            {
                var series = new Series(gas.Key)
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    Color = GetColor(index++)
                };
                for (int i = 0; i < gas.Value.Count && i < years.Count; i++)
                {
                    series.Points.AddXY(years[i], gas.Value[i]);
                }
                Chart.Series.Add(series);
            }

            // Plot forecast
            if (forecast.Any() && years.Any())
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
                for (int i = 0; i < forecast.Count && i < forecastYears.Count; i++)
                {
                    forecastSeries.Points.AddXY(forecastYears[i], forecast[i]);
                }
                Chart.Series.Add(forecastSeries);
            }
            else
            {
                MessageBox.Show("Insufficient data for forecast.");
            }
        }

        private Color GetColor(int index)
        {
            switch (index % 3)
            {
                case 0: return Color.Blue;
                case 1: return Color.Green;
                case 2: return Color.Purple;
                default: return Color.Black;
            }
        }
    }
}