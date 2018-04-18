using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace ComputerBuilder
{
    public partial class YandexLoginWindow : Form
    {
        public MainWindow mw;
        private bool closeapp = true;
        public YandexLoginWindow()
        {
            InitializeComponent();
            
            label3.Text = "";
            label4.Text = "";
            
        }

        private void YandexLoginWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeapp)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CookieContainer test = new CookieContainer();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            label3.Text = "";
            label4.Text = "";
            try
            {
                Yandex yandex = new Yandex(textBox1.Text, textBox2.Text);
                yandex.Authorize();
                test = yandex.cookies;
                Cookies cs = new Cookies();
                cs.Write(test, GlobalVariables.apppath + @"\ComputerBuilderData\coockies.txt");
                YandexInfo yi = new YandexInfo();
                mw.username.Text = yi.GetUserName();
                mw.useravatar.Load(yi.GetUserAvatar());
                closeapp = false;
                this.Close();

            }
            catch (Exceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (YandexExceptions)
            {
                if (textBox1.Text == "")
                {
                    label3.Text = "Поле пустое!";
                }
                if (textBox2.Text == "")
                {
                    label4.Text = "Поле пустое!";
                }
            }

            finally
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }



        }

        private void YandexLoginWindow_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://passport.yandex.ru/passport?mode=restore");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://passport.yandex.ru/registration/");
        }
    }
}
