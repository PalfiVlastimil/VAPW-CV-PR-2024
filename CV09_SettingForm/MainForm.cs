using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cv9
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var form = new SettingForm();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                // zpracovat hodnotu formulari
                if (form.IsEvent)
                {
                    // nasatveni pro udalostni zpracovani
                }
                else
                {
                    // nastaveni pro casovani
                }
            }
        }
    }
}
