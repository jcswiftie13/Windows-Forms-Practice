using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log_parsing;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void enter_Click(object sender, EventArgs e)
        {
            string filepath = inputpath.Text;
            ReadFile reader = new ReadFile(filepath);
            var time = reader.rettime();
            var levels = reader.retlevel();
            var categories = reader.retcategory();
            var tags = reader.rettag();
            display.Text = "Starts at: " + time.Item1 + Environment.NewLine;
            display.AppendText("Ends at: " + time.Item2 + Environment.NewLine);
            display.AppendText("Levels: " + Environment.NewLine);
            foreach(KeyValuePair<string, int> kvp in levels)
            {
                display.Text += string.Format("{0}: {1}\t", kvp.Key, kvp.Value);
            }
            display.AppendText(Environment.NewLine + "Categories: " + Environment.NewLine);
            foreach (KeyValuePair<string, int> kvp in categories)
            {
                display.Text += string.Format("{0}: {1}\t", kvp.Key, kvp.Value);
            }
            display.AppendText(Environment.NewLine + "Tags: " + Environment.NewLine);
            foreach (KeyValuePair<string, int> kvp in tags)
            {
                display.Text += string.Format("{0}: {1}\t", kvp.Key, kvp.Value);
            }
        }
    }
}
