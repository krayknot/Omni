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
using System.Net.Sockets;

namespace Omni
{
    public partial class frmStepThree : Form
    {
        public frmStepThree()
        {
            InitializeComponent();
        }

        private void frmStepThree_Load(object sender, EventArgs e)
        {
            GetIPv4Statistics();
        }

        public void GetIPv4Statistics()
        {
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
                            txtOutput.Text = txtOutput.Text.Trim() + Environment.NewLine + ip.ToString();
                            count = count +1;
                        }

                        //MessageBox.Show(ip.ToString());
                    }
                }
            }
        }

        public string GetIPv4StatisticsLOCAL()
        {
            string response = string.Empty;
            //get the IPv4 address

            //dataGridView1.DataSource = NetworkInterface.GetAllNetworkInterfaces();

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

        private void button1_Click(object sender, EventArgs e)
        {
            


                //if (dnsServers.Count > 0)
                //{
                //    //Console.WriteLine(adapter.Description);
                //    foreach (IPAddress dns in dnsServers)
                //    {
                //        MessageBox.Show(dns.ToString() + " " + dns.AddressFamily);
                //    }
                //    //Console.WriteLine();
                //}
            }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmStepFour().ShowDialog();
        }

        
       
    }
}
