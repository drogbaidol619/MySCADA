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
                    //object ob = thePLC.Read("DB1.DBW2");
                    //Post = Convert.ToUInt16(ob);
                    //Console.WriteLine($"Position: {Post}");

                    //ob = thePLC.Read("DB1.DBX0.2");
                    //Status = Convert.ToBoolean(ob);
                    //Console.WriteLine($"Status: {Status}");

                    //ob = thePLC.Read("DB1.DBD4");
                    //Speed = ((uint)ob).ConvertToFloat();
                    //Console.WriteLine($"Speed: {Speed}");

                    //thePLC.ReadClass(Motor_1, 1); //1 is DB number
                    //thePLC.ReadClass(Motor_2, 2);
                    //thePLC.ReadClass(Motor_3, 3);
                    //thePLC.ReadClass(Motor_4, 4);
                    //thePLC.ReadClass(Motor_5, 5);
                    //thePLC.ReadClass(Motor_6, 6);
                    //thePLC.ReadClass(Motor_7, 7);
                    //thePLC.ReadClass(Motor_8, 8);
                    //thePLC.ReadClass(Motor_9, 9);
                    //thePLC.ReadClass(Motor_10, 10);
                    //Console.WriteLine($"Motor 1 - Start: {Motor_1.Start}, Stop: {Motor_1.Stop}, SetSpeed: {Motor_1.SetSpeed}, Status: {Motor_1.Status}, Speed: {Motor_1.Speed}, Pos: {Motor_1.Position}");
                    //Console.WriteLine($"Motor 2 - Start: {Motor_2.Start}, Stop: {Motor_2.Stop}, SetSpeed: {Motor_2.SetSpeed}, Status: {Motor_2.Status}, Speed: {Motor_2.Speed}, Pos: {Motor_2.Position}");
                    //Console.WriteLine($"Motor 3 - Start: {Motor_3.Start}, Stop: {Motor_3.Stop}, SetSpeed: {Motor_3.SetSpeed}, Status: {Motor_3.Status}, Speed: {Motor_3.Speed}, Pos: {Motor_3.Position}");
                    //Console.WriteLine($"Motor 4 - Start: {Motor_4.Start}, Stop: {Motor_4.Stop}, SetSpeed: {Motor_4.SetSpeed}, Status: {Motor_4.Status}, Speed: {Motor_4.Speed}, Pos: {Motor_4.Position}");
                    //Console.WriteLine($"Motor 5 - Start: {Motor_5.Start}, Stop: {Motor_5.Stop}, SetSpeed: {Motor_5.SetSpeed}, Status: {Motor_5.Status}, Speed: {Motor_5.Speed}, Pos: {Motor_5.Position}");
                    //Console.WriteLine($"Motor 6 - Start: {Motor_6.Start}, Stop: {Motor_6.Stop}, SetSpeed: {Motor_6.SetSpeed}, Status: {Motor_6.Status}, Speed: {Motor_6.Speed}, Pos: {Motor_6.Position}");
                    //Console.WriteLine($"Motor 7 - Start: {Motor_7.Start}, Stop: {Motor_7.Stop}, SetSpeed: {Motor_7.SetSpeed}, Status: {Motor_7.Status}, Speed: {Motor_7.Speed}, Pos: {Motor_7.Position}");
                    //Console.WriteLine($"Motor 8 - Start: {Motor_8.Start}, Stop: {Motor_8.Stop}, SetSpeed: {Motor_8.SetSpeed}, Status: {Motor_8.Status}, Speed: {Motor_8.Speed}, Pos: {Motor_8.Position}");
                    //Console.WriteLine($"Motor 9 - Start: {Motor_9.Start}, Stop: {Motor_9.Stop}, SetSpeed: {Motor_9.SetSpeed}, Status: {Motor_9.Status}, Speed: {Motor_9.Speed}, Pos: {Motor_9.Position}");
                    //Console.WriteLine($"Motor 10 - Start: {Motor_10.Start}, Stop: {Motor_10.Stop}, SetSpeed: {Motor_10.SetSpeed}, Status: {Motor_10.Status}, Speed: {Motor_10.Speed}, Pos: {Motor_10.Position}");



                    for(int i=0; i<Motors.Count; i++)
                    {
                        lock (Semaphore)
                        thePLC.ReadClass(Motors[i], i + 1);
                        Console.WriteLine($"Motor {i + 1} - Start: {Motors[i].Start}, Stop: {Motors[i].Stop}, SetSpeed: {Motors[i].SetSpeed}, Status: {Motors[i].Status}, Speed: {Motors[i].Speed}, Pos: {Motors[i].Position}");
                    }

                    //Console.Clear();    

                    //for (int i=0; i<Motors.Count; i++)
                    //{
                    //    Console.WriteLine($" Motor{i+1} , " +
                    //        $"Status: {Motors[i].Status}, " +
                    //        $"Speed: {Motors[i].Speed}, " +
                    //        $"SetSpeed: {Motors[i].SetSpeed}, " +
                    //        $"Pos: {Motors[i].Position}");
                    //}

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
