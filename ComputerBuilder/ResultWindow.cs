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
    public partial class ResultWindow : Form
    {
        private string[] tovarslinks = new string[10] ;
        private string[] tovarsnames = new string[10];
        private string[] tovarsprives = new string[10];
        private string[] tovarsimages = new string[10];
        private string title = "";
        private int summ = 0;
        //private List<string> citiesnames = new List<string>();
        public ResultWindow(string[] tovarslinks, string[] tovarsnames, string[] tovarsprives, string[] tovarsimages, string title)
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                this.tovarslinks[i] = tovarslinks[i];
                this.tovarsnames[i] = tovarsnames[i];
                this.tovarsprives[i] = tovarsprives[i];
                this.tovarsimages[i] = tovarsimages[i];
                this.title = title;
                string price = tovarsprives[i].Replace(" ", string.Empty);
                summ = summ + Int32.Parse(price);
            }
            label1.Text = title;
            pictureBox1.LoadAsync(tovarsimages[0]);
            pictureBox2.LoadAsync(tovarsimages[1]);
            pictureBox3.LoadAsync(tovarsimages[2]);
            pictureBox4.LoadAsync(tovarsimages[3]);
            pictureBox9.LoadAsync(tovarsimages[8]);
            pictureBox10.LoadAsync(tovarsimages[9]);
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            label2.Text = tovarsnames[0].Substring(0, tovarsnames[0].Length - 29); 
            label3.Text = tovarsnames[1];
            label4.Text = tovarsnames[2];
            label5.Text = tovarsnames[3];
            label10.Text = tovarsnames[8];
            label23.Text = tovarsnames[9];
            label11.Text = "От " + tovarsprives[0] + " руб";
            label12.Text = "От " + tovarsprives[1] + " руб";
            label13.Text = "От " + tovarsprives[2] + " руб";
            label14.Text = "От " + tovarsprives[3] + " руб";
            label19.Text = "От " + tovarsprives[8] + " руб";
            label22.Text = "От " + tovarsprives[9] + " руб";
            if (tovarsimages[4] != "")
            {
                pictureBox5.LoadAsync(tovarsimages[4]);
                label6.Text = tovarsnames[4].Substring(0, tovarsnames[4].Length - 30); 
                label15.Text = "От " + tovarsprives[4] + " руб";
                button5.Enabled = true;
            }
            if (tovarsimages[5] != "")
            {
                pictureBox6.LoadAsync(tovarsimages[5]);
                label7.Text = tovarsnames[5];
                label16.Text = "От " + tovarsprives[5] + " руб";
                button6.Enabled = true;
            }
            if (tovarsimages[6] != "")
            {
                pictureBox7.LoadAsync(tovarsimages[6]);
                label8.Text = tovarsnames[6];
                label17.Text = "От " + tovarsprives[6] + " руб";
                button7.Enabled = true;
            }
            if (tovarsimages[7] != "")
            {
                pictureBox8.LoadAsync(tovarsimages[7]);
                label9.Text = tovarsnames[7];
                label18.Text = "От " + tovarsprives[7] + " руб";
                button8.Enabled = true;
            }
            label21.Text = "От " + summ + " руб";


        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tovarslinks[0]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tovarslinks[1]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tovarslinks[2]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tovarslinks[3]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tovarslinks[4]);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tovarslinks[5]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tovarslinks[6]);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tovarslinks[7]);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tovarslinks[8]);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tovarslinks[9]);
        }

        private void ResultWindow_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
