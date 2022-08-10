using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Omni
{
    public partial class frmStepFour : Form
    {
        public frmStepFour()
        {
            InitializeComponent();
        }

        private void frmStepFour_Load(object sender, EventArgs e)
        {
            txtOutput.Text = GetIPv4StatisticsLOCAL();
        }

        public string GetIPv4StatisticsLOCAL()
        {
            string response = string.Empty;
            //get the IPv4 address

            

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                //MessageBox.Show(ni.NetworkInterfaceType.ToString());
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                // if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.GenericModem)
                {
                    Console.WriteLine(ni.Name);
                    foreach (GatewayIPAddressInformation ip in ni.GetIPProperties().GatewayAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && ni.Name == "Network Bridge")
                        {
                            response = ip.Address.ToString();
                        }
                    }
                }
            }

            return response;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmStepFive().ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }
    }
}
