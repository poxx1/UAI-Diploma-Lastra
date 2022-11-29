using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiles
{
    public  class ConnectionSingleton
    {
        private static SqlConnection connection;

        private static SqlConnection constructor()
        {

            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.IntegratedSecurity = true;

            if (System.Environment.MachineName.Contains("LAB"))
            {
                cs.DataSource = System.Environment.MachineName;
            }
            else
            {
                cs.DataSource = System.Environment.MachineName + @"\SQLEXPRESS";
            }

            //System.Environment.MachineName + @"\SQLEXPRESS";
            cs.InitialCatalog = "campo";
            return new SqlConnection(cs.ConnectionString);
            
            //Desde el resource
            //return new SqlConnection(Properties.Resources.ConnectionString);
        }

        public static SqlConnection getConnection()
        {
            if (connection == null)
            {
                connection = constructor();
            }
            //connection.Close();
            return connection;
        }
    }
}
