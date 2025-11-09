using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Timers;

namespace MySCADA
{
    public class PLC
    {
        public string Name;
        public string IP;
        public Plc thePLC;
        public ushort Post;
        public bool Status;
        public float Speed;
        public object Semaphore;

        Timer UpdateTimer;

        public List<Motor_Data> Motors = new List<Motor_Data>();

        public PLC(string name, string ip)
        {
            for(int i=0; i<10; i++)
            {
                Motor_Data data = new Motor_Data();
                Motors.Add(data);
            }

            Name = name;
            IP = ip;
            thePLC = new Plc(CpuType.S71500, IP, 0, 1);
            try
            {
                thePLC.Open();
                Console.WriteLine($"Connected to PLC {Name} at {IP}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to PLC {Name} at {IP}: {ex.Message}");
            }

            Semaphore = new object();

            UpdateTimer = new Timer(1000);
            UpdateTimer.Interval = 1000;
            UpdateTimer.Elapsed += UpdateTimer_Elapsed;
            UpdateTimer.Enabled = true;
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(thePLC.IsConnected)
            {
                try
                {
                    for(int i=0; i<Motors.Count; i++)
                    {
                        lock (Semaphore)
                        thePLC.ReadClass(Motors[i], i + 1);
                        Console.WriteLine($"Motor {i + 1} - Start: {Motors[i].Start}, Stop: {Motors[i].Stop}, SetSpeed: {Motors[i].SetSpeed}, Status: {Motors[i].Status}, Speed: {Motors[i].Speed}, Pos: {Motors[i].Position}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading from PLC {Name}: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"PLC {Name} is not connected.");
            }

            
            
        }

    }

    public class Motor_Data
    {
        // Các thuộc tính dùng để đọc/ghi dữ liệu từ PLC
        public bool Start { get; set; }
        public bool Stop { get; set; }
        public float SetSpeed { get; set; }
        public bool Status { get; set; }
        public float Speed { get; set; }
        public ushort Position { get; set; }
    }
}
