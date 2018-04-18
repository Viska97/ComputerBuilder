using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace ComputerBuilder
{
    class Cookies
    {
        
        public Cookies()
        {
            
        }

        public void Write(CookieContainer cookies, string file)
        {
            var formatter = new SoapFormatter();
            using (Stream s = File.Create(file))
                formatter.Serialize(s, cookies);
            
        }

        public CookieContainer Read(string file)
        {
            CookieContainer container = null;
            var formatter = new SoapFormatter();
            using (Stream s = File.OpenRead(file))
                container = (CookieContainer)formatter.Deserialize(s);
            return container;
        }

    }
}
