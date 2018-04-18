using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace ComputerBuilder
{
    class SqlConnect
    {
        public SqlConnect()
        {
            string sqlpath = GlobalVariables.apppath + @"\computerbuilder.db";
            SqLiteWorker.connection = new SQLiteConnection(string.Format("Data Source={0};", sqlpath));
            SqLiteWorker.connection.Open();
        }
    }
    public static class SqLiteWorker
    {
        public static SQLiteConnection connection { get; set; }

    }
}
