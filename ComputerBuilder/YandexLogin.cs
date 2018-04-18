using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ComputerBuilder
{
    class YandexLogin
    {
        private string login, password;
        public YandexLogin(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        public bool Login()
        {
            CookieContainer test = new CookieContainer();
            Yandex yandex = new Yandex(login, password);
            ProgressChanged(1);
            yandex.Authorize();
            ProgressChanged(1);
            test = yandex.cookies;
            Cookies cs = new Cookies();
            cs.Write(test, GlobalVariables.apppath + @"\coockies.txt");
            ProgressChanged(1);
            return true;
        }

        public event Action<int> ProgressChanged;
        //public event Action<bool> WorkCompleted;
    }
}
