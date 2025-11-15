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

// 1. THÊM THƯ VIỆN CHART (BẮT BUỘC)
using System.Windows.Forms.DataVisualization.Charting;

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

        // -----------------------------------------------------------------
        // HÀM TIMER (Cập nhật cả Tab 1 và Tab 2)
        // -----------------------------------------------------------------
        private void UpdateTimer_Tick_1(object sender, EventArgs e)
        {
            if (Parent == null) return;

            // --- 1. CẬP NHẬT TAB 1 ---
            if (isEdited == false) { lbSetSpeed.Text = Parent.SetSpeed.ToString(); }
            if (isSliderEdited == false) { slider.Value = (int)Parent.SetSpeed; }
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
                if (fanImages.Count > 0) { pbfan.BackgroundImage = fanImages[0]; }
                fan = 0;
                btStart.Enabled = true;
                btStop.Enabled = false;
            }
            if (fanImages.Count > 0) { pbfan.BackgroundImageLayout = ImageLayout.Stretch; }

            // --- 2. CẬP NHẬT TAB 2  ---
            try
            {
                DateTime currentTime = DateTime.Now;
                double currentTimeValue = currentTime.ToOADate();

                // thêm điểm mới
                chartSpeed.Series["TrendLine"].Points.AddXY(currentTimeValue, Parent.Speed);

                // Cập nhật trục X để tự động mở rộng (sẽ bị "nén" lại)
                if (chartSpeed.Series["TrendLine"].Points.Count > 1)
                {
                    chartSpeed.ChartAreas[0].AxisX.Maximum = currentTimeValue;
                }
            }
            catch (Exception ex) { /* Bỏ qua lỗi nhỏ nếu có */ }
        }


        private void Motor_Faceplate_Load(object sender, EventArgs e)
        {
            this.Text = Parent.Name;

            // --- KHỞI TẠO TAB 1---
            lbSetSpeed.Text = Parent.SetSpeed.ToString();
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
                MessageBox.Show($"Lỗi tải ảnh (Tab 1): {ex.Message}\n" +
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


            // --- KHỞI TẠO TAB 2  ---

            // 1. Xóa cấu hình mặc định
            chartSpeed.Series.Clear();
            chartSpeed.ChartAreas.Clear();

            // 2. Tạo vùng hiển thị (ChartArea)
            ChartArea area = new ChartArea("MainArea");
            area.AxisX.Title = "Thời gian (s)";
            area.AxisY.Title = "Giá trị Tốc độ";
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 1000;
            chartSpeed.ChartAreas.Add(area);

            // 3. Cấu hình trục X
            chartSpeed.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";

            // 4. Tạo Series (Đường kẻ)
            Series series = new Series("TrendLine");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;
            series.Color = System.Drawing.Color.Blue;

            // 5. Gán ValueType cho SERIES
            series.XValueType = ChartValueType.Time;
            series.YValueType = ChartValueType.Double;

            series.ChartArea = "MainArea";

            // 6. Thêm Series vào Chart
            chartSpeed.Series.Add(series);

            // 7. Tắt chú thích (Legend)
            chartSpeed.Legends[0].Enabled = false;
        }

        // -----------------------------------------------------------------
        // CÁC HÀM ĐIỀU KHIỂN
        // -----------------------------------------------------------------

        private void btStart_Click(object sender, EventArgs e)
        {
            if (Parent == null) return;
            try
            {
                Parent.StartMotor("DBX0.0", true);
                Parent.StopMotor("DBX0.1", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi lệnh Start: {ex.Message}");
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            if (Parent == null) return;
            try
            {
                Parent.StopMotor("DBX0.1", true);
                Parent.StartMotor("DBX0.0", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi lệnh Stop: {ex.Message}");
            }
        }

        private void lbSetSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                float temp;
                bool ret = float.TryParse(lbSetSpeed.Text, out temp);
                if (ret && temp >= 0 && temp <= 1000)
                {
                    Parent.NewSpeed("DBD2", temp);
                }
                else
                {
                    MessageBox.Show("Giá trị nhập không hợp lệ. Vui lòng nhập số.");
                }
                isEdited = false;
            }
        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            float newSpeed = slider.Value;
            lbSetSpeed.Text = newSpeed.ToString();
            Parent.NewSpeed("DBD2", newSpeed);
        }

        private void lbSetSpeed_DoubleClick(object sender, EventArgs e)
        {
            isEdited = true;
        }

        private void slider_MouseDown(object sender, MouseEventArgs e)
        {
            isSliderEdited = true;
        }

        private void slider_MouseLeave(object sender, EventArgs e)
        {
            isSliderEdited = false;
        }
    }
}