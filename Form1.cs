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
        //private DataProcessor processor;
        //private TemperatureChartRenderer temperatureRenderer;
        //private GDPChartRenderer gdpRenderer;
        //private EmissionChartRenderer emissionRenderer;
        private DataTable dataTable = new DataTable();
        private List<double> dataValues = new List<double>();

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            //temperatureRenderer = new TemperatureChartRenderer(chart1);
            //gdpRenderer = new GDPChartRenderer(chart1);
            //emissionRenderer = new EmissionChartRenderer(chart1);
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
                //LoadData(openFileDialog.FileName);
                //ProcessData();
            }
        }
    }
}