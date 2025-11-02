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
            this.lbSetSpeed = new System.Windows.Forms.TextBox();
            this.lbTemperature = new System.Windows.Forms.Label();
            this.vbarSpeed = new System.Windows.Forms.PictureBox();
            this.pbTem1 = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.pbfan = new System.Windows.Forms.PictureBox();
            this.slider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.vbarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick_1);
            // 
            // lbSetSpeed
            // 
            this.lbSetSpeed.Location = new System.Drawing.Point(154, 178);
            this.lbSetSpeed.Name = "lbSetSpeed";
            this.lbSetSpeed.Size = new System.Drawing.Size(161, 22);
            this.lbSetSpeed.TabIndex = 10;
            this.lbSetSpeed.DoubleClick += new System.EventHandler(this.lbSetSpeed_DoubleClick);
            this.lbSetSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbSetSpeed_KeyDown);
            // 
            // lbTemperature
            // 
            this.lbTemperature.AutoSize = true;
            this.lbTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTemperature.Location = new System.Drawing.Point(20, 175);
            this.lbTemperature.Name = "lbTemperature";
            this.lbTemperature.Size = new System.Drawing.Size(105, 25);
            this.lbTemperature.TabIndex = 9;
            this.lbTemperature.Text = "Set Speed";
            // 
            // vbarSpeed
            // 
            this.vbarSpeed.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.vbarSpeed.Location = new System.Drawing.Point(356, 12);
            this.vbarSpeed.Name = "vbarSpeed";
            this.vbarSpeed.Size = new System.Drawing.Size(39, 269);
            this.vbarSpeed.TabIndex = 14;
            this.vbarSpeed.TabStop = false;
            // 
            // pbTem1
            // 
            this.pbTem1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pbTem1.Location = new System.Drawing.Point(356, 13);
            this.pbTem1.Name = "pbTem1";
            this.pbTem1.Size = new System.Drawing.Size(39, 270);
            this.pbTem1.TabIndex = 13;
            this.pbTem1.TabStop = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(149, 223);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(53, 25);
            this.label.TabIndex = 15;
            this.label.Text = "Num";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeed.Location = new System.Drawing.Point(20, 223);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(70, 25);
            this.lbSpeed.TabIndex = 16;
            this.lbSpeed.Text = "Speed";
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(25, 88);
            this.btStop.Margin = new System.Windows.Forms.Padding(4);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(124, 55);
            this.btStop.TabIndex = 18;
            this.btStop.Text = "STOP";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(25, 13);
            this.btStart.Margin = new System.Windows.Forms.Padding(4);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(124, 55);
            this.btStart.TabIndex = 17;
            this.btStart.Text = "START";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // pbfan
            // 
            this.pbfan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbfan.Location = new System.Drawing.Point(178, 13);
            this.pbfan.Name = "pbfan";
            this.pbfan.Size = new System.Drawing.Size(137, 130);
            this.pbfan.TabIndex = 19;
            this.pbfan.TabStop = false;
            // 
            // slider
            // 
            this.slider.Location = new System.Drawing.Point(437, 13);
            this.slider.Maximum = 1000;
            this.slider.Name = "slider";
            this.slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.slider.Size = new System.Drawing.Size(56, 268);
            this.slider.TabIndex = 20;
            this.slider.Scroll += new System.EventHandler(this.slider_Scroll);
            this.slider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.slider_MouseDown);
            this.slider.MouseLeave += new System.EventHandler(this.slider_MouseLeave);
            // 
            // Motor_Faceplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 320);
            this.Controls.Add(this.slider);
            this.Controls.Add(this.pbfan);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.lbSpeed);
            this.Controls.Add(this.label);
            this.Controls.Add(this.vbarSpeed);
            this.Controls.Add(this.pbTem1);
            this.Controls.Add(this.lbSetSpeed);
            this.Controls.Add(this.lbTemperature);
            this.Name = "Motor_Faceplate";
            this.Text = "Motor_Faceplate";
            this.Load += new System.EventHandler(this.Motor_Faceplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vbarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.TextBox lbSetSpeed;
        private System.Windows.Forms.Label lbTemperature;
        private System.Windows.Forms.PictureBox vbarSpeed;
        private System.Windows.Forms.PictureBox pbTem1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.PictureBox pbfan;
        private System.Windows.Forms.TrackBar slider;
    }
}