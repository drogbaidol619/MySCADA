using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MySCADA
{
    public partial class FlowMeter_Faceplate : Form
    {
        // Biến chứa đối tượng Logic (Dữ liệu)
        FlowMeter Parent;
        public FlowMeter_Faceplate(FlowMeter parent)
        {
            InitializeComponent();
            Parent = parent;
            this.TopMost = true; // Luôn nổi lên trên
        }

        private void FlowMeter_Faceplate_Load(object sender, EventArgs e)
        {
            this.Text = Parent.Name;
        }

        // Sự kiện Tick của Timer 
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (Parent == null) return;
            // 1. Điện áp (V)
            if (V != null)
                V.Text = Parent.Voltage.ToString("0.0") + " V";
            if (Vab != null)
                Vab.Text = Parent.Vab.ToString("0.0") + " V";
            if (Vbc != null)
                Vbc.Text = Parent.Vbc.ToString("0.0") + " V";
            if (Vca != null)
                Vca.Text = Parent.Vca.ToString("0.0") + " V";

            // 2. Dòng điện (A)
            if (I != null)
                I.Text = Parent.Current.ToString("0.00") + " A";
            if (Ia != null)
                Ia.Text = Parent.Ia.ToString("0.00") + " A";
            if (Ib != null)
                Ib.Text = Parent.Ib.ToString("0.00") + " A";
            if (Ic != null)
                Ic.Text = Parent.Ic.ToString("0.00") + " A";

            // 3. Công suất P (kW)
            if (P != null)
                P.Text = Parent.P.ToString("0.00") + " kW";

            // 4. Tổng năng lượng 
            if (Q != null)
                Q.Text = Parent.Q.ToString("0.0") + " kWh";

            // 5. PF
            if (PF != null)
                PF.Text = Parent.PF.ToString("0.0") + " kWh";

            // 6. E
            if (E != null)
                E.Text = Parent.E.ToString("0.0") + " kWh";
        }



    }
}