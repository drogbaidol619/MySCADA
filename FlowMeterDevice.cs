using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;

namespace MySCADA
{
    public class FlowMeter
    {
        public int UnitId { get; set; } // Địa chỉ Modbus (Slave ID)
        public string Name { get; set; }

        // --- Dữ liệu nhận về ---
        public float Voltage { get; set; }
        public float Current { get; set; }
        public float Vab { get; set; }
        public float Vbc { get; set; }
        public float Vca { get; set; }
        public float Ia { get; set; }
        public float Ib { get; set; }
        public float Ic { get; set; }
        public float P { get; set; }
        public float Q { get; set; }
        public float PF { get; set; }
        public float E { get; set; }

        public FlowMeter(string name, int unitId)
        {
            Name = name;
            UnitId = unitId;
        }
    }
}
