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

        ////public static PLC PLC_1;
        ////public static List<Motor> Motors = new List<Motor>();
        [STAThread]
        static void Main()
        {
            PLC plc = new PLC("PLC_1", "113.161.79.146"); //113.161.79.146  169.254.25.142

            Root.AddPLC(plc);

            for (int i = 0; i < 10; i++)
            {
                Motor motor = new Motor($"Motor_{i + 1}","PLC_1",i, 500);
                Root.AddMotor(motor);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
