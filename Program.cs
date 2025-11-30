using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySCADA
{
    internal static class Program
    {
        public static SCADA Root = new SCADA();

        public static FlowMeterSystem FlowSys;

        ////public static PLC PLC_1;
        ////public static List<Motor> Motors = new List<Motor>();
        [STAThread]
        static void Main()
        {
            PLC plc = new PLC("PLC_1", "192.168.0.1"); //113.161.79.146  169.254.25.142 
            Root.AddPLC(plc);
            plc =  new PLC("PLC_2", "192.168.0.2");
            Root.AddPLC(plc);

            for (int i = 0; i < 5; i++)
            {
                Motor motor = new Motor($"Motor_{i + 1}", i, "PLC_1" , 500);
                Root.AddMotor(motor);
            }

            for (int i = 0; i < 5; i++)
            {
                Motor motor = new Motor($"Motor_{i + 5+  1}", i+5 , "PLC_2", 500);
                Root.AddMotor(motor);
            }

            try
            {
                FlowSys = new FlowMeterSystem("192.168.0.10"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo FlowMeterSystem: " + ex.Message);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
