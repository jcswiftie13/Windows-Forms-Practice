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
using System.IO;
using log_parsing;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string filename;
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
            string[] lines = null;
            try
            {
                lines = System.IO.File.ReadAllLines($"{filepath}");
            }
            catch(FileNotFoundException)
            {
                DialogResult d;
                d = MessageBox.Show("File not found.", "Retry input", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.No)
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    goto Label;
                }
            }
            FileReader reader = new FileReader(lines);
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
            Label:;
        }

        private void display_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputpath_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK && dlg.FileName != null)
            {
                // Open document
                filename = dlg.FileName;
            }
            inputpath.Text = filename;
        }
    }
}
