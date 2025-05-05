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
            tabControl1 = new TabControl();
            tabTemperature = new TabPage();
            tabGDP = new TabPage();
            tabGreenhouse = new TabPage();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabTemperature);
            tabControl1.Controls.Add(tabGDP);
            tabControl1.Controls.Add(tabGreenhouse);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2218, 1245);
            tabControl1.TabIndex = 0;
            // 
            // tabTemperature
            // 
            tabTemperature.Location = new Point(12, 69);
            tabTemperature.Name = "tabTemperature";
            tabTemperature.Padding = new Padding(3);
            tabTemperature.Size = new Size(2194, 1164);
            tabTemperature.TabIndex = 0;
            tabTemperature.Text = "tabTemperature";
            tabTemperature.UseVisualStyleBackColor = true;
            // 
            // tabGDP
            // 
            tabGDP.Location = new Point(12, 69);
            tabGDP.Name = "tabGDP";
            tabGDP.Padding = new Padding(3);
            tabGDP.Size = new Size(2194, 1164);
            tabGDP.TabIndex = 1;
            tabGDP.Text = "tabGDP";
            tabGDP.UseVisualStyleBackColor = true;
            // 
            // tabGreenhouse
            // 
            tabGreenhouse.Location = new Point(12, 69);
            tabGreenhouse.Name = "tabGreenhouse";
            tabGreenhouse.Padding = new Padding(3);
            tabGreenhouse.Size = new Size(2194, 1164);
            tabGreenhouse.TabIndex = 2;
            tabGreenhouse.Text = "tabGreenhouse";
            tabGreenhouse.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2218, 1245);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabTemperature;
        private TabPage tabGDP;
        private TabPage tabGreenhouse;
    }
}
