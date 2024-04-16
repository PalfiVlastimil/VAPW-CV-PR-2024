using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR07
{
    public partial class Form2 : Form
    {
        public Form2(string str)
        {
            InitializeComponent();
            button1.Text = str;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkBox1.Checked)
            {
                e.Cancel = true;
            }
            if (checkBox2.Checked)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                DialogResult = DialogResult.Continue;
            }
        }

        public String Text2
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }


    }
}
