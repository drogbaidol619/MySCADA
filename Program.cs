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

        public static PLC PLC_1;
        public static List<Motor> Motors = new List<Motor>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PLC_1 = new PLC("PLC_1", "113.161.79.146"); //113.161.79.146  169.254.25.142

            Root.AddPLC(PLC_1);

            Motor motor = new Motor("Motor_1","PLC_1", 0, 500, Root);
            Root.AddMotor(motor);
            motor = new Motor("Motor_2", "PLC_1", 1, 500, Root);
            Root.AddMotor(motor);
            motor = new Motor("Motor_3", "PLC_1", 2, 500, Root);
            Root.AddMotor(motor);


            //for (int i=0; i<10; i++)
            //{
            //    Motor motor = new Motor($"Motor_{i+1}", i, 500);
            //    Motors.Add(motor);
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
