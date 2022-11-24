using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiles; //Reworkear para que sea Services o Utilities, porque queda una verga ese nombre

namespace Business
{
    public class BackupRestoreService
    {
        public bool makeBackup(string query)
        {
            DBConnection db = new DBConnection();
            if (db.NoTransactionQuery(query))
                return true;
            else
                return false;
        }

        public bool restoreBackup(string query)
        {
            DBConnection db = new DBConnection();
            if (db.NoTransactionQueryMaster(query))
                return true;
            else
                return false;
        }
    }
}
