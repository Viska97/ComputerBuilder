using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using HtmlAgilityPack;

namespace ComputerBuilder
{
    class YandexInfo
    {
        private HttpWebRequest request;
        private CookieContainer cooks;
        private HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

        public YandexInfo()
        {
            request = (HttpWebRequest)WebRequest.Create("https://passport.yandex.ru/passport?mode=auth");
            request.UserAgent = "Chrome";
            Cookies cs = new Cookies();
            cooks = cs.Read(GlobalVariables.apppath + @"\ComputerBuilderData\coockies.txt");
            request.CookieContainer = cooks;
            doc.OptionFixNestedTags = true;
            HttpWebResponse responce = (HttpWebResponse)request.GetResponse();
            doc.Load(responce.GetResponseStream(), Encoding.UTF8);
        }

        public string GetUserName()
        {
            HtmlNode name = null;
            HtmlNode firstname = null;
            string username;
            firstname = doc.DocumentNode.SelectSingleNode("//body/div/div[1]/div[3]/div[1]/div[2]/div[2]/span[1]");
            name = doc.DocumentNode.SelectSingleNode("//body/div/div[1]/div[3]/div[1]/div[2]/div[2]/text()");
            if (name == null)
            {
                username = null;
            }
            else
            {
                username = firstname.InnerHtml + name.InnerHtml;
            }
            return username;
        }

        public string GetUserAvatar()
        {
            string useravatar = null;
            HtmlNode avatarlink = null;
            avatarlink = doc.DocumentNode.SelectSingleNode("//body/div/div[1]/div[3]/div[1]/div[1]/div/span");
            if (avatarlink == null)
            {
                useravatar = "http://avatars.mds.yandex.net/get-yapic/0/0-0/islands-200";
            }
            else
            {
                useravatar = avatarlink.GetAttributeValue("style", "");
                useravatar = useravatar.Substring(useravatar.IndexOf("("));
                useravatar = useravatar.Replace("(", "");
                useravatar = useravatar.Replace(")", "");
            }
            return useravatar;
        }
    }
}
