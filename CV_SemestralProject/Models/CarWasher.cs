using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CV_SemestralProject.Models
{
    public class CarWasher : IDisposable
    {
        public delegate void ChangedWasherStateHandler(object sender, double stateLitres, double washPercent);
        public delegate void ChangedTextStateHandler(object sender, string text);
        private Gate _inGateState;
        private Gate _outGateState;
        private string _text;
        private double _stateLitres;
        private Thread _thread = new Thread(StartThread);
        public MachineStates States { get; set; }
        private bool Running { get; set; }
        private bool IsWashing { get; set;}
        
        public Gate InGateState { get; set; }
        public Gate OutGateState { get; set; }
        public int CapacityLitres { get; private set; }
        public int InletValveFlowRate { get; private set; }
        public int OutletValveFlowRate { get; private set; }
        private int WorkingCycleMs { get; set; }
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                bool flag = value != _text;
                _text = value;
                if (flag)
                {
                    this.OnTextStateChange?.Invoke(this, _text);
                }
            }
        }
        public double StateLitres
        {
            get
            {
                return _stateLitres;
            }
            private set
            {
                bool flag = value != _stateLitres;
                _stateLitres = value;
                if (flag)
                {
                    this.OnWasherStateChange?.Invoke(this, _stateLitres, 100.0 * _stateLitres / (double)CapacityLitres);
                }
            }
        }

        public event ChangedTextStateHandler OnTextStateChange;
        public event ChangedWasherStateHandler OnWasherStateChange;

        private static void StartThread(object obj)
        {
            CarWasher carWasher = (CarWasher)obj;
            while (carWasher.Running)
            {
                switch (carWasher.States)
                {
                    case MachineStates.VehicleEnter:
                        carWasher.InGateState.OpenGate();
                        carWasher.InGateState.Semaphore = Semaphore.On;
                        carWasher.OutGateState.Semaphore = Semaphore.On;
                        carWasher.States = MachineStates.AwaitingResponse;
                        carWasher.Text = "Vehicle Detected!";
                        break;
                    case MachineStates.Washing:
                        carWasher.InGateState.Semaphore = Semaphore.Off;
                        carWasher.OutGateState.Semaphore = Semaphore.Off;
                        carWasher.InGateState.CloseGate();
                        //washing logic
                        carWasher.IsWashing = true;
                        carWasher.Text = "Washing…";
                        Stopwatch stopwatch = Stopwatch.StartNew();
                        while (carWasher.IsWashing)
                        {
                            Stopwatch stopwatch2 = Stopwatch.StartNew();
                            stopwatch.Stop();
                            double totalSeconds = stopwatch.Elapsed.TotalSeconds;
                            if (totalSeconds > 0.0)
                            {
                                double num = carWasher.InletValveFlowRate * totalSeconds;
                                carWasher.StateLitres += num;
                                if (carWasher.StateLitres >= 1 * (double)carWasher.CapacityLitres)
                                {
                                    carWasher.IsWashing = false;
                                    carWasher.StateLitres = 0;
                                }
                            }
                            stopwatch.Restart();
                            stopwatch2.Stop();
                            int num3 = carWasher.WorkingCycleMs - (int)stopwatch2.ElapsedMilliseconds;
                            num3 = ((num3 < 1) ? 1 : num3);
                            try
                            {
                                Thread.Sleep(num3);
                            }
                            catch (ThreadInterruptedException)
                            {
                                carWasher.Running = false;
                            }
                        }
                        carWasher.Text = "Done!";
                        carWasher.OutGateState.OpenGate();
                        carWasher.OutGateState.Semaphore = Semaphore.On;
                        carWasher.States = MachineStates.AwaitingResponse;
                        break;
                    case MachineStates.VehicleExit:
                        carWasher.Text = "Empty";
                        carWasher.OutGateState.CloseGate();
                        carWasher.OutGateState.Semaphore = Semaphore.Off;
                        carWasher.States = MachineStates.AwaitingResponse;
                        break;
                }
                try
                {
                    Thread.Sleep(1);
                }
                catch (ThreadInterruptedException)
                {
                    carWasher.Running = false;
                }
            }
        }

        public CarWasher(int capacityLitres) {
            if (capacityLitres < 5000 || capacityLitres > 100000)
            {
                throw new InvalidOperationException("Capacity out of range!");
            }
            Text = "Empty";
            Random random = new Random(Environment.TickCount);
            CapacityLitres = capacityLitres;
            InGateState = new Gate(125);
            OutGateState = new Gate(125);
            InletValveFlowRate = (int)(500.0 + random.NextDouble() * 1500.0);
            Running = true;
            WorkingCycleMs = (int)(250.0 + random.NextDouble() * 1000.0);
            States = MachineStates.AwaitingResponse;
            _thread.Start(this); 
        }
        public void Dispose()
        {
            try
            {
                _thread.Interrupt();
                _thread.Join();
            }
            catch (Exception)
            {
            }
        }
    }
}
