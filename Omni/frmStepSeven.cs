using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Omni
{
    public partial class frmStepSeven : Form
    {
        public frmStepSeven()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }
    }
}
