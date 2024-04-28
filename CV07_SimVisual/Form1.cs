using Sim1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cv7
{
    public partial class Form1 : Form
    {
        TankValves tank;
        TankValves tank2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tank = new TankValves(15000);
            tank.OnInletValveStateChange += Tank_OnInletValveStateChange;
            tank.OnOutletValveStateChange += Tank_OnOutletValveStateChange;
            tank.OnTankStateChange += Tank_OnTankStateChange;

            tank2 = new TankValves(6000);
        }

        void UpdateState(object sender, double stateLitres, double statePercent)
        {
            panel4.Height = (int)(panel3.Height * (100 - statePercent) / 100);
        }

        private void Tank_OnTankStateChange(object sender, double stateLitres, double statePercent)
        {
            //dva typy invoku
            this.Invoke(new TankValves.ChangedTankStateHandler(UpdateState), 
                sender, stateLitres, statePercent);
            
            this.Invoke(new Action(() => {
                panel4.Height = (int)(panel3.Height * (100 - statePercent) / 100);
            }));
        }

        private void Tank_OnOutletValveStateChange(object sender, ValveState valveState)
        {
            panel2.BackColor = valveState == ValveState.On ? Color.Lime : Color.Red;
        }

        private void Tank_OnInletValveStateChange(object sender, ValveState valveState)
        {
            panel1.BackColor = valveState == ValveState.On ? Color.Lime : Color.Red;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            tank?.Dispose();
            tank2?.Dispose();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            panel6.Height = (int)(panel5.Height * (1 - tank2.StateLitres/tank2.CapacityLitres));
            panel8.BackColor = tank2.InletValveState == ValveState.On ? Color.Lime : Color.Red;
            panel7.BackColor = tank2.OutletValveState == ValveState.On ? Color.Lime : Color.Red;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
