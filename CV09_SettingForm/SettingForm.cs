﻿using System;
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
    public partial class SettingForm : Form
    {
        public bool IsEvent { get { return radioButton1.Checked; } }

        public SettingForm()
        {
            InitializeComponent();
        }
    }
}
