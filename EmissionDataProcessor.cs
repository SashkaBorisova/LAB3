using System.Data;
using System;
using System.Collections.Generic;
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
            if (!DataTable.Columns.Contains("CO2")||
                !DataTable.Columns.Contains("CH4")||
                !DataTable.Columns.Contains("N2O"))
            {
                MessageBox.Show("CSV file must contain columns: CO2, CH4, N2O");
                return;
            }


            // Check if DataTable has rows
            if (DataTable.Rows.Count == 0)
            {
                MessageBox.Show("CSV file contains no data rows.");
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
                        else
                        {
                            MessageBox.Show($"Invalid data in column {column.ColumnName}, row {DataTable.Rows.IndexOf(row) + 1}: '{row[column]}' is not a valid number.");
                            return;
                        }
                    }
                    // Check if values were parsed
                    if (!values.Any())
                    {
                        MessageBox.Show($"No valid numeric data found in column {column.ColumnName}.");
                        return;
                    }
                    Emissions[column.ColumnName] = values;
                }
            }

            // Check if Emissions has data
            if (!Emissions.Any())
            {
                MessageBox.Show("No valid emission data was loaded from the CSV file.");
                return;
            }

            // Calculate emission reduction percentages
            Dictionary<string, double> reductionPercentages = new Dictionary<string, double>();
            foreach (var gas in Emissions)
            {
                var values = gas.Value;
                if (values.Count < 2)
                {
                    MessageBox.Show($"Not enough data points for {gas.Key} to calculate reduction percentage (at least 2 data points required).");
                    return;
                }

                double initial = values.First();
                double final = values.Last();
                // Avoid division by zero
                if (initial == 0)
                {
                    MessageBox.Show($"Initial value for {gas.Key} is zero, cannot calculate percentage reduction.");
                    return;
                }
                double percentage = ((initial - final) / initial) * 100;
                reductionPercentages[gas.Key] = percentage;
            }

            // Check if reduction percentages were calculated
            if (!reductionPercentages.Any())
            {
                MessageBox.Show("Could not calculate reduction percentages for any gas.");
                return;
            }

            // Forecast CO2 emissions
            DataValues = Calculator.CalculateMovingAverage(Emissions["CO2"], n);

// Show results
            var maxReduction = reductionPercentages.OrderByDescending(x => x.Value).First();
            var minReduction = reductionPercentages.OrderBy(x => x.Value).First();
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
