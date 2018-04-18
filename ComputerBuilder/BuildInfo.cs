using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace ComputerBuilder
{
    public partial class BuildInfo : Form
    {
        private List<string> tovarslinks = new List<string>();
        public BuildInfo(string[] tovarslinks, string[] tovarsnames, string[] tovarsprives, Bitmap[] tovarsimages, string title)
        {

            InitializeComponent();
            int summ = 0;
            for (int i = 0; i < 10; i++)
            {
                
                    string price = tovarsprives[i].Replace(" ", string.Empty);
                    imageList1.Images.Add(tovarsimages[i]);
                    ListViewItem lvi = new ListViewItem();
                    lvi.Group = listView1.Groups[i];
                    lvi.ImageIndex = i;
                    lvi.Text = tovarsnames[i];
                    lvi.SubItems.Add("от " + price + " руб");
                    listView1.Items.Add(lvi);
                    summ = summ + Int32.Parse(price);
                    this.tovarslinks.Add(tovarslinks[i]);
                
                
            }
            label1.Text = title;
            label2.Text = "Итого: от " + Convert.ToString(summ) + " руб.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (ListViewItem lvi in listView1.Items)
            {
                if (lvi.Checked)
                {
                    i++;
                    if (tovarslinks[lvi.Index]!= "")
                    {
                        System.Diagnostics.Process.Start(tovarslinks[lvi.Index]);
                    }
                    
                }
            }
            if (i == 0)
            {
                MessageBox.Show("Не выбраны комплектующие!");
            }
        }
    }
}
