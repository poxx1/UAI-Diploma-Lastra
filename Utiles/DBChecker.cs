using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (db.NoTransactionQuery(script)) return true;
            else return false;
        }

        public string readScript(string path)
        {
            StreamReader sr = new StreamReader(path);
            string script = sr.ReadToEnd();
            sr.Close();
            return script;
        }
    }
}