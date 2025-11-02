using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;

namespace MySCADA
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        // MonitorTimer: đọc trạng thái từ Program.Motors và cập nhật màu pbMotor_i
        private void MonitorTimer_Tick(object sender, EventArgs e)
        {
            UpdateMotorIndicatorFromModel(0, pbMotor_1);
            UpdateMotorIndicatorFromModel(1, pbMotor_2);
            UpdateMotorIndicatorFromModel(2, pbMotor_3);
            UpdateMotorIndicatorFromModel(3, pbMotor_4);
            UpdateMotorIndicatorFromModel(4, pbMotor_5);
            UpdateMotorIndicatorFromModel(5, pbMotor_6);
            UpdateMotorIndicatorFromModel(6, pbMotor_7);
            UpdateMotorIndicatorFromModel(7, pbMotor_8);
            UpdateMotorIndicatorFromModel(8, pbMotor_9);
            UpdateMotorIndicatorFromModel(9, pbMotor_10);
        }

        private void UpdateMotorIndicatorFromModel(int index, PictureBox pb)
        {
            if (pb == null) return;

            if (Program.Motors != null && index >= 0 && index < Program.Motors.Count)
            {
                try
                {
                    bool running = Program.Motors[index].Status;
                    pb.BackColor = running ? Color.Green : Color.Gray;
                }
                catch
                {
                    pb.BackColor = Color.LightGray;
                }
            }
            else
            {
                pb.BackColor = Color.LightGray;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MonitorTimer_Tick(this, EventArgs.Empty);
        }
        private void btMotor_1_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_1");
            if (motor != null) 
            { 
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_2_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_1");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_3_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_1");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_4_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_1");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_5_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_1");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_6_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_1");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_7_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_1");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_8_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_1");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_9_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_1");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_10_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_1");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }
    }
}
