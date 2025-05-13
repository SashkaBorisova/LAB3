using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace LAB3
{
    // Abstract base class for data processing
    public abstract class DataProcessor
    {
        protected DataTable DataTable { get; set; }
        protected List<double> DataValues { get; set; }

        public DataProcessor()
        {
            DataTable = new DataTable();
            DataValues = new List<double>();
        }

        // Load data from CSV
        public virtual void LoadData(string filePath)
        {
            DataTable.Clear();
            DataValues.Clear();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length == 0) return;

                string[] headers = lines[0].Split(',');
                foreach (string header in headers)
                {
                    DataTable.Columns.Add(header.Trim());
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    DataRow row = DataTable.NewRow();
                    for (int j = 0; j < fields.Length && j < headers.Length; j++)
                    {
                        row[j] = fields[j].Trim();
                    }
                    DataTable.Rows.Add(row);

                    if (double.TryParse(fields.Last().Trim(), out double value))
                        DataValues.Add(value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading file: {ex.Message}");
            }
        }

        // Abstract method for data processing
        public abstract void ProcessData(int n);

        // Get data
        public DataTable GetTable() => DataTable;
        public List<double> GetValues() => DataValues;
    }
}