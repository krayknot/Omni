using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;


namespace Omni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ipv4Statistics = string.Empty;
            string ipv4StatisticsLOCAL = string.Empty;


            lstStatus.Items.Add("Checking Internet...");
            lstStatus.Refresh();

            if (CheckForInternetConnection() == true)
            {
                lstStatus.Items.Add("Internet is Active.");

                lstStatus.Items.Add("Plug your laptop to one of the router's LAN ports. Wait until the router connects correctly.");

                //get the IPv4 address
                ipv4Statistics = GetIPv4Statistics();
                lstStatus.Items.Add("Ipv4 Statistics: " + ipv4Statistics);

                ipv4StatisticsLOCAL = GetIPv4StatisticsLOCAL();
                lstStatus.Items.Add("Ipv4 Statistics Ethernet: " + ipv4StatisticsLOCAL);


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

        public string GetIPv4Statistics()
        {
            string response = string.Empty;
            //get the IPv4 address
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ppp)
                // if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.GenericModem)
                {
                    Console.WriteLine(ni.Name);
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            response = ip.Address.ToString();
                        }
                    }
                }
            }

            return response;
        }

        public string GetIPv4StatisticsLOCAL()
        {
            string response = string.Empty;
            //get the IPv4 address

            dataGridView1.DataSource = NetworkInterface.GetAllNetworkInterfaces();

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
