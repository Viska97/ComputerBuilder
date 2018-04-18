using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 

namespace ComputerBuilder
{
    public partial class ComputerWindow : Form
    {
        private List<string> builds = new List<string>();
        private string[] segments = new string[7] {"" , "verylow", "low" , "medium" , "high" , "veryhigh" , "maximum"};
        private string[] orders = new string[2] {"ASC", "DESC"};
        private string segment = "";
        private string order = "ASC";
        public ComputerWindow()
        {
            InitializeComponent();
            
        }

        private void ComputerWindow_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            
            BuildsLoader bl = new BuildsLoader(order,segment);
            builds = bl.GetBuilds();
            
            
            foreach (string build in builds)
            {
                listBox1.Items.Add(build);
                

            }
            

        }

        private void ListBoxLoad()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedIndex != -1)
            {
                string bl = listBox1.SelectedItem.ToString();
                bl = bl.Substring(0, bl.IndexOf("."));
                LoadingWindow lw = new LoadingWindow(bl);
                lw.ShowDialog();
            }
            else
            {
                MessageBox.Show("Не выбрана сборка!");
            }
           
        }

        private void listBox1_EnabledChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void listBox1_Enter(object sender, EventArgs e)
        {
            //button1.Enabled = true;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            segment = segments[comboBox1.SelectedIndex];

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            order = orders[comboBox2.SelectedIndex];
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuildsLoader bl = new BuildsLoader(order, segment);
            builds = bl.GetBuilds();
            listBox1.Items.Clear();
            foreach (string build in builds)
            {
                listBox1.Items.Add(build);
                

            }
        }
    }
}
