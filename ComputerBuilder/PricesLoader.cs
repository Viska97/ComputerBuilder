using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Drawing;

namespace ComputerBuilder
{
    class PricesLoader
    {
        
        
        private CookieContainer cks = null;
        private HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        public PricesLoader(string id)
        {
            string city = null;
            SettingsReader manager = new SettingsReader(GlobalVariables.apppath + @"\ComputerBuilderData\settings.ini");
            city = manager.GetPrivateString("Main", "City");
            Cookies cs = new Cookies();
            cks = cs.Read(GlobalVariables.apppath + @"\ComputerBuilderData\coockies.txt");
            var request = (HttpWebRequest)WebRequest.Create(String.Format(@"https://market.yandex.ru/product/{0}?productId={0}&=&lr={1}", id, city));
            request.UserAgent = "Chrome";
            request.CookieContainer = cks;
            doc.OptionFixNestedTags = true;
            HttpWebResponse responce = (HttpWebResponse)request.GetResponse();
            doc.Load(responce.GetResponseStream(), Encoding.UTF8);

        }

        public string GetName()
        {
            try
            {
                HtmlNode namenode = null;
                string name = null;
                namenode = doc.DocumentNode.SelectSingleNode("//body/div[1]/div[4]/div[2]/div[2]/div/div[1]/div[1]/div/h1");
                name = namenode.InnerHtml;
                return name;
            }
            catch (Exception e)
            {
                return "0";
            }
        }

        public Bitmap GetImage()
        {
            string image = null;
            HtmlNode imagenode = null;
            imagenode = doc.DocumentNode.SelectSingleNode("//img[@class='n-gallery__image image']");
            image = "https:" + imagenode.GetAttributeValue("src", "");
            byte[] bitmapData;
            WebClient webClient = new WebClient();
            bitmapData = webClient.DownloadData(image);
            MemoryStream memoryStream = new MemoryStream(bitmapData);
            Bitmap bitmap = new Bitmap(memoryStream);
            return bitmap;
        }

        public string GetPrice()
        {
            try {
                string pricestring;
                HtmlNode pricenode = null;
                pricenode = doc.DocumentNode.SelectSingleNode("//body/div[1]/div[6]/div/div/div[2]/div[2]/div[2]/span");
                pricestring = pricenode.InnerHtml;
                pricestring = pricestring.Substring(0, pricestring.Length - 2);
                return pricestring;
            }
            catch(Exception e)
            {
                return "0";
            }
        }
    }
}
