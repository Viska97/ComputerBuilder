using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;
using System.Threading.Tasks;

namespace ComputerBuilder
{
    public partial class LoadingWindow : Form
    {
        private string idinbase;
        private string[] products = new string[10] { "cpu", "fan", "mobo", "ram", "gpu", "hdd", "ssd", "net", "psu" , "case" };
        private string[] tovarslinks = new string[10];
        private string[] tovarsnames = new string[10];
        private string[] tovarsprives = new string[10];
        private Bitmap[] tovarsimages = new Bitmap[10];
        private string title = null;
        public LoadingWindow(string idinbase)
        {
            InitializeComponent();
            this.idinbase = idinbase;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10;
            backgroundWorker1.RunWorkerAsync();
            
        }

        private void LoadingWindow_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string city = null;
            title = idinbase;
            SQLiteCommand command = new SQLiteCommand(String.Format("SELECT * FROM builds WHERE title='{0}'", idinbase), SqLiteWorker.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            SettingsReader manager = new SettingsReader(GlobalVariables.apppath + @"\ComputerBuilderData\settings.ini");
            city = manager.GetPrivateString("Main", "City");
            foreach (DbDataRecord record in reader)
            {
                int j = 1;
                Parallel.For(0, 10, (i, state) => 
                {
                    if (Convert.ToString(record[products[i]]) != "no")
                    {
                        PricesLoader pl = new PricesLoader(Convert.ToString(record[products[i]]));
                        tovarsnames[i] = pl.GetName();
                        tovarsimages[i] = pl.GetImage();
                        tovarsprives[i] = pl.GetPrice();
                        tovarslinks[i] = String.Format("https://market.yandex.ru/product/{0}?productId={0}&=&lr={1}", Convert.ToString(record[products[i]]), city);
                    }
                    else
                    {
                        tovarsnames[i] = "Нет";
                        tovarsimages[i] = ComputerBuilder.Properties.Resources.Computer_96;
                        tovarsprives[i] = "0";
                        tovarslinks[i] = "";

                    }
                    backgroundWorker1.ReportProgress(j);
                    j++;
                    
                });

            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = String.Format("Загрузка ({0}/10)", e.ProgressPercentage);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            BuildInfo bw = new BuildInfo(tovarslinks, tovarsnames, tovarsprives, tovarsimages, title);
            bw.ShowDialog();
            this.Close();
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            BuildInfo bw = new BuildInfo(tovarslinks, tovarsnames, tovarsprives, tovarsimages, title);
            bw.ShowDialog();
        }

        
    }
}
