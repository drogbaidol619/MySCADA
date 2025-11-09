using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MySCADA
{ 
    public class Motor
    {
        public string Name;
        public int Address;
        public string PlcName;

        public bool Stop;
        public bool Start;
        public double SetSpeed;
        public bool Status;
        public double Speed;
        public int Position;
        public int Period = 1000; // milliseconds

        Timer UpdateTimer;

        SCADA Parent;

        public Motor(string name,string plc, int address, int period)
        {
            Name = name;
            PlcName = plc;
            Address = address;
            UpdateTimer = new Timer();
            UpdateTimer.Interval = Period;
            UpdateTimer.Elapsed += UpdateTimer_Elapsed;
            UpdateTimer.Enabled = true;
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PLC plc = Program.Root.FindPLC(PlcName);
            if (plc != null)
            {
                Status = plc.Motors[Address].Status;
                Speed = plc.Motors[Address].Speed;
                Position = plc.Motors[Address].Position;
                SetSpeed = plc.Motors[Address].SetSpeed;
            }

            //Console.WriteLine($"{Name} - Status: {Status}, Speed: {Speed}, Position: {Position}, SetSpeed: {SetSpeed}");
        }

        public void StartMotor(string addr, object value)
        {
                string startAddress = $"DB{Address + 1}." + addr; //DB1.DBX0.0 
                PLC plc = Program.Root.FindPLC(PlcName);
                if (plc != null)
                {
                    lock (plc.Semaphore)
                    { plc.thePLC.Write(startAddress, value); }
                }
        }

        public void StopMotor(string addr, object value)
        {
            string startAddress = $"DB{Address + 1}." + addr; //DB1.DBX0.0
            PLC plc = Program.Root.FindPLC(PlcName);
            if (plc != null)
            {
                lock (plc.Semaphore)
                { plc.thePLC.Write(startAddress, value); }
            }
        }

        public void NewSpeed(string addr, object value)
        {
            string startAddress = $"DB{Address + 1}." + addr; //DB1.DBX0.0 
            PLC plc = Program.Root.FindPLC(PlcName);
            if (plc != null)
            {
                lock (plc.Semaphore)
                { plc.thePLC.Write(startAddress, value); }
            }
        }

    }
}
