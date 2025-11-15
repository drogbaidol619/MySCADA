namespace MySCADA
{
    partial class Motor_Faceplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.tab = new System.Windows.Forms.TabControl();
            this.controlPage = new System.Windows.Forms.TabPage();
            this.slider = new System.Windows.Forms.TrackBar();
            this.pbfan = new System.Windows.Forms.PictureBox();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.vbarSpeed = new System.Windows.Forms.PictureBox();
            this.pbTem1 = new System.Windows.Forms.PictureBox();
            this.lbSetSpeed = new System.Windows.Forms.TextBox();
            this.lbTemperature = new System.Windows.Forms.Label();
            this.trendPage = new System.Windows.Forms.TabPage();
            this.chartSpeed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.alarmPage = new System.Windows.Forms.TabPage();
            this.tab.SuspendLayout();
            this.controlPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vbarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTem1)).BeginInit();
            this.trendPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick_1);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.controlPage);
            this.tab.Controls.Add(this.trendPage);
            this.tab.Controls.Add(this.alarmPage);
            this.tab.Location = new System.Drawing.Point(12, 22);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(910, 481);
            this.tab.TabIndex = 21;
            // 
            // controlPage
            // 
            this.controlPage.Controls.Add(this.slider);
            this.controlPage.Controls.Add(this.pbfan);
            this.controlPage.Controls.Add(this.btStop);
            this.controlPage.Controls.Add(this.btStart);
            this.controlPage.Controls.Add(this.lbSpeed);
            this.controlPage.Controls.Add(this.label);
            this.controlPage.Controls.Add(this.vbarSpeed);
            this.controlPage.Controls.Add(this.pbTem1);
            this.controlPage.Controls.Add(this.lbSetSpeed);
            this.controlPage.Controls.Add(this.lbTemperature);
            this.controlPage.Location = new System.Drawing.Point(4, 25);
            this.controlPage.Name = "controlPage";
            this.controlPage.Padding = new System.Windows.Forms.Padding(3);
            this.controlPage.Size = new System.Drawing.Size(902, 452);
            this.controlPage.TabIndex = 0;
            this.controlPage.Text = "Control Tab";
            this.controlPage.UseVisualStyleBackColor = true;
            // 
            // slider
            // 
            this.slider.Location = new System.Drawing.Point(707, 40);
            this.slider.Maximum = 1000;
            this.slider.Name = "slider";
            this.slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.slider.Size = new System.Drawing.Size(56, 268);
            this.slider.TabIndex = 30;
            this.slider.Scroll += new System.EventHandler(this.slider_Scroll);
            this.slider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.slider_MouseDown);
            this.slider.MouseLeave += new System.EventHandler(this.slider_MouseLeave);
            // 
            // pbfan
            // 
            this.pbfan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbfan.Location = new System.Drawing.Point(302, 40);
            this.pbfan.Name = "pbfan";
            this.pbfan.Size = new System.Drawing.Size(137, 130);
            this.pbfan.TabIndex = 29;
            this.pbfan.TabStop = false;
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(78, 115);
            this.btStop.Margin = new System.Windows.Forms.Padding(4);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(124, 55);
            this.btStop.TabIndex = 28;
            this.btStop.Text = "STOP";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(78, 40);
            this.btStart.Margin = new System.Windows.Forms.Padding(4);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(124, 55);
            this.btStart.TabIndex = 27;
            this.btStart.Text = "START";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeed.Location = new System.Drawing.Point(97, 297);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(70, 25);
            this.lbSpeed.TabIndex = 26;
            this.lbSpeed.Text = "Speed";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(386, 297);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(53, 25);
            this.label.TabIndex = 25;
            this.label.Text = "Num";
            // 
            // vbarSpeed
            // 
            this.vbarSpeed.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.vbarSpeed.Location = new System.Drawing.Point(555, 40);
            this.vbarSpeed.Name = "vbarSpeed";
            this.vbarSpeed.Size = new System.Drawing.Size(39, 269);
            this.vbarSpeed.TabIndex = 24;
            this.vbarSpeed.TabStop = false;
            // 
            // pbTem1
            // 
            this.pbTem1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pbTem1.Location = new System.Drawing.Point(555, 40);
            this.pbTem1.Name = "pbTem1";
            this.pbTem1.Size = new System.Drawing.Size(39, 270);
            this.pbTem1.TabIndex = 23;
            this.pbTem1.TabStop = false;
            // 
            // lbSetSpeed
            // 
            this.lbSetSpeed.Location = new System.Drawing.Point(278, 223);
            this.lbSetSpeed.Name = "lbSetSpeed";
            this.lbSetSpeed.Size = new System.Drawing.Size(161, 22);
            this.lbSetSpeed.TabIndex = 22;
            this.lbSetSpeed.DoubleClick += new System.EventHandler(this.lbSetSpeed_DoubleClick);
            this.lbSetSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbSetSpeed_KeyDown);
            // 
            // lbTemperature
            // 
            this.lbTemperature.AutoSize = true;
            this.lbTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTemperature.Location = new System.Drawing.Point(97, 223);
            this.lbTemperature.Name = "lbTemperature";
            this.lbTemperature.Size = new System.Drawing.Size(105, 25);
            this.lbTemperature.TabIndex = 21;
            this.lbTemperature.Text = "Set Speed";
            // 
            // trendPage
            // 
            this.trendPage.Controls.Add(this.chartSpeed);
            this.trendPage.Location = new System.Drawing.Point(4, 25);
            this.trendPage.Name = "trendPage";
            this.trendPage.Padding = new System.Windows.Forms.Padding(3);
            this.trendPage.Size = new System.Drawing.Size(902, 452);
            this.trendPage.TabIndex = 1;
            this.trendPage.Text = "TrendPage";
            this.trendPage.UseVisualStyleBackColor = true;
            // 
            // chartSpeed
            // 
            chartArea3.Name = "ChartArea1";
            this.chartSpeed.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartSpeed.Legends.Add(legend3);
            this.chartSpeed.Location = new System.Drawing.Point(3, 3);
            this.chartSpeed.Name = "chartSpeed";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartSpeed.Series.Add(series3);
            this.chartSpeed.Size = new System.Drawing.Size(896, 446);
            this.chartSpeed.TabIndex = 0;
            this.chartSpeed.Text = "chart1";
            // 
            // alarmPage
            // 
            this.alarmPage.Location = new System.Drawing.Point(4, 25);
            this.alarmPage.Name = "alarmPage";
            this.alarmPage.Padding = new System.Windows.Forms.Padding(3);
            this.alarmPage.Size = new System.Drawing.Size(902, 452);
            this.alarmPage.TabIndex = 2;
            this.alarmPage.Text = "AlarmPage";
            this.alarmPage.UseVisualStyleBackColor = true;
            // 
            // Motor_Faceplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 503);
            this.Controls.Add(this.tab);
            this.Name = "Motor_Faceplate";
            this.Text = "Motor_Faceplate";
            this.Load += new System.EventHandler(this.Motor_Faceplate_Load);
            this.tab.ResumeLayout(false);
            this.controlPage.ResumeLayout(false);
            this.controlPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vbarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTem1)).EndInit();
            this.trendPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage controlPage;
        private System.Windows.Forms.TabPage trendPage;
        private System.Windows.Forms.TrackBar slider;
        private System.Windows.Forms.PictureBox pbfan;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox vbarSpeed;
        private System.Windows.Forms.PictureBox pbTem1;
        private System.Windows.Forms.TextBox lbSetSpeed;
        private System.Windows.Forms.Label lbTemperature;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpeed;
        private System.Windows.Forms.TabPage alarmPage;
    }
}