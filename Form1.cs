using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LAB3
{
    public partial class Form1 : Form
    {
       private DataProcessor processor;
       private TemperatureChartRenderer temperatureRenderer;
       private GDPChartRenderer gdpRenderer;
       private EmissionChartRenderer emissionRenderer;
       private DataTable dataTable = new DataTable();
       private List<double> dataValues = new List<double>();

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            temperatureRenderer = new TemperatureChartRenderer(chart1);
            gdpRenderer = new GDPChartRenderer(chart1);
            emissionRenderer = new EmissionChartRenderer(chart1);
        }

        private void InitializeUI()
        {
            cmdVariant.Items.AddRange(new object[] { 3, 4, 12 });
            cmdVariant.SelectedIndex = 0;
            btnOpenFile.Click += BtnLoad_Click;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadData(openFileDialog.FileName);
                ProcessData();
            }
        }

        private void LoadData(string filePath)
        {
            dataTable.Clear();
            dataValues.Clear();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length == 0) return;

                string[] headers = lines[0].Split(',');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header.Trim());
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    DataRow row = dataTable.NewRow();
                    for (int j = 0; j < fields.Length; j++)
                    {
                        row[j] = fields[j].Trim();
                    }
                    dataTable.Rows.Add(row);

                    if (double.TryParse(fields.Last().Trim(), out double value))
                        dataValues.Add(value);
                }

                dgvData.DataSource = dataTable;
                MessageBox.Show("Data loaded successfully!");

                //Выбор на основе варианта
                int variant = (int)cmdVariant.SelectedItem;
                switch (variant)
                {
                    case 3:
                        processor = new TemperatureDataProcessor();
                        break;
                    case 4:
                       processor = new GDPDataProcessor();
                        break;
                    case 12:
                       processor = new EmissionDataProcessor();
                        break;
                }
               processor.LoadData(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading file: {ex.Message}");
            }
        }

        private void ProcessData()
        {
            if (!int.TryParse(numericPeriod.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Enter a valid value for N!");
                return;
            }

           //processor.ProcessData(n);
           DrawChart();
        }
        private void DrawChart()
        {
            chart1.Series.Clear();
            int variant = (int)cmdVariant.SelectedItem;
            switch (variant)
            {
                case 3:
                    var temperatureProcessor = (TemperatureDataProcessor)processor;
                        temperatureRenderer.RenderChart(
                        temperatureProcessor.GetDays(),
                        temperatureProcessor.GetTemperatures(),
                        processor.GetValues());
                    break;
                case 4:
                    var gdpProcessor = (GDPDataProcessor)processor;
                    gdpRenderer.RenderChart(
                        gdpProcessor.GetYears(),
                        gdpProcessor.GetIndicators(),
                        gdpProcessor.GetGdpForecast(),
                        gdpProcessor.GetGnpForecast());
                    break;
                case 12:
                    var emissionProcessor = (EmissionDataProcessor)processor;
                    emissionRenderer.RenderChart(
                        emissionProcessor.GetYears(),
                        emissionProcessor.GetEmissions(),
                        processor.GetValues());
                    break;
            }
        }
    }
}