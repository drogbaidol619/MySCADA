using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MySCADA
{
    public class SCADA
    {
        List<PLC> PLCs = new List<PLC>();
        public List<Motor> Motors = new List<Motor>();
        
        public SCADA()
        {
        }

        public void AddPLC(PLC plc)
        {
           PLCs.Add(plc);
        }

        public void AddMotor(Motor motor)
        {
            Motors.Add(motor);
        }

        public PLC FindPLC(string name)
        {
            foreach (PLC plc in PLCs)
            {
                if (plc.Name == name)
                {
                    return plc;
                }
            }
            return null;
        }

        public Motor FindMotor(string name)
        {
            foreach (Motor m in Motors)
            {
                if (m.Name == name)
                {
                    return m;
                }
            }
            return null;
        }

    }
}
