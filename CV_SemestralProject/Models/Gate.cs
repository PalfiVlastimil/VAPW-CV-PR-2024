using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CV_SemestralProject.Models.CarWasher;

namespace CV_SemestralProject.Models
{
    public class Gate
    {
        public delegate void ChangedSemaphoreStateHandler(object sender, Semaphore semaphore);
        public delegate void ChangedOpeningStateHandler(object sender, int openingShift);
        public event ChangedSemaphoreStateHandler OnSemaphoreStateChange;
        public event ChangedOpeningStateHandler OnOpeningStateChange;

        public int MaxOpeningShift { get; private set; }
        private int _progressOpeningShift;
        public int ProgressOpeningShift
        {
            get
            {
                return _progressOpeningShift;
            }
            set
            {
                bool flag = value != _progressOpeningShift;
                _progressOpeningShift = value;
                if (flag)
                {
                    this.OnOpeningStateChange?.Invoke(this, _progressOpeningShift);
                }
            }
        }
        private Semaphore _semaphore;
        public Semaphore Semaphore 
        {
            get 
            {
                return _semaphore;
            }
            set
            {
                bool flag = value != _semaphore;
                _semaphore = value;
                if (flag)
                {
                    this.OnSemaphoreStateChange?.Invoke(this, _semaphore);
                }
            } 
        }
        
        public Gate(int maxOpeningShift) { 
            
            MaxOpeningShift = maxOpeningShift;
            ProgressOpeningShift = 0;
            Semaphore = Semaphore.Off;
        
        }
        public void OpenGate()
        {
            for (int i = 0; i < MaxOpeningShift; i++)
            {
                ProgressOpeningShift += 1;
            }
        }
        public void CloseGate()
        {
            for (int i = 0; i < MaxOpeningShift; i++)
            {
                ProgressOpeningShift -= 1;
            }
        }
    }
}
