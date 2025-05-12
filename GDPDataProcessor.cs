using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LAB3
{
    // Класс для обработки данных о ВВП и ВНП (вариант 4)
    public class GDPDataProcessor : DataProcessor
    {
        private MovingAverageCalculator Calculator { get; set; }
        private Dictionary<string, List<double>> Indicators { get; set; }
        private List<double> GdpForecast { get; set; }
        private List<double> GnpForecast { get; set; }

        public GDPDataProcessor() : base()
        {
            Calculator = new MovingAverageCalculator();
            Indicators = new Dictionary<string, List<double>>();
            GdpForecast = new List<double>();
            GnpForecast = new List<double>();
        }

        public override void ProcessData(int n)
        {
            Indicators.Clear();
            DataValues.Clear();
            GdpForecast.Clear();
            GnpForecast.Clear();


            // Проверьте наличие необходимых столбцов
            if (!DataTable.Columns.Contains("GDP") || !DataTable.Columns.Contains("GNP"))
            {
                MessageBox.Show("CSV file must contain columns: GDP, GNP");
                return;
            }

            // Считывание данных
            foreach (DataColumn column in DataTable.Columns)
            {
                if (column.ColumnName.ToLower() != "year")
                {
                    List<double> values = new List<double>();
                    foreach (DataRow row in DataTable.Rows)
                    {
                        if (double.TryParse(row[column].ToString(), out double value))
                        {
                            values.Add(value);
                        }
                    }
                    Indicators[column.ColumnName] = values;
                }
            }

            // Рассчитать процентные изменения ВВП и ВНП
            List<double> gdpPercentageChanges = new List<double>();
            List<double> gnpPercentageChanges = new List<double>();
            var gdp = Indicators["GDP"];
            var gnp = Indicators["GNP"];
            for (int i = 1; i < gdp.Count; i++)
            {
                double gdpChange = ((gdp[i] - gdp[i - 1]) / gdp[i - 1]) * 100;
                double gnpChange = ((gnp[i] - gnp[i - 1]) / gnp[i - 1]) * 100;
                gdpPercentageChanges.Add(gdpChange);
                gnpPercentageChanges.Add(gnpChange);
            }

            double maxGdpGrowth = gdpPercentageChanges.Where(x => x > 0).DefaultIfEmpty(0).Max();
            double maxGdpDecline = gdpPercentageChanges.Where(x => x < 0).DefaultIfEmpty(0).Min();
            double maxGnpGrowth = gnpPercentageChanges.Where(x => x > 0).DefaultIfEmpty(0).Max();
            double maxGnpDecline = gnpPercentageChanges.Where(x => x < 0).DefaultIfEmpty(0).Min();

            // Прогнозируемый ВВП и ВНП
            GdpForecast = Calculator.CalculateMovingAverage(Indicators["GDP"], n);
            GnpForecast = Calculator.CalculateMovingAverage(Indicators["GNP"], n);

            // Установите значения данных в соответствии с прогнозом ВВП для обеспечения совместимости
            DataValues = GdpForecast;

            // Показать результаты
            MessageBox.Show($"GDP:\n  Maximum growth: {maxGdpGrowth:F2}%\n  Maximum decline: {maxGdpDecline:F2}%\n" +
                            $"GNP:\n  Maximum growth: {maxGnpGrowth:F2}%\n  Maximum decline: {maxGnpDecline:F2}%");
        }

        public Dictionary<string, List<double>> GetIndicators() => Indicators;
        public List<int> GetYears()
        {
            List<int> years = new List<int>();
            foreach (DataRow row in DataTable.Rows)
            {
                if (int.TryParse(row["Year"].ToString(), out int year))
                {
                    years.Add(year);
                }
            }
            return years;
        }

        public List<double> GetGdpForecast() => GdpForecast;
        public List<double> GetGnpForecast() => GnpForecast;
    }
}