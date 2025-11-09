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
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.controlPage = new System.Windows.Forms.TabPage();
            this.trendPage = new System.Windows.Forms.TabPage();
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
            this.tabControl1.SuspendLayout();
            this.controlPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vbarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTem1)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.controlPage);
            this.tabControl1.Controls.Add(this.trendPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(533, 391);
            this.tabControl1.TabIndex = 21;
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
            this.controlPage.Size = new System.Drawing.Size(525, 362);
            this.controlPage.TabIndex = 0;
            this.controlPage.Text = "Control Tab";
            this.controlPage.UseVisualStyleBackColor = true;
            this.controlPage.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // trendPage
            // 
            this.trendPage.Location = new System.Drawing.Point(4, 25);
            this.trendPage.Name = "trendPage";
            this.trendPage.Padding = new System.Windows.Forms.Padding(3);
            this.trendPage.Size = new System.Drawing.Size(525, 362);
            this.trendPage.TabIndex = 1;
            this.trendPage.Text = "TrendPage";
            this.trendPage.UseVisualStyleBackColor = true;
            // 
            // slider
            // 
            this.slider.Location = new System.Drawing.Point(438, 23);
            this.slider.Maximum = 1000;
            this.slider.Name = "slider";
            this.slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.slider.Size = new System.Drawing.Size(56, 268);
            this.slider.TabIndex = 30;
            // 
            // pbfan
            // 
            this.pbfan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbfan.Location = new System.Drawing.Point(179, 23);
            this.pbfan.Name = "pbfan";
            this.pbfan.Size = new System.Drawing.Size(137, 130);
            this.pbfan.TabIndex = 29;
            this.pbfan.TabStop = false;
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(26, 98);
            this.btStop.Margin = new System.Windows.Forms.Padding(4);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(124, 55);
            this.btStop.TabIndex = 28;
            this.btStop.Text = "STOP";
            this.btStop.UseVisualStyleBackColor = true;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(26, 23);
            this.btStart.Margin = new System.Windows.Forms.Padding(4);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(124, 55);
            this.btStart.TabIndex = 27;
            this.btStart.Text = "START";
            this.btStart.UseVisualStyleBackColor = true;
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeed.Location = new System.Drawing.Point(21, 233);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(70, 25);
            this.lbSpeed.TabIndex = 26;
            this.lbSpeed.Text = "Speed";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(150, 233);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(53, 25);
            this.label.TabIndex = 25;
            this.label.Text = "Num";
            // 
            // vbarSpeed
            // 
            this.vbarSpeed.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.vbarSpeed.Location = new System.Drawing.Point(357, 22);
            this.vbarSpeed.Name = "vbarSpeed";
            this.vbarSpeed.Size = new System.Drawing.Size(39, 269);
            this.vbarSpeed.TabIndex = 24;
            this.vbarSpeed.TabStop = false;
            // 
            // pbTem1
            // 
            this.pbTem1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pbTem1.Location = new System.Drawing.Point(357, 23);
            this.pbTem1.Name = "pbTem1";
            this.pbTem1.Size = new System.Drawing.Size(39, 270);
            this.pbTem1.TabIndex = 23;
            this.pbTem1.TabStop = false;
            // 
            // lbSetSpeed
            // 
            this.lbSetSpeed.Location = new System.Drawing.Point(155, 188);
            this.lbSetSpeed.Name = "lbSetSpeed";
            this.lbSetSpeed.Size = new System.Drawing.Size(161, 22);
            this.lbSetSpeed.TabIndex = 22;
            // 
            // lbTemperature
            // 
            this.lbTemperature.AutoSize = true;
            this.lbTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTemperature.Location = new System.Drawing.Point(21, 185);
            this.lbTemperature.Name = "lbTemperature";
            this.lbTemperature.Size = new System.Drawing.Size(105, 25);
            this.lbTemperature.TabIndex = 21;
            this.lbTemperature.Text = "Set Speed";
            // 
            // Motor_Faceplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 434);
            this.Controls.Add(this.tabControl1);
            this.Name = "Motor_Faceplate";
            this.Text = "Motor_Faceplate";
            this.Load += new System.EventHandler(this.Motor_Faceplate_Load);
            this.tabControl1.ResumeLayout(false);
            this.controlPage.ResumeLayout(false);
            this.controlPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vbarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.TabControl tabControl1;
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
    }
}