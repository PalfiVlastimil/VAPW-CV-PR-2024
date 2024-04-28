using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace cv10
{
    public partial class Form1 : Form
    {
        const int THREADS = 17;
        const long MAX = 100000000;
        long[] counters = new long[THREADS];
        Thread[] threads = new Thread[THREADS];
        ProgressBar[] pbars = new ProgressBar[THREADS];

        /// <summary>
        /// Synchronizační objekt, poskytuje zámek kritické sekce
        /// </summary>
        object lockObject = new object();

        Stopwatch sw = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // vygenerovani UI komponent pro zobrazení stavu čítače
            // vygenerování jednotlivých vláken (instance Thread)
            for (int i = 0; i < threads.Length; i++)
            {
                pbars[i]?.Dispose();
                counters[i] = 0;

                pbars[i] = new ProgressBar { Parent = this, Left = 50, Top = 50 + i * 22,
                    Value = 0, Height = 10 };

                /* 
                 * pro jednotlive typy metod vlakna se pouzije
                 * 
                 * new ParameterizedThreadStart(ThreadProc)
                 *  - inkrementace čítače, bez synchronizace a uspávání vlákna
                 *  - spotřebovává plný výkon procesoru
                 * 
                 * new ParameterizedThreadStart(ThreadProcSync)
                 *  - inkrementace čítače, se synchronizací bez uspávání vlákna
                 *  - spotřebovává plný výkon, díky synchronizaci trvá déle vykonání všech úloh
                 * 
                 * new ParameterizedThreadStart(ThreadProcSyncSleep)
                 *  - inkrementace po částech se synchronizací a uspáváním vlákna
                 *  - nevytěžuje procesor na plný výkon
                 * 
                 */ 
                threads[i] = new Thread(new ParameterizedThreadStart(ThreadProcSyncSleep));
            }

            timer1.Start();

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start(i);
            }

            sw.Reset();
            sw.Start();
        }

        private void ThreadProc(object o)
        {
            var index = (int)o;

            while (counters[index] < MAX)
            {
                counters[index]++;
            }
        }

        private void ThreadProcSync(object o)
        {
            var index = (int)o;

            while (counters[index] < MAX)
            {
                // vlákno získá zámek kritické sekce, ostatní vlákna
                // čekají na zámek (jejich činnost je blokována)
                lock (lockObject) // => synchronizace
                {
                    counters[index]++;
                }
            }
        }

        private void ThreadProcSyncSleep(object o)
        {
            var index = (int)o;

            while (counters[index] < MAX)
            {
                // vlákno získá zámek kritické sekce, ostatní vlákna
                // čekají na zámek (jejich činnost je blokována)
                lock (lockObject)// => synchronizace
                {
                    for (int j = 0; j < 50000; j++)
                    {
                        counters[index]++;
                    }
                }
                // vlákno je uspáno na 1ms, procesor tak může přepnou na vykonávání
                // jiného vlákna
                Thread.Sleep(1);// => uspání vlákna, po uspání předá klíč/přepne se program na jiné vlákno 
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            bool done = true;
            for (int i = 0; i < counters.Length; i++)
            {
                pbars[i].Value = (int)(100 * counters[i] / MAX);
                done &= counters[i] == MAX;
            }
            if (done)
            {
                sw.Stop();
                label1.Text = $"{sw.ElapsedMilliseconds} ms";
            }
        }
    }
}
