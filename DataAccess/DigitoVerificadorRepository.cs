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
        PermissionsRepository permisosRepository;
        LanguageRepository languageRepository;

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
                string query = $@"update DigitoVerificador set digitoVerificador = @digitoverificador where id_dv =@id";

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
                string query = $@"update DigitoVerificadorVertical set digitoVerificador = @digitoverificador where id_dv_v =@id";

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
    }
}
