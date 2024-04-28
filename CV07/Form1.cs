using Sim1;

namespace CV07
{
    public partial class Form1 : Form
    {
        TankValves tank;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tank = new TankValves(15000);

            tank.OnInletValveStateChange += Tank_OnInletValveStateChange;
            tank.OnOutletValveStateChange += Tank_OnOutletValveStateChange;
            //tank.OnTankStateChange += Tank_OnTankStateChange;
        }




        //pøístup na základì událostí
        //ètení primo tìch atributù pomocí èasovaèe
        //pøidat Timer
        private void Tank_OnInletValveStateChange(object sender, ValveState valveState)
        {
            //UpdateLabelText(valveState.ToString(), label1);
            //label se posune do jiného vlákna a tam se provede
            this.Invoke(new Action(() => { label1.Text = valveState.ToString(); }));
            ChangePumpColors(valveState, label1);
        }

        private void Tank_OnOutletValveStateChange(object sender, ValveState valveState)
        {
            UpdateLabelText(valveState.ToString(), label2);
            ChangePumpColors(valveState, label2);
            

        }

        private void Tank_OnTankStateChange(object sender, double stateLitres, double statePercent)
        {
            this.Invoke(new Action(() => label1.Text = stateLitres.ToString()));
            
        }
        private void ChangePumpColors(ValveState valveState, Label label)
        {
            switch (valveState)
            {
                case ValveState.On:
                    label.BackColor = Color.Green; break;
                case ValveState.Off:
                    label.BackColor = Color.Red; break;
                default:
                    label.BackColor = Color.Orange; break;
            }
        }
        private void UpdateLabelText(string newText, Label label)
        {
            if (label.InvokeRequired)
            {
                label.Invoke((MethodInvoker)(() => label.Text = newText));
            }
            else
            {
                label.Text = newText;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            tank?.Dispose();
        }

        
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
