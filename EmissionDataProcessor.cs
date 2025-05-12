using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LAB3
{
    // Class for processing emission data (Variant 12)
    public class EmissionDataProcessor : DataProcessor
    {
        private MovingAverageCalculator Calculator { get; set; }
        private Dictionary<string, List<double>> Emissions { get; set; }

        public EmissionDataProcessor() : base()
        {
            Calculator = new MovingAverageCalculator();
            Emissions = new Dictionary<string, List<double>>();
        }

        public override void ProcessData(int n)
        {
            Emissions.Clear();
            DataValues.Clear();

            // Check for required columns
            if (!DataTable.Columns.Contains("CO2") || !DataTable.Columns.Contains("CH4") || !DataTable.Columns.Contains("N2O"))
            {
                MessageBox.Show("CSV file must contain columns: CO2, CH4, N2O");
                return;
            }

            // Read data
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
                    Emissions[column.ColumnName] = values;
                }
            }

            // Calculate emission reduction percentages
            Dictionary<string, double> reductionPercentages = new Dictionary<string, double>();
            foreach (var gas in Emissions)
            {
                double initial = gas.Value.First();
                double final = gas.Value.Last();
                double percentage = ((initial - final) / initial) * 100;
                reductionPercentages[gas.Key] = percentage;
            }

            // Forecast CO2 emissions
            DataValues = Calculator.CalculateMovingAverage(Emissions["CO2"], n);

            // Show results
            var maxReduction = reductionPercentages.OrderByDescending(x => x.Value).FirstOrDefault();
            var minReduction = reductionPercentages.OrderBy(x => x.Value).FirstOrDefault();
            MessageBox.Show($"Gas with maximum reduction: {maxReduction.Key} ({maxReduction.Value:F2}%)\n" +
                            $"Gas with minimum reduction: {minReduction.Key} ({minReduction.Value:F2}%)");
        }

        public Dictionary<string, List<double>> GetEmissions() => Emissions;
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
    }
}