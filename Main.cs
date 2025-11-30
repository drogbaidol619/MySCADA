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
            Motor motor = Program.Root.FindMotor("Motor_2");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_3_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_3");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_4_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_4");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_5_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_5");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_6_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_6");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_7_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_7");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_8_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_8");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_9_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_9");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void btMotor_10_Click(object sender, EventArgs e)
        {
            Motor motor = Program.Root.FindMotor("Motor_10");
            if (motor != null)
            {
                Motor_Faceplate fpl = new Motor_Faceplate(motor);
                fpl.Show();
            }
        }

        private void MonitorTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Gọi hàm trợ giúp cho từng motor
                UpdateMotorColor(pbMotor_1, "Motor_1");
                UpdateMotorColor(pbMotor_2, "Motor_2");
                UpdateMotorColor(pbMotor_3, "Motor_3");
                UpdateMotorColor(pbMotor_4, "Motor_4");
                UpdateMotorColor(pbMotor_5, "Motor_5");
                UpdateMotorColor(pbMotor_6, "Motor_6");
                UpdateMotorColor(pbMotor_7, "Motor_7");
                UpdateMotorColor(pbMotor_8, "Motor_8");
                UpdateMotorColor(pbMotor_9, "Motor_9");
                UpdateMotorColor(pbMotor_10, "Motor_10");
            }
            catch (Exception ex)
            {
                MonitorTimer.Stop();
                MessageBox.Show("Lỗi nghiêm trọng khi cập nhật UI: " + ex.Message);
            }
        }


        private void UpdateMotorColor(Control control, string motorName)
        {
            Motor motor = Program.Root.FindMotor(motorName);

            if (motor != null)
            {
                if (motor.Status)
                {
                    control.BackColor = Color.Green; 
                }
                else
                {
                    control.BackColor = Color.Gray; 
                }
            }
            else
            {
                control.BackColor = Color.Red;
            }
        }


    }
}
