using Models.language;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Utiles;

namespace DataAccess
{
    public class LanguageRepository
    {
        public List<Language> GetAllLanguagesWithoutTranslations()
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select * from idioma;";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                List<Language> lista = new List<Language>();

                while (reader.Read())
                {
                    Language language = new Language();
                    language.ID = reader.GetInt32(reader.GetOrdinal("id"));
                    language.Name = reader.GetString(reader.GetOrdinal("name"));
                    lista.Add(language);
                }

                reader.Close();
                connection.Close();

                return lista;
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
       
        //private SqlTransaction trans;
        public void InsertNewLanguage(DataTable dt,string name)
        {
            //Language lang = new Language();
            //try
            //{
            //    CreateLanguage(name);

            //    lang = GetLanguage(name);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("No se pudo agregar a la tabla Idiomas");
            //}

            SqlConnection connection = ConnectionSingleton.getConnection();
           
            //try
            //    {
            //    //trans = connection.BeginTransaction("Trans");
            //    connection.Open();
            //        var cmd = new SqlCommand();
            //        cmd.Connection = connection;

            //        var sql = $@"delete from traduccion where id_idioma = {lang.ID};";

            //        cmd.CommandText = sql;

            //        SqlDataReader reader = cmd.ExecuteReader();

            //        reader.Close();
            //        connection.Close();
            //    }
            //    catch
            //    {
            //        connection.Close();
            //        throw;
            //    }

                try
                {
                connection = ConnectionSingleton.getConnection();

                connection.Open();                

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                    {
                        foreach (DataColumn c in dt.Columns)
                            bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);

                        bulkCopy.DestinationTableName = "traduccion";
                        try
                        {
                            bulkCopy.WriteToServer(dt);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                //trans.Commit();

                connection.Close();
            }
                catch (Exception ex)
                {
                //if (trans != null) trans.Rollback();

                connection.Close();
                throw ex;
                }
            
        }
        public void saveLanguage(DataTable dt, int id)
        {  
            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                //trans = connection.BeginTransaction("Trans");
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"delete from traduccion where id_idioma = {id};";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                reader.Close();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }

            try
            {
                connection = ConnectionSingleton.getConnection();

                connection.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    foreach (DataColumn c in dt.Columns)
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);

                    bulkCopy.DestinationTableName = "traduccion";
                    try
                    {
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //trans.Commit();

                connection.Close();
            }
            catch (Exception ex)
            {
                //if (trans != null) trans.Rollback();

                connection.Close();
                throw ex;
            }

        }

        private DataTable dataTable = new DataTable();

        public DataTable GetLanguageDataTable(int ID)
        {
            //string connString = @"your connection string here";
            string query = $"select * from traduccion where id_idioma = {ID.ToString()}";

            SqlConnection conn = ConnectionSingleton.getConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();

            return dataTable;
        }

        public void updateTranslation(string key, string value, Language language)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = $@"UPDATE [dbo].[traduccion]
                                     SET [traduccion] = @value
                                     WHERE [key] = @key and [id_idioma] = @languageId";
                cmd.Parameters.Add(new SqlParameter("key", key));
                cmd.Parameters.Add(new SqlParameter("value", value));
                cmd.Parameters.Add(new SqlParameter("languageId", language.ID));

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al actualizar");
            }
        }

        public void createTranslation(string key, string value, Language language)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = $@"
                                    INSERT INTO [dbo].[traduccion]
                                               ([id_idioma]
                                               ,[key]
                                               ,[traduccion])
                                         VALUES
                                               (@languageId
                                               ,@key
                                               ,@value)";
                cmd.Parameters.Add(new SqlParameter("key", key));
                cmd.Parameters.Add(new SqlParameter("value", value));
                cmd.Parameters.Add(new SqlParameter("languageId", language.ID));

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al crear");
            }
        }

        public List<Language> GetAllLanguagesWithTranslations()
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select * from idioma;";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                List<Language> lista = new List<Language>();

                while (reader.Read())
                {
                    Language language = new Language();
                    language.ID = reader.GetInt32(reader.GetOrdinal("id"));
                    language.Name = reader.GetString(reader.GetOrdinal("name"));
                    lista.Add(language);
                }

                reader.Close();
                connection.Close();
                foreach (Language languaje in lista)
                {
                    languaje.Translations = GetTranslations(languaje);
                }

                return lista;
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        public Language GetLanguage(string name)
        {
            SqlConnection connection = ConnectionSingleton.getConnection();

            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select * from idioma i where i.name = '{name}'";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();


                Language language = new Language();
                while (reader.Read())
                {
                    language.ID = reader.GetInt32(reader.GetOrdinal("id"));
                    language.Name = reader.GetString(reader.GetOrdinal("name"));
                }
                reader.Close();
                connection.Close();

                language.Translations = GetTranslations(language);

                return language;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }



        }
        public Language GetLanguage(int id)
        {
            SqlConnection connection = ConnectionSingleton.getConnection();

            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select * from idioma i where i.id = '{id}'";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();


                Language language = new Language();
                while (reader.Read())
                {
                    language.ID = reader.GetInt32(reader.GetOrdinal("id"));
                    language.Name = reader.GetString(reader.GetOrdinal("name"));
                }
                reader.Close();
                connection.Close();

                language.Translations = GetTranslations(language);

                return language;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }
        private List<Translation> GetTranslations(Language language)
        {
            SqlConnection connection = ConnectionSingleton.getConnection();

            try
            {

                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select * from traduccion where id_idioma = {language.ID};";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                List<Translation> lista = new List<Translation>();

                while (reader.Read())
                {
                    Translation translation = new Translation();
                    translation.Translate = reader.GetString(reader.GetOrdinal("traduccion"));
                    translation.Key = reader.GetString(reader.GetOrdinal("key"));
                    lista.Add(translation);
                }

                reader.Close();
                connection.Close();

                return lista;

            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

        }
        public void CreateLanguage(string name)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = $@"insert into idioma (name) values (@nombre) "; ;
                cmd.Parameters.Add(new SqlParameter("nombre", name));

                cmd.ExecuteNonQuery();

                connection.Close();

                //return GetAllLanguagesWithoutTranslations().First(lang => lang.Name.Equals(name));
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al crear el idioma");
            }
        }
        public DataSet GetDataSet()
        {
            List<Language> languages = GetAllLanguagesWithoutTranslations();
            string languagesString = string.Join(",", (languages.Select(language => language.Name).ToArray()));

            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select * from (
	                            select i.name as nombre , t.[key] as Clave,t.traduccion as traduccion
	                            from idioma i 
	                            inner join traduccion t on i.id = t.id_idioma
                            ) asd
                            pivot(
                            max  (traduccion) 
                            for nombre
                            in ( {languagesString} )
                            )as p
                            ";

                cmd.CommandText = sql;


                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet, "mitabla");


                connection.Close();

                return dataSet;
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
    }
}