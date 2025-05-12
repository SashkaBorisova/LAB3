using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LAB3
{
    public partial class Form1 : Form
    {
        private DataTable dataTable = new DataTable();
        private List<double> dataValues = new List<double>();

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
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
                //ProcessData();
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

                // Разделяем первую строку на заголовки
                string[] headers = lines[0].Split(',');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header.Trim());
                }

                // Читаем данные из следующих строк
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    DataRow row = dataTable.NewRow();
                    for (int j = 0; j < fields.Length; j++)
                    {
                        row[j] = fields[j].Trim();
                    }
                    dataTable.Rows.Add(row);

                    // Предполагаем, что данные для анализа находятся в последнем числовом столбце
                    if (double.TryParse(fields.Last().Trim(), out double value))
                        dataValues.Add(value);
                }

                dgvData.DataSource = dataTable;
                MessageBox.Show("Данные успешно загружены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}");
            }
        }

        private void ProcessData()
        {
            if (!int.TryParse(numericPeriod.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Введите корректное значение N!");
                return;
            }

            int variant = (int)cmdVariant.SelectedItem;
            switch (variant)
            {
                case 3: // Температура
                    ProcessTemperatureData(n);
                    break;
                case 4: // ВВП/ВНП
                    ProcessGDPData(n);
                    break;
                case 12: // Выбросы газов
                    ProcessEmissionData(n);
                    break;
            }

           // DrawChart();
        }

        private void ProcessTemperatureData(int n)
        {

        }

        private void ProcessGDPData(int n)
        {

        }

        private void ProcessEmissionData(int n)
        {

        }


    }
}

