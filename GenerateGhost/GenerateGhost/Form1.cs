using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.DirectoryServices;

namespace GenerateGhost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Machine> lstMachines = new List<Machine>();

        private void btnPickFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "DHCP Dump (*.csv)|*.csv|All Files|*.*";
            openFileDialog1.ShowDialog();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        Dictionary<string, string> arrMachines = new Dictionary<string, string>();

        private void Go_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    using (StreamReader readFile = new StreamReader(openFileDialog1.FileName))
                    {
                        string line;
                        string[] row;

                        while ((line = readFile.ReadLine()) != null)
                        {
                            if ((line == "") || (line.StartsWith("Client")))
                                continue;

                            row = line.Split(',');

                            if (arrMachines.ContainsKey(row[1].Replace("." + strREGIONCODE.ToLower() + ".eq.edu.au", "")))
                            {
                                arrMachines.Remove(row[1].Replace("." + strREGIONCODE.ToLower() + ".eq.edu.au", ""));
                            }
                            arrMachines.Add(row[1].Replace("." + strREGIONCODE.ToLower() + ".eq.edu.au", ""), row[4].ToUpper());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            foreach (KeyValuePair<string, string> macInfo in arrMachines)
            {
                DirectoryEntry dirEntry = new DirectoryEntry("LDAP://OU=" + strSITECODE + "_Computers,OU=" + strSITEOU + ",OU=" + strDISTRICTOU + ",DC=" + strREGIONCODE.ToLower() + ",DC=eq,DC=edu,DC=au");
                DirectorySearcher mySearch = new DirectorySearcher(dirEntry);
                mySearch.Filter = "(&(objectClass=computer)(Name=" + macInfo.Key + "))";
                foreach (SearchResult resEnt in mySearch.FindAll())
                {
                    string shortADName = resEnt.GetDirectoryEntry().Path.Replace("LDAP://CN=" + macInfo.Key + ",", "");
                    string shorterName = shortADName.Remove(shortADName.IndexOf(",OU=" + strSITECODE + "_Computers"));
                    lstMachines.Add(new Machine() { MACAddress = macInfo.Value, Name = macInfo.Key, OrganizationalUnit = shorterName, Description = resEnt.GetDirectoryEntry().Properties["Description"].Value.ToString() });
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = from m in lstMachines
                        orderby m.OrganizationalUnit
                        select m;

            Dictionary<string, List<Machine>> dicMachines = new Dictionary<string,List<Machine>>();

            foreach (var mach in query)
            {
                if (!dicMachines.ContainsKey(mach.OrganizationalUnit))
                {
                    dicMachines.Add(mach.OrganizationalUnit, new List<Machine> { mach });
                }
                else
                {
                    dicMachines[mach.OrganizationalUnit].Add(mach);
                }
            }

            textBox1.AppendText(strSITECODE + " Ghost file!\r\n\r\n");
            foreach (KeyValuePair<string, List<Machine>> mach in dicMachines)
            {
                textBox1.AppendText(mach.Key.ToString() + "\r\n");
                foreach (Machine m in mach.Value)
                {
                    textBox1.AppendText("\t" + m.MACAddress + ";" + m.Name + ";" + m.Description + "\r\n");
                }
            }
        }

        public string strSITEOU = Environment.GetEnvironmentVariable("SITEOU");
        public string strDISTRICTOU = Environment.GetEnvironmentVariable("DISTRICTOU");
        public string strREGIONCODE = Environment.GetEnvironmentVariable("REGIONCODE");
        public string strSITECODE = Environment.GetEnvironmentVariable("SITECODE");

        private void Form1_Load(object sender, EventArgs e)
        {
            if ((Environment.GetEnvironmentVariable("SITEOU") == "") || (Environment.GetEnvironmentVariable("DISTRICTOU") == "") || (Environment.GetEnvironmentVariable("REGIONCODE") == ""))
            {
                MessageBox.Show("Are you running this on a WORKSTATION? Is the machine MOEd? Is your MOE working correctly? App will not function correctly without environment variables."); 
            }
            txtSite.Text = Environment.GetEnvironmentVariable("SITEOU");
            txtDistrict.Text = Environment.GetEnvironmentVariable("DISTRICTOU");
            txtRegion.Text = Environment.GetEnvironmentVariable("REGIONCODE");
        }
    }

    class Machine
    {
        public Machine()
        {
        }

        public string MACAddress;
        public string OrganizationalUnit;
        public string Name;
        public string Description;
    }
}
