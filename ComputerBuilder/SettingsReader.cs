using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace ComputerBuilder
{
    class SettingsReader
    {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateString(string section, string key, string def, StringBuilder buffer, int size, string path);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern int WritePrivateString(string section, string key, string str, string path);

        private const int size = 1024; 
        private string path = null;
        public SettingsReader(string path)
        {
            this.path = path;
        }
        public string GetPrivateString(string section, string key)
        {
            if (File.Exists(path))
            {
                StringBuilder value = new StringBuilder(size);
                GetPrivateString(section, key, null, value, size, path);
                return value.ToString();
            }
            else
            {
                throw new Exceptions("Ошибка! Не найден файл настроек.");
            }
            
        }
        public void WritePrivateString(string section, string key, string value)
        {
            if (File.Exists(path))
            {
                WritePrivateString(section, key, value, path);
            }
            else
            {
                throw new Exceptions("Ошибка! Не найден файл настроек.");
            }
        }
    }
}
