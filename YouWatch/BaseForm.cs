﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouWatch
{
    public partial class BaseForm : Form
    {
        public bool IsClosed = false;
        public bool IsHidden = false;

        public BaseForm()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            IsClosed = false;
            IsHidden = false;
        }
    }
}
