using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.Common;
using System.IO;

namespace ComputerBuilder
{
    
    public partial class MainWindow : Form
    {
        public static string apppath = @Assembly.GetExecutingAssembly().Location;

        public MainWindow()
        {
            InitializeComponent();
            GlobalVariables.apppath = apppath.Remove(apppath.LastIndexOf(@"\"));
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
            
            bool needrestart = false;
            ExtractFiles EF1 = new ExtractFiles(@Assembly.GetExecutingAssembly().Location);
            EF1.Extract();
            needrestart = EF1.needrestart;
            if (needrestart == true)
            {
                MessageBox.Show("Приложение будет перезапущено для подгрузки необходимых файлов");
                Application.Restart();
            }
            else
            {
                SqlConnect connect = new SqlConnect();   
            }
            this.CheckFirtsRun();
            this.CheckLogin();
            this.CheckCity();
        }


        private void CheckLogin()
        {
            if (File.Exists(GlobalVariables.apppath + @"\ComputerBuilderData\coockies.txt"))
            {
                string username, useravatar;
                YandexInfo yi = new YandexInfo();
                username = yi.GetUserName();
                useravatar = yi.GetUserAvatar();
                if (username == null)
                {
                    YandexLoginWindow ylw = new YandexLoginWindow();
                    ylw.mw = this;
                    ylw.ShowDialog();
                }
                else
                {
                    this.username.Text = username;
                    this.useravatar.Load(useravatar);
                }
            }
            else
            {
                YandexLoginWindow ylw = new YandexLoginWindow();
                ylw.mw = this;
                ylw.ShowDialog();
            }
        }
        private void CheckCity()
        {
            string cityname;
            try
            {
                
                SettingsReader manager = new SettingsReader(GlobalVariables.apppath + @"\settings.ini");
                cityname = manager.GetPrivateString("Main", "City");
                if (cityname == "null")
                {
                    SelectCityWindow scw = new SelectCityWindow(true);
                    scw.ShowDialog();
                }
            }
            catch (Exceptions ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void CheckFirtsRun()
        {
            string check;
            SettingsReader manager = new SettingsReader(GlobalVariables.apppath + @"\settings.ini");
            check = manager.GetPrivateString("Other", "FirstRun");
            if (check == "True")
            {
                MessageBox.Show("Добро пожаловать в помощник по выбору компьютера! Для работы программы необходимо авторизоваться с помощью аккаунта Яндекс и выбрать город.");
                manager.WritePrivateString("Other", "FirstRun" , "False");
            }
        }
       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://market.yandex.ru/");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            SettingsReader manager = new SettingsReader(GlobalVariables.apppath + @"\settings.ini");
            string city = manager.GetPrivateString("Main", "CityName");
            label2.Text = city;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SettingsWindow sw = new SettingsWindow();
            sw.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AboutWindow aw = new AboutWindow();
            aw.ShowDialog();
        }

        

        

        private void button3_Click(object sender, EventArgs e)
        {
            ComputerWindow cw = new ComputerWindow();
            try
            {
                cw.ShowDialog();
            }
            catch (Exception)
            {

                MessageBox.Show("Неизвестная ошибка");
                Application.Restart();
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    public static class GlobalVariables
    {
        public static string apppath { get; set; }
    }

    
}
