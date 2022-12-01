using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Utiles
{
    public class DBChecker
    {
        public bool dbExists()
        {
            DBConnection db = new DBConnection();
            if(db.TestConnection()) return true;
            else return false;
        }

        public bool CreateDB(string script)
        {
            DBConnection db = new DBConnection();
            if (db.GOQuery(script)) return true;
            else return false;
        }

        public string readScript(string path)
        {
            StreamReader sr = new StreamReader(path);
            //string script = sr.ReadToEnd();
            //script = script.Replace("\r\n"," ");
            //return script;

            string script = File.ReadAllText(path);
            sr.Close();

            return script;
        }
    }
}