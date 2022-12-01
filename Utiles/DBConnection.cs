using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Utiles
{
    public class DBConnection
    {
        string connectionString = Properties.Resources.ConnectionString;
        public bool query(string query)
        {
            var objeto = new object();
            var objeto1 = new object();

            var cn = new SqlConnection(@"Server=DESKTOP-CUHS3KR\SQLEXPRESS; Initial Catalog=campo;Integrated Security=True");
            var cmd = new SqlCommand();

            cn.Open();

            cmd.CommandTimeout = 5;

            SqlTransaction myTrans;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.CommandText = query;

            myTrans = cn.BeginTransaction();

            cmd.Transaction = myTrans;

            string[] user = new string[2];

            object obj = new object();

            //Ejecuto la consulta
            try
            {
                using (SqlDataReader dr = cmd.ExecuteReader())

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = dr;
                        }
                    }
                    else
                    {
                        user[0] = "No existen ocurrencias para el server";
                    }

                myTrans.Commit();

                return true;
            }
            catch (SqlException e)
            {
                myTrans.Rollback();
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cn.Close();
            }

        }
        public bool NoTransactionQuery(string query)
        {
            var objeto = new object();
            var objeto1 = new object();

            var cn = new SqlConnection(@"Server=" + System.Environment.MachineName + @"\SQLEXPRESS" + "; Initial Catalog=master;Integrated Security=True");
            var cmd = new SqlCommand();

            cn.Open();

            cmd.CommandTimeout = 5;


            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.CommandText = query;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show($"SQL Exception triggered: {e}");
                return false;
                //throw e;
            }
            catch (Exception)
            {
                return false;
                //throw e;
            }
            finally
            {
                cn.Close();
            }

        }
        public bool GOQuery(string query)
        {
            ////var cn = new SqlConnection(@"Server=" + System.Environment.MachineName + @"\SQLEXPRESS" + "; Initial Catalog=master;Integrated Security=True");
            ////var cmd = new SqlCommand();

            string sqlConnectionString = (@"Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=master; Data Source=DESKTOP-CUHS3KR\SQLEXPRESS;");

            //Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(sqlConnectionString);
            ////
            //Server server = new Server(new ServerConnection(conn));

            //try
            //{
            //    server.ConnectionContext.ExecuteNonQuery(query);
            //    return true;
            //}
            //catch (SqlException e)
            //{
            //    MessageBox.Show($"SQL Exception triggered: {e}");
            //    return false;
            //    //throw e;
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show($"Exception triggered: {e}");
            //    return false;
            //    //throw e;
            //}
            //finally
            //{

            //}

            try
            {
                string script = query;

                // split script on GO command
                System.Collections.Generic.IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
                                         RegexOptions.Multiline | RegexOptions.IgnoreCase);
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    foreach (string commandString in commandStrings)
                    {
                        if (commandString.Trim() != "")
                        {
                            using (var command = new SqlCommand(commandString, connection))
                            {
                                try
                                {
                                    command.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    string spError = commandString.Length > 100 ? commandString.Substring(0, 100) + " ...\n..." : commandString;
                                    MessageBox.Show(string.Format("Please check the SqlServer script.\nFile: {0} \nLine: {1} \nError: {2} \nSQL Command: \n{3}", query, ex.LineNumber, ex.Message, spError), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

        }
        public bool NoTransactionQueryMaster(string query)
        {
            var objeto = new object();
            var objeto1 = new object();

            string DataSource = "";

            if (System.Environment.MachineName.Contains("LAB"))
            {
                DataSource = System.Environment.MachineName;
            }
            else
            {
                DataSource = System.Environment.MachineName + @"\SQLEXPRESS";
            }

            var cn = new SqlConnection(@"Server="+ DataSource + "; Initial Catalog=master;Integrated Security=True");
            var cmd = new SqlCommand();

            cn.Open();

            cmd.CommandTimeout = 5;

            
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.CommandText = query;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show($"SQL Exception triggered: {e}");
                return false;
                //throw e;
            }
            catch (Exception)
            {
                return false;
                //throw e;
            }
            finally
            {
                cn.Close();
            }

        }
        public string[] Select(string query)
        {
            //var user = new object();
            //var password = new object();

            var cn = new SqlConnection(connectionString);
            var cmd = new SqlCommand();

            cn.Open();

            cmd.CommandTimeout = 5;

            SqlTransaction myTrans;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.CommandText = query;

            myTrans = cn.BeginTransaction();

            cmd.Transaction = myTrans;

            string[] user = new string[2];

            //Ejecuto la consulta
            try
            {
                using (SqlDataReader dr = cmd.ExecuteReader())

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            user[0] = dr[0].ToString();
                            user[1] = dr[1].ToString();
                        }
                    }
                    else
                    {
                        user[0] = "No existen ocurrencias para el server";
                    }

                myTrans.Commit();

                return user;
            }
            catch (SqlException e)
            {
                myTrans.Rollback();
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cn.Close();
            }

        }
        public bool TestConnection()
        {
            string DataSource = "";

            if (System.Environment.MachineName.Contains("LAB"))
            {
                DataSource = System.Environment.MachineName;
            }
            else
            {
                DataSource = System.Environment.MachineName + @"\SQLEXPRESS";
            }

            var _conexion = new SqlConnection(@"Server=" + DataSource + "; Initial Catalog=campo;Integrated Security=True");
            //Abro la conexion
            try
            {
                _conexion.Open();
                _conexion.Close();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Cant connect to database!\r\n + {e}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                //
                return false;
            }
            return true;
        }
    }
}