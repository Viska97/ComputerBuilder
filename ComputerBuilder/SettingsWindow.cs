using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ComputerBuilder
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete(GlobalVariables.apppath + @"\coockies.txt");
            Application.Restart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SettingsReader manager = new SettingsReader(GlobalVariables.apppath + @"\settings.ini");
            SelectCityWindow scw = new SelectCityWindow(false);
            scw.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsWindow_Activated(object sender, EventArgs e)
        {
            
            YandexInfo yi = new YandexInfo();
            label1.Text =  yi.GetUserName();
            pictureBox1.Load(yi.GetUserAvatar());
            SettingsReader manager = new SettingsReader(GlobalVariables.apppath + @"\settings.ini");
            label2.Text = manager.GetPrivateString("Main", "CityName");
        }
    }
}
