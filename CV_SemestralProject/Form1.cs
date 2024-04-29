using CV_SemestralProject.Models;
using System.Diagnostics;
using Semaphore = CV_SemestralProject.Models.Semaphore;

namespace CV_SemestralProject
{
    public partial class Form1 : Form
    {
        private CarWasher washer;
        public int InGateOrigPos { get; set; }
        public int OutGateOrigPos { get; set; }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            washer = new CarWasher(10000);
            InGateOrigPos = panel1.Location.X;
            OutGateOrigPos = panel2.Location.X;
            LoadEvents();


        }
        private void LoadEvents()
        {
            //Washer Events
            washer.OnWasherStateChange += Washer_OnWasherStateChange;
            washer.OnTextStateChange += Washer_OnTextStateChange;
            //Gate Events
            washer.InGateState.OnOpeningStateChange += Washer_OnInOpeningStateChange;
            washer.InGateState.OnSemaphoreStateChange += Washer_OnInSemaphoreStateChange;
            washer.OutGateState.OnOpeningStateChange += Washer_OnOutOpeningStateChange;
            washer.OutGateState.OnSemaphoreStateChange += Washer_OnOutSemaphoreStateChange;
        }
        private void UnloadEvents()
        {
            //Washer Events
            washer.OnWasherStateChange -= Washer_OnWasherStateChange;
            washer.OnTextStateChange -= Washer_OnTextStateChange;
            //Gate Events
            washer.InGateState.OnOpeningStateChange -= Washer_OnInOpeningStateChange;
            washer.InGateState.OnSemaphoreStateChange -= Washer_OnInSemaphoreStateChange;
            washer.OutGateState.OnOpeningStateChange -= Washer_OnOutOpeningStateChange;
            washer.OutGateState.OnSemaphoreStateChange -= Washer_OnOutSemaphoreStateChange;
        }
        private void LoadTimer()
        {
            timer1.Start();
            timer1.Enabled = true;
        }
        private void UnloadTimer()
        {
            timer1.Stop();
            timer1.Enabled = false;
        }
        private void Washer_OnOutOpeningStateChange(object sender, int openingShift)
        {
            this.Invoke(new Action(() =>
            {
                panel2.Location = new Point(OutGateOrigPos + openingShift, panel2.Location.Y);
            }));
        }
        private void Washer_OnOutSemaphoreStateChange(object sender, Semaphore semaphore)
        {
            this.Invoke(new Action(() =>
            {
                label2.BackColor = semaphore == Semaphore.On ? Color.Green : Color.Red;
            }));
        }

        private void Washer_OnInOpeningStateChange(object sender, int openingShift)
        {
            this.Invoke(new Action(() =>
            {
                panel1.Location = new Point(InGateOrigPos + openingShift, panel1.Location.Y);
            }));
        }
        private void Washer_OnInSemaphoreStateChange(object sender, Semaphore semaphore)
        {
            this.Invoke(new Action(() =>
            {
                label1.BackColor = semaphore == Semaphore.On ? Color.Green : Color.Red;
            }));
        }

        private void Washer_OnWasherStateChange(object sender, double stateLitres, double washPercent)
        {
            //Tohle nevím, jak vyøešit
            try
            {
                this.Invoke(new Action(() =>
                {
                    panel3.Height = (int)(panel4.Height * (100 - washPercent) / 100);
                }));
            }
            catch (ThreadInterruptedException e)
            {
                Debug.WriteLine("Thread Interrupted in Invoke!");
                Application.Exit();
                return;
            }

        }

        private void Washer_OnTextStateChange(object sender, string text)
        {
            this.Invoke(new Action(() =>
            {
                label3.Text = text;
            }));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //TODO: udìlat Timer události na tlaèítko a menu
            washer.States = MachineStates.VehicleEnter;
            button1.Visible = false;
            button2.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            washer.States = MachineStates.Washing;
            button2.Visible = false;
            button3.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (washer.States == MachineStates.Washing)
            {
                return;
            }
            washer.States = MachineStates.VehicleExit;
            button3.Visible = false;
            button1.Visible = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            washer?.Dispose();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new FormSettings();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                // zpracovat hodnotu formulari
                if (form.IsEvent)
                {
                    UnloadTimer();
                    LoadEvents();
                }
                else
                {
                    UnloadEvents();
                    LoadTimer();
                }
            }
        }
    }
}
