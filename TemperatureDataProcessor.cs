using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LAB3
{
    public class TemperatureDataProcessor : DataProcessor
    {
        private MovingAverageCalculator Calculator { get; set; }
        private Dictionary<string, List<double>> Temperatures { get; set; }

        public TemperatureDataProcessor() : base()
        {
            Calculator = new MovingAverageCalculator();
            Temperatures = new Dictionary<string, List<double>>();
        }

        public override void ProcessData(int n)
        {
            Temperatures.Clear();
            DataValues.Clear();

            // проверка наличи стобцов
            if(!DataTable.Columns.Contains("MaxTemperature")||
               !DataTable.Columns.Contains("MinTemperature")||
               !DataTable.Columns.Contains("AvgTemperature"))
            {
                MessageBox.Show("CSV file must contain columns: MaxTemperature, MinTemperature, AvgTemperature");
                return;
            }

            // считывание данных
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
                    Temperatures[column.ColumnName] = values;
                }
            }

            // расчёт разницы температур
            List<double> differences = new List<double>();
            for (int i = 0; i < Temperatures["MaxTemperature"].Count; i++)
            {
                differences.Add(Math.Abs(Temperatures["MaxTemperature"][i] - Temperatures["MinTemperature"][i]));
            }

            int maxDifferenceDay = differences.IndexOf(differences.Max()) + 1;
            int minDifferenceDay = differences.IndexOf(differences.Min()) + 1;

            // средняя температура
            DataValues = Calculator.CalculateMovingAverage(Temperatures["AvgTemperature"], n);

            // результат
            MessageBox.Show($"Day with maximum temperature difference: {maxDifferenceDay} ({differences.Max():F2}°C)\n" +
                            $"Day with minimum temperature difference: {minDifferenceDay} ({differences.Min():F2}°C)");
        }

        public Dictionary<string, List<double>> GetTemperatures() => Temperatures;
        public List<int> GetDays()
        {
            List<int> days = new List<int>();
            foreach (DataRow row in DataTable.Rows)
            {
                if (int.TryParse(row["Year"].ToString(), out int day))
                {
                    days.Add(day);
                }
            }
            return days;
        }
    }
}