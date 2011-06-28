using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace PrintMap2
{
    public partial class Form1 : Form
    {
        XDocument XPrintersXML;

        public Form1()
        {
            InitializeComponent();
        }

        public string strConfigurationLocation = "";
        
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("configuration.xml"))
                {
                    XDocument xConfigurationXML = XDocument.Load("configuration.xml");
                    strConfigurationLocation = xConfigurationXML.Element("configuration").Element("filepath").Value;
                    //MessageBox.Show(strConfigurationLocation);
                }
                else
                {
                    string envPath = "\\\\eq" + Environment.GetEnvironmentVariable("REGIONCODE").ToString().ToLower() + Environment.GetEnvironmentVariable("SITECODE").ToString() + "001\\eqlogon\\student_printers.xml";
                    strConfigurationLocation = envPath;
                    //MessageBox.Show(strConfigurationLocation);
                }

                if (File.Exists("student_printers.xml")) {
                    XPrintersXML = XDocument.Load(@"student_printers.xml");
                    toolStripStatusLabel1.Text = "NOTICE: Loaded XML from local file.";
                } else {
                    XPrintersXML = XDocument.Load(strConfigurationLocation);
                }
                //XPrintersXML = XDocument.Load(@"\\eqnoq2008001\eqlogon\student_printers.xml");
                //XPrintersXML = XDocument.Load(@"student_printers.xml");
                var q = from c in XPrintersXML.Descendants("printer")
                        select new
                        {
                            Name = c.Element("name").Value,
                            Description = c.Element("description").Value,
                            Path = c.Element("path").Value
                        };

                foreach (var item in q)
                {
                    lstPrinters.Items.Add(item.Name);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                // Probably not connected to the network.
                MessageBox.Show("Could not find file on Server.  Are you sure you've got WiFi turned on and connected to the network, or are plugged in via ethernet?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        [DllImport("printui.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern void PrintUIEntryW(IntPtr hwnd, IntPtr hinst, string lpszCmdLine, int nCmdShow);

        private void lstPrinters_SelectedValueChanged(object sender, EventArgs e)
        {
            if (File.Exists("student_printers.xml"))
            {
                XPrintersXML = XDocument.Load(@"student_printers.xml");
                toolStripStatusLabel1.Text = "NOTICE: Loaded XML from local file.";
            }
            else
            {
                XPrintersXML = XDocument.Load(strConfigurationLocation);
            }
            //XPrintersXML = XDocument.Load(@"student_printers.xml");
            //XPrintersXML = XDocument.Load(@"\\eqnoq2008001\eqlogon\student_printers.xml");
            var q = from c in XPrintersXML.Descendants("printer")
                    where c.Element("name").Value == lstPrinters.SelectedItem.ToString()
                    select new
                    {
                        Name = c.Element("name").Value,
                        Description = c.Element("description").Value,
                        Path = c.Element("path").Value
                    };

            foreach (var i in q) {
                textBox1.Text = i.Name;
                textBox2.Text = i.Description + " All jobs sent to this printer are audited.";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("PrintMap Version 2.0 for MOE 3.0 by Brent Pickup (AyrSHS)", "About");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstPrinters.SelectedIndex == -1)
            {
                MessageBox.Show("ERR: Please select a printer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            toolStripStatusLabel1.Text = "Enumerating printers....";

            if (File.Exists("student_printers.xml"))
            {
                XPrintersXML = XDocument.Load(@"student_printers.xml");
                toolStripStatusLabel1.Text = "NOTICE: Loaded XML from local file.";
            }
            else
            {
                XPrintersXML = XDocument.Load(strConfigurationLocation);
            }
            //XPrintersXML = XDocument.Load(@"student_printers.xml");
            //XPrintersXML = XDocument.Load(@"\\eqnoq2008001\eqlogon\student_printers.xml");
            var q = from c in XPrintersXML.Descendants("printer")
                    where c.Element("name").Value == lstPrinters.SelectedItem.ToString()
                    select new
                    {
                        Name = c.Element("name").Value,
                        Description = c.Element("description").Value,
                        Path = c.Element("path").Value
                    };

            foreach (var i in q)
            {
                toolStripStatusLabel1.Text = "Mapping Printer....";
                PrintUIEntryW(IntPtr.Zero, IntPtr.Zero, @"/in /n" + i.Path, 0);
                toolStripStatusLabel1.Text = "Done. Printer should be available.";
            }
        }
    }
}
