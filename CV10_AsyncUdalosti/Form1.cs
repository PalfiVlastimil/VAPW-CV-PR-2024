using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cv9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Red;

            /* 
             * simulace ulohy s dobou trvání 5s
             * 5 x 1s s aktualizací čítače na Label
             * 
             * BLOKUJE UI VLÁKNO - cyklus se provádí v rámci
             * vlákna UI
             * 
             */ 
            for (int i = 0; i < 5; i++)
            {
                label1.Text = i.ToString();
                Thread.Sleep(1000);
            }

            panel1.BackColor = Color.Lime;
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Red;

            /* 
             * simulace ulohy s dobou trvání 5s
             * 5 x 1s s aktualizací čítače na Label
             * 
             * NEBLOKUJE UI VLÁKNO - cyklus se provádí v rámci
             * vlákna úlohy (spuštěno na poolu vláken)
             * 
             * !!! metoda obsluhy události je asynchronní, neblokuje UI vlákno,
             * ale díky await se čeká na dokončení úlohy
             * 
             */
            //pomocí await čeká na dokončení události, během async můžeme něco dělat
            await Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    //Tímhle nám neblokuje UI vlákno, nebo by byla nějaká chyba
                    this.Invoke(new Action(() => { label2.Text = i.ToString(); }));
                    
                    Thread.Sleep(1000);
                }
            });

            panel2.BackColor = Color.Lime;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Red;

            /* 
             * simulace ulohy s dobou trvání 5s
             * 5 x 1s s aktualizací čítače na Label
             * 
             * NEBLOKUJE UI VLÁKNO - cyklus se provádí v rámci
             * vlákna úlohy (spuštěno na poolu vláken)
             * 
             * !!! neblokuje UI vlákno, nečeká se na dokončení úlohy
             * 
             */
            Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    this.Invoke(new Action(() => { label3.Text = i.ToString(); }));
                    Thread.Sleep(1000);
                }
            });

            panel3.BackColor = Color.Lime;
        }
    }
}
