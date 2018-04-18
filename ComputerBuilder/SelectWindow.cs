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
    public partial class SelectWindow : Form
    {
        public SelectWindow()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SelectWindow_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton7.Checked = true;
            radioButton3.Checked = true;
            checkBox9.Checked = true;
            label12.Enabled = false;
            checkedListBox1.Enabled = false;
            label2.Enabled = false;
            comboBox1.Enabled = false;
            comboBox7.Enabled = false;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                label12.Enabled = true;
                comboBox7.Enabled = true;
            }
            else
            {
                label12.Enabled = false;
                comboBox7.Enabled = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                checkedListBox1.Enabled = true;

            }
            else
            {
                checkedListBox1.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox8.Enabled = true;
                label2.Enabled = false;
                comboBox1.Enabled = false;
            }
            else
            {
               
                comboBox8.Enabled = false;
                label2.Enabled = true;
                comboBox1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
