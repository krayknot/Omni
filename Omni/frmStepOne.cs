using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Omni
{
    public partial class frmStepOne : Form
    {
        public frmStepOne()
        {
            InitializeComponent();
        }

        private void frmStepOne_Load(object sender, EventArgs e)
        {

        }

        private void btnTestInternet_Click(object sender, EventArgs e)
        {
            lstStatus.Items.Add("Checking Internet...");
            lstStatus.Refresh();

            if (CheckForInternetConnection() == true)
            {
                lstStatus.Items.Add("Internet is Active.");
                btnNext.Enabled = true;            
            }
            else
            {
                lstStatus.Items.Add("Internet is In-active.");
            }
            lstStatus.Refresh();
        }

        public bool CheckForInternetConnection()
        {
            try
            {
               

                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmStepTwo().ShowDialog();
        }
    }
}
