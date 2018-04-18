using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading.Tasks;
using System.Threading;

namespace ComputerBuilder
{
    public partial class SelectCityWindow : Form
    {
        private List<string> regions = new List<string>();
        private List<string> regionids = new List<string>();
        private List<string> cities = new List<string>();
        private List<string> citiesnames = new List<string>();
        private string region = null;
        private string city = null;
        public SelectCityWindow(bool cancelbutton)
        {
            InitializeComponent();
            this.ControlBox = false;
            if (cancelbutton)
            {
                button2.Visible = false;
            }

        }

        private void SelectCityWindow_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            

        }

        private void LoadCities(object sender, DoWorkEventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("https://pogoda.yandex.ru/static/cities.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("country[@name='Россия']/city");
            
            foreach (XmlNode item in childnodes)
            {
                XmlNode attr = item.Attributes.GetNamedItem("part");
                if (regions.Contains(attr.Value) == false)
                {
                    regions.Add(attr.Value);
                }
                
            }
            regions.Sort();
            foreach (string item in regions)
            {
                if (item != "")
                {
                    if (comboBox1.InvokeRequired) comboBox1.Invoke(new Action<string>((it) => comboBox1.Items.Add(it)), item);
                    else comboBox1.Items.Add(item);
                }
                else
                {
                    if (comboBox1.InvokeRequired) comboBox1.Invoke(new Action<string>((it) => comboBox1.Items.Add(it)), "Крым другие города региона");
                    else comboBox1.Items.Add("Крым другие города региона");
                }
                
            }


        }

        private void LoadRegions(object sender, DoWorkEventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("https://pogoda.yandex.ru/static/cities.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes(String.Format("country[@name='Россия']/city[@part='{0}']", region));
            
            foreach (XmlNode item in childnodes)
            {

                cities.Add(item.InnerText);
                citiesnames.Add(item.InnerText);
                citiesnames.Sort();
                XmlNode attr = item.Attributes.GetNamedItem("region");
                regionids.Add(attr.Value);
                
            }
            foreach (string item in citiesnames)
            {
                if (comboBox2.InvokeRequired) comboBox2.Invoke(new Action<string>((it) => comboBox2.Items.Add(it)), item);
                else comboBox2.Items.Add(item);
            }

        }

        private void SaveCity(object sender, DoWorkEventArgs e)
        {
            int index = cities.IndexOf(city);
            string id = regionids[index];
            SettingsReader manager = new SettingsReader(GlobalVariables.apppath + @"\ComputerBuilderData\settings.ini");
            manager.WritePrivateString("Main", "City" , id);
            manager.WritePrivateString("Main", "CityName", city);
        }
        private void LoadCities_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            progressBar1.Increment(1);
        }

        private void Load_Complited(object sender, RunWorkerCompletedEventArgs e)
        {
            
            button1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Visible = false;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            citiesnames.Clear();
            regionids.Clear();
            cities.Clear();
            region = comboBox1.SelectedItem.ToString();
            
            button1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                button1.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                city = comboBox2.SelectedItem.ToString();
                progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 30;
                backgroundWorker3.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Выбирите город");
            }
            
            
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Visible = false;
            this.Close();
        }

        private void SelectCityWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
