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

// 1. THÊM CÁC THƯ VIỆN CỦA LIVECHARTS
using LiveCharts;
using LiveCharts.Wpf; // Cần thêm tham chiếu (reference) 'WindowsBase'
using LiveCharts.Configurations;

namespace MySCADA
{
    // 1. TẠO MODEL DỮ LIỆU MỚI
    // (Class này chứa cả Thời gian và Tốc độ)
    public class TimeSpeedModel
    {
        public DateTime Time { get; set; }
        public double Speed { get; set; }
    }

    public partial class Motor_Faceplate : Form
    {
        Motor Parent;
        private bool isEdited = false;
        private bool isSliderEdited = false;
        List<Image> fanImages = new List<Image>();
        int fan = 0;

        // 2. THÊM GIỚI HẠN ĐIỂM (ĐỂ TRÁNH CRASH)
        // (Hiển thị 100 điểm, tương đương 10 giây nếu Timer 100ms)
        private const int MaxTrendPoints = 100;

        // --- BIẾN CHO LIVECHARTS ---
        // 3. SỬA KIỂU DỮ LIỆU CỦA DANH SÁCH
        public ChartValues<TimeSpeedModel> SpeedValues { get; set; }
        private CartesianChart myChart;

        public Motor_Faceplate(Motor parent)
        {
            InitializeComponent();
            Parent = parent;
            this.TopMost = true;

            // 4. SỬA KHỞI TẠO DANH SÁCH
            SpeedValues = new ChartValues<TimeSpeedModel>();
        }

        // -----------------------------------------------------------------
        // HÀM TIMER (Cập nhật cả Tab 1 và Tab 2)
        // -----------------------------------------------------------------
        private void UpdateTimer_Tick_1(object sender, EventArgs e)
        {
            if (Parent == null) return;

            // --- 1. CẬP NHẬT TAB 1 (Điều khiển) ---
            // (Code này giữ nguyên, không thay đổi)
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


            // --- 2. CẬP NHẬT TAB 2 (Biểu đồ) ---

            // 5. THÊM DỮ LIỆU MỚI (CẢ THỜI GIAN VÀ TỐC ĐỘ)
            SpeedValues.Add(new TimeSpeedModel
            {
                Time = DateTime.Now,
                Speed = Parent.Speed
            });

            // 6. THÊM LẠI VÒNG LẶP XÓA ĐIỂM CŨ (RẤT QUAN TRỌNG)
            while (SpeedValues.Count > MaxTrendPoints)
            {
                SpeedValues.RemoveAt(0);
            }
        }

        // -----------------------------------------------------------------
        // HÀM LOAD (Chỉ khởi tạo Tab 1)
        // -----------------------------------------------------------------
        private void Motor_Faceplate_Load(object sender, EventArgs e)
        {
            // (Code này giữ nguyên, không thay đổi)
            this.Text = Parent.Name;
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
        }

        // -----------------------------------------------------------------
        // HÀM SHOWN (Chỉ khởi tạo Tab 2)
        // -----------------------------------------------------------------
        private void Motor_Faceplate_Shown(object sender, EventArgs e)
        {
            // --- KHỞI TẠO TAB 2 (BIỂU ĐỒ) ---
            try
            {
                // 7. ĐỊNH NGHĨA BỘ ÁNH XẠ (MAPPER)
                // Báo cho LiveCharts biết: Trục X dùng 'Time', Trục Y dùng 'Speed'
                var mapper = Mappers.Xy<TimeSpeedModel>()
                    .X(model => model.Time.Ticks) // Ánh xạ X vào Thời gian (dưới dạng Ticks)
                    .Y(model => model.Speed);     // Ánh xạ Y vào Tốc độ

                // Lưu bộ ánh xạ này
                Charting.For<TimeSpeedModel>(mapper);

                // 8. Lấy biểu đồ thật
                myChart = this.speedTrend.Child as CartesianChart;
                if (myChart == null)
                {
                    throw new Exception("Không tìm thấy control 'CartesianChart' bên trong 'speedTrend'.");
                }

                // 9. Cấu hình Series
                myChart.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Speed",
                        Values = SpeedValues, // Ràng buộc với danh sách
                        PointGeometry = null
                    }
                };

                // 10. Cấu hình Trục Y (Không đổi)
                myChart.AxisY.Add(new Axis
                {
                    Title = "Speed",
                    MinValue = 0,
                    MaxValue = 1000
                });

                // 11. SỬA CẤU HÌNH TRỤC X (HIỂN THỊ THỜI GIAN)
                myChart.AxisX.Add(new Axis
                {
                    Title = "Time",
                    ShowLabels = true,
                    // Định dạng nhãn: Lấy Ticks (value) chuyển về DateTime
                    LabelFormatter = value => new DateTime((long)value).ToString("HH:mm:ss")
                });

                myChart.LegendLocation = LegendLocation.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo Biểu đồ (Tab 2): {ex.Message}\n" +
                    "Tab 1 vẫn sẽ hoạt động.");
            }
        }

        // -----------------------------------------------------------------
        // CÁC HÀM ĐIỀU KHIỂN (Không thay đổi)
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