using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace ConvertCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("\\\\eqnoq2008001\\eqlogon\\Printers.csv"))
            {
                using (StreamReader readFile = new StreamReader("\\\\eqnoq2008001\\eqlogon\\Printers.csv"))
                {
                    string line;
                    string[] row;

                    XElement ePrinters = new XElement("printers");

                    while ((line = readFile.ReadLine()) != null)
                    {
                        if ((line == "") || (line.StartsWith("Ayr State High School")))
                            continue;
                        row = line.Split(',');
                        // 0 = first name
                        // 1 = last
                        // 2 = username
                        // 3 = eqid
                        XElement ePrinter = new XElement("printer", new XElement("item",
                            new XElement("name", row[0]),
                            new XElement("description", row[0])));
                        //arrStudents.Add(new Person() { FirstName = row[1], LastName = row[0], Username = row[2] });
                    }
                }
                // parse students.
            }
        }
    }
}
