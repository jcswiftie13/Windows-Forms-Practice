using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
            FileReader reader = new FileReader(filepath);
            var time = reader.PassTime();
            var levels = reader.PassLevel();
            var categories = reader.PassCategory();
            var tags = reader.PassTag();
            display.Text = "Starts at: " + time.Item1 + Environment.NewLine;
            display.AppendText("Ends at: " + time.Item2 + Environment.NewLine + Environment.NewLine);
            display.AppendText("Levels total: " + levels.Count + Environment.NewLine + Environment.NewLine);
            foreach(KeyValuePair<string, int> kvp in levels)
            {
                display.Text += string.Format("{0}: {1}\t", kvp.Key, kvp.Value) + Environment.NewLine;
            }
            display.AppendText(Environment.NewLine + "Categories total: " + categories.Count + Environment.NewLine + Environment.NewLine);
            foreach (KeyValuePair<string, int> kvp in categories)
            {
                display.Text += string.Format("{0}: {1}\t", kvp.Key, kvp.Value) + Environment.NewLine;
            }
            display.AppendText(Environment.NewLine + "Tags total: " + tags.Count + Environment.NewLine + Environment.NewLine);
            foreach (KeyValuePair<string, int> kvp in tags)
            {
                display.Text += string.Format("{0}: {1}\t", kvp.Key, kvp.Value) + Environment.NewLine;
            }
        }

        private void display_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputpath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
