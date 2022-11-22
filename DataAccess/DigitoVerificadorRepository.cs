using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.DBModel;
using Utiles;

namespace DataAccess
{
    public class DigitoVerificadorRepository
    {
        //PermissionsRepository permisosRepository;
        //LanguageRepository languageRepository;

        public void UpdateVertical(DBUsers user)
        {

            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update Users set digitoverificador = @digitoverificador where id_usuario =@id";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id", user.ID));
                cmd.Parameters.Add(new SqlParameter("digitoverificador", user.digitoVerificador));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        public void UpdateHorizontal(DigitoVerificadorModel user)
        {

            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update DigitoVerificador set digitoVerificador = @digitoverificador where id_dv = @id";
                //Esto anda mal porque los ID no coinciden, entonces no updatea una verga
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id", user.id_dv));
                cmd.Parameters.Add(new SqlParameter("digitoverificador", user.digitoVerificador));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        public void UpdateVertical(DigitoVerificadorModel user)
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update DigitoVerificadorVertical set digitoVerificador = @digitoverificador where id_dv_v =@id_dv_v";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id_dv_v", user.id_dv));
                cmd.Parameters.Add(new SqlParameter("digitoVerificador", user.digitoVerificador));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }

        public bool InsertHorizontal(DigitoVerificadorModel digitoVerificadorModel)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"INSERT into [DigitoVerificador]
                            ([id_dv]
                            ,[digitoVerificador]
                            )            
                        VALUES
                            ( @id_dv
                            , @digitoVerificador                        
                             )";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("id_dv", digitoVerificadorModel.id_dv));
                cmd.Parameters.Add(new SqlParameter("digitoVerificador", digitoVerificadorModel.digitoVerificador));

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
                //throw ex;
            }
        }
    }
}
