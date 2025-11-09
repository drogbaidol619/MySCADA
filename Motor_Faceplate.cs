using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySCADA
{
    public partial class Motor_Faceplate : Form
    {
        Motor Parent;
        private bool isEdited = false;
        private bool isSliderEdited = false;
        List<Image> fanImages = new List<Image>();
        int fan = 0;

        public Motor_Faceplate(Motor parent)
        {
            InitializeComponent();
            Parent = parent;
            this.TopMost = true;
        }

        private void UpdateTimer_Tick_1(object sender, EventArgs e)
        {
            if (Parent == null) return;

            // 1. Cập nhật hiển thị giá trị
            if (isEdited == false)
            {
                lbSetSpeed.Text = Parent.SetSpeed.ToString();
            }

            if (isSliderEdited == false)
            {
                slider.Value = (int)Parent.SetSpeed;
            }

            label.Text = Parent.Speed.ToString();
            vbarSpeed.Height = (int)(201 - (Parent.Speed * 201 / 1000));

            if (Parent.Status)
            {
                if (fanImages.Count > 0)
                {
                    pbfan.BackgroundImage = fanImages[fan];
                    fan++;
                    if (fan >= fanImages.Count) fan = 0;
                }
                btStart.Enabled = false; 
                btStop.Enabled = true;   
            }
            else
            {
                if (fanImages.Count > 0)
                {
                    pbfan.BackgroundImage = fanImages[0];
                }
                fan = 0; 
                btStart.Enabled = true;   
                btStop.Enabled = false;  
            }

            if (fanImages.Count > 0)
            {
                pbfan.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void Motor_Faceplate_Load(object sender, EventArgs e)
        {
            this.Text = Parent.Name;
            lbSetSpeed.Text = Parent.SetSpeed.ToString();
            // Load ảnh
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    string imgPath = Path.Combine(Application.StartupPath, "images", $"fan_{i + 1}.png");
                    Image fanImg = Image.FromFile(imgPath);
                    fanImages.Add(fanImg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải ảnh: {ex.Message}\n" +
                   "Đảm bảo đã copy thư mục 'images' vào bin\\Debug");
            }

            if (Parent != null)
            {
                btStart.Enabled = !Parent.Status;
                btStop.Enabled = Parent.Status;
            }

            if (fanImages.Count > 0)
            {
                pbfan.BackgroundImage = fanImages[0];
                pbfan.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (Parent == null) return;
            try
            {
                    // Gửi cả hai lệnh
                    Parent.StartMotor("DBX0.0", true); // Gửi lệnh Start = true
                    Parent.StopMotor("DBX0.1", false); // Gửi lệnh Stop = false

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi lệnh Start: {ex.Message}");
            }
        }

        // NÚT STOP CHỈ GỌI LỆNH
        private void btStop_Click(object sender, EventArgs e)
        {
            if (Parent == null) return;
            try
            {
                    // Gửi cả hai lệnh
                    Parent.StopMotor("DBX0.1", true);   // Gửi lệnh Stop = true
                    Parent.StartMotor("DBX0.0", false); // Gửi lệnh Start = false
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi lệnh Stop: {ex.Message}");
            }
        }

        private void lbSetSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            // Chỉ gửi lệnh khi người dùng nhấn ENTER
            if (e.KeyCode == Keys.Enter)
            {

                float temp;
                bool ret = float.TryParse(lbSetSpeed.Text, out temp);
                if (ret && temp >=0 && temp <=1000)
                {
                        Parent.NewSpeed("DBD2",temp);
                }
                else
                {
                    MessageBox.Show("Giá trị nhập không hợp lệ. Vui lòng nhập số.");
                }

                isEdited = false;
            }
        }

        private void lbSetSpeed_DoubleClick(object sender, EventArgs e)
        {
            isEdited = true;
        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            float newSpeed = slider.Value;
            lbSetSpeed.Text = newSpeed.ToString();
            {
                Parent.NewSpeed("DBD2", newSpeed);
            }
        }

        private void slider_MouseDown(object sender, MouseEventArgs e)
        {
            isSliderEdited = true;
        }

        private void slider_MouseLeave(object sender, EventArgs e)
        {
            isSliderEdited = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}