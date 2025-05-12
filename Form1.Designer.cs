namespace LAB3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            cmdVariant = new ComboBox();
            btnOpenFile = new Button();
            dgvData = new DataGridView();
            textBoxInfo = new RichTextBox();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            numericPeriod = new NumericUpDown();
            btnForecast = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPeriod).BeginInit();
            SuspendLayout();
            // 
            // cmdVariant
            // 
            cmdVariant.FormattingEnabled = true;
            cmdVariant.Location = new Point(32, 86);
            cmdVariant.Name = "cmdVariant";
            cmdVariant.Size = new Size(814, 56);
            cmdVariant.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(32, 170);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(814, 128);
            btnOpenFile.TabIndex = 1;
            btnOpenFile.Text = "Открыть файл";
            btnOpenFile.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(32, 386);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 123;
            dgvData.Size = new Size(814, 898);
            dgvData.TabIndex = 2;
            // 
            // textBoxInfo
            // 
            textBoxInfo.Location = new Point(877, 170);
            textBoxInfo.Name = "textBoxInfo";
            textBoxInfo.Size = new Size(1394, 128);
            textBoxInfo.TabIndex = 3;
            textBoxInfo.Text = "";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(877, 330);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(1394, 954);
            chart1.TabIndex = 4;
            chart1.Text = "chart1";
            // 
            // numericPeriod
            // 
            numericPeriod.Location = new Point(1398, 84);
            numericPeriod.Name = "numericPeriod";
            numericPeriod.Size = new Size(466, 55);
            numericPeriod.TabIndex = 10;
            numericPeriod.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnForecast
            // 
            btnForecast.Location = new Point(1916, 75);
            btnForecast.Name = "btnForecast";
            btnForecast.Size = new Size(355, 71);
            btnForecast.TabIndex = 6;
            btnForecast.Text = "Рассчитать";
            btnForecast.UseVisualStyleBackColor = true;
            btnForecast.Click += btnForecast_Click;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(287, 21);
            label2.Name = "label2";
            label2.Size = new Size(291, 48);
            label2.TabIndex = 8;
            label2.Text = "Выбор варианта";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(254, 318);
            label3.Name = "label3";
            label3.Size = new Size(336, 48);
            label3.TabIndex = 9;
            label3.Text = "Получение данных";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(876, 86);
            label4.Name = "label4";
            label4.Size = new Size(481, 48);
            label4.TabIndex = 11;
            label4.Text = "Ввод числа N для прогноза:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2302, 1316);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnForecast);
            Controls.Add(numericPeriod);
            Controls.Add(chart1);
            Controls.Add(textBoxInfo);
            Controls.Add(dgvData);
            Controls.Add(btnOpenFile);
            Controls.Add(cmdVariant);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPeriod).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmdVariant;
        private Button btnOpenFile;
        private DataGridView dgvData;
        private RichTextBox textBoxInfo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private NumericUpDown numericPeriod;
        private Button btnForecast;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
