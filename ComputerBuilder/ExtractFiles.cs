using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ComputerBuilder
{
    class ExtractFiles
    {
        private string[] ListFiles = new string[] { @"\ComputerBuilderData\x64\SQLite.Interop.dll" ,
            @"\ComputerBuilderData\x86\SQLite.Interop.dll" , @"\ComputerBuilderData\EntityFramework.dll" , @"\ComputerBuilderData\EntityFramework.SqlServer.dll" ,
            @"\ComputerBuilderData\EntityFramework.SqlServer.xml" , @"\ComputerBuilderData\EntityFramework.xml" , @"\ComputerBuilderData\HtmlAgilityPack.dll", @"\ComputerBuilderData\HtmlAgilityPack.xml",
            @"\ComputerBuilderData\System.Data.SQLite.dll" , @"\ComputerBuilderData\System.Data.SQLite.EF6.dll" , @"\ComputerBuilderData\System.Data.SQLite.Linq.dll" , @"\ComputerBuilderData\System.Data.SQLite.xml",
            @"\ComputerBuilderData\computerbuilder.db" , @"\ComputerBuilder.exe.config" , @"\ComputerBuilderData\settings.ini" , @"\ComputerBuilderData\eula.txt"};
        private string[] ListFolders = new string[] { @"\ComputerBuilderData\x64", @"\ComputerBuilderData\x86" };
        private string startuppath;
        public bool needrestart = false;

        public ExtractFiles(string startuppath)
        {
            this.startuppath = startuppath.Remove(startuppath.LastIndexOf(@"\")); 
        }
        public void Extract()
        {
            for (int i = 0; i < ListFolders.Length; i++)
            {
                bool check = Directory.Exists(startuppath + ListFolders[i]);
                if (check == false)
                {
                    needrestart = true;
                    Directory.CreateDirectory(startuppath + ListFolders[i]);
                }
            }
            for (int i = 0; i < ListFiles.Length; i++)
            {
                bool checkfile = File.Exists(startuppath+ ListFiles[i]);
                if (checkfile == false)
                {
                    needrestart = true;
                    byte[] fl = ExtractFile(i);
                    File.WriteAllBytes(startuppath + ListFiles[i],fl);
                }
            }
            
        }
        private byte[] ExtractFile(int i)
        {
            byte[] fl = null;
            switch (i)
            {
                case 0:
                    fl = global::ComputerBuilder.Properties.Resources.SQLite_Interop_64_dll;
                    break;
                case 1:
                    fl = global::ComputerBuilder.Properties.Resources.SQLite_Interop_86_dll;
                    break;
                case 2:
                    fl = global::ComputerBuilder.Properties.Resources.EntityFramework_dll;
                    break;
                case 3:
                    fl = global::ComputerBuilder.Properties.Resources.EntityFramework_SqlServer_dll;
                    break;
                case 4:
                    fl = global::ComputerBuilder.Properties.Resources.EntityFramework_SqlServer_xml;
                    break;
                case 5:
                    fl = global::ComputerBuilder.Properties.Resources.EntityFramework_xml;
                    break;
                case 6:
                    fl = global::ComputerBuilder.Properties.Resources.HtmlAgilityPack_dll;
                    break;
                case 7:
                    fl = global::ComputerBuilder.Properties.Resources.HtmlAgilityPack_xml;
                    break;
                case 8:
                    fl = global::ComputerBuilder.Properties.Resources.System_Data_SQLite_dll;
                    break;
                case 9:
                    fl = global::ComputerBuilder.Properties.Resources.System_Data_SQLite_EF6_dll;
                    break;
                case 10:
                    fl = global::ComputerBuilder.Properties.Resources.System_Data_SQLite_Linq_dll;
                    break;
                case 11:
                    fl = global::ComputerBuilder.Properties.Resources.System_Data_SQLite_xml;
                    break;
                case 12:
                    fl = global::ComputerBuilder.Properties.Resources.computerbuilder;
                    break;
                case 13:
                    fl = global::ComputerBuilder.Properties.Resources.ComputerBuilder_exe_config;
                    break;
                case 14:
                    fl = global::ComputerBuilder.Properties.Resources.settingsini;
                    break;
                case 15:
                    fl = global::ComputerBuilder.Properties.Resources.eula;
                    break;
            }
            return fl;
        }
    }
}
