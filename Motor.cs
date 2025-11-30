using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MySCADA
{
    // LỚP ALARM (Giữ nguyên)
    public class AlarmEntry
    {
        public string AlarmText { get; set; }
        public DateTime AlarmTime { get; set; }
        public string AlarmType{ get; set; }
    }

    public class Motor
    {
        public string Name;
        public int Address;
        public string PlcName;

        // Các biến trạng thái
        public bool Stop;
        public bool Start;
        public double SetSpeed;
        public bool Status;
        public double Speed;
        public int Position;
        public int Period = 1000;

        Timer UpdateTimer;

        // DANH SÁCH ALARM (Giữ nguyên)
        public List<AlarmEntry> Alarms { get; private set; }
        private const int MaxAlarmEntries = 200;

        // --- BIẾN "CỜ" MỚI ĐỂ CHỐNG LŨ ALARM ---
        private bool isHighSpeedAlarmActive = false;
        private bool isLowSpeedAlarmActive = false;

        public Motor(string name, int address, string plcName, int period)
        {
            Name = name;
            Address = address;
            PlcName = plcName;
            Period = period;

            Alarms = new List<AlarmEntry>();

            UpdateTimer = new Timer();
            UpdateTimer.Interval = Period;
            UpdateTimer.Elapsed += UpdateTimer_Elapsed;
            UpdateTimer.Enabled = true;
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                PLC plc = Program.Root.FindPLC(PlcName);
                if (plc != null)
                {
                    Status = plc.Motors[Address].Status;
                    Speed = plc.Motors[Address].Speed;
                    Position = plc.Motors[Address].Position;
                    SetSpeed = plc.Motors[Address].SetSpeed;
                }

                // --- LOGIC ALARM  ---

                if (this.Speed > 800 )
                {
                    if (isHighSpeedAlarmActive == false)
                    {
                        isHighSpeedAlarmActive = true;
                        isLowSpeedAlarmActive = false;
                        Alarms.Add(new AlarmEntry
                        {
                            AlarmText = $"High Speed Alarm: {Math.Round(this.Speed, 0)}",
                            AlarmTime = DateTime.Now,
                            AlarmType= "High High"
                        });

                        // 4. Giới hạn danh sách 
                        while (Alarms.Count > MaxAlarmEntries)
                        {
                            Alarms.RemoveAt(0);
                        }
                    }
                } 
                else if ( this.Speed <300 && this.Status == true)
                {
                    if(isLowSpeedAlarmActive == false)
                    {
                        isLowSpeedAlarmActive = true;
                        isHighSpeedAlarmActive = false;
                        Alarms.Add(new AlarmEntry
                        {
                            AlarmText = $"Low Speed Alarm: {Math.Round(this.Speed, 0)}",
                            AlarmTime = DateTime.Now,
                            AlarmType= "Low Low"
                        });
                        while (Alarms.Count > MaxAlarmEntries)
                        {
                            Alarms.RemoveAt(0);
                        }
                    }
                }

                else // (Speed <= 800 >=300)
                {
                    isHighSpeedAlarmActive = false;
                    isLowSpeedAlarmActive = false;
                }
                // --- KẾT THÚC LOGIC ALARM ---
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi timer Motor {Name}: {ex.Message}");
            }
        }

        // --- CÁC HÀM GHI (WRITE)---

        public void StartMotor(string addr, object value)
        {
            try
            {
                PLC plc = Program.Root.FindPLC(PlcName);
                if (plc == null) { throw new Exception($"Không tìm thấy PLC: {PlcName}"); }
                lock (plc.Semaphore)
                {
                    string startAddress = $"DB{Address + 1}." + addr;
                    plc.thePLC.Write(startAddress, value);
                }
            }
            catch (Exception ex) { throw new Exception($"Lỗi StartMotor: {ex.Message}"); }
        }

        public void StopMotor(string addr, object value)
        {
            try
            {
                PLC plc = Program.Root.FindPLC(PlcName);
                if (plc == null) { throw new Exception($"Không tìm thấy PLC: {PlcName}"); }
                lock (plc.Semaphore)
                {
                    string startAddress = $"DB{Address + 1}." + addr;
                    plc.thePLC.Write(startAddress, value);
                }
            }
            catch (Exception ex) { throw new Exception($"Lỗi StopMotor: {ex.Message}"); }
        }

        public void NewSpeed(string addr, object value)
        {
            try
            {
                PLC plc = Program.Root.FindPLC(PlcName);
                if (plc == null) { throw new Exception($"Không tìm thấy PLC: {PlcName}"); }
                lock (plc.Semaphore)
                {
                    string startAddress = $"DB{Address + 1}." + addr;
                    plc.thePLC.Write(startAddress, (float)value);
                }
            }
            catch (Exception ex) { throw new Exception($"Lỗi NewSpeed: {ex.Message}"); }
        }
    }
}