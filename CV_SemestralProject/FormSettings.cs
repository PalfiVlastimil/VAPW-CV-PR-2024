using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CV_SemestralProject
{
    public partial class FormSettings : Form
    {
        public bool IsEvent { get { return radioButton1.Checked; } }
        public FormSettings()
        {
            InitializeComponent();
        }
    }
}
