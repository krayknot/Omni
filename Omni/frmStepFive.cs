using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.Diagnostics;

namespace Omni
{
    public partial class frmStepFive : Form
    {
        public frmStepFive()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetIPv4Statistics();
        }

        public void GetIPv4Statistics()
        {
            string response = string.Empty;

            int count = 0;
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {

                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                IPAddressCollection dnsServers = adapterProperties.DnsAddresses;

                foreach (IPAddress ip in adapterProperties.DnsAddresses)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        if (count < 2)
                        {
                            response = response.Trim() + Environment.NewLine + ip.ToString();
                            count = count + 1;
                        }

                        //MessageBox.Show(ip.ToString());
                    }
                }
            }

            MessageBox.Show(response, "Information: IPv4 DNS Servers", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmStepSix().ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://" + GetIPv4StatisticsLOCAL());
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
    }
}
