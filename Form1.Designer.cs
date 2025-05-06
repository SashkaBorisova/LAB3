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
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // cmdVariant
            // 
            cmdVariant.FormattingEnabled = true;
            cmdVariant.Items.AddRange(new object[] { "Variant 3: Temperature", "Variant 4: GDP/GNP", "Variant: GreenHouse Gases" });
            cmdVariant.Location = new Point(59, 59);
            cmdVariant.Name = "cmdVariant";
            cmdVariant.Size = new Size(814, 56);
            cmdVariant.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(59, 145);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(814, 176);
            btnOpenFile.TabIndex = 1;
            btnOpenFile.Text = "Открыть файл";
            btnOpenFile.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(59, 366);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 123;
            dgvData.Size = new Size(814, 873);
            dgvData.TabIndex = 2;
            // 
            // textBoxInfo
            // 
            textBoxInfo.Location = new Point(949, 826);
            textBoxInfo.Name = "textBoxInfo";
            textBoxInfo.Size = new Size(1207, 413);
            textBoxInfo.TabIndex = 3;
            textBoxInfo.Text = "";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(949, 59);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(1207, 716);
            chart1.TabIndex = 4;
            chart1.Text = "chart1";
            chart1.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2229, 1276);
            Controls.Add(chart1);
            Controls.Add(textBoxInfo);
            Controls.Add(dgvData);
            Controls.Add(btnOpenFile);
            Controls.Add(cmdVariant);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmdVariant;
        private Button btnOpenFile;
        private DataGridView dgvData;
        private RichTextBox textBoxInfo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
