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

        public Motor(string name,string plc, int address, int period, SCADA parent)
        {
            Name = name;
            PlcName = plc;
            Address = address;
            UpdateTimer = new Timer();
            UpdateTimer.Interval = Period;
            UpdateTimer.Elapsed += UpdateTimer_Elapsed;
            UpdateTimer.Enabled = true;
            Parent = parent;
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Status = Program.PLC_1.Motors[Address].Status;
            Speed = Program.PLC_1.Motors[Address].Speed;
            Position = Program.PLC_1.Motors[Address].Position;
            SetSpeed = Program.PLC_1.Motors[Address].SetSpeed;

            Console.WriteLine($"{Name} - Status: {Status}, Speed: {Speed}, Position: {Position}, SetSpeed: {SetSpeed}");
        }

        public void StartMotor(string addr, object value)
        {
            string startAddress = $"DB{Address+1}." + addr; //DB1.DBX0.0 
            Program.PLC_1.thePLC.Write(startAddress, value);
        }

        public void StopMotor(string addr, object value)
        {
            string startAddress = $"DB{Address + 1}." + addr; //DB1.DBX0.0
            Program.PLC_1.thePLC.Write(startAddress, value);
        }

        public void NewSpeed(string addr, object value)
        {
            string startAddress = $"DB{Address + 1}." + addr; //DB1.DBX0.0 
            Program.PLC_1.thePLC.Write(startAddress, value);
        }

    }
}
