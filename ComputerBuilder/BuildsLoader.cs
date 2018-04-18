using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Common;

namespace ComputerBuilder
{
    class BuildsLoader
    {
        private string order;
        private string segment;
        private SQLiteDataReader reader;
        public BuildsLoader(string order, string segment)
        {
            string commandtext;
            if (segment != "")
            {
                commandtext = String.Format("SELECT * FROM builds WHERE segment='{0}' ORDER BY avgprice {1}", segment, order);
            }
            else
            {
                commandtext = String.Format("SELECT * FROM builds ORDER BY avgprice {0}",  order);
            }
            
            SQLiteCommand command = new SQLiteCommand(commandtext, SqLiteWorker.connection);
            reader = command.ExecuteReader();

        }

        public List<string> GetBuilds()
        {
            List<string> builds = new List<string>();
            

            foreach (DbDataRecord record in reader)
            {
                builds.Add(Convert.ToString(record["title"]) +". Средняя цена:" + Convert.ToString(record["avgprice"])+" руб.");

            }
            return builds;
        }

    }
}
