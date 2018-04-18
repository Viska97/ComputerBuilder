using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;

namespace ComputerBuilder
{
    class Yandex
    {
        private readonly string login;

        private readonly string password;

        internal CookieContainer cookies;


        private readonly Uri passportUri = new Uri("https://passport.yandex.ru/passport?mode=auth");

        public Yandex(string login, string password)
        {
            if (login.Length == 0 || password.Length == 0)
            {
                throw new YandexExceptions("Пустое поле");
            }
            this.login = login;
            this.password = password;
        }

        public void Authorize()
        {


            HttpWebRequest request = GetRequest(passportUri,
                                              new KeyValuePair<string, string>("login", this.login),
                                              new KeyValuePair<string, string>("passwd", this.password),
                                              new KeyValuePair<string, string>("twoweeks", "yes"),
                                              new KeyValuePair<string, string>("retpath", ""));
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.ResponseUri == passportUri)
                {

                    throw new Exceptions("Неправильная пара логин-пароль! Авторизоваться не удалось.");
                }
            }

        }

        protected virtual HttpWebRequest GetRequest(Uri url, string method)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = method;
                if (cookies == null)
                {
                    cookies = new CookieContainer();
                }
                request.CookieContainer = cookies;
                request.KeepAlive = true;
                request.Headers[HttpRequestHeader.AcceptCharset] = Encoding.UTF8.WebName;
                request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
                request.AutomaticDecompression = DecompressionMethods.GZip;
                return request;
            }
            catch (Exception)
            {

                throw new Exceptions("Неизвестная ошибка");
            }

        }

        protected virtual HttpWebRequest GetRequest(Uri url, params KeyValuePair<string, string>[] headers)
        {
            try
            {
                HttpWebRequest request = GetRequest(url, WebRequestMethods.Http.Post);
                StringBuilder data = new StringBuilder(1024);
                for (int i = 0; i < headers.Length - 1; i++)
                {
                    data.AppendFormat("{0}={1}&",
                    HttpUtility.HtmlEncode(headers[i].Key),
                    HttpUtility.HtmlEncode(headers[i].Value));
                }
                if (headers.Length > 0)
                {
                    data.AppendFormat("{0}={1}",
                    HttpUtility.HtmlEncode(headers[headers.Length - 1].Key),
                    HttpUtility.HtmlEncode(headers[headers.Length - 1].Value));
                }

                byte[] rawData = Encoding.UTF8.GetBytes(data.ToString());
                request.ContentLength = rawData.Length;
                request.GetRequestStream().Write(rawData, 0, rawData.Length);
                return request;
            }
            catch (Exception)
            {

                throw new Exceptions("Неизвестная ошибка");
            }
        }
    }
}
